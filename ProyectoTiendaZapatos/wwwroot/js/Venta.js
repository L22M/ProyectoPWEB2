var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblVentas").DataTable({
        "ajax": {
            "url": "/Admin/Venta/GetAll",  // Verifica que esta URL es correcta para obtener los datos de las ventas.
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ventaId", "width": "10%" },
            { "data": "clienteId", "width": "10%" },
            {
                "data": "fecha", "width": "20%", "render": function (data) {
                    // Formateo de la fecha a un formato más amigable
                    return data ? new Date(data).toLocaleDateString() : '';
                }
            },
            { "data": "total", "width": "20%", "render": $.fn.dataTable.render.number(',', '.', 2, '$') },
            {
                "data": "ventaId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Venta/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-edit"></i> Editar
                        </a>
                        &nbsp;
                        <a onclick=Delete("/Admin/Venta/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-trash-alt"></i> Borrar
                        </a>
                    </div>`;
                }, "width": "20%"
            }
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros disponibles",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ registros",
            "infoEmpty": "Mostrando 0 a 0 de 0 registros",
            "infoFiltered": "(filtrado de _MAX_ registros totales)",
            "lengthMenu": "Mostrar _MENU_ registros",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "No se encontraron registros coincidentes",
            "paginate": {
                "first": "Primero",
                "last": "Último",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        }
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
