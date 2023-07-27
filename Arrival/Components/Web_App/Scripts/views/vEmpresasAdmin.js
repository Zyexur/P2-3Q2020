
function vEmpresasAdmin() {

	this.tableId = 'tblEmpresasAdmin';
	this.service = 'empresa';
	this.ctrlActions = new ControlActions();
	this.columns = "CedulaJuridica,NombreJuridico,Correo,NumTelefono,Tipo,Estado";

	this.RetrieveAll = function () {
		var url = this.service + '/' + 'Transportistas';
		this.ctrlActions.FillTable(url, this.tableId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tableId, true);
	}

	//this.Create = function () {
	//	var data = {};
	//	data = this.ctrlActions.GetDataForm('frmCreate');
	//	//Hace el post al create
	//	this.ctrlActions.PostToAPI(this.service, data);
	//	//Refresca la tabla
	//	this.ReloadTable();
	//}

	//this.Update = function () {
	//	var data = {};
	//	data = this.ctrlActions.GetDataForm('frmEdition');
	//	//Hace el post al create
	//	this.ctrlActions.PutToAPI(this.service, data);
	//	//Refresca la tabla
	//	this.ReloadTable();
	//}

	//this.Delete = function () {

	//	var data = {};
	//	data = this.ctrlActions.GetDataForm('frmDelete');
	//	//Hace el post al create
	//	this.ctrlActions.DeleteToAPI(this.service, data);
	//	//Refresca la tabla
	//	this.ReloadTable();
	//}

	//this.BindFields = function (data) {
	//	this.ctrlActions.BindFields('frmEdition', data);
	//	this.ctrlActions.BindFields('frmDelete', data);
	//}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vempresasadmin = new vEmpresasAdmin();
	vempresasadmin.RetrieveAll();

});

