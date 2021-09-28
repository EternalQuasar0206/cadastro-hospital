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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Gerenciamento de Paciente

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
        public IActionResult Paciente([FromBody] ApagarPacienteRequest pacienteRequest) {
            return Content(GerenciarPacientes.Excluir(pacienteRequest.Id), "application/json");
        }

        //Gerenciamento de tipo de exame

        [HttpPost]
        //Criar tipo de exame
        public IActionResult TipoExame([FromBody] TipoExame tipoExame) {
            return Content(GerenciarTipoexames.Novo(tipoExame), "application/json");
        }

        [HttpPatch]
        //Alterar tipo de exame
        public IActionResult TipoExame([FromBody] AlterarExameRequest exameRequest) {
            var tipo_exame = new TipoExame() {
                Nome = exameRequest.Nome,
                Descricao = exameRequest.Descricao
            };
            return Content(GerenciarTipoexames.Alterar(exameRequest.Id, tipo_exame));
        }
    }
}
