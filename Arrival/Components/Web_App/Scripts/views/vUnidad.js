function vUnidad() {

	this.tblUnidades= 'tblUnidades';
	this.service = 'Unidad';
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();
	this.columns = "Placa,Modelo,Marca,Anno,Tamano,Capacidad,Color,IdEmpresa,IdRuta,IdChofer";

	this.RetrieveAll = function () {
		var centroeducativo = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
		this.ctrlActions.FillTable(this.service + "/" + centroeducativo, this.tblUnidades, false);
	}

	this.ReloadTable = function () {
		var centroeducativo = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
		this.ctrlActions.FillTable(this.service + "/" + centroeducativo, this.tblUnidades, true);
	}

	this.Create = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');

		this.ctrlActions.PostReloadToAPI(this.service, data, function () {
			var vunidad = new vUnidad();
			vunidad.ReloadTable();
		});

		var cedulaFisica = localStorage.getItem('usuario');

		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Unidad creada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.Update = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');

		this.ctrlActions.PutToApproveAPI(this.service, data, function () {
			var vunidad = new vUnidad();
			vunidad.ReloadTable();
		});

		var cedulaFisica = localStorage.getItem('usuario');

		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Unidad actualizada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.Delete = function () {

		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');

		this.ctrlActions.DeleteReloadToAPI(this.service, data, function () {
			var vunidad = new vUnidad();
			vunidad.ReloadTable();
		});

		var cedulaFisica = localStorage.getItem('usuario');

		var arreglo = cedulaFisica.replace(/['"]+/g, '');

		var accion = 'Unidad eliminada';

		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vunidades = new vUnidad();
	vunidades.RetrieveAll();

});
