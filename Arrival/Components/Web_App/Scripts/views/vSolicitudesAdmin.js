function vSolicitudesAdmin() {

	this.tblId = 'tblSolicitudes';
	this.service = 'solicitudempresa';
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();
	this.columns = "IdSolicitud,FechaCreacion,CedulaJuridica,NombreJuridico";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmGestion', data);
	}

	this.Approve = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');
		var approve_service = 'solicitudes/' + data.IdSolicitud + '/approve'
		this.ctrlActions.PutToApproveAPI(approve_service, data, function () {
			var vsolicitudes = new vSolicitudesAdmin();
			vsolicitudes.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});

		var cedulaFisica = localStorage.getItem('usuario');
		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Solicitud aprobada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.Reject = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');
		var reject_service = 'solicitudes/' + data.IdSolicitud + '/reject'
		this.ctrlActions.PutToRejectAPI(reject_service, data, function () {
			var vsolicitudes = new vSolicitudesAdmin();
			vsolicitudes.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});

		var cedulaFisica = localStorage.getItem('usuario');

		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Solicitud rechazada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
    }

}

$(document).ready(function () {

	var vsolicitudes = new vSolicitudesAdmin();
	vsolicitudes.RetrieveAll();
	$("#txtId").prop('disabled', true);
	$("#txtFecha").prop('disabled', true);
	$("#txtCedula").prop('disabled', true);
	$("#txtNombre").prop('disabled', true);
});