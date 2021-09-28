using cadastro_hospital.Models;
using System.Linq;
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

                ctx.Pacientes.Add(new Paciente() {
                    Nome = paciente.Nome,
                    Cpf = paciente.Cpf,
                    Nascimento = paciente.Nascimento,
                    Sexo = paciente.Sexo,
                    Telefone = paciente.Telefone
                });
                //TODO: Adicionar retorno de sucesso
            }
            catch {
                //TODO: Adicionar tratamento do erro
            }
            //TODO: Adicionar retorno padrão (falso)
        }
    }
}