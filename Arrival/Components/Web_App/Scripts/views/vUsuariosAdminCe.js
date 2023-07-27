function vUsuariosAdminCe() {

    this.tblUsuarioId = 'tblUsuariosCe';
    this.service = 'UsuariosCentro';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaFisica,Nombre,Apellido,Correo,NumTelefono,FechaNacimiento,EstadoUsuario,Rol";

    this.RetrieveAll = function () {
        var cedulaJuridica = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
        this.ctrlActions.FillTable(this.service + "/" + cedulaJuridica , this.tblUsuarioId, false);
    }

    this.ReloadTable = function () {
        var cedulaJuridica = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
        this.ctrlActions.FillTable(this.service + "/" + cedulaJuridica, this.tblUsuarioId, true);
    }
};

$(document).ready(function () {
    var vusuarioCe = new vUsuariosAdminCe();
    vusuarioCe.RetrieveAll();

});