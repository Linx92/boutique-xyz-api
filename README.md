# Api boutique XYZ

## Requirements - Windows

- netcore 8 - https://dotnet.microsoft.com/en-us/download
- Visual Studio >= 2022
- MySQL Worckbench 8
---


## Base de datos
Se realizó el modelado de la base de datos mediante la librería Microsoft.EntityFrameworkCore.Tools
El diagrama se muestra de esta manera
<div align="center">
	<img src="https://github.com/user-attachments/assets/7e7bd3c8-0ba3-4d28-950d-2de2cba51a4e" >
</div>div>

```


Se adjunta la query de la base de datos BoutiqueXYZDB utilizada para las pruebas, esta debe ser ejecutada en un gestor de base de datos MySQL.

Tener en cuenta la cadena de conexión para su ejecución local

Esta variable está ubicada en el appsettings.Developmente.json
"ConnectionStrings": {
    "defaultConnection": "server=localhost;port=3306;database=BoutiqueXYZDB;user=Mi_usuario;password=My_Contraseña;"
  }
```
##
Para la prueba se definieron los usuarios de manera que estos puedan tener los roles establecidos
## /Usuario
Este endpoint devuelve los datos de los usuarios, se definió el valor de cada Rol como
Encargado = 1, Vendedor = 2, Delivery = 3 y Repartidor=4
```
[
  {
    "codigoTrabajador": 1,
    "nombre": "Juan",
    "correoElectronico": "juan@boutique.com",
    "user": "juan",
    "telefono": "957373323",
    "puesto": null,
    "rol": 1
  },
  {
    "codigoTrabajador": 2,
    "nombre": "María",
    "correoElectronico": "Maria@boutique.com",
    "user": "maria",
    "telefono": "957334321",
    "puesto": null,
    "rol": 2
  },
  {
    "codigoTrabajador": 3,
    "nombre": "Jose",
    "correoElectronico": "jose@boutique.com",
    "user": "jose",
    "telefono": "934673248",
    "puesto": null,
    "rol": 3
  },
  {
    "codigoTrabajador": 4,
    "nombre": "Pablo",
    "correoElectronico": "pablo@boutique.com",
    "user": "pablo",
    "telefono": "973264732",
    "puesto": null,
    "rol": 4
  },
  {
    "codigoTrabajador": 5,
    "nombre": "Karina",
    "correoElectronico": "karina@boutique.com",
    "user": "karina",
    "telefono": "9783488282",
    "puesto": "Puesto 1",
    "rol": 4
  },
  {
    "codigoTrabajador": 6,
    "nombre": "Laura",
    "correoElectronico": "laura@boutique.com",
    "user": "laura",
    "telefono": "951335658",
    "puesto": "Puesto 2",
    "rol": 2
  }
]
```
# /Usuario/registrar
Este endpoint registra los datos del usuario, se definió el valor de cada Rol como
Encargado = 1, Vendedor = 2, Delivery = 3 y Repartidor=4
```
{
  "nombre": "laura",
  "correoElectronico": "laura@boutique.com",
  "user": "laura",
  "passwordHash": "contraseña de prueba",
  "telefono": "951335658",
  "puesto": "Puesto 2",
  "rol": 2
}

Response body
{
  "type": "https://tools.ietf.org/html/rfc9110#section-15.5.1",
  "title": "One or more validation errors occurred.",
  "status": 400,
  "errors": {
    "Nombre": [
      "La primera letra debe ser mayúscula"
    ]
  },
  "traceId": "00-6959661c7b207c63d4bc54b1a8314125-b915821c335dfd3f-00"
}
```
Se agregaron ciertas valdiaciones con respecto a la asignación del rol
```
{
  "nombre": "Diana",
  "correoElectronico": "diana@boutique.com",
  "user": "diana",
  "passwordHash": "1234",
  "telefono": "953234976",
  "puesto": "Puesto 4",
  "rol": 5
}
Response body
{
  "message": "El rol que intenta asignar no existe"
}
```
# /Usuario/authenticate
Para fines practicos se configuró el password 1234 para todos los usuarios, de igual manera esto está debidamente encriptada a nivel de base de datos
```
{
  "user": "maria",
  "passwordHash": "1234"
}

Response body
{
"codigoTrabajador": 2,
  "nombre": "María",
  "correoElectronico": "maria@boutique.com",
  "user": "maria",
  "rol": "Vendedor",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJDb2RpZ29UcmFiYWphZG9yIjoiMiIsIm5iZiI6MTcyNTI2MjU0NywiZXhwIjoxNzI1ODY3MzQ3LCJpYXQiOjE3MjUyNjI1NDd9.wXxpcJLNOyoSfVoZuNJuTQWfOSdThTK1VBXOmz0Nwos"
}
```
Con respecto a los productos, se crearon los siguientes endpoints
# /api/producto
```
{
  "nombre": "Aceite",
  "tipo": "Liquido",
  "precio": 10,
  "cantidad": 8,
  "unidadMedida":"Ml"
  "etiquetas": [
    "Prueba 1",
    "Prueba 2"
  ]
}
Response body
{
  "message": "El rol que intenta asignar no existe"
}
```
# /api/producto
El sku de cada producto se genera internamente tomando datos del mismo producto, como el nombre el tipo, la unidad de medida, y numeros aleaterios del 2 al 9
```
[
  {
    "sku": "A-G-K-399346",
    "nombre": "Azúcar",
    "tipo": "Grano",
    "etiquetas": "Endulzante,Rubia,",
    "precio": 2.5,
    "cantidad": 7,
    "unidadMedida": "Kg",
    "productoPedidos": []
  },
  {
    "sku": "A-G-K-545534",
    "nombre": "Arroz",
    "tipo": "Grano",
    "etiquetas": "Integral,",
    "precio": 4.5,
    "cantidad": 5,
    "unidadMedida": "KG",
    "productoPedidos": []
  },
  {
    "sku": "A-L-M-433696",
    "nombre": "Aceite",
    "tipo": "Liquido",
    "etiquetas": "Prueba 1,Prueba 2,",
    "precio": 10,
    "cantidad": 8,
    "unidadMedida": "ML",
    "productoPedidos": []
  },
  {
    "sku": "L-L-M-372854",
    "nombre": "Leche",
    "tipo": "Liquido",
    "etiquetas": "Sin lactosa,250 cal,",
    "precio": 2.5,
    "cantidad": 20,
    "unidadMedida": "ML",
    "productoPedidos": []
  }
]
```
---
# api/pedido
Este endpoint solo está habilitado para que el usuario que tenga el rol de vendedor solo pueda realizar los pedidos
```
{
  "fechaPedido": "2024-09-02T09:36:53.392Z",
  "vendedor": 1,
  "productos": [
    {
      "numeroPedido": 0,
      "sku": "A-G-K-399346",
      "cantidad": 1
    }
  ]
}
Response body
{
  "message": "Forbidden - No tienes el rol requerido"
}

```
En caso el usuario tenga el rol de "Vendedor", el pedido se registrará correctamente dvolviendo el siguiente Json con el número de pedido y el codigo del usuario

