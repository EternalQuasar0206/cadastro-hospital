using cadastro_hospital.Models;
using System.Linq;
using System.Text.Json;
using System;

//TODO: Adicionar validadores de informação
namespace cadastro_hospital.Data {
    public static class GerenciarExames {
        public static string Novo(Exame exame) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();

            try {
                var tipo_exame = ctx.TipoExames.Where(x => x.Id == exame.TipoexameId).FirstOrDefault();

                if(tipo_exame != null) {
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

        public static string Alterar(int id, Exame exame) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();
            Exame entity = ctx.Exames.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "O id do exame informado não existe"
                });
            }

            ctx.Entry(entity).CurrentValues.SetValues(exame);
            ctx.SaveChanges();
            return JsonSerializer.Serialize(entity);
        }

        public static string Excluir(int id) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();

            try {
                Exame entity = ctx.Exames.Where(x => x.Id == id).FirstOrDefault();
                ctx.Exames.Remove(entity);
                ctx.SaveChanges();
                return JsonSerializer.Serialize(entity);
            }
            catch(Exception e) {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "Ocorreu um erro ao realizar a ação: " + e
                });
            }

        }
    }
}