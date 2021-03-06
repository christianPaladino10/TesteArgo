﻿using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TesteArgo.Models;

namespace TesteArgo
{
	public class teste3
	{
		///www.omdbapi.com/
		const string ApiKey = "18693fd6";

		/// <summary>
		/// By Search
		/// www.omdbapi.com/?s=titulo&apikey=18693fd6
		/// </summary>
		/// <param name="filtro"></param>
		/// <returns></returns>
		public List<Filme> ListarFilmes(string filtro)
		{
			string baseUri = $"http://www.omdbapi.com/?s={filtro}&apikey=18693fd6";

			var request = WebRequest.Create(baseUri);
			request.Method = "GET";
			request.ContentType = "application/json";

			Busca busca = null;

			try
			{
				using (var response = request.GetResponse())
				using (var stream = response.GetResponseStream())
				using (var reader = new StreamReader(stream, Encoding.UTF8))
				{
					string result = reader.ReadToEnd();

					busca = JsonConvert.DeserializeObject<Busca>(result);

					reader.Close();
					response.Close();
				}
			}
			catch (WebException e)
			{
				throw e;
			}

			return busca.Search;
		}

		/// <summary>
		/// By ID or Title
		/// www.omdbapi.com/?i=tt0372784&apikey=18693fd6
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Filme ListarPorId(string id)
		{
			string baseUri = $"http://www.omdbapi.com/?i={id}&apikey=18693fd6";

			var request = WebRequest.Create(baseUri);
			request.Method = "GET";
			request.ContentType = "application/json";

			Filme filme = null;
			try
			{
				using (var response = request.GetResponse())
				using (var stream = response.GetResponseStream())
				using (var reader = new StreamReader(stream, Encoding.UTF8))
				{
					string result = reader.ReadToEnd();

					filme = JsonConvert.DeserializeObject<Filme>(result);

					reader.Close();
					response.Close();
				}
			}
			catch (WebException e)
			{
				throw e;
			}

			return filme;
		}
	}
}
