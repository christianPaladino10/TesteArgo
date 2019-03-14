using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TesteArgo.Models
{
    public class Filme
    {
        /// <summary>
        /// Title
        /// </summary>
		[JsonProperty("Title")]
        public string Titulo { get; set; }
		/// <summary>
		/// Year
		/// </summary>
		[JsonProperty("Year")]
		public string Ano { get; set; }
		/// <summary>
		/// imdbID
		/// </summary>
		[JsonProperty("imdbID")]
		public string imdbID { get; set; }
		/// <summary>
		/// Poster
		/// </summary>
		[JsonProperty("Poster")]
		public string Poster { get; set; }
		/// <summary>
		/// Type
		/// </summary>
		[JsonProperty("Type")]
		public string Tipo { get; set; }

	}

	public class Busca
	{
		public List<Filme> Search { get; set; }
		public int totalResults { get; set; }
		public bool Response { get; set; }
	}
}
