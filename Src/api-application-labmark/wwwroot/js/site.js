function unmaskForm(FormObj) {
    console.log(FormObj);
    $("#"+FormObj.id + " input[type=text]").each(function () {
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