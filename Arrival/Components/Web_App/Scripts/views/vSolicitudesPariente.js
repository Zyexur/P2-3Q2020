function vSolicitudesPariente() {

	this.tblId = 'tblSolicitudes';
	this.service = 'solicitudestudiante/pariente?cedulaFisicaPariente=';
	this.ctrlActions = new ControlActions();
	this.columns = "IdSolicitud,FechaCreacion,NombreJuridico,Nombre,Apellido,Estado";

	this.FillDropDown = function () {
		var data = [];
		var url = 'empresa/CentrosEducativos';
		this.ctrlActions.GetToApi(url, (response) => {
			data = response;
			data.forEach(item => {
				var html = `<option value=${item.CedulaJuridica}>${item.NombreJuridico}</option>`
				document.getElementById("school-dpd").insertAdjacentHTML("beforeend", html);
            })
        })
	}

	this.FillDropDownEstudiante = function () {
		var data = [];
		var url = 'usuario/pariente/estudiantes?cedulaFisicaPariente=' + window.localStorage.getItem('usuario').replace(/['"]+/g, '') + '&sin_centro=true';
		this.ctrlActions.GetToApi(url, (response) => {
			data = response;
			data.forEach(item => {
				var html = `<option value=${item.CedulaFisica}>${item.Nombre + ' ' + item.Apellido}</option>`
				document.getElementById("estudiantes").insertAdjacentHTML("beforeend", html);
			})
		})
	}

	this.RetrieveAll = function () {

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + cedulaFisica;
		this.ctrlActions.FillTable(url, this.tblId, false);
	}

	this.ReloadTable = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + cedulaFisica;
		this.ctrlActions.FillTable(url, this.tblId, true);
	}

	this.BindFields = function (data) {
	}

	this.Register = function () {
		var data = {};
		var e = document.getElementById("estudiantes");
		data.CedulaFisica = e.value;
		var s = document.getElementById("school-dpd")
		data.CedulaJuridica = s.value;

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.service + cedulaFisica;

		this.ctrlActions.PostReloadToAPI(url, data, function () {
			var vsolicitudesPariente = new vSolicitudesPariente();
			vsolicitudesPariente.ReloadTable();
			$('#estudiantes').empty().append('<option selected disabled>Seleccione el estudiante</option>');
			vsolicitudesPariente.FillDropDownEstudiante();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});

	}
}

$(document).ready(function () {

	var vsolicitudesPariente = new vSolicitudesPariente();
	vsolicitudesPariente.RetrieveAll();
	vsolicitudesPariente.FillDropDown();
	vsolicitudesPariente.FillDropDownEstudiante();

});