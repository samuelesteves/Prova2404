using System.ComponentModel.DataAnnotations;

namespace Prova2404.Models
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }

        public string Nome { get; set; }

        public string Ano { get; set; }

        public string Turma { get; set; }

        public string Periodo { get; set; }

        public string Curso { get; set; }
    }
}
