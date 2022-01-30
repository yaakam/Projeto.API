using Projeto.Dominio.Especificacoes;
using System;
using System.Collections.Generic;

namespace Projeto.Dominio.Entidades
{
    public class Cliente
    {
        #region "Construtores"
        public Cliente()
        {
            listaDeEnderecos = new List<Endereco>();
        }

        public Cliente(Guid codigo, string nome, string cPF, DateTime dataDeAniversario)
        {
            Codigo = codigo;
            Nome = nome;
            CPF = cPF;
            DataDeNascimento = dataDeAniversario;
            listaDeEnderecos = new List<Endereco>();
        }

        #endregion

        #region "Propriedades"

        private Guid codigo;
        public virtual Guid Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        private string nome;
        public virtual string Nome
        {
            get { return nome; }
            set
            {
                ValidarNome(value);
                nome = value;
            }
        }


        private string cPF;
        public virtual string CPF
        {
            get { return cPF; }
            set
            {
                ValidarCPF(value);
                cPF = value;
            }
        }


        private DateTime dataDeNascimento;
        public virtual DateTime DataDeNascimento
        {
            get { return dataDeNascimento; }
            set
            {
                ValidarDataDeNascimento(value);
                dataDeNascimento = value;
            }
        }


        private IList<Endereco> listaDeEnderecos;
        public virtual IList<Endereco> ListaDeEnderecos
        {
            get { return listaDeEnderecos; }
            set
            {
                foreach (var item in value)
                    ValidarLista(item);

                listaDeEnderecos = value;
            }
        }

        #endregion

        #region "Validações"

        private void ValidarNome(string nome)
        {
            if (string.IsNullOrEmpty(nome))
            {
                throw new Exception("O nome o cliente é obrigatório.");
            }
            else if (nome.Length > 30)
            {
                throw new Exception("O nome do cliente deve conter no máximo 30 caracteres.");
            }
        }

        private void ValidarCPF(string cPF)
        {
            if (string.IsNullOrEmpty(cPF))
            {
                throw new Exception("O CPF do cliente é obrigatório.");
            }
            else if (!new CPFValidoEspecificacao().EhSatisfatorio(cPF))
            {
                throw new Exception("O CPF informado é invalido.");
            }
        }

        private void ValidarDataDeNascimento(DateTime dataDeNascimento)
        {
            if (dataDeNascimento == DateTime.MinValue || dataDeNascimento == DateTime.MaxValue)
            {
                throw new Exception("A data de nascimento do cliente é obrigatória.");
            }
        }

        private void ValidarLista(Endereco endereco)
        {
            if (endereco == null)
            {
                throw new Exception("O endereço não pode ser nulo.");
            }            
        }

        public void AdicionarEndereco(Endereco endereco)
        {
            ValidarLista(endereco);

            endereco.Cliente = this;

            listaDeEnderecos.Add(endereco);
        }

        #endregion
    }
}
