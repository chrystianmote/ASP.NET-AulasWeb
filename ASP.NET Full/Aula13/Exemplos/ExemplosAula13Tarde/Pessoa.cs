using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExemplosAula13Tarde
{
    [Serializable]
    public class Pessoa
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNasc { get; set; }
        public bool EhCasado { get; set; }

        public Pessoa(int id, string nome, string email,
            DateTime dataNasc, bool ehCasado)
        {
            ID = id;
            Nome = nome;
            Email = email;
            DataNasc = dataNasc;
            EhCasado = ehCasado;
        }
    }
}
