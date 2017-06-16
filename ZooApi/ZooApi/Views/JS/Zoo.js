$(document).ready(function () {

    function GetMarcas() {

        var urlAPI = 'http://localhost:60332/api/especies';

        $.get(urlAPI, function (respuesta, estado) {

            $('#resultados').html('');
            // COMPRUEBO EL ESTADO DE LA LLAMADA
            if (estado === 'success') {
                // SI LLEGO HASTA AQUÍ QUIERE DECIR

                var relleno = '';

                relleno += '<table border="0">';
                relleno += '    <tr>';
                relleno += '        <td>Id.</td>'
                relleno += '        <td>Denominación</td>'
                relleno += '        <td>Acciones</td>'
                relleno += '    </tr>';
                $.each(respuesta.dataMarcas, function (indice, elemento) {

                    relleno += '    <tr>';
                    relleno += '        <td>' + elemento.id + '</td>';
                    relleno += '        <td>' + elemento.denominacion + '</td>';
                    relleno += '        <td>';
                    relleno += '            <button data-id="' + elemento.id + '" id="btnEliminar">X</button>';
                    relleno += '            <button data-id="' + elemento.id + '" id="btnEditar">Editar</button>';
                    relleno += '        </td>';
                    relleno += '    </tr>';

                });
                relleno += '</table>';
                $('#resultados').append(relleno);
            }
        });
    }

    $('#resultados').on('click', '#btnEliminar', function () {
        var idMarca = $(this).attr('data-id');
        var urlAPI = 'http://localhost:60332/api/especies';
        $.ajax({
            url: urlAPI + '/' + idMarca,
            type: "DELETE",
            success: function (respuesta) {
                GetMarcas();
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    $('#resultados').on('click', '#btnEditar', function () {
        var idMarca = $(this).attr('data-id');
        var urlAPI = 'http://localhost:60332/api/especies';
        var dataNuevaMarca = {
            denominacion: $('#txtNuevaMarca').val()
        };

        $.ajax({
            url: urlAPI + '/' + idMarca,
            type: "PUT",
            dataType: 'json',
            data: dataNuevaMarca,
            success: function (respuesta) {
                GetMarcas();
            },
            error: function (respuesta) {
                console.log(respuesta);
            }
        });
    });

    $('#btnAddMarca').click(function () {
        var nuevaMarca = $('#txtMarcaDenominacion').val();
        var urlAPI = 'http://localhost:60332/api/especies';

        var dataNuevaMarca = {
            id: 0,
            denominacion: nuevaMarca
        };

        $('#imgLoading').removeClass('oculta-loading');

        $.ajax({
            url: urlAPI,
            type: "POST",
            dataType: 'json',
            data: dataNuevaMarca,
            success: function (respuesta) {
                $('#imgLoading').addClass('oculta-loading');
                GetMarcas();
            },
            error: function (respuesta) {
                console.log(respuesta);
                $('#imgLoading').addClass('oculta-loading');
            }
        });
    });

    GetMarcas();

});