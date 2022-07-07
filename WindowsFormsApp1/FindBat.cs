using RunBatForm.Constans;
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
    public partial class frmFindBat : Form
    {
        private string startPath;
        private string pathData;
        private List<ItemModel> batList;
        public frmFindBat()
        {
            InitializeComponent();
            startPath = Path.Combine(Global.RootAppFolderPath, BatPath.StartFolderPath);
            pathData = Path.Combine(Global.RootAppFolderPath, FilePath.DataStartPath);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void FindData()
        {
            batList = ReadAllFileInFolder(startPath);
            if (batList != null && batList.Count > 0)
            {
                BindData(batList);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            var cloneList = new List<ItemModel>(Global.StartItem);
            foreach (var item in batList)
            {
                if (item.ischecked)
                {
                    item.ischecked = false;
                    cloneList.Add(item);
                }
            }
            if (Global.StartItem.Count < cloneList.Count)
            {
                var jsonData = JsonHelper.Serializer(cloneList);
                if (jsonData.NotNullOrEmpty())
                {
                    var result = FileHelper.WriteFile(pathData, jsonData);
                    if (result)
                    {
                        MessageBox.Show(MessageConstans.Success);
                        Global.StartItem = cloneList;
                        FindData();
                        btnUpdate.Enabled = false;
                    }    
                    else
                        MessageBox.Show(MessageConstans.Failed);
                }
            }
            else
                MessageBox.Show(MessageConstans.NoDataSelected);
        }

        private List<ItemModel> ReadAllFileInFolder(string path)
        {
            List<ItemModel> newItems = new List<ItemModel>();
            string[] files = Directory.GetFiles(path, "*.bat");
            foreach (string file in files)
            {
                string fileName = file.Replace(path, "").Replace("\\", "");
                var exist = Global.StartItem.Find(i => i.file_name == fileName);
                if (exist == null)
                {
                    newItems.Add(new ItemModel
                    {
                        file_name = fileName,
                        name = fileName.Replace(".bat", "")
                    });
                }
            }
            return newItems;
        }

        private void BindData(List<ItemModel> data)
        {
            var list = new BindingList<ItemModel>(data);
            dtgBatFile.DataSource = list;
        }

        private void dtgBatFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var name = dtgBatFile.Rows[e.RowIndex].Cells["clName"].Value;
                var ischecked = Convert.ToBoolean(dtgBatFile.Rows[e.RowIndex].Cells["clSelected"].Value);
                foreach (var i in batList)
                {
                    if (i.name == name.ToString())
                        i.ischecked = !ischecked;
                }
                if (batList.Find(i => i.ischecked) != null)
                    btnUpdate.Enabled = true;
                else
                    btnUpdate.Enabled = false;
            }
        }
    }
}
