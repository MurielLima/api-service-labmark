$("form").submit(function (event) {
    console.log(this, event);
});
function unmaskForm(FormObj) {
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
            $("#logradouro").val(dados.logradouro);
            $("#bairro").val(dados.bairro);
        }
    }).fail(function () {
        $("#cidade").val('');
        $("#uf").val('');
    });
}

function dateFormat(date) {
    const meses = ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"];
    let data = new Date(date);
    let dataFormatada = ((data.getDate() + " " + meses[(data.getMonth())] + " " + data.getFullYear()));
    return dataFormatada;
}

function cpfCnpjFormat(full) {

    if (full['cpf']) {        
        return full['cpf'].replace(/^(\d{3})\D*(\d{3})\D*(\d{3})\D*(\d{2})$/g, '$1.$2.$3-$4');
    } else {
        return full['cnpj'].replace(/^(\d{2})\D*(\d{3})\D*(\d{3})\D*(\d{4})\D*(\d{2})$/g,'$1.$2.$3/$4-$5');
    }




}


function phoneFormat(full) {
    if (full['phone'].ddd && full['phone'].number)
        return '(' + full['phone'].ddd + ') ' + full['phone'].number || '';
    else
        return '';
}

function table(id, urlGet, urlEdit, columns, campo, exam) {

    columns.unshift({
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
            campo = campo || '?id=';
           
            $(row.querySelector("tr > td.details-control")).click(function () {
                if (exam) {


                    if ([2, 13].includes(data.code)) {

                        urlEdit = '/Exam/CountMBLB/';
                    }

                    if ([6, 7, 15, 150, 16, 160].includes(data.code)) {
                        urlEdit = '/Exam/ColifomsEscherichia/FirstStep/';
                    }
                    window.location.href = urlEdit + campo + window.location.href.split('=')[1];
                } else window.location.href = urlEdit + campo + data.id;
                //window.alert(urlEdit + campo + data.id);
                
            });
        },
        "language": {
            "paginate": {
                "previous": "Anterior",
                "next": "Próxima"
            },
            "lengthMenu": "Mostrando _MENU_",
            "search": "",
            "searchPlaceholder": "Filtrar"
        }
    });
    $.fn.dataTable.ext.errMode = 'throw';

    table.on('error.dt', function (e, settings, techNote, message) {
        Swal.fire({
            title: "Ops..\nLista vazia!",
            text: "Parece que não temos nenhum registro para mostrar.",
            icon: 'info',
            confirmButtonColor: '#3085d6',
            confirmButtonText: 'Ok'
        })
        console.log(message);
        return true;
    });
}
/* Valida se a data passada como parâmetro está dentro do período informado */
function isDataValida(data, periodo) {
    var arrayData = data.split('/');
    var campoDia = parseInt(arrayData[]);
    var campoMes = parseInt(arrayData[1]);
    var campAno = parseInt(arrayData[2]);

    var dataUsuario = new Date();
    dataUsuario.setDate(campoDia);
    dataUsuario.setMonth(campoMes - 1);
    dataUsuario.setFullYear(campAno);

    var dataLimite = new Date();
    dataLimite.setDate(dataLimite.getDate() + periodo);

    if (dataUsuario.getTime() <= dataLimite.getTime()) {
        return true;
    } else {
        return false;
    }
}
