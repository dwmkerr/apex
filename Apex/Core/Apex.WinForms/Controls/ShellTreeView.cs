using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Apex.WinForms.Interop;
using Apex.WinForms.Shell;

namespace Apex.WinForms.Controls
{
    /// <summary>
    /// The ShellTreeView is a tree view that is designed to show contents of the system,
    /// just like in Windows Explorer.
    /// </summary>
    public class ShellTreeView : TreeView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellTreeView"/> class.
        /// </summary>
        public ShellTreeView()
        {
            //  Set the image list to the shell image list.
            SetImageList(ShellImageList.GetImageList(ShellImageListSize.Small));// ShellImageList.SmallImageListHandle);
        }

        /// <summary>
        /// Raises the <see cref="M:System.Windows.Forms.Control.CreateControl"/> method.
        /// </summary>
        protected override void OnCreateControl()
        {
            //  Call the base.
            base.OnCreateControl();

            //  Add the desktop node, if we're not in design mode.
            if (!DesignMode)
                AddDesktopNode();
        }

        /// <summary>
        /// Adds the desktop node.
        /// </summary>
        private void AddDesktopNode()
        {
            //  Get the desktop folder.
            var desktopFolder = ShellFolder.DesktopShellFolder;

            //  Create the desktop node.
            var desktopNode = new TreeNode
                                  {
                                      Text = desktopFolder.DisplayName,
                                      ImageIndex = desktopFolder.IconIndex,
                                      SelectedImageIndex = desktopFolder.IconIndex,
                                  };

            //  Map it and add it.
            nodesToFolders[desktopNode] = desktopFolder;
            Nodes.Add(desktopNode);
            
            //  Expand it.
            OnBeforeExpand(new TreeViewCancelEventArgs(desktopNode, false, TreeViewAction.Expand));
            desktopNode.Expand();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.TreeView.BeforeExpand"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.TreeViewCancelEventArgs"/> that contains the event data.</param>
        protected override void OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            //  Get the node.
            var node = e.Node;

            //  Clear children - which may in fact be the placeholder.
            node.Nodes.Clear();

            //  Get the shell folder.
            var shellFolder = nodesToFolders[node];

            //  Create the enum flags.
            var childFlags = ChildTypes.Folders | ChildTypes.Files;
            if(ShowFiles)
                childFlags |= ChildTypes.Files;
            if (ShowHiddenFilesAndFolders)
                childFlags |= ChildTypes.Hidden;

            //  Go through each child.
            foreach (var child in shellFolder.GetChildren(childFlags))
            {
                //  Create a child node.
                var childNode = new TreeNode
                                    {
                                        Text = child.DisplayName,
                                        ImageIndex = child.IconIndex,
                                        SelectedImageIndex = child.IconIndex,
                                    };

                //  Map the node to the shell folder.
                nodesToFolders[childNode] = child;

                //  If this item has children, add a child node as a placeholder.
                if (child.HasChildren)
                    childNode.Nodes.Add(string.Empty);

                //  Add the child node.
                node.Nodes.Add(childNode);
            }

            //  Call the base.
            base.OnBeforeExpand(e);
        }

        /// <summary>
        /// Sets the image list.
        /// </summary>
        /// <param name="imageListHandle">The image list handle.</param>
        private void SetImageList(IntPtr imageListHandle)
        {
            //  Set the image list.
            var result = User32.SendMessage(Handle, TVM_SETIMAGELIST, TVSIL_NORMAL, imageListHandle);
            
            //  Validate the result.
            if(result != 0)
                Marshal.ThrowExceptionForHR(result);
        }

        /// <summary>
        /// Gets the node shell folder.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns>The node shell folder.</returns>
        internal ShellFolder GetNodeShellFolder(TreeNode node)
        {
            ShellFolder shellFolder;
            if(nodesToFolders.TryGetValue(node, out shellFolder))
                return shellFolder;
            return null;
        }

        /// <summary>
        /// A map of tree nodes to the Shell Folders.
        /// </summary>
        private readonly Dictionary<TreeNode, ShellFolder> nodesToFolders = new Dictionary<TreeNode, ShellFolder>();

        /// <summary>
        /// Gets or sets a value indicating whether to show hidden files and folders.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if show hidden files and folders; otherwise, <c>false</c>.
        /// </value>
        [Category("Shell Tree View")]
        [Description("If set to true, hidden files and folders will be shown.")]
        public bool ShowHiddenFilesAndFolders { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show files.
        /// </summary>
        /// <value>
        ///   <c>true</c> if show files; otherwise, <c>false</c>.
        /// </value>
        [Category("Shell Tree View")]
        [Description("If set to true, files will be shown as well as folders.")]
        public bool ShowFiles { get; set; }

        /// <summary>
        /// Gets a value that indicates whether the <see cref="T:System.ComponentModel.Component"/> is currently in design mode.
        /// </summary>
        /// <returns>true if the <see cref="T:System.ComponentModel.Component"/> is in design mode; otherwise, false.</returns>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool DesignMode { get { return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv"); } }

        private const UInt32 TVSIL_NORMAL = 0;
        private const UInt32 TVM_SETIMAGELIST = 4361;
    }
}
