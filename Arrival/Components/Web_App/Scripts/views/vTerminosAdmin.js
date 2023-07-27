
function vTerminosAdmin() {

	this.formId = 'termsForm';
	this.service = 'Terminos';
	this.ctrlActions = new ControlActions();


	this.RegistrarTerminos = function () {
		var inputData = {};
		inputData.Apartado = document.getElementById("r-titulo").value;
		inputData.DescripcionApartado = document.getElementById("r-descripcion").value;
		this.ctrlActions.PostToAPI(this.service, inputData)
			.done(() => {
				$(".termsList").empty();
				this.MostrarTerminos();
				this.LimpiarInputs();
			})
	}

	this.Eliminar = () => {
		$("#delBtn").click((event) => {
			var itemId = sessionStorage.getItem("ItemId");
			console.log(itemId);
			this.ctrlActions.DeleteToAPI(this.service, { "IdApartado": itemId})
				.done(() => {
					$(".termsList").empty();
					this.MostrarTerminos();
					console.log("termino eliminado")
				})
		})
	}
	this.GetModifiedData = function () {
		$("#saveMod").click(() => {
			var data = {};
			data.IdApartado = sessionStorage.getItem("ItemId");
			data.Apartado = document.getElementById("m-titulo").value;
			data.DescripcionApartado = document.getElementById("m-descripcion").value;
			this.Modificar(data);
		})
		//sessionStorage.setItem("Apartado", titulo);
		//sessionStorage.setItem("DescripcionApartado", desc);
	}

	this.Modificar = (data) => {
		this.ctrlActions.PutToAPI(this.service, data)
			.done(() => {
				$(".termsList").empty();
				this.MostrarTerminos();
				console.log("termino modificado")
			})
    }

	this.LimpiarInputs = () => {
		$("#termsForm").filter(':input').each(function (input) {
			console.log(input);
		});
    }

	this.MostrarTerminos = function () {
		var respData = [];
		this.ctrlActions.GetToApi(this.service, (response) => {
			respData = response;
		})
			.done(() => {
				respData.forEach(item => {
					var html = this.InsertCardsHtml(item);
					$(".termsList").append(html);
					$(".cardsContainer").click(function () {
						$(this).css("background-color", "#f2f2f2");
						sessionStorage.setItem("ItemId", $(this).attr("id"));
						sessionStorage.setItem("Apartado", $(this > "#titulo").value);
					})
				})
			})
	}

	this.InsertCardsHtml = function (data) {
		var html = `
		<div class="cardsContainer" id="${data.IdApartado}">
			<h5 id="titulo">${data.Apartado}</h5>
			<div class="descripcion">${data.DescripcionApartado}</div>
		</div>
		`
		return html;
	}

	this.DisplayForm = () => {
		$("#addbtn").click( () => {
			console.log("entro");
			$(".termsForm").toggle("hidden");
		})
	}

}

$(document).ready(function () {
	var vterminos = new vTerminosAdmin();
	//sessionStorage.removeItem("ItemId");
	vterminos.MostrarTerminos();
	vterminos.DisplayForm();
	vterminos.Eliminar();
	vterminos.GetModifiedData();
	//vterminos.Modificar();
})