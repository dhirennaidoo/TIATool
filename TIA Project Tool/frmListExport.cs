using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIA_Project_Tool
{
    public partial class frmListExport: Form
    {
        public frmListExport(IList<string> listItems)
        {
            InitializeComponent();

            lbItems.Items.Clear();

            lbItems.Items.AddRange(listItems.ToArray());
        }

        private void frmListExport_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV file (*.csv) |*.csv";
            sfd.Title = "Choose location to save CSV";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string strPath = Path.GetFullPath(sfd.FileName);
                int intItemCount = 0;

                StreamWriter myOutputStream = new StreamWriter(strPath);
                foreach (string line in lbItems.Items)
                { 
                    myOutputStream.WriteLine(line);
                    intItemCount += 1;
                }

                myOutputStream.Close();

                statusStrip1.Text = "Saved " + intItemCount.ToString() + " to " + strPath;
            }
        }
    }
}
