using cadastro_hospital.Models;
using System.Linq;
using System;

namespace cadastro_hospital.Data {
    public static class GerenciarConsultas {
        public static string Marcar(MarcarConsultaRequest consultaRequest) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();

            try {
                var paciente = ctx.Pacientes.Where(x => x.Id == consultaRequest.paciente).FirstOrDefault();
                var exame = ctx.Exames.Where(x => x.Id == consultaRequest.exame).FirstOrDefault();
                var concorrente_data = ctx.Consultas.Where(x => x.Data == consultaRequest.data).FirstOrDefault();

                if(concorrente_data != null) {
                    ctx.Exames.Add(exame);
                    ctx.SaveChanges();
                    return JsonSerializer.Serialize(exame);
                }
                else {
                    throw new Exception("Tipo de exame inválido ou inexistente.");
                }
            }
            catch(Exception e) {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "Ocorreu um erro ao realizar a ação: " + e
                });
            }
        }
    }
}