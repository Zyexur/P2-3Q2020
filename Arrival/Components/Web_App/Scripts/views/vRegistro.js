
function vRegistro() {

	this.formId = 'registrationForm';
	this.service = 'Usuario';
	this.ctrlActions = new ControlActions();

	this.Registrar = function () {

		var emptyInputs = this.ctrlActions.ValidateInputFields(this.formId);

		if (emptyInputs == false) {
			var data = {};
			data = this.ctrlActions.GetDataForm(this.formId);
			//data.Rol = "Administrador";
			var checkboxStatus = $("#r-CheckBox").prop("checked");
			if (checkboxStatus) {
				this.ctrlActions.PostToRegistroAPI(this.service, data, (response) => {
					var data = {};
					data = response.Data;
					if (response.Message === "OK") {
						this.ctrlActions.EnviarCorreo("Confirmación de cuenta", data);
						var smsMsj = `Confirmación de cuenta. Codigo de verificación: ${data.Codigo}.
					Ingrese el codigo de validacion en el siguiente enlace: "https://localhost:44339/Home/ValidarCuenta"`
						this.ctrlActions.EnviarSms(smsMsj, data);
						window.location.href = "https://localhost:44339/Home/ValidarCuenta";
					}
				});

			} else {
				alert("Debes aceptar los terminos y condiciones");
			}
		}else {
			alert("Hay campos vacios");
        }
	}

	this.RegistrarAdminG = function () {

		var emptyInputs = this.ctrlActions.ValidateInputFields(this.formId);

		if (emptyInputs == false) {
			var data = {};
			data = this.ctrlActions.GetDataForm(this.formId);
				this.ctrlActions.PostToRegistroAPI(this.service, data, (response) => {
					var data = {};
					data = response.Data;
					if (response.Message === "OK") {
						this.ctrlActions.EnviarCorreo("Confirmación de cuenta", data);
						var smsMsj = `Confirmación de cuenta. Codigo de verificación: ${data.Codigo}.
					Ingrese el codigo de validacion en el siguiente enlace: "https://localhost:44339/Home/ValidarCuenta"`
						this.ctrlActions.EnviarSms(smsMsj, data);
					}
				});
		} else {
			alert("Hay campos vacios");
		}
	}

	this.PromptText = function () {
		var html = `
		<div class="modal" tabindex="-1">
		  <div class="modal-dialog">
			<div class="modal-content">
			  <div class="modal-header">
				<h5 class="modal-title">Cuenta creada</h5>
				<button type="button" class="close" data-dismiss="modal" aria-label="Close">
				  <span aria-hidden="true">&times;</span>
				</button>
			  </div>
			  <div class="modal-body">
				<p>La cuenta se ha creado de forma exitosa</p>
			  </div>
			  <div class="modal-footer">
				<button type="button" class="btn btn-secondary" data-dismiss="modal">Ok</button>
			  </div>
			</div>
		  </div>
		</div>`

		document.querySelector(".container").insertAdjacentHTML('afterbegin', html);
	}

}

$(document).ready(function () {
	vregistro = new vRegistro();
	$("#registration_btn").click(function () {
		vregistro.Registrar();
	})
})