using RunBatForm.Constans;
using RunBatForm.Converts;
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
            var cfJsonData = FileHelper.ReadFile(cfConfigPath);
            var mainJsonData = FileHelper.ReadFile(mainConfigPath);
            if (!string.IsNullOrEmpty(cfJsonData))
            {
                CF = JsonHelper.Deserialize<ServerConfigurationModel>(cfJsonData);
                if (CF != null)
                {
                    txtPasswordCF.Text = CF.Password;
                    txtServerCF.Text = CF.Server;
                    txtUserCF.Text = CF.Login;
                    txtPortCF.Text = CF.Port;
                }
            }
            if (!string.IsNullOrEmpty(mainJsonData))
            {
                Main = JsonHelper.Deserialize<ServerConfigurationModel>(mainJsonData);
                if (Main != null)
                {
                    txtPasswordMain.Text = Main.Password;
                    txtServerMain.Text = Main.Server;
                    txtUserMain.Text = Main.Login;
                    txtPortMain.Text = Main.Port;
                }
            }
            var _data = CF ?? Main;
            if (_data != null)
            {
                txtSQLCMDPath.Text = _data.SQLCMD;
                txtExportTo.Text = _data.Path;
                ttSQLCMD.SetToolTip(txtSQLCMDPath, _data.SQLCMD);
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
            if (string.IsNullOrEmpty(txtServerMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "server main");
            if (string.IsNullOrEmpty(txtUserMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "user main");
            if (string.IsNullOrEmpty(txtPasswordMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "password main");
            if (string.IsNullOrEmpty(txtPortMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "port main");
            if (string.IsNullOrEmpty(txtGeoMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "geo main");
            if (string.IsNullOrEmpty(txtGeoPasswordMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "geo password main");
            if (string.IsNullOrEmpty(txtUserContainerCodeMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "user container code main");
            if (string.IsNullOrEmpty(txtContainerPasswordMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "container password main");
            if (string.IsNullOrEmpty(txtContainerCodeMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "container code main");
            if (string.IsNullOrEmpty(txtDeployEnvMain.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "deploy env main");
            #endregion

            #region [CF]
            if (string.IsNullOrEmpty(txtServerCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "server cf");
            if (string.IsNullOrEmpty(txtUserCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "user cf");
            if (string.IsNullOrEmpty(txtPasswordCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "password cf");
            if (string.IsNullOrEmpty(txtPortCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "port cf");
            if (string.IsNullOrEmpty(txtGeoCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "geo cf");
            if (string.IsNullOrEmpty(txtGeoPasswordCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "geo password cf");
            if (string.IsNullOrEmpty(txtUserContainerCodeCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "user container code cf");
            if (string.IsNullOrEmpty(txtContainerPasswordCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "container password cf");
            if (string.IsNullOrEmpty(txtContainerCodeCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "container code cf");
            if (string.IsNullOrEmpty(txtDeployEnvCF.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "deploy env cf");
            #endregion

            #region [General]
            if (string.IsNullOrEmpty(txtSQLCMDPath.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "SQLCMD path");
            if (string.IsNullOrEmpty(txtSQLServerSolutionPath.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "SQL server solution path");
            if (string.IsNullOrEmpty(txtCatalogDACPACPath.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "catalog dacpac path");
            if (string.IsNullOrEmpty(txtCoreDACPACPath.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "core dacpac path");
            if (string.IsNullOrEmpty(txtWorkingPaperDACPACPath.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "workingpaper dacpac path");
            if (string.IsNullOrEmpty(txtSQLPackagePath.Text))
                return string.Format(MessageConstans.TheFieldEmpty, "SQL package path");
            #endregion
            return string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var message = ValidationControl();
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message);
            var result = Update();
            if (result)
            {
                MessageBox.Show(MessageConstans.Success);

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

            if (!string.IsNullOrEmpty(jsonMainData) && !string.IsNullOrEmpty(jsonCFData))
            {
                var updateMainResult = FileHelper.WriteFile(mainConfigPath, jsonMainData);
                var updateCFResult = FileHelper.WriteFile(cfConfigPath, jsonCFData);
                return updateMainResult && updateCFResult;
            }
            return false;
        }

        private void UpdateConfigBat()
        {
            string mainConfigBat = ConvertModelToBatContentString.ConfigServer(Main);
            string cfConfigBat = ConvertModelToBatContentString.ConfigServer(CF);
            if(string.IsNullOrEmpty(mainConfigBat) && !string.IsNullOrEmpty(cfConfigBat))
            {

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
