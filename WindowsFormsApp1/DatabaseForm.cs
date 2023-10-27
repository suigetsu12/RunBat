using RunBatForm.Constans;
using RunBatForm.Enums;
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
using static RunBatForm.Constans.RootPath;

namespace RunBatForm
{
    public partial class frmDatabaseForm : Form
    {
        private string pathData;
        private string databasePath;
        private string tempPath;
        private List<DatabaseItemModel> items;
        private string selectedItem;
        private ScriptType selectedScriptType;
        private string configDatabasePath;
        private ServerConfigurationModel ConfigDatabase;
        private bool isDeployMigrateDatabase = false;
        private bool isSelectServer = false;
        public frmDatabaseForm()
        {
            InitializeComponent();
            databasePath = Path.Combine(Global.RootAppFolderPath, BatPath.DatabaseFolderPath);
            tempPath = Path.Combine(Global.RootAppFolderPath, BatPath.Temp.TempFolder);
            pathData = Path.Combine(Global.RootAppFolderPath, FilePath.DataDatabasePath);
            configDatabasePath = Path.Combine(Global.RootAppFolderPath, FilePath.ConfigDatabasePath);
            var jsonData = FileHelper.ReadFile(configDatabasePath);
            if (jsonData.NotNullOrEmpty())
            {
                ConfigDatabase = JsonHelper.Deserialize<ServerConfigurationModel>(jsonData);
            }
            LoadData();
        }

        private void LoadData()
        {
            var jsonData = FileHelper.ReadFile(pathData);
            if (jsonData.NotNullOrEmpty())
            {
                items = JsonHelper.Deserialize<List<DatabaseItemModel>>(jsonData);
            }
        }

