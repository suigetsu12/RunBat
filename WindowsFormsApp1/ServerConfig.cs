﻿using RunBatForm.Constans;
using RunBatForm.Converts;
using RunBatForm.Extensions;
using RunBatForm.Helpers;
using RunBatForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace RunBatForm
{
    public partial class frmServerConfig : Form
    {
        private string cfConfigPath;
        private string mainConfigPath;
        private ServerConfigurationModel CF;
        private ServerConfigurationModel Main;

        public frmServerConfig()
        {
            InitializeComponent();
            cfConfigPath = Path.Combine(Global.RootAppFolderPath, FilePath.ConfigCFPath);
            mainConfigPath = Path.Combine(Global.RootAppFolderPath, FilePath.ConfigMainPath);
            LoadData();
        }

        private void LoadData()
        {
            var mainJsonData = FileHelper.ReadFile(mainConfigPath);
            var cfJsonData = FileHelper.ReadFile(cfConfigPath);
            if (mainJsonData.NotNullOrEmpty())
            {
                Main = JsonHelper.Deserialize<ServerConfigurationModel>(mainJsonData);
                if (Main != null)
                {
                    txtPasswordMain.Text = Main.Password;
                    txtServerMain.Text = Main.Server;
                    txtUserMain.Text = Main.Login;
                    txtPortMain.Text = Main.Port;
                    txtGeoMain.Text = Main.GEO;
                    txtGeoPasswordMain.Text = Main.GEOPassword;
                    txtUserContainerCodeMain.Text = Main.UserContainerCode;
                    txtContainerPasswordMain.Text = Main.ContainerPassword;
                    txtContainerCodeMain.Text = Main.ContainerCode;
                    txtDeployEnvMain.Text = Main.DeployEnv;
                }
            }

            if (cfJsonData.NotNullOrEmpty())
            {
                CF = JsonHelper.Deserialize<ServerConfigurationModel>(cfJsonData);
                if (CF != null)
                {
                    txtPasswordCF.Text = CF.Password;
                    txtServerCF.Text = CF.Server;
                    txtUserCF.Text = CF.Login;
                    txtPortCF.Text = CF.Port;
                    txtGeoCF.Text = CF.GEO;
                    txtGeoPasswordCF.Text = CF.GEOPassword;
                    txtUserContainerCodeCF.Text = CF.UserContainerCode;
                    txtContainerPasswordCF.Text = CF.ContainerPassword;
                    txtContainerCodeCF.Text = CF.ContainerCode;
                    txtDeployEnvCF.Text = CF.DeployEnv;
                }
            }

            var _data = CF ?? Main;
            if (_data != null)
            {
                txtSQLCMDPath.Text = _data?.SQLCMD;
                txtExportTo.Text = _data?.Path;
                ttSQLCMD.SetToolTip(txtSQLCMDPath, _data?.SQLCMD);
                txtSQLServerSolutionPath.Text = _data?.SQLServerSolution;
                txtCatalogDACPACPath.Text = _data?.CatalogDACPAC;
                txtCoreDACPACPath.Text = _data?.CoreDACPAC;
                txtWorkingPaperDACPACPath.Text = _data?.WorkingPaperDACPAC;
                txtSQLPackagePath.Text = _data?.SQLPackage;
            }
        }

        private void btnBrowserSQLCMD_Click(object sender, EventArgs e)
        {
            ChooseSQLCMDFile();
        }

        private void ChooseSQLCMDFile()
        {
            if (openFileSQLCMDDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openFileSQLCMDDialog.FileName;
                txtSQLCMDPath.Text = newPath;
            }
        }

        private string ValidationControl()
        {
            #region [Main]
            if (!txtServerMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "server main");
            if (!txtUserMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "user main");
            if (!txtPasswordMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "password main");
            if (!txtPortMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "port main");
            if (!txtGeoMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "geo main");
            if (!txtGeoPasswordMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "geo password main");
            if (!txtUserContainerCodeMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "user container code main");
            if (!txtContainerPasswordMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "container password main");
            if (!txtContainerCodeMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "container code main");
            if (!txtDeployEnvMain.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "deploy env main");
            #endregion

            #region [CF]
            if (!txtServerCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "server cf");
            if (!txtUserCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "user cf");
            if (!txtPasswordCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "password cf");
            if (!txtPortCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "port cf");
            if (!txtGeoCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "geo cf");
            if (!txtGeoPasswordCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "geo password cf");
            if (!txtUserContainerCodeCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "user container code cf");
            if (!txtContainerPasswordCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "container password cf");
            if (!txtContainerCodeCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "container code cf");
            if (!txtDeployEnvCF.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "deploy env cf");
            #endregion

            #region [General]
            if (!txtSQLCMDPath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "SQLCMD path");
            if (!txtSQLServerSolutionPath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "SQL server solution path");
            if (!txtCatalogDACPACPath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "catalog dacpac path");
            if (!txtCoreDACPACPath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "core dacpac path");
            if (!txtWorkingPaperDACPACPath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "workingpaper dacpac path");
            if (!txtSQLPackagePath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "SQL package path");
            #endregion
            return string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var message = ValidationControl();
            if (message.NotNullOrEmpty())
                MessageBox.Show(message);
            var result = Update();
            if (result)
            {
                MessageBox.Show(MessageConstans.Success);
                UpdateConfigBat();
            }
            else
                MessageBox.Show(MessageConstans.Failed);
        }

        private bool Update()
        {
            #region [Main]
            Main.Server = txtServerMain.Text.Trim();
            Main.Login = txtUserMain.Text.Trim();
            Main.Password = txtPasswordMain.Text.Trim();
            Main.Port = txtPortMain.Text.Trim();
            Main.SQLCMD = txtSQLCMDPath.Text.Trim();
            Main.GEO = txtGeoMain.Text.Trim();
            Main.GEOPassword = txtGeoPasswordMain.Text.Trim();
            Main.UserContainerCode = txtUserContainerCodeMain.Text.Trim();
            Main.ContainerPassword = txtContainerPasswordMain.Text.Trim();
            Main.ContainerCode = txtContainerCodeMain.Text.Trim();
            Main.DeployEnv = txtDeployEnvMain.Text.Trim();
            Main.SQLServerSolution = txtSQLServerSolutionPath.Text.Trim();
            Main.CatalogDACPAC = txtCatalogDACPACPath.Text.Trim();
            Main.CoreDACPAC = txtCoreDACPACPath.Text.Trim();
            Main.WorkingPaperDACPAC = txtWorkingPaperDACPACPath.Text.Trim();
            Main.SQLPackage = txtSQLPackagePath.Text.Trim();

            var jsonMainData = JsonHelper.Serializer(Main);
            #endregion

            #region [CF]
            CF.Server = txtServerCF.Text.Trim();
            CF.Login = txtUserCF.Text.Trim();
            CF.Password = txtPasswordCF.Text.Trim();
            CF.Port = txtPortCF.Text.Trim();
            CF.SQLCMD = txtSQLCMDPath.Text.Trim();
            CF.SQLCMD = txtSQLCMDPath.Text.Trim();
            CF.GEO = txtGeoCF.Text.Trim();
            CF.GEOPassword = txtGeoPasswordCF.Text.Trim();
            CF.UserContainerCode = txtUserContainerCodeCF.Text.Trim();
            CF.ContainerPassword = txtContainerPasswordCF.Text.Trim();
            CF.ContainerCode = txtContainerCodeCF.Text.Trim();
            CF.DeployEnv = txtDeployEnvCF.Text.Trim();
            CF.SQLServerSolution = txtSQLServerSolutionPath.Text.Trim();
            CF.CatalogDACPAC = txtCatalogDACPACPath.Text.Trim();
            CF.CoreDACPAC = txtCoreDACPACPath.Text.Trim();
            CF.WorkingPaperDACPAC = txtWorkingPaperDACPACPath.Text.Trim();
            CF.SQLPackage = txtSQLPackagePath.Text.Trim();

            var jsonCFData = JsonHelper.Serializer(CF);
            #endregion

            if (jsonMainData.NotNullOrEmpty() && jsonCFData.NotNullOrEmpty())
            {
                var updateMainResult = FileHelper.WriteFile(mainConfigPath, jsonMainData);
                var updateCFResult = FileHelper.WriteFile(cfConfigPath, jsonCFData);
                return updateMainResult && updateCFResult;
            }
            return false;
        }

        private void UpdateConfigBat()
        {
            string mainConfigData = ConvertModelToBatContentString.ConfigServer(Main);
            string cfConfigData = ConvertModelToBatContentString.ConfigServer(CF);
            if (mainConfigData.NotNullOrEmpty() && cfConfigData.NotNullOrEmpty())
            {
                string mainConfigPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerMain);
                string cfConfigPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerCF);
                FileHelper.WriteFile(mainConfigPath, mainConfigData);
                FileHelper.WriteFile(cfConfigPath, cfConfigData);
            }

            string path = Path.Combine(Global.Configuration.Path, Global.Configuration.BackupDataFolder);
            string mainConfigShortData = ConvertModelToBatContentString.ConfigShortServer(Main, path);
            string cfConfigShortData = ConvertModelToBatContentString.ConfigShortServer(CF, path);
            if (mainConfigShortData.NotNullOrEmpty() && cfConfigShortData.NotNullOrEmpty())
            {
                string mainConfigShortPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerShortMain);
                string cfConfigShortPath = Path.Combine(Global.RootAppFolderPath, BatPath.Config.ConfigServerShortCF);
                FileHelper.WriteFile(mainConfigShortPath, mainConfigShortData);
                FileHelper.WriteFile(cfConfigShortPath, cfConfigShortData);
            }
        }

        private void btnBrowserSQLServerSolution_Click(object sender, EventArgs e)
        {
            ChooseSQLServerSolutionFile();
        }

        private void ChooseSQLServerSolutionFile()
        {
            if (openFileSQLServerSolutionDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openFileSQLServerSolutionDialog.FileName;
                txtSQLServerSolutionPath.Text = newPath;
            }
        }

        private void btnBrowserCatalogDACPAC_Click(object sender, EventArgs e)
        {
            ChooseCatalogDACPACFile();
        }

        private void ChooseCatalogDACPACFile()
        {
            if (openFileCatalogDACPACDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openFileCatalogDACPACDialog.FileName;
                txtCatalogDACPACPath.Text = newPath;
            }
        }

        private void btnBrowserCoreDACPAC_Click(object sender, EventArgs e)
        {
            ChooseCoreDACPACFile();
        }

        private void ChooseCoreDACPACFile()
        {
            if (openFileCoreDACPACDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openFileCoreDACPACDialog.FileName;
                txtCoreDACPACPath.Text = newPath;
            }
        }

        private void btnBrowserWorkingPaperDACPAC_Click(object sender, EventArgs e)
        {
            ChooseWorkingPaperDACPACFile();
        }

        private void ChooseWorkingPaperDACPACFile()
        {
            if (openFileWorkingPaperDACPACDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openFileWorkingPaperDACPACDialog.FileName;
                txtWorkingPaperDACPACPath.Text = newPath;
            }
        }

        private void btnBrowserSQLPackage_Click(object sender, EventArgs e)
        {
            ChooseSQLPackageFile();
        }

        private void ChooseSQLPackageFile()
        {
            if (openFileSQLPackageDialog.ShowDialog() == DialogResult.OK)
            {
                string newPath = openFileSQLPackageDialog.FileName;
                txtSQLPackagePath.Text = newPath;
            }
        }
    }
}
