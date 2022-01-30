using Projeto.Dominio.Entidades;
using System;

namespace Projeto.Dominio.ObjetosDeValor
{
    public class EnderecoRequisicao
    {
        public Guid Codigo { get; set; }
        public string Logradouro { get; set; }
        public bool SemNumero { get; set; }
        public int? Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Endereco ConverterEmEndereco(Cliente cliente)
        {
            return new Endereco(Codigo, cliente,Logradouro, SemNumero, Numero, Bairro, Cidade, Estado);
        }
    }
}
