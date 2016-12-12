using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace BlocoDeAnotacoes
{
    class NotaDAO
    {
        private static SQLiteConnection conn;
        private const string dbFilename = "blocoDeAnotacoes.db";

        public static void LoadDatabase()
        {
            string path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, dbFilename);
            conn = new SQLiteConnection(new SQLitePlatformWinRT(), path);
            conn.CreateTable<Nota>();
        }

        internal static void Salvar(Nota nota)
        {
            if (nota.Id > 0)
                conn.Update(nota);
            else
                conn.Insert(nota);
        }

        internal static void Remover(Nota nota)
        {
            conn.Delete(nota);
        }

        internal static List<Nota> Listar()
        {
            var notas = conn.Query<Nota>("SELECT Id, Titulo, Descricao, DataModificacao, Prioridade FROM Nota");

            return notas.ToList();
        }

        internal static Nota ObterPorId(int id)
        {
            var notas = conn.Query<Nota>("SELECT Id, Titulo, Descricao, DataModificacao, Prioridade FROM Nota WHERE Id = " + id);

            Nota nota = null;

            if (notas.Count > 0)
                nota = notas[0];

            return nota;
        }

        /// <summary>
        /// Busca de notas por texto
        /// </summary>
        /// <param name="texto">String de busca</param>
        /// <returns>Notas que contenham a busca no título ou descrição (case insensitive)</returns>
        internal static List<Nota> Buscar(string texto)
        {
            var notas = conn.Query<Nota>(
                "SELECT Id, Titulo, Descricao, DataModificacao, Prioridade " + 
                "FROM Nota WHERE LOWER(Titulo) LIKE '%" + texto.ToLower() + "%' OR LOWER(Descricao) LIKE '%" + texto.ToLower() + "%'");

            List<Nota> lista = new List<Nota>();

            foreach (var nota in notas)
            {
                lista.Add(nota);
            }

            return lista;
        }
    }
}
