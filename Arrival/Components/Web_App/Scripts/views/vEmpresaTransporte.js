function vEmpresaTransporte() {

	this.tblId = 'tblEmpresaTransporte';
	this.service = 'empresa';
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();
	this.columns = "CedulaJuridica,NombreJuridico,Correo,NumTelefono,Coordenada,Estado";

	this.RetrieveAll = function () {

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service  + "?cedulaFisica=" + cedulaFisica;
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
		data.tipo = 'tr';
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + "?cedulaFisica=" + cedulaFisica;

		this.ctrlActions.PostReloadToAPI(url, data, function () {
			var vempresaTransporte = new vEmpresaTransporte();
			localStorage.setItem("cedulaJuridica", data.cedulaJuridica);
			vempresaTransporte.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});
	}

	this.Update = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.service + "?cedulaFisica=" + cedulaFisica;

		this.ctrlActions.PutReloadToAPI(url, data, function () {
			var vempresaTransporte = new vEmpresaTransporte();
			vempresaTransporte.ReloadTable();
			$(':input', '#frmGestion')
				.not(':button, :submit, :reset, :hidden')
				.val('');
		});
	}

	this.Delete = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmGestion');

		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');

		var url = this.service + "?cedulaFisica=" + cedulaFisica;

		this.ctrlActions.DeleteReloadToAPI(url, data, function () {
			var vempresaTransporte = new vEmpresaTransporte();
			vempresaTransporte.ReloadTable();
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
			} else{
				localStorage.setItem("cedulaJuridica", "");
            }
		})
	} 

}


$(document).ready(function () {

	var vempresaTransporte = new vEmpresaTransporte();
	vempresaTransporte.RetrieveAll();
	$("#txtEstado").prop('disabled', true);
});