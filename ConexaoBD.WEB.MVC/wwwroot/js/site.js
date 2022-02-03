$(document).ready(function () {
    /*document.getElementById("pwd").innerHTML = "oi";*/

    //https://stackoverflow.com/questions/944857/how-do-i-restrict-access-to-certain-pages-in-asp-net-mvc
    //if (document.getElementById("userLogado").innerHTML != "") {
    //    document.getElementById("clientes").hidden = false;
    //    document.getElementById("utilizadores").hidden = false;
    //    document.getElementById("gruposDeUtilizadores").hidden = false;
    //    document.getElementById("login").hidden = true;
    //    document.getElementById("logout").hidden = false;
    //}
    //else {
    //    document.getElementById("logout").hidden = true;
    //}

});

function sortTable(n) {
    var table, rows, switching, i, x, y, shouldSwitch, dir, switchcount = 0;
    table = document.getElementById("tabela");
    switching = true;
    dir = "asc";
    while (switching) {
        switching = false;
        rows = table.rows;
        for (i = 1; i < (rows.length - 1); i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("TD")[n];
            y = rows[i + 1].getElementsByTagName("TD")[n];
            if (dir == "asc") {
                if (x.innerHTML.toLowerCase() > y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            } else if (dir == "desc") {
                if (x.innerHTML.toLowerCase() < y.innerHTML.toLowerCase()) {
                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {
            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
            switchcount++;
        } else {
            if (switchcount == 0 && dir == "asc") {
                dir = "desc";
                switching = true;
            }
        }
    }
}
//https://www.w3schools.com/howto/howto_js_sort_table.asp



function find(indice, coluna) {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById(indice);
    filter = input.value.toUpperCase();
    table = document.getElementById("tabela");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = coluna; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[coluna];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}
//https://www.w3schools.com/howto/howto_js_filter_table.asp


