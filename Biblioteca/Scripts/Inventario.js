
$().ready(() => {
    ShowTeam(1, "null");
    //var url = window.location;
    //switch (url.pathname) {
        
    //    case "/Libros":

    //        ShowTeam(1, "null");
    //        break;

    //    case "/Libros/Index":

    //        ShowTeam(1, "null");
    //        break;

         


    //}
});
ShowTeam = (Numpagina, Dife) => {


    //var Valor = document.getElementById("searchid").value;
    //if (Valor == "") {
    //    Valor = document.getElementById("searchTeam").value;

    //} if (Valor == "") {
        Valor = "null";
    //}
    var Action = "Libros/ShowTeam";
    var Enviar = new Inventario();

    Enviar.ShowTeam(Action, Valor, Dife, Numpagina);

}

function EditTeam(id) {

    document.getElementById('Idequi2').innerHTML = id;
     var action = '/Inventario/EditTeam';
    var enviar = new Inventario();
    HallarComplemento('Marca');
    HallarComplemento('Estado');
    HallarComplemento('Dispositivo');
    enviar.EditTeam(id, action);
}

var InfoCreate = () => {
    HallarComplemento('Marca');
    HallarComplemento('Estado');
    HallarComplemento('Genero');

}

var HallarComplemento = (valores) => {
    var action = 'Libros/ValidarComplemento';

    var envio = new Inventario()
    envio.validarComplemento(action, valores);





}

var SaveTeam = (difference) => {


    var informacion = new FormData();
    if (difference == 'Create') {
        var Id = document.getElementById('Id').value;
        var Titulo = document.getElementById('Titulo').value;
        var Autor = document.getElementById('Autor').value;
        var Mar = document.getElementById('Marca').value;
        var State = document.getElementById('Estado').value;
        var Genero = document.getElementById('Genero').value;



    }

    if (difference == "Edit") {

        var Id = document.getElementById('Id2').value;
        var Titulo = document.getElementById('Titulo2').value;
        var Autor = document.getElementById('Autor2').value;
        var Mar = document.getElementById('Marca2').value;
        var State = document.getElementById('Estado2').value;
        var Genero = document.getElementById('Genero2').value;

       





    }

    informacion.append("Id", Id)
    informacion.append("Titulo", Titulo)
    informacion.append("Autor", Autor)
    informacion.append("Mar", Mar)
    informacion.append("State", State)
    informacion.append("Genero", Genero)
    informacion.append("difference", difference)

    var action = 'Libros/SaveTeam';





    var Save = new Inventario();
    Save.SaveTeam(action, informacion);









}





class Inventario {


    validarComplemento(action, valores) {

        var count = 1;
        $.ajax({
            type: "POST",
            url: action,
            data: { valores },
            success: (response) => {
                console.log(response);


                if (0 < response.length) {
                    console.log(response);

                    switch (valores) {

                        case "Marca":

                            for (var i = 0; i < response.length; i++) {
                                document.getElementById('Marca').options[count] = new Option(response[i].Nom_Marca, response[i].Nom_Marca);
                                document.getElementById('Marca2').options[count] = new Option(response[i].Nom_Marca, response[i].Nom_Marca);
                                count++;
                            }

                            break;

                        case "Estado":

                            for (var i = 0; i < response.length; i++) {
                                document.getElementById('Estado').options[count] = new Option(response[i].Nom_Estado, response[i].Nom_Estado);
                                document.getElementById('Estado2').options[count] = new Option(response[i].Nom_Estado, response[i].Nom_Estado);
                                count++;
                            }

                            break;


                        case "Genero":

                            for (var i = 0; i < response.length; i++) {
                                document.getElementById('Genero').options[count] = new Option(response[i].Nom_Genero, response[i].Nom_Genero);
                                document.getElementById('Genero2').options[count] = new Option(response[i].Nom_Genero, response[i].Nom_Genero);
                                count++;
                            }

                            break;








                    }



                }
            }
        });



    }

    SaveTeam(action, informacion) {
        $.ajax({
            type: "Post",
            url: action,
            dataType: "text",
            processData: false,
            contentType: false,
            cache: false,
            enctype: 'multipart/form-data',
            data: informacion,
            success: (response) => {

                Console.log(response);
              

                if (response = "save") {

                    this.cerrarContenido();

                } else {

                    alert("no Guardo");


                }

            }



        });



    }


    ShowTeam(action, valor, Dife, Numpagina) {
        $.ajax({
            type: "Post",
            url: action,
            data: { valor, Dife, Numpagina },
            success: (respuesta) => {
                console.log(respuesta);
                console.log(respuesta[0])

                $("#ResultTeam").html(respuesta[0]);
                $("#ResultPag").html(respuesta[1]);
            }



        });



    }



    EditTeam(id, action) {



        $.ajax({
            type: "POST",
            url: action,
            data: { id },
            success: (response) => {
                console.log(response);


                document.getElementById('Tip_Dis2').options[0] = new Option(response[0].Nom_tipo, response[0].Nom_tipo);
                document.getElementById('Marca2').options[0] = new Option(response[0].Nom_marca, response[0].Nom_marca);
                document.getElementById('modelo2').value = response[0].Modelo;
                document.getElementById('Ram2').value = response[0].Ram;
                document.getElementById('Pro2').value = response[0].Procesador;
                document.getElementById('Tip_Disco2').value = response[0].Tipo_disco;
                document.getElementById('CapDisco2').value = response[0].Capa_disco;
                document.getElementById('Costo2').value = response[0].Costo;
                document.getElementById('Buyday2').innerHTML = response[1];
                document.getElementById('Estado2').options[0] = new Option(response[0].Nom_estado, response[0].Nom_estado);






            }

        })

    }

    cerrarContenido() {
        $('#EditTeam').modal('hide');
        $('#CreateEqui').modal('hide');
        $('#ModalTitulo').modal('hide');


        document.getElementById('Idequi').value = "";
        document.getElementById('Tip_Dis').value = "";
        document.getElementById('Marca').value = "";
        document.getElementById('modelo').value = "";
        document.getElementById('Pro').value = "";
        document.getElementById('Ram').value = "";
        document.getElementById('Tip_Disco').value = "";
        document.getElementById('CapDisco').value = "";
        document.getElementById('Costo').value = "";
        document.getElementById('Estado').value = "";
        document.getElementById('Buyday').value = "";
        ShowTeam(1, "null");


    }


}