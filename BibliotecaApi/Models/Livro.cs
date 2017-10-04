using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public enum Status
    {
        Disponivel,
        Emprestado
    }

    public class Livro
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public Status Status { get; set; }
        public String Descricao { get; set; }
        public Categoria Categoria { get; set; }
        public int qntCopias { get; set; }
        public int qntIndisponiveis { get; set; }
    }
}
