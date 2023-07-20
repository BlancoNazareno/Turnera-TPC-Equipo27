<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Kanit:wght@500&display=swap" rel="stylesheet">
    <style>
        body {
            padding: 5%;
            font-family: 'Kanit', sans-serif;
            text-align: center;
        }

        hr {
            height: 8px;
            background-image: linear-gradient(to right, #007bff, #00ff00, #ff0000);
            border: none;
            margin: 30px;
        }

        .mensaje {
            text-align: center;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <hr />
        <h1 style="text-align:center;">Space medicine</h1>
        <div class="mensaje">
            <p>Hola {nombre},</p>
            <p>Tu turno fue confirmado para el dia {fecha}.</p>
            <p>En Florentino Ameghino 946, Pacheco Partido de Tigre.</p>
            <p>En caso de no poder asistir, recordá cancelar tu turno <a href="https://localhost:44349/MisTurnos.aspx">aquí</a>.</p>
            <p>Muchas gracias</p>
        </div>
        <hr />
    </form>
</body>
</html>
