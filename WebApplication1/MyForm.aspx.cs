using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class MyForm : System.Web.UI.Page
    {
        protected string res = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            WebApplication1.ServiceReference1.Service1Client clt = new ServiceReference1.Service1Client();
            res = clt.GetData(3);

        }
    }
}