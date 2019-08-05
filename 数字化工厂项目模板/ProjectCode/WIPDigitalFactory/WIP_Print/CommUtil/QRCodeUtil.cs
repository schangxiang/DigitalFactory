using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Util;

namespace WIP_Print
{
    public class QRCodeUtil
    {
        /// <summary>  
        /// 生成二维码图片  
        /// </summary>  
        /// <param name="codeNumber">要生成二维码的字符串</param>       
        /// <param name="size">大小尺寸(文件大小)</param>  
        /// <returns>二维码图片</returns>  
        public static Bitmap CreateImgCode(string codeNumber, int size)
        {
            //创建二维码生成类  
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            //设置编码模式  
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            //设置编码测量度  
            qrCodeEncoder.QRCodeScale = size;
            //设置编码版本  
            qrCodeEncoder.QRCodeVersion = 0;
            //设置编码错误纠正  
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            //生成二维码图片  
            Bitmap image = null;
            if (QRCodeUtility.IsUniCode(codeNumber))
            {
                image = qrCodeEncoder.Encode(codeNumber, System.Text.Encoding.UTF8);
            }
            else
            {
                image = qrCodeEncoder.Encode(codeNumber, System.Text.Encoding.ASCII);
            }
            return image;
        }



        /// <summary>  
        /// 生成二维码  
        /// </summary>  
        /// <param name="content">内容</param>
        /// <param name="moduleSize">二维码的大小</param>
        /// <returns>输出流</returns>  
        public static MemoryStream GetQRCode(string content, int moduleSize = 9)
        {
            //ErrorCorrectionLevel 误差校正水平
            //QuietZoneModules     空白区域

            var encoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = encoder.Encode(content);
            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(moduleSize, QuietZoneModules.Two), Brushes.Black, Brushes.White);

            MemoryStream memoryStream = new MemoryStream();
            render.WriteToStream(qrCode.Matrix, ImageFormat.Jpeg, memoryStream);

            return memoryStream;

            //生成图片的代码
            //DrawingSize dSize = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            //Bitmap map = new Bitmap(dSize.CodeWidth, dSize.CodeWidth);
            //Graphics g = Graphics.FromImage(map);
            //render.Draw(g, qrCode.Matrix);
            //map.Save(fileName, ImageFormat.Jpeg);//fileName为存放的图片路径
        }

