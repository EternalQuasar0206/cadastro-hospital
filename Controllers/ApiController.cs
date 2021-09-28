using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cadastro_hospital.Models;
using cadastro_hospital.Data;

namespace cadastro_hospital.Controllers
{
    public class ApiController : Controller
    {
        private readonly ILogger<ApiController> _logger;

        public ApiController(ILogger<ApiController> logger)
        {
            _logger = logger;
        }

        //====================Gerenciamento de Paciente====================

        [HttpPost]
        //Criar paciente
        public IActionResult Paciente([FromBody] Paciente paciente)
        {
            return Content(GerenciarPacientes.Novo(paciente), "application/json");
        }

        [HttpPatch]
        //Alterar Paciente
        public IActionResult Paciente([FromBody] AlterarPacienteRequest pacienteRequest)
        {
            var paciente = new Paciente() {
                Nome = pacienteRequest.Nome,
                Cpf = pacienteRequest.Cpf,
                Nascimento = pacienteRequest.Nascimento,
                Sexo = pacienteRequest.Sexo,
                Telefone = pacienteRequest.Telefone,
                Email = pacienteRequest.Email
            };
            return Content(GerenciarPacientes.Alterar(pacienteRequest.Id, paciente), "application/json");
        }

        [HttpDelete]
        //Apagar paciente
        public IActionResult Paciente([FromBody] ApagarPacienteRequest pacienteRequest) {
            return Content(GerenciarPacientes.Excluir(pacienteRequest.Id), "application/json");
        }

        //====================Gerenciamento de tipo de exame====================

        [HttpPost]
        //Criar tipo de exame
        public IActionResult TipoExame([FromBody] TipoExame tipoExame) {
            return Content(GerenciarTipoexames.Novo(tipoExame), "application/json");
        }

        [HttpPatch]
        //Alterar tipo de exame
        public IActionResult TipoExame([FromBody] AlterarTipoExameRequest exameRequest) {
            var tipo_exame = new TipoExame() {
                Nome = exameRequest.Nome,
                Descricao = exameRequest.Descricao
            };
            return Content(GerenciarTipoexames.Alterar(exameRequest.Id, tipo_exame));
        }

        [HttpDelete]
        //Apagar tipo de exame
        public IActionResult TipoExame([FromBody] ApagarTipoExameRequest exameRequest) {
            return Content(GerenciarTipoexames.Excluir(exameRequest.Id), "application/json");
        }

        //====================Gerenciamento de exame====================
        [HttpPost]
        //Criar exame
        public IActionResult Exame([FromBody] Exame exame) {
            return Content(GerenciarExames.Novo(exame), "application/json");
        }

        [HttpPatch]
        //Alterar exame
        public IActionResult Exame([FromBody] AlterarExameRequest exameRequest) {
            var exame = new Exame() {
                Nome = exameRequest.Nome,
                Descricao = exameRequest.Descricao,
                TipoexameId = exameRequest.TipoexameId
            };
            return Content(GerenciarExames.Alterar(exameRequest.Id, exame), "application/json");
        }

        [HttpDelete]
        //Apagar exame
        public IActionResult Exame([FromBody] ApagarTipoExameRequest exameRequest) {
            return Content(GerenciarExames.Excluir(exameRequest.Id), "application/json");
        }
    }
}
