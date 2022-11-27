//TIA Project Tool
//V14

using Microsoft.Win32;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Xml.Linq;

//Siemens includes
using Siemens.Engineering.Multiuser;
using Siemens.Engineering;
using Siemens.Engineering.Cax;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.Compare;
using Siemens.Engineering.Download;
using Siemens.Engineering.Hmi;
using Siemens.Engineering.Hmi.Cycle;
using Siemens.Engineering.Hmi.Communication;
using Siemens.Engineering.Hmi.Globalization;
using Siemens.Engineering.Hmi.RuntimeScripting;
using Siemens.Engineering.Hmi.Screen;
using Siemens.Engineering.Hmi.Tag;
using Siemens.Engineering.Hmi.TextGraphicList;
using Siemens.Engineering.HW;
using Siemens.Engineering.HW.Extensions;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.HW.Utilities;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using Siemens.Engineering.SW.ExternalSources;
using Siemens.Engineering.SW.Tags;
using Siemens.Engineering.SW.TechnologicalObjects;
using Siemens.Engineering.SW.TechnologicalObjects.Motion;
using Siemens.Engineering.SW.Types;
using Siemens.Engineering.Upload;

namespace TIA_Project_Tool
{
    public partial class Form1 : Form
    {
        //
        private static TiaPortalProcess _tiaProcess;
        public IDataObject ido;

        public TiaPortal MyTiaPortal
        {
            get; set;
        }
        public Project MyProject
        {
            get; set;
        }

        public LocalSession MyLocalSession
        {
            get; set;
        }

        //-------------------------------------------------------------------------
        public Form1()
        {
            InitializeComponent();
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
        }

        private static Assembly MyResolver(object sender, ResolveEventArgs args)
        {
            int index = args.Name.IndexOf(',');
            if (index == -1)
            {
                return null;
            }
            string name = args.Name.Substring(0, index);

            RegistryKey filePathReg = Registry.LocalMachine.OpenSubKey(
            //    "SOFTWARE\\Siemens\\Automation\\Openness\\14.0\\PublicAPI\\14.0.1.0");
                "SOFTWARE\\Siemens\\Automation\\Openness\\17.0\\PublicAPI\\17.0.0.0");
            object oRegKeyValue = filePathReg?.GetValue(name);
            if (oRegKeyValue != null)
            {
                string filePath = oRegKeyValue.ToString();

                string path = filePath;
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return Assembly.LoadFrom(fullPath);
                }
            }

            return null;
        }

