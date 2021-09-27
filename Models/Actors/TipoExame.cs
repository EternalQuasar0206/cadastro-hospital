using System.ComponentModel.DataAnnotations;
using System;

namespace cadastro_hospital.Models {
    public class TipoExame {
        [Key]
        public int id {get; set;}
        [MaxLength(100)]
        public string nome {get; set;}
        [MaxLength(256)]
        public string descricao {get; set;}
    }
}