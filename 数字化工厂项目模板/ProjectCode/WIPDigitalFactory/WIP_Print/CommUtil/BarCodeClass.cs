using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;

namespace WIP_Print
{
    class BarCodeClass
    {
        /// <summary>
        /// 条形码宽度
        /// </summary>
        public int BarCodeWidth { get; set; }
        /// <summary>
        /// 条形码高度
        /// </summary>
        public int BarCodeHeight { get; set; }


        ///<summary>
        ///生成条形码
        ///</summary>
        ///<paramname="pictureBox1"></param>
        ///<paramname="Contents"></param>
        public Image ZXCreateBarCode( string Contents)
        {
            //Regex rg = new Regex("^[0-9]{12}$");
            //if (!rg.IsMatch(Contents))
            //{
            //    MessageBox.Show("本例子采用EAN_13编码，需要输入12位数字");
            //    return;
            //}

            EncodingOptions options = null;
            BarcodeWriter writer = null;
            //if(BarCodeWidth==0 || BarCodeHeight == 0)
            //{
            //    BarCodeWidth = pictureBox1.Width;
            //    BarCodeHeight = pictureBox1.Height;
            //}
            options = new EncodingOptions
            {
                Width = 300,
                Height = 50,
               
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.CODE_128;
            writer.Options = options;


            Bitmap bitmap = writer.Write(Contents);
            return bitmap;
        }



    }
}