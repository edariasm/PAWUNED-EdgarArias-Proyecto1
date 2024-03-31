function loginmessage() {
    alert("Inicio de sesión exitoso");
}

function actividaduardada() {
    alert("La actividad ha sido guardada con éxito");
}

function comidaguardada() {
    alert("La alimentación ha sido guardada con éxito");
}

function metaguardada() {
    alert("La meta ha sido guardada con éxito");
}


//capturar fecha actual para las actividades

function fecha_actual() {

    var fecha = new Date();
    var fechaFormateada = ('0' + fecha.getDate()).slice(-2) + '/' + ('0' + (fecha.getMonth() + 1)).slice(-2) + '/' + fecha.getFullYear();

    // en el span con id fechaActual se coloca la fecha
    document.getElementById("fechaActual").innerText = fechaFormateada;
}


//function login() {

//    var username = document.getElementById("username").value;
//    var password = document.getElementById("password").value;
//    console.log(username);
//    console.log(password);

//    // Llamar a la acción de Login del controlador Usuarios utilizando AJAX
//    $.ajax({
//        url: loginUrl, // URL de la acción de Login
//        type: 'POST', // Método HTTP
//        data: { username: username, password: password }, // Datos del formulario
//        success: function (result) {
//            // Manejar la respuesta del servidor
//            console.log(result);
//            // Redirigir a la página principal si el inicio de sesión fue exitoso
//            window.location.href = '@Url.Action("Index", "Home")';
//        },
//        error: function (xhr, status, error) {
//            // Manejar errores de la solicitud AJAX
//            console.error(xhr.responseText);
//            alert('Error: No se pudo iniciar sesión');
//        }
//    });

//    // Evitar que el formulario se envíe automáticamente
//    return false;
//}


function pruebaAjax() {
    $.ajax({
        url: '/Home/PruebaAjax', // Reemplaza '/Home/Test' con la ruta a tu acción de prueba
        type: 'POST',
        success: function (response) {
            console.log('Respuesta recibida:', response);
            alert('La solicitud AJAX fue exitosa. Comprueba la consola para ver la respuesta.');
        },
        error: function (xhr, status, error) {
            console.error('Error en la solicitud AJAX:', error);
            alert('La solicitud AJAX falló. Comprueba la consola para ver el error.');
        }
    });
}




