
$().ready(() => {
    ShowTeam(1, "null");
    
    
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

    document.getElementById('Id2').innerHTML = id;
     var action = '/Libros/EditTeam';
    var enviar = new Inventario();
    HallarComplemento('Marca');
    HallarComplemento('Estado');
    HallarComplemento('Genero');

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

        var Id = document.getElementById('Id2').innerText;
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

                console.log(response);
              

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

                document.getElementById('Id2').value = response[0].Id_Libro;
                document.getElementById('Genero2').options[0] = new Option(response[0].Genero, response[0].Genero);
                document.getElementById('Genero2').selectedIndex = 0;
                document.getElementById('Marca2').options[0] = new Option(response[0].Marca, response[0].Marca);
                document.getElementById('Marca2').selectedIndex = 0;
                document.getElementById('Autor2').value = response[0].Autor;
                document.getElementById('Titulo2').value = response[0].Titulo;
              
                
                document.getElementById('Estado2').options[0] = new Option(response[0].Nom_Estado, response[0].Nom_Estado);
                document.getElementById('Estado2').selectedIndex = 0;






            }

        })

    }

    cerrarContenido() {
        $('#EditTeam').modal('hide');
        $('#CreateEqui').modal('hide');
       

       

        document.getElementById('Id').value = "";
        document.getElementById('Titulo').value = "";
        document.getElementById('Autor').value = "";
        document.getElementById('Marca').value = "";
        document.getElementById('Estado').value = "";
        document.getElementById('Genero').value = "";
       
        
        ShowTeam(1, "null");


    }


}