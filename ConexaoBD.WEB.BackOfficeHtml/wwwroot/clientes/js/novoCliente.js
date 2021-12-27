//Chamada da Função de ativação de botão da barra de navegação
$(document).ready(function () {
    var menu = document.getElementById("navClientes");
    AtivarBotaoBarraNavegacao(menu);

});

function GravarDadosNovoCliente() {
    $('#btnGravar').click(function (e) {
        var dataLocal = {
            "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
            "nome": "novoNome",
            "nif": "123456789",
            "tipoMorada": 2,
            "distrito": "novoDistrito",
            "endereco": "novoEndereco",
            "codigoPostal": "1234567",
            "localidade": "novaLocalidade"
        };
    });

    $.post("", dataLocal).done(function (data) {
        alert("Dados Gravados: " + data);
    });
}
