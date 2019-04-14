$(document).ready(function () {

  Consultar();
});

function Consultar() {

    $.ajax({
        url: "/Produto/GetAll",
        type: "GET",
        data: {},
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.nome + '</td>';
                html += '<td>' + item.tipo + '</td>';
                html += '<td>' + item.tamanho + '</td>';
                html += '<td>' + item.quantidade + '</td>';
                html += '<td>' + item.valor + '</td>';
                html += '<td>' + item.descricao + '</td>';
                html += '<td style="text-align:center"><a href="#" data-toggle="tooltip" data-placement="top" title="Detalhe" class="btn" style="background-color:#144b87;color:white;border-color:#144b87" onclick="return GetDadosProduto(' + item.id + ', true)"><i class="fas fa-search-plus"></i></a>';
                html += '\xa0 <a href = "#" data-toggle="tooltip" data-placement="top" title="Editar" class="btn" style="background-color:#144b87;color:white;border-color:#144b87" onclick = "return GetDadosProduto(' + item.id + ', false)" > <i class="fas fa-edit" /></a >';
                html += '\xa0 <a href="#" data-toggle="tooltip" data-placement="top" title="Excluir" class="btn btn-danger" onclick="Deletar(' + item.id + ')"><i class="fas fa-trash fa-fw"></i></a></td > ';
                html += '</tr>';
            });
            $('.tbody').html(html);

            
        },
        error: function (errormessage) {
            swal({
                type: 'error',
                title: 'Oops...',
                text: 'Não foi possível consultar'
            });
        }
    });
}

function Adicionar() {

    var res = Validacao();
    if (res == false) {
        return false;
    }
    var ProdutoJson = {
        Id: 0,
        Nome: $('#txtNome').val(),
        Tipo: $("#selTipo option:selected").text(),
        Tamanho: $("#selTamanho option:selected").text(),
        Quantidade: $('#txtQuantidade').val(),
        Valor: $('#txtValor').val(),
        Descricao: $('#txtDescricao').val()
    };

    var json = JSON.stringify(ProdutoJson);

    $.ajax({
        url: "/Produto/Adicionar",        
        data: json,
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Consultar();

            $('#modalAddOrEdit').modal('toggle');
            $('.modal-backdrop').css('display', 'none');

            if (result == 'Sucesso') {

                swal({
                    type: 'success',
                    title: 'Produto adicionado com sucesso',
                    showConfirmButton: false
                });

                LimparCampos();
            }
            else
                swal({
                    type: 'error',
                    title: 'Oops...',
                    text: 'Não foi possível adicionar o produto'
                });
        },
        error: function (errormessage) {
            swal({
                type: 'error',
                title: 'Oops...',
                text: 'Não foi possível adicionar o produto'
            });
        }
    });
}

function GetDadosProduto(id, detalhe) {

    $('#txtNome').css('border-color', 'lightgrey');
    $('#selTipo').css('border-color', 'lightgrey');
    $('#selTamanho').css('border-color', 'lightgrey');
    $('#txtQuantidade').css('border-color', 'lightgrey');
    $('#txtValor').css('border-color', 'lightgrey');
    $('#txtDescricao').css('border-color', 'lightgrey');

    $.ajax({
        url: "/Produto/GetById/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id').val(result.id);
            $('#txtNome').val(result.nome);
            $('#selTipo option:selected').text(result.tipo);
            $('#selTamanho option:selected').text(result.tamanho);
            $('#txtQuantidade').val(result.quantidade);
            $('#txtValor').val(result.valor);
            $('#txtDescricao').val(result.descricao);

            $('#modalAddOrEdit').modal('show');
            $('#btnCadastrar').hide();

            if (detalhe) {

                $("#lblTitleModal").text("Detalhe do Produto");
                $("#txtNome").prop('disabled', true);
                $("#selTipo").prop('disabled', true);
                $("#selTamanho").prop('disabled', true);
                $("#txtQuantidade").prop('disabled', true);
                $("#txtValor").prop('disabled', true);
                $("#txtDescricao").prop('disabled', true);

                $('#btnAtualizar').hide();
                $('#btnLimpar').hide();


            } else {

                $("#lblTitleModal").text("Editar do Produto");
                $("#txtNome").prop('disabled', false);
                $("#selTipo").prop('disabled', false);
                $("#selTamanho").prop('disabled', false);
                $("#txtQuantidade").prop('disabled', false);
                $("#txtValor").prop('disabled', false);
                $("#txtDescricao").prop('disabled', false);

                $('#btnAtualizar').show();
                $('#btnLimpar').show();

            }
        },
        error: function (errormessage) {

        }
    });
    return false;
   
}


