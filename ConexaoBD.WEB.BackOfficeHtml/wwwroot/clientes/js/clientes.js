//Chamada da Função de ativação de botão da barra de navegação
$(document).ready(function () {
    var menu = document.getElementById("navClientes");
    AtivarBotaoBarraNavegacao(menu);

    PreencherTabelaClientes();
    //PreencherTabelaMoradas();

});

//Preenchimento da tabela de Clientes
function PreencherTabelaClientes() {
    $("#tblClientes").DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_pt.json'
        },
        "ajax": "https://localhost:44372/api/Cliente/calculos/tabelaclientes",
        "columns": [
            { "data": "id" },
            { "data": "nome" },
            { "data": "nif" },
            { "data": "ativo" },
            { "data": "dataCriacao" },
            { "data": "dataAlteracao" },
            { "defaultContent": "<a href='#' onclick='return ApresentarMorada();'>Detalhes</a>" },
            { "defaultContent": "<a href='#'>Editar</a>" }
        ]
    });
}


function ApresentarMorada() {
    $("#tblMoradaCliente").DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_pt.json'
        },
        "ajax": "https://localhost:44372/api/Cliente/calculos/tabelamorada",
        "columns": [
            { "data": "idMorada" },
            { "data": "tipoMoradaStr" },
            { "data": "distrito" },
            { "data": "endereco" },
            { "data": "codigoPostal" },
            { "data": "localidade" }
        ] 
    });
    $("#teste").text("Falta completar o Row-Selector!");
}



//Preenchimento da tabela de Moradas
function PreencherTabelaMoradas() {
    $("#tblMoradaCliente").DataTable({
        language: {
            url: 'https://cdn.datatables.net/plug-ins/1.11.3/i18n/pt_pt.json'
        },
        "ajax": "https://localhost:44372/api/Cliente/calculos/tabelamorada",
        "columns": [
            { "data": "idMorada" },
            { "data": "tipoMoradaStr" },
            { "data": "distrito" },
            { "data": "endereco" },
            { "data": "codigoPostal" },
            { "data": "localidade" }
        ]
    });
}
