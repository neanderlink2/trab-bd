using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabBD.Models
{
    [Table("TB_EMAIL")]
    public class Email
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("endereco")]
        public string Endereco { get; set; }

        [Column("id_contato")]
        [ForeignKey("Contato")]        
        public Guid IdContato { get; set; }

        public Contato Contato { get; set; }
    }
}
