var dataTablePer;
function PersonelGetir() {
    dataTablePer = $("#PersonelTable").DataTable({
        paging: true,
        destroy: true,
        lengthChange: false,
        searching: true,
        ordering: true,
        info: true,
        responsive: true,
        order: [[0, "asc"]],
        lengthMenu: [[5, 10, 25, 50, -1], ['5', '10', '25', '50', 'Hepsini Göster']],
        ajax: {
            url: "/Home/PersonelGetir",
            type: "GET",
            datatype: "json",
            dataSrc: ""
        },
        columns: [
            { data: "id" },
            { data: "ad" },
            { data: "soyad" },
            { data: "telefon" },
            {
                data: "id", "render": function (data) {
                    return '<a href="#" class="btn btn-success duzenle rounded-0" style=" width:60px;">D</a>';
                }
            },
            {
                data: "id", "render": function (data) {
                    return '<a href="#" class="btn btn-danger sil rounded-0" style=" width:60px;">S</a>';
                }
            }
        ],
        columnDefs:
            [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                },
                {
                    className: "p-0 m-0 text-center bg-success", style: "color:black; vertical-align: middle !important;", width: "1%", targets: [4]
                },
                {
                    className: "p-0 m-0 text-center bg-danger", style: "color:black; vertical-align: middle !important;", width: "1%", targets: [5]
                },
            ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.12.1/i18n/tr.json"
        },

    });

    $('#PersonelTable tbody').on('click', '.duzenle', async function () {
        var data = dataTablePer.row($(this).parents('tr')).data();
        await $('input[name="Id"]').val(data.id);
        await $('input[name="Ad"]').val(data.ad);
        await $('input[name="Soyad"]').val(data.soyad);
        await $('input[name="Telefon"]').val(data.telefon);
        await $('#PersonelModal').modal('show');
    });
    $('#PersonelTable tbody').on('click', '.sil', async function () {
        var data = dataTablePer.row($(this).parents('tr')).data();
        await PersonelSil(data.id);
    });
}

$(document).ready(function () {
    PersonelGetir();
});

async function Sifirla() {
    Sifirla();
    await $('input[name="Id"]').val(null);
    await $('input[name="Ad"]').val(null);
    await $('input[name="Soyad"]').val(null);
    await $('input[name="Telefon"]').val(null);
}

async function PersonelEkleGuncelle(e) {
    e.preventDefault();
    let entity = await new FormData(e.target);
    var Id = entity.get("Id");
    if (Id > 0) {
        await $.ajax({
            url: "/Home/PersonelGuncelle",
            data: entity,
            type: "POST",
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            cache: false,
            success: function (result) {
                $('#PersonelModal').modal('hide')
                dataTablePer.ajax.reload();
            },
            error: function (message) {
                dataTablePer.ajax.reload();
                console.log(message.responseText);
            }
        });
    }
    else {
        await $.ajax({
            url: "/Home/PersonelEkle",
            data: entity,
            type: "POST",
            enctype: 'multipart/form-data',
            processData: false,
            contentType: false,
            cache: false,
            success: function (result) {
                dataTablePer.ajax.reload();
                $('#PersonelModal').modal('hide')
            },
            error: function (message) {
                dataTablePer.ajax.reload();
                console.log(message.responseText);
            }
        });
    }
}
async function PersonelSil(data) {
    let formData = new FormData();
    formData.append("Id", data);
    await $.ajax({
        url: "/Home/Delete",
        data: formData,
        type: "POST",
        enctype: 'multipart/form-data',
        processData: false,
        contentType: false,
        cache: false,
        success: function (result) {
            dataTablePer.ajax.reload();
        },
        error: function (message) {
            dataTablePer.ajax.reload();
            console.log(message.responseText);
        }
    });
}