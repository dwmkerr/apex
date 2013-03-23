using Apex.WinForms.Controls;

namespace ControlsSample
{
    partial class FormControlsSample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormControlsSample));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageColorMap = new System.Windows.Forms.TabPage();
            this.colorMap = new Apex.Controls.ColorMap();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageExpandingPanel = new System.Windows.Forms.TabPage();
            this.expandingPanelContainer1 = new Apex.Controls.ExpandingPanelContainer();
            this.expandingPanel2 = new Apex.Controls.ExpandingPanel();
            this.expandingPanel1 = new Apex.Controls.ExpandingPanel();
            this.tabPagePathTextBox = new System.Windows.Forms.TabPage();
            this.textBox1 = new Apex.WinForms.Controls.PathTextBox();
            this.tabPageShellTreeList = new System.Windows.Forms.TabPage();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.shellTreeView1 = new Apex.WinForms.Controls.ShellTreeView();
            this.shellListView1 = new Apex.WinForms.Controls.ShellListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonTreeShowFiles = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTreeShowHidden = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonListShowFolders = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonListShowHidden = new System.Windows.Forms.ToolStripButton();
            this.tabControl.SuspendLayout();
            this.tabPageColorMap.SuspendLayout();
            this.tabPageExpandingPanel.SuspendLayout();
            this.expandingPanelContainer1.SuspendLayout();
            this.tabPagePathTextBox.SuspendLayout();
            this.tabPageShellTreeList.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageColorMap);
            this.tabControl.Controls.Add(this.tabPageExpandingPanel);
            this.tabControl.Controls.Add(this.tabPagePathTextBox);
            this.tabControl.Controls.Add(this.tabPageShellTreeList);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(696, 415);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageColorMap
            // 
            this.tabPageColorMap.Controls.Add(this.colorMap);
            this.tabPageColorMap.Controls.Add(this.label1);
            this.tabPageColorMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageColorMap.Name = "tabPageColorMap";
            this.tabPageColorMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColorMap.Size = new System.Drawing.Size(688, 389);
            this.tabPageColorMap.TabIndex = 0;
            this.tabPageColorMap.Text = "Color Map";
            this.tabPageColorMap.UseVisualStyleBackColor = true;
            // 
            // colorMap
            // 
            this.colorMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorMap.BackColor = System.Drawing.Color.Red;
            this.colorMap.CurrentColor = System.Drawing.Color.Red;
            this.colorMap.Location = new System.Drawing.Point(18, 35);
            this.colorMap.Name = "colorMap";
            this.colorMap.ShowColorBorder = true;
            this.colorMap.Size = new System.Drawing.Size(664, 94);
            this.colorMap.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color Map";
            // 
            // tabPageExpandingPanel
            // 
            this.tabPageExpandingPanel.Controls.Add(this.expandingPanelContainer1);
            this.tabPageExpandingPanel.Location = new System.Drawing.Point(4, 22);
            this.tabPageExpandingPanel.Name = "tabPageExpandingPanel";
            this.tabPageExpandingPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageExpandingPanel.Size = new System.Drawing.Size(688, 389);
            this.tabPageExpandingPanel.TabIndex = 1;
            this.tabPageExpandingPanel.Text = "Expanding Panel";
            this.tabPageExpandingPanel.UseVisualStyleBackColor = true;
            // 
            // expandingPanelContainer1
            // 
            this.expandingPanelContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.expandingPanelContainer1.AutoScroll = true;
            this.expandingPanelContainer1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.expandingPanelContainer1.Controls.Add(this.expandingPanel2);
            this.expandingPanelContainer1.Controls.Add(this.expandingPanel1);
            this.expandingPanelContainer1.Location = new System.Drawing.Point(6, 6);
            this.expandingPanelContainer1.Name = "expandingPanelContainer1";
            this.expandingPanelContainer1.Size = new System.Drawing.Size(240, 200);
            this.expandingPanelContainer1.TabIndex = 1;
            // 
            // expandingPanel2
            // 
            this.expandingPanel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expandingPanel2.Location = new System.Drawing.Point(4, 4);
            this.expandingPanel2.Name = "expandingPanel2";
            this.expandingPanel2.PanelContainer = this.expandingPanelContainer1;
            this.expandingPanel2.PanelName = "Panel 2";
            this.expandingPanel2.Size = new System.Drawing.Size(215, 100);
            this.expandingPanel2.SizeWidthToContainer = true;
            this.expandingPanel2.TabIndex = 2;
            // 
            // expandingPanel1
            // 
            this.expandingPanel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.expandingPanel1.Location = new System.Drawing.Point(4, 108);
            this.expandingPanel1.Name = "expandingPanel1";
            this.expandingPanel1.PanelContainer = this.expandingPanelContainer1;
            this.expandingPanel1.PanelName = "Panel 1";
            this.expandingPanel1.Size = new System.Drawing.Size(215, 100);
            this.expandingPanel1.SizeWidthToContainer = true;
            this.expandingPanel1.TabIndex = 1;
            // 
            // tabPagePathTextBox
            // 
            this.tabPagePathTextBox.Controls.Add(this.textBox1);
            this.tabPagePathTextBox.Location = new System.Drawing.Point(4, 22);
            this.tabPagePathTextBox.Name = "tabPagePathTextBox";
            this.tabPagePathTextBox.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePathTextBox.Size = new System.Drawing.Size(688, 389);
            this.tabPagePathTextBox.TabIndex = 2;
            this.tabPagePathTextBox.Text = "Path Text Box";
            this.tabPagePathTextBox.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.OpenFileDialogFilter = null;
            this.textBox1.OpenFileDialogTitle = null;
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 1;
            // 
            // tabPageShellTreeList
            // 
            this.tabPageShellTreeList.Controls.Add(this.toolStripContainer1);
            this.tabPageShellTreeList.Location = new System.Drawing.Point(4, 22);
            this.tabPageShellTreeList.Name = "tabPageShellTreeList";
            this.tabPageShellTreeList.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageShellTreeList.Size = new System.Drawing.Size(688, 389);
            this.tabPageShellTreeList.TabIndex = 3;
            this.tabPageShellTreeList.Text = "Shell Tree/List";
            this.tabPageShellTreeList.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(682, 383);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(3, 3);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(682, 383);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.shellTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.shellListView1);
            this.splitContainer1.Size = new System.Drawing.Size(682, 383);
            this.splitContainer1.SplitterDistance = 227;
            this.splitContainer1.TabIndex = 2;
            // 
            // shellTreeView1
            // 
            this.shellTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellTreeView1.Location = new System.Drawing.Point(0, 0);
            this.shellTreeView1.Name = "shellTreeView1";
            this.shellTreeView1.ShowFiles = true;
            this.shellTreeView1.ShowHiddenFilesAndFolders = false;
            this.shellTreeView1.Size = new System.Drawing.Size(227, 383);
            this.shellTreeView1.TabIndex = 0;
            // 
            // shellListView1
            // 
            this.shellListView1.AssociationTreeView = this.shellTreeView1;
            this.shellListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellListView1.Location = new System.Drawing.Point(0, 0);
            this.shellListView1.Name = "shellListView1";
            this.shellListView1.ShowFolders = true;
            this.shellListView1.ShowHiddenFilesAndFolders = false;
            this.shellListView1.Size = new System.Drawing.Size(451, 383);
            this.shellListView1.TabIndex = 1;
            this.shellListView1.UseCompatibleStateImageBehavior = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonTreeShowFiles,
            this.toolStripButtonTreeShowHidden,
            this.toolStripSeparator2,
            this.toolStripButtonListShowFolders,
            this.toolStripButtonListShowHidden});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(455, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Visible = false;
            // 
            // toolStripButtonTreeShowFiles
            // 
            this.toolStripButtonTreeShowFiles.CheckOnClick = true;
            this.toolStripButtonTreeShowFiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTreeShowFiles.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTreeShowFiles.Image")));
            this.toolStripButtonTreeShowFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTreeShowFiles.Name = "toolStripButtonTreeShowFiles";
            this.toolStripButtonTreeShowFiles.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonTreeShowFiles.Text = "Show Files (Tree)";
            // 
            // toolStripButtonTreeShowHidden
            // 
            this.toolStripButtonTreeShowHidden.CheckOnClick = true;
            this.toolStripButtonTreeShowHidden.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTreeShowHidden.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTreeShowHidden.Image")));
            this.toolStripButtonTreeShowHidden.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTreeShowHidden.Name = "toolStripButtonTreeShowHidden";
            this.toolStripButtonTreeShowHidden.Size = new System.Drawing.Size(116, 22);
            this.toolStripButtonTreeShowHidden.Text = "Show Hidden (Tree)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonListShowFolders
            // 
            this.toolStripButtonListShowFolders.CheckOnClick = true;
            this.toolStripButtonListShowFolders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonListShowFolders.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonListShowFolders.Image")));
            this.toolStripButtonListShowFolders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonListShowFolders.Name = "toolStripButtonListShowFolders";
            this.toolStripButtonListShowFolders.Size = new System.Drawing.Size(110, 22);
            this.toolStripButtonListShowFolders.Text = "Show Folders (List)";
            // 
            // toolStripButtonListShowHidden
            // 
            this.toolStripButtonListShowHidden.CheckOnClick = true;
            this.toolStripButtonListShowHidden.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonListShowHidden.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonListShowHidden.Image")));
            this.toolStripButtonListShowHidden.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonListShowHidden.Name = "toolStripButtonListShowHidden";
            this.toolStripButtonListShowHidden.Size = new System.Drawing.Size(111, 22);
            this.toolStripButtonListShowHidden.Text = "Show Hidden (List)";
            // 
            // FormControlsSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 439);
            this.Controls.Add(this.tabControl);
            this.Name = "FormControlsSample";
            this.Text = "Controls Sample";
            this.Load += new System.EventHandler(this.FormControlsSample_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageColorMap.ResumeLayout(false);
            this.tabPageColorMap.PerformLayout();
            this.tabPageExpandingPanel.ResumeLayout(false);
            this.expandingPanelContainer1.ResumeLayout(false);
            this.tabPagePathTextBox.ResumeLayout(false);
            this.tabPagePathTextBox.PerformLayout();
            this.tabPageShellTreeList.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageColorMap;
        private Apex.Controls.ColorMap colorMap;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPageExpandingPanel;
        private Apex.Controls.ExpandingPanelContainer expandingPanelContainer1;
        private Apex.Controls.ExpandingPanel expandingPanel2;
        private Apex.Controls.ExpandingPanel expandingPanel1;
        private System.Windows.Forms.TabPage tabPagePathTextBox;
        private PathTextBox textBox1;
        private System.Windows.Forms.TabPage tabPageShellTreeList;
        private ShellTreeView shellTreeView1;
        private ShellListView shellListView1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonTreeShowFiles;
        private System.Windows.Forms.ToolStripButton toolStripButtonListShowFolders;
        private System.Windows.Forms.ToolStripButton toolStripButtonTreeShowHidden;
        private System.Windows.Forms.ToolStripButton toolStripButtonListShowHidden;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

