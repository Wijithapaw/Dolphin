$.extend( true, $.fn.dataTable.defaults, {
	"oLanguage": {
	    "sLengthMenu": "_MENU_ records per page",
	}
} );

$(document).ready(function () {
    $('#richTable').DataTable({
        responsive: true,
    });
});