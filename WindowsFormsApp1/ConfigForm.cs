﻿using RunBatForm.Constans;
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
        private string cfConfigPath;
        private string mainConfigPath;
        private ServerConfigurationModel CF;
        private ServerConfigurationModel Main;
        public ConfigForm()
        {
            InitializeComponent();
            SetToolTip();
            RenderData();
            cfConfigPath = Path.Combine(Global.RootAppFolderPath, FilePath.ConfigCFPath);
            mainConfigPath = Path.Combine(Global.RootAppFolderPath, FilePath.ConfigMainPath);
            var mainJsonData = FileHelper.ReadFile(mainConfigPath);
            var cfJsonData = FileHelper.ReadFile(cfConfigPath);
            if (mainJsonData.NotNullOrEmpty())
            {
                Main = JsonHelper.Deserialize<ServerConfigurationModel>(mainJsonData);
            }

            if (cfJsonData.NotNullOrEmpty())
            {
                CF = JsonHelper.Deserialize<ServerConfigurationModel>(cfJsonData);
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
                Main.Path = txtDataBackupFolder.Text;
                Main.SQLServerSolution = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.Solution);
                Main.CatalogDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.CatalogDACPAC);
                Main.CoreDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.CoreDACPAC);
                Main.WorkingPaperDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.WorkingPaperDACPAC);
                Main.MsBuild = Global.Configuration.MSBuildPath;
                CF.Path = txtDataBackupFolder.Text;
                CF.SQLServerSolution = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.Solution);
                CF.CatalogDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.CatalogDACPAC);
                CF.CoreDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.CoreDACPAC);
                CF.WorkingPaperDACPAC = Path.Combine(txtDatabaseProjectFolder.Text, DatabaseSolution.WorkingPaperDACPAC);
                CF.MsBuild = Global.Configuration.MSBuildPath;

                string mainConfigShortData = ConvertModelToBatContentString.ConfigShortServer(Main, path);
                string cfConfigShortData = ConvertModelToBatContentString.ConfigShortServer(CF, path);
                if (mainConfigShortData.NotNullOrEmpty() && cfConfigShortData.NotNullOrEmpty())
                {
                    string mainConfigShortPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerShortMain);
                    string cfConfigShortPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerShortCF);
                    FileHelper.WriteFile(mainConfigShortPath, mainConfigShortData);
                    FileHelper.WriteFile(cfConfigShortPath, cfConfigShortData);
                }

                string mainConfigData = ConvertModelToBatContentString.ConfigServer(Main);
                string cfConfigData = ConvertModelToBatContentString.ConfigServer(CF);
                if (mainConfigData.NotNullOrEmpty() && cfConfigData.NotNullOrEmpty())
                {
                    string mainConfigPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerMain);
                    string cfConfigPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerCF);
                    FileHelper.WriteFile(mainConfigPath, mainConfigData);
                    FileHelper.WriteFile(cfConfigPath, cfConfigData);
                }

                var jsonMainData = JsonHelper.Serializer(Main);
                var jsonCFData = JsonHelper.Serializer(CF);
                if (jsonMainData.NotNullOrEmpty() && jsonCFData.NotNullOrEmpty())
                {
                    FileHelper.WriteFile(mainConfigPath, jsonMainData);
                    FileHelper.WriteFile(cfConfigPath, jsonCFData);
                }

                var pathData = ConvertModelToBatContentString.PathFile(Global.Configuration);
                if (pathData.NotNullOrEmpty())
                {
                    string pathPath = Path.Combine(Global.RootAppFolderPath, BatPath.PathBat);
                    FileHelper.WriteFile(pathPath, pathData);
                }
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
