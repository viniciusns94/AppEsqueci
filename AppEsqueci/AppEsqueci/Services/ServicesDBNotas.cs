using System;
using System.Collections.Generic;
using System.Text;
using AppEsqueci.Models;
using SQLite;

namespace AppEsqueci.Services
{
    public class ServicesDBNotas
    {
        SQLiteConnection conn;
        public string StatusMessage { get; set; }

        public ServicesDBNotas(string DbPath)
        {
            if (DbPath.Equals("")) DbPath = App.DbPath;
            conn = new SQLiteConnection(DbPath); //Define o banco
            conn.CreateTable<ModelNotas>(); // cria a tabela notas
        }

        public void Inserir(ModelNotas Nota)
        {
            try
            {
                if (string.IsNullOrEmpty(Nota.Titulo))
                    throw new Exception("Titulo da nota não informado");
                if (string.IsNullOrEmpty(Nota.Dados))
                    throw new Exception("Dados da nota não informado(s)");

                int result = conn.Insert(Nota);
                if (result != 0)
                    this.StatusMessage = string.Format("{0} registro(s) adicionado(s): [Nota: {1}]", result, Nota.Titulo);
                else
                    this.StatusMessage = string.Format("0 registro(s) adicionado(s): Informe o 'título' e os 'dados' da nota");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
