
namespace _7x5dotFontSender
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxMessage = new System.Windows.Forms.TextBox();
            this.lblSendText = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.gbxTextSend = new System.Windows.Forms.GroupBox();
            this.lblSpeedFast = new System.Windows.Forms.Label();
            this.lblSpeedSlow = new System.Windows.Forms.Label();
            this.tbrSpeed = new System.Windows.Forms.TrackBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblConnect = new System.Windows.Forms.Label();
            this.btnSerialOpen = new System.Windows.Forms.Button();
            this.btnClean = new System.Windows.Forms.Button();
            this.gbxTextSend.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxMessage
            // 
            this.tbxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMessage.Location = new System.Drawing.Point(6, 44);
            this.tbxMessage.Multiline = true;
            this.tbxMessage.Name = "tbxMessage";
            this.tbxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxMessage.Size = new System.Drawing.Size(550, 160);
            this.tbxMessage.TabIndex = 3;
            this.tbxMessage.Text = "こんにちは。";
            // 
            // lblSendText
            // 
            this.lblSendText.AutoSize = true;
            this.lblSendText.Location = new System.Drawing.Point(6, 26);
            this.lblSendText.Name = "lblSendText";
            this.lblSendText.Size = new System.Drawing.Size(53, 12);
            this.lblSendText.TabIndex = 0;
            this.lblSendText.Text = "送信文字";
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(448, 209);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(108, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "一　行　送　信";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // gbxTextSend
            // 
            this.gbxTextSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxTextSend.Controls.Add(this.lblSpeedFast);
            this.gbxTextSend.Controls.Add(this.lblSpeedSlow);
            this.gbxTextSend.Controls.Add(this.tbrSpeed);
            this.gbxTextSend.Controls.Add(this.btnStop);
            this.gbxTextSend.Controls.Add(this.lblConnect);
            this.gbxTextSend.Controls.Add(this.btnSerialOpen);
            this.gbxTextSend.Controls.Add(this.btnClean);
            this.gbxTextSend.Controls.Add(this.lblSendText);
            this.gbxTextSend.Controls.Add(this.btnSend);
            this.gbxTextSend.Controls.Add(this.tbxMessage);
            this.gbxTextSend.Location = new System.Drawing.Point(12, 3);
            this.gbxTextSend.Name = "gbxTextSend";
            this.gbxTextSend.Size = new System.Drawing.Size(562, 240);
            this.gbxTextSend.TabIndex = 0;
            this.gbxTextSend.TabStop = false;
            // 
            // lblSpeedFast
            // 
            this.lblSpeedFast.AutoSize = true;
            this.lblSpeedFast.Location = new System.Drawing.Point(318, 220);
            this.lblSpeedFast.Name = "lblSpeedFast";
            this.lblSpeedFast.Size = new System.Drawing.Size(27, 12);
            this.lblSpeedFast.TabIndex = 7;
            this.lblSpeedFast.Text = "速い";
            // 
            // lblSpeedSlow
            // 
            this.lblSpeedSlow.AutoSize = true;
            this.lblSpeedSlow.Location = new System.Drawing.Point(92, 220);
            this.lblSpeedSlow.Name = "lblSpeedSlow";
            this.lblSpeedSlow.Size = new System.Drawing.Size(79, 12);
            this.lblSpeedSlow.TabIndex = 5;
            this.lblSpeedSlow.Text = "表示速度 遅い";
            // 
            // tbrSpeed
            // 
            this.tbrSpeed.AutoSize = false;
            this.tbrSpeed.Location = new System.Drawing.Point(171, 208);
            this.tbrSpeed.Name = "tbrSpeed";
            this.tbrSpeed.Size = new System.Drawing.Size(144, 24);
            this.tbrSpeed.TabIndex = 6;
            this.tbrSpeed.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbrSpeed.Value = 8;
            this.tbrSpeed.Scroll += new System.EventHandler(this.tbrSpeed_Scroll);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(367, 209);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "送信停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblConnect.Location = new System.Drawing.Point(82, 26);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(70, 12);
            this.lblConnect.TabIndex = 1;
            this.lblConnect.Text = "接続ポート: ";
            this.lblConnect.Click += new System.EventHandler(this.lblConnect_Click);
            // 
            // btnSerialOpen
            // 
            this.btnSerialOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSerialOpen.Location = new System.Drawing.Point(375, 11);
            this.btnSerialOpen.Name = "btnSerialOpen";
            this.btnSerialOpen.Size = new System.Drawing.Size(181, 23);
            this.btnSerialOpen.TabIndex = 2;
            this.btnSerialOpen.Text = "シリアルポートの選択";
            this.btnSerialOpen.UseVisualStyleBackColor = true;
            this.btnSerialOpen.Click += new System.EventHandler(this.btnSerialOpen_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(6, 209);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(75, 23);
            this.btnClean.TabIndex = 4;
            this.btnClean.Text = "文字消去";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 249);
            this.Controls.Add(this.gbxTextSend);
            this.Name = "MainForm";
            this.Text = "7x5ドット文字を連続送信します";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbxTextSend.ResumeLayout(false);
            this.gbxTextSend.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbrSpeed)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbxMessage;
        private System.Windows.Forms.Label lblSendText;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox gbxTextSend;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.Button btnSerialOpen;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TrackBar tbrSpeed;
        private System.Windows.Forms.Label lblSpeedFast;
        private System.Windows.Forms.Label lblSpeedSlow;
    }
}

