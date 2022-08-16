# GNB.InternationalBussinessMen

<p align="left">
</p>

<h3 align="left">Languages and Tools:</h3>
<p align="left"> <a href="https://www.w3schools.com/cs/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" alt="csharp" width="40" height="40"/> </a> <a href="https://www.w3schools.com/css/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/css3/css3-original-wordmark.svg" alt="css3" width="40" height="40"/> </a> <a href="https://git-scm.com/" target="_blank" rel="noreferrer"> <img src="https://www.vectorlogo.zone/logos/git-scm/git-scm-icon.svg" alt="git" width="40" height="40"/> </a> <a href="https://www.w3.org/html/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/html5/html5-original-wordmark.svg" alt="html5" width="40" height="40"/> </a> <a href="https://developer.mozilla.org/en-US/docs/Web/JavaScript" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/javascript/javascript-original.svg" alt="javascript" width="40" height="40"/> </a> <a href="https://www.microsoft.com/en-us/sql-server" target="_blank" rel="noreferrer"> <img src="https://www.svgrepo.com/show/303229/microsoft-sql-server-logo.svg" alt="mssql" width="40" height="40"/> </a> <a href="https://reactjs.org/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/react/react-original-wordmark.svg" alt="react" width="40" height="40"/> </a> <a href="https://www.typescriptlang.org/" target="_blank" rel="noreferrer"> <img src="https://raw.githubusercontent.com/devicons/devicon/master/icons/typescript/typescript-original.svg" alt="typescript" width="40" height="40"/> </a> </p>

<h3>The Description of the project is bellow to the images</h3>

![loading](https://user-images.githubusercontent.com/16734057/183831694-62026257-1ac7-4d6d-b380-b047f1111a22.PNG)
![web home](https://user-images.githubusercontent.com/16734057/183831680-2dc5c300-539f-4e4c-9dfc-9edc8486f6ab.PNG)
![web sidebar](https://user-images.githubusercontent.com/16734057/183831721-754e9ee6-b607-4f21-84c9-4c242c0e1bfd.PNG)
![rates module](https://user-images.githubusercontent.com/16734057/183831743-d41203bd-f1a2-4ede-b1d7-f80f700d512c.PNG)
![rates module data](https://user-images.githubusercontent.com/16734057/183831744-3380a54d-8d79-4d59-8b99-e9a41e84701a.PNG)
![transaction module](https://user-images.githubusercontent.com/16734057/183831758-d85490b0-ed0c-4419-88dc-5f4f976e74aa.PNG)
![transaction module data](https://user-images.githubusercontent.com/16734057/183831763-400b2b29-ae9f-49a8-a914-0cfb351eb6c3.PNG)
![products module](https://user-images.githubusercontent.com/16734057/183831774-57dd43e9-81e2-4e77-9d52-8c2012e7bee3.PNG)
![modal id validation](https://user-images.githubusercontent.com/16734057/183831803-167a9feb-ca5c-4afb-bbee-82042ace39f1.PNG)
![products module result](https://user-images.githubusercontent.com/16734057/183831810-dd0e7f6c-e298-4cc4-b392-d403f3795bdc.PNG)

<p>
  International Business Men
Trabajas para el GNB (Gloiath National Bank), y tu jefe, Barney Stinson, te ha pedido
que diseñes e implementes una aplicación para ayudar a los ejecutivos de la empresa
que vuelan por todo el mundo. Los ejecutivos necesitan un listado de cada producto
con el que GNB comercia, y el total de la suma de las ventas de estos productos.
Para esta tarea debes crear una web y un webservice. Este webservice puede devolver
los resultados en formato XML o en JSON. Eres libre de escoger el formato con el que
te sientas más cómodo (sólo es necesario que se implemente uno de los formatos).
Recursos a utilizar:
 http://quiet-stone-2094.herokuapp.com/rates.xml o http://quiet-stone-
2094.herokuapp.com/rates.json devuelve un documento con los siguientes formatos;
XML
<?xml version="1.0" encoding="UTF-8"?>
<rates>
<rate from="EUR" to="USD" rate="1.359"/>
<rate from="CAD" to="EUR" rate="0.732"/>
<rate from="USD" to="EUR" rate="0.736"/>
<rate from="EUR" to="CAD" rate="1.366"/>
</rates>
JSON
[
{ "from": "EUR", "to": "USD", "rate": "1.359" },
{ "from": "CAD", "to": "EUR", "rate": "0.732" },
{ "from": "USD", "to": "EUR", "rate": "0.736" },
{ "from": "EUR", "to": "CAD", "rate": "1.366" }
]
Cada entrada en la colección especifica una conversión de una moneda a otra
(cuando te devuelve una conversión, la conversión contraria también se devuelve), sin
embargo, hay algunas conversiones que no se devuelven, y en caso de ser necesarias,
deberán ser calculadas utilizando las conversiones que se dispongan. Por ejemplo, en
el ejemplo no se envía la conversión de USD a CAD, esta debe ser calculada usando la
conversión USD a EUR y después EUR a CAD.
 http://quiet-stone-2094.herokuapp.com/transactions.xml o http://quiet-stone-
2094.herokuapp.com/transactions.json devuelve un documento con los siguientes
formatos:
XML
<?xml version="1.0" encoding="UTF-8"?> <transactions>
<transaction sku="T2006" amount="10.00" currency="USD"/>
<transaction sku="M2007" amount="34.57" currency="CAD"/>
<transaction sku="R2008" amount="17.95" currency="USD"/>
<transaction sku="T2006" amount="7.63" currency="EUR"/>
<transaction sku="B2009" amount="21.23" currency="USD"/>
...
</transactions>
JSON
[
{ "sku": "T2006", "amount": "10.00", "currency": "USD" },
{ "sku": "M2007", "amount": "34.57", "currency": "CAD" },
{ "sku": "R2008", "amount": "17.95", "currency": "USD" },
{ "sku": "T2006", "amount": "7.63", "currency": "EUR" },
{ "sku": "B2009", "amount": "21.23", "currency": "USD" }
]
Cada entrada en la colección representa una transacción de un producto (el cual se
identifica mediante el campo SKU), el valor de dicha transacción (amount) y la
moneda utilizada (currency).
El webservice debe tener un método desde el cuál se pueda obtener el listado de
todas las transacciones. Otro método con el que obtener todos los rates.
Y por último una página web a la que se le pase un SKU, y muestre un listado con
todas las transacciones de ese producto en EUR, y la suma total de todas esas
transacciones, también en EUR.
Por ejemplo, utilizando los datos anteriores, la suma total para el producto T2006
debería ser 14,99.
Además, necesitamos un plan B en caso que el webservice del que obtenemos la
información no esté disponible. Para ello, la aplicación debe persistir la información
cada vez que la obtenemos (eliminando y volviendo a insertar los nuevos datos).
Puedes utilizar el sistema que prefieras para ello, por ejemplo, en una base de datos
relacional.
Requisitos
Puedes utilizar cualquier framework y cualquier librería de terceros.
Recuerda que pueden faltar algunas conversiones, deberás calcularlas mediante la
información que tengas.
Separación de responsabilidades en distintas capas
Implementación de log de error y manejo de excepciones en cada capa.
Tener en cuenta los principios SOLID y correcta capitalización del código.
Uso de Inyección de dependencias.
Tests unitarios.
Puntos extra (No obligatorios)
Estamos tratando con divisas, intenta no utilizar números con coma flotante.
Después de cada conversión, el resultado debe ser redondeado a dos decimales usando
el redondeo Bank
  
</p>
