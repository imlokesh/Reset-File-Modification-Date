using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reset_File_Modification_Date
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files)
            {
                if (File.GetLastWriteTime(file) < File.GetCreationTime(file))
                {
                    File.SetLastWriteTime(file, File.GetCreationTime(file));
                }
            }
            MessageBox.Show("All dates have been reset.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
