using System.ComponentModel.DataAnnotations;
using System;

namespace cadastro_hospital.Models {
    public class Exame {
        [Key]
        public int id {get; set;}
        public int tipoexame_id {get; set;}
        [MaxLength(100)]
        public string nome {get; set;}
        [MaxLength(256)]
        public string descricao {get; set;}

    }
}