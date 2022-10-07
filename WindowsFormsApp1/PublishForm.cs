using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using RunBatForm.Enums;
using RunBatForm.Models;
using RunBatForm.Constans;
using RunBatForm.Helpers;
using System.Drawing;
using RunBatForm.Extensions;

namespace RunBatForm
{
    public partial class frmPublishForm : Form
    {
        private string publishPath;
        private string pathData;
        private List<PublishItemModel> items;
        private string selectedItem;
        public frmPublishForm()
        {
            InitializeComponent();
            publishPath = Path.Combine(Global.RootAppFolderPath, BatPath.PublishFolderPath);
            pathData = Path.Combine(Global.RootAppFolderPath, FilePath.DataPublishPath);
            LoadData();
        }

        private void LoadData()
        {
            var jsonData = FileHelper.ReadFile(pathData);
            if (jsonData.NotNullOrEmpty())
            {
                items = JsonHelper.Deserialize<List<PublishItemModel>>(jsonData);
            }
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            if (selectedItem.NotNullOrEmpty() && publishPath.NotNullOrEmpty())
            {
                try
                {
                    var filePath = publishPath + @"\" + selectedItem;
                    if (!File.Exists(filePath))
                    {
                        MessageBox.Show(MessageConstans.FileDoesNotExist);
                    }
                    else
                    {
                        CommandLineHelper.Run(publishPath, filePath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void rdbFeature_CheckedChanged(object sender, EventArgs e)
        {
            BindData(PublishType.FEATURE);
        }

        private void rdbFunction_CheckedChanged(object sender, EventArgs e)
        {
            BindData(PublishType.FUNCTION);
        }

        private void BindData(PublishType type)
        {
            if (!items.IsNullOrEmpty())
            {
                var _data = items.FindAll(i => i.publish_type == type);
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
                    selectedItem = string.Empty;
                    btnPublish.Enabled = false;
                }
            }    
        }

        private void CheckedChangeItem(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            if (r.Checked)
            {
                selectedItem = items.Find(i => i.name == r.Text).file_name;
                btnPublish.Enabled = true;
            }
            else
            {
                selectedItem = string.Empty;
                btnPublish.Enabled = false;
            }
                
        }
    }
}
