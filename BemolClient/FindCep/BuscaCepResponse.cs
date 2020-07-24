using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindCep
{
    /// <summary>
    /// Classe de Retorno da API VIACEP.
    /// </summary>
    /// 
    public sealed class BuscaCepResponse
    {
        /// <summary>
        /// Seta ou retorna o CEP
        /// </summary>
        /// <value>
        /// O CEP.
        /// </value>
        [JsonProperty("cep")]
        public string Cep { get; set; }

        /// <summary>
        /// Seta ou retorna o logradouro.
        /// </summary>
        /// <value>
        /// O logradouro.
        /// </value>
        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        /// <summary>
        /// Seta ou retorna o complemento.
        /// </summary>
        /// <value>
        /// O complemento.
        /// </value>
        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        /// <summary>
        /// Seta ou retorna p bairro.
        /// </summary>
        /// <value>
        /// O bairro.
        /// </value>
        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        /// <summary>
        /// Seta ou retorna a cidade
        /// </summary>
        /// <value>
        /// A cidade.
        /// </value>
        [JsonProperty("localidade")]
        public string Cidade { get; set; }

        /// <summary>
        /// Seta ou retorna a UF
        /// </summary>
        /// <value>
        /// Unidade Federativa.
        /// </value>
        [JsonProperty("uf")]
        public string Uf { get; set; }

        /// <summary>
        /// Seta ou retorna a unidade.
        /// </summary>
        /// <value>
        /// The unit.
        /// </value>
        [JsonProperty("unidade")]
        public string Unidade { get; set; }

        /// <summary>
        /// Seta ou retorna o código do IBGE.
        /// </summary>
        /// <value>
        /// Código do IBGE.
        /// </value>
        [JsonProperty("ibge")]
        public int Ibge { get; set; }

        /// <summary>
        /// Seta ou retorna o código Gia.
        /// </summary>
        /// <value>
        /// O Código Gia.
        /// </value>
        [JsonProperty("gia")]
        public int? Gia { get; set; }
    }
}
