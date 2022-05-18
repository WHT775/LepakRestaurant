using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;

namespace LepakRestaurant
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QRCodeEncoder encoder = new QRCodeEncoder();

            Bitmap img = encoder.Encode("http://localhost:44331/Boundary/CustomerLogin/");

            img.Save("C:\\Users\\Admin\\Desktop\\Table1.jpg", ImageFormat.Jpeg);
            Table1.ImageUrl = "Table1.jpg";

            img.Save("C:\\Users\\Admin\\Desktop\\Table2.jpg", ImageFormat.Jpeg);
            Table2.ImageUrl = "Table2.jpg";

            img.Save("C:\\Users\\Admin\\Desktop\\Table3.jpg", ImageFormat.Jpeg);
            Table3.ImageUrl = "Table3.jpg";

            img.Save("C:\\Users\\Admin\\Desktop\\Table4.jpg", ImageFormat.Jpeg);
            Table4.ImageUrl = "Table4.jpg";

            img.Save("C:\\Users\\Admin\\Desktop\\Table5.jpg", ImageFormat.Jpeg);
            Table5.ImageUrl = "Table5.jpg";

            img.Save("C:\\Users\\Admin\\Desktop\\Table6.jpg", ImageFormat.Jpeg);
            Table6.ImageUrl = "Table6.jpg";
        }
    }
}