var dataTable;

$(document).ready(function () {
	loadDataTable();
})

function loadDataTable() {
	dataTable = $('#DT_load').DataTable({
		"ajax": {
			"url": "/api/blogpost",
			"type": "GET",
			"datatype": "json"
		},
		"columns": [
			{ "data": "title", "width": "20%" },
			{ "data": "author", "width": "20%" },
			{ "data": "body", "width": "30%" },
			{
				"data": "id",
				"render": function (data) {
					return `<div class="text-center">
						<a href="/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">Edit</a>
						<a class="btn btn-danger text-white" style="cursor:pointer; width:70px;" onclick="Delete('/api/blogpost?id='+${data})">Delete</a>
						</div>`;
				}, "width": "30%"
			}
		],
		"language": {
			"emptyTables": "no data found"
		},
		"width": "100%"
	})
}

function Delete(url) {
	swal({
		title: "Are you sure you want to Delete?",
		text: "This action is irreversible.",
		icon: "warning",
		buttons: true,
		dangerMode: true
	}).then((willDelete) => {
		if (willDelete) {
			$.ajax({
				type: "DELETE",
				url: url,
				success: function (data) {
					if (data.success) {
						toastr.success(data.message);
						dataTable.ajax.reload();
					}
					else {
						toastr.error(message);
					}
				}
			});
		}
	});
}