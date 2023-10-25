using RunBatForm.Constans;
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
        private string configDatabasePath;
        private ServerConfigurationModel ConfigDatabase;

        public frmServerConfig()
        {
            InitializeComponent();
            configDatabasePath = Path.Combine(Global.RootAppFolderPath, FilePath.ConfigDatabasePath);
            LoadData();
        }

        private void LoadData()
        {
            var configJsonData = FileHelper.ReadFile(configDatabasePath);
            if (configJsonData.NotNullOrEmpty())
            {
                ConfigDatabase = JsonHelper.Deserialize<ServerConfigurationModel>(configJsonData);
                if (ConfigDatabase.NotNullOrEmpty())
                {
                    txtEntityName.Text = ConfigDatabase.Entity.Name;
                    txtSiteCollectionUrl.Text = ConfigDatabase.Entity.SiteCollectionUrl;
                    txtGeo.Text = ConfigDatabase.GEO;
                    txtGeoPassword.Text = ConfigDatabase.GEOPassword;
                    txtUserContainerCode.Text = ConfigDatabase.UserContainerCode;
                    txtContainerPassword.Text = ConfigDatabase.ContainerPassword;
                    txtContainerCode.Text = ConfigDatabase.ContainerCode;
                    txtDeployEnv.Text = ConfigDatabase.DeployEnv;
                    txtSQLCMDPath.Text = ConfigDatabase.SQLCMD;
                    txtExportTo.Text = ConfigDatabase.Path;
                    ttSQLCMD.SetToolTip(txtSQLCMDPath, ConfigDatabase.SQLCMD);
                    txtSQLPackagePath.Text = ConfigDatabase.SQLPackage;

                    txtServerMain.Text = ConfigDatabase.Main.Server;
                    txtUserMain.Text = ConfigDatabase.Main.Login;
                    txtPasswordMain.Text = ConfigDatabase.Main.Password;
                    txtPortMain.Text = ConfigDatabase.Main.Port;

                    txtServerCF.Text = ConfigDatabase.CF.Server;
                    txtUserCF.Text = ConfigDatabase.CF.Login;
                    txtPasswordCF.Text = ConfigDatabase.CF.Password;
                    txtPortCF.Text = ConfigDatabase.CF.Port;
                }
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
            #endregion

            #region [General]
            if (!txtEntityName.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "entity name");
            if (!txtSiteCollectionUrl.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "site collection url");
            if (!txtUserContainerCode.Text.NotNullOrEmpty())
                if (!txtGeo.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "geo");
            if (!txtGeoPassword.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "geo password");
            if (!txtUserContainerCode.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "user container code");
            if (!txtContainerPassword.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "container password");
            if (!txtContainerCode.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "container code");
            if (!txtDeployEnv.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "deploy env");
            if (!txtSQLCMDPath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "SQLCMD path");
            if (!txtSQLPackagePath.Text.NotNullOrEmpty())
                return string.Format(MessageConstans.TheFieldEmpty, "SQL package path");
            #endregion
            return string.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var message = ValidationControl();
            if (message.NotNullOrEmpty())
            {
                MessageBox.Show(message);
                return;
            }
            var result = Update();
            if (result)
                MessageBox.Show(MessageConstans.Success);
            else
                MessageBox.Show(MessageConstans.Failed);
        }

        private bool Update()
        {
            #region [General]
            ConfigDatabase.Entity.Name = txtEntityName.Text.Trim();
            ConfigDatabase.Entity.SiteCollectionUrl = txtSiteCollectionUrl.Text.Trim();
            ConfigDatabase.SQLCMD = txtSQLCMDPath.Text.Trim();
            ConfigDatabase.GEO = txtGeo.Text.Trim();
            ConfigDatabase.GEOPassword = txtGeoPassword.Text.Trim();
            ConfigDatabase.UserContainerCode = txtUserContainerCode.Text.Trim();
            ConfigDatabase.ContainerPassword = txtContainerPassword.Text.Trim();
            ConfigDatabase.ContainerCode = txtContainerCode.Text.Trim();
            ConfigDatabase.DeployEnv = txtDeployEnv.Text.Trim();
            ConfigDatabase.SQLPackage = txtSQLPackagePath.Text.Trim();
            #endregion

            #region [Main]
            ConfigDatabase.Main.Server = txtServerMain.Text.Trim();
            ConfigDatabase.Main.Login = txtUserMain.Text.Trim();
            ConfigDatabase.Main.Password = txtPasswordMain.Text.Trim();
            ConfigDatabase.Main.Port = txtPortMain.Text.Trim();
            #endregion

            #region [CF]
            ConfigDatabase.CF.Server = txtServerCF.Text.Trim();
            ConfigDatabase.CF.Login = txtUserCF.Text.Trim();
            ConfigDatabase.CF.Password = txtPasswordCF.Text.Trim();
            ConfigDatabase.CF.Port = txtPortCF.Text.Trim();
            #endregion

            var jsonData = JsonHelper.Serializer(ConfigDatabase);
            if (ConfigDatabase.NotNullOrEmpty())
                return FileHelper.WriteFile(configDatabasePath, jsonData);
            return false;
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
