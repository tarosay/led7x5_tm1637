using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7x5dotFontSender
{
    public partial class ComPortForm : Form
    {
        public string SerialPortName = "";
        private List<string> Coms = new List<string>();

        public ComPortForm()
        {
            InitializeComponent();
        }

        private void ComPortForm_Load(object sender, EventArgs e)
        {
            //リストボックスに込むポートを設定します
            lstComPorts.Items.Clear();
            Coms.Clear();

            string[] ports = GetDeviceNames();
            if (ports != null)
            {
                int mk, uk;
                string comn = "COM1";
                string name = "";
                foreach (string port in ports)
                {
                    try
                    {
                        mk = port.LastIndexOf("(");
                        uk = port.LastIndexOf(")");
                        comn = port.Substring(mk + 1, uk - 1 - mk);
                        name = port.Substring(0, mk);
                    }
                    catch
                    {
                        comn = "COM1";
                    }
                    Coms.Add(comn);
                    lstComPorts.Items.Add("(" + comn + ")" + name);
                }

                lstComPorts.SelectedIndex = 0;
            }

            if (Coms.Count == 0)
            {
                btnOK.Enabled = false;
            }
        }

        /// <summary>
        /// COM Portを取得します
        /// </summary>
        /// <returns></returns>
        private string[] GetDeviceNames()
        {
            var deviceNameList = new System.Collections.ArrayList();
            var check = new System.Text.RegularExpressions.Regex("(COM[1-9][0-9]?[0-9]?)");

            ManagementClass mcPnPEntity = new ManagementClass("Win32_PnPEntity");
            ManagementObjectCollection manageObjCol = mcPnPEntity.GetInstances();

            //全てのPnPデバイスを探索しシリアル通信が行われるデバイスを随時追加する
            foreach (ManagementObject manageObj in manageObjCol)
            {
                //Nameプロパティを取得
                var namePropertyValue = manageObj.GetPropertyValue("Name");
                if (namePropertyValue == null)
                {
                    continue;
                }

                //Nameプロパティ文字列の一部が"(COM1)～(COM999)"と一致するときリストに追加"
                string name = namePropertyValue.ToString();
                if (check.IsMatch(name))
                {
                    deviceNameList.Add(name);
                }
            }

            //戻り値作成
            if (deviceNameList.Count > 0)
            {
                string[] deviceNames = new string[deviceNameList.Count];
                int index = 0;
                foreach (var name in deviceNameList)
                {
                    deviceNames[index++] = name.ToString();
                }
                return deviceNames;
            }
            else
            {
                return null;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (lstComPorts.SelectedIndex < 0 || lstComPorts.SelectedIndex >= Coms.Count)
            {
                return;
            }

            this.SerialPortName = this.Coms[lstComPorts.SelectedIndex];
            this.Close();
        }
    }
}
