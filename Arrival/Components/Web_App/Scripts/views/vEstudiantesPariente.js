function vEstudiantesPariente() {

	this.tblId = 'tblEstudiantesPariente';
	this.service = 'usuario/pariente/estudiantes?cedulaFisicaPariente=';
	this.ctrlActions = new ControlActions();
	this.columns = "CedulaFisica,Nombre,Apellido,Correo,NumTelefono,FechaNacimiento,Coordenada,EstadoUsuario";

	this.RetrieveAll = function () {

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + cedulaFisica + '&sin_centro=false';
		this.ctrlActions.FillTable(url, this.tblId, false);
	}

	this.ReloadTable = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + cedulaFisica + '&sin_centro=false';
		this.ctrlActions.FillTable(url, this.tblId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFieldsCallback('frmGestion', data, function () {
			$("#txtId").prop('disabled', true);
			document.getElementById("btnRegister").style.display = "none";
		});
	}

	this.Register = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');
		data.Rol = 'Estudiante';

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.service + cedulaFisica;

		this.ctrlActions.PostReloadToAPI(url, data, function () {
			var vestudiantesPariente = new vEstudiantesPariente();
			vestudiantesPariente.ReloadTable();
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
			var vestudiantesPariente = new vEstudiantesPariente();
			vestudiantesPariente.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
			$("#txtId").prop('disabled', false);
			document.getElementById("btnRegister").style.display = "inline";
		});
	}

	this.Delete = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var register_service = this.service + "?cedulaFisica=" + cedulaFisica;

		this.ctrlActions.DeleteReloadToAPI(register_service, data, function () {
			var vestudiantesPariente = new vEstudiantesPariente();
			vestudiantesPariente.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
			$("#txtId").prop('disabled', false);
			document.getElementById("btnRegister").style.display = "inline";
		});
	}
}

$(document).ready(function () {

	var vestudiantesPariente = new vEstudiantesPariente();
	vestudiantesPariente.RetrieveAll();
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