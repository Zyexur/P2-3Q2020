function vContrasenna() {

	this.service = 'contrasenna';
	this.ctrlActions = new ControlActions();
	this.columns = "Correo,Contrasenna";

	this.Create = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frm-registro-contrasenna');
		//Hace el post al create
		this.ctrlActions.PostToContrasennaAPI(this.service, data);
	}

	this.Retrieve = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frm-recupera-contrasenna');
		//this.ctrlActions.GetToApi("contrasenna?correo=" + data.Correo, function (response) {
		//	data = response;
		//	console.log(data);
		//});
		this.ctrlActions.GetToApiContrasenna("contrasenna?correo=" + data.Correo, function (response) {
			data = response;
			console.log(data);
		});
		//this.ctrlActions.EnviarCorreoContrasenna("Recuperación de la contraseña", data);
	}
	
}

$(document).ready(function () {
	vcontrasenna = new vContrasenna();
});