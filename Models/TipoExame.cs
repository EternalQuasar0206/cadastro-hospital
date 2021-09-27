using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace cadastro_hospital.Models
{
    public partial class TipoExame
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(256)]
        public string Descricao { get; set; }
    }
}
