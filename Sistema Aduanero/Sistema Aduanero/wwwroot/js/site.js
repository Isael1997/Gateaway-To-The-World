// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Este es el bloque de código que trabaja el boton mostrar y ocultar.
function mostrar_y_ocultar(){
    var formulario = document.getElementById('formulario_nuevo_registro');
    var formularioStyle = window.getComputedStyle(formulario);
    var formularioDisplay = formularioStyle.getPropertyValue('display');
    if(formularioDisplay == "none"){
        document.getElementById('formulario_nuevo_registro').style.display = "block";
    }else{
        document.getElementById('formulario_nuevo_registro').style.display = "none";
    }
}
//Este es el bloque de código que trabaja el boton mostrar y ocultar.