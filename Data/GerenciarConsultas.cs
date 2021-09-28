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
                var concorrente_data = ctx.Consultas.Where(x => x.Data == consultaRequest.data).FirstOrDefault();

                if(concorrente_data.Paciente != null) {
                    var consulta = new Consulta() {
                        Paciente = consultaRequest.paciente,
                        Exame = consultaRequest.exame,
                        Data = consultaRequest.data,
                        Protocolo = (int)new Random().Next(1, 999999) + DateTime.Now.ToString("yyyyMMddHHmmss")
                    };
                    ctx.Consultas.Add(consulta);
                    ctx.SaveChanges();
                    return JsonSerializer.Serialize(consulta);
                }
                else {
                    throw new Exception("Já existe uma consulta marcada nesta data.");
                }
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
    }
}