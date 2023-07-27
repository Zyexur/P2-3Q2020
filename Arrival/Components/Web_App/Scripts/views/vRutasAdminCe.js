
function vRutasAdminCe() {

	this.tblMembresiasId = 'tblRutasAdminCe';
	this.service = 'ruta';
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();
	this.columns = "IdRuta,NombreRuta,Hora";


	this.RetrieveEmpresa = function () {
		var data = {};
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		this.ctrlActions.GetToApi("empresa?cedulafisica=" + cedulaFisica, function (response) {
			data = response;
			window.localStorage.setItem('centroeducativo', JSON.stringify(data[0].CedulaJuridica));
		});

	}

	this.RetrieveAll = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = "empresa?cedulaFisica=" + cedulaFisica;
		this.SetCedulaJuridica(url);
		this.ctrlActions.FillTable(this.service + "/" + cedulaFisica, this.tblMembresiasId, false);
	}

	this.ReloadTable = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		this.ctrlActions.FillTable(this.service + "/" + cedulaFisica, this.tblMembresiasId, true);
	}

	this.Create = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		data["CentroEducativo"] = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
		this.ctrlActions.PostReloadToAPI(this.service, data, function () {
			var vrutasadmince = new vRutasAdminCe();
			vrutasadmince.ReloadTable();
		});
		//this.ctrlActions.PostToAPI(this.service, data);
		//this.ReloadTable();
	}

	this.Asociate = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmAsociate');
		var e = document.getElementById("est-dpd");
		data.Estudiante = e.value;
		data["CentroEducativo"] = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
		this.ctrlActions.PostToAPI(this.service + "/asociar", data);
		this.ReloadTable();
	}

	this.Update = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		var tr = document.getElementById("tr-dpd");
		data.EmpresaTransporte = tr.value;
		this.ctrlActions.PutToApproveAPI(this.service, data, function () {
			var vrutasadmince = new vRutasAdminCe();
			vrutasadmince.ReloadTable();
		});
		//this.ctrlActions.PutToAPI(this.service, data);
		//this.ReloadTable();

	}

	this.Delete = function () {

		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.DeleteReloadToAPI(this.service, data, function () {
			var vrutasadmince = new vRutasAdminCe();
			vrutasadmince.ReloadTable();
		});
		//this.ctrlActions.DeleteToAPI(this.service, data);
		//this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
		this.ctrlActions.BindFields('frmAsociate', data);
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

	this.FillDropDowns = function () {
		this.FillDropDownTr();
		this.FillDropDownEst();
	}

	this.FillDropDownTr = function () {
		this.ctrlActions = new ControlActions();
		var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');

		var data = [];
		var url = 'empresa?cj=' + centroeducativo;
		this.ctrlActions.GetToApi(url, (response) => {
			data = response;

			console.log(data);
			data.forEach(item => {
				var html = `<option value=${item.CedulaJuridica}>${item.NombreJuridico}</option>`
				document.getElementById("tr-dpd").insertAdjacentHTML("beforeend", html);
			})
		})
	}

	this.FillDropDownEst = function () {
		this.ctrlActions = new ControlActions();
		var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');

		var data = [];
		var url = 'usuarioscentro?centroeducativoestudiante=' + centroeducativo;
		this.ctrlActions.GetToApi(url, (response) => {
			data = response;

			console.log(data);
			data.forEach(item => {
				var html = `<option value=${item.CedulaFisica}>${item.Nombre + " " + item.Apellido}</option>`
				document.getElementById("est-dpd").insertAdjacentHTML("beforeend", html);
			})
		})
    }

}

//ON DOCUMENT READY
$(document).ready(function(){
	var vrutasadmince = new vRutasAdminCe();
	$("#txtId").prop('disabled', true);
	vrutasadmince.RetrieveAll();
	vrutasadmince.RetrieveEmpresa();
	vrutasadmince.FillDropDowns();
});

function FillDropDowns() {
	FillDropDownTr();
	FillDropDownEst();
}

function FillDropDownEst() {
	this.ctrlActions = new ControlActions();
	var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');

	var data = [];
	var url = 'usuarioscentro?centroeducativoestudiante=' + centroeducativo;
	this.ctrlActions.GetToApi(url, (response) => {
		data = response;

		console.log(data);
		data.forEach(item => {
			var html = `<option value=${item.cedulaFisica}>${item.Nombre + " " + item.Apellido}</option>`
			document.getElementById("est-dpd").insertAdjacentHTML("beforeend", html);
		})
	})
}

function FillDropDownTr() {
	this.ctrlActions = new ControlActions();
	var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');

	var data = [];
	var url = 'empresa?cj=' + centroeducativo;
	this.ctrlActions.GetToApi(url, (response) => {
		data = response;

		console.log(data);
		data.forEach(item => {
			var html = `<option value=${item.CedulaJuridica}>${item.NombreJuridico}</option>`
			document.getElementById("tr-dpd").insertAdjacentHTML("beforeend", html);
		})
	})
}

function RetrieveEmpresa() {
	this.ctrlActions = new ControlActions();

	var data = {};
	var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
	this.ctrlActions.GetToApi("empresa?cedulafisica=" + cedulaFisica, function (response) {
		data = response;
		window.localStorage.setItem('centroeducativo', JSON.stringify(data[0].CedulaJuridica));
	});
}