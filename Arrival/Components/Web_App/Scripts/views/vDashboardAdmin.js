
function vDashboardAdmin() {

    this.formId = 'registrationForm';
    this.service = 'Pago';
    this.ctrlActions = new ControlActions();

    this.GetPagos = function () {
        var pagos = this.ctrlActions.GetToApi(servide, () => {
            console.log(pagos);
        })
    }


    function getMonthlyData() {
        var chartData = ['Mes', 'Ganancias'];

    }

    $(document).ready(function () {
        vdashboard = new vDashboardAdmin();

    })
}