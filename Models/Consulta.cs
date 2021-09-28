using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cadastro_hospital.Models {
    public class Consulta {
        [Key]
        public int Id {get; set;}
        public string Paciente {get; set;}
        public string Exame {get; set;}
        public string Data {get; set;}
        public string Protocolo {get; set;}
    }
}