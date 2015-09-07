using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;

namespace UsandoACT
{
    /// <summary>
    /// Summary description for AjaxWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class AjaxWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        [ScriptMethod]
        public string[] GetCompletionList(string prefixText, 
            int count)
        {
            return new string[] {
                "Albânia",
                "Argentina",
                "Bangladesh",
                "Barbados",
                "Bélgica",
                "Brasil",
                "Bolívia",
                "Bulgária",                
                "Caribe",
                "Colômbia",                
                "Cuba",
                "Dinamarca"
            };
        }
    }
}
