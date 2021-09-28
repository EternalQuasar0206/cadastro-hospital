using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cadastro_hospital.Models {
    public class MarcarConsultaRequest {
        public int paciente {get; set;}
        public int exame {get; set;}
        public string data {get; set;}
        public string protocolo {get; set;}
    }
}