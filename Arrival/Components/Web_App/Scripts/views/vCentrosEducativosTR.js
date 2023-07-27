function vCentrosEducativosTR() {

	this.tblId = 'tblCentrosAsociados';
	this.servicioEmpresa = 'Empresa';
	this.servicioSolicitud = 'SolicitudesTR_CE';
	this.serviceBitacora = 'Bitacora';
	this.ctrlActions = new ControlActions();

	this.columns = "CedulaJuridica,NombreJuridico,Correo,NumTelefono,Coordenada,Estado";

	this.RetrieveAll = function () {

		var cedulaJuridica = window.localStorage.getItem('cedulaJuridica').replace(/['"]+/g, '');
		var url = this.servicioEmpresa + "/CentrosEducativos?cedulaTr=" + cedulaJuridica;
		this.ctrlActions.FillTable(url, this.tblId, false);
		
	}

	this.ReloadTable = function () {
		var cedulaFisica = window.localStorage.getItem('usuario').replace(/['"]+/g, '');
		var url = this.service + "?cedulaFisica=" + cedulaFisica;
		this.ctrlActions.FillTable(url, this.tblId, true);
	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmGestion', data);
	}

	this.FillDropDown = function () {
		var data = [];
		var url = this.servicioEmpresa + '/CentrosEducativos';
		this.ctrlActions.GetToApi(url, (response) => {
			data = response;

			data.forEach(item => {
				var html = `<option value=${item.CedulaJuridica}>${item.NombreJuridico}</option>`
				document.getElementById("school-dpd").insertAdjacentHTML("beforeend", html);
			})
		})
	}

	this.GetSelectedCE = function () {
		$("#school-dpd").change(function () {
			localStorage.setItem("cedulaCE", this.value);
		})
	}

	this.EnviarSolicitud = function () {
		$("#sendReq").click(()=> {
			var data = {};
			data.CedulaCE = localStorage.getItem("cedulaCE");
			data.CedulaTR = localStorage.getItem("cedulaJuridica");
			this.ctrlActions.PostToAPI(this.servicioSolicitud, data)
				.done(function (response) {
					if (response.Message == 'existe') {
						var html = this.InsertModal("Error", "No se puede enviar la solicitud", "Ya se ha enviado una solicitud a este centro educativo");

                    }
				})
		})
	}

	this.InsertModal = function (title, subTitle, body) {
		var html =
			`
        <div class="container">
          <h2>${title}</h2>
          <!-- Trigger the modal with a button -->
          <button type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal">Open Small Modal</button>

          <!-- Modal -->
          <div class="modal fade" id="myModal" role="dialog">
            <div class="modal-dialog modal-sm">
              <div class="modal-content">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
                  <h4 class="modal-title">${subTitle}</h4>
                </div>
                <div class="modal-body">
                  <p>${body}</p>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
              </div>
            </div>
          </div>
        </div>

        </body>
        </html>
        `
		return html;
	}

}

$(document).ready(function () {

	var centrosEducativosTR = new vCentrosEducativosTR();
	centrosEducativosTR.RetrieveAll();
	centrosEducativosTR.FillDropDown();
	centrosEducativosTR.GetSelectedCE();
	centrosEducativosTR.EnviarSolicitud();
})

