# Ejemplos de Entity Framework
Ejercicios tomados del curso de **Felipe Gavilán: Introducción a Entity Framework Core 6 - De Verdad**, y complementado con apuntes propios.

# Principales puntos 📋
* Crear BDD desde nuestro código de C# utilizando la técnica de code first.
* Leer, actualizar, borrar, y crear data utilizando Entity Framework Core.
* Relaciones entre tablas: Relaciones 1 a N, 1 a 1, y N a N.
* Utilización de [Fluent API](https://learn.microsoft.com/es-es/ef/ef6/modeling/code-first/fluent/types-and-properties) para configuraciones del esquema de BDD. Convenciones de nombres de EF.
* Utilización de datos complejos de BDD, como *"geography"*, que indica una latitud y longitud. Para su uso en .Net, se utilizará la librería [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite)
* Utilización de pruebas automáticas en proyectos de Entity Framework Core.
* Utilización de funciones como Sum, Average y GroupBy.
* Utilización de procedimientos almacenados utilizando Entity Framework Core.
* Carga de datos y diferencias de: eager, explicit, select y lazy loading.
* Utilización de ejecución diferida para hacer nuestro código más flexible y reutilizable.
* Uso correcto de EF, como debemos usar un pool para reciclar el DbContext.

# Pre-requisitos 📋
Como herramientas de desarrollo necesitarás:
* Visual Studio 2022 (con la versión para .NET 6)
* SQL Server (con la versión Express es suficiente)
* Tener instalado el [Command-line interface (CLI) de EF](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). Ejecutar en un cmd:
```
dotnet tool install --global dotnet-ef
```

## Antes de comenzar... entiende la base de datos que vamos a utilizar ⚙️
Los ejemplos se realizan sobre una base de datos de cines, con las salas que tiene cada cine, qué películas emiten, etcétera. A medida que avanza el curso, se va añadiendo complejidad.

Las tablas maestras (que pueden variar en función de los ejercicios), son las siguientes:
* Tabla **[Cines]**: datos maestros de cines.
* Tabla **[Generos]**: datos maestros de géneros de películas (Acción, Animación, Comedia, Ciencia ficción, Drama, etc).
* Tabla **[Pelicula]**: datos maestros de películas.
* Tabla **[Actores]**: datos maestros de actores de rodaje.

Las tablas intermedias, son las siguientes:
* Tabla **[CinesOfertas]**: ofertas que tiene un cine. Relación 1 a 1.
* Tabla **[SalasDeCine]**: salas de un cine (estándarm 3D, premium, etc). 1 cine tiene N salas.
* Tabla **[PeliculaSalaDeCine]**: en qué salas se emite una película. Relación N a N entre **[SalasDeCine]** y **[Peliculas]**.
* Tabla **[GeneroPelicula]**: géneros en los que clasificar las películas. Relación N a N entre **[Generos]** y **[Peliculas]**.
* Tabla **[PeliculasActores]**: películas en los que participan los actores. Relación N a N entre **[Actores]** y **[Peliculas]**.

El esquema de base de datos podría ser parecido al siguiente:
![My Image](00_Esquema_BDD.PNG)

# Construido con 🛠️
* [Microsoft Visual Studio Profesional 2022](https://visualstudio.microsoft.com/es/vs/) - IDE  de desarrollo
* [SQL Server Management Studio](https://docs.microsoft.com/es-es/sql/?view=sql-server-ver15/) - IDE de base de datos

## Autores ✒️
* **Felipe Gavilán** - *Trabajo Inicial* - [gavilanch](https://github.com/gavilanch/Entity-Framework-Core-De-Verdad.git)
* **David Santesteban** - *Trabajos con apuntes propios* - [davidsantes](https://github.com/davidsantes)

## Agradecimientos 🎁

* Plataforma de aprendizaje online [Udemy](https://www.udemy.com/course/introduccion-a-entity-framework-core-2-1-de-verdad/)
* A cualquiera que me invite a una cerveza 🍺. 
---

# Índice de contenidos 📋
1. [Introducción a Entity Framework](#Tema_01_Intro)
   1. [Configurando una aplicación de consola con EF Core y Code first](#Tema_01_Demo_Consola)       
   2. [Configurando una aplicación ASP MVC con EF Core y Code first](#Tema_01_Demo_MVC)         
3. [Modelado de base de datos](#Tema_02_Modelado_BDD)

---

## MÓDULO 01. Introducción a Entity Framework <a name="Tema_01_Intro"></a>
Toma de contacto con EF. 

### 1.1 Configurando una aplicación de consola con EF Core y Code first <a name="Tema_01_Demo_Consola"></a>

#### Objetivo 🚀
* Crear migraciones para crear la Base de datos en base a una clase **[Persona]**, que a través de un DBSet, creará su correspondiente tabla en la BDD.

#### Principales puntos técnicos 📋
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.SqlServer**, necesario para utilizar EF.
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.Tools**, necesario para ejecutar comandos de EF desde el Package Manager Console.
* Utilización de un DBContext: **ApplicationDbContext.cs**.
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion]**

#### Comenzando 🚀

* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion]**

#### Migraciones ⚙️
* ```Add-Migration 01_Inicial```: Código necesario para la migración con la entidad **[Personas]**
* ```Update-Database```: ejecución de la migración y creación de la BDD **[EFCorePeliculasDB_01Introduccion]**.

#### ¿Cómo queda la base de datos? 🔩
![My Image](01_Intro_Consola_Esquema_BDD.PNG)
---


### 1.2 Configurando una aplicación ASP MVC con EF Core y Code first <a name="Tema_01_Demo_MVC"></a>
Toma de contacto con EF y una aplicación ASP MVC.

#### Objetivo 🚀
* Crear migraciones para crear la Base de datos en base a una clase **[Persona]**, que a través de un DBSet, creará su correspondiente tabla en la BDD.

#### Principales puntos técnicos 📋
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.SqlServer**, necesario para utilizar EF.
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.Tools**, necesario para ejecutar comandos de EF desde el Package Manager Console.
* Utilización de un DBContext: **ApplicationDbContext.cs**.
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion_MVC]**

#### Comenzando 🚀
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Usar **appsettings.Development.json** para almacenar el connectionstring DbContextOptions
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion_MVC]**

#### Migraciones ⚙️
* ```Add-Migration 01_Inicial```: Código necesario para la migración con la entidad **[Personas]**
* ```Update-Database```: ejecución de la migración y creación de la BDD **[EFCorePeliculasDB_01Introduccion]**.

#### ¿Cómo queda la base de datos? 🔩
![My Image](01_Intro_MVC_Esquema_BDD.png)
---

## MÓDULO 02. Modelado de base de datos <a name="Tema_02_Modelado_BDD"></a>
Toma de contacto con EF. 

---