        private void rdbDeploy_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.DEPLOY);
            gbDatabaseGroup.Visible = true;
            isDeployMigrateDatabase = true;
        }

        private void rdbMigrate_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.MIGRATE);
            gbDatabaseGroup.Visible = true;
            isDeployMigrateDatabase = true;
        }

        private void rdbBackup_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.BACKUP);
            gbDatabaseGroup.Visible = false;
            isDeployMigrateDatabase = false;
        }

        private void rdbRestore_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.RESTORE);
            gbDatabaseGroup.Visible = false;
            isDeployMigrateDatabase = false;
        }

        private void rdbDrop_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.DROP);
            gbDatabaseGroup.Visible = false;
            isDeployMigrateDatabase = false;
        }

        private void BindData(HandleDatabaseType type)
        {
            if(!items.IsNullOrEmpty())
            {
                var _data = items.FindAll(i => i.handle_type == type);
                if (!_data.IsNullOrEmpty())
                {
                    pnItems.Controls.Clear();
                    int yPoint = 15;
                    foreach (var item in _data)
                    {
                        RadioButton rb = new RadioButton();
                        rb.Text = item.name;
                        rb.Width = 600;
                        rb.CheckedChanged += new EventHandler(this.CheckedChangeItem);
                        pnItems.Controls.Add(rb);
                        rb.Location = new Point(15, yPoint);
                        yPoint += 30;
                    }
                    cbWorkingpaper.Checked = false;
                    cbCore.Checked = false;
                    cbCatalog.Checked = false;
                    isSelectServer = false;
                    selectedItem = string.Empty;
                    btnRun.Enabled = false;
                }
            }
        }

        private void DatabaseCheckedChangeItem(object sender, EventArgs e)
        {
            bool canRun = !isDeployMigrateDatabase || (isDeployMigrateDatabase && isSelectServer && (cbWorkingpaper.Checked || cbCore.Checked || cbCatalog.Checked));
            btnRun.Enabled = canRun;
        }

        private void CheckedChangeItem(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            if (r.Checked)
            {
                var item = items.Find(i => i.name == r.Text);
                selectedItem = item.file_name;
                selectedScriptType = item.script_type;
                if(isDeployMigrateDatabase)
                {
                    isSelectServer = true;
                }
                bool canRun = !isDeployMigrateDatabase || (isDeployMigrateDatabase && isSelectServer && (cbWorkingpaper.Checked || cbCore.Checked || cbCatalog.Checked));
                btnRun.Enabled = canRun;
            }
            else
            {
                selectedItem = string.Empty;
                btnRun.Enabled = false;
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool canRun = !isDeployMigrateDatabase || (isDeployMigrateDatabase && (cbWorkingpaper.Checked || cbCore.Checked || cbCatalog.Checked));
            if (!canRun)
            {
                MessageBox.Show(MessageConstans.PleaseSelectDatabase);
                return;
            }
            if (selectedItem.NotNullOrEmpty() && databasePath.NotNullOrEmpty())
            {
                try
                {
                    string scriptPath = RenderScriptFile();
                    if (scriptPath.NotNullOrEmpty())
                        CommandLineHelper.Run(tempPath, scriptPath);
                    else
                    {
                        MessageBox.Show(MessageConstans.FileDoesNotExist);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string RenderScriptFile()
        {
            string content = string.Empty;
            string path = string.Empty;
            switch (selectedScriptType)
            {
                case ScriptType.DEPLOY_MAIN:
                case ScriptType.DEPLOY_CF:
                case ScriptType.MIGRATE_MAIN:
                case ScriptType.MIGRATE_CF:
                    if (cbCore.Checked && (selectedScriptType == ScriptType.DEPLOY_MAIN || selectedScriptType == ScriptType.DEPLOY_CF))
                    {
                        var entity_content = RenderScriptHelper.ScriptInsertEntity(ConfigDatabase);
                        if (entity_content.NotNullOrEmpty())
                        {
                            var entityPath = Path.Combine(Global.RootAppFolderPath, BatPath.Temp.ScriptEntity);
                            FileHelper.DeleteFile(entityPath);//delete old file
                            FolderHelper.CreateFolder(tempPath);
                            FileHelper.WriteFile(entityPath, entity_content);
                        }
                    }
                    content = RenderScriptHelper.DeployOrMigrate(ConfigDatabase, selectedScriptType, cbCatalog.Checked, cbCore.Checked, cbWorkingpaper.Checked);
                    break;
                case ScriptType.BACKUP_MAIN:
                case ScriptType.BACKUP_CF:
                    var backup_content = RenderScriptHelper.ScriptBackup(ConfigDatabase, (selectedScriptType == ScriptType.BACKUP_MAIN) ? ServerType.MAIN : ServerType.CF);
                    if (backup_content.NotNullOrEmpty())
                    {
                        var backupPath = Path.Combine(Global.RootAppFolderPath, BatPath.Temp.ScriptBackup);
                        FileHelper.DeleteFile(backupPath);//delete old file
                        FolderHelper.CreateFolder(tempPath);
                        FileHelper.WriteFile(backupPath, backup_content);
                    }
                    content = RenderScriptHelper.BackupDatabase(ConfigDatabase, selectedScriptType);
                    break;
                case ScriptType.RESTORE_MAIN:
                case ScriptType.RESTORE_CF:
                    var restore_content = RenderScriptHelper.ScriptRestore(ConfigDatabase, (selectedScriptType == ScriptType.RESTORE_MAIN) ? ServerType.MAIN : ServerType.CF);
                    if (restore_content.NotNullOrEmpty())
                    {
                        var restorePath = Path.Combine(Global.RootAppFolderPath, BatPath.Temp.ScriptRestore);
                        FileHelper.DeleteFile(restorePath);//delete old file
                        FolderHelper.CreateFolder(tempPath);
                        FileHelper.WriteFile(restorePath, restore_content);
                    }
                    content = RenderScriptHelper.RestoreDatabase(ConfigDatabase, selectedScriptType);
                    break;
                case ScriptType.DROP_MAIN:
                case ScriptType.DROP_CF:
                    var drop_content = RenderScriptHelper.ScriptDrop(ConfigDatabase, (selectedScriptType == ScriptType.DROP_MAIN) ? ServerType.MAIN : ServerType.CF);
                    if (drop_content.NotNullOrEmpty())
                    {
                        var dropPath = Path.Combine(Global.RootAppFolderPath, BatPath.Temp.ScriptDrop);
                        FileHelper.DeleteFile(dropPath);//delete old file
                        FolderHelper.CreateFolder(tempPath);
                        FileHelper.WriteFile(dropPath, drop_content);
                    }
                    content = RenderScriptHelper.DropDatabase(ConfigDatabase, selectedScriptType);
                    break;
            }

            if (content.NotNullOrEmpty())
            {
                path = Path.Combine(Global.RootAppFolderPath, BatPath.Temp.ScriptRun);
                FileHelper.DeleteFile(path);//delete old file
                FolderHelper.CreateFolder(tempPath);
                FileHelper.WriteFile(path, content);
            }

            return path;
        }
    }
}
