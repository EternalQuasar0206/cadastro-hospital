using cadastro_hospital.Models;
using System.Linq;
using System.Text.Json;
using System;

namespace cadastro_hospital.Data {
    //TODO: Adicionar validadores de informação
    public static class GerenciarTipoexames {
        public static string Novo(TipoExame tipoexame) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();

            try {
                ctx.TipoExames.Add(tipoexame);
                ctx.SaveChanges();
                return JsonSerializer.Serialize(tipoexame);
            }
            catch(Exception e) {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "Ocorreu um erro ao realizar a ação: " + e
                });
            }
        }

        public static string Alterar(int id, TipoExame tipoexame) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();
            TipoExame entity = ctx.TipoExames.Where(x => x.Id == id).FirstOrDefault();
            if (entity == null)
            {
                return JsonSerializer.Serialize(new Erro() {
                    mensagem = "O id do tipo de exame informado não existe"
                });
            }

            ctx.Entry(entity).CurrentValues.SetValues(tipoexame);
            ctx.SaveChanges();
            return JsonSerializer.Serialize(entity);
        }

        public static string Excluir(int id) {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();

            try {
                TipoExame entity = ctx.TipoExames.Where(x => x.Id == id).FirstOrDefault();
                ctx.TipoExames.Remove(entity);
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
            var tipo_exames = ctx.TipoExames.ToList();
            return JsonSerializer.Serialize(tipo_exames);
        }
    }
}