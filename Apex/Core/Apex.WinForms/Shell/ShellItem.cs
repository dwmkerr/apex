using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Apex.WinForms.Interop;

namespace Apex.WinForms.Shell
{
    /// <summary>
    /// Represents a ShellItem object.
    /// </summary>
    public class ShellItem : IDisposable
    {
        /// <summary>
        /// Initializes the <see cref="ShellItem"/> class.
        /// </summary>
        static ShellItem()
        {
            //  Create the lazy desktop shell folder.
            desktopShellFolder = new Lazy<ShellItem>(CreateDesktopShellFolder);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellItem"/> class.
        /// </summary>
        public ShellItem()
        {
            //  Create the lazy path.
            path = new Lazy<string>(CreatePath);
        }

        /// <summary>
        /// Creates the desktop shell folder.
        /// </summary>
        /// <returns>The desktop shell folder.</returns>
        private static ShellItem CreateDesktopShellFolder()
        {
            //  Get the desktop shell folder interface. 
            IShellFolder desktopShellFolderInterface = null;
            var result = Shell32.SHGetDesktopFolder(ref desktopShellFolderInterface);

            //  Validate the result.
            if(result != 0)
            {
                //  Throw the failure as an exception.
                Marshal.ThrowExceptionForHR(result);
            }
            
            //  Get the dekstop PDIL.
            var desktopPIDL = IntPtr.Zero;
            result = Shell32.SHGetSpecialFolderLocation(IntPtr.Zero, CSIDL.CSIDL_DESKTOP, ref desktopPIDL);
            
            //  Validate the result.
            if(result != 0)
            {
                //  Throw the failure as an exception.
                Marshal.ThrowExceptionForHR(result);
            }

            //  Get the file info.
            var fileInfo = new SHFILEINFO();
            Shell32.SHGetFileInfo(desktopPIDL, 0, out fileInfo, (uint) Marshal.SizeOf(fileInfo), 
                SHGFI.SHGFI_DISPLAYNAME | SHGFI.SHGFI_PIDL | SHGFI.SHGFI_SMALLICON | SHGFI.SHGFI_SYSICONINDEX);

            //  Return the Shell Folder.
            return new ShellItem
                       {
                           DisplayName = fileInfo.szDisplayName,
                           IconIndex = fileInfo.iIcon,
                           HasSubFolders = true,
                           ShellFolderInterface = desktopShellFolderInterface
                       };
        }

        /// <summary>
        /// Initialises the ShellItem, from its PIDL and parent.
        /// </summary>
        /// <param name="pidl">The pidl.</param>
        /// <param name="parentFolder">The parent folder.</param>
        private void Initialise(IntPtr pidl, ShellItem parentFolder)
        {
            //  Set the parent item and relative pidl.
            ParentItem = parentFolder;
            RelativePIDL = pidl;

            //  Create the fully qualified PIDL.
            PIDL = Shell32.ILCombine(parentFolder.PIDL, pidl);

            //  Use the desktop folder to get attributes.
            var flags = SFGAO.SFGAO_FOLDER | SFGAO.SFGAO_HASSUBFOLDER | SFGAO.SFGAO_BROWSABLE | SFGAO.SFGAO_FILESYSTEM;
            parentFolder.ShellFolderInterface.GetAttributesOf(1, ref pidl, ref flags);
            IsFolder = (flags & SFGAO.SFGAO_FOLDER) != 0;
            HasSubFolders = (flags & SFGAO.SFGAO_HASSUBFOLDER) != 0;

            //  Get the file info.
            var fileInfo= new SHFILEINFO();
            Shell32.SHGetFileInfo(PIDL, 0, out fileInfo, (uint) Marshal.SizeOf(fileInfo),  
                SHGFI.SHGFI_SMALLICON | SHGFI.SHGFI_SYSICONINDEX | SHGFI.SHGFI_PIDL | SHGFI.SHGFI_DISPLAYNAME | SHGFI.SHGFI_ATTRIBUTES);

            //  Set extended attributes.
            DisplayName = fileInfo.szDisplayName;
            Attributes = (SFGAO)fileInfo.dwAttributes;
            TypeName = fileInfo.szTypeName;
            IconIndex = fileInfo.iIcon;
            
            //  Are we a folder?
            if (IsFolder)
            {
                //  Bind the shell folder interface.
                IShellFolder shellFolderInterface;
                var result = parentFolder.ShellFolderInterface.BindToObject(pidl, IntPtr.Zero, ref Shell32.IID_IShellFolder, out shellFolderInterface);
                ShellFolderInterface = shellFolderInterface;

                //  Validate the result.
                if(result != 0)
                {
                    //  Throw the failure as an exception.
                    Marshal.ThrowExceptionForHR((int)result);
                }
            }
        }
        
        /// <summary>
        /// Gets the system path for this shell item.
        /// </summary>
        /// <returns>A path string.</returns>
        private string CreatePath()
        {
            var stringBuilder = new StringBuilder(256);
            Shell32.SHGetPathFromIDList(PIDL, stringBuilder);
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Gets the children.
        /// </summary>
        /// <param name="childTypes">The child types.</param>
        /// <returns>
        /// The children.
        /// </returns>
        public IEnumerable<ShellItem> GetChildren(ChildTypes childTypes)
        {
            //  We'll return a list of children.
            var children = new List<ShellItem>();
            
            //  Create the enum flags from the childtypes.
            SHCONTF enumFlags = SHCONTF.None;
            if(childTypes.HasFlag(ChildTypes.Folders))
                enumFlags |= SHCONTF.SHCONTF_FOLDERS;
            if (childTypes.HasFlag(ChildTypes.Files))
                enumFlags |= SHCONTF.SHCONTF_NONFOLDERS;
            if (childTypes.HasFlag(ChildTypes.Hidden))
                enumFlags |= SHCONTF.SHCONTF_INCLUDEHIDDEN;

            try
            {
                //  Create an enumerator for the children.
                IEnumIDList pEnum;
                var result = ShellFolderInterface.EnumObjects(IntPtr.Zero, enumFlags, out pEnum);

                //  Validate the result.
                if (result != 0)
                {
                    //  Throw the failure as an exception.
                    Marshal.ThrowExceptionForHR((int)result);
                }

                //  Start going through children.
                IntPtr childPIDL;
                int enumResult;
                pEnum.Next(1, out childPIDL, out enumResult);

                //  Now start enumerating.
                while (childPIDL != IntPtr.Zero && enumResult == 1)
                {
                    //  Create a new shell folder.
                    var childShellFolder = new ShellItem();

                    //  Initialize it.
                    try
                    {
                        childShellFolder.Initialise(childPIDL, this);
                    }
                    catch (Exception exception)
                    {
                        throw new InvalidOperationException("Failed to initialise child.", exception);
                    }

                    //  Add the child.
                    children.Add(childShellFolder);

                    //  Free the PIDL, reset the result.
                    Marshal.FreeCoTaskMem(childPIDL);

                    //  Move onwards.
                    pEnum.Next(1, out childPIDL, out enumResult);
                }

                //  Release the enumerator.
                Marshal.ReleaseComObject(pEnum);
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Failed to enumerate children." , exception);
            }

            //  Sort the children.
            var sortedChildren = children.Where(c => c.IsFolder).ToList();
            sortedChildren.AddRange(children.Where(c => !c.IsFolder));

            //  Return the children.
            return sortedChildren;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            //  Release the shell folder interface.
            if (ShellFolderInterface != null)
                Marshal.ReleaseComObject(ShellFolderInterface);

            //  Free the PIDL.
            if (PIDL != IntPtr.Zero)
                Marshal.FreeCoTaskMem(PIDL);

            //  Suppress finalization.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(DisplayName) ? base.ToString() : DisplayName;
        }

        /// <summary>
        /// The lazy desktop shell folder.
        /// </summary>
        private static readonly Lazy<ShellItem> desktopShellFolder;

        /// <summary>
        /// The lazy path.
        /// </summary>
        private readonly Lazy<string> path;

        /// <summary>
        /// Gets the parent item.
        /// </summary>
        public ShellItem ParentItem { get; private set; }

        /// <summary>
        /// Gets a value indicating whether this instance is folder.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is folder; otherwise, <c>false</c>.
        /// </value>
        public bool IsFolder { get; private set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Gets the name of the type.
        /// </summary>
        /// <value>
        /// The name of the type.
        /// </value>
        public string TypeName { get; private set; }

        /// <summary>
        /// Gets the attributes.
        /// </summary>
        public SFGAO Attributes { get; private set; }

        /// <summary>
        /// Gets the index of the icon.
        /// </summary>
        /// <value>
        /// The index of the icon.
        /// </value>
        public int IconIndex { get; private set; }

        /// <summary>
        /// Gets the ShellFolder of the Desktop.
        /// </summary>
        public static ShellItem DesktopShellFolder { get { return desktopShellFolder.Value; } }

        /// <summary>
        /// Gets the shell folder interface.
        /// </summary>
        public IShellFolder ShellFolderInterface { get; private set; }

        /// <summary>
        /// Gets the Full PIDL.
        /// </summary>
        public IntPtr PIDL { get; private set; }

        /// <summary>
        /// Gets the relative PIDL.
        /// </summary>
        public IntPtr RelativePIDL { get; private set; }
        
        /// <summary>
        /// Gets a value indicating whether this instance has children.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has children; otherwise, <c>false</c>.
        /// </value>
        public bool HasSubFolders { get; private set; }

        /// <summary>
        /// Gets the path.
        /// </summary>
        public string Path { get { return path.Value; } }
    }
}
