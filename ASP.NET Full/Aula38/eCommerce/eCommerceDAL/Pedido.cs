using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace eCommerceDAL
{
    public partial class Pedido : EntityObject
    {
        public string Cliente
        {
            get
            {
                return this.Usuario.Nome;
            }
        }

        public decimal ValorTotal
        {
            get
            {
                using (eCommerceEntities ctx = new eCommerceEntities())
                {
                    return (ctx.ItensPedido.
                        Where(x => x.IdPedido == this.IdPedido).
                        Sum(x => x.Quantidade * x.PrecoUnitario));
                }
            }
        }
    }
}