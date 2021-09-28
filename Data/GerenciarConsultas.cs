using cadastro_hospital.Models;
using System.Linq;
using System.Text.Json;
using System;

namespace cadastro_hospital.Data {
    public static class GerenciarConsultas {
        public static string Marcar(MarcarConsultaRequest consultaRequest) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();

            try {
                var paciente = ctx.Pacientes.Where(x => x.Id == consultaRequest.paciente).FirstOrDefault();
                var exame = ctx.Exames.Where(x => x.Id == consultaRequest.exame).FirstOrDefault();
                var concorrente = ctx.Consultas.Where(x => x.Data == consultaRequest.data).SingleOrDefault();

                if(!IsDate(consultaRequest.data)) {
                    throw new Exception("Data inválida");
                }
                var consulta = new Consulta() {
                    Paciente = paciente.Id,
                    Exame = exame.Id,
                    Data = consultaRequest.data,
                    Protocolo = (int)new Random().Next(1, 999999) + DateTime.Now.ToString("yyyyMMddHHmmss")
                };
                ctx.Consultas.Add(consulta);
                ctx.SaveChanges();
                return JsonSerializer.Serialize(consulta);
            }
            catch(Exception e) {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "Ocorreu um erro ao realizar a ação: " + e
                });
            }
        }

        public static string Desmarcar(DesmarcarConsultaRequest consultaRequest) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();

            try {
                Consulta entity = ctx.Consultas.Where(x => x.Id == consultaRequest.id).FirstOrDefault();
                ctx.Consultas.Remove(entity);
                ctx.SaveChanges();
                return JsonSerializer.Serialize(entity);
            }
            catch(Exception e) {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "Ocorreu um erro ao realizar a ação: " + e
                });
            }
        }
        
        public static string Listar() {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();
            var consultas = ctx.Consultas.ToList();
            return JsonSerializer.Serialize(consultas);
        }

        public static bool IsDate(string tempDate) { 
            DateTime fromDateValue; 
            var formats = new[] { "dd/MM/yyyy", "yyyy-MM-dd" }; 
            if (DateTime.TryParseExact(tempDate, formats, 
            System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fromDateValue)) { 
                return true;
            }
            else { 
                return false;
            }
        }
    }
}