using Bemol01App.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bemol01App.Entities
{
    public class Clientes : IEntityBase<Clientes>
    {
        public BemolContext _bemolContext { get; set; }

        public Clientes(BemolContext bemolContext)
        {
            _bemolContext = bemolContext;
        }

        //public int Id { get; set; }
        [Key]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        //public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        //public string Unidade { get; set; }
        public string Ibge { get; set; }

        //public string Gia { get; set; }

        public Clientes Alterar(Clientes cliente)
        {
            var retorno = Consultar(cliente.Cpf);

            retorno.Nome = cliente.Nome;
            retorno.Cep = cliente.Cep;
            retorno.Logradouro = cliente.Logradouro;
            retorno.Bairro = cliente.Bairro;
            retorno.Cidade = cliente.Cidade;
            retorno.Uf = cliente.Uf;
            retorno.Ibge = cliente.Ibge;

            _bemolContext.Clientes.Update(retorno);
            _bemolContext.SaveChanges();
            return cliente;
        }

        public Clientes Consultar(string cpf)
        {
            return _bemolContext.Clientes.Where(c => c.Cpf == cpf).FirstOrDefault();
        }

        public int Incluir(Clientes obj)
        {
            var retorno = Consultar(obj.Cpf);

            if (retorno != null)
            {
                retorno = Alterar(obj);
                return 2;
            }
            _bemolContext.Clientes.Add(obj);
            _bemolContext.SaveChanges();
            return 1;
        }

        public int Remover(string cpf)
        {
            var retorno = Consultar(cpf);

            if (retorno == null)
            {
                return 0;
            }
            _bemolContext.Clientes.Remove(retorno);

            return 1;
        }
    }
}
