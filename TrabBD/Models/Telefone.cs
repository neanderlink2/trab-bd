using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabBD.Models
{
    [Table("TB_TELEFONE")]
    public class Telefone
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("numero")]
        public string Numero { get; set; }

        [Column("id_contato")]
        [ForeignKey("Contato")]        
        public Guid IdContato { get; set; }

        public Contato Contato { get; set; }
    }
}
