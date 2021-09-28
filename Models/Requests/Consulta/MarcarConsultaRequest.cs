using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cadastro_hospital.Models {
    public class MarcarConsultaRequest {
        public string paciente {get; set;}
        public int exame {get; set;}
        public DateTime data {get; set;}
        public string protocolo {get; set;}
    }
}