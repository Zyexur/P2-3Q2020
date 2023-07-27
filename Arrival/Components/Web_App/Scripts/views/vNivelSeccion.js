function createSeccion() {
    this.ctrlActions = new ControlActions();

    this.serviceSeccion = 'NivelSeccion';

    var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
    var nivel = document.getElementById("Nivel");
    var niv = nivel.options[nivel.selectedIndex].value;
    var seccion = document.getElementById("Seccion");
    var secc = seccion.options[seccion.selectedIndex].value;

    var data = { IdCentroEdu: centroeducativo, IdNivel: niv, IdSeccion: secc };

    this.ctrlActions.PostReloadToAPI(this.serviceSeccion, data, function () {
        var vnivelseccion = new vNivelSeccion();
        vnivelseccion.ReloadTable();
    });

    //this.ctrlActions.PostToAPI(this.serviceSeccion, data);

    var cedulaFisica = localStorage.getItem('usuario');

    var arreglo = cedulaFisica.replace(/['"]+/g, '');

    var accion = 'Seccion creada';

    var info = { 'Accion': accion, 'CedulaFisica': arreglo };
    this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
}

function createNivel() {
    this.ctrlActions = new ControlActions();

    this.serviceNivel = 'CentroEduNivel';
    var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
    var nivel = document.getElementById("Nivel");
    var niv = nivel.options[nivel.selectedIndex].value;
    var seccion = document.getElementById("Seccion");
    var secc = seccion.options[seccion.selectedIndex].value;

    var data = { IdCentroEdu: centroeducativo, IdNivel: niv, IdSeccion: secc };
    

    this.ctrlActions.PostToRegistroAPI(this.serviceNivel, data, function (response) {
       createSeccion();
    });

    //this.ctrlActions.PostReloadToAPI(this.serviceNivel, data, function (response) {
    //    createSeccion();
    //    var vnivelseccion = new vNivelSeccion();
    //    vnivelseccion.ReloadTable();
    //});

    var cedulaFisica = localStorage.getItem('usuario');

    var arreglo = cedulaFisica.replace(/['"]+/g, '');

    var accion = 'Nivel creado';

    var info = { 'Accion': accion, 'CedulaFisica': arreglo };
    this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
}

function vNivelSeccion() {

    this.tblNivelesSeccionesId = 'tblNivelesSecciones';
    this.service = 'NivelesSecciones';
    this.ctrlActions = new ControlActions();
    this.columns = "NombreNivel,NombreSeccion";

    this.Create = function () {
        createNivel();
    }

    this.RetrieveAll = function () {
        var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
        this.ctrlActions.FillTable(this.service + "/" + centroeducativo, this.tblNivelesSeccionesId, false);

    }

    this.ReloadTable = function () {
        var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
        this.ctrlActions.FillTable(this.service + "/" + centroeducativo, this.tblNivelesSeccionesId, true);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

$(document).ready(function () {
    var vnivelSeccion = new vNivelSeccion();
    vnivelSeccion.RetrieveAll();
});