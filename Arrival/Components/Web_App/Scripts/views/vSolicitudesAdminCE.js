function vSolicitudesAdminCE() {

	this.tblId = 'tblSolicitudes';
	this.service = 'solicitudestudiante';
	this.ctrlActions = new ControlActions();
	this.columns = "IdSolicitud,FechaCreacion,CedulaFisica,Nombre,Apellido";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service + '?cedulaFisica=' + window.localStorage.getItem('usuario').replace(/['"]+/g, '') , this.tblId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service + '?cedulaFisica=' + window.localStorage.getItem('usuario').replace(/['"]+/g, '') , this.tblId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmGestion', data);
	}

	this.Approve = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');
		var approve_service = this.service + '/' + data.IdSolicitud + '/approve' + '?cedulaFisica=' + window.localStorage.getItem('usuario').replace(/['"]+/g, '')
		this.ctrlActions.PutToApproveAPI(approve_service, data, function () {
			var vsolicitudesAdminCe = new vSolicitudesAdminCE();
			vsolicitudesAdminCe.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});
	}

	this.Reject = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');
		var reject_service = this.service + '/' + data.IdSolicitud + '/reject' + '?cedulaFisica=' + window.localStorage.getItem('usuario').replace(/['"]+/g, '')
		this.ctrlActions.PutToRejectAPI(reject_service, data, function () {
			var vsolicitudesAdminCe = new vSolicitudesAdminCE();
			vsolicitudesAdminCe.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});
	}

}

$(document).ready(function () {

	var vsolicitudesAdminCe = new vSolicitudesAdminCE();
	vsolicitudesAdminCe.RetrieveAll();
	$("#txtId").prop('disabled', true);
	$("#txtApellido").prop('disabled', true);
	$("#txtFecha").prop('disabled', true);
	$("#txtCedula").prop('disabled', true);
	$("#txtNombre").prop('disabled', true);

});