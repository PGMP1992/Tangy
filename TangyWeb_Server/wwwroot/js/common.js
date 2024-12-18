window.ShowToastr = (type, message) => {
    if (type == "success") {
        toastr.success(message, '', {timeout:5000})
    }
    if (type == "error") {
        toastr.error(message, '', { timeout: 5000 })
    }
}

window.ShowSwal = (type, message) => {
    if (type == "success") {
        Swal.Fire(
            'Success!',
            message,
            'success'
        )
    }
    if (type == "error") {
        Swal.Fire(
            'Error!',
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}
