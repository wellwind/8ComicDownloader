namespace _8ComicDownloader
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnGenerateLink = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.chkGetAll = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.lblNotice = new System.Windows.Forms.Label();
            this.chkSkipExist = new System.Windows.Forms.CheckBox();
            this.cbComicList = new System.Windows.Forms.ComboBox();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.colSts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 13);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(595, 31);
            this.progressBar1.TabIndex = 3;
            // 
            // btnGenerateLink
            // 
            this.btnGenerateLink.Location = new System.Drawing.Point(553, 48);
            this.btnGenerateLink.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerateLink.Name = "btnGenerateLink";
            this.btnGenerateLink.Size = new System.Drawing.Size(218, 31);
            this.btnGenerateLink.TabIndex = 7;
            this.btnGenerateLink.Text = "分析漫畫網址(&A)";
            this.btnGenerateLink.UseVisualStyleBackColor = true;
            this.btnGenerateLink.Click += new System.EventHandler(this.btnGenerateLink_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(51, 84);
            this.txtUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(720, 27);
            this.txtUrl.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Url";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 127);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "抓最後N集";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(105, 123);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(66, 27);
            this.numericUpDown1.TabIndex = 11;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // chkGetAll
            // 
            this.chkGetAll.AutoSize = true;
            this.chkGetAll.Location = new System.Drawing.Point(179, 126);
            this.chkGetAll.Margin = new System.Windows.Forms.Padding(4);
            this.chkGetAll.Name = "chkGetAll";
            this.chkGetAll.Size = new System.Drawing.Size(59, 20);
            this.chkGetAll.TabIndex = 12;
            this.chkGetAll.Text = "全抓";
            this.chkGetAll.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(18, 523);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(218, 31);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "清空圖片網址(&C)";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(244, 523);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(218, 31);
            this.btnDownload.TabIndex = 15;
            this.btnDownload.Text = "開始下載(&D)";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // lblNotice
            // 
            this.lblNotice.AutoSize = true;
            this.lblNotice.Location = new System.Drawing.Point(621, 20);
            this.lblNotice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(46, 16);
            this.lblNotice.TabIndex = 16;
            this.lblNotice.Text = "notice";
            // 
            // chkSkipExist
            // 
            this.chkSkipExist.AutoSize = true;
            this.chkSkipExist.Checked = true;
            this.chkSkipExist.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSkipExist.Location = new System.Drawing.Point(470, 529);
            this.chkSkipExist.Margin = new System.Windows.Forms.Padding(4);
            this.chkSkipExist.Name = "chkSkipExist";
            this.chkSkipExist.Size = new System.Drawing.Size(171, 20);
            this.chkSkipExist.TabIndex = 17;
            this.chkSkipExist.Text = "檔案已存在就不下載";
            this.chkSkipExist.UseVisualStyleBackColor = true;
            // 
            // cbComicList
            // 
            this.cbComicList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComicList.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbComicList.FormattingEnabled = true;
            this.cbComicList.Location = new System.Drawing.Point(18, 52);
            this.cbComicList.Margin = new System.Windows.Forms.Padding(4);
            this.cbComicList.Name = "cbComicList";
            this.cbComicList.Size = new System.Drawing.Size(527, 24);
            this.cbComicList.TabIndex = 18;
            this.cbComicList.SelectedIndexChanged += new System.EventHandler(this.cbComicList_SelectedIndexChanged);
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSts,
            this.colPath,
            this.colUrl});
            this.dgvList.Location = new System.Drawing.Point(18, 154);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 24;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(753, 361);
            this.dgvList.TabIndex = 19;
            // 
            // colSts
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colSts.DefaultCellStyle = dataGridViewCellStyle4;
            this.colSts.HeaderText = "狀態";
            this.colSts.Name = "colSts";
            this.colSts.ReadOnly = true;
            // 
            // colPath
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colPath.DefaultCellStyle = dataGridViewCellStyle5;
            this.colPath.HeaderText = "路徑";
            this.colPath.Name = "colPath";
            this.colPath.ReadOnly = true;
            this.colPath.Width = 200;
            // 
            // colUrl
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.colUrl.DefaultCellStyle = dataGridViewCellStyle6;
            this.colUrl.HeaderText = "網址";
            this.colUrl.Name = "colUrl";
            this.colUrl.ReadOnly = true;
            this.colUrl.Width = 400;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.dgvList);
            this.Controls.Add(this.cbComicList);
            this.Controls.Add(this.chkSkipExist);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.chkGetAll);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnGenerateLink);
            this.Controls.Add(this.progressBar1);
            this.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "8Comic Downloader";
            this.Load += new System.EventHandler(this.frmMaim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnGenerateLink;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox chkGetAll;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.CheckBox chkSkipExist;
        private System.Windows.Forms.ComboBox cbComicList;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
    }
}

