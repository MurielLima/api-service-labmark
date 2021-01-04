function unmaskForm(FormObj) {
    console.log(FormObj);
    $("#"+FormObj.id + " input[type=text]").each(function () {
        $(this).unmask();
    });
}