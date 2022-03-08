using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTodo.Models
{
    public class Todo
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName ("Atividade")]
        [Column(TypeName ="nvarchar(250)")]
        public string Tasks { get; set; }

        [DisplayName ("Concluído")]
        [Column(TypeName ="bit")]
        public bool Done { get; set; }
        
        [DisplayName ("Data de criação")]
        [Column(TypeName ="datetime")]
        public DateTime CreateTask { get; set; } = DateTime.Now;

        
       
    }
}