```
{
  "numeroPedido": 7,
  "sku": null,
  "cantidad": 0,
  "vendedor": 2
}
```
# api/pedido/{numeroPedido}
Consulta de los pedidos realizados por numero de pedido
```
{
  "numeroPedido": 5,
  "fechaPedido": "2024-09-02T06:51:57.453",
  "fechaRecepcion": null,
  "fechaDespacho": null,
  "fechaEntrega": null,
  "vendedor": 6,
  "repartidor": null,
  "estado": 1,
  "productoPedidos": [
    {
      "numeroPedido": 5,
      "sku": "A-G-K-545534",
      "cantidad": 5
    }
  ]
}
```
Con los datos de este pedido se mostrarán cómo funciona el cambio de estado, se definió el valor de cada Estado como
 Por_atender = 1, En_proceso = 2, En_delivery = 3, Recibido = 4

# api/pedido/
Consulta de los pedidos realizados por numero de pedido
```
{
  "numeroPedido": 5,
  "estado": 1,
  "repartidor": 0
}
Error: response status is 400
Response body

  El pedido no puede actualizarse a un estado actual o anterior

```
Cada que se realiza el cambio de estado se guarda la fecha y la hora según corresponda, en la consulta al mismo numero de pedido, se puede visualizar que le fecha de recepción se registró cuando el estado se cambió a "En Proceso", la logica sería la misma con los estados posteriores.
```
{
  "numeroPedido": 5,
  "fechaPedido": "2024-09-02T06:51:57.453",
  "fechaRecepcion": "2024-09-02T05:13:01.562866",
  "fechaDespacho": null,
  "fechaEntrega": null,
  "vendedor": 6,
  "repartidor": 0,
  "estado": 2,
  "productoPedidos": [
    {
      "numeroPedido": 5,
      "sku": "A-G-K-545534",
      "cantidad": 5
    }
  ]
}
```
Para el estado cuando el estado "En delivery", se agregó la validación de solicitar el codigo del repartidor.
```
{
  "numeroPedido": 5,
  "estado": 3,
  "repartidor": 0
}

	
Error: response status is 400

Response body
  Debe asignar un repartidor
```
Si se volviera a consultar el numero de pedido N° 5, los datos sería los siguientes
```
{
  "numeroPedido": 5,
  "fechaPedido": "2024-09-02T06:51:57.453",
  "fechaRecepcion": "2024-09-02T05:13:01.562866",
  "fechaDespacho": "2024-09-02T05:19:28.428093",
  "fechaEntrega": null,
  "vendedor": 6,
  "repartidor": 5,
  "estado": 3,
  "productoPedidos": [
    {
      "numeroPedido": 5,
      "sku": "A-G-K-545534",
      "cantidad": 5
    }
  ]
}
```

##  Endpoints

Browse to [http://localhost:7116/swagger/index.html](http://localhost:7116/swagger/index.html) if your are running with visual studio to view swagger the web page with the endpoints

---
# Features

- **Docker**
- Ready to use netcore template
- Log to file and stdout
- Log to aws
- Ready to use with oracle, sql server and mysql
- Automatic services and repositories scan and register
- Secure endpoints with horus (oauth2) using **[HttpPreAuthorize("movie:read")]**
- Swagger for development
- /health endpoint

