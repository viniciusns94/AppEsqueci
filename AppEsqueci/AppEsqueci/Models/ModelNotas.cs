using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppEsqueci.Models
{
    [Table("Anotacoes")]
    public class ModelNotas
    { 
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public string Titulo { get; set; }
        [NotNull]
        public string Dados { get; set; }
        [NotNull]
        public bool Favorito { get; set; }
    }
}
