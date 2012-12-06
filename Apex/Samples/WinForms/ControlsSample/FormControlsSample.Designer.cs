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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageColorMap = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageExpandingPanel = new System.Windows.Forms.TabPage();
            this.tabPagePathTextBox = new System.Windows.Forms.TabPage();
            this.colorMap = new Apex.Controls.ColorMap();
            this.expandingPanelContainer1 = new Apex.Controls.ExpandingPanelContainer();
            this.expandingPanel2 = new Apex.Controls.ExpandingPanel();
            this.expandingPanel1 = new Apex.Controls.ExpandingPanel();
            this.textBox1 = new PathTextBox();
            this.tabControl.SuspendLayout();
            this.tabPageColorMap.SuspendLayout();
            this.tabPageExpandingPanel.SuspendLayout();
            this.tabPagePathTextBox.SuspendLayout();
            this.expandingPanelContainer1.SuspendLayout();
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
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(260, 238);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageColorMap
            // 
            this.tabPageColorMap.Controls.Add(this.colorMap);
            this.tabPageColorMap.Controls.Add(this.label1);
            this.tabPageColorMap.Location = new System.Drawing.Point(4, 22);
            this.tabPageColorMap.Name = "tabPageColorMap";
            this.tabPageColorMap.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageColorMap.Size = new System.Drawing.Size(252, 212);
            this.tabPageColorMap.TabIndex = 0;
            this.tabPageColorMap.Text = "Color Map";
            this.tabPageColorMap.UseVisualStyleBackColor = true;
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
            this.tabPageExpandingPanel.Size = new System.Drawing.Size(252, 212);
            this.tabPageExpandingPanel.TabIndex = 1;
            this.tabPageExpandingPanel.Text = "Expanding Panel";
            this.tabPageExpandingPanel.UseVisualStyleBackColor = true;
            // 
            // tabPagePathTextBox
            // 
            this.tabPagePathTextBox.Controls.Add(this.textBox1);
            this.tabPagePathTextBox.Location = new System.Drawing.Point(4, 22);
            this.tabPagePathTextBox.Name = "tabPagePathTextBox";
            this.tabPagePathTextBox.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePathTextBox.Size = new System.Drawing.Size(252, 212);
            this.tabPagePathTextBox.TabIndex = 2;
            this.tabPagePathTextBox.Text = "Path Text Box";
            this.tabPagePathTextBox.UseVisualStyleBackColor = true;
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
            this.colorMap.Size = new System.Drawing.Size(228, 94);
            this.colorMap.TabIndex = 1;
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
            this.expandingPanel2.Size = new System.Drawing.Size(192, 100);
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
            this.expandingPanel1.Size = new System.Drawing.Size(192, 100);
            this.expandingPanel1.SizeWidthToContainer = true;
            this.expandingPanel1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(40, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // FormControlsSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tabControl);
            this.Name = "FormControlsSample";
            this.Text = "Controls Sample";
            this.tabControl.ResumeLayout(false);
            this.tabPageColorMap.ResumeLayout(false);
            this.tabPageColorMap.PerformLayout();
            this.tabPageExpandingPanel.ResumeLayout(false);
            this.tabPagePathTextBox.ResumeLayout(false);
            this.tabPagePathTextBox.PerformLayout();
            this.expandingPanelContainer1.ResumeLayout(false);
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
    }
}

