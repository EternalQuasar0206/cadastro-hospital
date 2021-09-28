using cadastro_hospital.Models;
using System.Linq;
using System.Text.Json;
using System;

namespace cadastro_hospital.Data {
    public static class GerenciarPaciente {
        public static string Novo(Paciente paciente) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();
            string result = string.Empty;

            try {
                var cpf_equals_list = ctx.Pacientes.Where(x => x.Cpf == paciente.Cpf).ToList();

                if(cpf_equals_list.Count > 0) {
                    throw new Exception("Já existe um CPF igual a esse cadastrado no sistema.");
                }

                //TODO: Adicionar validadores de informação

                ctx.Pacientes.Add(paciente);
                ctx.SaveChanges();
                return JsonSerializer.Serialize(paciente);
            }
            catch(Exception e) {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "Ocorreu um erro ao realizar a ação: " + e
                });
            }
        }

        public static string Alterar(int id, Paciente paciente) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();
            Paciente entity = ctx.Pacientes.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "O id do paciente informado não existe"
                });
            }

            ctx.Entry(entity).CurrentValues.SetValues(paciente);
            ctx.SaveChanges();
            return JsonSerializer.Serialize(entity);
        }
    }
}