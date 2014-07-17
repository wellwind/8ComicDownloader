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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMaim_Load(object sender, EventArgs e)
        {
            lblNotice.Text = "";
            loadComicList();
        }

        /// <summary>
        /// 抓取漫畫清單
        /// </summary>
        private void loadComicList()
        {
            if (File.Exists("./comic_list.txt"))
            {
                cbComicList.Items.Clear();
                cbComicList.Items.AddRange(File.ReadAllLines("comic_list.txt"));
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
            File.WriteAllLines("./comic_list.txt", cbComicList.Items.Cast<string>().ToArray());
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
            string comicName = html.Split(new string[] { ":[" }, StringSplitOptions.None)[1].Split(new string[] { "<font id=" }, StringSplitOptions.None)[0].Trim();
            string itemId = html.Split(new string[] { "var ti=" }, StringSplitOptions.None)[1].Split(new string[] { ";" }, StringSplitOptions.None)[0];
            string code = html.Split(new string[] { "var cs='" }, StringSplitOptions.None)[1].Split(new string[] { "'" }, StringSplitOptions.None)[0];

            addComicList(comicName, txtUrl.Text);

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
                    sb.AppendLine(String.Format("{0}/{1}|{2}", comicName, kvp.Key, url));
                }
            }
            txtDownloadUrls.Text += sb.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDownloadUrls.Clear();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string[] files = txtDownloadUrls.Text.Split(new string[] {"\r", "\n"}, StringSplitOptions.RemoveEmptyEntries);
            progressBar1.Value = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = files.Length;
            System.Net.WebClient wc = new System.Net.WebClient();

            foreach (string file in files)
            {
                progressBar1.PerformStep();
                if(String.IsNullOrEmpty(file.Trim())) continue;
                string[] tmp = file.Split(new string[] { "|" }, StringSplitOptions.None);
    
                string dir = tmp[0];
                string url = tmp[1];

                string fileName = url.Split(new string[] { "/" }, StringSplitOptions.None).Last();
                string directory = url.Split(new string[] { "/" }, StringSplitOptions.None).Reverse().ToArray()[1];

                lblNotice.Text = "./" + directory + "/" + fileName;
                changeTitle(lblNotice.Text);

                string from = "./" + fileName;
                string to = "./" + dir + "/" + fileName;

                // 檔案已存在就跳過不下載
                if (chkSkipExist.Checked && File.Exists(to))
                {
                    continue;
                }

                Application.DoEvents();

                try
                {
                    // 下載檔案
                    wc.DownloadFile(url, "./" + fileName);

                    // 搬移檔案
                    if (!Directory.Exists("./" + dir))
                    {
                        Directory.CreateDirectory("./" + dir);
                    }
                    if (!String.IsNullOrEmpty(fileName))
                    {
                        if (File.Exists(to))
                        {
                            File.Delete(to);
                        }

                        File.Move(from, to);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Application.DoEvents();
            }

            changeTitle("Done");
            MessageBox.Show("Done");
        }
    }
}
