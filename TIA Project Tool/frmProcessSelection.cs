using Siemens.Engineering;
using Siemens.Engineering.HW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIA_Project_Tool
{
    public partial class frmProcessSelection : Form
    {
        //private IList<TiaPortalProcess> processes;
        public String strSelectedProcId;
        public int selectedProcId;
        public frmProcessSelection(IList<TiaPortalProcess> processes)
        {
            InitializeComponent();
            lbProcesses.Items.Clear();
            foreach (TiaPortalProcess proc in processes)
            {
                String strEntry = "ID:" + proc.Id.ToString();
                if(proc.ProjectPath != null)
                    { strEntry += " Path:" + proc.ProjectPath.ToString(); };
                lbProcesses.Items.Add(strEntry);
            }
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string[] arrInstance = lbProcesses.SelectedItem.ToString().Remove(0, 3).Split(' ');
            strSelectedProcId = arrInstance[0];
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            strSelectedProcId = "";
            this.Close();  
        }
    }
}
