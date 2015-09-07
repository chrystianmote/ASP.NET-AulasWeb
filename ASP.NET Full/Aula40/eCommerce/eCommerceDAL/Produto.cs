using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace eCommerceDAL
{
    public partial class Produto : EntityObject
    {
        public string NomeCategoria
        {
            get
            {
                return this.Categoria.Descricao;
            }
        }
    }
}
