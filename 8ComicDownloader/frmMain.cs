using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace _8ComicDownloader
{
    public partial class frmMain : Form
    {
        private string comicListPath { get { return Path.GetDirectoryName(Application.ExecutablePath) + "/comic_list.txt"; } }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMaim_Load(object sender, EventArgs e)
        {
            lblNotice.Text = "";
            numericUpDown1.Maximum = Decimal.MaxValue;
            loadDownloadPath();
            loadComicList();
        }

        /// <summary>
        /// 讀取預設下載路徑
        /// </summary>
        private void loadDownloadPath()
        {
            string downloadPath = Properties.Settings.Default["DownloadPath"].ToString();
            if (String.IsNullOrEmpty(downloadPath))
            {
                downloadPath = Path.GetDirectoryName(Application.ExecutablePath);
            }
            lblDownloadPath.Text = downloadPath;
        }

        /// <summary>
        /// 抓取漫畫清單
        /// </summary>
        private void loadComicList()
        {
            if (File.Exists(comicListPath))
            {
                cbComicList.Items.Clear();
                cbComicList.Items.AddRange(File.ReadAllLines(comicListPath));
            }
        }

        /// <summary>
        /// 將漫畫家入清單中
        /// </summary>
        /// <param name="comicName"></param>
        /// <param name="url"></param>
        private void addComicList(string comicName, string url)
        {
            string existComic = "";
            List<string> tmpList = new List<string>();

            foreach (string name in cbComicList.Items.Cast<string>())
            {
                if (name.Contains(comicName))
                {
                    tmpList.Add(comicName + ";" + url);
                    existComic = comicName;
                }
                else
                {
                    tmpList.Add(name);
                }
            }

            if (String.IsNullOrEmpty(existComic))
            {
                tmpList.Add(comicName + ";" + url);
            }

            cbComicList.Items.Clear();
            cbComicList.Items.AddRange(tmpList.ToArray());
            cbComicList.SelectedItem = comicName + ";" + url;

            saveComicList();
        }

        /// <summary>
        /// 儲存漫畫清單
        /// </summary>
        private void saveComicList()
        {
            File.WriteAllLines(comicListPath, cbComicList.Items.Cast<string>().ToArray());
        }

        private void changeTitle(string text)
        {
            this.Text = text + " - 8 Comic Downloader";
        }

        private void cbComicList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbComicList.SelectedIndex != -1)
            {
                txtUrl.Text = String.Join(";", cbComicList.SelectedItem.ToString().Split(new string[] { ";" }, StringSplitOptions.None).Skip(1).ToArray());
            }
        }

        private void btnGenerateLink_Click(object sender, EventArgs e)
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string html = wc.DownloadString(txtUrl.Text);

            // 解析網頁原始碼
            string comicName = html.Split(new string[] { ":[" }, StringSplitOptions.None)[1].Split(new string[] { "<font id=" }, StringSplitOptions.None)[0].Trim();
            string itemId = html.Split(new string[] { "var ti=" }, StringSplitOptions.None)[1].Split(new string[] { ";" }, StringSplitOptions.None)[0];
            string code = html.Split(new string[] { "var cs='" }, StringSplitOptions.None)[1].Split(new string[] { "'" }, StringSplitOptions.None)[0];

            addComicList(comicName, txtUrl.Text);

            // 解析集數資料
            ComicLinkGenerator cg = new ComicLinkGenerator();
            cg.ItemId = itemId;
            cg.Code = code;

            Dictionary<string, Comic> result = cg.DoParse();
            StringBuilder sb = new StringBuilder();
            var comics = result.Cast<KeyValuePair<string, Comic>>().OrderByDescending(x => x.Key).Take(chkGetAll.Checked ? result.Count : Convert.ToInt32(numericUpDown1.Value));
            foreach (KeyValuePair<string, Comic> kvp in comics.OrderBy(x => x.Key))
            {
                foreach (string url in kvp.Value.Urls)
                {
                    dgvList.Rows.Add(new string [] {"未下載", String.Format("{0}/{1}/{2}", comicName, kvp.Key, url.Split(new string[] { "/" }, StringSplitOptions.None).Last()), url});
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvList.Rows.Clear();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = dgvList.Rows.Count;
            System.Net.WebClient wc = new System.Net.WebClient();

            foreach(DataGridViewRow row in dgvList.Rows)
            {
                dgvList.CurrentCell = row.Cells[0];
                row.Selected = true;
                progressBar1.PerformStep();
                Application.DoEvents();

                if (row.Cells["colSts"].Value.ToString().Equals("已下載"))
                {
                    continue;
                }

                row.Cells["colSts"].Value = "下載中";

                // 重新組合下載目錄
                string dir = String.Join("/", row.Cells["colPath"].Value.ToString().Split(new string[] {"/"}, StringSplitOptions.None).Take(2).ToArray());
                string url = row.Cells["colUrl"].Value.ToString();

                string fileName = url.Split(new string[] { "/" }, StringSplitOptions.None).Last();
                string directory = url.Split(new string[] { "/" }, StringSplitOptions.None).Reverse().ToArray()[1];

                lblNotice.Text = row.Cells["colPath"].Value.ToString();
                changeTitle(lblNotice.Text);

                // string from = Path.GetTempPath() + "/" + fileName;
                string to = lblDownloadPath.Text + "/" + dir + "/" + fileName;

                // 檔案已存在就跳過不下載
                if (chkSkipExist.Checked && File.Exists(to))
                {
                    row.Cells["colSts"].Value = "略過";
                    continue;
                }

                Application.DoEvents();

                try
                {
                    // 如果目錄不存在，先產生
                    if (!Directory.Exists(Path.GetDirectoryName(to)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(to));
                    }

                    // 下載檔案
                    wc.DownloadFile(new Uri(url), to);

                    // 搬移檔案

                    //if (!String.IsNullOrEmpty(fileName))
                    //{
                    //    if (File.Exists(to))
                    //    {
                    //        File.Delete(to);
                    //    }

                    //    File.Move(from, to);
                    //}
                    row.Cells["colSts"].Value = "已下載";
                }
                catch (Exception ex)
                {
                    row.Cells["colSts"].Value = String.Format("下載失敗: {0}", ex.Message);
                }
            }

            Application.DoEvents();
            changeTitle("全部下載完成");
            MessageBox.Show("全部下載完成");
        }

        private void linkLabelOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(lblDownloadPath.Text);
        }

        private void linkLabelChangePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            folderBrowserDialog1.SelectedPath = lblDownloadPath.Text;
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lblDownloadPath.Text = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default["DownloadPath"] = lblDownloadPath.Text;
                Properties.Settings.Default.Save();

                MessageBox.Show("路徑已儲存");
            }
        }
    }
}
