
function iniciar() {
    document.getElementById("carrera").style.display = "none";
}


function actualizacionCombo(valor) {

    if (valor == "Profesor" || valor == "Estudiante") {
        document.getElementById("carrera").style.display = "block";
    }
    else {
        document.getElementById("carrera").style.display = "none";
    }
}

$(function () {
    $("ComboBoxRol").change(function () {
        var valor = $(this).val();

        if (valor == "Profesor" && valor == "Estudiante") {
            document.getElementById("carrera").style.display = "block";
        }
    });
});