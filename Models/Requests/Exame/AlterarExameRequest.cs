namespace cadastro_hospital.Models {
    public class AlterarExameRequest {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoexameId { get; set; }
        public string Descricao { get; set; }
    }
}