//Chamada da Função de ativação de botão da barra de navegação
$(document).ready(function () {
    var menu = document.getElementById("navHome");
    AtivarBotaoBarraNavegacao(menu);
    AtualizarValoresDosCards();
    AtualizarGraficoClientes();

    $("#btnLogin").click(function () {
        ExibirPainelDeLogin();
    });
});


//Funções para ligação à Base de Dados com CORS+AJAX
function AtualizarNumeroDeClientesAtivos() {
    var definicoes = {
        url: "https://localhost:44372/api/Cliente/calculos/numerodeclientesativos",
        method: 'GET'
    };

    $.ajax(definicoes).done(function (resposta) {
        console.debug(resposta);
        $("#lblNumeroClientesAtivos").text(resposta);
    });
}
function AtualizarNumeroDeClientes() {
    var definicoes = {
        url: "https://localhost:44372/api/Cliente/calculos/numerodeclientes",
        method: 'GET'
    };

    $.ajax(definicoes).done(function (resposta) {
        console.debug(resposta);
        $("#lblNumeroClientes").text(resposta);
    });
}

//Função para atualizar o valores dos Cards:
function AtualizarValoresDosCards() {
    $("#lblNumeroClientesAtivos").text("0");
    $("#lblNumeroVendas").text("0");
    $("#lblNumeroArtigosAtivos").text("0");

    AtualizarNumeroDeClientesAtivos();
    AtualizarNumeroDeClientes();
}

function AtualizarGraficoClientes() {
    google.charts.load('current', { 'packages': ['corechart'] });
    google.charts.setOnLoadCallback(CarregarDadosDoGraficoClientes);

    var clientesAtivos = 0;
    var clientesInativos = 0;

    var definicoesA = {
        url: "https://localhost:44372/api/Cliente/calculos/numerodeclientesativos",
        async: false,
        method: 'GET'
    };
    var definicoesB = {
        url: "https://localhost:44372/api/Cliente/calculos/numerodeclientes",
        async: false,
        method: 'GET'
    };

    $.ajax(definicoesA).done(function (resposta) {
        clientesAtivos = resposta;
    });
    $.ajax(definicoesB).done(function (resposta) {
        clientesInativos = resposta - clientesAtivos;
    });

    function CarregarDadosDoGraficoClientes() {
        var data = google.visualization.arrayToDataTable([
            ['Estado', 'Quant.'],
            ['Ativo', clientesAtivos],
            ['Inativo', clientesInativos]
        ]);

        var options = {
            title: 'Estado dos Clientes',
            legend: { position: 'bottom' }
        };

        var chart = new google.visualization.PieChart(document.getElementById('imgGraficoClientes'));
        chart.draw(data, options);
    }
}

function ExibirPainelDeLogin() {
    Swal.fire({
        title: 'Painel de Login',
        input: 'text',
        inputAttributes: {
            autocapitalize: 'off'
        },
        showCancelButton: true,
        confirmButtonText: 'Entrar',
        showLoaderOnConfirm: true,
        preConfirm: (login) => {
            return fetch('').then(resposta => {
                if (!resposta.ok) {
                    throw new Error(resposta.statusText)
                }
                return resposta.json()
            })
                .catch(erro => { Swal.showValidationMessage('Entrada recusada.') })
        },
        alloOutsideClick: () => !Swal.isLoading()
    }).then((resulto) => {
        if (resultado.isConfirmed) {
            Swal.fire({
                title: 'Logado com sucesso.',
                imageUrl: resultado.value.avatar_url
            })
        }
    })
}

