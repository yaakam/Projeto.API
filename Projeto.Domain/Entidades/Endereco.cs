using System;

namespace Projeto.Dominio.Entidades
{
    public class Endereco
    {
        #region "Construtores"
        public Endereco()
        {

        }

        public Endereco(Guid codigo, Cliente cliente, string logradouro, bool semNumero, int? numero, string bairro, string cidade, string estado)
        {
            Codigo = codigo;
            Cliente = cliente;
            Logradouro = logradouro;
            SemNumero = semNumero;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
        }
        #endregion

        #region "Propriedades"

        private Guid codigo;
        public virtual Guid Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }


        private Cliente cliente;
        public virtual Cliente Cliente
        {
            get { return cliente; }
            set 
            { 
                cliente = value; 
            }
        }


        private string logradouro;
        public virtual string Logradouro
        {
            get { return logradouro; }
            set 
            {
                ValidarLogradouro(value);
                logradouro = value; 
            }
        }


        private bool semNumero;
        public virtual bool SemNumero
        {
            get { return semNumero; }
            set 
            {
                semNumero = value; 
            }
        }


        private int? numero;
        public virtual int? Numero
        {
            get { return numero; }
            set 
            { 
                numero = value; 
            }
        }


        private string bairro;
        public virtual string Bairro
        {
            get { return bairro; }
            set 
            {
                ValidarBairro(value);
                bairro = value; 
            }
        }


        private string cidade;
        public virtual string Cidade
        {
            get { return cidade; }
            set 
            {
                ValidarCidade(value);
                cidade = value; 
            }
        }


        private string estado;
        public virtual string Estado
        {
            get { return estado; }
            set 
            {
                ValidarEstado(value);
                estado = value; 
            }
        }

        #endregion

        #region "Validações"

        private void ValidarLogradouro(string logradouro)
        {
            if (string.IsNullOrEmpty(logradouro))
            {
                throw new Exception("O logradouro é obrigatório.");
            }
            else if (logradouro.Length > 50)
            {
                throw new Exception("O logradouro deve conter no máximo 50 caracteres.");
            }
        }

        private void ValidarBairro(string bairro)
        {
            if (string.IsNullOrEmpty(bairro))
            {
                throw new Exception("O logradouro é obrigatório.");
            }
            else if (bairro.Length > 50)
            {
                throw new Exception("O bairro deve conter no máximo 40 caracteres.");
            }
        }

        private void ValidarCidade(string cidade)
        {
            if (string.IsNullOrEmpty(cidade))
            {
                throw new Exception("O cidade é obrigatório.");
            }
            else if (cidade.Length > 50)
            {
                throw new Exception("O cidade deve conter no máximo 40 caracteres.");
            }
        }

        private void ValidarEstado(string estado)
        {
            if (string.IsNullOrEmpty(estado))
            {
                throw new Exception("O estado é obrigatório.");
            }
            else if (estado.Length > 50)
            {
                throw new Exception("O estado deve conter no máximo 40 caracteres.");
            }
        }

        #endregion
    }
}
