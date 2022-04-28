$(document).ready(function () {
    // Setup - add a text input to each footer cell
    $('#Datatable thead tr')
        .clone(true)
        .addClass('filters')
        .appendTo('#Datatable thead');

    var table = $('#Datatable').DataTable({
        language: {
            url: '//cdn.datatables.net/plug-ins/1.11.5/i18n/uk.json'
        },
        orderCellsTop: true,
        
        fixedHeader: true,
        initComplete: function () {
            var api = this.api();

            // For each column
            api
                .columns()
                .eq(0)
                .each(function (colIdx) {
                    // Set the header cell to contain the input element
                    var cell = $('.filters th').eq(
                        $(api.column(colIdx).header()).index()
                    );
                    var title = $(cell).text();

                    if ($(cell).hasClass('dontNeedFilter')) {
                        $(cell).html('<div class="btn-group-vertical w-100"><button type = "button" class= "btn btn-success"><i class="fa fa-plus-square"></i><br>Створити</button></div>');
                    }
                    else
                    {
                        $(cell).html('<input type="text" class="form-control" placeholder="' + '" />');
                    }
                    

                    // On every keypress in this input
                    $(
                        'input',
                        $('.filters th').eq($(api.column(colIdx).header()).index())
                    )
                        .off('keyup change')
                        .on('keyup change', function (e) {
                            e.stopPropagation();

                            // Get the search value
                            $(this).attr('title', $(this).val());
                            var regexr = '({search})'; //$(this).parents('th').find('select').val();

                            var cursorPosition = this.selectionStart;
                            // Search the column for that value
                            api
                                .column(colIdx)
                                .search(
                                    this.value != ''
                                        ? regexr.replace('{search}', '(((' + this.value + ')))')
                                        : '',
                                    this.value != '',
                                    this.value == ''
                                )
                                .draw();

                            $(this)
                                .focus()[0]
                                .setSelectionRange(cursorPosition, cursorPosition);
                        });
                });
        },
        columnDefs: [
            { orderable: false, targets: -1 }
        ],

    });
});