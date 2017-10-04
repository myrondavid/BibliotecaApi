using BibliotecaApi.Models.UsuarioModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApi.Models
{
    public class Emprestimo
    {
        
        public int Id { get; set; }
        public Livro Livro { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public int PrazoDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public DateTime DataLimite { get; set; }
    }
}
