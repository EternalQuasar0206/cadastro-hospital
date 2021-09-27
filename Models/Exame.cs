using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace cadastro_hospital.Models
{
    public partial class Exame
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoexameId { get; set; }
        public string Descricao { get; set; }
    }
}
