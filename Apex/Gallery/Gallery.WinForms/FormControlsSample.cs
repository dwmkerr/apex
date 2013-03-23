using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlsSample
{
    public partial class FormControlsSample : Form
    {
        public FormControlsSample()
        {
            InitializeComponent();
        }

        private void FormControlsSample_Load(object sender, EventArgs e)
        {
            UpdateShellTabToolbarStates();
        }

        private void UpdateShellTabToolbarStates()
        {
            toolStripButtonTreeShowFiles.Checked = shellTreeView1.ShowFiles;
            toolStripButtonTreeShowHidden.Checked = shellTreeView1.ShowHiddenFilesAndFolders;
            toolStripButtonListShowFolders.Checked = shellListView1.ShowFolders;
            toolStripButtonListShowHidden.Checked = shellListView1.ShowHiddenFilesAndFolders;
        }
    }
}
