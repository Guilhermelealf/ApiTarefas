using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string? Nome { get; set; }
        
        public string? Descricao {  get; set; }
        
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Concluida { get; set; }

    }
}
