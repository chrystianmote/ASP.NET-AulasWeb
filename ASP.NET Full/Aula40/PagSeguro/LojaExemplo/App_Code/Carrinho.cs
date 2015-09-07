using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

/// <summary>
/// Summary description for Carrinho
/// </summary>
public class Carrinho {

    private Dictionary<int, int> ListaDeItens { get; set; }

    public static Carrinho Instancia {
        get {
            if (HttpContext.Current.Session["carrinho"] == null) {
                HttpContext.Current.Session["carrinho"] = new Carrinho();
            }
            return (Carrinho)HttpContext.Current.Session["carrinho"];
        }
    }

    private Carrinho() {
        this.ListaDeItens = new Dictionary<int,int>();
    }

    public void Adicionar(int id, int quantidade) {
        if (this.ListaDeItens.ContainsKey(id)) {
            this.ListaDeItens[id] += quantidade;
        } else {
            this.ListaDeItens.Add(id, quantidade);
        }
    }

    public int QuantidadeTotal {
        get {
            int total = 0;
            foreach (int id in this.ListaDeItens.Keys) {
                total += this.ListaDeItens[id];
            }
            return total;
        }
    }

    public bool TemItens {
        get{
            return this.ListaDeItens.Count > 0;
        }
    }

    public int[] CodigosDosItens {
        get {
            return this.ListaDeItens.Keys.ToArray();
        }
    }

    public int ObterQuantidadeDoItem(int id) {
        return this.ListaDeItens[id];
    }

    public void Limpar() {
        this.ListaDeItens.Clear();
    }
}
