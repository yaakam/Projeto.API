using Projeto.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Projeto.Dominio.ObjetosDeValor
{
    public class ClienteRequisicao
    {
        public Guid Codigo { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public IList<EnderecoRequisicao> ListaDeEnderecos { get; set; }

        public Cliente ConverterEmCliente()
        {
            var cliente  = new Cliente(Codigo, Nome, CPF, DataDeNascimento);
            foreach (var item in ListaDeEnderecos)
                cliente.AdicionarEndereco(item.ConverterEmEndereco(cliente));
            return cliente;
        }
    }
}
