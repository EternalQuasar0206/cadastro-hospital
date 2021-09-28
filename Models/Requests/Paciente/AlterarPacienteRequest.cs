namespace cadastro_hospital.Models {
    public class AlterarPacienteRequest {
        public int Id {get; set;}
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Nascimento { get; set; }
        public char Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}