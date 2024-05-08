var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblCompras").DataTable({
        "ajax": {
            "url": "/Admin/Compra/GetAll",  // Asegúrate de que esta URL es correcta y apunta al método que devuelve las compras.
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "compraId", "width": "10%" },
            { "data": "cliente.nombre", "width": "15%" },  // Suponiendo que tienes acceso al cliente desde la compra.
            { "data": "cliente.apellido", "width": "15%" },
            {
                "data": "fecha", "width": "15%", "render": function (data) {
                    return new Date(data).toLocaleDateString();  // Formateando la fecha.
                }
            },
            { "data": "total", "width": "15%" },
            {
                "data": "compraId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Compra/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-edit"></i> Editar
                        </a>
                        &nbsp;
                        <a onclick=Delete("/Admin/Compra/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-trash-alt"></i> Borrar
                        </a>
                    </div>`;
                }, "width": "20%"
            }
        ],
        "language": { /* Tu configuración de idioma */ }
    });
}

function Delete(url) {
    swal({
        title: "¿Está seguro de borrar?",
        text: "Este contenido no se puede recuperar.",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Sí, borrar!",
        closeOnConfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                } else {
                    toastr.error(data.message);
                }
            }
        });
    });
}
