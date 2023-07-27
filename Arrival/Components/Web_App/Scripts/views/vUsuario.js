function vUsuario() {

    this.tblUsuarioId = 'tblUsuario';
    this.service = 'Usuario';
    this.ServiceActivar = 'Usuario/activar';
    this.ServiceDesactivar = 'Usuario/desactivar';
    this.serviceBitacora = 'Bitacora';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaFisica,Nombre,Apellido,Correo,NumTelefono,FechaNacimiento,EstadoUsuario,Rol";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsuarioId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsuarioId, true);
    }

    this.Update = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmEdition');
        this.ctrlActions.PutToAPI(this.servicePerfil, data);
        this.ReloadTable();

        var cedulaFisica = localStorage.getItem("usuario");
        var arreglo = cedulaFisica.replace(/['"]+/g, '');

        var accion = 'Usuario actualizado';

        var info = { 'Accion': accion, 'CedulaFisica': arreglo };
        this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
    }

    this.Activar = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmDelete');
        this.ctrlActions.PutToApproveAPI(this.ServiceActivar, data, function () {
            var vusuario = new vUsuario();
            vusuario.ReloadTable();
        });
    }

    this.Desactivar = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmDelete');
        this.ctrlActions.PutToApproveAPI(this.ServiceDesactivar, data, function () {
            var vusuario = new vUsuario();
            vusuario.ReloadTable();
        });
    }

    this.Delete = function () {

        var data = {};
        data = this.ctrlActions.GetDataForm('frmDelete');
        //Hace el post al create
        this.ctrlActions.DeleteReloadToAPI(this.service, data, function () {
            var vusuario = new vUsuario();
            vusuario.ReloadTable();
        });
        var cedulaFisica = localStorage.getItem("usuario");
        var arreglo = cedulaFisica.replace(/['"]+/g, '');

        var accion = 'Usuario eliminado';

        var info = {'Accion': accion, 'CedulaFisica': arreglo};
        this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        this.ctrlActions.BindFields('frmDelete', data);
    }
};

$(document).ready(function () {
    var vusuario = new vUsuario();
    vusuario.RetrieveAll();

    $("#txtCedulaUpd").prop('disabled', true);

    $("#btnUpdUsuario").click(function () {
        $("#upd").modal('hide');
    });

    $("#btnDelUsuario").click(function () {
        $("#del").modal('hide');
    });
});