        private void StartTIA()
        {
            try
            {
                if (chkHideInterface.Checked == true)
                {
                    MyTiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);
                    ssLabel.Text = "TIA Portal started without user interface";
                    _tiaProcess = TiaPortal.GetProcesses()[0];
                }
                else
                {
                    MyTiaPortal = new TiaPortal(TiaPortalMode.WithUserInterface);
                    ssLabel.Text = "TIA Portal started with user interface";
                }

                btnOpenProj.Enabled = true;
                btnCloseTIAPortal.Enabled = true;
                btnStartTIAPortal.Enabled = false;
            }
            catch (Exception ex)
            {
                ssLabel.Text = "Error starting TIA Portal: " + ex.Message;
            }
        }

        private void OpenProj()
        {
            OpenFileDialog fileSearch = new OpenFileDialog();

            fileSearch.Filter = "Standalone Projects (*.ap*)|*.ap*|Multiuser Local Sessions (*.als*)|*.als*";
            fileSearch.RestoreDirectory = true;
            fileSearch.ShowDialog();

            string ProjectPath = fileSearch.FileName.ToString();

            if (string.IsNullOrEmpty(ProjectPath) == false)
            {
                OpenProject(ProjectPath);
            }
        }

        private void OpenProject(string ProjectPath)
        {
            string strExtension = Path.GetExtension(ProjectPath);

            
            try
            {
                if (strExtension == ".als17")
                {
                    MyLocalSession = MyTiaPortal.LocalSessions.Open(new FileInfo(ProjectPath));
                }
                else
                {
                    MyProject = MyTiaPortal.Projects.Open(new FileInfo(ProjectPath));
                }
                ssLabel.Text = "Project " + ProjectPath + " opened";
            }
            catch (Exception ex)
            {
                ssLabel.Text = "Error while opening project: " + ex.Message;
            }

            //btn_CompileHW.Enabled = true;
            //btn_CloseProject.Enabled = true;
            //btn_SearchProject.Enabled = false;
            //btn_Save.Enabled = true;
            //btn_AddHW.Enabled = true;
        }

        private void SaveProject()
        {
            MyProject.Save();
            ssLabel.Text = "Project saved";
        }

        private void CloseProject()
        {
            MyProject.Close();
            ssLabel.Text = "Project closed";

            btnOpenProj.Enabled = true;
            btnCloseProject.Enabled = false;
            btnSaveProject.Enabled = false;
            //btn_CompileHW.Enabled = false;
        }

        private void ConnectTIA()
        {
            btnConnectProject.Enabled = false;
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            IList<String> ilDevices = new List<String> { };
            switch (processes.Count)
            {
                case 1:
                    _tiaProcess = processes[0];
                    MyTiaPortal = _tiaProcess.Attach();
                    if (MyTiaPortal.GetCurrentProcess().Mode == TiaPortalMode.WithUserInterface)
                    {
                        chkHideInterface.Checked = false;
                    }
                    else
                    {
                        chkHideInterface.Checked = true;
                    }

                    //Project is open
                    if (MyTiaPortal.Projects.Count > 0)
                    {
                        MyProject = MyTiaPortal.Projects[0];
                        ilDevices = getDevicesFromProject();
                    }

                    //Local session is open
                    if (MyTiaPortal.LocalSessions.Count > 0)
                    {
                        MyLocalSession = MyTiaPortal.LocalSessions[0];
                        ilDevices = getDevicesFromLocalSession();
                    }

                    //Nothing opened
                    if ((MyTiaPortal.Projects.Count <= 0) && (MyTiaPortal.LocalSessions.Count <= 0))
                    {
                        ssLabel.Text = "No TIA Portal Project or Local Session was open!";
                        btnConnectProject.Enabled = true;
                        return;
                    }

                    
                    cmboDevices.Items.AddRange(ilDevices.ToArray<String>());

                    break;
                case 0:
                    ssLabel.Text = "No running instance of TIA Portal was found!";
                    btnConnectProject.Enabled = true;
                    return;
                default:
                    ssLabel.Text = "More than one running instance of TIA Portal was found!";
                    btnConnectProject.Enabled = true;
                    return;
            }

            ssLabel.Text = _tiaProcess.ProjectPath.ToString();
            btnStartTIAPortal.Enabled = false;
            btnConnectProject.Enabled = true;
            btnConnectProject.Text = "Disconnect";
            btnCloseTIAPortal.Enabled = true;
            //btn_CompileHW.Enabled = true;
            btnCloseProject.Enabled = true;
            btnOpenProj.Enabled = false;
            btnSaveProject.Enabled = true;
            //btn_AddHW.Enabled = true;
        }

        private IList<String> getDevicesFromProject()
        {
            IList < String > ilDevices = new List<String> ();
            //string[] strDevices = new string[] { };
            //if MyProject. error checking?
            foreach (Device device in MyProject.Devices)
            {
                string testc = device.Name;
                DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                foreach (DeviceItem deviceItem in deviceItemAggregation)
                {
                    ilDevices.Add(deviceItem.Name);
                
                }
            }
            return ilDevices;
        }

        private IList<String> getDevicesFromLocalSession()
        {
            IList<String> ilDevices = new List<String>();
            //string[] strDevices = new string[] { };
            //if MyProject. error checking?
            foreach (Device device in MyLocalSession.Project.Devices)
            {
                string testc = device.Name;
                ilDevices.Add(device.Name);
                //DeviceItemComposition deviceItemAggregation = device.DeviceItems;
                //foreach (DeviceItem deviceItem in deviceItemAggregation)
                //{
                //    ilDevices.Add(deviceItem.Name);

                //}
            }
            return ilDevices;
        }

        private IList<String> getBlocksFromDevice(string deviceName)
        {
            IList<String> ilBlocks = new List<String>();
            
            return ilBlocks;
        }

        private PlcSoftware GetPlcSoftware(Device device)
        {
            DeviceItemComposition deviceItemComposition = device.DeviceItems;
            foreach (DeviceItem deviceItem in deviceItemComposition)
            {
                SoftwareContainer softwareContainer = deviceItem.GetService<SoftwareContainer>();
                if (softwareContainer != null)
                {
                    Software softwareBase = softwareContainer.Software;
                    PlcSoftware plcSoftware = softwareBase as PlcSoftware;
                    return plcSoftware;
                }
            }
            return null;
        }


        //Button events
        private void btnStartTIAPortal_Click(object sender, EventArgs e)
        {
            StartTIA();
        }

        private void btnConnectProject_Click(object sender, EventArgs e)
        {
            ConnectTIA();
        }

        private void btnOpenProj_Click(object sender, EventArgs e)
        {
            OpenProj();
        }

        private void btnCloseProject_Click(object sender, EventArgs e)
        {
            //CloseProject();
        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void cmboDevices_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmboBlockList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tvMasterCopies_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            string cb = Clipboard.GetText();
            if (cb != null)
            {
                lvInstances.Items.Clear();

                //Remove whitespace
                cb = cb.Replace("\n", "");
                string[] lines = cb.Split('\r');

                foreach (string line in lines)
                {
                    lvInstances.Items.Add(line);
                }
                //IEnumerable items = (IEnumerable)ido.GetData("ListViewItems");
                //if (items != null)
                //foreach (ListViewItem item in items)
                //listView1.Items.Add(item);
            }

        }

        private void lvInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Convert ListViewItem to string list
            List<string> strInstances = lvInstances.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();

            foreach (string instance in strInstances)
            {
               
            }
        }

        /// <summary>
        /// This will iterate through all devices in the project or local session
        /// and return the one that matches the selected device
        /// </summary>
        private Device GetDevice()
        {
            Device dvc = null;

            if (MyProject != null)
            {
                foreach (Device plc in MyProject.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    {
                        dvc = plc;
                        break;
                    }
                }
            }

            if (MyLocalSession != null)
            {
                foreach (Device plc in MyLocalSession.Project.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    {
                        dvc = plc;
                        break;
                    }
                }
            }
            return dvc;
        }

        private bool StartCompile()
        {
            Device dvcCpu = GetDevice();
            ICompilable compileServiceSwCpu = dvcCpu.GetService<ICompilable>();
            CompilerResult compileResultSwCpu = compileServiceSwCpu.Compile();
            bool compileCheck = !compileResultSwCpu.State.Equals(CompilerResultState.Error);
            return compileCheck;
        }

        private string getInstanceDBName(string strInstanceName)
            { return "DB" + strInstanceName; }

        //==========XML handling==========
        private void modifyXML(string strPath,string strPlaceholder,string strNewName)
        {
            //Still unsure if all modifications should be done here
            //IO should also be replaced here

            XDocument doc = XDocument.Load(strPath);

            string strInstanceDBName = getInstanceDBName(strNewName);

            var docText = doc.ToString().Replace(strPlaceholder, strInstanceDBName);
            using (var reader = new StringReader(docText))
                doc = XDocument.Load(reader, LoadOptions.None);

            doc.Save(strPath);
        }
        private void btnGenerateInstances_Click(object sender, EventArgs e)
        {
            //Of course this damn thing has no empty constructor, FFS
            PlcSoftware plcs = null;
            Siemens.Engineering.Library.MasterCopies.MasterCopy mc = null;

            //TODO: Find complete structure, in case it is nested
            string strSelectedMasterCopy = tvMasterCopies.SelectedNode.Text;
            string strPlaceholder = Toolbox.getXMLPlaceholder(cmboInstanceType.Text);

            if (MyProject != null)
            {
                foreach (Device plc in MyProject.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    {
                        plcs = GetPlcSoftware(plc);
                        break;
                    }
                }
                mc = MyProject.ProjectLibrary.MasterCopyFolder.MasterCopies.Find(strSelectedMasterCopy);
            }

            if (MyLocalSession != null)
            {
                foreach (Device plc in MyLocalSession.Project.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    { 
                        plcs = GetPlcSoftware(plc);
                        break;
                    }
                }
                mc = MyLocalSession.Project.ProjectLibrary.MasterCopyFolder.MasterCopies.Find(strSelectedMasterCopy);
            }

            //Convert ListViewItem to string list
            List<string> strInstances = lvInstances.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();

            foreach (string instance in strInstances)
            {
                //filter block names out here
                if (instance.Length > 0)
                {
                    Siemens.Engineering.SW.Blocks.PlcBlock newBlock = plcs.BlockGroup.Blocks.CreateFrom(mc);
                    newBlock.Name = instance;
                    string strExportPath = @"C:\TIATool\" + newBlock.Name + ".xml";

                    if (!newBlock.IsConsistent)
                    {
                        bool compileResult = StartCompile();
                    }

                    if (File.Exists(strExportPath))
                    {
                        File.Delete(strExportPath);
                    }


                    //Export XML
                    newBlock.Export(new FileInfo(strExportPath),ExportOptions.None);

                    //Replace instance references
                    modifyXML(strExportPath, strPlaceholder, newBlock.Name);

                    //Import modified XML
                    plcs.BlockGroup.Blocks.Import(new FileInfo(strExportPath), ImportOptions.Override);
                }
            }
        }


        /// <summary>
        /// This function accepts a <c>MasterCopyFolder</c> parameter and
        /// browses it, forming a TreeNode that represents the structure.
        /// </summary>
        /// <param name="mcsf">Master Copies folder</param>
        private TreeNode getMCFolderAsTreeNode(MasterCopyFolder mcsf)
        {
            TreeNode newNode = new TreeNode(mcsf.Name);

            //Get all sub-folders
            foreach (MasterCopyUserFolder mcuf in mcsf.Folders)
            {
                TreeNode folderNode = getMCFolderAsTreeNode(mcuf);
                newNode.Nodes.Add(folderNode);
            }

            //Get all master copies
            foreach (MasterCopy mc in mcsf.MasterCopies)
            {
                TreeNode tn = new TreeNode(mc.Name);
                //Make it clear this is the copy and not a folder
                tn.NodeFont = new Font(tvMasterCopies.Font, FontStyle.Bold);    
                newNode.Nodes.Add(tn);
            }

            return newNode;
        }

        private void btnGenerateInstanceDBs_Click(object sender, EventArgs e)
        {
            PlcSoftware plcs = null;

            if (MyProject != null)
            {
                foreach (Device plc in MyProject.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    {
                        plcs = GetPlcSoftware(plc);
                        break;
                    }
                }
            }

            if (MyLocalSession != null)
            {
                foreach (Device plc in MyLocalSession.Project.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    {
                        plcs = GetPlcSoftware(plc);
                        break;
                    }
                }
            }

            //Convert ListViewItem to string list
            List<string> strInstances = lvInstances.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();

            foreach (string instance in strInstances)
            {
                //filter block names out here
                if (instance.Length > 0)
                {
                    string strInstanceDBName = "DB" + instance;
                    plcs.BlockGroup.Blocks.CreateInstanceDB(strInstanceDBName, true, 1, cmboInstanceType.SelectedItem.ToString());
                }
            }


        }

        private void btnRetrieveMasterCopies_Click_1(object sender, EventArgs e)
        {
            PlcSoftware plcs = null;
            MasterCopySystemFolder mcsf = null;

            if (MyProject != null)
            {
                foreach (Device plc in MyProject.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    {
                        plcs = GetPlcSoftware(plc);
                        break;
                    }
                }
                mcsf = MyProject.ProjectLibrary.MasterCopyFolder;
            }

            if (MyLocalSession != null)
            {
                foreach (Device plc in MyLocalSession.Project.Devices)
                {
                    if (plc.Name == cmboDevices.SelectedItem.ToString())
                    {
                        plcs = GetPlcSoftware(plc);
                        break;
                    }
                }
                mcsf = MyLocalSession.Project.ProjectLibrary.MasterCopyFolder;
            }

            //Process mcsf

            tvMasterCopies.Nodes.Add(getMCFolderAsTreeNode(mcsf));
        }
    }

    public class Toolbox
    {
        public static string getXMLPlaceholder(string strInstanceType)
        {
            string strPlaceholder = "";
            switch (strInstanceType)
            {
                case "$AnalogInput":
                    strPlaceholder = "DB100AI100";
                    break;
                case "$AnalogOutput":
                    strPlaceholder = "DB100AO100";
                    break;
                case "$DigitalInput":
                    strPlaceholder = "DB100DI100";
                    break;
                case "$DigitalOutput":
                    strPlaceholder = "DB100DO100";
                    break;
                case "$Motor":
                    strPlaceholder = "DB100M100";
                    break;
                case "$Valve":
                    strPlaceholder = "DB100V100";
                    break;
                default:
                    strPlaceholder = "DB100M100";
                    break;
            }

            return strPlaceholder;
        }
    }
}
