// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    getDataTable("#table - Utilizador");
    getDatatable("#table - Artigo");

})
function getDataTable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registo encontrado na tabela",
            "s.Info": "Mostrar _START_ at&eacute; _END_ de _TOTAL_ registos,",
            "s.InfoFiltered": "Mostrar 0 at&eacute; 0 de 0 registos",
            "sInfoFiltered": "(Filtrar de _MAX_ total de registos)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLenghtMenu": "Mostrar _MENU_ registos por página",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processing...",
            "sZeroRecords": "Nenhum registo encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Próximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último",
            },
            "oAria": {
                "sSortAscending": "Ordenar por ordem crescente",
                "sSortDescending": "Ordenar por ordem decrescente"
            }
        }
    });

}

$('.close-alert').click(function () {
    $('alert').hide('hide');
})