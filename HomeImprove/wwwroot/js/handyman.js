var dataTable;

$(document).ready(function () {
    loadDataTable();
})


function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/handyman/getall'},
        "columns": [
            { data: 'title', "width": "20%" },
            { data: 'name', "width": "15%" },
            { data: 'price', "width": "10%" },
            { data: 'category.name', "width": "20%" },
            {
                data: 'id',
                "render": function(data) {
                    return `<div class="w-75 btn-group" role="group">
                        <a href="/admin/handyman/upserthandyman?id=${data}" class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i> Uredi</a>
                        <a onClick=Delete('/admin/handyman/delete/${data}') class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i> Izbriši</a>
                    </div>`
                },
                "width": "35%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Da li ste sigurni?',
        text: "Nećete biti u mogućnosti da vratite ukoliko izbrišete!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Da, izbriši!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    })
}
