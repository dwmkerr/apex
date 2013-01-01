using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Apex.WinForms.Interop;
using Apex.WinForms.Shell;

namespace Apex.WinForms.Controls
{
    /// <summary>
    /// The ShellListView is a list view to show shell data in a similar way to windows explorer.
    /// </summary>
    public class ShellListView : ListView
    {
        public ShellListView()
        {
            SetImageList(ShellImageList.GetImageList(ShellImageListSize.Large));// ShellImageList.LargeImageListHandle);
        }

        /// <summary>
        /// Deassociates the shell tree view.
        /// </summary>
        /// <param name="shellTreeView">The shell tree view.</param>
        private void DeassociateShellTreeView(ShellTreeView shellTreeView)
        {
            //  Remove the event handler.
            shellTreeView.AfterSelect -= shellTreeView_AfterSelect;
        }

        /// <summary>
        /// Associates the tree view.
        /// </summary>
        /// <param name="shellTreeView">The shell tree view.</param>
        private void AssociateShellTreeView(ShellTreeView shellTreeView)
        {
            //  We'll need to know when an item is selected.
            shellTreeView.AfterSelect += shellTreeView_AfterSelect;
        }

        /// <summary>
        /// Handles the AfterSelect event of the shellTreeView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        void shellTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //  Get the selected node.
            var selectedNode = e.Node;

            //  If there isn't one, we're done.
            if (selectedNode == null)
                return;

            //  Get the selected folder.
            var selectedFolder = associatedTreeView.GetNodeShellFolder(selectedNode);

            //  If there isn't one, we're done.
            if (selectedFolder == null)
                return;

            //  Now show the children of the selected folder.
            Initialise(selectedFolder);
        }

        /// <summary>
        /// Initialises the specified parent folder.
        /// </summary>
        /// <param name="parentFolder">The parent folder.</param>
        private void Initialise(ShellFolder parentFolder)
        {
            //  Clear children.
            Items.Clear();

            //  Clear the map.
            itemsToFolders.Clear();

            //  Work out the types to show.
            var childTypes = ChildTypes.Files;
            if(ShowHiddenFilesAndFolders)
                childTypes |= ChildTypes.Hidden;
            if(ShowFolders)
                childTypes |= ChildTypes.Folders;

            //  Go through the children.
            foreach (var child in parentFolder.GetChildren(childTypes))
            {
                //  Create an item.
                var item = new ListViewItem
                               {
                                   Text = child.DisplayName,
                                   ImageIndex = child.IconIndex
                               };

                //  Map it.
                itemsToFolders[item] = child;

                //  Insert the item.
                Items.Add(item);
            }
        }

        private void SetImageList(IntPtr imageListHandle)
        {
            //  Set the image list.
            var result = User32.SendMessage(Handle, LVM_SETIMAGELIST, LVSIL_NORMAL, imageListHandle);

            //  Validate the result.
            if (result != 0)
                Marshal.ThrowExceptionForHR(result);
        }

        private const uint LVM_FIRST = 0x1000;
        private const uint LVM_SETIMAGELIST = (LVM_FIRST + 3);
        private const uint LVSIL_NORMAL = 0; 

        /// <summary>
        /// Map of list view items to shell folders.
        /// </summary>
        private readonly Dictionary<ListViewItem, ShellFolder> itemsToFolders = new Dictionary<ListViewItem, ShellFolder>(); 

        /// <summary>
        /// The associated tree view.
        /// </summary>
        private ShellTreeView associatedTreeView;

        /// <summary>
        /// Gets or sets the association tree view.
        /// </summary>
        /// <value>
        /// The association tree view.
        /// </value>
        [Category("Shell List View")]
        [Description("If an associated Shell Tree View is specified, this view will automatically show the children " + 
            "of the item selected in the tree view.")]
        public ShellTreeView AssociationTreeView
        {
            get
            {
                return associatedTreeView;
            }
            set
            {
                //  Handle the trivial case.
                if (value == associatedTreeView)
                    return;

                //  Do we need to de-associate a tree view?
                if (associatedTreeView != null)
                    DeassociateShellTreeView(associatedTreeView);

                //  Do we need to associate a tree view?
                if (value != null)
                {
                    AssociateShellTreeView(value);
                    associatedTreeView = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether to show hidden files and folders.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if show hidden files and folders; otherwise, <c>false</c>.
        /// </value>
        [Category("Shell List View")]
        [Description("If set to true, hidden files and folders will be shown.")]
        public bool ShowHiddenFilesAndFolders { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to show folders as well as files.
        /// </summary>
        /// <value>
        ///   <c>true</c> if show files; otherwise, <c>false</c>.
        /// </value>
        [Category("Shell List View")]
        [Description("If set to true, folders will be shown as well as files.")]
        public bool ShowFolders { get; set; }
    }
}
