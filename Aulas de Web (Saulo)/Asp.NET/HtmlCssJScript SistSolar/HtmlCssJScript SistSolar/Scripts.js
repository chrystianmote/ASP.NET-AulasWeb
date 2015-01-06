function RedirecionarPlaneta(op) {

    switch (parseInt(op)) {
        case 1:
            window.alert("Você selecionou Mercúrio !!");
            break;
        case 2:
            window.alert("Você selecionou Vênus !!");
            break;
        case 3:
            window.alert("Você selecionou Terra !!");
            break;
        case 4:
            window.alert("Você selecionou Marte !!");
            break;
        case 5:
            window.alert("Você selecionou Desconhecido !!");
            break;
        case 6:
            window.alert("Você selecionou Júpiter !!");
            break;
        case 7:
            window.alert("Você selecionou Saturno !!");
            break;
        case 8:
            window.alert("Você selecionou Urano !!");
            break;
        case 9:
            window.alert("Você selecionou Netuno !!");
            break;
    }
}
function ConfirmarCadastro() {
    var op = window.confirm("Deseja Efetuar o cadastro?")
    if (op) {
        window.alert("Cadastro Efetuado com Sucesso!");
    }
    else {
        window.alert("Repita o Cadastro!");
    }
}