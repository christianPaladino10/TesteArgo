using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TesteArgo.Models;
using System.Configuration;

namespace TesteArgo
{
	/// <summary>
	/// Nessa classe deve ser feito o acesso a banco de dados SQL SERVER
	/// Dados de conexao do banco de dados
	/// host: den1.mssql6.gear.host
	/// base: testecore
	/// user:testecore
	/// senha : Dz2iI~!U1Edq
	/// 
	/// Tabela Destino
	/// 
	/// Colunas:
	/// DestinoId inteiro 
	/// Nome texto nulavel
	/// Dia data nulavel
	/// 
	/// </summary>
	public class teste4
    {
		private SqlConnection conn;

		private void ConectarSql()
		{
			Conexao con = new Conexao();
			conn = con.ConectarSql(ref conn);
		}

		public List<Destino> ListarDestino()
        {
			List<Destino> listaDestinos = new List<Destino>();

			ConectarSql();
			string query = "SELECT * FROM Destino";

			SqlCommand cmd = new SqlCommand(query, conn);

			SqlDataReader reader = cmd.ExecuteReader();

			while (reader.Read())
			{
				Destino destino = new Destino()
				{
					Nome = Convert.ToString(reader["Nome"]),
					Dia = Convert.ToDateTime(reader["Dia"])
				};

				listaDestinos.Add(destino);
			}

			return listaDestinos;
		}

        public Destino buscarPorId(int id)
        {
			Destino destino = new Destino();
			ConectarSql();
			string query = "SELECT * FROM Destino WHERE DestinoId = @id";

			SqlCommand cmd = new SqlCommand(query, conn);
			cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

			try
			{
				SqlDataReader reader = cmd.ExecuteReader();
				if (reader.HasRows == false)
				{
					throw new Exception("Destino não encontrado");
				}

				reader.Read();
				destino.Nome = Convert.ToString(reader["Nome"]);
				destino.Dia = Convert.ToDateTime(reader["Dia"]);

				return destino;

			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (conn.State == ConnectionState.Open) conn.Close();
				if (conn != null) conn.Dispose();
			}
		}
    }

	public class Conexao
	{
		public SqlConnection ConectarSql(ref SqlConnection con)
		{
			if (con != null)
			{
				con.Dispose();
			}
			con = new SqlConnection(ConfigurationManager.ConnectionStrings["stringConexao"].ConnectionString);
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
			try
			{
				con.Open();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return con;
		}
	}

}
