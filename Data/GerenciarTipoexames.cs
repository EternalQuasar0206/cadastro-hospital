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

            var result = ctx.TipoExames.SingleOrDefault(x => x.Id == id);
            if (result != null)
            {
                if(tipoexame.Nome != null && tipoexame.Nome != "") result.Nome = tipoexame.Nome;
                if(tipoexame.Descricao != null && tipoexame.Descricao != "") result.Descricao = tipoexame.Descricao;
                ctx.SaveChanges();
            }

            return JsonSerializer.Serialize(result);
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