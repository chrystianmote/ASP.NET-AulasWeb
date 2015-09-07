using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ExemplosAula13Tarde
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            List<Produto> produtos = new List<Produto>();

            produtos.Add(new Produto(1, "IPhone 3GS", "O Melhor da Taconologia no seu bolso", 2499.99M, 50));
            produtos.Add(new Produto(2, "MacBook Air", "O Notebook mais fino do mundo!", 7999.90M, 150));
            produtos.Add(new Produto(3, "Sony LED TV 57'", "A maneira mais inovadora de estar na TV em 3D", 14999.90M, 20));
            produtos.Add(new Produto(4, "Core i7 Extreme Edition 3.5Ghz", "Turbine seu PC agora mesmo!", 5499.90M, 30));
            produtos.Add(new Produto(5, "Microsoft&copy; Visual Studio 2010", "O melhor software de desenvolvimento para WEB do mundo", 1999.90M, 350));

            Application["produtos"] = produtos;
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}