$(document).ready(function () {



    // Setar data atual campos de data
    var now = new Date();
    var today = now.getDate() + '/' + (now.getMonth() + 1) + '/' + now.getFullYear();
    //alert(today);

    

    if ($('#Data').val()=="") {

        $('#DataInicio').val(today);
        $('#DataFim').val(today);

    }

   

    //Preencher filtros pós post back
   
    $('#SelectEmpresa').val($('#Empresa').val());
    if ($('#Data').val() != "") {

        $('#SelectStatus').val($('#Status').val());
    }
    

    //Validações Campos Submit
    $('#form').submit(function () {
        var btn = $(document.activeElement).val()

        $('#DivMensagemSucesso').hide();
        $('#DivMensagemSucesso').empty();   

        //Tratamento botão pesquisar

        if (btn == "Pesquisar") {

            if ($('#SelectEmpresa').val() == "") {

                $('#DivMensagemSucesso').append("<strong>Favor selecionar a empresa!</strong>");
                $('#DivMensagemSucesso').show();

                return false;
            } else {


                return true;
            }
        }


        // Tratamento Botão Fechar
        if (btn=="Fechar") {

            if ($('#SelectEmpresa').val() == "") {

                $('#DivMensagemSucesso').append("<strong>Favor selecionar a empresa!</strong>");
                $('#DivMensagemSucesso').show();

                return false;

            } else {


                if(VerificaSelecao()){

                    return true;

                }else{
                    $('#DivMensagemSucesso').append("<strong>Favor selecionar os pedidos!</strong>");
                    $('#DivMensagemSucesso').show();
                    return false;

                }                

            }

            return true;
        }

        return true;

      

    });


    function VerificaSelecao(){


        if ($('input:checkbox:checked').length == 0) {
         
            return false;
        }else{

            return true;

        }

    }




    $('#CheckTodos').change(function () {
        var checkboxes = $(this).closest('form').find(':checkbox');
        if ($(this).prop('checked')) {
            checkboxes.prop('checked', true);
        } else {
            checkboxes.prop('checked', false);
        }
    });
   
});    
    

