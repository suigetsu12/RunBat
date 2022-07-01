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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RunBatForm
{
    public partial class AddForm : Form
    {
        DataModel data;
        private string pathData;
        public AddForm()
        {
            InitializeComponent();
            pathData = Path.Combine(Global.RootAppFolderPath, FilePath.DataStartPath);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!txtFileName.Text.NotNullOrEmpty() || !txtName.Text.NotNullOrEmpty())
            {
                MessageBox.Show(MessageConstans.PleaseInputNameAndFileName);
                return;
            }

            Form1 frm = new Form1();
            var item = new ItemModel { file_name = txtFileName.Text, name = txtName.Text, ischecked = false };
            if (CheckExistItem(item))
            {
                MessageBox.Show(MessageConstans.ItemAlreadyExist);
            }
            else
            {
                frm.AddData(item);
                this.Close();
            }
        }

        private bool CheckExistItem(ItemModel item)
        {
            var exist = Global.StartItem.FirstOrDefault(i => (i.file_name == item.file_name || i.name == item.name));
            if (exist != null)
                return true;
            return false;
        }

        private void btnAddContinue_Click(object sender, EventArgs e)
        {
            if (!txtFileName.Text.NotNullOrEmpty() || !txtName.Text.NotNullOrEmpty())
            {
                MessageBox.Show(MessageConstans.PleaseInputNameAndFileName);
                return;
            }

            var item = new ItemModel { file_name = txtFileName.Text, name = txtName.Text, ischecked = false };
            if (CheckExistItem(item))
            {
                MessageBox.Show(MessageConstans.ItemAlreadyExist);
            }
            else
            {
                var result = AddItem(item);
                if (!result)
                {
                    lblMessage.Text = MessageConstans.Failed;
                    lblMessage.Visible = true;
                }
                else
                {
                    txtFileName.Text = string.Empty;
                    txtName.Text = string.Empty;

                    lblMessage.Text = MessageConstans.Success;
                    lblMessage.Visible = true;
                }
            }
        }

        private bool AddItem(ItemModel item)
        {
            var cloneList = new List<ItemModel>(Global.StartItem);
            cloneList.Add(item);
            var jsonData = JsonHelper.Serializer(cloneList);
            if (jsonData.NotNullOrEmpty())
            {
                var result = FileHelper.WriteFile(pathData, jsonData);
                if (result)
                    Global.StartItem.Add(item);
                return result;
            }
            return false;
        }

        private void text_change(object sender, EventArgs e)
        {
            lblMessage.Text = string.Empty;
            lblMessage.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var item = new ItemModel { file_name = txtFileName.Text, name = txtName.Text };
            if (CheckExistItem(item))
            {
                MessageBox.Show(MessageConstans.ItemAlreadyExist);
                return;
            }
            var cloneList = new List<ItemModel>(Global.StartItem);
            foreach (var i in cloneList)
            {
                if (i.name == lblHideName.Text)
                {
                    i.name = item.name;
                    i.file_name = item.file_name;
                    break;
                }
            }
            var jsonData = JsonHelper.Serializer(cloneList);
            if (jsonData.NotNullOrEmpty())
            {
                var result = FileHelper.WriteFile(pathData, jsonData);
                if (result)
                {
                    Global.StartItem = cloneList;
                    this.Close();
                }
                else
                    MessageBox.Show(MessageConstans.Failed);
            }
            else
                MessageBox.Show(MessageConstans.Failed);

        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lblHideName.Text = String.Empty;
        }
    }
}
