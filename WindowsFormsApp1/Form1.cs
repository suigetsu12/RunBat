using Newtonsoft.Json;
using RunBatForm.Models;
using RunBatForm.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RunBatForm.Constans;
using RunBatForm.Helpers;
using RunBatForm.Extensions;
using System.Reflection;

namespace RunBatForm
{
    public partial class Form1 : Form
    {
        List<Process> processes = new List<Process>();
        private string path;
        public Form1()
        {
            InitializeComponent();
            path = Path.Combine(Global.RootAppFolderPath, FilePath.DataStartPath);
            ReadData();
            RenderData();
        }

        private void ReadData()
        {
            try
            {
                var jsonData = FileHelper.ReadFile(path);
                if (jsonData.NotNullOrEmpty())
                {
                    Global.StartItem = JsonHelper.Deserialize<List<ItemModel>>(jsonData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RenderData()
        {
            if (Global.StartItem != null && Global.StartItem.Count > 0)
            {
                BindData();
            }
        }

        private void BindData()
        {
            var list = new BindingList<ItemModel>(Global.StartItem);
            dtgData.DataSource = list;
        }

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (SaveFile())
                    MessageBox.Show(MessageConstans.Success);
                else
                    MessageBox.Show(MessageConstans.Failed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool SaveFile()
        {
            try
            {
                if (Global.StartItem == null || Global.StartItem.Count == 0)
                {
                    return false;
                }

                var jsonData = JsonHelper.Serializer(Global.StartItem);
                if (jsonData.NotNullOrEmpty())
                {
                    var result = FileHelper.WriteFile(path, jsonData);
                    RenderData();
                    return result;
                }
                return false;
            }
            catch
            {
                return false;
            }

        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (Global.StartItem == null || Global.StartItem.Count == 0)
            {
                MessageBox.Show(MessageConstans.TheDataIsEmpty);
                return;
            }

            string batDir = Path.Combine(Global.RootAppFolderPath, BatPath.StartFolderPath);
            bool hasProcess = false;
            foreach (var i in Global.StartItem)
            {
                if (i.ischecked && i.processid == 0)
                {
                    try
                    {
                        var filePath = batDir + @"\" + i.file_name;
                        if (!File.Exists(filePath))
                        {
                            i.message = MessageConstans.FileDoesNotExist;
                            continue;
                        }
                        var process = CommandLineHelper.Run(batDir, filePath);
                        processes.Add(process);
                        i.message = MessageConstans.Running;
                        i.processid = process.Id;
                        if (!hasProcess)
                            hasProcess = true;
                    }
                    catch (Exception ex)
                    {
                        i.message = ex.Message;
                    }
                }
            }
            if (hasProcess)
                btnStopAll.Enabled = true;

            RenderData();
            Thread trd = new Thread(new ThreadStart(this.CheckProcess));
            trd.IsBackground = true;
            trd.Start();
        }

        private void btnCheckedAll_Click(object sender, EventArgs e)
        {
            foreach (var i in Global.StartItem)
            {
                i.ischecked = true;
            }
            btnRun.Enabled = true;
            dtgData_Refresh();
        }

        private void btnUnCheckedAll_Click(object sender, EventArgs e)
        {
            foreach (var i in Global.StartItem)
            {
                i.ischecked = false;
            }
            btnRun.Enabled = false;
            dtgData_Refresh();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            ReadData();
            RenderData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddForm addFr = new AddForm();
            addFr.btnAdd.Visible = true;
            addFr.btnAddContinue.Visible = true;
            addFr.btnUpdate.Visible = false;
            addFr.ShowDialog();
            this.Reload();
        }

        public void AddData(ItemModel item)
        {
            Global.StartItem.Add(item);
            SaveFile();
        }

        private void dtgData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                var name = dtgData.Rows[e.RowIndex].Cells["clName"].Value;
                var ischecked = Convert.ToBoolean(dtgData.Rows[e.RowIndex].Cells["clRun"].Value);
                foreach (var i in Global.StartItem)
                {
                    if (i.name == name.ToString())
                        i.ischecked = !ischecked;
                }
            }
            if (processes.Count > 0)
                btnStop.Enabled = true;
        }

        public void UpdateData(string name, ItemModel item)
        {
            foreach (var i in Global.StartItem)
            {
                if (i.name == name)
                {
                    i.name = item.name;
                    i.file_name = item.file_name;
                    break;
                }
            }
            SaveFile();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dtgData_Edit();
        }

        private void dtgData_Edit()
        {
            var selectedRow = dtgData.SelectedRows[0];
            if (selectedRow != null)
            {
                AddForm addFrm = new AddForm();
                var name = selectedRow.Cells["clName"].Value;
                var fname = selectedRow.Cells["clFileName"].Value;
                addFrm.txtName.Text = name.ToString();
                addFrm.txtFileName.Text = fname.ToString();
                addFrm.lblHideName.Text = name.ToString();
                addFrm.btnAdd.Visible = false;
                addFrm.btnAddContinue.Visible = false;
                addFrm.btnUpdate.Visible = true;
                addFrm.ShowDialog();
                this.Reload();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var selectedRow = dtgData.SelectedRows[0];
            if (selectedRow != null)
            {
                var val = selectedRow.Cells["clName"].Value;
                var exist = Global.StartItem.FirstOrDefault(i => i.name == val.ToString());
                if (exist != null)
                    Global.StartItem.Remove(exist);

                SaveFile();
                BindData();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (processes.Count > 0)
            {
                var selectedRow = dtgData.SelectedRows[0];
                if (selectedRow != null)
                {
                    var val = Convert.ToInt32(selectedRow.Cells["clProcessId"].Value);
                    if (val != 0)
                    {
                        var proc = processes.FirstOrDefault(i => i.Id == val);
                        if (proc != null)
                        {
                            KillProcessAndChildrens(val);
                            processes.Remove(proc);
                        }
                        var item = Global.StartItem.FirstOrDefault(i => i.processid == val);
                        if (item != null)
                        {
                            item.processid = 0;
                            item.message = "";
                        }
                        dtgData_Refresh();
                    }
                }
            }
        }

        private void KillProcessAndChildrens(int pid)
        {
            ManagementObjectSearcher processSearcher = new ManagementObjectSearcher
                ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection processCollection = processSearcher.Get();

            try
            {
                Process proc = Process.GetProcessById(pid);
                if (!proc.HasExited) proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }

            if (processCollection != null)
            {
                foreach (ManagementObject mo in processCollection)
                {
                    KillProcessAndChildrens(Convert.ToInt32(mo["ProcessID"])); //kill child processes(also kills childrens of childrens etc.)
                }
            }
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            if (processes.Count > 0)
            {
                foreach (var proc in processes)
                {
                    KillProcessAndChildrens(proc.Id);
                    var item = Global.StartItem.FirstOrDefault(i => i.processid == proc.Id);
                    if (item != null)
                    {
                        item.processid = 0;
                        item.message = "";
                    }
                    Thread.Sleep(100);
                }
                dtgData_Refresh();
                processes = new List<Process>();
            }
        }

        private void CheckProcess()
        {
            bool run = true;
            while (run)
            {
                bool hasChange = false;
                var f = Global.StartItem.FirstOrDefault(i => i.processid != 0);
                if (f == null)
                {
                    run = false;
                    continue;
                }

                foreach (var i in Global.StartItem)
                {
                    if (i.processid != 0)
                    {
                        var _process = Process.GetProcessById(i.processid);
                        if (_process != null && _process.HasExited)
                        {
                            i.processid = 0;
                            i.message = string.Empty;
                            hasChange = true;
                        }
                    }
                }

                if (hasChange)
                    dtgData_Refresh();
                Thread.Sleep(1000);
            }
        }

        private void dtgData_Refresh()
        {
            dtgData.Invoke(new MethodInvoker(() => dtgData.Refresh()));
        }

        private void dtgData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgData_Edit();
        }

        private void dtgData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in dtgData.Rows)
            {
                var value = row.Cells["clMessage"].Value?.ToString();
                if (value.NotNullOrEmpty())
                {
                    if (value == MessageConstans.Running)
                        row.Cells["clMessage"].Style.ForeColor = Color.Blue;
                    else
                        row.Cells["clMessage"].Style.ForeColor = Color.Red;
                }
                else
                    row.Cells["clMessage"].Style.ForeColor = Color.Black;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm frmConfig = new ConfigForm();
            frmConfig.ShowDialog();
        }

        private void btnResetProcess_Click(object sender, EventArgs e)
        {
            foreach (var item in Global.StartItem)
            {
                item.processid = 0;
                item.message = "";
            }
            if (SaveFile())
                MessageBox.Show(MessageConstans.Success);
            else
                MessageBox.Show(MessageConstans.Failed);
        }

        private void btnFindBat_Click(object sender, EventArgs e)
        {
            frmFindBat frm = new frmFindBat();
            frm.ShowDialog();
            this.Reload();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            frmPublishForm frm = new frmPublishForm();
            frm.ShowDialog();
        }

        private void btnDatabase_Click(object sender, EventArgs e)
        {
            frmDatabaseForm frm = new frmDatabaseForm();
            frm.ShowDialog();
        }

        private void btnServerConfig_Click(object sender, EventArgs e)
        {
            frmServerConfig frm = new frmServerConfig();
            frm.ShowDialog();
        }

        private void btnCreateBaseData_Click(object sender, EventArgs e)
        {
        }
    }
}
