var dq = function(x) {
    return document.querySelector(x);
}

function CadastrarPaciente() {
    let data = {
        Nome: dq("#nome_paciente").value,
        Cpf: dq("#cpf_paciente").value,
        Nascimento: dq("#nascimento_paciente").value,
        Sexo: dq("#sexo_paciente").options[dq("#sexo_paciente").selectedIndex].value,
        Email: dq("#email_paciente").value,
        Telefone: dq("#telefone_paciente").value
    }

    fetch("../Api/Paciente", {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(data => {
        if(data.mensagem) {
            alert(data.mensagem);
        }
        else {
            alert("Paciente criado com sucesso")
        }
    })
    .catch((error) => {
        alert("Ocorreu um erro: " + error)
    })
}

function EditarPaciente() {
    let data = {
        Id: dq("#id_paciente").value,
        Nome: dq("#enome_paciente").value,
        Cpf: dq("#ecpf_paciente").value,
        Nascimento: dq("#enascimento_paciente").value,
        Sexo: dq("#esexo_paciente").options[dq("#esexo_paciente").selectedIndex].value,
        Email: dq("#eemail_paciente").value,
        Telefone: dq("#etelefone_paciente").value
    }

    fetch("../Api/Paciente", {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(data => {
        if(data.mensagem) {
            alert(data.mensagem);
        }
        else {
            alert("Paciente editado com sucesso")
        }
    })
    .catch((error) => {
        alert("Ocorreu um erro: " + error)
    })
}