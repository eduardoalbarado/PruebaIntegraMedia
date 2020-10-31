# PruebaIntegraMedia

Consigna

Se necesita crear un sistema que se encargue del registro de ventas, donde también se puedan cargar los clientes y los empleados de dicha empresa, indicando su nombre, apellido, DNI, fecha de nacimiento, edad.
En caso de clientes su tarjeta de crédito, y en caso de empleados el ID o legajo. El sistema debe guardar productos, con nombre, marca, fecha de vencimiento,
precio unitario y proveedor, solamente la empresa cuenta con un solo local.
El programa debe imprimir una factura con los datos del cliente: nombre y apellido; el empleado que cobró: Nombre completo y legajo; la lista de productos: nombre del producto, precio unitario, cantidad y total; la fecha de compra y el total de todos los productos comprados.


Aplicación
Si implementara una aplicación web, ya que permite un fácil acceso de distintos dispositivos. También en base a la flexibilidad de implementación local o el cloud, permitiendo escalar si el sistema lo amerita (empezando con un contenedor o migrarlo a Azure App Service o AWS EC2). 
Arquitectura 
En base a la consigna, que se limita a un módulo de ventas, se puede usar el Patrón modelo-vista-controlador; para separar las representaciones internas de información de las formas en que se presenta y acepta la información del usuario. Mejora a futuro hacer uso de Patrón de 4 capas.
Lenguaje
Para la creación de aplicaciones web se utilizan múltiples lenguajes.

•	Backend se usará C# más precisamente NET Core 3.1 version LTS para obtener mayor tiempo de soporte. Mejora a futuro el uso de AutoMapper, y Test Unitarios.
Como ORM se usará EntityFramework en la modalidad Code First, ya que no contamos con datos ni schema previo.

•	Frontend se usará lenguajes de maquetado y scripting HTML, JavaScript. (En el caso que el sistema fuese más complejo y duradero es muy recomendable implementar Angular en el Fontend)
Base de datos
Al no tener un requerimiento de alta performance, se optó por una base de datos en un SqlServer Express. Si hubiese un incremente en el acceso a la base de datos se puede migrar a una versión superior o migrarlo a Azure donde se puede escalar dinámicamente, y disponer de alta disponibilidad.
