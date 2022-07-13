## Guia de Instalacion

* Se utilizó la tecnica de code first, por lo tanto se debe validar que se encuentre instalado Entity Framework Core Tools en la capa de infrastructure para realizar el Update de las migraciones con el comando PM> Update-Database

## Arquitecturas y Patrones

* Puertos y Adaptadores : Todas las entradas y salidas alcanzan o dejan el dominio a traves de un puerto. Este puerto aisla el dominio de las tecnologias externas con el objetivo de que el dominio no tenga ningún conocimiento de quien envía o recibe la entrada y salida

* CQRS (Commmand Query Responsability Segregation):
Patrón con el cual dividimos nuestro modelo de objetos en dos, un modelo para consulta(Query) y un modelo para comando(Command). Este patrón es recomendado cuando se va desarrollar lógica de negocio compleja porque nos ayuda a separar las responsabilidades y a mantener un modelo de negocio consistente.

* Mediator: Patrón de Comportamiento que permite la comunicación de varios objetos entre sí, sin que ninguno de esos objetos tenga que conocer la estructura de los otros.
Como mediador o coordinador, es el encargado de manejar la comunicación o tráfico entre las partes que forman la estructura principal, y que habremos definido en la lógica de nuestro código previamente.

## Especificaciones técnicas

* Repositorio Genérico (muy útil con el manejo de agregados)
* Inyeccion automática de Domain Services usando anotacion "[DomainService]"
* MediaTR : registra manejadores de commands y queries de forma automática (via reflexion hace scan del assembly)
* Manejador de Excepciones Global
* Pruebas Unitarias (Domain) con MSTEST
* Swagger
* HealthCheck (para base de datos) para Api
* Comand + Query + Handlers
