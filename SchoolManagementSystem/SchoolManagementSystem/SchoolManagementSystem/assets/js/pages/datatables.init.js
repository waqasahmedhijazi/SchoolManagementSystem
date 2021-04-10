$(document).ready(function () {
    $("#basic-datatable").DataTable({
        pagingType: "full_numbers",
        "dom": '<"top"f<"clear">>rt<"bottom"ilp<"clear">>',
        language: {
            paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" }
        },
        drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") }
    });


    var a = $("#datatable-buttons").DataTable({
        lengthMenu: [[10, 25, 50, -1], [10, 25, 50, "All"]],
        buttons: [{ extend: "copy", className: "btn-light" }, { extend: "print", className: "btn-light" }, { extend: "pdf", className: "btn-light" }],
        language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } },
        drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") }
    });
    a.buttons().container().appendTo("#datatable-buttons_wrapper .col-md-6:eq(0)");

    $("#selection-datatable").DataTable({ select: { style: "multi" }, language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } }, drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") } });
    $("#key-datatable").DataTable({ keys: !0, language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } }, drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") } })

    $("#alternative-page-datatable").DataTable({ pagingType: "full_numbers", drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") } });
    $("#scroll-vertical-datatable").DataTable({ scrollY: "350px", scrollCollapse: !0, paging: !1, language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } }, drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") } });
    $("#scroll-horizontal-datatable").DataTable({ scrollX: !0, language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } }, drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") } });
    $("#complex-header-datatable").DataTable({ language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } }, drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") }, columnDefs: [{ visible: !1, targets: -1 }] });
    $("#row-callback-datatable").DataTable({ language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } }, drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") }, createdRow: function (a, e, i) { 15e4 < +e[5].replace(/[\$,]/g, "") && $("td", a).eq(5).addClass("text-danger") } });
    $("#state-saving-datatable").DataTable({ stateSave: !0, language: { paginate: { previous: "<i class='mdi mdi-chevron-left'>", next: "<i class='mdi mdi-chevron-right'>" } }, drawCallback: function () { $(".dataTables_paginate > .pagination").addClass("pagination-rounded") } });
});