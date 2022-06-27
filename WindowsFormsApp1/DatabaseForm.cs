using RunBatForm.Constans;
using RunBatForm.Enums;
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
    public partial class frmDatabaseForm : Form
    {
        private string pathData;
        private string databasePath;
        private List<DatabaseItemModel> items;
        private string selectedItem;
        public frmDatabaseForm()
        {
            InitializeComponent();
            databasePath = Path.Combine(Global.RootAppFolderPath, BatPath.DatabaseFolderPath);
            pathData = Path.Combine(Global.RootAppFolderPath, FilePath.DataDatabasePath);
            LoadData();
        }

        private void LoadData()
        {
            var jsonData = FileHelper.ReadFile(pathData);
            if (!string.IsNullOrEmpty(jsonData))
            {
                items = JsonHelper.Deserialize<List<DatabaseItemModel>>(jsonData);
            }
        }

        private void rdbDeploy_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.DEPLOY);
        }

        private void rdbMigrate_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.MIGRATE);
        }

        private void rdbBackup_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.BACKUP);
        }

        private void rdbRestore_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.RESTORE);
        }

        private void rdbDrop_CheckedChanged(object sender, EventArgs e)
        {
            BindData(HandleDatabaseType.DROP);
        }

        private void BindData(HandleDatabaseType type)
        {
            if(items != null && items.Count > 0)
            {
                var _data = items.FindAll(i => i.handle_type == type);
                if (_data != null && _data.Count > 0)
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
                    selectedItem = string.Empty;
                    btnRun.Enabled = false;
                }
            }
        }

        private void CheckedChangeItem(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            if (r.Checked)
            {
                selectedItem = items.Find(i => i.name == r.Text).file_name;
                btnRun.Enabled = true;
            }
            else
            {
                selectedItem = string.Empty;
                btnRun.Enabled = false;
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedItem) && !string.IsNullOrEmpty(databasePath))
            {
                try
                {
                    var filePath = databasePath + @"\" + selectedItem;
                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show(MessageConstans.FileDoesNotExist);
                    }
                    else
                    {
                        CommandLineHelper.Run(databasePath, filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
