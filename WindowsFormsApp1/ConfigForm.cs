using RunBatForm.Constans;
using RunBatForm.Helpers;
using RunBatForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace RunBatForm
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            SetToolTip();
            RenderData();
        }

        private void SetToolTip()
        {
            toolTip1.SetToolTip(label1, "Path of the main folder");
            toolTip2.SetToolTip(label2, "Path of the publish folder related to the main folder");
            toolTip3.SetToolTip(label3, "Path of the backup data folder related to the main folder");
            toolTip4.SetToolTip(label4, "Path of the project folder");
            toolTip5.SetToolTip(label5, "Path of the .bat file Visual Studio Dev Command-Line");
        }

        private void RenderData()
        {
            string path = Global.Configuration.Path;
            txtFolder.Text = path;
            txtPublicFolder.Text = Path.Combine(path, Global.Configuration.PublishFolder);
            txtDataBackupFolder.Text = Path.Combine(path, Global.Configuration.BackupDataFolder);
            txtProjectFolder.Text = Global.Configuration.ProjectFolder;
            txtVSDevCmdPath.Text = Global.Configuration.VsDevCmdPath;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void ChooseFolder()
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = folderBrowserDialog.SelectedPath;
                txtFolder.Text = newPath;
                txtPublicFolder.Text = Path.Combine(newPath, Global.Configuration.PublishFolder);
                txtDataBackupFolder.Text = Path.Combine(newPath, Global.Configuration.BackupDataFolder);
                btnRevert.Visible = true;
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            Global.Configuration.Path = txtFolder.Text;
            Global.Configuration.ProjectFolder = txtProjectFolder.Text;
            Global.Configuration.VsDevCmdPath = txtVSDevCmdPath.Text;
            var resultSavePathBat = SavePathBat();
            var jsonData = JsonHelper.Serializer(Global.Configuration);
            var result = FileHelper.WriteFile(Path.Combine(Global.RootAppFolderPath, FilePath.Configuration), jsonData);
            if(resultSavePathBat && result)
            {
                btnRevert.Visible = false;
                lbError.Visible = false;
            }
            else
            {
                if(!resultSavePathBat)
                    lbError.Text = "Cannot save bat data!";
                else
                    lbError.Text = "Cannot save config data!";
                lbError.Visible = true;
            }    
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            RenderData();
            btnRevert.Visible = false;
        }

        private void btnProjectBrowser_Click(object sender, EventArgs e)
        {
            ChooseProjectFolder();
        }

        private void ChooseProjectFolder()
        {
            if (projectFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = projectFolderBrowserDialog.SelectedPath;
                txtProjectFolder.Text = newPath;
                btnRevert.Visible = true;
            }
        }

        private void btnDevCmdPathBrowser_Click(object sender, EventArgs e)
        {
            ChooseVSDevCmdFile();
        }

        private void ChooseVSDevCmdFile()
        {
            if (openVSDevCmdFileDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openVSDevCmdFileDialog.FileName;
                txtVSDevCmdPath.Text = newPath;
                btnRevert.Visible = true;
            }
        }

        private bool SavePathBat()
        {
            List<string> strList = new List<string>();
            strList.Add($"@echo off ");
            var splitVsDevCmdPathStr = Global.Configuration.VsDevCmdPath.Split('\\');
            string newVsDevCmdPath = string.Empty;
            foreach(var _string in splitVsDevCmdPathStr)
            {
                string newString = _string;
                if (newString.Contains(" "))
                {
                    newString = $"\"{newString}\"";
                }
                if (string.IsNullOrEmpty(newVsDevCmdPath))
                    newVsDevCmdPath = newString;
                else
                    newVsDevCmdPath = newVsDevCmdPath + "\\" + newString;
            }
            strList.Add($"set rootPathProject={Global.Configuration.ProjectFolder}");
            strList.Add($"set msbuildPath={newVsDevCmdPath}");
            strList.Add($"set rootPathStart={Path.Combine(Global.Configuration.Path, Global.Configuration.PublishFolder)}");
            string stringData = string.Join('\n', strList.ToArray());
            string strPath = Path.Combine(Global.RootAppFolderPath, BatPath.PathBat);
            return FileHelper.WriteFile(strPath, stringData);
        }
    }
}
