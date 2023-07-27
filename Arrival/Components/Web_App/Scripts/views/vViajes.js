function vViajes() {

	this.tblViajeId = 'tblViaje';
	this.tblEstudianteId = 'tblEstudiantes'
	this.serviceViaje = 'viaje'
	this.serviceEstudiantes = 'usuario/estudiantes/ruta?cedulaFisicaChofer='
	this.ctrlActions = new ControlActions();
	this.columnsViaje = "IdViaje,NombreRuta,Estado"
	this.columnsEstudiantes = "CedulaFisica,Nombre,Apellido"

	this.FillDropDownEstudiante = function () {
		var data = [];
		var url = this.serviceEstudiantes + window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		this.ctrlActions.GetToApi(url, (response) => {
			data = response;
			data.forEach(item => {
				var html = `<option value=${item.CedulaFisica}>${item.Nombre + ' ' + item.Apellido}</option>`
				document.getElementById("estudiantes").insertAdjacentHTML("beforeend", html);
			})
		})
	}

	this.RetrieveViaje = function () {

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.serviceViaje + '?cedulaFisicaChofer=' + cedulaFisica;
		this.ctrlActions.FillTableViaje(url, this.tblViajeId, false);
	}

	this.ReloadTableViaje = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.serviceViaje + '?cedulaFisicaChofer=' + cedulaFisica;
		this.ctrlActions.FillTableViaje(url, this.tblViajeId, true);
	}

	this.BindFields = function (data) {
	}

	this.Abordaje = function () {

		var data = {};
		data.CedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.serviceViaje;

		this.ctrlActions.PostReloadToAPI(url, data, function () {
			var vviajes = new vViajes();
			vviajes.ReloadTableViaje();
		});
	}

	this.Start = function () {

		var data = {};
		data.CedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.serviceViaje;

		this.ctrlActions.PutReloadToAPI(url, data, function () {
			var vviajes = new vViajes();
			vviajes.ReloadTableViaje();
			vviajes.ReloadTableEstudiantes();
		});
	}

	this.End = function () {

		var data = {};
		data.CedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.serviceViaje;

		this.ctrlActions.DeleteReloadToAPI(url, data, function () {
			var vviajes = new vViajes();
			vviajes.ReloadTableViaje();
			vviajes.ReloadTableEstudiantes();
		});
	}

	this.Add = function () {

		var data = {};

		var e = document.getElementById("estudiantes")
		var cedulaFisicaEstudiante = e.value;

		var cedulaFisicaChofer = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.serviceViaje + '/estudiantes/add?cedulaFisicaChofer=' + cedulaFisicaChofer + '&cedulaFisicaEstudiante=' + cedulaFisicaEstudiante;

		this.ctrlActions.PostReloadToAPI(url, data, function () {
			var vviajes = new vViajes();
			vviajes.ReloadTableViaje();
			vviajes.ReloadTableEstudiantes();
		});

	}

	this.Remove = function () {

		var data = {};

		var e = document.getElementById("estudiantes")
		var cedulaFisicaEstudiante = e.value;

		var cedulaFisicaChofer = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.serviceViaje + '/estudiantes/remove?cedulaFisicaChofer=' + cedulaFisicaChofer + '&cedulaFisicaEstudiante=' + cedulaFisicaEstudiante;

		this.ctrlActions.DeleteReloadToAPI(url, data, function () {
			var vviajes = new vViajes();
			vviajes.ReloadTableViaje();
			vviajes.ReloadTableEstudiantes();
		});

	}

	this.RetrieveEstudiantes = function () {

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.serviceViaje + '/estudiantes?cedulaFisicaChofer=' + cedulaFisica;
		this.ctrlActions.FillTable(url, this.tblEstudianteId, false);
	}

	this.ReloadTableEstudiantes = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.serviceViaje + '/estudiantes?cedulaFisicaChofer=' + cedulaFisica;
		this.ctrlActions.FillTable(url, this.tblEstudianteId, true);
	}
}

$(document).ready(function () {

	var vviajes = new vViajes();
	vviajes.RetrieveViaje();
	vviajes.RetrieveEstudiantes();
	vviajes.FillDropDownEstudiante();
});