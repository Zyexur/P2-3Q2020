

function vValidarCuenta() {

	this.formId = 'validationForm';
	this.service = 'Usuario';
	this.ctrlActions = new ControlActions();

	this.ValidarCodigo = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm(this.formId);
		this.ctrlActions.GetByIdToApi(this.service, data, (response) => {
			if (response.Codigo) {
				window.location.href = "https://localhost:44339/Home/RegistrarContrasenna";				
			} else {
				alert("El codigo es incorrecto");
            }
		})
	}
}
$(document).ready(function () {
	validarcuenta = new vValidarCuenta();
})