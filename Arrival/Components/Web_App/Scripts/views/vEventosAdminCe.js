
function vEventosAdminCe() {

	this.tblMembresiasId = 'tblEventosAdminCe';
	this.service = 'actividadespecial';
	this.serviceBitacora = 'Bitacora';
	this.serviceget = 'actividadespecial?centroeducativo=';
	this.ctrlActions = new ControlActions();
	this.columns = "IdActividad,Nombre,Desc,CoorFinal";

	this.RetrieveAll = function () {
		var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
		this.ctrlActions.FillTable(this.serviceget + centroeducativo, this.tblMembresiasId, false);
	}

	this.ReloadTable = function () {
		var centroeducativo = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
		this.ctrlActions.FillTable(this.serviceget + centroeducativo, this.tblMembresiasId, true);
	}

	this.Create = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		data["CentroEducativo"] = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
		this.ctrlActions.PostReloadToAPI(this.service, data, function () {
			var veventosadmince = new vEventosAdminCe();
			veventosadmince.ReloadTable();
		});

		//this.ctrlActions.PostToAPI(this.service, data);
		//this.ReloadTable();

		var cedulaFisica = localStorage.getItem("usuario");
		var arreglo = cedulaFisica.replace(/['"]+/g, '');
		var accion = 'Evento creado';
		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.Asociate = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmAsociate');
		data["CentroEducativo"] = window.localStorage.getItem('centroeducativo').replace(/['"]+/g, '');
		this.ctrlActions.PostToAPI(this.service + "/asociar", data);
		this.ReloadTable();
	}

	this.Update = function () {
		var data = {};
		data = this.ctrlActions.GetDataForm('frmEdition');
		this.ctrlActions.PutToApproveAPI(this.service, data, function () {
			var veventosadmince = new vEventosAdminCe();
			veventosadmince.ReloadTable();
		});
		//this.ctrlActions.PutToAPI(this.service, data);
		//this.ReloadTable();

		var cedulaFisica = localStorage.getItem('usuario');
		var arreglo = cedulaFisica.replace(/['"]+/g, '');
		var accion = 'Evento actualizado';
		var info = { 'Accion': accion, 'CedulaFisica': arreglo };
		this.ctrlActions.PostBitacoraApi(this.serviceBitacora, info);
	}

	this.Delete = function () {

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
		this.ctrlActions.BindFields('frmAsociate', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	$("#txtId").prop('disabled', true);
	$("#txtCoorFinal").prop('disabled', true);
	$("#txtIdAsc").prop('disabled', true);
	$("#txtNombreAsc").prop('disabled', true);

	var veventosadmince = new vEventosAdminCe();
	veventosadmince.RetrieveAll(this.serviceget);
	FillDropDowns();	

	mapboxgl.accessToken = 'pk.eyJ1IjoiYWJsYW5jb2NlbmZvIiwiYSI6ImNrODNud2lrdzB6NDQzZnBxZzh1cmZ6ZnEifQ.zM2OTXbSt4-hq2FzCB7WkQ';
	var coordinates = document.getElementById('coordinates');
	var map = new mapboxgl.Map({
		container: 'map', 
		style: 'mapbox://styles/mapbox/streets-v11', 
		zoom: 13
	});
	map.addControl(
		new MapboxGeocoder({
			accessToken: mapboxgl.accessToken,
			//marker: false
			marker: {
				color: 'green'
			},
			mapboxgl: mapboxgl
		})
	);


	if (navigator.geolocation) {
		navigator.geolocation.getCurrentPosition(function (position) {
			var longitud = position.coords.longitude;
			var latitud = position.coords.latitude
			guardarCoordenadas(longitud, latitud);

			map.setCenter({ lon: position.coords.longitude, lat: position.coords.latitude })//cambio

		}, function () { }, { timeout: 5000 });
	} else {
		console.log('Error de longitud y latitud');
	}

	function guardarCoordenadas(plongitud, platitud) {
	localStorage.setItem('longitud', plongitud);
	localStorage.setItem('latitud', platitud);
	}

	var canvas = map.getCanvasContainer();
	//var longitud = window.localStorage.getItem('longitud').replace(/['"]+/g, '');
	var latitud = window.localStorage.getItem('latitud').replace(/['"]+/g, '');
	var longitud = window.localStorage.getItem('longitud');
	//var latitud = window.localStorage.getItem('latitud');

	var geojson = {
		'type': 'FeatureCollection',
		'features': [
			{
				'type': 'Feature',
				'geometry': {
					'type': 'Point',
					'coordinates': [longitud, latitud]
				}
			}
		]
	};

	function onMove(e) {
		var coords = e.lngLat;
		canvas.style.cursor = 'grabbing';
		geojson.features[0].geometry.coordinates = [coords.lng, coords.lat];
		map.getSource('point').setData(geojson);
	}

	function onUp(e) {
		var coords = e.lngLat;
		console.log(coords);
		// Imprime las coordenadas del punto
		coordinates.style.display = 'block';
		document.getElementById("txtCoorFinal").value = coords.lng + "," + coords.lat;
		canvas.style.cursor = '';

		map.off('mousemove', onMove);
		map.off('touchmove', onMove);
	}

	map.on('load', function () {
		map.addSource('point', {
			'type': 'geojson',
			'data': geojson
		});

		map.addLayer({
			'id': 'point',
			'type': 'circle',
			'source': 'point',
			'paint': {
				'circle-radius': 10,
				'circle-color': '#3887be'
			}
		});

		map.on('mouseenter', 'point', function () {
			map.setPaintProperty('point', 'circle-color', '#3bb2d0');
			canvas.style.cursor = 'move';
		});

		map.on('mouseleave', 'point', function () {
			map.setPaintProperty('point', 'circle-color', '#3887be');
			canvas.style.cursor = '';
		});

		map.on('mousedown', 'point', function (e) {
			e.preventDefault();
			canvas.style.cursor = 'grab';
			map.on('mousemove', onMove);
			map.once('mouseup', onUp);
		});

		map.on('touchstart', 'point', function (e) {
			if (e.points.length !== 1) return;
			e.preventDefault();
			map.on('touchmove', onMove);
			map.once('touchend', onUp);
		});
	});

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
			var html = `<option value=${item.cedulaFisica}>${item.Nombre + " " + item.Apellido}</option>`
			document.getElementById("tr-dpd").insertAdjacentHTML("beforeend", html);
		})
	})
}
