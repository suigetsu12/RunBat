using RunBatForm.Constans;
using RunBatForm.Converts;
using RunBatForm.Extensions;
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
        private string configDatabasePath;
        private ServerConfigurationModel ConfigDatabase;
        public ConfigForm()
        {
            InitializeComponent();
            SetToolTip();
            RenderData();
            configDatabasePath = Path.Combine(Global.RootAppFolderPath, FilePath.ConfigDatabasePath);
            var jsonData = FileHelper.ReadFile(configDatabasePath);
            if (jsonData.NotNullOrEmpty())
            {
                ConfigDatabase = JsonHelper.Deserialize<ServerConfigurationModel>(jsonData);
            }
        }

        private void SetToolTip()
        {
            toolTip1.SetToolTip(label1, "Path of the main folder");
            toolTip2.SetToolTip(label2, "Path of the publish folder related to the main folder");
            toolTip3.SetToolTip(label3, "Path of the backup data folder related to the main folder");
            toolTip4.SetToolTip(label4, "Path of the project folder");
            toolTip5.SetToolTip(label5, "Path of the .bat file Visual Studio Dev Command-Line");
            toolTip6.SetToolTip(label6, "Path of the database project folder");
            toolTip7.SetToolTip(label7, "Path of the .exe file MSBuild");
            toolTip8.SetToolTip(label8, "Path of the .exe file Azure Function tool");
        }

        private void RenderData()
        {
            string path = Global.Configuration.Path;
            txtFolder.Text = path;
            txtPublicFolder.Text = Path.Combine(path, Global.Configuration.PublishFolder);
            txtDataBackupFolder.Text = Path.Combine(path, Global.Configuration.BackupDataFolder);
            txtProjectFolder.Text = Global.Configuration.ProjectFolder;
            txtDatabaseProjectFolder.Text = Global.Configuration.DatabaseProjectFolder;
            txtVSDevCmdPath.Text = Global.Configuration.VsDevCmdPath;
            txtMSBuildPath.Text = Global.Configuration.MSBuildPath;
            txtAzureFuncToolPath.Text = Global.Configuration.AzureFuncToolPath;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            ChooseFolder();
        }

        private void ChooseFolder()
        {
            folderBrowserDialog.SelectedPath = txtFolder.Text ?? Global.Configuration.Path;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = folderBrowserDialog.SelectedPath;
                txtFolder.Text = newPath;
                txtPublicFolder.Text = Path.Combine(newPath, Global.Configuration.PublishFolder);
                txtDataBackupFolder.Text = Path.Combine(newPath, Global.Configuration.BackupDataFolder);
                btnRevert.Visible = true;
            }
        }

        private string Validation()
        {
            if (!txtFolder.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "main folder path");
            if (!txtPublicFolder.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "publish folder path");
            if (!txtDataBackupFolder.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "database folder path");
            if (!txtProjectFolder.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "project application folder path");
            if (!txtDatabaseProjectFolder.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "project database folder path");
            if (!txtVSDevCmdPath.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "VSDev Cmd path");
            if (!txtMSBuildPath.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "MSBuild path");
            if (!txtAzureFuncToolPath.Text.NotNullOrEmpty())
                return String.Format(MessageConstans.TheFieldEmpty, "Azure Function tool path");
            return string.Empty;
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            var message = Validation();
            if (message.NotNullOrEmpty())
            {
                MessageBox.Show(message);
                return;
            }

            Global.Configuration.Path = txtFolder.Text;
            Global.Configuration.ProjectFolder = txtProjectFolder.Text;
            Global.Configuration.DatabaseProjectFolder = txtDatabaseProjectFolder.Text;
            Global.Configuration.VsDevCmdPath = txtVSDevCmdPath.Text;
            Global.Configuration.MSBuildPath = txtMSBuildPath.Text;
            Global.Configuration.AzureFuncToolPath = txtAzureFuncToolPath.Text;
            var resultSavePathBat = SavePathBat();
            var jsonData = JsonHelper.Serializer(Global.Configuration);
            var result = FileHelper.WriteFile(Path.Combine(Global.RootAppFolderPath, FilePath.Configuration), jsonData);
            if (resultSavePathBat && result)
            {
                btnRevert.Visible = false;
                lbError.Visible = false;

                string path = Path.Combine(Global.Configuration.Path, Global.Configuration.BackupDataFolder);
                ConfigDatabase.Path = txtDataBackupFolder.Text;
                ConfigDatabase.SQLServerSolution = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.Solution);
                ConfigDatabase.CatalogDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.CatalogDACPAC);
                ConfigDatabase.CoreDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.CoreDACPAC);
                ConfigDatabase.WorkingPaperDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.WorkingPaperDACPAC);
                ConfigDatabase.MsBuild = Global.Configuration.MSBuildPath;

                var jsonConfigDatabase = JsonHelper.Serializer(ConfigDatabase);
                if (jsonConfigDatabase.NotNullOrEmpty())
                    FileHelper.WriteFile(configDatabasePath, jsonConfigDatabase);

                CreateFolder();
                MessageBox.Show(MessageConstans.Success);
            }
            else
            {
                if (!resultSavePathBat)
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
            projectFolderBrowserDialog.SelectedPath = txtProjectFolder.Text ?? Global.Configuration.ProjectFolder;
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
            strList.Add($":: --------------------------- The PATH of project  ----------------------------------------");
            strList.Add($"set rootPathProject={Global.Configuration.ProjectFolder}\\");
            strList.Add($":: --------------------------- The PATH of Visual Studio  ----------------------------------------");
            strList.Add($"set msbuildPath={StringHelper.RefactorPathContainSpace(Global.Configuration.VsDevCmdPath)}");
            strList.Add($":: --------------------------- The PATH you want to build to   ----------------------------------------");
            strList.Add($"set rootPathStart={Path.Combine(Global.Configuration.Path, Global.Configuration.PublishFolder)}\\");
            strList.Add($":: --------------------------- The PATH Azure function tool   ----------------------------------------");
            strList.Add($"set azureFunctionToolPath={StringHelper.RefactorPathContainSpace(Global.Configuration.AzureFuncToolPath)}");
            string stringData = string.Join('\n', strList.ToArray());
            string strPath = Path.Combine(Global.RootAppFolderPath, BatPath.PathBat);
            return FileHelper.WriteFile(strPath, stringData);
        }

        private void btnDatabaseProjectBrowser_Click(object sender, EventArgs e)
        {
            ChooseDatabaseProjectFolder();
        }

        private void ChooseDatabaseProjectFolder()
        {
            databaseProjectFolderBrowserDialog.SelectedPath = txtDatabaseProjectFolder.Text ?? Global.Configuration.DatabaseProjectFolder;
            if (databaseProjectFolderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = databaseProjectFolderBrowserDialog.SelectedPath;
                txtDatabaseProjectFolder.Text = newPath;
                btnRevert.Visible = true;
            }
        }

        private void btnMSBuildPathBrowser_Click(object sender, EventArgs e)
        {
            ChooseMSBuildFile();
        }

        private void ChooseMSBuildFile()
        {
            if (openMSBuildFileDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openMSBuildFileDialog.FileName;
                txtMSBuildPath.Text = newPath;
                btnRevert.Visible = true;
            }
        }

        private void btnAzureFuncToolPathBrowser_Click(object sender, EventArgs e)
        {
            ChooseAzureFuncToolFile();
        }

        private void ChooseAzureFuncToolFile()
        {
            if (openAzureFunctionToolFileDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openAzureFunctionToolFileDialog.FileName;
                txtAzureFuncToolPath.Text = newPath;
                btnRevert.Visible = true;
            }
        }

        private void CreateFolder()
        {
            FolderHelper.CreateFolder(Path.Combine(Global.Configuration.Path, Global.Configuration.PublishFolder));
            FolderHelper.CreateFolder(Path.Combine(Global.Configuration.Path, Global.Configuration.BackupDataFolder));
        }
    }
}
