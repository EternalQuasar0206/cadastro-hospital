using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cadastro_hospital.Models {
    public class Consulta {
        [Key]
        public int Id {get; set;}
        public int Paciente {get; set;}
        public int Exame {get; set;}
        public string Data {get; set;}
        public string Protocolo {get; set;}
    }
}