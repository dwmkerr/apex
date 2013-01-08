using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellListView"/> class.
        /// </summary>
        public ShellListView()
        {
            //  Create a small and normal image list.
            LargeImageList = new ImageList { ImageSize = new Size(32, 32), ColorDepth = ColorDepth.Depth32Bit};
            SmallImageList = new ImageList { ImageSize = new Size(16, 16), ColorDepth = ColorDepth.Depth32Bit };
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
            var selectedFolder = associatedTreeView.GetShellItem(selectedNode);

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
        public void Initialise(ShellItem parentFolder)
        {
            //  If we're not double buffered, we want to be.
            if(!DoubleBuffered)
                DoubleBuffered = true;

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

            //  Work out what images we're using.
            bool smallImages = View == View.SmallIcon || View == View.Details || View == View.List;
            var imageList = smallImages ? SmallImageList : LargeImageList;

            //  Go through the children.
            foreach (var child in parentFolder.GetChildren(childTypes))
            {
                //  Do we need to create the icon for the item?
                if (shellIconIndexesToCacheIconIndexes.ContainsKey(child.IconIndex) == false)
                {
                    //  Get the shell icon for the item.
                    var shellIcon = Icon.FromHandle(ComCtl32.ImageList_GetIcon(
                        smallImages
                        ? ShellImageList.GetImageList(ShellImageListSize.Small) 
                        : ShellImageList.GetImageList(ShellImageListSize.Large), child.IconIndex, 0));

                    //  Create it and add it.
                    var mappedIndex = imageList.Images.Count;
                    imageList.Images.Add(shellIcon);
                    shellIconIndexesToCacheIconIndexes[child.IconIndex] = mappedIndex;
                }

                //  Create an item.
                var item = new ListViewItem
                               {
                                   Text = child.DisplayName,
                                   ImageIndex = shellIconIndexesToCacheIconIndexes[child.IconIndex]
                               };

                //  Map it.
                itemsToFolders[item] = child;

                //  Insert the item.
                Items.Add(item);

                //  Fire the event handler.
                FireOnShellItemAdded(item);
            }
        }

        /// <summary>
        /// Gets the shell item for a list view item.
        /// </summary>
        /// <param name="listViewItem">The list view item.</param>
        /// <returns>The shell item for the list view item.</returns>
        public ShellItem GetShellItem(ListViewItem listViewItem)
        {
            ShellItem item;
            itemsToFolders.TryGetValue(listViewItem, out item);
            return item;
        }

        /// <summary>
        /// Fires the on shell item added event.
        /// </summary>
        /// <param name="itemAdded">The item added.</param>
        private void FireOnShellItemAdded(ListViewItem itemAdded)
        {
            //  Fire the event if we have it.
            var theEvent = OnShellItemAdded;
            if(theEvent != null)
                theEvent(this, new ListViewItemEventArgs(itemAdded));;
        }

        /// <summary>
        /// Map of list view items to shell folders.
        /// </summary>
        private readonly Dictionary<ListViewItem, ShellItem> itemsToFolders = new Dictionary<ListViewItem, ShellItem>();

        /// <summary>
        /// Map of shell image list icon indexes to shell icon indexes.
        /// </summary>
        private readonly Dictionary<int, int> shellIconIndexesToCacheIconIndexes = new Dictionary<int, int>(); 

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

        /// <summary>
        /// Occurs when a shell item is added.
        /// </summary>
        [Category("Shell List View")]
        [Description("Called when a shell item is added.")]
        public event ListViewItemEventHandler OnShellItemAdded;
    }

    public class ListViewItemEventArgs : EventArgs
    {
        public ListViewItemEventArgs(ListViewItem item)
        {
            Item = item;
        }

        public ListViewItem Item { get; private set; }
    }

    public delegate void ListViewItemEventHandler(object sender, ListViewItemEventArgs args);
}
