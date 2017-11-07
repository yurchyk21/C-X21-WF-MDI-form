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
    public partial class ChildForm : Form
    {
        public ChildForm()
        {
            InitializeComponent();
            this.AllowDrop = true;
            pictureBox1.AllowDrop = true;
        }


        private void pictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] mass;
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                mass = e.Data.GetData(DataFormats.FileDrop) as string[];
                pictureBox1.ImageLocation = mass[0];
                this.Text = Path.GetFileName(mass[0]);
            }
        }

        private void ChildForm_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void pictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
    }
}
