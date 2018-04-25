using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Web;

namespace QRCoderTest.App_Start
{
    public class CreateImgText
    {
        private string _Text = null;
        private Color _TextColor = Color.Empty;
        private FontStyle _TextStyle = FontStyle.Bold;
        private int _Width;
        private int _Height;

        #region 
        /**//// <summary>
            /// 要显示的文本
            /// </summary>
        public string Text
        {
            get
            {
                if (_Text == null || _Text.Trim().Length <= 0)
                {
                    return "图片加载中";
                }
                return _Text;
            }
            set { _Text = value; }
        }
        /**//// <summary>
            /// 文本颜色
            /// </summary>
        public Color TextColor
        {
            get
            {
                if (_TextColor == Color.Empty)
                {
                    return Color.Black;
                }
                return _TextColor;
            }
            set { _TextColor = value; }
        }
        /**//// <summary>
            /// 文本样式 加粗 倾斜 普通等
            /// </summary>
        public FontStyle TextStyle
        {
            get { return _TextStyle; }
            set { _TextStyle = value; }
        }
        /**//// <summary>
            /// 图片的宽
            /// </summary>
        public int Width
        {
            get { return _Width; }
            //set { _Width = value; }
        }
        /**//// <summary>
            /// 图片的高
            /// </summary>
        public int Height
        {
            get { return _Height; }
            //set { _Height = value; }
        }
        #endregion

        #region 
        public CreateImgText()
        {

        }
        public CreateImgText(string strText)
        {
            _Text = strText;
        }

        public CreateImgText(string strText, Color TextColor)
        {
            _Text = strText;
            _TextColor = TextColor;
        }
        public CreateImgText(string strText, Color TextColor, FontStyle TextStyle)
        {
            _Text = strText;
            _TextColor = TextColor;
            _TextStyle = TextStyle;
        }
        #endregion

        /**//// <summary>
            /// 创建输出的文字流
            /// </summary>
            /// <returns></returns>
        public byte[] CreateTextByte()
        {
            Font font = new Font("黑体", 20, TextStyle);
            Brush brush = new SolidBrush(TextColor);
            // 计算文字的宽和高
            Size sizeText = MeasureText(Text, font);
            _Width = sizeText.Width;
            _Height = sizeText.Height;
            // 创建一个位图
            Bitmap bmp = new Bitmap(sizeText.Width, sizeText.Height);

            // 设置画布
            Graphics grph = Graphics.FromImage(bmp);
            // 指定消除锯齿 文字
            grph.TextRenderingHint = TextRenderingHint.AntiAlias;
            // 清除画布
            grph.Clear(Color.White);
            // 在画布上画图案 内容,字体,画刷,坐标
            grph.DrawString(Text, font, brush, 0, 0);
            // 新建一个内存流
            MemoryStream stream = new MemoryStream();
            // 将图片保存在内存流中
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

            byte[] byteBuf = new byte[stream.Length];
            byteBuf = stream.ToArray();

            //资源回收 
            bmp.Dispose();
            grph.Dispose();
            stream.Close();

            return byteBuf;
        }
        /// <summary>
        /// 根据Print文本计算画布的大小
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        private Size MeasureText(string text, Font font)
        {
            return new Size(100,100);
        }
    }
}