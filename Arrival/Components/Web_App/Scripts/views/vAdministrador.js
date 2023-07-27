$(document).ready(function () {
    if (localStorage.getItem("usuario") === null) {
        window.location.href = 'LandingPage';
    } else {
        var rol = localStorage.getItem('rol');
        if (rol !== '"Administrador General"') {
            window.location.href = 'LandingPage';
        } 
    }
});