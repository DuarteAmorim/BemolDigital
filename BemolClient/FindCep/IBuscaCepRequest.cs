using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindCep
{
    /// <summary>
    /// Interface IBuscaCepRequest
    /// </summary>
    public interface IBuscaCepRequest
    {
        /// <summary>
        /// Pesquisa o Cep informado.
        /// </summary>
        /// <param name="cep">O código do CEP informado.</param>
        /// <returns></returns>
        BuscaCepResponse Pesquisar(string cep);



        /// <summary>
        /// Pesquisa Assíncrona.
        /// </summary>
        /// <param name="cep">O CEP.</param>
        /// <param name="cancellationToken">O token de cancelamento.</param>
        /// <returns></returns>
        Task<BuscaCepResponse> PesquisarAsync(string cep, CancellationToken cancellationToken);


    }
}
