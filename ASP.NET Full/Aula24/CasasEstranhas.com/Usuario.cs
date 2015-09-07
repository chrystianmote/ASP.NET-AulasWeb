using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Text;

namespace CasasEstranhas.com
{
    public class Usuario
    {
        public int IdUsuario;
        public string Nome;
        public string Login;
        public string Senha;
        public bool Admin;

        public static bool Inserir(Usuario usuario)
        {
            SqlConnection conn = new SqlConnection(
                WebConfigurationManager.ConnectionStrings[
                "CasasEstranhasConnectionString"].ConnectionString);

            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO Usuario ");
            sql.Append("(Nome, Login, Senha, Admin) ");
            sql.Append("VALUES ");
            sql.Append("(@Nome, @Login, @Senha, @Admin)");

            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
            cmd.Parameters.AddWithValue("@Login", usuario.Login);
            cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
            cmd.Parameters.AddWithValue("@Admin", usuario.Admin);

            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Usuario Validar(string login, string senha)
        {
            SqlConnection conn = new SqlConnection(
                WebConfigurationManager.ConnectionStrings[
                "CasasEstranhasConnectionString"].ConnectionString);

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM Usuario ");
            sql.Append("WHERE ");
            sql.Append("Login = @Login AND Senha = @Senha");

            SqlCommand cmd = new SqlCommand(sql.ToString(), conn);
            cmd.Parameters.AddWithValue("@Login", login);
            cmd.Parameters.AddWithValue("@Senha", senha);

            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                Usuario usuario = new Usuario();
                usuario.IdUsuario = Convert.ToInt32(rdr["IdUsuario"]);
                usuario.Nome = rdr["Nome"].ToString();
                usuario.Login = rdr["Login"].ToString();
                usuario.Senha = rdr["Senha"].ToString();
                usuario.Admin = Convert.ToBoolean(rdr["Admin"]);
                return usuario;
            }
            else
            {
                return null;
            }
        }
    }
}