//Criação de variáveis Globais
var utilizadorLogado = null;
var tema = 0;

//Função de ativação de botão da barra de navegação
function AtivarBotaoBarraNavegacao(param) {
    $(param).addClass("active");
}

//Função de mudança de tema Bootswatch
function MudarTemaBootswatch() {
    var href = "https://bootswatch.com/5/cerulean/bootstrap.min.css";
    tema++;
    switch (tema) {
        case 1:
            href = "https://bootswatch.com/5/darkly/bootstrap.min.css";
            break;
        case 2:
            href = "https://bootswatch.com/5/litera/bootstrap.min.css";
            break;
        case 3:
            href = "https://bootswatch.com/5/materia/bootstrap.min.css";
            break;
        case 4:
            href = "https://bootswatch.com/5/pulse/bootstrap.min.css";
            break;
        default:
            href = "https://bootswatch.com/5/cerulean/bootstrap.min.css";
            tema = 0;
    }
    var link = document.getElementById("bootswatchTheme");
    link.href = href;
}