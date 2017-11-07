using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS_X21_WF_MDI
{
    public partial class Form1 : Form
    {
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm child = new ChildForm();
            child.Text = (++counter).ToString();
            child.MdiParent = this;
            child.Show();
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch ((sender as ToolStripMenuItem).Text)
            {
                case "Vertical":
                    LayoutMdi(MdiLayout.TileVertical);
                    break;
                case "Cascade":
                    LayoutMdi(MdiLayout.Cascade);
                    break;
                case "Horizontal":
                    LayoutMdi(MdiLayout.TileHorizontal);
                    break;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] data = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                foreach (string item in data)
                {
                    ChildForm child = new ChildForm();
                    child.MdiParent = this;
                    this.Text = Path.GetFileName(item);
                    (child.GetChildAtPoint(new Point(10, 10)) as PictureBox).ImageLocation = item;
                    child.Show();
                }
            }

        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = folderBrowserDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                DirectoryInfo dir = new DirectoryInfo(folderBrowserDialog1.SelectedPath);
                FileInfo[] info = dir.GetFiles();
                foreach (FileInfo item in info)
                {
                    ChildForm child = new ChildForm();
                    child.MdiParent = this;
                    this.Text = Path.GetFileName(item.FullName);
                    (child.GetChildAtPoint(new Point(10, 10)) as PictureBox).ImageLocation = item.FullName;
                    child.Show();
                }
            }
        }
    }
}
