using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabBD.Models
{
    [Table("TB_CONTATO")]
    public class Contato
    {
        [Column("id")]
        public Guid Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }


        public IEnumerable<Email> Emails { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
    }
}
