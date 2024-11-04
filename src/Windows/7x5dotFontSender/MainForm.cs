using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7x5dotFontSender
{
    public partial class MainForm : Form
    {
        private string SerialPortName = "";
        private bool SendStop = false;
        private int SendLineNumber = 0;   //送信する行番号
        private int[] Speeds = { 18, 15, 14, 13, 12, 11, 10, 8, 6, 4, 2 };
        private int SpeedCnt = 5;

        public MainForm()
        {
            InitializeComponent();
            //センターに表示
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tbrSpeed.Value = 5;
            this.SpeedCnt = this.Speeds[tbrSpeed.Value];
        }

        private void btnSerialOpen_Click(object sender, EventArgs e)
        {
            ComPortForm form = new ComPortForm();

            form.StartPosition = FormStartPosition.CenterParent;

            //オーナーウィンドウにthisを指定する
            form.ShowDialog(this);

            //シリアル接続します
            this.SerialPortName = form.SerialPortName;

            //フォームが必要なくなったところで、Disposeを呼び出す
            form.Dispose();

            lblConnect.ForeColor = Color.Black;
            lblConnect.Text = "接続ポート: " + this.SerialPortName;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            tbxMessage.Clear();
            this.SendLineNumber = 0;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (this.SerialPortName == "")
            {
                lblConnect.ForeColor = Color.Red;
                lblConnect.Text = "接続ポート: 選択されていません";
                return;
            }

            if (this.tbxMessage.Text == "")
            {
                return;
            }

            string text = tbxMessage.Lines[this.SendLineNumber];
            this.SendLineNumber++;
            if (this.SendLineNumber >= tbxMessage.Lines.Length)
            {
                this.SendLineNumber = 0;
            }

            //改行のみの行だったら次の行を取得する
            while (text == "")
            {
                text = tbxMessage.Lines[this.SendLineNumber];
                this.SendLineNumber++;

                if (this.SendLineNumber >= tbxMessage.Lines.Length)
                {
                    this.SendLineNumber = 0;
                }
            }

            btnSerialOpen.Enabled = false;
            btnSend.Enabled = false;
            this.SendStop = false;
            btnStop.Enabled = true;

            try
            {
                SerialPort serial = new SerialPort(this.SerialPortName, 115200);

                serial.ReadTimeout = 1000;      //タイムアウトms
                serial.WriteTimeout = 1000;     //タイムアウトms
                serial.Open();

                FontConvert convert = new FontConvert();
                byte[] data = convert.SetString(text);

                //dataの値を7バイトずつ送ります
                string led = "0000000";
                for (int i = 0; i < data.Length; i++)
                {
                    led = led.Substring(1, 6);
                    led += convert.MicrobitLED[data[i]];
                    serial.Write(led);

                    for (int j = 0; j < this.SpeedCnt; j++)
                    {
                        Thread.Sleep(10);
                        Application.DoEvents();
                    }

                    if (this.SendStop) { break; }
                }
                led = "0000000";
                serial.Write(led);

                serial.Close();
                serial.Dispose();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }

            btnSerialOpen.Enabled = true;
            btnSend.Enabled = true;
            btnStop.Enabled = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.SendStop = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            this.SendStop = true;
        }

        private void tbrSpeed_Scroll(object sender, EventArgs e)
        {
            this.SpeedCnt = this.Speeds[tbrSpeed.Value];
            Debug.WriteLine(this.SpeedCnt);
        }

        private void lblConnect_Click(object sender, EventArgs e)
        {

        }
    }
}
