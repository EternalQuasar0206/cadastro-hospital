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

            var result = ctx.Exames.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                if(exame.Nome != null && exame.Nome != "") result.Nome = exame.Nome;
                if(exame.TipoexameId != 0) result.TipoexameId = exame.TipoexameId;
                if(exame.Descricao != null && exame.Descricao != "") result.Descricao = exame.Descricao;
                ctx.SaveChanges();
            }

            return JsonSerializer.Serialize(result);
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

        public static string Listar() {
            cadastro_hospitalContext ctx = new cadastro_hospitalContext();
            var exames = ctx.Exames.ToList();
            return JsonSerializer.Serialize(exames);
        }
    }
}