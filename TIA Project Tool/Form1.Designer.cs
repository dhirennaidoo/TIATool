namespace TIA_Project_Tool
{
    partial class Form1
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
            this.grpPortal = new System.Windows.Forms.GroupBox();
            this.btnCloseTIAPortal = new System.Windows.Forms.Button();
            this.btnStartTIAPortal = new System.Windows.Forms.Button();
            this.chkHideInterface = new System.Windows.Forms.CheckBox();
            this.txt_Status = new System.Windows.Forms.StatusStrip();
            this.ssLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpProject = new System.Windows.Forms.GroupBox();
            this.btnCloseProject = new System.Windows.Forms.Button();
            this.btnSaveProject = new System.Windows.Forms.Button();
            this.btnConnectProject = new System.Windows.Forms.Button();
            this.btnOpenProj = new System.Windows.Forms.Button();
            this.grpDeviceSelection = new System.Windows.Forms.GroupBox();
            this.cmboBlockList = new System.Windows.Forms.ComboBox();
            this.cmboDevices = new System.Windows.Forms.ComboBox();
            this.tvMasterCopies = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvInstances = new System.Windows.Forms.ListView();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnGenerateInstances = new System.Windows.Forms.Button();
            this.grpInstances = new System.Windows.Forms.GroupBox();
            this.btnRetrieveMasterCopies = new System.Windows.Forms.Button();
            this.grpPortal.SuspendLayout();
            this.txt_Status.SuspendLayout();
            this.grpProject.SuspendLayout();
            this.grpDeviceSelection.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpInstances.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPortal
            // 
            this.grpPortal.Controls.Add(this.btnCloseTIAPortal);
            this.grpPortal.Controls.Add(this.btnStartTIAPortal);
            this.grpPortal.Controls.Add(this.chkHideInterface);
            this.grpPortal.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.grpPortal.Location = new System.Drawing.Point(13, 13);
            this.grpPortal.Name = "grpPortal";
            this.grpPortal.Size = new System.Drawing.Size(169, 83);
            this.grpPortal.TabIndex = 0;
            this.grpPortal.TabStop = false;
            this.grpPortal.Text = "TIA Portal";
            // 
            // btnCloseTIAPortal
            // 
            this.btnCloseTIAPortal.Enabled = false;
            this.btnCloseTIAPortal.Location = new System.Drawing.Point(88, 44);
            this.btnCloseTIAPortal.Name = "btnCloseTIAPortal";
            this.btnCloseTIAPortal.Size = new System.Drawing.Size(75, 30);
            this.btnCloseTIAPortal.TabIndex = 2;
            this.btnCloseTIAPortal.Text = "Close";
            this.btnCloseTIAPortal.UseVisualStyleBackColor = true;
            // 
            // btnStartTIAPortal
            // 
            this.btnStartTIAPortal.Location = new System.Drawing.Point(6, 44);
            this.btnStartTIAPortal.Name = "btnStartTIAPortal";
            this.btnStartTIAPortal.Size = new System.Drawing.Size(75, 30);
            this.btnStartTIAPortal.TabIndex = 1;
            this.btnStartTIAPortal.Text = "Start";
            this.btnStartTIAPortal.UseVisualStyleBackColor = true;
            this.btnStartTIAPortal.Click += new System.EventHandler(this.btnStartTIAPortal_Click);
            // 
            // chkHideInterface
            // 
            this.chkHideInterface.AutoSize = true;
            this.chkHideInterface.Location = new System.Drawing.Point(7, 20);
            this.chkHideInterface.Name = "chkHideInterface";
            this.chkHideInterface.Size = new System.Drawing.Size(118, 17);
            this.chkHideInterface.TabIndex = 0;
            this.chkHideInterface.Text = "Hide User Interface";
            this.chkHideInterface.UseVisualStyleBackColor = true;
            // 
            // txt_Status
            // 
            this.txt_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssLabel});
            this.txt_Status.Location = new System.Drawing.Point(0, 529);
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(784, 22);
            this.txt_Status.TabIndex = 1;
            this.txt_Status.Text = "statusStrip1";
            // 
            // ssLabel
            // 
            this.ssLabel.Name = "ssLabel";
            this.ssLabel.Size = new System.Drawing.Size(118, 17);
            this.ssLabel.Text = "toolStripStatusLabel1";
            // 
            // grpProject
            // 
            this.grpProject.Controls.Add(this.btnCloseProject);
            this.grpProject.Controls.Add(this.btnSaveProject);
            this.grpProject.Controls.Add(this.btnConnectProject);
            this.grpProject.Controls.Add(this.btnOpenProj);
            this.grpProject.Location = new System.Drawing.Point(188, 12);
            this.grpProject.Name = "grpProject";
            this.grpProject.Size = new System.Drawing.Size(262, 84);
            this.grpProject.TabIndex = 2;
            this.grpProject.TabStop = false;
            this.grpProject.Text = "Project";
            // 
            // btnCloseProject
            // 
            this.btnCloseProject.BackgroundImage = global::TIA_Project_Tool.Properties.Resources.Close_16x;
            this.btnCloseProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCloseProject.Location = new System.Drawing.Point(192, 19);
            this.btnCloseProject.Name = "btnCloseProject";
            this.btnCloseProject.Size = new System.Drawing.Size(56, 56);
            this.btnCloseProject.TabIndex = 3;
            this.btnCloseProject.Text = "Close";
            this.btnCloseProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCloseProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCloseProject.UseVisualStyleBackColor = true;
            this.btnCloseProject.Click += new System.EventHandler(this.btnCloseProject_Click);
            // 
            // btnSaveProject
            // 
            this.btnSaveProject.BackgroundImage = global::TIA_Project_Tool.Properties.Resources.Save_16x;
            this.btnSaveProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSaveProject.Location = new System.Drawing.Point(130, 19);
            this.btnSaveProject.Name = "btnSaveProject";
            this.btnSaveProject.Size = new System.Drawing.Size(56, 56);
            this.btnSaveProject.TabIndex = 2;
            this.btnSaveProject.Text = "Save";
            this.btnSaveProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaveProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveProject.UseVisualStyleBackColor = true;
            this.btnSaveProject.Click += new System.EventHandler(this.btnSaveProject_Click);
            // 
            // btnConnectProject
            // 
            this.btnConnectProject.BackgroundImage = global::TIA_Project_Tool.Properties.Resources.ConnectToRemoteServer_16x;
            this.btnConnectProject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConnectProject.Location = new System.Drawing.Point(68, 19);
            this.btnConnectProject.Name = "btnConnectProject";
            this.btnConnectProject.Size = new System.Drawing.Size(56, 56);
            this.btnConnectProject.TabIndex = 1;
            this.btnConnectProject.Text = "Connect";
            this.btnConnectProject.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConnectProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnConnectProject.UseVisualStyleBackColor = true;
            this.btnConnectProject.Click += new System.EventHandler(this.btnConnectProject_Click);
            // 
            // btnOpenProj
            // 
            this.btnOpenProj.BackgroundImage = global::TIA_Project_Tool.Properties.Resources.OpenFolder_16x;
            this.btnOpenProj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnOpenProj.Enabled = false;
            this.btnOpenProj.Location = new System.Drawing.Point(6, 19);
            this.btnOpenProj.Name = "btnOpenProj";
            this.btnOpenProj.Size = new System.Drawing.Size(56, 56);
            this.btnOpenProj.TabIndex = 0;
            this.btnOpenProj.Text = "Open";
            this.btnOpenProj.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOpenProj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpenProj.UseVisualStyleBackColor = true;
            this.btnOpenProj.Click += new System.EventHandler(this.btnOpenProj_Click);
            // 
            // grpDeviceSelection
            // 
            this.grpDeviceSelection.Controls.Add(this.cmboBlockList);
            this.grpDeviceSelection.Controls.Add(this.cmboDevices);
            this.grpDeviceSelection.Location = new System.Drawing.Point(13, 102);
            this.grpDeviceSelection.Name = "grpDeviceSelection";
            this.grpDeviceSelection.Size = new System.Drawing.Size(437, 83);
            this.grpDeviceSelection.TabIndex = 3;
            this.grpDeviceSelection.TabStop = false;
            this.grpDeviceSelection.Text = "Device";
            // 
            // cmboBlockList
            // 
            this.cmboBlockList.FormattingEnabled = true;
            this.cmboBlockList.Location = new System.Drawing.Point(6, 47);
            this.cmboBlockList.Name = "cmboBlockList";
            this.cmboBlockList.Size = new System.Drawing.Size(416, 21);
            this.cmboBlockList.TabIndex = 1;
            this.cmboBlockList.SelectedIndexChanged += new System.EventHandler(this.cmboBlockList_SelectedIndexChanged);
            // 
            // cmboDevices
            // 
            this.cmboDevices.FormattingEnabled = true;
            this.cmboDevices.Location = new System.Drawing.Point(6, 20);
            this.cmboDevices.Name = "cmboDevices";
            this.cmboDevices.Size = new System.Drawing.Size(416, 21);
            this.cmboDevices.TabIndex = 0;
            this.cmboDevices.SelectedIndexChanged += new System.EventHandler(this.cmboDevices_SelectedIndexChanged);
            // 
            // tvMasterCopies
            // 
            this.tvMasterCopies.Location = new System.Drawing.Point(6, 49);
            this.tvMasterCopies.Name = "tvMasterCopies";
            this.tvMasterCopies.Size = new System.Drawing.Size(304, 251);
            this.tvMasterCopies.TabIndex = 4;
            this.tvMasterCopies.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMasterCopies_AfterSelect);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRetrieveMasterCopies);
            this.groupBox1.Controls.Add(this.tvMasterCopies);
            this.groupBox1.Location = new System.Drawing.Point(456, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(316, 306);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Master Copies";
            // 
            // lvInstances
            // 
            this.lvInstances.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.lvInstances.HideSelection = false;
            this.lvInstances.Location = new System.Drawing.Point(6, 49);
            this.lvInstances.Name = "lvInstances";
            this.lvInstances.Size = new System.Drawing.Size(425, 251);
            this.lvInstances.TabIndex = 6;
            this.lvInstances.UseCompatibleStateImageBehavior = false;
            this.lvInstances.SelectedIndexChanged += new System.EventHandler(this.lvInstances_SelectedIndexChanged);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(6, 19);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(75, 24);
            this.btnPaste.TabIndex = 7;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnGenerateInstances
            // 
            this.btnGenerateInstances.Location = new System.Drawing.Point(13, 503);
            this.btnGenerateInstances.Name = "btnGenerateInstances";
            this.btnGenerateInstances.Size = new System.Drawing.Size(775, 23);
            this.btnGenerateInstances.TabIndex = 8;
            this.btnGenerateInstances.Text = "Generate Instances";
            this.btnGenerateInstances.UseVisualStyleBackColor = true;
            this.btnGenerateInstances.Click += new System.EventHandler(this.btnGenerateInstances_Click);
            // 
            // grpInstances
            // 
            this.grpInstances.Controls.Add(this.btnPaste);
            this.grpInstances.Controls.Add(this.lvInstances);
            this.grpInstances.Location = new System.Drawing.Point(13, 191);
            this.grpInstances.Name = "grpInstances";
            this.grpInstances.Size = new System.Drawing.Size(437, 306);
            this.grpInstances.TabIndex = 9;
            this.grpInstances.TabStop = false;
            this.grpInstances.Text = "Instances";
            // 
            // btnRetrieveMasterCopies
            // 
            this.btnRetrieveMasterCopies.Location = new System.Drawing.Point(7, 20);
            this.btnRetrieveMasterCopies.Name = "btnRetrieveMasterCopies";
            this.btnRetrieveMasterCopies.Size = new System.Drawing.Size(75, 23);
            this.btnRetrieveMasterCopies.TabIndex = 5;
            this.btnRetrieveMasterCopies.Text = "Refresh";
            this.btnRetrieveMasterCopies.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 551);
            this.Controls.Add(this.grpInstances);
            this.Controls.Add(this.btnGenerateInstances);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDeviceSelection);
            this.Controls.Add(this.grpProject);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.grpPortal);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpPortal.ResumeLayout(false);
            this.grpPortal.PerformLayout();
            this.txt_Status.ResumeLayout(false);
            this.txt_Status.PerformLayout();
            this.grpProject.ResumeLayout(false);
            this.grpDeviceSelection.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.grpInstances.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPortal;
        private System.Windows.Forms.CheckBox chkHideInterface;
        private System.Windows.Forms.StatusStrip txt_Status;
        private System.Windows.Forms.Button btnStartTIAPortal;
        private System.Windows.Forms.GroupBox grpProject;
        private System.Windows.Forms.Button btnCloseTIAPortal;
        private System.Windows.Forms.Button btnOpenProj;
        private System.Windows.Forms.Button btnConnectProject;
        private System.Windows.Forms.Button btnSaveProject;
        private System.Windows.Forms.Button btnCloseProject;
        private System.Windows.Forms.GroupBox grpDeviceSelection;
        private System.Windows.Forms.ComboBox cmboDevices;
        private System.Windows.Forms.ToolStripStatusLabel ssLabel;
        private System.Windows.Forms.ComboBox cmboBlockList;
        private System.Windows.Forms.TreeView tvMasterCopies;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvInstances;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnRetrieveMasterCopies;
        private System.Windows.Forms.Button btnGenerateInstances;
        private System.Windows.Forms.GroupBox grpInstances;
    }
}

