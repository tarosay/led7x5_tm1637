using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7x5dotFontSender
{
    /// <summary>
    /// フォントは、
    /// ユズノカ様作成の mikannnoki-font
    /// ５×７ドット文字フォント「pixelfont-5x7.ttf」を用いています
    /// https://mikannnoki-font.booth.pm/
    /// https://booth.pm/ja/items/1477300
    /// </summary>
    public class FontConvert
    {
        public string[] MicrobitLED = {
                "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j",
                "k", "l", "m", "n", "o", "p", "q", "r", "s", "t",
                "u", "v"
                };

        public FontConvert()
        {

        }

        public byte[] SetString(string text)
        {
            List<byte> dat = new List<byte>();

            FontFamily fontFamily = new FontFamily("pixelfont-5x7");
            Font font = new Font(fontFamily, 8, FontStyle.Regular, GraphicsUnit.Pixel);

            int width = 15;
            int height = 10;
            Bitmap bmp = new Bitmap(width, height);
            Graphics grp = Graphics.FromImage(bmp);
            grp.SmoothingMode = SmoothingMode.None;
            grp.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;

            SolidBrush bBlack = new SolidBrush(Color.Black);
            SolidBrush bWhite = new SolidBrush(Color.White);

            //string setText = Strings.StrConv(text, VbStrConv.Wide, 0x411);    //半角を全角に変換する
            string setText = text;
            int scanWidth = 0;
            for (int i = 0; i < setText.Length; i++)
            {
                //バックを白で塗りつぶす
                grp.FillRectangle(bWhite, 0, 0, width, height);

                // 文字列を描画する
                string strNormal = setText.Substring(i, 1);
                grp.DrawString(strNormal, font, bBlack, new PointF(1, 1));

                //DateTime dtNow = DateTime.Now;
                //string dtstr = dtNow.ToString("yyyyMMdd") + dtNow.ToString("HHmmss");
                //bmp.Save(dtstr + ".png", ImageFormat.Png);

                if (IsHankaku(strNormal))
                {
                    //(2,3)～(4,7)の範囲をスキャンする
                    scanWidth = 3;
                }
                else
                {
                    //(2,3)～(8,7)の範囲をスキャンする
                    scanWidth = 7;
                }

                for (int x = 0; x < scanWidth; x++)
                {
                    byte dot = 0;
                    for (int y = 0; y < 5; y++)
                    {
                        Color p = bmp.GetPixel(x + 2, y + 3);
                        if (p.R == 0)
                        {
                            dot += (byte)(1 << y);
                        }
                    }
                    dat.Add(dot);
                }
                dat.Add(0);
            }

            for (int i = 0; i < 5; i++)
            {
                dat.Add(0);
            }

            fontFamily.Dispose();
            font.Dispose();
            font = null;

            bWhite.Dispose();
            bWhite = null;

            bBlack.Dispose();
            bBlack = null;

            grp.Dispose();
            bmp.Dispose();
            bmp = null;

            return dat.ToArray();
        }

        private bool IsHankaku(string moji)
        {
            return moji.Length == Encoding.GetEncoding("shift_jis").GetByteCount(moji);
        }
    }
}
