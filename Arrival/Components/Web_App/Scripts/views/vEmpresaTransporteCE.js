function vEmpresaTransporteCE() {

	this.tblSolicitudes = 'tblSolicitudes';
	this.tblEmpresasTransporte = 'tblEmpresasTransporte';
	this.serviceEmpresa = 'empresa';
	this.serviceSolicitudes = 'SolicitudesTR_CE'
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();

	this.RetrieveTransportistas = function () {

		var cedulaJuridica = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
		var url = this.serviceEmpresa + "/Transportistas?cedulaCe=" + cedulaJuridica;
		this.ctrlActions.FillTable(url, this.tblEmpresasTransporte, false);
	}

	this.ReloadTable = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.serviceEmpresa + "?cedulaFisica=" + cedulaFisica;
		this.ctrlActions.FillTable(url, this.tblEmpresasTransporte, true);
	}

	this.BindFields = function (data) {
		localStorage.setItem("empresaTransporte", JSON.stringify(data));
	}

	this.RetrieveSolicitudes = function () {
		var cedulaJuridica = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
		var url = this.serviceSolicitudes + "?cedulaJuridica=" + cedulaJuridica;
		this.ctrlActions.FillTable(url, this.tblSolicitudes, false);
	}

	this.AprobarSolicitud = function () {
		$("#btnAprobar").click(()=> {
			var data = {};
			data = localStorage.getItem("empresaTransporte");
			data = JSON.parse(data)
			data.Estado = 'A';
			this.ctrlActions.PutToAPI(this.serviceSolicitudes, data);
		})
	}

	this.RechazarSolicitud = function () {
		$("#btnRechazar").click(()=> {
			var data = {};
			data = localStorage.getItem("empresaTransporte");
			this.ctrlActions.DeleteToAPI(this.serviceSolicitudes, data);
		})
	}

}

$(document).ready(function () {

	var empresaTransporteCE = new vEmpresaTransporteCE();
	empresaTransporteCE.RetrieveTransportistas();
	empresaTransporteCE.RetrieveSolicitudes();
	empresaTransporteCE.AprobarSolicitud();
	empresaTransporteCE.RechazarSolicitud();
});

