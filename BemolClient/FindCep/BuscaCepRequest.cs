using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindCep
{
    /// <summary>
    /// The Via CEP client class.
    /// </summary>
    public class BuscaCepRequest : IBuscaCepRequest
    {

        /// <summary>
        /// Url Base para consumir a API
        /// </summary>
        private const string UrlBase = "https://viacep.com.br";

        /// <summary>
        /// http Client
        /// </summary>
        private readonly HttpClient _httpClient;


        /// <summary>
        /// Inicializa a instância da classe <see cref="BuscaCepRequest"/>.
        /// </summary>
        public BuscaCepRequest()
        {
            _httpClient = HttpClientFactory.Create();
            _httpClient.BaseAddress = new Uri(UrlBase);
        }

        /// <summary>
        /// Inicializa a instância da classe <see cref="BuscaCepRequest"/>.
        /// </summary>
        /// <param name="httpClient">Cliente http.</param>
        public BuscaCepRequest(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Pesquisa pelo CEP específico
        /// </summary>
        /// <param name="cep">The zip code.</param>
        /// <returns></returns>
        public BuscaCepResponse Pesquisar(string cep)
        {
            return PesquisarAsync(cep, CancellationToken.None).Result; ;
        }


        /// <summary>
        /// Pesquisa assíncrona
        /// </summary>
        /// <param name="cep">O CEP.</param>
        /// <param name="cancellationToken">O Token.</param>
        /// <returns></returns>
        public async Task<BuscaCepResponse> PesquisarAsync(string cep, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"/ws/{cep}/json", cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<BuscaCepResponse>(cancellationToken).ConfigureAwait(false);
        }



    }
}
