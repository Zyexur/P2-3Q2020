function vPerfilContrasennaUsuarios() {

    this.tblMembresiasId = '';
    this.service = 'perfilcontrasenna';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaFisica,Nombre,Apellido,Correo,NumTelefono,FechaNacimiento,Contrasenna";

    this.Retrieve = function () {
        var data = {};
        var cedulafisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
        this.ctrlActions.GetToApi(this.service + "/" + cedulafisica, function (response) {
            data = response;
            window.localStorage.setItem('usuarioperfil', JSON.stringify(data));
        });
    }

    this.ModificarContrasenna = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('updateContrasennaForm');
        var cedulafisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
        this.ctrlActions.PutToAPI(this.service + "/" + cedulafisica, data);
        location.reload();
    }

    this.ModificarPerfil = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('updateForm');
        //var cedulafisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
        this.ctrlActions.PutToAPI(this.service, data);
        location.reload();
    }

}

$(document).ready(function () {
    $("#cedula_upd").prop('disabled', true);

    var vperfilcontrasennausuarios = new vPerfilContrasennaUsuarios();
    vperfilcontrasennausuarios.Retrieve();

});

function vperfil() {

    var perfil = window.localStorage.getItem('usuarioperfil');
    console.log(perfil);
    var objeto = {}
    objeto = JSON.parse(perfil);
    $("#cedula_upd").val(objeto.CedulaFisica);
    $("#nombre_upd").val(objeto.Nombre);
    $("#apellidos_upd").val(objeto.Apellido);
    $("#correo_upd").val(objeto.Correo);
    $("#telefono_upd").val(objeto.NumTelefono);
    $("#fecha_nacimiento_upd").val(objeto.FechaNacimiento);
    $("#contrasenna_upd").val(objeto.Contrasenna);

}