        /// <summary>
        /// 生成带Logo二维码  
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="iconPath">logo路径</param>
        /// <param name="moduleSize">二维码的大小</param>
        /// <returns>输出流</returns>
        public static MemoryStream GetQRCode(string content, string iconPath, int moduleSize = 9)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.M);
            QrCode qrCode = qrEncoder.Encode(content);

            GraphicsRenderer render = new GraphicsRenderer(new FixedModuleSize(moduleSize, QuietZoneModules.Two), Brushes.Black, Brushes.White);

            DrawingSize dSize = render.SizeCalculator.GetSize(qrCode.Matrix.Width);
            Bitmap map = new Bitmap(dSize.CodeWidth, dSize.CodeWidth);
            Graphics g = Graphics.FromImage(map);
            render.Draw(g, qrCode.Matrix);

            //追加Logo图片 ,注意控制Logo图片大小和二维码大小的比例
            //PS:追加的图片过大超过二维码的容错率会导致信息丢失,无法被识别
            System.Drawing.Image img = System.Drawing.Image.FromFile(iconPath);

            Point imgPoint = new Point((map.Width - img.Width) / 2, (map.Height - img.Height) / 2);
            g.DrawImage(img, imgPoint.X, imgPoint.Y, img.Width, img.Height);

            MemoryStream memoryStream = new MemoryStream();
            map.Save(memoryStream, ImageFormat.Jpeg);

            return memoryStream;

            //生成图片的代码： map.Save(fileName, ImageFormat.Jpeg);//fileName为存放的图片路径
        }

        /// <summary>  
        /// 保存图片  
        /// </summary>
        /// <param name="img">图片</param>  
        public static bool SaveImg(System.Drawing.Image img, string savePathAndName, Size size, ImageFormat imgSet)
        {
            //文件路径  
            string fullPath = Path.GetDirectoryName(savePathAndName);
            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            if (File.Exists(savePathAndName))
            {
                File.Delete(savePathAndName);
                //LogHelper.Info(typeof(QRCode), "【文件重复】覆盖 - "+ savePathAndName.Substring(savePathAndName.Length-13, 13));
            }

            Bitmap newImg = new Bitmap(img, size.Width, size.Height);//图片保存的大小尺寸  
            newImg.SetResolution(150,150);
            newImg.Save(savePathAndName, imgSet);
            newImg.Dispose();
            GC.Collect();
            return true;
        }

        private Font _font = new Font("微软雅黑",15f);
        /// <summary>  
        /// 调用此函数后使此两种图片合并，类似相册，有个  
        /// 背景图，中间贴自己的目标图片  
        /// </summary>  
        /// <param name="sourceImg">粘贴的源图片</param>  
        /// <param name="destImg">粘贴的目标图片</param>  
        public static Metafile CombinImage(Size imgSize, string destImg, string fileName,string content="")
        {
            Bitmap bmp = new Bitmap(imgSize.Width, imgSize.Height);
            Graphics gs = Graphics.FromImage(bmp);
            Metafile mf = new Metafile(fileName, gs.GetHdc());
            Graphics g = Graphics.FromImage(mf);

            //g.SmoothingMode = SmoothingMode.HighQuality;
            //g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            //g.CompositingQuality = CompositingQuality.HighQuality;

            //绘制边框
            g.DrawRectangle(new Pen(System.Drawing.Color.FromArgb(54,170,109),12),0,0, imgSize.Width, imgSize.Height);

            //绘制二维码
            System.Drawing.Image img = System.Drawing.Image.FromFile(destImg);
            g.DrawImage(img, Convert.ToInt32(imgSize.Width * 400 / 612), (imgSize.Height - img.Height) / 2, img.Width, img.Height);
            img.Dispose();

            //绘制logo
            //Metafile logo= new Metafile(Application.StartupPath + "\\BackImage\\logo"+ imgSize.Width + imgSize.Height + ".wmf");
            Metafile logo = new Metafile(System.Windows.Forms.Application.StartupPath + "\\BackImage\\logo1.wmf");
            g.DrawImageUnscaled(logo, Convert.ToInt32(imgSize.Width * 32 / 612), Convert.ToInt32(imgSize.Height * 35 / 236));
        
            //绘制内容
            g.DrawString(content, new Font("微软雅黑", 53f), new SolidBrush(System.Drawing.Color.Black), new Point(Convert.ToInt32(imgSize.Width * 62 / 612), Convert.ToInt32(imgSize.Height * 128 / 236)));
            g.Save();
            g.Dispose();
            mf.Dispose();
            GC.Collect();
            return null;
        }

        /// <summary>  
        /// 调用此函数后使此两种图片合并，类似相册，有个  
        /// 背景图，中间贴自己的目标图片  
        /// </summary>  
        /// <param name="sourceImg">粘贴的源图片</param>  
        /// <param name="destImg">粘贴的目标图片</param>  
        public static System.Drawing.Image CombinImage(System.Drawing.Image imgBack,System.Drawing.Image destImg)
        {

            //System.Drawing.Image img = destImg;        //照片图片    
            if (destImg.Height != 780 || destImg.Width != 780)
            {
                destImg = KiResizeImage(destImg, 780, 780, 0);
            }
            Graphics g = Graphics.FromImage(imgBack);

            g.DrawImage(imgBack, 0, 0, imgBack.Width, imgBack.Height);      //g.DrawImage(imgBack, 0, 0, 相框宽, 相框高);   

            //g.FillRectangle(System.Drawing.Brushes.White, imgBack.Width / 2 - img.Width / 2 - 1, imgBack.Width / 2 - img.Width / 2 - 1,1,1);//相片四周刷一层黑色边框  

            //g.DrawImage(img, 照片与相框的左边距, 照片与相框的上边距, 照片宽, 照片高);  

            g.DrawImage(imgBack, imgBack.Width / 2 - destImg.Width / 2, imgBack.Width / 2 - destImg.Width / 2, destImg.Width, destImg.Height);
            GC.Collect();
            return imgBack;
        }

        /// <summary>  
        /// Resize图片  
        /// </summary>  
        /// <param name="bmp">原始Bitmap</param>  
        /// <param name="newW">新的宽度</param>  
        /// <param name="newH">新的高度</param>  
        /// <param name="Mode">保留着，暂时未用</param>  
        /// <returns>处理以后的图片</returns>  
        public static System.Drawing.Image KiResizeImage(System.Drawing.Image bmp, int newW, int newH, int Mode)
        {
            try
            {
                System.Drawing.Image b = new Bitmap(newW, newH);
                Graphics g = Graphics.FromImage(b);

                // 插值算法的质量  
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;

                g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                g.Dispose();

                return b;
            }
            catch
            {
                return null;
            }
        }
    }
}
