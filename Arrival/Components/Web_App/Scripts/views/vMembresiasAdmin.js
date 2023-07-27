
function vMembresiasAdmin() {

	this.tblMembresiasId = 'tblMembresias';
	this.service = 'membresia';
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();
	this.columns = "IdMembresia,Nombre,Periodicidad,Monto";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblMembresiasId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblMembresiasId, true);
	}

	this.Create = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostReloadToAPI(this.service, data, function () {
			var vmembresiasadmin = new vMembresiasAdmin();
			vmembresiasadmin.ReloadTable();
		});

		var cedulaFisica = localStorage.getItem('usuario');

		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Membres\u00EDa creada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.Update = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToApproveAPI(this.service, data, function () {
			var vmembresiasadmin = new vMembresiasAdmin();
			vmembresiasadmin.ReloadTable();
		});

		var cedulaFisica = localStorage.getItem('usuario');
		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Membres\u00EDa actualizada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.Delete = function () {

		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteReloadToAPI(this.service, data, function () {
			var vmembresiasadmin = new vMembresiasAdmin();
			vmembresiasadmin.ReloadTable();
		});

		var cedulaFisica = localStorage.getItem("usuario");
		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Membres\u00EDa eliminada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vmembresias = new vMembresiasAdmin();
	vmembresias.RetrieveAll();

	$("#txtId").prop('disabled', true);

});

