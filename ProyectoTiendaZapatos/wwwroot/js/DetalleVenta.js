var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblDetalleVentas").DataTable({
        "ajax": {
            "url": "/Admin/DetalleVenta/GetAll",  // Asegúrate de que esta URL es correcta y apunta al método que devuelve los detalles de venta.
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "detalleVentaId", "width": "10%" },
            { "data": "ventaId", "width": "10%" },
            { "data": "productoId", "width": "10%" },
            { "data": "cantidad", "width": "10%" },
            { "data": "precio", "width": "10%", "render": $.fn.dataTable.render.number(',', '.', 2, '$') },
            {
                "data": "detalleVentaId",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/DetalleVenta/Edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-edit"></i> Editar
                        </a>
                        &nbsp;
                        <a onclick=Delete("/Admin/DetalleVenta/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                            <i class="far fa-trash-alt"></i> Borrar
                        </a>
                    </div>`;
                }, "width": "15%"
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
