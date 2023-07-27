function vUsuario() {

    this.tableId = 'tblUsuario';
    this.service1 = 'Empresa';
    this.service2 = 'SolicitudEmpresa'
    this.serviceBitacora = 'Bitacora';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaFisica,Nombre,Apellido,Correo,NumTelefono,FechaNacimiento,EstadoUsuario,Rol";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblUsuarioId, false);
    }

    this.Registrar = function () {
        var inputData = {};
        inputData = ctrlActions.GetDataForm("registrationForm");
        this.ctrlActions.PostToAPI(this.service2)

        //this.ctrlActions.PostToAPI(this.service, inputData)
            .done(() => {
                
            })
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

    this.Delete = function () {

        var data = {};
        data = this.ctrlActions.GetDataForm('frmDelete');
        //Hace el post al create
        this.ctrlActions.DeleteToAPI(this.service, data);
        //Refresca la tabla
        this.ReloadTable();

        var cedulaFisica = localStorage.getItem("usuario");
        var arreglo = cedulaFisica.replace(/['"]+/g, '');

        var accion = 'Usuario eliminado';

        var info = { 'Accion': accion, 'CedulaFisica': arreglo };
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