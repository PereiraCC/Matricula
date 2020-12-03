
function iniciar() {
    document.getElementById("carrera").style.display = "none";
}

function iniciarPlan() {
    document.getElementById("cboTecnologias").style.display = "none";
    document.getElementById("cboTurismo").style.display = "none";
    document.getElementById("cboCriminal").style.display = "none";
    document.getElementById("cboDental").style.display = "none";
    document.getElementById("cboElectronica").style.display = "none";
    document.getElementById("cboSecretariado").style.display = "none";
    document.getElementById("cboAdministracion").style.display = "none";
}

function cambioComboCarrera(valor) {

    if (valor == "Tecnologias de informacion") {
        iniciarPlan();
        document.getElementById("cboTecnologias").style.display = "block";
    }
    else if (valor == "Turismo") {
        iniciarPlan();
        document.getElementById("cboTurismo").style.display = "block";
        
    }
    else if (valor == "Investigación Criminal") {
        iniciarPlan();
        document.getElementById("cboCriminal").style.display = "block";
    }
    else if (valor == "Mecánica Dental") {
        iniciarPlan();
        document.getElementById("cboDental").style.display = "block";
    }
    else if (valor == "Electrónica") {
        iniciarPlan();
        document.getElementById("cboElectronica").style.display = "block";
    }
    else if (valor == "Secretariado Ejecutivo") {
        iniciarPlan();
        document.getElementById("cboSecretariado").style.display = "block";
    }
    else if (valor == "Dirección y Administración de Empresas") {
        iniciarPlan();
        document.getElementById("cboAdministracion").style.display = "block";
    }
}


function actualizacionCombo(valor) {

    if (valor == "Profesor" || valor == "Estudiante") {
        document.getElementById("carrera").style.display = "block";
    }
    else {
        document.getElementById("carrera").style.display = "none";
    }
}

function agregarTabla(valor) {
    var nombreMateria = valor;
    var i = 1; //contador para asignar id al boton que borrara la fila
    var fila = '<tr id="row' + i + '><td>' + nombreMateria + '</td><td><button type="button" name="remove" id="' + i + '" class="btn btn-danger btn_remove" onclick="eliminarDatoTabla(this)">Quitar</button></td></tr>'; //esto seria lo que contendria la fila

    i++;
    $('#mytable tr:first').after(fila);
    $("#adicionados").text(""); //esta instruccion limpia el div adicioandos para que no se vayan acumulando
    var nFilas = $("#mytable tr").length;
    $("#adicionados").append(nFilas - 1);
    //le resto 1 para no contar la fila del header
};

function eliminarDatoTabla(data) {
    var button_id = data.id;
    //cuando da click obtenemos el id del boton
    $('#row' + button_id + '').remove(); //borra la fila
    //limpia el para que vuelva a contar las filas de la tabla
    $("#adicionados").text("");
    var nFilas = $("#mytable tr").length;
    $("#adicionados").append(nFilas - 1);
};



