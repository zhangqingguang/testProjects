using QRCoder;
using QRCoderTest.App_Start;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QRCoderTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode("https://devserver01:8009/website/index?v=002829#xingc", QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            return View();
        }
        public ActionResult QrCode(string code)
        {
            string text = "https://devserver01:8009/website/index?v="+ code + "#xingc";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(2,Color.Black,Color.White,false);

            return File(ImageToByte2(qrCodeImage), "image/png", code+".png");
        }
        public static byte[] ImageToByte2(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// 将文本转换成图片
        /// </summary>
        /// <returns></returns>
        public ActionResult TextToImage()
        {
            var bytes = new CreateImgText("我是一个图片哈...", Color.Black, FontStyle.Regular).CreateTextByte();

            return File(bytes, "image/png", Guid.NewGuid().ToString() + ".png");
        }

        public ActionResult ShowTextImage()
        {
            return View();
        }



    }
}