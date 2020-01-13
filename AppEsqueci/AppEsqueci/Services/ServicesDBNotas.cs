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

        public ServicesDBNotas(string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath)) 
                dbPath = App.DbPath;
            conn = new SQLiteConnection(dbPath); //Define o banco
            conn.CreateTable<ModelNotas>(); // cria a tabela notas
        }

        public void Inserir(ModelNotas nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))
                    throw new Exception("Titulo da nota não informado");
                if (string.IsNullOrEmpty(nota.Dados))
                    throw new Exception("Dados da nota não informado(s)");

                int result = conn.Insert(nota);
                if (result != 0)
                    this.StatusMessage = string.Format("{0} registro(s) adicionado(s): [Nota: {1}]", result, nota.Titulo);
                else
                    this.StatusMessage = string.Format("0 registro(s) adicionado(s): Informe o 'título' e os 'dados' da nota");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModelNotas> Listar()
        {
            List<ModelNotas> lista = new List<ModelNotas>();
            try
            {
                lista = conn.Table<ModelNotas>().ToList();
                this.StatusMessage = "Litagem das Notas";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return lista;
        }
    }
}
