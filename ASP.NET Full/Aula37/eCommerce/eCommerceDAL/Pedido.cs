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
    }
}