using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class frmReplaceJSONConfiguration : Form
    {
        private int found = 0;
        private int replaced = 0;
        private List<string> cacheListPath = new List<string>();
        private string cacheOldValue = string.Empty;
        private string cacheNewValue = string.Empty;
        private bool hasChange = false;
        private List<string> listFilesChanged = new List<string>();
        private List<string> fileToReplace = new List<string>();
        public frmReplaceJSONConfiguration()
        {
            InitializeComponent();
            pnItems.Controls.Clear();
            fileToReplace.AddRange(Global.Configuration.FileToReplace.ToLower().Trim().Split(';'));
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
            if (!txtOldValue.Text.NotNullOrEmpty())
            {
                MessageBox.Show(MessageConstans.PleaseInputTheTextNeedToFind);
                return;
            }
            if (!txtNewValue.Text.NotNullOrEmpty())
            {
                MessageBox.Show(MessageConstans.PleaseInputTheTextNeedToReplace);
                return;
            }
            cacheListPath = SearchConfig();
            cacheOldValue = txtOldValue.Text; 
            cacheNewValue = txtNewValue.Text;
            bool result = ReplaceProcess();
            if (result)
            {
                lbFound.Text = $"Found: {found}";
                lbReplaced.Text = $"Replaced: {replaced}";
                lbFound.Visible = true;
                lbReplaced.Visible = true;
                btnRevert.Visible = true;
                PrintFilesChanged();
            }    
        }

        private bool ReplaceProcess(bool isRevert = false)
        {
            try
            {
                listFilesChanged = new List<string>();
                found = 0;
                replaced = 0;
                foreach (string fpath in cacheListPath)
                {
                    hasChange = false;
                    string jsonData = FileHelper.ReadFile(fpath);
                    var obj = JObject.Parse(jsonData);
                    var objectData = ParseJObject(obj, fpath, isRevert);
                    if (hasChange)
                    {
                        var newJsonData = JsonConvert.SerializeObject(objectData, Formatting.Indented);
                        FileHelper.WriteFile(fpath, newJsonData);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private JObject ParseJObject(JObject obj, string fpath, bool isRevert)
        {
            var newObj = obj;

            foreach (var property in obj)
            {
                var name = property.Key;
                var value = property.Value;

                if (value is JValue)
                {
                    string strValue = value.ToString();
                    string strFind = !isRevert ? cacheOldValue : cacheNewValue;
                    string strReplace = !isRevert ? cacheNewValue : cacheOldValue;
                    if (strValue.Contains(strFind))
                    {
                        found++;
                        newObj[name] = (JValue)(strValue.Replace(strFind, strReplace));
                        AddFileChanged(fpath);
                        replaced++;
                        hasChange = true;
                    }
                }
                else if (value is JArray)
                {
                    newObj[name] = (JArray)ParseJArray(value as JArray, fpath, isRevert);
                }    
                else if (value is JObject)
                {
                    newObj[name] = (JObject)ParseJObject(value as JObject, fpath, isRevert);
                }
            }

            return newObj;
        }

        private void AddFileChanged(string fpath)
        {
            if (!listFilesChanged.Contains(fpath))
                listFilesChanged.Add(fpath);
        }

        private JArray ParseJArray(JArray jar, string fpath, bool isRevert)
        {
            var newJar = new JArray();
            foreach (var item in jar)
            {
                if (item is JObject)
                {
                    newJar.Add(ParseJObject(item as JObject, fpath, isRevert));
                }
                else if (item is JArray)
                {
                    newJar.Add(ParseJArray(item as JArray, fpath, isRevert));
                } 
                else if (item is JValue)
                {
                    string strValue = item.ToString();
                    string strFind = !isRevert ? cacheOldValue : cacheNewValue;
                    string strReplace = !isRevert ? cacheNewValue : cacheOldValue;
                    if (strValue.Contains(strFind))
                    {
                        found++;
                        newJar.Add((JValue)(strValue.Replace(strFind, strReplace)));
                        AddFileChanged(fpath);
                        replaced++;
                        hasChange = true;
                    }
                }    

            }
            return newJar;
        }

        private List<string> SearchConfig(string rooDir = null)
        {
            List<string> files = new List<string>();
            try
            {
                rooDir = rooDir ?? $"{Global.Configuration.Path}\\{Global.Configuration.PublishFolder}";
                foreach (string f in Directory.GetFiles(rooDir))
                {
                    var splitName = f.Split('\\');
                    if (fileToReplace.Contains(splitName[splitName.Length - 1].ToLower().Trim()))
                        files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(rooDir))
                {
                    files.AddRange(SearchConfig(d));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return files;
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            if (ReplaceProcess(true))
            {
                lbFound.Text = $"Found: {found}";
                lbReplaced.Text = $"Reverted: {replaced}";
                btnRevert.Visible = false;
                PrintFilesChanged();
            }    
        }

        private void PrintFilesChanged()
        {
            pnItems.Controls.Clear();
            int yPoint = 15;
            foreach (var path in listFilesChanged)
            {
                Label lb = new Label();
                lb.Text = path;
                lb.Width = 600;
                pnItems.Controls.Add(lb);
                lb.Location = new Point(15, yPoint);
                yPoint += 30;
            }
        }
    }
}
