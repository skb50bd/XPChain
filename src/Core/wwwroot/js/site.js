const deleteButton = document.getElementsByClassName('js-remove-item');

const swalDelete = Swal.mixin({
    confirmButtonClass: "btn btn-danger",
    cancelButtonClass: "btn btn-secondary mr-2",
    buttonsStyling: false
});

const swalSave = Swal.mixin({
    confirmButtonClass: "btn btn-success",
    cancelButtonClass: "btn btn-danger mr-4",
    buttonsStyling: false
});

function confirmRemove(event) {
    swalDelete.fire({
        title: "Are you sure?",
        text: "The item will be removed from records!",
        type: "warning",
        showCancelButton: true,
        confirmButtonText: "Yes, remove it!",
        cancelButtonText: "No, cancel!",
        reverseButtons: true
    }).then((result) => {
        if (result.value) {
            $.ajax(
                {
                    url: $(event.target).attr("data-href"),
                    method: "DELETE"
                }
            ).done(function() {
                swalDelete.fire(
                    "Removed!",
                    "Your file has been removed.",
                    "success"
                ).then((value) => {
                    if (value)
                        window.location = $(event.target).attr("data-returnUrl");
                });
            }).fail(function() {
                swalDelete.fire(
                    "Failed",
                    "Could not remove the item :(",
                    "warning"
                );
            });
        } else if (
            // Read more about handling dismissals
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalDelete.fire(
                "Cancelled",
                "Your data is safe :)",
                "error"
            );
        }
    });
}


$(document).ready(() => {
    $(deleteButton).click(confirmRemove);
});