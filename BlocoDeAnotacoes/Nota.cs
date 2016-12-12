using System;
using SQLite.Net.Attributes;

namespace BlocoDeAnotacoes
{
    [Table("Nota")]
    class Nota
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100), NotNull]
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        [NotNull]
        public DateTime DataModificacao { get; set; }
        [NotNull]
        public bool Prioridade { get; set; }

        public Nota()
        {
            this.DataModificacao = DateTime.Now;
            this.Prioridade = false;
        }
    }
}
