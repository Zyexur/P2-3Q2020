function vChoferes() {

    this.tblUsuariosChofer = 'tblUsuariosChofer';
    this.service = 'UsuariosChofer';
    this.Chofer = 'Chofer';
    this.ctrlActions = new ControlActions();
    this.columns = "CedulaFisica,Nombre,Apellido,Correo,NumTelefono,FechaNacimiento,Rol";

    this.RetrieveAll = function () {
        var cedulaJuridica = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
        this.ctrlActions.FillTable(this.Chofer + "/" + cedulaJuridica, this.tblUsuariosChofer, false);
    }

    this.ReloadTable = function () {
        var cedulaJuridica = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
        this.ctrlActions.FillTable(this.Chofer + "/" + cedulaJuridica, this.tblUsuariosChofer, true);
    }

    this.Create = function () {
        var data = {};
        data = this.ctrlActions.GetDataForm('frmEdition');
        //Hace el post al create
        var cedulaJuridica = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
        var register_service = this.service + '/' + cedulaJuridica;

        this.ctrlActions.PostToRegistroAPI(register_service, data, (response) => {
            var data = {};
            data = response.Data;
            if (response.Message === "OK") {
                this.ctrlActions.EnviarCorreo("Confirmación de cuenta", data);
                var smsMsj = `Confirmación de cuenta. Codigo de verificación: ${data.Codigo}.
					Ingrese el codigo de validacion en el siguiente enlace: "https://localhost:44339/Home/ValidarCuenta"`
                this.ctrlActions.EnviarSms(smsMsj, data);
            }
            var vchoferes = new vChoferes();
            vchoferes.ReloadTable();
        });

        //this.ctrlActions.PostToAPI(register_service, data);
    }



    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
    }
}

$(document).ready(function () {
    var vchoferes = new vChoferes();
    vchoferes.RetrieveAll();
});