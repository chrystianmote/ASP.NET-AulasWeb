using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace eCommerceBackEnd
{
    public partial class CarregarImagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string file = Request.QueryString["file"];
            Bitmap bmp = new Bitmap(Server.MapPath("~/" + file));
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imagem = ms.ToArray();
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(imagem);
            //bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.End();
        }
    }
}