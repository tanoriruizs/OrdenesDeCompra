﻿document.getElementById("createForm").addEventListener("submit", function (event) {
    event.preventDefault();

    let numeroDeOrden = document.getElementById("NumeroDeOrden").value.trim();
    let fecha = document.getElementById("Fecha").value;
    let proveedor = document.getElementById("Proveedor").value.trim();
    let montoTotal = document.getElementById("MontoTotal").value.trim();

    if (numeroDeOrden === "" || fecha === "" || proveedor === "" || montoTotal === "") {
        Swal.fire({
            title: "Error",
            text: "Todos los campos son obligatorios.",
            icon: "error"
        });
        return;
    }

    Swal.fire({
        title: "Orden Creada",
        text: "Se ha creado una nueva orden correctamente.",
        icon: "success"
    }).then((result) => {
        if (result.isConfirmed) {
            this.submit();
        }
    });
});