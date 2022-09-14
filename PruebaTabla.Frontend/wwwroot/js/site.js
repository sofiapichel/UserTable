var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
})


showInPopup = (url, title, componentFocus) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal .modal-body').html(res);
            $('#form-modal .modal-title').html(title);
            $('#form-modal').modal('show');
            $('#' + componentFocus).focus();
        }
    })
}

showInPopupLg = (url, title, componentFocus) => {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (res) {
            $('#form-modal-lg .modal-body').html(res);
            $('#form-modal-lg .modal-title').html(title);
            $('#form-modal-lg').modal('show');
            $('#' + componentFocus).focus();
        }
    })
}


jQueryAjaxPost = form => {
    try {
        $.ajax({
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (res) {
                if (res.isValid) {
                    $('#view-all-usuario').html(res.html)

                    $('#form-modal .modal-body').html('');
                    $('#form-modal .modal-title').html('');
                    $('#form-modal').modal('hide');


                    $('#form-modal-lg .modal-body').html('');
                    $('#form-modal-lg .modal-title').html('');
                    $('#form-modal-lg').modal('hide');

                    alertify.success('Operaci&oacute;n realizada con &eacute;xito');

                }
                else {

                    if (res.valorEnUso) {
                        $('#form-modal .modal-body').html(res.html);
                        $('#form-modal-lg .modal-body').html(res.html);
                        alertify.error('El valor ingresado ya existe');
                    } else {
                        $('#form-modal .modal-body').html(res.html);
                        $('#form-modal-lg .modal-body').html(res.html);
                        alertify.error('Verific&aacute; los datos ingresados');
                    }
                }

            },
            error: function (err) {
                console.log(err)
            }
        })
        //to prevent default form submit event
        return false;
    } catch (ex) {
        console.log(ex)
    }
}

jQueryAjaxDelete = form => {

    alertify.confirm('Eliminar...', 'Eliminar registro?', function () {

        try {
            $.ajax({
                type: 'POST',
                url: form.action,
                data: new FormData(form),
                contentType: false,
                processData: false,
                success: function (res) {
                    $('#view-all-usuario').html(res.html)
                    alertify.success('Registro eliminado con &eacute;xito');
                },
                error: function (err) {
                    alertify.error('Error al eliminar el registro');
                }
            })
        } catch (ex) {
            console.log(ex)
        }

    }
        , function () {

        }).set('labels', { ok: 'Eliminar', cancel: 'Cancelar' }, 'modal', true);



    //prevent default form submit event
    return false;
}
