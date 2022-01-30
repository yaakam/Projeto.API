using Projeto.Dominio.Enumeradores;
using Projeto.Dominio.Extensoes;
using Projeto.Dominio.ObjetosDeValor;
using Projeto.Utilitarios.ORM.NHibernate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto.Dominio.Servicos
{
    public abstract class ServicoBase<T>
    {
        #region "Delegações"

        public delegate Task ServicoDeTrasancao<TP>(TP entidade);

        public delegate Task ServicoDeTransacaoSemParamentro();

        #endregion

        #region "Propriedades"

        protected object Dados { get; set; }

        public List<Mensagem> Mensagens { get; set; }

        #endregion

        #region "Construtor"

        public ServicoBase()
        {
            Dados = default;
            Mensagens = new List<Mensagem>();
        }

        #endregion


        #region "Abstrações"        
        protected virtual async Task RealizarProcesso(T entidade) { }

        protected virtual async Task RealizarProcesso(IList<T> entidade) { }

        protected virtual async Task RealizarProcesso() { }

        #endregion

        #region "Operações pré-implementadas"
        public async Task<MensagemDeResposta> Processar(T entidade)
        {
            return await ExecuteOperation(entidade, RealizarProcesso);
        }

        public async Task<MensagemDeResposta> Processar(IList<T> list)
        {
            return await ExecuteOperation(list, RealizarProcesso);
        }

        public async Task<MensagemDeResposta> Processar()
        {
            return await ExecuteOperation(RealizarProcesso);
        }

        #endregion

        #region "Transação unificada"
        /// <summary>
        /// Realiza a operação sem paramentros
        /// </summary>
        /// <param name="operation">Operacão que vai ser executada</param>

        protected async Task<MensagemDeResposta> ExecuteOperation(ServicoDeTransacaoSemParamentro operation)
        {
            try
            {
                await operation();
                if (!Mensagens.TemErros())
                {
                    NHibernateFabricaDeSessoes.Sessao().Confirmar();
                }
                else
                {
                    NHibernateFabricaDeSessoes.Sessao().Desfazer();
                }
            }
            catch (Exception e)
            {
                NHibernateFabricaDeSessoes.Sessao().Desfazer();
                Mensagens.Add(new Mensagem(e.Message, TipoDeMensagemEnumerador.Erro));
            }
            finally
            {
                Mensagens.RemoveMensagensDuplicadas();
            }

            return new MensagemDeResposta
            {
                Status = !Mensagens.TemErros(),
                Dados = Dados,
                Mensagens = Dados == null ? new List<Mensagem>() { new Mensagem("O processo não gerou dados.", TipoDeMensagemEnumerador.Informacao) } : Mensagens
            };
        }

        /// <summary>
        /// Realiza a operação com parâmetros
        /// </summary>
        /// <typeparam name="TG">Tipo dos parâmentros</typeparam>
        /// <param name="entidade">Entidade que vai ser processada</param>
        /// <param name="operation">Operação que vai ser executada</param>
        protected async Task<MensagemDeResposta> ExecuteOperation<TG>(TG entidade, ServicoDeTrasancao<TG> operation)
        {
            try
            {
                await operation(entidade);
                if (!Mensagens.TemErros())
                {
                    NHibernateFabricaDeSessoes.Sessao().Confirmar();
                }
                else
                {
                    NHibernateFabricaDeSessoes.Sessao().Desfazer();
                }
            }
            catch (Exception e)
            {
                NHibernateFabricaDeSessoes.Sessao().Desfazer();
                Mensagens.Add(new Mensagem(e.Message));
            }
            finally
            {
                Mensagens.RemoveMensagensDuplicadas();
            }

            return new MensagemDeResposta
            {
                Status = !Mensagens.TemErros(),
                Dados = Dados,
                Mensagens = Dados == null ? new List<Mensagem>() { new Mensagem("O processo não gerou dados.", TipoDeMensagemEnumerador.Informacao) } : Mensagens
            };
        }

        #endregion
    }
}
