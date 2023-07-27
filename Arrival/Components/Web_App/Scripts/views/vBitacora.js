function vBitacora() {

    this.tblBitacoraId = 'tblBitacora';
    this.service = 'Bitacora';
    this.ctrlActions = new ControlActions();
    this.columns = "IdActividad,Fecha,Accion,CedulaFisica";

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblBitacoraId, false);
    }

    this.ReloadTable = function () {
        this.ctrlActions.FillTable(this.service, this.tblBitacoraId, true);
    }

    this.BindFields = function (data) {
        this.ctrlActions.BindFields('frmEdition', data);
        this.ctrlActions.BindFields('frmDelete', data);
    }
}

$(document).ready(function () {
    var vbitacora = new vBitacora();
    vbitacora.RetrieveAll();
});