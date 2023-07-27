function vCentroEducativoAdminCe() {

	this.tblId = 'tblCentroEducativoAdminCe';
	this.service = 'empresa';
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();
	this.columns = "CedulaJuridica,NombreJuridico,Correo,NumTelefono,Coordenada,Estado";

	this.RetrieveAll = function () {

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + "?cedulaFisica=" +cedulaFisica;
		this.ctrlActions.FillTableEmpresa(url, this.tblId, false);
		this.SetCedulaJuridica(url);
	}

	this.ReloadTable = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + "?cedulaFisica=" + cedulaFisica;
		this.ctrlActions.FillTable(url, this.tblId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmGestion', data);
	}

	this.Register = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');
		data.tipo = 'ce';

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var register_service = this.service + "?cedulaFisica=" + cedulaFisica;

		this.ctrlActions.PostReloadToAPI(register_service, data, function () {
			var vcentroEducativoAdminCe = new vCentroEducativoAdminCe();
			vcentroEducativoAdminCe.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});
	}

	this.Update = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var register_service = this.service + "?cedulaFisica=" + cedulaFisica;

		this.ctrlActions.PutReloadToAPI(register_service, data, function () {
			var vcentroEducativoAdminCe = new vCentroEducativoAdminCe();
			vcentroEducativoAdminCe.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});
	}

	this.Delete = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var register_service = this.service + "?cedulaFisica=" + cedulaFisica;

		this.ctrlActions.DeleteReloadToAPI(register_service, data, function () {
			var vcentroEducativoAdminCe = new vCentroEducativoAdminCe();
			vcentroEducativoAdminCe.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
			$("#txtId").prop('disabled', false);
			document.getElementById("btnRegister").style.display = "inline";
		});
	}

	this.SetCedulaJuridica = function (url) {
		this.ctrlActions.GetToApi(url, (response) => {
			console.log(response);
			if (response != null) {
				localStorage.setItem("cedulaJuridica", response[0].CedulaJuridica);
			} else {
				localStorage.setItem("cedulaJuridica", "");
			}
		})
	} 
}

$(document).ready(function () {

	var vcentroEducativoAdminCe = new vCentroEducativoAdminCe();
	vcentroEducativoAdminCe.RetrieveAll();
	$("#txtEstado").prop('disabled', true);
	$("#txtCoordenada").prop('disabled', true);

	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(function (position) {
			var longitud = position.coords.longitude;
			var latitud = position.coords.latitude
			guardarCoordenadas(longitud, latitud);
		}, function () { }, { timeout: 5000 });
	} else {
		console.log('Error de longitud y latitud');
	}

	function guardarCoordenadas(plongitud, platitud) {
		localStorage.setItem('longitud', plongitud);
		localStorage.setItem('latitud', platitud);
		document.getElementById("txtCoordenada").value = plongitud + "," + platitud;
	}

});