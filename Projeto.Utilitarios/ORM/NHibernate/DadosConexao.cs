﻿namespace Projeto.Utilitarios.ORM.NHibernate
{
    public class DadosConexao
    {
        public string Server { get; set; }
        public string Port { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return "Server=" + Server + (!string.IsNullOrEmpty(Port) ? "," : "") + Port + ";Database=" + Database + ";Uid=" + User +  ";Pwd=" + Password;
        }
    }
}
