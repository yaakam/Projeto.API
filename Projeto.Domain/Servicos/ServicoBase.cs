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
        protected virtual async Task DoProcess(T entidade) { }

        protected virtual async Task DoProcess(IList<T> entidade) { }

        protected virtual async Task DoProcess() { }

        #endregion

        #region "Operações pré-implementadas"
        public async Task<MensagemDeResposta> Process(T entidade)
        {
            return await ExecuteOperation(entidade, DoProcess);
        }

        public async Task<MensagemDeResposta> Process(IList<T> list)
        {
            return await ExecuteOperation(list, DoProcess);
        }

        public async Task<MensagemDeResposta> Process()
        {
            return await ExecuteOperation(DoProcess);
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
                Mensagens = Mensagens
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
                Mensagens = Mensagens
            };
        }

        #endregion
    }
}
