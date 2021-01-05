﻿function unmaskForm(FormObj) {
    console.log(FormObj);
    $("#" + FormObj.id + " input[type=text]").each(function () {
        $(this).unmask();
    });
}
function buscaCep() {
    var cep = $("#cep").val();
    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
        if (dados.erro) {
            $("#cidade").val("Cidade não encontrada");
            $("#uf").val("UF não encontrado");
        } else {
            $("#cidade").val(dados.localidade);
            $("#uf").val(dados.uf);
        }
    }).fail(function () {
        $("#cidade").val('');
        $("#uf").val('');
    });
}
function table(id, urlGet, urlEdit, columns) {

    columns.unshift( {
        "className": 'details-control',
        "orderable": false,
        "data": null,
        "defaultContent": ''
    });
    columns.unshift({
        "data": "id",
        "orderable": false
    });
    
    var table = $('#' + id).DataTable({
        "deferRender": true,
        "pagingType": "simple_numbers",
        "order": [[2, "asc"]],
        "stateSave": true,
        "info": false,
        "ajax": {
            "url": urlGet,
            "type": "GET",
            "dataSrc": 'detail'
        },
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ],
        "columns": 
            columns
        ,
        "rowCallback": function (row, data) {
            $(row.querySelector("tr > td.details-control")).click(function () {
                window.location.href = urlEdit + "?id=" + data.id;
            });
        },
        "language": {
            "paginate": {
                "previous": "<<",
                "next": ">>"
            },
            "lengthMenu": "Mostrando _MENU_",
            "search": "",
            "searchPlaceholder": "Filtrar"
        }
    });
}
