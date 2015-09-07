using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Objects.DataClasses;

namespace eCommerceDAL
{
    public partial class ItemPedido : EntityObject
    {
        public string NomeProduto
        {
            get
            {
                return this.Produto.Nome;
            }
        }

        public decimal Subtotal
        {
            get
            {
                return this.PrecoUnitario * this.Quantidade;
            }
        }
    }
}