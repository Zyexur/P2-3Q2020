function vInicioSesion() {

	this.service = 'usuario/iniciar';
	this.ctrlActions = new ControlActions();

	this.IniciarSesion = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frm-inicio');
		this.ctrlActions.PostToIniciarSesionAPI(this.service, data);
	}
}

$(document).ready(function () {
	vinicioSesion = new vInicioSesion();
	//window.localStorage.removeItem('usuario');
	//window.localStorage.removeItem('rol');
	window.localStorage.clear();
});