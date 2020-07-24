using Bemol01App.Entities;
using FindCep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bemol01App
{
    public partial class frmCadClientes : Form
    {
        public frmCadClientes()
        {
            InitializeComponent();
        }

        private void mskCep_Leave(object sender, EventArgs e)
        {
            BuscaCepRequest requestCep;
            try
            {
                requestCep = new BuscaCepRequest();

                var retorno = requestCep.Pesquisar(mskCep.Text);

                CarregarDadosDoCep(retorno);
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.ToString().Contains("400 (Bad Request)"))
                {
                    MessageBox.Show(this, "CEP inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    mskCep.Clear();
                    mskCep.Focus();

                }
            }
        }

        private void CarregarDadosDoCep(BuscaCepResponse response)
        {
            mskCep.Text = response.Cep;
            txtLogradouro.Text = response.Logradouro;
            txtBairro.Text = response.Bairro;
            txtCidade.Text = response.Cidade;
            txtUf.Text = response.Uf;
            txtIbge.Text = response.Ibge.ToString();
        }

        private void CarregarDadosDoCliente(Clientes cliente)
        {
            mskCpf.Text = cliente.Cpf;
            txtNome.Text = cliente.Nome;
            mskCep.Text = cliente.Cep;
            txtLogradouro.Text = cliente.Logradouro;
            txtBairro.Text = cliente.Bairro;
            txtCidade.Text = cliente.Cidade;
            txtUf.Text = cliente.Uf;
            txtIbge.Text = cliente.Ibge;
        }

        private Clientes CarregarDadosDoObjeto(Clientes cliente)
        {
            cliente.Cpf = mskCpf.Text;
            cliente.Nome = txtNome.Text;
            cliente.Cep = mskCep.Text;
            cliente.Logradouro = txtLogradouro.Text;
            cliente.Bairro = txtBairro.Text;
            cliente.Cidade = txtCidade.Text;
            cliente.Uf = txtUf.Text;
            cliente.Ibge = txtIbge.Text;
            return cliente;
        }
        private void LimparDadosDoCliente()
        {
            mskCpf.Clear();
            txtNome.Clear();
            mskCep.Clear();
            txtLogradouro.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtUf.Clear();
            txtIbge.Clear();

            mskCpf.Focus();
        }

        private void mskCpf_Leave(object sender, EventArgs e)
        {
            using (var contexto = new BemolContext())
            {
                var cliente = new Clientes(contexto);

                var retorno = cliente.Consultar(mskCpf.Text);
                if (retorno != null)
                {
                    CarregarDadosDoCliente(retorno);
                }
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (mskCpf.Text.Count() < 11)
            {
                MessageBox.Show(this, "CPF inválido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                mskCpf.Clear();
                mskCpf.Focus();
                return;
            }
            using (var contexto = new BemolContext())
            {
                var cliente = CarregarDadosDoObjeto(new Clientes(contexto));

                var retorno = cliente.Incluir(cliente);
                MessageBox.Show(this, string.Format("Cliente {0} com sucesso!", retorno == 1 ? "incluído" : "alterado"), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LimparDadosDoCliente();
        }

        private void Controle_Enter(object sender, EventArgs e)
        {
            SelecionaTodoTexto();
        }

        private void SelecionaTodoTexto()
        {
            SendKeys.Send("^a");
        }
    }
}
