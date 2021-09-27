using System.ComponentModel.DataAnnotations;
using System;

namespace cadastro_hospital.Models {
    public class Exame {
        [Key]
        public int id {get; set;}
        [MaxLength(100)]
        public string nome {get; set;}
        [MaxLength(11)]
        public string cpf {get; set;}
        public DateTime nascimento {get; set;}
        public char sexo {get; set;}
        public string telefone {get; set;}
        public string email {get; set;}
    }
}