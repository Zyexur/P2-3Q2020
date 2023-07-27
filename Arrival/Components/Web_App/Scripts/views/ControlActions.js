function ControlActions() {

    this.URL_API = "https://localhost:44345/api/";

    this.GetUrlApiService = function (service) {
        return this.URL_API + service;
    };

    this.GetModal = function (title, subTitle, body) {
        var html = this.modal.InsertHtml(title, subTitle, body);
        return html;
    }

    this.GetTableColumsDataName = function (tableId) {
        var val = $('#' + tableId).attr("ColumnsDataName");

        return val;
    };

    this.FillTable = function (service, tableId, refresh) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];

            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "language": {
                    "lengthMenu": "Mostrando _MENU_ registros",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                    "infoEmpty": "Mostrando 0 de 0 registros",
                    "emptyTable": "No hay datos disponibles",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "No se encontraron resultados",
                    "paginate": {
                        "first": "Primera",
                        "last": "Final",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },
                "processing": true,
                select: {
                    style: 'single'
                },
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data'
                },
                "columns": arrayColumnsData
            });
        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }

    };

    this.FillTableEmpresa = function (service, tableId, refresh) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "bInfo": false,
                "ordering": false,
                "bFilter": false,
                "paging": false,
                "processing": true,
                select: {
                    style: 'single'
                },
                "language": {
                    "lengthMenu": "Mostrando _MENU_ registros",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                    "infoEmpty": "Mostrando 0 de 0 registros",
                    "emptyTable": "No hay datos disponibles",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "No se encontraron resultados",
                    "paginate": {
                        "first": "Primera",
                        "last": "Final",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    },
                },
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data'
                },
                "columns": arrayColumnsData,
                "drawCallback": function (settings) {
                    var table = $('#' + tableId).DataTable();

                    if (table.data().any()) {
                        $("#txtId").prop('disabled', true);
                        document.getElementById("btnRegister").style.display = "none";
                    }
                }
            });
        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }

    };

    this.FillTableViaje = function (service, tableId, refresh) {

        if (!refresh) {
            columns = this.GetTableColumsDataName(tableId).split(',');
            var arrayColumnsData = [];


            $.each(columns, function (index, value) {
                var obj = {};
                obj.data = value;
                arrayColumnsData.push(obj);
            });

            $('#' + tableId).DataTable({
                "bInfo": false,
                "ordering": false,
                "bFilter": false,
                "paging": false,
                "processing": true,
                select: {
                    style: 'single'
                },
                "language": {
                    "lengthMenu": "Mostrando _MENU_ registros",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
                    "infoEmpty": "Mostrando 0 de 0 registros",
                    "emptyTable": "No hay viajes en curso",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "No se encontraron resultados",
                    "paginate": {
                        "first": "Primera",
                        "last": "Final",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    },
                },
                "ajax": {
                    "url": this.GetUrlApiService(service),
                    dataSrc: 'Data'
                },
                "columns": arrayColumnsData,
                "drawCallback": function (settings) {
                    var table = $('#' + tableId).DataTable();

                    if (table.data().any()) {
                        document.getElementById("btnAbordaje").style.display = "none";
                        document.getElementById("tblEstudianteswrapper").style.display = "inline";
                        document.getElementById("frmEstudiantes").style.display = "inline";
                        document.getElementById("btnStart").style.display = "inline";
                        document.getElementById("btnEnd").style.display = "inline";
                    } else {
                        document.getElementById("btnAbordaje").style.display = "inline";
                        document.getElementById("btnStart").style.display = "none";
                        document.getElementById("btnEnd").style.display = "none";
                        document.getElementById("tblEstudianteswrapper").style.display = "none";
                        document.getElementById("frmEstudiantes").style.display = "none";
                    }
                }
            });
        } else {
            //RECARGA LA TABLA
            $('#' + tableId).DataTable().ajax.reload();
        }

    };

    this.GetSelectedRow = function () {
        var data = sessionStorage.getItem(tableId + '_selected');

        return data;
    };

    this.BindFields = function (formId, data) {
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];
        });
    };

    this.BindFieldsCallback = function (formId, data, callbackFunction) {
        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            this.value = data[columnDataName];
            callbackFunction();
        });
    };


    this.GetDataForm = function (formId) {
        var data = {};

        $('#' + formId + ' *').filter(':input').each(function (input) {
            var columnDataName = $(this).attr("ColumnDataName");
            data[columnDataName] = this.value;
        });
        return data;
    };

    this.GetSelectedOptions = function (formId) {
        var options = {};
        console.log($('#' + formId + '*').children().children().filter('select'));
        $('#' + formId + '*').children().children().filter('select').each(function () {
            var optionId = $(this).attr("id");
            options[optionId] = this.value;
        });
    }

	this.ShowMessage = function (type,message) {
		//if (type == 'E') {
		//	$("#alert_container").removeClass("alert alert-success alert-dismissable")
		//	$("#alert_container").addClass("alert alert-danger alert-dismissable");
		//	$("#alert_message").text(message);
		//} else if (type == 'I') {
		//	$("#alert_container").removeClass("alert alert-danger alert-dismissable")
		//	$("#alert_container").addClass("alert alert-success alert-dismissable");
		//	$("#alert_message").text(message);
		//}
        //  $('.alert').show();
        if (type == 'E') {
            $("#modal-cnt").removeClass("bg-success")
            $("#modal-cnt").addClass("bg-danger");
            $(".modal-title").text("Error");
            $(".modal-message").text(message);
        } else if (type == 'I') {
            $("#modal-cnt").removeClass("bg-danger")
            $("#modal-cnt").addClass("bg-success");
            $(".modal-title").text("Ok");
            $(".modal-message").text(message);
        }
        $('#exampleModalCenter').modal('show')
    };

    this.EnviarCorreoContrasenna = function (subject, data) {
        var emailData = {};
        var html = this.InsertHtmlContrasenna(data);
        emailData.To = data.Correo;
        emailData.Subject = subject;
        emailData.Body = html;
        this.PostToAPI("Email/SendMail", emailData);
    }

	this.PostToAPI = function (service, data) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
            })
        return jqxhr;
    };

    this.PostReloadToAPI = function (service, data, callbackFunction) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            callbackFunction();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
        return jqxhr;
    };

	this.PostToRegistroAPI = function (service, data, callbackFunction) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			console.log(JSON.stringify(response));
			callbackFunction(response);
			var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
	};


	this.PostToIniciarSesionAPI = function (service, data) {
		var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
			var ctrlActions = new ControlActions();
			window.localStorage.setItem('usuario', JSON.stringify(response.Data.CedulaFisica));
            window.localStorage.setItem('rol', JSON.stringify(response.Data.Rol));
            var rol = response.Data.Rol
            switch (rol) {
                case "Administrador General":
                    window.location.href = 'SolicitudesAdmin';
                    break;
                case "Administrador Centro Educativo":
                    window.location.href = 'RutasAdminCe';
                    break;
                case "Transportista":
                    window.location.href = 'EmpresaTransporte';
                    break;
                case "Pariente":
                    window.location.href = 'EstudiantesPariente';
                    break;
                case "Chofer":
                    window.location.href = 'Viajes';
                    break;
                default:
                    window.location.href = 'LandingPage';
            };
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
				console.log(data);
			})
    };

    this.PostToContrasennaAPI = function (service, data) {
        var jqxhr = $.post(this.GetUrlApiService(service), data, function (response) {
            //console.log(JSON.stringify(response.Data));
            //callbackFunction(response.Data);
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .then(function (response) {              
                window.location.href = 'InicioSesion';
            })

            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };


    this.PostBitacoraApi = function (service, info) {
        var jqxhr = $.post(this.GetUrlApiService(service), info, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
    };


	this.PutToAPI = function (service, data) {
		var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
			ctrlActions.ShowMessage('I', response.Message);
		})
			.fail(function (response) {
				var data = response.responseJSON;
				var ctrlActions = new ControlActions();
				ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
        return jqxhr;
    };

    this.PutReloadToAPI = function (service, data, callbackFunction) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            callbackFunction();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
        return jqxhr;
    };

    this.PutToRejectAPI = function (service, data, callbackFunction) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            callbackFunction();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
    };

    this.PutToApproveAPI = function (service, data, callbackFunction) {
        var jqxhr = $.put(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            callbackFunction();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
    };

    
    this.DeleteToAPI = function (service, data) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (e) {
                console.log("Fail")
                var data = e.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
        return jqxhr;
    };

    this.DeleteReloadToAPI = function (service, data, callbackFunction) {
        var jqxhr = $.delete(this.GetUrlApiService(service), data, function (response) {
            var ctrlActions = new ControlActions();
            callbackFunction();
            ctrlActions.ShowMessage('I', response.Message);
        })
            .fail(function (e) {
                console.log("Fail")
                var data = e.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
                console.log(data);
            })
        return jqxhr;
    };


    this.GetToApi = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            callbackFunction(response.Data);
        });
        return jqxhr;
    };

    this.GetByIdToApi = function (service, data, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), data, function (response) {
            callbackFunction(response.Data);
        })
    }

    this.ValidateInputFields = (formId) => {
        var x = false;
        $('#' + formId + ' *').filter(".form-control").each(function (i, value) {
            console.log(i);
            console.log(value);
            if (value.value == "") {
                $(value).css("border", "1px solid red");
                x = true;
            }
        });
        return x;
    };


    this.EnviarCorreo = function (subject, data) {
        var emailData = {};
        var html = this.InsertHtml(data);
        emailData.To = data.Correo;
        emailData.Subject = subject;
        emailData.Body = html;
        this.PostToAPI("Email/SendMail", emailData);
    };

    this.EnviarSms = function (msj, data) {
        var smsData = {};
        smsData.To = data.NumTelefono;
        smsData.Body = msj;
        this.PostToAPI("Sms/SendSms", smsData);
    };

    //Custom jquery actions
    $.post = function (url, data, callback) {
        if ($.isFunction(data)) {
            type = type || callback,
                callback = data,
                data = {}
        }
        return $.ajax({
            url: url,
            type: 'POST',
            success: callback,
            data: JSON.stringify(data),
            contentType: 'application/json'
        });
    };

    $.put = function (url, data, callback) {
        if ($.isFunction(data)) {
            type = type || callback,
                callback = data,
                data = {}
        }
        return $.ajax({
            url: url,
            type: 'PUT',
            success: callback,
            data: JSON.stringify(data),
            contentType: 'application/json'
        });
    };

    $.delete = function (url, data, callback) {
        if ($.isFunction(data)) {
            type = type || callback,
                callback = data,
                data = {}
        }
        return $.ajax({
            url: url,
            type: 'DELETE',
            success: callback,
            data: JSON.stringify(data),
            contentType: 'application/json'
        });
    };

    this.InsertHtml = (data) => {
        var html = 		    
            `< !DOCTYPE html>
            <html lang="en">

                <head>
                    <meta charset="utf-8"> <!-- utf-8 works for most cases -->
                <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
                            <!-- Forcing initial-scale shouldn't be necessary -->
                <title></title> <!-- The title tag shows in email notifications, like Android 4.4. -->

                <!-- CSS Reset : BEGIN -->
                <style>
                    /* What it does: Remove spaces around the email design added by some email clients. */
                    /* Beware: It can remove the padding / margin and add a background color to the compose a reply window. */
                                html,
                    body {
                                    margin: 0 auto !important;
                        padding: 0 !important;
                        height: 100% !important;
                        width: 100% !important;
                        background: #f1f1f1;
                    }

                    /* What it does: Stops email clients resizing small text. */
                    * {
                                    -ms - text - size - adjust: 100%;
                        -webkit-text-size-adjust: 100%;
                    }

                    /* What it does: Centers email on Android 4.4 */
                    div[style*="margin: 16px 0"] {
                                    margin: 0 !important;
                    }

                    /* What it does: Stops Outlook from adding extra spacing to tables. */
                    table,
                    td {
                                    mso - table - lspace: 0pt !important;
                        mso-table-rspace: 0pt !important;
                    }

                    /* What it does: Fixes webkit padding issue. */
                    table {
                                    border - spacing: 0 !important;
                        border-collapse: collapse !important;
                        table-layout: fixed !important;
                        margin: 0 auto !important;
                    }

                    /* What it does: Uses a better rendering method when resizing images in IE. */
                    img {
                                    -ms - interpolation - mode: bicubic;
                    }

                    /* What it does: Prevents Windows 10 Mail from underlining links despite inline CSS. Styles for underlined links should be inline. */
                    a {
                                    text - decoration: none;
                    }

                    /* What it does: A work-around for email clients meddling in triggered links. */
                    *[x-apple-data-detectors],
                    /* iOS */
                    .unstyle-auto-detected-links *,
                    .aBn {
                                    border - bottom: 0 !important;
                        cursor: default !important;
                        color: inherit !important;
                        text-decoration: none !important;
                        font-size: inherit !important;
                        font-family: inherit !important;
                        font-weight: inherit !important;
                        line-height: inherit !important;
                    }

                    /* What it does: Prevents Gmail from displaying a download button on large, non-linked images. */
                    .a6S {
                                    display: none !important;
                        opacity: 0.01 !important;
                    }

                    /* What it does: Prevents Gmail from changing the text color in conversation threads. */
                    .im {
                                    color: inherit !important;
                    }

                    /* If the above doesn't work, add a .g-img class to any image in question. */
                    img.g-img+div {
                                    display: none !important;
                    }

                    /* What it does: Removes right gutter in Gmail iOS app: https://github.com/TedGoas/Cerberus/issues/89  */
                    /* Create one of these media queries for each additional viewport size you'd like to fix */

                    /* iPhone 4, 4S, 5, 5S, 5C, and 5SE */
                    @media only screen and (min-device-width: 320px) and (max-device-width: 374px) {
                                    u~div .email-container {
                                    min - width: 320px !important;
                        }
                    }

                    /* iPhone 6, 6S, 7, 8, and X */
                    @media only screen and (min-device-width: 375px) and (max-device-width: 413px) {
                                    u~div .email-container {
                                    min - width: 375px !important;
                        }
                    }

                    /* iPhone 6+, 7+, and 8+ */
                    @media only screen and (min-device-width: 414px) {
                                    u~div .email-container {
                                    min - width: 414px !important;
                        }
                    }
                </style>

                            <!-- CSS Reset : END -->
                <!-- Progressive Enhancements : BEGIN -->
                <style>
                                .primary {
                                    background: #17bebb;
                    }

                    .bg_white {
                                    background: #ffffff;
                    }

                    .bg_light {
                                    /* background: #f7fafa; */
                                    background: #f5f5f5;
                    }

                    .bg_black {
                                    background: #000000;
                    }

                    .bg_dark {
                                    background: rgba(0, 0, 0, .8);
                    }

                    .email-section {
                                    padding: 2.5em;
                    }

                    /*BUTTON*/
                    .btn {
                                    padding: 10px 15px;
                        display: inline-block;
                    }

                    .btn.btn-primary {
                                    border - radius: 5px;
                        background: #3399ff;
                        color: ;
                        padding: 5px;
                    }

                    .btn.btn-white {
                                    border - radius: 5px;
                        background: #0066ff;
                        color: #000000;
                    }

                    .btn.btn-white-outline {
                                    border - radius: 5px;
                        background: transparent;
                        color: #fff;
                    }

                    .btn.btn-black-outline {
                                    border - radius: 0px;
                        background: transparent;
                        border: 2px solid #000;
                        color: #000;
                        font-weight: 700;
                    }

                    .btn-custom {
                                    color: rgba(0, 0, 0, .3);
                        text-decoration: underline;
                    }

                    h1,
                    h2,
                    h3,
                    h4,
                    h5,
                    h6 {
                                    font - family: 'Work Sans', sans-serif;
                        color: #000000;
                        margin-top: 0;
                        font-weight: 400;
                    }

                    body {
                                    font - family: 'Work Sans', sans-serif;
                        font-weight: 400;
                        font-size: 15px;
                        line-height: 1.8;
                        /* color: rgba(0, 0, 0, .4); */
                        color: #6c757d;
                    }

                    a {
                                    color: #17bebb;
                    }

                    /*LOGO*/

                    .logo h1 {
                                    margin: 0;
                    }

                    .logo h1 a {
                                    color: #17bebb;
                        font-size: 24px;
                        font-weight: 700;
                        font-family: 'Work Sans', sans-serif;
                    }

                    /*HERO*/
                    .hero {
                                    position: relative;
                        z-index: 0;
                    }

                    .hero .text {
                                    color: rgba(0, 0, 0, .3);
                    }

                    .hero .text h2 {
                                    color: #000;
                        font-size: 34px;
                        margin-bottom: 15px;
                        font-weight: 300;
                        line-height: 1.2;
                    }

                    .hero .text h3 {
                                    font - size: 24px;
                        font-weight: 200;
                    }

                    .hero .text h2 span {
                                    font - weight: 600;
                        color: #000;
                    }


                    /*PRODUCT*/
                    .product-entry {
                                    display: block;
                        position: relative;
                        float: left;
                        padding-top: 20px;
                    }

                    .product-entry .text {
                                    width: calc(100% - 125px);
                        padding-left: 20px;
                    }

                    .product-entry .text h3 {
                                    margin - bottom: 0;
                        padding-bottom: 0;
                    }

                    .product-entry .text p {
                                    margin - top: 0;
                    }

                    .product-entry img,
                    .product-entry .text {
                                    float: left;
                    }

                    ul.social {
                                    padding: 0;
                    }

                    ul.social li {
                                    display: inline-block;
                        margin-right: 10px;
                    }

                    /*FOOTER*/

                    .footer {
                                    /* border-top: 1px solid rgba(0, 0, 0, .05); */
                                    /* color: rgba(0, 0, 0, .5); */
                                    color: #6c757d;
                    }

                    .footer .heading {
                                    color: #000;
                        font-size: 20px;
                    }

                    .footer ul {
                                    margin: 0;
                        padding: 0;
                    }

                    .footer ul li {
                                    list - style: none;
                        margin-bottom: 10px;
                    }

                    .footer ul li a {
                                    color: rgba(0, 0, 0, 1);
                    }

                    @media screen and (max-width: 500px) { }
                            </style>


            </head>

        <body width="100%" style="margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #f1f1f1;">
            <center style="width: 100%; background-color: #f1f1f1;">
                <div
                    style="display: none; font-size: 1px;max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;">
                    &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;
                </div>
                <div style="max-width: 600px; margin: 0 auto;" class="email-container">
                    <!-- BEGIN BODY -->
                    <table align="center" role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%" style="margin: auto;">
                        <tr>
                            <td valign="top" class="bg_white" style="padding: 1em 2.5em 0 2.5em;">
                                <table role="presentation" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="logo" style="text-align: center;">
                                            <a href="#"> <img src="https://res.cloudinary.com/yfqnpmwypy/image/upload/v1606896803/logo-blue_zsze99.svg" width="275" height="40"></a>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr><!-- end tr -->
                        <tr>
                            <td valign="middle" class="hero bg_white" style="padding: 2em 0 2em 0;">
                                    <table role="presentation" border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="padding: 0 2.5em; text-align: left;">
                                                <div class="text">
                                                    <h2 id="titulo">Confirmación de la cuenta</h2>
                                                    <h3 id="descripcion">Hola ${data.Nombre}</h3>
                                                    <p>Para activar su cuenta de Arrival es necesario que ingrese el siguiente codigo de verificación
                                    en el enlace que aparece abajo.</p>
                                                    <h4>${data.Codigo}</h4>
                                                    <p>Gracias por preferirnos!</p>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr><!-- end tr -->
                            <tr>
                                <table class="bg_white" role="presentation" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td valign="middle" style="text-align:left; padding: 1em 2.5em;">
                                            <a id="redireccion" href="https://localhost:44339/Home/ValidarCuenta" class="btn btn-primary">Verificar cuenta</a>
                                        </td>
                                    </tr>
                                </table>
                            </tr><!-- end tr -->
            <!-- 1 Column Text + Button : END -->
                    </table>
                        <table align="center" role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%"
                            style="margin: auto;">
                            <tr>
                                <td valign="middle" class="bg_light footer email-section">
                                    <table>
                                        <tr>
                                            <td valign="top" width="33.333%">
                                                <table role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="text-align: left; padding-right: 10px;">
                                                            <h3 class="heading">Acerca</h3>
                                                            <p>Somos Arrival.</p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td valign="top" width="33.333%">
                                                <table role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%">
                                                    <tr>
                                                        <td style="text-align: left; padding-left: 5px; padding-right: 5px;">
                                                            <h3 class="heading">Contacto</h3>
                                                            <p>myspotcr@gmail.com</p>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>
                                    </table>
                                </td>
                            </tr><!-- end: tr -->
                            <tr>
                                <td class="bg_white" style="text-align: center;">
                                    <p>Diseñado por xcoding</p>
                                </td>
                            </tr>
                        </table>
                    </div>
                </center>
            </body>
            </html>`;
        return html;
    }

    this.GetToApiContrasenna = function (service, callbackFunction) {
        var jqxhr = $.get(this.GetUrlApiService(service), function (response) {
            console.log("Response " + response);
            callbackFunction(response.Data);
        })
            .then(function (response) {
                var data = {};
                data = response.Data;
                var ctrlActions = new ControlActions();
                ctrlActions.EnviarCorreoContrasenna("Recuperación de la contraseña", data);
            })
            .fail(function (response) {
                var data = response.responseJSON;
                var ctrlActions = new ControlActions();
                ctrlActions.ShowMessage('E', data.ExceptionMessage);
            })
    };

	this.InsertHtmlContrasenna = (data) => {
		var html = `
		<!DOCTYPE html>
        <html lang="en">

        <head>
            <meta charset="utf-8"> <!-- utf-8 works for most cases -->
            <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
            <!-- Forcing initial-scale shouldn't be necessary -->
            <title></title> <!-- The title tag shows in email notifications, like Android 4.4. -->

            <!-- CSS Reset : BEGIN -->
            <style>
                /* What it does: Remove spaces around the email design added by some email clients. */
                /* Beware: It can remove the padding / margin and add a background color to the compose a reply window. */
                html,
                body {
                    margin: 0 auto !important;
                    padding: 0 !important;
                    height: 100% !important;
                    width: 100% !important;
                    background: #f1f1f1;
                }

                /* What it does: Stops email clients resizing small text. */
                * {
                    -ms-text-size-adjust: 100%;
                    -webkit-text-size-adjust: 100%;
                }

                /* What it does: Centers email on Android 4.4 */
                div[style*="margin: 16px 0"] {
                    margin: 0 !important;
                }

                /* What it does: Stops Outlook from adding extra spacing to tables. */
                table,
                td {
                    mso-table-lspace: 0pt !important;
                    mso-table-rspace: 0pt !important;
                }

                /* What it does: Fixes webkit padding issue. */
                table {
                    border-spacing: 0 !important;
                    border-collapse: collapse !important;
                    table-layout: fixed !important;
                    margin: 0 auto !important;
                }

                /* What it does: Uses a better rendering method when resizing images in IE. */
                img {
                    -ms-interpolation-mode: bicubic;
                }

                /* What it does: Prevents Windows 10 Mail from underlining links despite inline CSS. Styles for underlined links should be inline. */
                a {
                    text-decoration: none;
                }

                /* What it does: A work-around for email clients meddling in triggered links. */
                *[x-apple-data-detectors],
                /* iOS */
                .unstyle-auto-detected-links *,
                .aBn {
                    border-bottom: 0 !important;
                    cursor: default !important;
                    color: inherit !important;
                    text-decoration: none !important;
                    font-size: inherit !important;
                    font-family: inherit !important;
                    font-weight: inherit !important;
                    line-height: inherit !important;
                }

                /* What it does: Prevents Gmail from displaying a download button on large, non-linked images. */
                .a6S {
                    display: none !important;
                    opacity: 0.01 !important;
                }

                /* What it does: Prevents Gmail from changing the text color in conversation threads. */
                .im {
                    color: inherit !important;
                }

                /* If the above doesn't work, add a .g-img class to any image in question. */
                img.g-img+div {
                    display: none !important;
                }

                /* What it does: Removes right gutter in Gmail iOS app: https://github.com/TedGoas/Cerberus/issues/89  */
                /* Create one of these media queries for each additional viewport size you'd like to fix */

                /* iPhone 4, 4S, 5, 5S, 5C, and 5SE */
                @media only screen and (min-device-width: 320px) and (max-device-width: 374px) {
                    u~div .email-container {
                        min-width: 320px !important;
                    }
                }

                /* iPhone 6, 6S, 7, 8, and X */
                @media only screen and (min-device-width: 375px) and (max-device-width: 413px) {
                    u~div .email-container {
                        min-width: 375px !important;
                    }
                }

                /* iPhone 6+, 7+, and 8+ */
                @media only screen and (min-device-width: 414px) {
                    u~div .email-container {
                        min-width: 414px !important;
                    }
                }
            </style>

            <!-- CSS Reset : END -->
            <!-- Progressive Enhancements : BEGIN -->
            <style>
                .primary {
                    background: #17bebb;
                }

                .bg_white {
                    background: #ffffff;
                }

                .bg_light {
                    /* background: #f7fafa; */
                    background: #f5f5f5;
                }

                .bg_black {
                    background: #000000;
                }

                .bg_dark {
                    background: rgba(0, 0, 0, .8);
                }

                .email-section {
                    padding: 2.5em;
                }

                /*BUTTON*/
                .btn {
                    padding: 10px 15px;
                    display: inline-block;
                }

                .btn.btn-primary {
                    border-radius: 5px;
                    background: #3399ff;
                    color: #ffffff;
                    padding: 5px;
                }

                .btn.btn-white {
                    border-radius: 5px;
                    background: #ffffff;
                    color: #000000;
                }

                .btn.btn-white-outline {
                    border-radius: 5px;
                    background: transparent;
                    border: 1px solid #fff;
                    color: #fff;
                }

                .btn.btn-black-outline {
                    border-radius: 0px;
                    background: transparent;
                    border: 2px solid #000;
                    color: #000;
                    font-weight: 700;
                }

                .btn-custom {
                    color: rgba(0, 0, 0, .3);
                    text-decoration: underline;
                }

                h1,
                h2,
                h3,
                h4,
                h5,
                h6 {
                    font-family: 'Work Sans', sans-serif;
                    color: #000000;
                    margin-top: 0;
                    font-weight: 400;
                }

                body {
                    font-family: 'Work Sans', sans-serif;
                    font-weight: 400;
                    font-size: 15px;
                    line-height: 1.8;
                    /* color: rgba(0, 0, 0, .4); */
                    color: #6c757d;
                }

                a {
                    color: #17bebb;
                }

                /*LOGO*/

                .logo h1 {
                    margin: 0;
                }

                .logo h1 a {
                    color: #17bebb;
                    font-size: 24px;
                    font-weight: 700;
                    font-family: 'Work Sans', sans-serif;
                }

                /*HERO*/
                .hero {
                    position: relative;
                    z-index: 0;
                }

                .hero .text {
                    color: rgba(0, 0, 0, .3);
                }

                .hero .text h2 {
                    color: #000;
                    font-size: 34px;
                    margin-bottom: 15px;
                    font-weight: 300;
                    line-height: 1.2;
                }

                .hero .text h3 {
                    font-size: 24px;
                    font-weight: 200;
                }

                .hero .text h2 span {
                    font-weight: 600;
                    color: #000;
                }


                /*PRODUCT*/
                .product-entry {
                    display: block;
                    position: relative;
                    float: left;
                    padding-top: 20px;
                }

                .product-entry .text {
                    width: calc(100% - 125px);
                    padding-left: 20px;
                }

                .product-entry .text h3 {
                    margin-bottom: 0;
                    padding-bottom: 0;
                }

                .product-entry .text p {
                    margin-top: 0;
                }

                .product-entry img,
                .product-entry .text {
                    float: left;
                }

                ul.social {
                    padding: 0;
                }

                ul.social li {
                    display: inline-block;
                    margin-right: 10px;
                }

                /*FOOTER*/

                .footer {
                    /* border-top: 1px solid rgba(0, 0, 0, .05); */
                    /* color: rgba(0, 0, 0, .5); */
                    color: #6c757d;
                }

                .footer .heading {
                    color: #000;
                    font-size: 20px;
                }

                .footer ul {
                    margin: 0;
                    padding: 0;
                }

                .footer ul li {
                    list-style: none;
                    margin-bottom: 10px;
                }

                .footer ul li a {
                    color: rgba(0, 0, 0, 1);
                }

                @media screen and (max-width: 500px) {}
            </style>


        </head>

        <body width="100%" style="margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #f1f1f1;">
            <center style="width: 100%; background-color: #f1f1f1;">
                <div
                    style="display: none; font-size: 1px;max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;">
                    &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;
                </div>
                <div style="max-width: 600px; margin: 0 auto;" class="email-container">
                    <!-- BEGIN BODY -->
                    <table align="center" role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%"
                        style="margin: auto;">
                        <tr>
                            <td valign="top" class="bg_white" style="padding: 1em 2.5em 0 2.5em;">
                                <table role="presentation" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="logo" style="text-align: center;">
                                            <h1>Arrival</h1>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr><!-- end tr -->
                        <tr>
                            <td valign="middle" class="hero bg_white" style="padding: 2em 0 2em 0;">
                                <table role="presentation" border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="padding: 0 2.5em; text-align: left;">
                                            <div class="text">
                                                <h2 id="titulo">Recuperación de la contraseña</h2>
                                                <h3 id="descripcion">Hola ${data.Nombre}</h3>
                                                <p>Su contraseña de Arrival se ha recuperado correctamente.</p>
                                                <h4>Contraseña : ${data.Contrasenna}</h4>
                                                <p>Gracias por preferirnos!</p>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr><!-- end tr -->
                        <tr>
                            <table class="bg_white" role="presentation" border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td valign="middle" style="text-align:left; padding: 1em 2.5em;">
                                        <a id="redireccion" href="https://localhost:44339/Home/InicioSesion" class="btn btn-primary">Iniciar sesión</a>
                                    </td>
                                </tr>
                            </table>
                        </tr><!-- end tr -->
                        <!-- 1 Column Text + Button : END -->
                    </table>
                    <table align="center" role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%"
                        style="margin: auto;">
                        <tr>
                            <td valign="middle" class="bg_light footer email-section">
                                <table>
                                    <tr>
                                        <td valign="top" width="33.333%">
                                            <table role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%">
                                                <tr>
                                                    <td style="text-align: left; padding-right: 10px;">
                                                        <h3 class="heading">Acerca</h3>
                                                        <p>Somos Arrival.</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" width="33.333%">
                                            <table role="presentation" cellspacing="0" cellpadding="0" border="0" width="100%">
                                                <tr>
                                                    <td style="text-align: left; padding-left: 5px; padding-right: 5px;">
                                                        <h3 class="heading">Contacto</h3>
                                                        <p>myspotcr@gmail.com</p>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                </table>
                            </td>
                        </tr><!-- end: tr -->
                        <tr>
                            <td class="bg_white" style="text-align: center;">
                                <p>Diseñado por xcoding</p>
                            </td>
                        </tr>
                    </table>

                </div>
            </center>
        </body>
        </html>`;

		return html;
    }

}
    