function Atualizar() {
    var res = Validacao();
    if (res == false) {
        return false;
    }
    var ProdutoJson = {
        Id: $('#Id').val(),
        Nome: $('#txtNome').val(),
        Tipo: $("#selTipo option:selected").text(),
        Tamanho: $("#selTamanho option:selected").text(),
        Quantidade: $('#txtQuantidade').val(),
        Valor: $('#txtValor').val(),
        Descricao: $('#txtDescricao').val()
    };
    $.ajax({
        url: "/Produto/Atualizar",
        data: JSON.stringify(ProdutoJson),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            Consultar();
            $('#modalAddOrEdit').modal('hide');
           

            if (result == 'Sucesso')
                swal({
                    type: 'success',
                    title: 'Produto atualizado com sucesso',
                    showConfirmButton: false
                })
            else
                swal({
                    type: 'error',
                    title: 'Oops...',
                    text: 'Não foi possível atualizar o Produto'
                });


        },
        error: function (errormessage) {
            swal({
                type: 'error',
                title: 'Oops...',
                text: 'Não foi possível atualizar o Produto'
            });
        }
    });
}

function Deletar(Id) {

    var ProdutoJson = {
        Id: Id,
        Nome:'',
        Tipo: '',
        Tamanho: '',
        Quantidade: 0,
        Valor: 0,
        Descricao: ''
    };

    swal({
        title: 'Deseja excluir o Produto?',
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim, quero excluir!'
    }).then((result) => {
        if (result) {

            $.ajax({
                url: "/Produto/Deletar",    
                data: JSON.stringify(ProdutoJson),
                type: "DELETE",                
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    Consultar();

                    if (result == 'Sucesso')
                        swal({
                            type: 'success',
                            title: 'Produto excluído com sucesso',
                            showConfirmButton: false
                        })
                    else
                        swal({
                            type: 'error',
                            title: 'Oops...',
                            text: 'Não foi possível excluir o Produto'
                        });
                },
                error: function (errormessage) {
                    swal({
                        type: 'error',
                        title: 'Oops...',
                        text: 'Não foi possível excluir o Produto'
                    });
                }
            });
        }
    });
}

function LimparCampos() {

    $("#lblTitleModal").text("Cadastro de Produto");
    $("#txtNome").prop('disabled', false);
    $("#selTipo").prop('disabled', false);
    $("#selTamanho").prop('disabled', false);
    $("#txtQuantidade").prop('disabled', false);
    $("#txtValor").prop('disabled', false);
    $("#txtDescricao").prop('disabled', false);

    $('#btnCadastrar').show();
    $('#btnAtualizar').hide();
    $('#btnLimpar').show();

    $('#Id').val("");
    $('#txtNome').val("");
    $('#selTipo').val("");
    $('#selTamanho').val("");
    $('#txtQuantidade').val("");
    $('#txtValor').val("");
    $('#txtDescricao').val("");    
}

function Validacao() {
    var isValid = true;

    if ($('#txtNome').val().trim() == "") {
        $('#txtNome').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtNome').css('border-color', 'lightgrey');
    }

    if ($('#selTipo').val().trim() == "") {
        $('#selTipo').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#selTipo').css('border-color', 'lightgrey');
    }

    if ($('#selTamanho').val().trim() == "") {
        $('#selTamanho').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#selTamanho').css('border-color', 'lightgrey');
    }

    if ($('#txtQuantidade').val().trim() == "") {
        $('#txtQuantidade').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtQuantidade').css('border-color', 'lightgrey');
    }

    if ($('#txtValor').val().trim() == "") {
        $('#txtValor').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtValor').css('border-color', 'lightgrey');
    }

    if ($('#txtDescricao').val().trim() == "") {
        $('#txtDescricao').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#txtDescricao').css('border-color', 'lightgrey');
    }

    return isValid;
}


