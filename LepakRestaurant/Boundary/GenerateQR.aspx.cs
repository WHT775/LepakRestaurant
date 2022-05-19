using LepakRestaurant.Controller;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LepakRestaurant.Boundary
{
    public partial class GenerateQR : System.Web.UI.Page
    {
        TableNumController tnc = new TableNumController();
        protected void Page_Load(object sender, EventArgs e)
        {

            //QREncoder encoder = new QREncoder();
            //string url = "http://localhost:44331/Boundary/CustomerLogin/?tableid=";
            ////Bitmap img = encoder.Encode("http://localhost:44331/Boundary/CustomerLogin/");
            //byte[] ByteArray = Encoding.UTF8.GetBytes(Text);
            //// save image as png file
            //// create save PNG image class 
            //// and load the QR Code matrix 
            //QRSavePngImage PngImage = new(QRCodeMatrix);

            //// set the module size in pixels
            //PngImage.ModuleSize = ModuleSize;

            //// set the quiet zone in pixels
            //PngImage.QuietZone = QuietZone;

            //// save the QR Code PNG image to file name
            //// or to open file stream
            //PngImage.SaveQRCodeToPngFile(Dialog.FileName);
            ////img.Save("C:\\Users\\Admin\\Desktop\\Table1.jpg", ImageFormat.Jpeg);
            ////Table1.ImageUrl = "Table1.jpg";

            ////img.Save("C:\\Users\\Admin\\Desktop\\Table2.jpg", ImageFormat.Jpeg);
            ////Table2.ImageUrl = "Table2.jpg";

            ////img.Save("C:\\Users\\Admin\\Desktop\\Table3.jpg", ImageFormat.Jpeg);
            ////Table3.ImageUrl = "Table3.jpg";

            ////img.Save("C:\\Users\\Admin\\Desktop\\Table4.jpg", ImageFormat.Jpeg);
            ////Table4.ImageUrl = "Table4.jpg";

            ////img.Save("C:\\Users\\Admin\\Desktop\\Table5.jpg", ImageFormat.Jpeg);
            ////Table5.ImageUrl = "Table5.jpg";

            ////img.Save("C:\\Users\\Admin\\Desktop\\Table6.jpg", ImageFormat.Jpeg);
            ////Table6.ImageUrl = "Table6.jpg";
            //QRSaveBitmapImage Image = new(QRCodeMatrix);

            //// set the module size in pixels
            //Image.ModuleSize = ModuleSize;

            //// set the quiet zone in pixels
            //Image.QuietZone = QuietZone;

            //// save the QR Code image to file name
            //// or to open file stream
            //Image.SaveQRCodeToBitmapFile(Dialog.FileName, ImageFormat);
        }

        protected void btnGenerateQrCode_Click(object sender, EventArgs e)
        {
            //if(!tnc.CheckIfTableNumExists(txtTableId.Text))
            //{
            //    QRCodeEncoder encoder = new QRCodeEncoder();
            //    encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;
            //    encoder.QRCodeScale = 10;
            //    Bitmap img = encoder.Encode("http://localhost:44331/Boundary/CustomerLogin/?tableid=" + txtTableId.Text);
            //    img.Save(Server.MapPath("images/tableid" + txtTableId.Text), ImageFormat.Jpeg);
            //}
            //else
            //{
            //    //Display the existing qr code and unique code
            //}

        }
    }
}