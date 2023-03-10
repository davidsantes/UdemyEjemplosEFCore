# Ejemplos de Entity Framework
Ejercicios tomados del curso de **Felipe Gavil谩n: Introducci贸n a Entity Framework Core 6 - De Verdad**, y complementado con apuntes propios.

# 脥ndice completo de contenidos 馃搵
1. **[Toma de contacto](#Toma_Contacto)**
2. **[Introducci贸n a Entity Framework](#Tema_01_Intro)**
   1. [Configurando una aplicaci贸n de consola con EF Core y Code first](#Tema_01_Demo_Consola)       
   2. [Configurando una aplicaci贸n ASP MVC con EF Core y Code first](#Tema_01_Demo_MVC)         
2. **[Modelado de base de datos](#Tema_02_Modelado_BDD)**
   1. [Migraciones](#Tema_02_Modelado_Migraciones)
   2. [Creando el proyecto](#Tema_02_Modelado_Creacion)
   3. [Llaves primarias](#Tema_02_Modelado_Llaves_Primarias)
   4. [Longitud m谩xima de campos](#Tema_02_Modelado_Longitud_Campos)
   5. [Cambiando nombres y esquema de tablas y columnas](#Tema_02_Modelado_Nombres_Esquema)
   6. [Creando la entidad Actor: Mapeo de DateTime a Date](#Tema_02_Modelado_MapeoDateTimeDate)
   7. [Otras propiedades interesantes](#Tema_02_Modelado_OtrasPropiedades)
   8. [Creando entidades](#Tema_02_Modelado_CreandoEntidades)
   9. [Creando relaciones](#Tema_02_Modelado_CreandoRelaciones)
   10. [Configurando convenciones reutilizables](#Tema_02_Modelado_ConfigurandoConvenciones)
   11. [Organizando OnModelCreating para organizar el c贸digo](#Tema_02_Modelado_OrganizandoOnModelCreating)
3. **[Consultando la base de datos](#Tema_03_Consultanto)**
   1. [Migraciones](#Tema_03_Consultanto_Migraciones)
   2. [Creando el proyecto](#Tema_03_Consultanto_Creacion)
   3. [Inserci贸n de datos con Data Seeding](#Tema_03_Consultanto_DataSeeding) 
   4. [Queries m谩s r谩pidas con ```AsNoTracking```](#Tema_03_Consultanto_AsNoTracking) 
   5. [Obtener el primer registro con ```First``` y ```FirstOrDefault```](#Tema_03_Consultanto_First) 
   6. [Obtener elementos filtrados con ```Where```](#Tema_03_Consultanto_Where) 
   7. [Ordenaci贸n con ```OrderBy``` y ```OrderByDescending```](#Tema_03_Consultanto_Order) 
   8. [Paginando con ```Skip``` y ```Take```](#Tema_03_Consultanto_Paginacion) 
   9. [Seleccionar columnas con ```Select```](#Tema_03_Consultanto_Select) 
   10. [Seleccionar columnas con ```Select``` o con Automapper](#Tema_03_Consultanto_Select) 
   11. [Consulta de datos Espaciales - Point (longitud, latitud)](#Tema_03_Consultanto_Point) 
   12. [Agrupar con ```GroupBy```](#Tema_03_Consultanto_GroupBy) 
   13. [Eager Loading - ```Include``` y ```ThenInclude```: cargando datos relacionados](#Tema_03_Consultanto_Eager) 
   14. [Select Loading - Cargado selectivo](#Tema_03_Consultanto_Select) 
   15. [Explicit loading - Carga expl铆cita](#Tema_03_Consultanto_Explicit) 
   16. [Lazy loading - Carga perezosa](#Tema_03_Consultanto_Lazy) 
   17. [Ejecuci贸n diferida (AsQueryAble): Filtros din谩micos](#Tema_03_Consultanto_Diferida)
4. **[Crear, modificar y borrar datos](#Tema_04_CRUD)**
   1. [Migraciones](#Tema_04_Crud_Migraciones)
   2. [Creando el proyecto](#Tema_04_Crud_Creacion)
   3. [Modelo Conectado y Modelo Desconectado - Estatus](#Tema_04_Crud_Modelo) 
   4. [Insertar registros de manera individual](#Tema_04_Crud_Insertar_Individual) 
   5. [Insertar registros de manera m煤ltiple](#Tema_04_Crud_Insertar_Multiple) 
   6. [Insertar registros con datos relacionados inexistentes](#Tema_04_Crud_Insertar_Relacionado) 
   7. [Insertar registros con datos relacionados inexistentes a trav茅s de un DTO (recomendado)](#Tema_04_Crud_Insertar_Relacionado_Dto) 
   8. [Insertar registros con datos relacionados existentes](#Tema_04_Crud_Insertar_Relacionado_Inexistente) 
   9. [Mapeo flexible de campos en vez de propiedades (HasField)](#Tema_04_Crud_Mapeo_Flexible) 
   10. [Actualizando registros - modelo conectado](#Tema_04_Crud_Modelo_Conectado) 
   11. [Actualizando registros - modelo desconectado](#Tema_04_Crud_Modelo_Desconectado) 
   12. [Borrado normal o f铆sico](#Tema_04_Crud_Borrado_Normal) 
   13. [Borrado suave o l贸gico](#Tema_04_Crud_Borrado_Suave) 
   14. [Filtros al nivel del modelo (a帽adir e ignorar)](#Tema_04_Crud_Filtro) 
5. **[Configurando propiedades de entidades y BDD (avanzado)](#Tema_05_Propiedades)**
   1. [Migraciones](#Tema_05_Propiedades_Migraciones)
   2. [Creando el proyecto](#Tema_05_Propiedades_Creacion)
   3. [Modos de configuraci贸n](#Tema_05_Propiedades_Modos)
   4. [Llaves primarias](#Tema_05_PropiedadesLlaves_primarias)   
   5. [Ignorando propiedades y clases para no trasladarlas a BDD](#Tema_05_Ignorando_Propiedades_Clases)
   6. [脥ndices e 铆ndices con filtros (铆ndice parcial)](#Tema_05_Propiedades_Indices)
   7. [HasConversion, conversiones de datos especiales (EF - BDD - EF) - Introducci贸n](#Tema_05_Propiedades_HasConversion)
   8. [HasConversion, conversiones de datos especiales (EF - BDD - EF) - Personalizado](#Tema_05_Propiedades_HasConversion_Personalizado)
   9. [Keyless (entidades sin Llave), ejecuci贸n de sentencias SQL (**ToSqlQuery**)](#Tema_05_Propiedades_Keyless_SQL)
   10. [Keyless (entidades sin Llave), ejecuci贸n de vistas de SQL (**ToView**)](#Tema_05_Propiedades_Keyless)
   11. [Shadow properties, propiedades Sombra, c贸mo manejar datos que no est谩n en entidades](#Tema_05_Propiedades_Shadow)
   12. [Configuraci贸n masiva de propiedades mediante automaticaci贸n de Fluent API](#Tema_05_Propiedades_Configuracion)
6. **[Configurando relaciones](#Tema_06_Configurando_Relaciones)**
   1. [Migraciones](#Tema_06_Relaciones_Migraciones)
   2. [Creando el proyecto](#Tema_06_Relaciones_Creacion)
   3. [Conceptos b谩sicos ](#Tema_06_Relaciones_Basico)
   4. [Relaciones por convenci贸n](#Tema_06_Relaciones_Convencion)
   5. [Relaciones requeridas y opcionales en la llave for谩nea](#Tema_06_Relaciones_Requeridas_Opcionales)
   6. [Relaciones con anotaciones de datos: llaves for谩neas expl铆citas con [ForeignKey]](#Tema_06_Relaciones_Foreign)
   7. [Relaciones con anotaciones: dos propiedades de navegaci贸n a la mista entidad con [InverseProperty]](#Tema_06_Relaciones_InverseProperty)
   8. [Relaci贸n 1 a 1 con Fluent API](#Tema_06_Relaciones_1_1)
   9. [Relaci贸n 1 a N con Fluent API](#Tema_06_Relaciones_1_N)
   10. [Relaci贸n N a N con Fluent API con clase intermedia](#Tema_06_Relaciones_N_N)
   11. [Relaci贸n N a N con Fluent API sin clase intermedia (skip navigation)](#Tema_06_Relaciones_N_N_sin_intermedia)
   12. [Relaciones y borrado, Fluent API y OnDelete: 驴Qu茅 Ocurre al borrar?](#Tema_06_Relaciones_Borrado)
   13. [Divisi贸n de una tabla (Table Splitting) en m谩s de una entidad (datos principales y secundarios)](#Tema_06_Relaciones_Division_Tabla)
   14. [Divisi贸n de una tabla mediante entidades de propiedad (reutilizaci贸n de entidades secundarias [Owned])](#Tema_06_Relaciones_Entidad_Propiedad)
   15. [Herencia de clases - una sola tabla por jerarqu铆a (Table per Hierarchy - TPH)](#Tema_06_Relaciones_Herencia_TPH_)
   16. [Herencia de clases - una sola tabla por cada tipo (Table per Type - TPT)](#Tema_06_Relaciones_Herencia_TPT_)
7. **[Comandos y migraciones](#Tema_07_Comandos_Y_Migraciones)**
   1. [Migraciones](#Tema_07_Comandos_Y_Migraciones_Migraciones)
   2. [Creando el proyecto](#Tema_07_Comandos_Y_Migraciones_Creacion)
   3. [Comando Get-Help](#Tema_07_Comandos_Y_Migraciones_GetHelp)
   4. [Comando Add-Migration](#Tema_07_Comandos_Y_Migraciones_Add-Migration)
   5. [Comando Update-Database](#Tema_07_Comandos_Y_Migraciones_Update-Database)
   6. [Comando Remove-Migration](#Tema_07_Comandos_Y_Migraciones_Remove-Migration)
   7. [Comando Get-Migration](#Tema_07_Comandos_Y_Migraciones_Get-Migration)
   8. [Comando Drop-Database](#Tema_07_Comandos_Y_Migraciones_Drop-Database)
   9. [Modificando las migraciones manualmente](#Tema_07_Comandos_Y_Migraciones_Modificacion_Manual)
   10. [Despliegue: Migration bundles o empaquetado de migraciones en ejecutables ](#Tema_07_Comandos_Y_Migraciones_Bundles)
   11. [Despliegue: Comando Script-Migration para general un script SQL](#Tema_07_Comandos_Y_Migraciones_Script-Migration)
   12. [Despliegue: M茅todo Database.Migrate() de c# - Aplicando las migraciones desde C#](#Tema_07_Comandos_Y_Migraciones_C)
   13. [Mejora del rendimiento: Modelos compilados con el comando Optimize](#Tema_07_Comandos_Y_Migraciones_Modelos_Compilados_)
   14. [Base de Datos Primero (Database first) - Scaffold-DbContext](#Tema_07_Comandos_Y_Migraciones_DBFirst_)
8. **[El DbContext](#Tema_08_DbContext)**
   1. [Migraciones](#Tema_08_DbContext_Migraciones)
   2. [Creando el proyecto](#Tema_08_DbContext_Creacion)
   3. [Principales propiedades del DbContext](#Tema_08_DbContext_Propiedades)
   4. [Configuraci贸n alternativa de DBContext: OnConfiguring](#Tema_08_DbContext_OnConfiguring)
   5. [Cambiando el estatus de una entidad con Entry](#Tema_08_DbContext_Estatus)
   6. [Actualizando algunas propiedades](#Tema_08_DbContext_Actualizar_Propiedades)
   7. [Sobrescribir SaveChanges](#Tema_08_DbContext_Sobrescribir_SaveChanges)
   8. [Inyecci贸n de dependencias por constructor en DbContext](#Tema_08_DbContext_Iny_Dependencias)
   9. [Eventos que se pueden capturar en el DBContext](#Tema_08_DbContext_Eventos)
   10. [Sentencias SQL - Select](#Tema_08_DbContext_SQL_Select)
   11. [Sentencias SQL - Inserts, updates, deletes](#Tema_08_DbContext_SQL_CRUD)
   12. [Sentencias SQL - ToSqlQuery() - Centralizando queries Arbitrarios](#Tema_08_DbContext_SQL_ToSqlQuery)
   13. [Uso de procedimientos almacenados](#Tema_08_DbContext_SQL_SP)
   14. [Transacciones por defecto](#Tema_08_DbContext_Transacciones_por_defecto)
   15. [Transacciones manuales - el mecanismo BeginTransaction() - una transacci贸n para varios SaveChanges](#Tema_08_DbContext_Transacciones_Manuales)
9. **[Entity Framework avanzado](#Tema_09_EF_Avanzado)**
   1. [Migraciones](#Tema_09_EF_Avanzado__Migraciones)
   2. [Creando el proyecto](#Tema_09_EF_Avanzado_Creacion)
   3. [Funciones escalares](#Tema_09_EF_Avanzado_Funciones_Escalares)
   4. [Funciones con valores de tabla](#Tema_09_EF_Avanzado_Funciones_Tabla)
   5. [Columnas calculadas (HasComputedColumnSql)](#Tema_09_EF_Avanzado_Columnas_Calculadas)
   6. [Campo de secuencia para ordenaciones (HasSequence)](#Tema_09_EF_Avanzado_Campo_Secuencia)
   7. [Conflictos de concurrencia por campo ([ConcurrencyCheck])](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Campo)
   8. [Conflictos de concurrencia por fila ([Timestamp])](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Fila)
   9. [Conflictos de concurrencia, mensajes de respuesta amigables capturando DbUpdateConcurrencyException](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Mensajes_Amigables)
   10. [Conflictos de concurrencia con el modelo desconectado](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Desconectado)
   11. [Tablas temporales (vigentes + hist贸rico): introducci贸n](#Tema_09_EF_Avanzado_Tablas_Intro)
   12. [Tablas temporales: inserci贸n, edici贸n, borrado](#Tema_09_EF_Avanzado_Tablas_CRUD)
   13. [Tablas temporales: consulta de tabla temporal e hist贸rica (TemporalAll)](#Tema_09_EF_Avanzado_Tablas_TemporalAsOf)
   14. [Tablas temporales: consulta por fecha concreta (TemporalAsOf())](#Tema_09_EF_Avanzado_Tablas_TemporalAsOf)
   15. [Tablas temporales: consulta por rangos de fechas (TemporalFromTo(), TemporalContainedIn(), TemporalBetween()](#Tema_09_EF_Avanzado_Tablas_Temporal__Rangos)
   16. [Tablas temporales: restaurando un registro borrado](#Tema_09_EF_Avanzado_Tablas_Temporal_Borrado)
   17. [Tablas temporales: personalizaci贸n de nombre de columnas y de tabla](#Tema_09_EF_Avanzado_Tablas_Temporal_Personalizacion)
   18. [Trabajando con el DbContext en otro proyecto](#Tema_09_EF_Avanzado_Tablas_Temporal_DbContext)
10. **[Entity Framework y pruebas autom谩ticas](#Tema_10_Pruebas_Automaticas)**
    1. [Migraciones](#Tema_10_Test_Migraciones)
    2. [Creando el proyecto](#Tema_10_Test_Creacion)
    3. [Configurando el Proveedor en memoria ```UseInMemoryDatabase```](#Tema_10_Test_Memoria)
    4. [La primera prueba unitaria con EF Core](#Tema_10_Test_Primer_Test)
    5. [Configurando AutoMapper para pruebas - Pruebas negativas](#Tema_10_Test_AutoMapper)
    6. [Usando LocalDb para pruebas de integraci贸n](#Tema_10_Test_LocalDb)
11. **[Entity Framework y ASP Net Core](#Tema_11_EF_Y_ASP)**
    1. [Migraciones](#Tema_11_Asp_Migraciones)
    2. [Tiempo de Vida de los Servicios y del DBContext](#Tema_11_Asp_Vida)
    3. [Instanciando el DbContext en un Singleton](#Tema_11_Asp_Singleton)
    4. [Programaci贸n As铆ncrona](#Tema_11_Asp_Programa_Asincrona)
    5. [Reciclando el DbContext (```AddDbContextPool```)](#Tema_11_Asp_Reciclando_DbContext)
    6. [Factor铆a de DbContexts (```AddDbContextFactory```) ](#Tema_11_Asp_Factoria_DbContext)
    7. [Consideraciones para Blazor Server](#Tema_11_Asp_Blazor)

# Toma de contacto  馃殌 <a name="Toma_Contacto"></a>

## Principales puntos 馃搵
* Crear BDD desde nuestro c贸digo de C# utilizando la t茅cnica de code first.
* Leer, actualizar, borrar, y crear data utilizando Entity Framework Core.
* Relaciones entre tablas: Relaciones 1 a N, 1 a 1, y N a N.
* Utilizaci贸n de [Fluent API](https://learn.microsoft.com/es-es/ef/ef6/modeling/code-first/fluent/types-and-properties) para configuraciones del esquema de BDD. Convenciones de nombres de EF.
* Utilizaci贸n de datos complejos de BDD, como *"geography"*, que indica una latitud y longitud. Para su uso en .Net, se utilizar谩 la librer铆a [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite)
* Utilizaci贸n de pruebas autom谩ticas en proyectos de Entity Framework Core.
* Utilizaci贸n de funciones como Sum, Average y GroupBy.
* Utilizaci贸n de procedimientos almacenados utilizando Entity Framework Core.
* Carga de datos y diferencias de: eager, explicit, select y lazy loading.
* Utilizaci贸n de ejecuci贸n diferida para hacer nuestro c贸digo m谩s flexible y reutilizable.
* Uso correcto de EF, como debemos usar un pool para reciclar el DbContext.

## Pre-requisitos 馃搵
Como herramientas de desarrollo necesitar谩s:
* Visual Studio 2022 (con la versi贸n para .NET 6)
* SQL Server (con la versi贸n Express es suficiente)
* Tener instalado el [Command-line interface (CLI) de EF](https://learn.microsoft.com/en-us/ef/core/cli/dotnet). Ejecutar en un cmd:
```
dotnet tool install --global dotnet-ef
```

## Antes de comenzar... entiende la base de datos que vamos a utilizar 鈿欙笍
Los ejemplos se realizan sobre una base de datos de cines, con las salas que tiene cada cine, qu茅 pel铆culas emiten, etc茅tera. A medida que avanza el curso, se va a帽adiendo complejidad.

Las tablas maestras (que pueden variar en funci贸n de los ejercicios), son las siguientes:
* Tabla **[Cines]**: datos maestros de cines.
* Tabla **[Generos]**: datos maestros de g茅neros de pel铆culas (Acci贸n, Animaci贸n, Comedia, Ciencia ficci贸n, Drama, etc).
* Tabla **[Pelicula]**: datos maestros de pel铆culas.
* Tabla **[Actores]**: datos maestros de actores de rodaje.

Las tablas intermedias, son las siguientes:
* Tabla **[CinesOfertas]**: ofertas que tiene un cine. Relaci贸n 1 a 1.
* Tabla **[SalasDeCine]**: salas de un cine (est谩ndarm 3D, premium, etc). 1 cine tiene N salas.
* Tabla **[PeliculaSalaDeCine]**: en qu茅 salas se emite una pel铆cula. Relaci贸n N a N entre **[SalasDeCine]** y **[Peliculas]**.
* Tabla **[GeneroPelicula]**: g茅neros en los que clasificar las pel铆culas. Relaci贸n N a N entre **[Generos]** y **[Peliculas]**.
* Tabla **[PeliculasActores]**: pel铆culas en los que participan los actores. Relaci贸n N a N entre **[Actores]** y **[Peliculas]**.

## Esquema de base de datos <a name="Esquema_BDD"></a>鈿欙笍
![My Image](00_Esquema_BDD.PNG)

## Construido con 馃洜锔?
* [Microsoft Visual Studio Profesional 2022](https://visualstudio.microsoft.com/es/vs/) - IDE  de desarrollo
* [SQL Server Management Studio](https://docs.microsoft.com/es-es/sql/?view=sql-server-ver15/) - IDE de base de datos

## Autores 鉁掞笍
* **Felipe Gavil谩n** - *Trabajo Inicial* - [gavilanch](https://github.com/gavilanch/Entity-Framework-Core-De-Verdad.git)
* **David Santesteban** - *Trabajos con apuntes propios* - [davidsantes](https://github.com/davidsantes)

## Agradecimientos 馃巵

* Plataforma de aprendizaje online [Udemy](https://www.udemy.com/course/introduccion-a-entity-framework-core-2-1-de-verdad/)
* A cualquiera que me invite a una cerveza 馃嵑.

---

# M脫DULO 01. Introducci贸n a Entity Framework <a name="Tema_01_Intro"></a>
**Objetivo:** creaci贸n y configuraci贸n de una base de datos.
**Principales caracter铆sticas del m贸dulo:**
* Code First: a partir de C#, se crea la BDD.
* Database First: ya existe la BDD.

## 1.1 Configurando una aplicaci贸n de consola con EF Core y Code first <a name="Tema_01_Demo_Consola"></a>

### Objetivo 馃殌
* Crear migraciones para crear la Base de datos en base a una clase **[Persona]**, que a trav茅s de un DBSet, crear谩 su correspondiente tabla en la BDD.

### Principales puntos t茅cnicos 馃搵
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.SqlServer**, necesario para utilizar EF.
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.Tools**, necesario para ejecutar comandos de EF desde el Package Manager Console.
* Utilizaci贸n de un DBContext: **ApplicationDbContext.cs**.
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion]**

### Comenzando 馃殌

* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion]**

### Migraciones 鈿欙笍
* ```Add-Migration 01_Inicial```: C贸digo necesario para la migraci贸n con la entidad **[Personas]**
* ```Update-Database```: ejecuci贸n de la migraci贸n y creaci贸n de la BDD **[EFCorePeliculasDB_01Introduccion]**.

### 驴C贸mo queda la base de datos? 馃敥
![My Image](01_Intro_Consola_Esquema_BDD.PNG)
---

## 1.2 Configurando una aplicaci贸n ASP MVC con EF Core y Code first <a name="Tema_01_Demo_MVC"></a>
Toma de contacto con EF y una aplicaci贸n ASP MVC.

### Objetivo 馃殌
* Crear migraciones para crear la Base de datos en base a una clase **[Persona]**, que a trav茅s de un DBSet, crear谩 su correspondiente tabla en la BDD.

### Principales puntos t茅cnicos 馃搵
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.SqlServer**, necesario para utilizar EF.
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.Tools**, necesario para ejecutar comandos de EF desde el Package Manager Console.
* Utilizaci贸n de un DBContext: **ApplicationDbContext.cs**.
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion_MVC]**

### Comenzando 馃殌
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Usar **appsettings.Development.json** para almacenar el connectionstring DbContextOptions
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion_MVC]**

### Migraciones 鈿欙笍
* ```Add-Migration 01_Inicial```: C贸digo necesario para la migraci贸n con la entidad **[Personas]**
* ```Update-Database```: ejecuci贸n de la migraci贸n y creaci贸n de la BDD **[EFCorePeliculasDB_01Introduccion]**.

### 驴C贸mo queda la base de datos? 馃敥
![My Image](01_Intro_Consola_Esquema_BDD.PNG)
---

# M脫DULO 02. Modelado de base de datos <a name="Tema_02_Modelado_BDD"></a>
**Objetivo:** creaci贸n y configuraci贸n de una base de datos a trav茅s de Code First y migraciones. Exceptuando las migraciones, el resto vale para Database first).
**Principales caracter铆sticas del m贸dulo:**
* Creaci贸n de la BDD de la que se basar谩 el resto de ejemplos a trav茅s de entidades cine, pel铆cula, actor, etc, de c# (code first).
* Creaci贸n de llaves primarias, tanto por convenci贸n como por configuraci贸n.
* Campos de texto: longitud m谩xima de los campos, que no sean nulos y tipo de dato de la columna.
* Campos espaciales (longitud, latitud): utilizaci贸n de la librer铆a [**NetApologySuite**](https://github.com/NetTopologySuite/NetTopologySuite).
* Campos Unicode para reducir el tama帽o de dicho campo y que no acepte caracteres extra帽os en una URL (```varchar``` vs ```nvarchar```).
* Configuraci贸n de relaciones 1 a 1, 1 a N, N a N.
* Configuraci贸n de relaciones N a N de manera autom谩tica (renunciando al control de la clase intermedia) o manual (debemos configurar completamente la tabla intermedia, aunque es recomendable).
* Hacer configuraciones por convenciones autom谩ticas de EF:
  * Por atributo en la entidad (```Key, StringLength, MaxLength, Required, etc```)
  * Por Fluent API del ```DBContext``` (m茅todo ```OnModelCreating```).
  * Configurando convenciones reutilizables: por ejemplo, si queremos que un ```DateTime``` de c# se mapee siempre a ```date``` de SQL.
* Utilizaci贸n de **IEntityTypeConfiguration** para separar en clases las configuraciones de Fluent API.

## 脥ndice:
1. [Migraciones](#Tema_02_Modelado_Migraciones)
2. [Creando el proyecto](#Tema_02_Modelado_Creacion)
3. [Llaves primarias](#Tema_02_Modelado_Llaves_Primarias)
4. [Longitud m谩xima de campos](#Tema_02_Modelado_Longitud_Campos)
5. [Cambiando nombres y esquema de tablas y columnas](#Tema_02_Modelado_Nombres_Esquema)
6. [Creando la entidad Actor: Mapeo de DateTime a Date](#Tema_02_Modelado_MapeoDateTimeDate)
7. [Otras propiedades interesantes](#Tema_02_Modelado_OtrasPropiedades)
8. [Creando entidades](#Tema_02_Modelado_CreandoEntidades)
9. [Creando relaciones](#Tema_02_Modelado_CreandoRelaciones)
10. [Configurando convenciones reutilizables](#Tema_02_Modelado_ConfigurandoConvenciones)
11. [Organizando OnModelCreating para organizar el c贸digo](#Tema_02_Modelado_OrganizandoOnModelCreating)
---

## 2.0 Migraciones 鈿欙笍 <a name="Tema_02_Modelado_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_02_Modelado_BDD]**.

### 2.0.1 驴C贸mo queda la base de datos? <a name="Tema_02_Modelado_Esquema"></a> 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)

## 2.1 Creando el proyecto <a name="Tema_02_Modelado_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **02_Modelado_Bdd**
* BDD utilizada: **[EFCorePeliculasDB_02_Modelado_BDD]**

## 2.2 Llaves primarias <a name="Tema_02_Modelado_Llaves_Primarias"></a>
* **Con convenci贸n de EF**: si un campo se llama "Id" o "NombreTablaId" autom谩ticamente se configura como una llave primaria
* **Sin convenci贸n de EF**: para determinar que un campo [identificador] es una llave primaria, se puede hacer con atributos ```[Key]``` o mediante Fluent API del ```ApplicationDbContext``` (m茅todo ```OnModelCreating```)

## 2.3 Longitud m谩xima de campos <a name="Tema_02_Modelado_Longitud_Campos"></a>
* Longitud m谩xima:
  * **StringLength y MaxLength**: revisar la clase Genero.cs.
  * **A trav茅s de Fluent API**: revisar ```ApplicationDbContext``` (m茅todo ```OnModelCreating```)
* Campos no nulos:
  * **Required**: revisar la clase Genero.cs.
  * **A trav茅s de Fluent API**: revisar ```ApplicationDbContext``` (m茅todo ```OnModelCreating```) 

## 2.4 Cambiando nombres y esquema de tablas y columnas <a name="Tema_02_Modelado_Nombres_Esquema"></a>
* Si no quiero que la tabla o columnas, utilicen el mismo nombre que la entidad, o si quiero a帽adir (opcionalmente), el esquema:
  * **Tablas**: revisar c贸digo comentado en Genero.cs ```[Table("TablaGeneros", Schema = "peliculas")]```.
  * **Columnas**:  revisar c贸digo comentado en Genero.cs ```[Column("NombreGenero")]```.
  * **A trav茅s de Fluent API**: revisar ```ApplicationDbContext``` (m茅todo ```OnModelCreating```) y ```GeneroConfig.cs```. El c贸digo est谩 comentado.

## 2.5 Creando la entidad Actor: Mapeo de DateTime a Date <a name="Tema_02_Modelado_MapeoDateTimeDate"></a>
* Campo Actor.cs **FechaNacimiento**, de tipo fecha:
  * Por defecto, un campo ```DateTime``` se va a mapear en BDD con un tipo ```datetime2``` (con hora, minutos...) y no va a ser null.
  * Mapear a tipo ```Date``` en vez de ```datetime2```:
    * Modo 1: Poner en el campo el atributo [Column(TypeName = "Date")]
    * Modo 2: A trav茅s de Fluent API, revisar ```ApplicationDbContext``` (m茅todo ```OnModelCreating```) y ```ActorConfig.cs```. El c贸digo est谩 comentado.
  * Mapear a nullable: ```DateTime? FechaNacimiento```.

## 2.6 Otras propiedades interesantes <a name="Tema_02_Modelado_OtrasPropiedades"></a>
* **Uso de Enums**: campo de tipo enum, en SalaDeCine.cs, de tipo ```TipoSalaDeCine``` (enum).
  * Crear谩 un campo de tipo num茅rico.
* **Valores por defecto**:
  * Para configurar valores por defecto, utilizaremos en la configuraci贸n **HasDefaultValue** (un valor por defecto de C#) o **HasDefaultValueSql** (para utilizar funciones de sql como ```getdate()```).

## 2.7 Creando entidades <a name="Tema_02_Modelado_CreandoEntidades"></a>
* Clase ```Cine```, caracter铆sticas destacables:
  * Ubicaci贸n geogr谩fica, que se guardar谩 en BDD en un campo de tipo ```geography```. Para ello, se utilizar谩 la librer铆a [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite) y el tipo ```Point```.
  * Para usar [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite) en el program.cs, cuando se crea ```builder.Services.AddDbContext```, hay que informarlo.
* Clase ```SalaDeCine```, caracter铆sticas destacables:
  * La propiedad **Precio** es decimal. Por defecto crear谩 en la base de datos un ```decimal(18,2)```. Para limitar las precisiones a 9 y 2 comas flotantes, y que ocupe casi la mitad de bytes:
    * Modo 1: Revisar SalaDeCine.cs ```[Precision(precision: 9, scale: 2)]```
    * Modo 2: A trav茅s de Fluent API (revisar la clase ```SalaDeCineConfig.cs```)
* Clase ```Pelicula```, caracter铆sticas destacables:
  * La propiedad **Url** solo aceptar谩 **Unicode** (```varchar```), por lo que no aceptar谩 caracteres extra帽os (```nvarchar```). Para hacerlo:
    * Modo 1: Revisar Pelicula.cs ```[Unicode(false)]```
    * Modo 2: A trav茅s de Fluent API (revisar la clase ```PeliculaConfig.cs```)   

## 2.8 Creando relaciones <a name="Tema_02_Modelado_CreandoRelaciones"></a> 
* **Relaci贸n 1 a 1**:
  * Oferta de un cine:
    * 1 Cine tiene 1 oferta.
    * Para enlazar:
      * Clase ```Cine```: tendr谩 como propiedad a ```CineOferta```.
      * Clase ```CineOferta```: tendr谩 como propiedad el cine ```CineId```, indicando que es una clave for谩nea.     
* **Relaci贸n 1 a N**:
  * Cine con sus salas de cine (2D, 3D, etc):
    * 1 Cine tiene N salas con precios diferentes.
    * Para enlazar:
      * Clase ```Cine```: 
        * Tendr谩 una lista de ```SalaDeCine```. En este caso, es ```HashSet``` (no ordena aunque es m谩s r谩pido). Si se quiere, podr铆a ser ```ICollection```, ```List```, etc.
      * Clase ```SalaDeCine```: 
        * Tendr谩 como propiedad de navegaci贸n a la clase ```Cine```.
        * Tendr谩 como propiedad el cine ```CineId```, indicando que es una clave for谩nea.     
* **Relaci贸n N a N**:
  * 1 pel铆cula puede tener N g茅neros, y 1 g茅nero puede tener N pel铆culas.
  * 1 pel铆cula puede emitirse en N salas de cine, y 1 sala de cine puede emitir N pel铆culas.
  * 1 actor puede participar en N pel铆culas, y 1 pel铆cula pueden participar N actores.
  * Para enlazar, modos de generaci贸n:
    * **De manera autom谩tica (No recomendado)**: se renuncia al control directo de la tabla intermedia, ya que no existe entidad que lo maneje.
      * Clase ```Pelicula``` una lista de ```Generos```. Se ha puesto como HashSet.
      * Clase ```Genero``` una lista de ```Peliculas```. Se ha puesto como HashSet.
      * Clase ```Pelicula``` una lista de ```SalaDeCine```. Se ha puesto como HashSet.
      * Clase ```SalaDeCine``` una lista de ```Peliculas```. Se ha puesto como HashSet.      
    * **De manera manual (S铆 recomendado)**: si se quiere introducir informaci贸n extra en la tabla intermedia que relacione pel铆cula y actores, como el nombre del personaje y el nombre de los actores, o en qu茅 orden se mostrar谩n los actores en una pel铆cula.
      * Clase ```PeliculaActor``` es la entidad intermedia, donde estar谩n: 
        * Las propiedades de uni贸n ```PeliculaId``` y ```ActorId```.
        * Las propiedades de navegaci贸n ```Pelicula``` y ```Actor```.
      * Clase ```Pelicula```, una lista de ```PeliculaActor```.
      * Clase ```Actor```, una lista de ```PeliculaActor```.
      * Se deber谩 configurar la llave primaria compuesta:
        * Mediante Fluent API: ```builder.HasKey(prop => new { prop.PeliculaId, prop.ActorId });```

## 2.9 Configurando convenciones reutilizables <a name="Tema_02_Modelado_ConfigurandoConvenciones"></a> 
* Por ejemplo, EF mapea un string a un nvarchar(max). Esto no quiere decir que no se pueda tener dicho caso, sino que no va a ser el comportamiento por defecto.
* De esta manera se puede ahorrar mucho c贸digo repetido.
* Existe un ejemplo en ```ApplicationDbContext```, m茅todo ```ConfigureConventions```, para que los m茅todos ```DateTime``` sean mapeados a ```Date```.
* Si se quiere que alg煤n m茅todo ```DateTime``` se convierta a otro tipo, habr谩 que hacerlo expl铆citamente. Existe un ejemplo comentado en ```ActorConfig```.

## 2.10 Organizando OnModelCreating para organizar el c贸digo <a name="Tema_02_Modelado_OrganizandoOnModelCreating"></a> 
* Se pueden crear clases m谩s peque帽as para organizar el Fluent API. Revisar ```OnModelCreating```.
* Se podr谩n registrar las clases 1 a 1 o todo el ensamblado a la vez.

---

# M脫DULO 03. Consultando datos <a name="Tema_03_Consultanto"></a>
**Objetivo:** creaci贸n de m茅todos de consulta.
**Principales caracter铆sticas del m贸dulo:**.
1. [Migraciones](#Tema_03_Consultanto_Migraciones)
2. [Creando el proyecto](#Tema_03_Consultanto_Creacion)
3. [Inserci贸n de datos con Data Seeding](#Tema_03_Consultanto_DataSeeding) 
4. [Queries m谩s r谩pidas con ```AsNoTracking```](#Tema_03_Consultanto_AsNoTracking) 
5. [Obtener el primer registro con ```First``` y ```FirstOrDefault```](#Tema_03_Consultanto_First) 
6. [Obtener elementos filtrados con ```Where```](#Tema_03_Consultanto_Where) 
7. [Ordenaci贸n con ```OrderBy``` y ```OrderByDescending```](#Tema_03_Consultanto_Order) 
8. [Paginando con ```Skip``` y ```Take```](#Tema_03_Consultanto_Paginacion) 
9. [Seleccionar columnas con ```Select```](#Tema_03_Consultanto_Select) 
10. [Seleccionar columnas con ```Select``` o con Automapper](#Tema_03_Consultanto_Select) 
11. [Consulta de datos Espaciales - Point (longitud, latitud)](#Tema_03_Consultanto_Point) 
12. [Agrupar con ```GroupBy```](#Tema_03_Consultanto_GroupBy) 
13. [Eager Loading - ```Include``` y ```ThenInclude```: cargando datos relacionados](#Tema_03_Consultanto_Eager) 
14. [Select Loading - Cargado selectivo](#Tema_03_Consultanto_Select) 
15. [Explicit loading - Carga expl铆cita](#Tema_03_Consultanto_Explicit) 
16. [Lazy loading - Carga perezosa](#Tema_03_Consultanto_Lazy) 
17. [Ejecuci贸n diferida (AsQueryAble): Filtros din谩micos](#Tema_03_Consultanto_Diferida)
---

## 3.0 Migraciones 鈿欙笍 <a name="Tema_03_Consultanto_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_03_Consulta_BDD]**.
  * Creaci贸n del esquema.
  * Inserci贸n de datos de prueba.

### 3.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 3.1 Creando el proyecto <a name="Tema_03_Consultanto_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **03_Consultando_Datos**
* BDD utilizada: **[EFCorePeliculasDB_03_Consulta_BDD]**

## 3.2 Inserci贸n de datos con Data Seeding <a name="Tema_03_Consultanto_DataSeeding"></a> 
* Se puede realizar una carga de datos inicial a trav茅s del Data Seeding.
* Revisar el m茅todo ```OnModelCreating``` de la clase ```ApplicationDbContext```.
* Se llama a la clase ```SeedingModuloConsulta```, donde se insertan los datos de la base de datos.
* Al a帽adir la migraci贸n ```DatosDePrueba``` a帽ade todos esos datos.

## 3.3 Queries m谩s r谩pidas con ```AsNoTracking``` <a name="Tema_03_Consultanto_AsNoTracking"></a> 
* Si no se tiene inter茅s en manejar el estado de una entidad (updated, etc), se puede utilizar ```AsNoTracking```.
* Se utiliza para cuando el fin es lectura pero no actualizaci贸n de los datos.
* **Ventaja:** son m谩s r谩pidos que los queries normales.
* Se puede hacer la configuraci贸n de AsNoTracking:
  * De manera individual: revisar ```GenerosController```, c贸digo comentado en m茅todo ```Get()```.
  * De manera global: 
    * Revisar ```program```, c贸digo ```UseQueryTrackingBehavior``` a la hora de configurar el DbContext.
    * Si se quiere activar el seguimiento de un m茅todo, se puede utilizar ```.AsTracking()```. revisar ```GenerosController```, c贸digo comentado en m茅todo ```Get()```.

## 3.4 Obtener el primer registro con ```First``` y ```FirstOrDefault``` <a name="Tema_03_Consultanto_First"></a> 
* Revisar ```GenerosController```, c贸digo en m茅todo ```GetPrimerGeneroConNombreEmpiezaConLetraC()```.

## 3.5 Obtener elementos filtrados con ```Where```<a name="Tema_03_Consultanto_Where"></a> 
* Revisar ```GenerosController```, c贸digo en m茅todo ```GetFiltroPorNombre()```.
* Se puede filtrar por m谩s de un elemento, por ejemplo, que empiece por una letra y otra. Revisar ```GenerosController```, c贸digo comentado en m茅todo ```GetFiltroPorNombre()```.

## 3.6 Ordenaci贸n con ```OrderBy``` y ```OrderByDescending```<a name="Tema_03_Consultanto_Order"></a> 
* Revisar ```GenerosController```, c贸digo en m茅todo ```Get()```.

## 3.7 Paginando con ```Skip``` y ```Take```<a name="Tema_03_Consultanto_Paginacion"></a> 
* Para no traer todos los registros de la base de datos.
* Para ello, se utiliza Take y Skip.
* Revisar ```GenerosController```, c贸digo en m茅todo ```GetPaginacion()```.

## 3.8 Seleccionar columnas con ```Select```<a name="Tema_03_Consultanto_Select"></a> 
* Para no traer todos los campos de una entidad.
* Revisar ```AutoresController```, c贸digo en m茅todo ```GetConSelectAnonimo()``` y ```GetConSelectADto```.
* Esto genera una SQL (se puede ver en la consola.exe de VS) que retorna solo los datos solicitados.

## 3.9 Seleccionar columnas con ```Select``` o con Automapper<a name="Tema_03_Consultanto_Select"></a> 
* Para no traer todos los campos de una entidad.
* Revisar ```AutoresController```, c贸digo en m茅todo ```GetConSelectAnonimo()``` y ```GetConSelectADto```.
* Esto genera una SQL (se puede ver en la consola.exe de VS) que retorna solo los datos solicitados.
* Tambi茅n se puede ahorrar el Select utilizando Automapper. 
  * Revisar ```AutoresController```, c贸digo en m茅todo ```GetAutomapper()```. Revi
  * Revisar la clase ```AutoMapperProfiles```.

## 3.10 Consulta de datos Espaciales - Point (longitud, latitud)<a name="Tema_03_Consultanto_Point"></a> 
* Para datos complejos como latitud / longitud, se puede utilizar **NetTopologySuite**. Se puede filtrar, o indicar los cines o puntos m谩s cercanos.
* Revisar:
  * ```CinesController```, c贸digo en m茅todo ```GetCinesCercanosConNetTopologySuite()```.
  * Revisar la clase ```AutoMapperProfiles```, donde se hacen transformaciones de longitud y latitud.

## 3.11 Agrupar con ```GroupBy```<a name="Tema_03_Consultanto_GroupBy"></a> 
* Revisar ```PeliculasController```, c贸digo en m茅todo ```GetAgrupadasPorCantidadDeGeneros()```.

## 3.12 Eager Loading - ```Include``` y ```ThenInclude```: cargando datos relacionados <a name="Tema_03_Consultanto_Eager"></a> 
* **Eager loading:** en la query se indica expl铆citamente los datos a cargar. Hay que utilizar include para los hijos a retornar.
* Revisar en **PeliculasController**, m茅todo ```GetEagerLoading```:
  * **Include**: permite cargar el hijo.
  * **ThenInclude**: permite entrar en el hijo del hijo del hijo. Por ejemplo, en una pel铆cula, que cargue la tabla intermedia peliculas actores, y a su vez los actores. 
  * **IgnoreCycles**: para evitar redundancia c铆clica (una clase pel铆cula tiene actores, pero los actores tienen pel铆culas), se utiliza IgnoreCycles en program.cs  
  * Tambi茅n se ordenan los hijos y se filtran por valores espec铆ficos (por ejemplo, que la fecha de nacimiento de los actores sea >= 1980)

## 3.13 Select Loading - Cargado selectivo <a name="Tema_03_Consultanto_Select"></a> 
* **Select loading:** para devolver clases an贸nimas con solo los datos que me interesan.
  * Por ejemplo, nombre pel铆cula y n煤mero de cines que la emiten. 
  * Es una opci贸n a tener en cuenta para queries complicadas.
* En anteriores ejemplos se ha hecho un select simple, pero se pueden cargar entidades relacionadas.
* Revisar en **PeliculasController**, m茅todo ```GetSelectLoading```:
  * Adem谩s de devolver una clase an贸nima, devuelve datos interesantes como el n煤mero de coincidencias total.

## 3.14 Explicit loading - Carga expl铆cita <a name="Tema_03_Consultanto_Explicit"></a> 
* **Explicit loading:** 煤til para hacer filtros en los hijos del padre, u operaciones secundarias con los hijos.
  * Se carga en diferentes l铆neas de c贸digo.
  * Es necesario utilizar AsTracking().
  * No es tan eficiente como hacer 1 query, ya que obliga a volver a cargar la entidad principal. 
  * Es m谩s recomendado hacer eager o select loading.
* Revisar en **PeliculasController**, m茅todo ```GetExplicitLoading```.

## 3.15 Lazy loading - Carga perezosa <a name="Tema_03_Consultanto_Lazy"></a> 
* **Lazy loading:** (no recomendado y no existe m茅todo de ejemplo en el c贸digo):
  * Si alguien intenta acceder a datos de hijos, los intentar谩 cargar. Si los datos hijos no han sido cargados, los carga de las bdd. Si ya est谩 cargado en memoria, utiliza esa. Un ejemplo algo oculto es Automapper, que intentar谩 analizar todas las propiedades.
  * Ineficiente. Hay que hacer varias queries separadas. Tambi茅n nos exponemos a peligros como el problema N+1, una query por cada entidad (por ejemplo, si hay foreach).
  * Se recomienda utilizar antes, eager loading, select loading, y en 煤ltimo caso caso, explicit loading.
  * Hay que instalar **Microsoft.EntityFrameworkCore.Proxies**.
  * Hay que configurar el dbContext para usar ```UseLazyLoadingProxies```, normalmente en el ```program.cs```.
  * Todas las entidades del modelo hijas, deben ser virtual (virtual HashSet, virtual CineOferta, virtual List, etc)
  * Las consultas utilizan ```AsTracking()```

## 3.16 Ejecuci贸n diferida (AsQueryAble): Filtros din谩micos <a name="Tema_03_Consultanto_Diferida"></a> 
* Se utiliza para componer la query en funci贸n de si se pasan los par谩metros o no.
* Se debe utilizar ```AsQueryAble()```, el cual nos permite ir construyendo la query.
* Revisar en **PeliculasController**, m茅todo ```GetFiltrarDinamicoEjecucionDiferida```. 

---

# M脫DULO 04. Crear, modificar y borrar datos <a name="Tema_04_CRUD"></a>
**Objetivo:** manejo de datos, creaci贸n, modificaci贸n y eliminaci贸n de los datos.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_04_Crud_Migraciones)
2. [Creando el proyecto](#Tema_04_Crud_Creacion)
3. [Modelo Conectado y Modelo Desconectado - Estatus](#Tema_04_Crud_Modelo) 
4. [Insertar registros de manera individual](#Tema_04_Crud_Insertar_Individual) 
5. [Insertar registros de manera m煤ltiple](#Tema_04_Crud_Insertar_Multiple) 
6. [Insertar registros con datos relacionados inexistentes](#Tema_04_Crud_Insertar_Relacionado) 
7. [Insertar registros con datos relacionados inexistentes a trav茅s de un DTO (recomendado)](#Tema_04_Crud_Insertar_Relacionado_Dto) 
8. [Insertar registros con datos relacionados existentes](#Tema_04_Crud_Insertar_Relacionado_Inexistente) 
9. [Mapeo flexible de campos en vez de propiedades (HasField)](#Tema_04_Crud_Mapeo_Flexible) 
10. [Actualizando registros - modelo conectado](#Tema_04_Crud_Modelo_Conectado) 
11. [Actualizando registros - modelo desconectado](#Tema_04_Crud_Modelo_Desconectado) 
12. [Borrado normal o f铆sico](#Tema_04_Crud_Borrado_Normal) 
13. [Borrado suave o l贸gico](#Tema_04_Crud_Borrado_Suave) 
14. [Filtros al nivel del modelo (a帽adir e ignorar)](#Tema_04_Crud_Filtro) 
---

## 4.0 Migraciones 鈿欙笍 <a name="Tema_04_Crud_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_04_CRUD_BDD]**.
  * Creaci贸n del esquema.
  * Inserci贸n de datos de prueba.

### 4.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 4.1 Creando el proyecto <a name="Tema_04_Crud_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **04_Crear_Actualizar_Borrar**
* BDD utilizada: **[EFCorePeliculasDB_04_CRUD_BDD]**

## 4.2 Modelo Conectado y Modelo Desconectado - Estatus <a name="Tema_04_Crud_Modelo"></a> 
* **Modo desconectado**:
	* Utilizado en el t铆pico escenario web, donde el usuario rellena un formulario y esos datos se utilizan para crear un dato. 
	* El modelo no es el responsable de pasar una nueva entidad. 
	* El DbContext puede ser diferente para una consulta, que para una inserci贸n.
* **Modo conectado**:
	* AsTracking, misma instancia del DbContext tanto para consultar los datos como para editarlos. 
	* Manera m谩s simple para trabajar.
	* Sin embargo, esta manera de trabajar no siempre es realista, ya que puede ser el cliente quien nos pase el dato para insertar, modificar, etc.
* **Status de la entidad**: para poder hacer el seguimiento en el equ se encuentra una entidad:
	* **Added** (agregado): una entidad debe ser creada en la BDD.
	* **Modified** (modificado): la entidad representa un registro existente en la BDD que debe actualizarse.
	* **Unchanged** (sin modificar): la entidad representa un registro existente en la BDD que no tiene cambios.
	* **Deleted** (borrado): la entidad representa un registro existente en la BDD que debe borrarse.
	* **Detached** (sin seguimiento): cuando una entidad no est谩 recibiendo ning煤n seguimiento por EF.
* **context.Entry(entidad).State** para conocer el estado de una entidad.
* **SaveChanges** del DbContext es el m茅todo que guarda los cambios.

## 4.3 Insertar registros de manera individual <a name="Tema_04_Crud_Insertar_Individual"></a> 
* Revisar en **GenerosController**, m茅todo ```InsertarIndividual```.
* Para probar con Swagger:
```
    {
	    "nombre":"Biografia"
    }
```

## 4.4 Insertar registros de manera m煤ltiple <a name="Tema_04_Crud_Insertar_Multiple"></a> 
* Revisar en **GenerosController**, m茅todo ```InsertarMultiple```.
* Se realiza con ```context.AddRange(entidad);```
* Para probar con Swagger:
```
[
  {
    "nombre": "Biografia varios 1"
  },
  {
    "nombre": "Biografia varios 2"
  }
]
```

## 4.5 Insertar registros con datos relacionados inexistentes <a name="Tema_04_Crud_Insertar_Relacionado"></a> 
* Revisar en **CinesController**, m茅todo ```InsertarDatosRelacionados```.

## 4.6 Insertar registros con datos relacionados inexistentes a trav茅s de un DTO (recomendado) <a name="Tema_04_Crud_Insertar_Relacionado_Dto"></a> 
* Revisar en **CinesController**, m茅todo ```InsertarDatosRelacionadosConDTO```.
* Recomendable ya que indico qu茅 datos debo pasar, adem谩s de que se pueden poner comprobaciones de valores (Required, etc) en el DTO para que sean datos correctos.
* Para probar con Swagger:
```
{
  "nombre": "Mi cine",
  "latitud": 18.476275,
  "longitud": -69.896979,
  "cineOferta": {
    "porcentajeDescuento": 7,
    "fechaInicio": "2023-02-21T16:47:16.336Z",
    "fechaFin": "2028-02-21T16:47:16.336Z"
  },
  "salasDeCine": [
    {
      "precio": 8,
      "tipoSalaDeCine": 1
    },
    {
      "precio": 12,
      "tipoSalaDeCine": 3
    }
  ]
}
```

## 4.7 Insertar registros con datos relacionados existentes <a name="Tema_04_Crud_Insertar_Relacionado_Inexistente"></a> 
* Si queremos insertar una pel铆cula con sus g茅neros, sin embargo, los g茅neros ya existen en la tabla de g茅neros.
* Se necesita reutilizar g茅neros ya existentes.
* Revisar en **PeliculasController**, m茅todo ```InsertarDatosRelacionados```.
* Se trabaja con el State, indicando que los g茅neros y salas de cine de la pel铆cula, se tratar谩n como consulta (sin modificar), y que s贸lo sirve para relacionarlos con la entidad pelicula. Esto se realiza con el estado ```EntityState.Unchanged```.
* Para probar con Swagger:
```
{
  "titulo": "mi pel铆cula",
  "enCartelera": true,
  "fechaEstreno": "2023-02-21T17:04:11.948Z",
  "generos": [
    1, 2
  ],
  "salasDeCine": [
    1, 2, 3
  ],
  "peliculasActores": [
    {
      "actorId": 1,
      "personaje": "Peter Parker"
    }
  ]
}
```

## 4.8 Mapeo flexible de campos en vez de propiedades (HasField) <a name="Tema_04_Crud_Mapeo_Flexible"></a> 
* Permite realizar transformaciones de datos antes de introducirlos a la BDD.
* Por ejemplo, que a la hora de insertar un actor, su primera letra del nombre y del apellido est茅n en may煤scula.
* Revisar: 
  * **Actor.cs**, propiedad ```Nombre```.
  * **ActoresController**, m茅todo ```InsertarConMapeoFlexibleDeCampo```.
  * **ActorConfig.cs**, se indica que la propiedad ```Nombre``` tiene un campo privado asociado, a trav茅s de ```.HasField("_nombre")```.
* Para probar con Swagger:
```
{
  "nombre": "jUaN valdEZ",
  "biografia": "Biograf铆a...",
  "fechaNacimiento": "2023-02-21T17:31:09.905Z"
}
```

## 4.9 Actualizando registros - modelo conectado <a name="Tema_04_Crud_Modelo_Conectado"></a> 
* La entidad a actualizar va a ser cargada por el mismo DbContext. Ambas operaciones ser谩n realizadas por la misma instancia del DbContext.
* La forma de realizarlo debe ser ```AsTracking()```, ya que es conectado.
* Revisar:  
  * **ActorController**, m茅todo ```ModificarConectado```. Modificar un actor existente.
  * **GenerosController**, m茅todo ```ModificarConectadoAgregar2```. Agregar un 2 al final de un nombre de un g茅nero. Es un ejemplo muy simple.

## 4.10 Actualizando registros - modelo desconectado <a name="Tema_04_Crud_Modelo_Desconectado"></a> 
* La entidad a actualizar va a ser cargada en diferentes DbContext, uno para buscar la entidad a modificar, y otro para modificarla).
* **Modelo conectado vs desconectado:** en el caso del modelo desconectado, actualiza todas las propiedades de la entidad, mientras que el conectado actualiza solo las modificadas, por lo que el primero es menos eficiente.
* La forma de realizarlo es mediante ```context.Update()```.
* Revisar:  
  * **ActorController**, m茅todo ```ModificarDesconectado```. Modificar un actor existente.

## 4.11 Borrado normal o f铆sico <a name="Tema_04_Crud_Borrado_Normal"></a> 
* Se utiliza para eliminar el registro de la tabla.
* Se debe cambiar el estatus de la entidad a ```deleted``` antes de hacer un ```SaveChanges()```.
* La forma de realizarlo es mediante ```context.Remove()```.
* Revisar:  
  * **GenerosController**, m茅todo ```BorradoNormalFisico```.

## 4.12 Borrado suave o l贸gico <a name="Tema_04_Crud_Borrado_Suave"></a> 
* Se utiliza si no se quiere remover el registro de la tabla. Realmente es una actualizaci贸n de un registro con un campo flag ```EstaBorrado```.
* La manera m谩s sencilla es realizar una actualizaci贸n con el modelo conectado y ```AsTracking()```.
* Revisar:  
  * **GenerosController**, m茅todo ```BorradoSuaveLogico```.

## 4.13 Filtros al nivel del modelo (a帽adir e ignorar) <a name="Tema_04_Crud_Filtro"></a> 
* En ocasiones va a haber filtros que queramos aplicar en todas las consultas que se hagan a la base de datos.
* Por ejemplo, si queremos retornar solo los g茅neros que est茅n activos.
* Si se genera un filtro, siempre se aplicar谩 sobre la entidad.
* Revisar:  
  * **GeneroConfig**, m茅todo ```HasQueryFilter```.
  * Si se ejecuta en Swagger cualquier Get de g茅neros, o se revisa la sentencia SQL que lanza, se puede comprobar que no devolver谩 los g茅neros que tengan un borrado l贸gico.
* En el caso de que necesitemos acceder a los borrados l贸gicos, es posible saltarse el filtro mediante ```IgnoreQueryFilters```:
  * Por ejemplo:
    * Si queremos restaurar un g茅nero previamente borrado, y lo tenemos que retornar.
    * Si queremos mostrar a un administrador todos los g茅neros, incluidos los borrados.
  * Revisar **GenerosController**, m茅todo ```RestaurarGeneroBorrado```.
---

# M脫DULO 05. Configurando propiedades de entidades y BDD (avanzado) <a name="Tema_05_Propiedades"></a>
**Objetivo:** ahondar m谩s en el manejo de las propiedades.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_05_Propiedades_Migraciones)
2. [Creando el proyecto](#Tema_05_Propiedades_Creacion)
3. [Modos de configuraci贸n](#Tema_05_Propiedades_Modos)
4. [Llaves primarias](#Tema_05_PropiedadesLlaves_primarias)   
5. [Ignorando propiedades y clases para no trasladarlas a BDD](#Tema_05_Ignorando_Propiedades_Clases)
6. [脥ndices e 铆ndices con filtros (铆ndice parcial)](#Tema_05_Propiedades_Indices)
7. [HasConversion, conversiones de datos especiales (EF - BDD - EF) - Introducci贸n](#Tema_05_Propiedades_HasConversion)
8. [HasConversion, conversiones de datos especiales (EF - BDD - EF) - Personalizado](#Tema_05_Propiedades_HasConversion_Personalizado)
9. [Keyless (entidades sin Llave), ejecuci贸n de sentencias SQL (**ToSqlQuery**)](#Tema_05_Propiedades_Keyless_SQL)
10. [Keyless (entidades sin Llave), ejecuci贸n de vistas de SQL (**ToView**)](#Tema_05_Propiedades_Keyless)
11. [Shadow properties, propiedades Sombra, c贸mo manejar datos que no est谩n en entidades](#Tema_05_Propiedades_Shadow)
12. [Configuraci贸n masiva de propiedades mediante automaticaci贸n de Fluent API](#Tema_05_Propiedades_Configuracion)

## 5.0 Migraciones 鈿欙笍 <a name="Tema_05_Propiedades_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_05_Propiedades]**.
  * Creaci贸n del esquema con todos los ejemplos del tema.
  * Inserci贸n de datos de prueba.

### 5.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 5.1 Creando el proyecto <a name="Tema_05_Propiedades_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **05_Configurando_Propiedades**
* BDD utilizada: **[EFCorePeliculasDB_05_Propiedades]**

## 5.2 Modos de configuraci贸n <a name="Tema_05_Propiedades_Modos"></a>
* Existen 3 maneras de realizar configuraciones en EF Core para los campos:
  * **Por convenci贸n**: funciona en base a los estilos de c贸digo y nombres utilizados en las entidades. 
    * Por ejemplo, una propiedad ```Id``` ser谩 considerada una llave primaria.
  * **Por anotaciones de datos**:
    * Atributos colocados sobre las propiedades de las entidades:
    * Por ejemplo, ```Key``` ser谩 considerada una llave primaria.
  * **Por Fluent API**:
    * Configurado en el m茅todo ```OnModelCreating``` de la clase ```DBContext```. Es la manera m谩s potente de realizar configuraciones.
    * Por ejemplo, ```HasMaxLength``` o ```IsRequired```.

## 5.3 Llaves primarias <a name="Tema_05_PropiedadesLlaves_primarias"></a>
* Se pueden definir llaves primarias con **Integer**.
* Se pueden definir llaves primarias con un **GUID (Global Unique Identifier)**
  * Revisar **LogsController**, m茅todo ```Get```.
  * Se puede indicar que en el campo no introduzca ning煤n valor de forma autom谩tica mediante:
    * Modo 1: a trav茅s del atributo ```[DatabaseGenerated(DatabaseGeneratedOption.None)]```. Revisar ```Logs.cs```.
    * Modo 2: a trav茅s del fluent API ```modelBuilder.Entity<Log>().Property(l => l.Id).ValueGeneratedNever()```. Revisar ```ApplicationDbContext.cs```.* 
    * En este caso, se deber谩 generar de manera manual, aunque no es recomendable.

## 5.4 Ignorando propiedades y clases para no trasladarlas a BDD <a name="Tema_05_Ignorando_Propiedades_Clases"></a>
* Por defecto en EF, cualquier clase o propiedad se mapea en alguna columna de la tabla correspondiente.
* En alguna circunstancia, puede que este comportamiento no interese.
* Se pueden ignorar campos o clases enteras:
  * **Campos**:
    * Por ejemplo: un campo **[Edad]** para un Actor. Esta campo ser谩 claulado a partir de la fecha de nacimiento.
    * Se puede realizar mediante:
      * Modo 1: a trav茅s del atributo ```[NotMapped]```. Revisar ```Actor.cs```.
      * Modo 2: a trav茅s del fluent API ```.Ignore```. Revisar ```ActorConfig.cs```.* 
      * En este caso, se deber谩 generar de manera manual, aunque no es recomendable.
  * **Clases**:
    * Por ejemplo: **[Direccion]**. Se puede hacer:
    * Cuando la clase est谩 nivel de nivel de propiedad, dentro de otra clase (**Actor** tiene **Direccion**)
      * Modo 1: a trav茅s del atributo ```[NotMapped]```. Revisar ```Actor.cs```.
      * Modo 2: a trav茅s del fluent API ```.Ignore```. Revisar ```ActorConfig.cs```.* 
    * Que ignore la clase siempre:
      * Modo 1: a trav茅s del atributo ```[NotMapped]```. Revisar ```Direccion.cs```.
      * Modo 2: a trav茅s del fluent API ```modelBuilder.Ignore<Direccion>()```. Revisar ```ApplicationDbContext.cs```.* 

## 5.5 脥ndices e 铆ndices con filtros (铆ndice parcial) <a name="Tema_05_Propiedades_Indices"></a>
* **脥ndices 煤nicos**:
    * Podemos configurar **铆ndices 煤nicos** en nuestras tablas para aumentar la velocidad de ciertas consultas.
    * Recomendable cuando no es viable hacer un full scan o b煤squedas completas cada vez que se haga una query.*
    * Los 铆ndices pueden configurarse como 煤nicos, garantizando que otra fila no vaya a tener el mismo valor (por ejemplo, un campo email).*
    * Las llaves primarias son autom谩ticamente configuradas como 铆ndices 煤nicos.
      * Por ejemplo, si se quiere poner un 铆ndice 煤nico para la propiedad ```Nombre``` de la entidad ```Genero```:
          * Modo 1: a trav茅s del atributo ```[Index(nameof(Nombre), IsUnique = true)]```. Revisar ```Genero.cs```.
          * Modo 2: a trav茅s del fluent API ```HasIndex().... .IsUnique()```. Revisar ```GeneroConfig```. 
    * Revisar ```GenerosController```, m茅todo ```Post``` para ver c贸mo realizar comprobaciones.
    * Para probar con Swagger:
```
{
    "nombre": "Anime"
}
```
* **脥ndices con filtros (铆ndice parcial)**:
  * Quiz谩s interesen 铆ndices que se apliquen de manera parcial.
  * Un ejemplo puede ser un g茅nero que tiene un borrado l贸gico, solo queremos que aplique cuando el campo ```[EstaBorrado]=0```, es decir, que no se repitan elementos 煤nicamente si est谩n activos.
  * Se realizar谩 con Fluent API:
    * Revisar en ```GeneroConfig``` el c贸digo ```.IsUnique().HasFilter("EstaBorrado = 'false'");```.
    * En BDD se generar谩 un 铆ndice con la ssiguientes caracter铆sticas:
```
/****** Object:  Index [IX_Generos_Nombre]    Script Date: 23/02/2023 13:34:03 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Generos_Nombre] ON [dbo].[Generos]
(
	[Nombre] ASC
)
WHERE ([EstaBorrado]='false')
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
```

## 5.6 HasConversion, conversiones de datos especiales (EF - BDD - EF) - Introducci贸n <a name="Tema_05_Propiedades_HasConversion"></a>
* Se pueden realizar transformaciones de datos en ambos sentidos:
  * De BDD a EF.
  * De EF a BDD.
* Un ejemplo t铆pico es la conversi贸n de un ```enum``` de c# a un ```nvarchar``` de BDD. Por ejemplo, de ```DosDimensiones``` al enum ```TipoSalaDeCine.DosDimensiones = 1```.
* Se puede realizar a trav茅s del fluent API ```.HasConversion<string>();```. Revisar ```SalaDeCineConfig```.* 
* Adem谩s, se puede poner un valor por defecto.
* Se puede comprobar con **Swagger** que cuando se est谩 leyendo el valor de BDD, lo transforma a un enum:
  * Lanzar el m茅todo /api/cines/{id}

## 5.7 HasConversion, conversiones de datos especiales (EF - BDD - EF) - Personalizado <a name="Tema_05_Propiedades_HasConversion_Personalizado"></a>
* Se pueden realizar conversiones personalizadas, y no solamente a string.
* Un ejemplo puede ser el campo moneda, que en EF. Por ejemplo, de ```鈧琡`` al enum ```Moneda.Euro = 3```.
* Clase ```MonedaASimboloConverter```:
  * Se deber谩 crear una clase que herede de ```ValueConverter```. 
  * En esta clase se configuran los dos mapeos, de EF a BDD y de BDD a EF.
* Registro de la clase:
  * La clase ```MonedaASimboloConverter``` deber谩 ser configurada en **Fluent API**
  * Se puede realizar a trav茅s del fluent API ```.HasConversion<MonedaASimboloConverter>();```. Revisar ```SalaDeCineConfig```.*   
* Se puede comprobar con **Swagger** que:
  * Cuando se est谩 leyendo el valor de BDD, lo transforma a un enum: lanzar el m茅todo /api/cines/Post
  * En BDD guarda en la tabla **[SalasDeCine]** los valores correspondientes a "RD$", "$" y "鈧?".

## 5.8 Keyless (entidades sin Llave), ejecuci贸n de sentencias SQL (**ToSqlQuery**) <a name="Tema_05_Propiedades_Keyless_SQL"></a>
* Hasta este momento todas las entidades ten铆an una llave primaria, ya sea unitaria o compuesta. EF exige normalmente una llave primaria para trabajar.
* Se pueden configurar entidades para que trabajen sin llaves. En el pasado se llamaban **Modelos de query**.
* Algunas ventajas que tiene son:
  * Poder expresar el resultado de queries arbitrarias en t茅rminos de una clase, con un lenguaje fuertemente tipado.
  * Centralizar las queries que realizamos.
  * No tenemos que preocuparnos por temas de eficiencia del seguidos de cambios, aunque es algo que ya lo tenemos resuelto con ```AsNoTracking()```.
* Por ejemplo, supongamos que queremos realizar una sentencia SQL para traer los cines sin incluir la ubicaci贸n:
  * Aunque se puede realizar con un Select de EF lo vamos a hacer a trav茅s de una SQL.
  * Generar una entidad sin llave llamada ```CineSinUbicacion```:
    * Modo 1: a trav茅s del atributo ```[Keyless]```. Mirar la propiedad clase.
    * Modo 2: a trav茅s del fluent API ```.HasNoKey()```. Revisar ```ApplicationDbContext```. 
  * Configurar la entidad en ApplicationDbContext:
    * Con la sentencia SQL a ejecutar en ```ToSqlQuery()```: revisar ```ApplicationDbContext```.
    * ToView(null) se utiliza para que no se agregue una tabla en la BDD con un esquema de **CineSinUbicacion**.
    * Generar un DBSet de ```DbSet<CineSinUbicacion>```.
* Se puede comprobar con **Swagger** a trav茅s del m茅todo /api/cines/SinUbicacion de ```CinesController```

## 5.9 Keyless (entidades sin Llave), ejecuci贸n de vistas de SQL (**ToView**) <a name="Tema_05_Propiedades_Keyless"></a>
* Adem谩s de sentencias SQL, se pueden ejecutar directamente vistas de SQL.
* La vista, se puede o bien crear en BDD o bien hacerlo a trav茅s de una migraci贸n si se realiza con Code First. 
* En el ejemplo se ha creado la migraci贸n ```VistaConteoPeliculas```, la cual genera la vista SQL ```[PeliculasConConteos]```.
* Esta vista retorna las pel铆culas, y por cada uno la cantidda de g茅neros, cines y actores que contiene.
 * Generar una entidad sin llave llamada ```PeliculaConConteos```:
    * Modo 1: a trav茅s del atributo ```[Keyless]```. Mirar la propiedad clase.
    * Modo 2: a trav茅s del fluent API ```.HasNoKey()```. Revisar ```ApplicationDbContext```. 
  * Configurar la entidad en el ApplicationDbContext:
    * Con la sentencia SQL a ejecutar en ```ToView()```: revisar ```ApplicationDbContext```.
    * Generar un DBSet de ```DbSet<PeliculaConConteos>```.
* Se puede comprobar con **Swagger** a trav茅s del m茅todo /api/peliculas/PeliculasConConteos de ```PeliculasController```

## 5.10 Shadow properties, propiedades Sombra, c贸mo manejar datos que no est谩n en entidades. <a name="Tema_05_Propiedades_Shadow"></a>
* Permiten acceder a columnas que no se encuentran presentes en las entidades de c#, pero s铆 en BDD. Esto es 煤til cuando no queremos ver expuestos datos en las entidades, y que no a帽ada complejidad extra al modelo.
* Ejemplo: fecha de creaci贸n en g茅nero:
  * Se realiza a trav茅s del Fluent API.
  * Revisar ```GeneroConfig```. Aqu铆 se realizar谩 con ```HasDefaultValueSql()``` y ```HasColumnType()```.
  * Para acceder al valor de la columna desde c#:
    * Revisar ```GenerosController```, ```m茅todo Get(int id)```: ```context.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue```
  * Para ordenar por un campo sombra desde c#:
    * Revisar ```GenerosController```, ```m茅todo Get()```: ```.OrderByDescending(g => EF.Property<DateTime>(g, "FechaCreacion"))```
* Se puede comprobar con **Swagger**:
  * Inserci贸n: generar un g茅nero a trav茅s del m茅todo /api/generos/Post de ```GenerosController```, se puede lanzar y verificar posteriormente en BDD:
```
{
  "nombre": "Tragicomedia"
}
```   
  * Lectura: lanzar m茅todo /api/generos/Get{id:int} de ```GenerosController```.

## 5.11 Configuraci贸n masiva de propiedades mediante automaticaci贸n de Fluent API <a name="Tema_05_Propiedades_Configuracion"></a>
* Permiten realizar convenciones masivas en base al nombre de una propiedad.
* Por ejemplo, si queremos configurar:
  * Cualquier propiedad del tipo string y cuyo nombre contiente "URL".
  * Para que no sea Unicode (que permita caracteres especiales) y de un tama帽o m谩ximo de 500 caracteres.
* Ejemplo: 
  * Se realiza a trav茅s del Fluent API.
  * Revisar ```ApplicationDbContext```, m茅todo ```OnModelCreating```.
  * Se crea un campo en la entidad ```Actor``` llamado ```FotoURL```.
  * Se puede verificar que en BDD, en la tabla ```[Actores]``` genera una columna ```FotoURL``` de tipo ```varchar(500)```.

---

# M脫DULO 06. Configurando relaciones <a name="Tema_06_Relaciones"></a>
**Objetivo:** ahondar m谩s en el manejo de las propiedades.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_06_Relaciones_Migraciones)
2. [Creando el proyecto](#Tema_06_Relaciones_Creacion)
3. [Conceptos b谩sicos ](#Tema_06_Relaciones_Basico)
4. [Relaciones por convenci贸n](#Tema_06_Relaciones_Convencion)
5. [Relaciones requeridas y opcionales en la llave for谩nea](#Tema_06_Relaciones_Requeridas_Opcionales)
6. [Relaciones con anotaciones de datos: llaves for谩neas expl铆citas con [ForeignKey]](#Tema_06_Relaciones_Foreign)
7. [Relaciones con anotaciones: dos propiedades de navegaci贸n a la mista entidad con [InverseProperty]](#Tema_06_Relaciones_InverseProperty)
8. [Relaci贸n 1 a 1 con Fluent API](#Tema_06_Relaciones_1_1)
9. [Relaci贸n 1 a N con Fluent API](#Tema_06_Relaciones_1_N)
10. [Relaci贸n N a N con Fluent API con clase intermedia](#Tema_06_Relaciones_N_N)
11. [Relaci贸n N a N con Fluent API sin clase intermedia (skip navigation)](#Tema_06_Relaciones_N_N_sin_intermedia)
12. [Relaciones y borrado, Fluent API y OnDelete: 驴Qu茅 Ocurre al borrar?](#Tema_06_Relaciones_Borrado)
13. [Divisi贸n de una tabla (Table Splitting) en m谩s de una entidad (datos principales y secundarios)](#Tema_06_Relaciones_Division_Tabla)
14. [Divisi贸n de una tabla mediante entidades de propiedad (reutilizaci贸n de entidades secundarias [Owned])](#Tema_06_Relaciones_Entidad_Propiedad)
15. [Herencia de clases - una sola tabla por jerarqu铆a (Table per Hierarchy - TPH)](#Tema_06_Relaciones_Herencia_TPH_)
16. [Herencia de clases - una sola tabla por cada tipo (Table per Type - TPT)](#Tema_06_Relaciones_Herencia_TPT_)

## 6.0 Migraciones 鈿欙笍 <a name="Tema_06_Relaciones_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_06_Relaciones]**.
  * Creaci贸n del esquema con todos los ejemplos del tema.
  * Inserci贸n de datos de prueba.

### 6.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 6.1 Creando el proyecto <a name="Tema_06_Relaciones_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **06_Configurando_Relaciones**
* BDD utilizada: **[EFCorePeliculasDB_06_Relaciones]**

## 6.2 Conceptos b谩sicos <a name="Tema_06_Relaciones_Basico"></a>
* **Tipos b谩sicos de relaciones** (ya comentado en el apartado [2.8 Creando relaciones](#Tema_02_Modelado_CreandoRelaciones):
  * **Relaci贸n 1 a 1**:
    * Oferta de un cine:
      * 1 Cine tiene 1 oferta.  
  * **Relaci贸n 1 a N**:
    * Cine con sus salas de cine (2D, 3D, etc):      
  * **Relaci贸n N a N**:
    * 1 pel铆cula puede tener N g茅neros, y 1 g茅nero puede tener N pel铆culas.
    * 1 pel铆cula puede emitirse en N salas de cine, y 1 sala de cine puede emitir N pel铆culas.
    * 1 actor puede participar en N pel铆culas, y 1 pel铆cula pueden participar N actores.
* **Llave principal o primaria**:
  * Puede ser simple o compuesta.
* **Entidad principal**:
  * Es aquella entidad que contiene la llave principal.
  * Por ejemplo: en el caso de 1 ```Cine``` con N ```Salas de Cine```, la entidad principal es ```Cine```.
* **Entidad dependiente**:
  * Es aquella entidad que no contiene la llave principal como una columna propia.
  * Por ejemplo: en el caso de ```Salas de Cine```, esta no contiene un valor propio, sino que lo usa simplemente para enlazarse con 1 ```Cine``` mediante una llave for谩nea.
* **Llave for谩nea**:
  * Valor de la llave principal en la entidad dependiente.
* **Propiedad de navegaci贸n**:
  * Se refiere a una propiedad de una entidad que permite enlazar con otras entidades relacionadas, ya sea en formato 1 a 1 o 1 a N.
  * Por ejemplo: en la clase ```Cine```, las siguientes propiedades:
    * Formato 1 a N: propiedad ```HashSet<SalaDeCine> SalasDeCine {get; set;}```.
    * Formato 1 a 1: propiedad ```CineOferta CineOferta {get; set;}```.
* **Relaci贸n requerida**:
  * Es una relaci贸n en la cual la llave for谩nea NO es nula, por lo que la relaci贸n siempre debe existir.
  * Por ejemplo: 1 ```Salas de Cine``` siempre debe estar enlazada con 1 ```Cine```. No puede existir 1 ```Sala de Cine``` sin su ```Cine```.
* **Relaci贸n opcional**:
  * Es una relaci贸n en la cual la llave for谩nea PUEDE ser nula, por lo que la relaci贸n no siempre debe existir.
  * Por ejemplo: un foro de mensajes, donde queremos conservar los mensajes incluso si el usuario elimina su cuenta.
* **Administrar relaciones**: existen 3 maneras de configurar las relaciones:
  * Por convenci贸n.
  * Por anotaci贸n.
  * Por Fluent API.
 
## 6.3 Relaciones por convenci贸n <a name="Tema_06_Relaciones_Convencion"></a>
* Revisar el apartado [2.8 Creando relaciones](#Tema_02_Modelado_CreandoRelaciones)

## 6.4 Relaciones requeridas y opcionales en la llave for谩nea<a name="Tema_06_Relaciones_Requeridas_Opcionales"></a>
* En el caso de querer configurar llaves for谩neas, pueden ser requeridas u opcionales. Un caso de querer que sea opcional, es porque el padre puede haber sido eliminado con un borrado l贸gico (suave):
* **Requeridas:**
  * Cualquier entidad hija ser谩 eliminada junto con la entidad padre.
  * Por ejemplo, una oferta de un cine, requiere siempre que exista un Cine.
    * Declaraci贸n de la propiedad: ```public int CineId { get; set; }```
    * A nivel de base de datos se crear谩 como ```[CineId] [int] NOT NULL```
* **Opcionales:**
  * Cualquier entidad hija NO ser谩 eliminada junto con la entidad padre.
  * Si se quisiera que fuera opcionales, se pondr铆a:
    * Declaraci贸n de la propiedad: ```public int? CineId { get; set; }```
    * ```public int? CineId { get; set; }```
    * En el caso de realizar un borrado:
      * En la entidad principal, deber铆a configurarse para con la palabra clave ```Include```, para que en los hijos elimine la clave for谩nea.
      * Revisar ```CinesController```, m茅todo ```Delete```.
    * A nivel de base de datos se crear谩 como ```[CineId] [int] NULL```

## 6.5 Relaciones con anotaciones de datos: llaves for谩neas expl铆citas con [ForeignKey]<a name="Tema_06_Relaciones_Foreign"></a>
* Se puede utilizar el atributo ```[ForeignKey]``` para indicar claves for谩neas.
* Puede servir si los nombres no corresponden a un est谩ndar.
* De una propiedad de navegaci贸n, por ejemplo en ```SalaDeCine``` se puede poner: ```[ForeignKey(nameof(ElCine))]```.

## 6.6 Relaciones con anotaciones: dos propiedades de navegaci贸n a la mista entidad con [InverseProperty]<a name="Tema_06_Relaciones_InverseProperty"></a>
* Cuando tenemos dos relaciones hacia la misma entidad.
* Por ejemplo: 
  * Si queremos implementar una funcionalidad de mensajer铆a en nuestra aplicaci贸n donde los usuarios van a poder enviarse mensajes privados entre s铆.
  * Cada mensaje tendr谩 un emisor y un receptor, que es la misma entidad: ```Persona```.
  * Revisar:
    * Clase ```Persona```, la cual contendr谩 una lista de mensajes enviados y otra de mensajes recibidos.
    * Clase ```Mensaje```, la cual tendr谩 propiedades de navegaci贸n hacia el emisor y el receptor.
    * Para que sepa c贸mo realizar la uni贸n, se utiliar谩 ```[InverseProperty]``` para que:
      * Los mensajes enviados se correspondan con aquellos en los cuales el valor de la persona sea igual al emisor.
      * Los mensajes recibidos se correspondan con aquellos en los cuales el valor de la persona sea igual al receptor.
* Se puede comprobar con **Swagger**:
  * Get: retornar los mensajes a trav茅s del m茅todo /api/personas/Get de ```PersonasController```.

## 6.7 Relaci贸n 1 a 1 con Fluent API<a name="Tema_06_Relaciones_1_1"></a>
* Fluent API Es la herramienta m谩s potente para realizar relaciones.
* 1 Cine tiene 1 oferta:
  * Revisar ```CineConfig```
    * ```HasOne()```: 1 Cine tiene 1 CineOferta
    * ```WithOne()```: 1 CineOferta tiene 1 Cine

## 6.8 Relaci贸n 1 a N con Fluent API<a name="Tema_06_Relaciones_1_N"></a>
* Normalmente con la configuraci贸n por convenci贸n suele ser necesario para este caso.
* 1 Cine tiene N salas de cine:
  * Revisar ```CineConfig```
    * ```HasMany()```: 1 Cine tiene N SalaDeCine
    * ```WithOne()```: 1 CineOferta tiene 1 Cine

## 6.9 Relaci贸n N a N con Fluent API con clase intermedia<a name="Tema_06_Relaciones_N_N"></a>
* El ejemplo se va a hacer con una clase intermedia personalizada.
* 1 Pelicula tiene N Actores y 1 Actor est谩 en N Pel铆culas:
  * Revisar ```PeliculaActorConfig```
    * ```HasOne()``` y ``WithMany()``` para ambas propiedades (Actores y Peliculas)

## 6.10 Relaci贸n N a N con Fluent API sin clase intermedia (skip navigation)<a name="Tema_06_Relaciones_N_N_sin_intermedia"></a>
* Oficialmente su nombre es ```skip navigation```, porque se salta la entidad intermedia de navegaci贸n.
* 1 Pelicula tiene N Generos y 1 Genero tiene N Pel铆culas:
  * Revisar ```PeliculaConfig```
    * ```HasMany()``` y ``WithMany()```.

## 6.11 Relaciones y borrado, Fluent API y OnDelete: 驴Qu茅 Ocurre al borrar?<a name="Tema_06_Relaciones_Borrado"></a>
* 驴Qu茅 ocurre entre la entidad principal ```Cine``` y ```SalaDeCine()``` cuando se elimina la primera?
* OnDelete permite configurar la siguientes opciones:
  * **Cascade**: 
    * Si la entidad principal es borrada, se eliminar谩n las entidades dependientes.
  * **Client Cascade**: 
    * Para las bases de datos que puede que no soporten la caracter铆stica de borrado en cascada.
    * El borrado en cascada se realiza desde la aplicaci贸n.
    * Requiere que al cargar la entidad principal, se carguen las entidades dependientes.
  * **No Action**: 
    * No hace nada.
    * Puede provocar errores a la hora de realizar la acci贸n. Por ejemplo, si se intenta borrar un cine que tiene sals de cine relacionadas.
  * **Client No Action**: 
    * No hace nada, aunque la misma documentaci贸n oficial considera inusual su uso.
  * **Restrict**: 
    * La acci贸n a realizar en la entidad principal no se va a realizar en las entidades dependientes.
    * En algunos motores de BDD como SQL y MySQL, es similar a **No Action** ya que no tienen restricciones diferidas.
    * Esta opci贸n puede ser relevante cuando se usa para PostgreSQL.
  * **Set Null**: 
    * Coloca el valor NULL en la columna de la clave for谩nea.
  * **Client Set Null**: 
    * Se coloca el valor NULL en la columna de la clave for谩neas desde la aplicaci贸n.
    * Requiere que al cargar la entidad principal, se carguen las entidades dependientes.
  * Ejemplo: no se podr谩 eliminar un cine si contiene salas de cine.
  * Revisar ```CineConfig```
    * ```.OnDelete(DeleteBehavior.Restrict)()```.    
    * Migraci贸n: ```NoPodemosBorrarCineConSalasDeCine```
    * Controller:
      * ```CineController```, m茅todos:
        * ```DeleteConRestrict```: primero elimina los hijos para posteriormente eliminar el padre.
        * ```DeleteSinRestrict```: debido a la configuraci贸n **Restrict**, actualmente provocar谩 un fallo.

## 6.12 Divisi贸n de una tabla (Table Splitting) en m谩s de una entidad (datos principales y secundarios)<a name="Tema_06_Relaciones_Division_Tabla"></a>
* A veces es una buena idea crear m谩s de una entidad para dividir los datos esenciales con los que normalmente se trabaja de otros secundarios.
* La tabla realmente ser谩 1, pero se dividir谩 en entidades con subconjuntos de datos.
* Por ejemplo, si la tabla **[Cines]** tiene datos secundarios como: ```Historia, Valores, Misiones, CodigoDeEtica```, los cuales normalmente no van a ser necesario.
* Para realizar el split:
  * Clase ```CineDetalle```:
    * Se crear谩 una clase para los datos secundarios ```CineDetalle```.
    * Tendr谩 una propiedad de navegaci贸n ```Cine```.
    * A partir de EF6 es necesario que para utilizar Table Splitting, al menos un campo sea ```[Required]```.
  * Clase ```Cine```:
    * Tendr谩 una propiedad de navegaci贸n ```CineDetalle```.
  * Clase ```ApplicationDbContext```:
    * Se a帽ade un DBSet ```DbSet<CineDetalle>```.
  * Clase ```CineConfig```:
    * Se configura la relaci贸n 1 a 1.
  * Clase ```CineDetalleConfig```:
    * Se configura para que mapee el resultado a la tabla **[Cines]**.
  * Migraci贸n: ```CineDetalleTableSplitting```.
* Se puede comprobar con **Swagger**, en ```CinesController```, mediante:
  * postCineSinDetalle
  * postCineConDetalle

## 6.13 Divisi贸n de una tabla mediante entidades de propiedad (reutilizaci贸n de entidades secundarias [Owned])<a name="Tema_06_Relaciones_Entidad_Propiedad"></a>
* Similar a la divisi贸n de una tabla (Table Splitting), la divisi贸n mediante entidades de propiedad permite reutilizar entidades secundarias.
* La principales diferencias con el anterior puntos son:
  * En las entidades de propiedad, la entidad dependiente puede ser utilizada en muchas otras entidades, por ejemplo ```Direccion```.
  * Retorna de manera autom谩tica los datos de la entidad secundaria.
* Es posible que varias entidades necesiten almacenar 1 ```Direccion```, por ejemplo ```Cine``` y ```Actor```.
* En BDD, cada tabla tendr谩 los campos ```Calle```, ```Pais```, ```Provincia```.
* Para realizar la reutilizaci贸n:
  * Clase ```Direccion```:
    * Se marcar谩 como ```Owned``` (adue帽ado o propiedad de otra entidad).
    * A partir de EF6 es necesario que para utilizar Table Splitting, al menos un campo sea ```[Required]```.
  * Clase ```Cine```:
    * Tendr谩 una propiedad de navegaci贸n ```Direccion```.
  * Clase ```Actor```:
    * Tendr谩 una propiedad de navegaci贸n ```DireccionHogar``` y otra ```BillingAddress```.
  * Clase ```CineConfig```:
    * Si no se quiere que los nombre sean: ```BillingAddress_Calle```, ```BillingAddress_Pais``` y ```BillingAddress_Provincia```:
    * Configurar la salida con el m茅todo ```OwnsOne```
   * Clase ```ActorConfig```:
    * Similar configuraci贸n que ```ActorConfig```.
  * Migraci贸n: ```EjemploOwned```.
* Se puede comprobar con **Swagger**, en ```CinesController```, mediante:
  * M茅todo ```/api/cines/{id}```: la query generada devuelve los campos de direcci贸n: ```[t0].[Calle], [t0].[Pais], [t0].[Provincia]```.

## 6.14 Herencia de clases - una sola tabla por jerarqu铆a (Table per Hierarchy - TPH) <a name="Tema_06_Relaciones_Herencia_TPH_"></a>
* Las entidades pueden relacionarse utilizando el mecanismo de herencia.
* Queremos manejar clases diferentes, con sus propios datos, pero que van a ir a la misma tabla.
* Por ejemplo:
  * Un sistema de alquiler de pel铆culas, en donde haya diferentes m茅todos de pago (paypal, tarjeta), con elementos comunes de pago.
  * Se crear谩n dos clases para Pagos, con sus datos comunes y espec铆ficos, pero que van a ir a la misma tabla de **[Pagos]**
  * A nivel de BDD, todos los datos se guardar谩n en la tabla ```[Pagos]```.
  * ![My Image](06_Relaciones_BDD_Pagos.PNG)
* Para realizar la herencia de clases:
  * Enum ```TipoPago```: para indicar si es paypal o tarjeta.
  * Clase ```Pago```: 
    * Clase abstracta, la cual va a tener propiedades comunes de todos los tipos de pago.
    * Se crea abstracta porque no queremos que nadie genere un pago de este tipo sin instanciarlo y configurarlo.
    * Contiene una propiedad ```TipoPago```, que discriminar谩 el tipo de pago.
  * Clase ```PagoPaypal```: clase que deriva de ```Pago```.
  * Clase ```PagoTarjeta```: clase que deriva de ```Pago```.
  * Clase ```AlquilerPelicula```: gestionar谩 un alquiler, as铆 como el m茅todo de Pago.
  * Clase ```ApplicationDbContext```: se genera el ```DbSet<Pago> Pagos```.
  * Clase ```PagoConfig```: se configurar谩 mediante ```HasDiscriminator```, que permite a EF indicar en la relaci贸n entre una clase derivada utilizada, y el enum correspondiente un registro (PayPal o Tarjeta).
  * Clase ```PagoPaypalConfig```
  * Clase ```PagoTarjetaConfig```
  * Migraci贸n: ```HerenciaTPH```. 
  * Clase ```PagosController```
    * Se puede filtrar que devuelva los de un tipo espec铆fico:
      * Todos los pagos: ```return await context.Pagos.ToListAsync();```
      * Pagos mediante tarjeta: ```return await context.Pagos.OfType<PagoTarjeta>().ToListAsync();```
      * Pagos mediante paypal: ```return await context.Pagos.OfType<PagoTarjeta>().ToListAsync();```

## 6.15 Herencia de clases - una sola tabla por cada tipo (Table per Type - TPT) <a name="Tema_06_Relaciones_Herencia_TPT_"></a>
* A diferencia de la Herencia de clases - TPH, se crea una tabla por cada una de las clases involucradas en la relaci贸n.
* Es 煤til si las clases derivadas tienen demasiados datos diferentes y por tanto una sola tabla tendr铆a demasiadas columnas.
* Por ejemplo:
  * Una relaci贸n con una entidad abstracta de producto.
  * A nivel de BDD, los datos se guardar谩n en varias tablas: ```[Productos]```, ```[Merchandising]``` y ```[PeliculasAlquilables]```.
  * ![My Image](06_Relaciones_BDD_Productos.PNG)
* Para realizar la herencia de clases:
  * Clase ```Producto```: 
    * Clase abstracta, la cual va a tener propiedades comunes al resto de elementos que hereden de esta clase.
    * Se crea abstracta porque no queremos que nadie genere un producto de este tipo sin instanciarlo y configurarlo.
  * Clase ```PeliculaAlquilable```: clase que deriva de ```Producto```.
  * Clase ```Merchandising```: clase que deriva de ```Producto```.
  * Clase ```ApplicationDbContext```: 
    * En el m茅todo ```OnModelCreating``` se configura para que cada clase derivada vaya a una tabla espec铆fica.
    * Se genera el ```DbSet<Producto> Productos```.
  * Migraci贸n: ```HerenciaTPT```. 
  * Clase ```ProductosController```
    * Se puede filtrar que devuelva los de un tipo espec铆fico:
      * Todos los productos: ```return await context.Productos.ToListAsync();```
      * Productos de tipo Merchandising: ```return await context.Set<Merchandising>().ToListAsync();```
      * Productos de tipo PeliculaAlquilable: ```return await context.Set<PeliculaAlquilable>().ToListAsync();```

---

# M脫DULO 07. Comandos y migraciones <a name="Tema_07_Comandos_Y_Migraciones"></a>
**Objetivo:** ahondar m谩s en el manejo de comandos y migraciones, a trav茅s del **Package Manager Console**.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_07_Comandos_Y_Migraciones_Migraciones)
2. [Creando el proyecto](#Tema_07_Comandos_Y_Migraciones_Creacion)
3. [Comando Get-Help](#Tema_07_Comandos_Y_Migraciones_GetHelp)
4. [Comando Add-Migration](#Tema_07_Comandos_Y_Migraciones_Add-Migration)
5. [Comando Update-Database](#Tema_07_Comandos_Y_Migraciones_Update-Database)
6. [Comando Remove-Migration](#Tema_07_Comandos_Y_Migraciones_Remove-Migration)
7. [Comando Get-Migration](#Tema_07_Comandos_Y_Migraciones_Get-Migration)
8. [Comando Drop-Database](#Tema_07_Comandos_Y_Migraciones_Drop-Database)
9. [Modificando las migraciones manualmente](#Tema_07_Comandos_Y_Migraciones_Modificacion_Manual)
10. [Despliegue: Migration bundles o empaquetado de migraciones en ejecutables ](#Tema_07_Comandos_Y_Migraciones_Bundles)
11. [Despliegue: Comando Script-Migration para general un script SQL](#Tema_07_Comandos_Y_Migraciones_Script-Migration)
12. [Despliegue: M茅todo Database.Migrate() de c# - Aplicando las migraciones desde C#](#Tema_07_Comandos_Y_Migraciones_C)
13. [Mejora del rendimiento: Modelos compilados con el comando Optimize](#Tema_07_Comandos_Y_Migraciones_Modelos_Compilados_)
14. [Base de Datos Primero (Database first) - Scaffold-DbContext](#Tema_07_Comandos_Y_Migraciones_DBFirst_)

## 7.0 Migraciones 鈿欙笍 <a name="Tema_07_Comandos_Y_Migraciones_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_07_Migraciones]**.
  * Creaci贸n del esquema con todos los ejemplos del tema.
  * Inserci贸n de datos de prueba.

### 7.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 7.1 Creando el proyecto <a name="Tema_07_Comandos_Y_Migraciones_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **07_Comandos_Y_Migraciones**
* BDD utilizada: **[EFCorePeliculasDB_07_Migraciones]**

## 7.2 Comando Get-Help <a name="Tema_07_Comandos_Y_Migraciones_GetHelp"></a>
* ```Get-Help```: sirve para obtener informaci贸n sobre otros comandos.
  * ```Get-Help Add-Migration```: informaci贸n b谩sica.
  * ```Get-Help Add-Migration -detailed```: informaci贸n detallada.
  * ```Get-Help Add-Migration -full```: informaci贸n detallada, quiz谩s demasiado abrumadora.

## 7.3 Comando Add-Migration <a name="Tema_07_Comandos_Y_Migraciones_Add-Migration"></a>
* ```Add-Migration```: permite agregar migraciones que por defecto.
* Por defecto, las migraciones se generan en la carpeta "Migrations", aunque se puede cambiar la carpeta:
  * ```Add-Migration EjemploNuevaCarpeta -OutputDir Migraciones```
* Las migraciones generadas tienen dos m茅todos:
  * ```Up```: se ejecuta cuando se aplica la migraci贸n en la base de datos.
  * ```Down```: se ejecuta si se necesita revertir la migraci贸n en la base de datos. Hace lo contrario al m帽etodo ```Up```.

## 7.4 Comando Update-Database <a name="Tema_07_Comandos_Y_Migraciones_Update-Database"></a>
* ```Update-Database```: recoge las migraciones y las aplica en la base de datos.
* El orden de ejecuci贸n es cronol贸gico.
* Se puede indicar que actualice hasta una migraci贸n concreta:
  * ```Update-Database Primera```.
* Se puede visualizar las migraciones realizadas en la tabla ```[_EFMigrationsHistory]```.

## 7.5 Comando Remove-Migration <a name="Tema_07_Comandos_Y_Migraciones_Remove-Migration"></a>
* ```Remove-Migration```: podemos remover migraciones. Si no se indica nada m谩s, remueve la migraci贸n m谩s reciente.
* Existen dos casu铆sticas:
  * Remover migraciones que no ha sido aplicada a la base de datos: es m谩s sencilla.
    * ```Remove-Migration```.
  * Remover migraciones que s铆 ha sido aplicada a la base de datos.
    * ```Remove-Migration``` provocar谩 un error ya que ha sido aplicada en la base de datos, por lo que hay que ejecutar:
      * Remover una migraci贸n de forma total: ```Remove-Migration -Force```: ejecutar谩 el m茅todo ```Down``` de la migraci贸n.
      * Remover una migraci贸n de forma parcial: a帽adir una nueva migraci贸n con ```Add-Migration``` que remueva el cambio.

## 7.6 Comando Get-Migration <a name="Tema_07_Comandos_Y_Migraciones_Get-Migration"></a>
* ```Get-Migration```: podemos visualizar las migraciones, las ya aplicadas y las pendientes.

## 7.7 Comando Drop-Database <a name="Tema_07_Comandos_Y_Migraciones_Drop-Database"></a>
* ```Drop-Database```: sirve para eliminar una base de datos.
* Hay que tener mucho cuidado al utilizar este comando.

## 7.8 Modificando las migraciones manualmente <a name="Tema_07_Comandos_Y_Migraciones_Modificacion_Manual"></a>
* Las migraciones se pueden cambiar a nuestro antojo, aunque se deben realizar antes de aplicar la migraci贸n en la base de datos.
* Por ejemplo:
  * Para colocar una vista en una migraci贸n (revisar la migraci贸n ```VistaConteoPeliculas```).
  * Para realizar delete con restrict (revisar la migraci贸n ```EjemploPersona```).

## 7.9 Despliegue: Migration bundles o empaquetado de migraciones en ejecutables <a name="Tema_07_Comandos_Y_Migraciones_Bundles"></a>
* 驴Qu茅 sucede si queremos aplicar las migraciones en un servidor que no tiene .Net instalado?
* 驴Qu茅 sucede si tenemos un proceso de entrega continua en el cual se deben automatizar los despliegues de las aplicaciones y bases de datos?
* Con migration bundles se crea un ejecutable el cual se puede correr contra una base de datos y ejecutar谩 las migraciones pendientes.
* Es una especie de ```Update-Database``` empaquetado en un ejecutable.
* Pasos:
  * Package Manager (actualmente falla, es un bug de EF):
    * ```Get-Migration``` para ver las migraciones no aplicadas.
    * ```Bundle-Migration``` deber铆a funcionar, aunque hay un peque帽o bug en el que Microsoft est谩 trabajando.
  * PowerShell (Acceder a la ubicaci贸n del proyecto y ejecutar en PowerShell, esta forma no falla):
    * Crear bundle: ```dotnet ef migrations bundle --configuration Bundle```.
      * Crear谩 un ejecutable llamado ```efbundle.exe``` con todas las migraciones de la aplicaci贸n.
    * Ejecutar bundle: ```.\efbundle.exe --connection "Connection_String_XXX_"```
    * Sustituir bundle tras nueva migraci贸n: ```dotnet ef migrations bundle --configuration Bundle --force```.

## 7.10 Despliegue: Comando Script-Migration para general un script SQL<a name="Tema_07_Comandos_Y_Migraciones_Script-Migration"></a>
* Genera el script de SQL (con extensi贸n .sql), el cual va a generar los cambios en la base de datos.
* Se puede ejecutar contra cualquier base de datos en un proceso de entrega continua.
* Package Manager (actualmente falla, es un bug de EF):
  * ```Script-Migration```: genera el script SQL sin verificaciones de objetos. No se puede ejecutar 2 veces, ya que no comprueba si un elemento est谩 creado o no.
  * ```Script-Migration -Idempotent```: genera el script SQL sin verificaciones de objetos. S铆 se puede ejecutar 2 veces, ya que no comprueba si un elemento est谩 creado o no.
* Problema:
  * Si existen migraciones manuales con sql personalizado, donde se incluyen vistas u otros objetos, se producir谩 un error. Los migration bundles no tienen este problema.

## 7.11 Despliegue: M茅todo Database.Migrate() de c# - Aplicando las migraciones desde C# <a name="Tema_07_Comandos_Y_Migraciones_C"></a>
* Con ```Migrate``` se pueden aplicar las migraciones desde la aplicaci贸n.
* ```Migrate``` permite ejecutar una funci贸n desde nuestra aplicaci贸n, la cual se encargar谩 de aplicar las migraciones.
* Problemas:
  * El comando ```Migrate``` podr铆a fallar si es ejecutado por varias aplicaciones de manera simult谩nea.
  * Si tarda mucho en ejecutarse, puede producirse un timeout de ASP.NET Core, pero no aplica para aplicaciones de consola, WPF o Windows Forms.
  * La primera vez que se ejecute la aplicaci贸n, puede tardar un poco ya que debe ejecutar las migraciones.
  * Si las migraciones dan error, es dif铆cil descubrir el error.
* Para utilizarlo:
  * Clase ```program```: ```applicationDbContext.Database.Migrate()```

## 7.12 Mejora del rendimiento: Modelos compilados con el comando Optimize <a name="Tema_07_Comandos_Y_Migraciones_Modelos_Compilados_"></a>
* Cuando existen cientos de entidades puede que la carga inicial sea lenta.
* Los modelos compilados permiten optimizar la inicializaci贸n del modelo de EF.
* La documentaci贸n oficial no recomienda utilizar modelos compilados si se tienen pocas entidades.
* Existen limitaciones con los modelos compilados:
  * Los filtros no son compatibles. Por ejemplo, habr铆a que omitir en la clase ```GeneroConfig``` el ```HasQueryFilter```.
  * Lazy loading no es compatible.
  * Cuando se hagan cambios, se debe ejecutar un comando para regenerar los modelos compilados.
* Ejemplo:
  * Package Manager:
    * ```Optimize-DbContext```: comando para ejecutar los modelos compilados. 
    * Este comando crear谩 modelos compilados de las entidades en la carpeta **[CompiledModels]**.
  * Clase ```program```: ```opciones.UseModel(ApplicationDbContextModel.Instance)```

## 7.13 Base de Datos Primero (Database first) - Scaffold-DbContext <a name="Tema_07_Comandos_Y_Migraciones_DBFirst_"></a>
* Permite tomar una base de datos existente y generar las entidades a partir de la base de datos.
* Ideal para cuando la base de datos ya est谩 creada pero se quiere utilizar EF.
* Para este ejemplo, se utilizar谩 un nuevo proyecto Web API ```PruebaBDPrimero```.
* Se van a generar los modelos de base de datos a ra铆z de la base de datos:
* Ejemplo:
  * Package Manager:
    * ```Scaffold-DbContext name=DefaultConnection -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entidades```.
    * Generar谩 tambi茅n la clase ```EFCorePeliculasDBContext```.
  * Se deber谩n hacer ajustes, como por ejemplo:
    * Clase ```Program```: configurar el DBContext en el contenedor de inyecci贸n de dependencias.
    * Generar los controladores.
  * Si posteriormente se realizan cambios en la base de datos, se pueden subir al proyecto mediante:
    * ```Scaffold-DbContext name=DefaultConnection -Provider Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entidades -Force```. 

---

# M脫DULO 08. El DbContext <a name="Tema_08_DbContext"></a>
**Objetivo:** profundizar en las capacidades del DBContext.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_08_DbContext_Migraciones)
2. [Creando el proyecto](#Tema_08_DbContext_Creacion)
3. [Principales propiedades del DbContext](#Tema_08_DbContext_Propiedades)
4. [Configuraci贸n alternativa de DBContext: OnConfiguring](#Tema_08_DbContext_OnConfiguring)
5. [Cambiando el estatus de una entidad con Entry](#Tema_08_DbContext_Estatus)
6. [Actualizando algunas propiedades](#Tema_08_DbContext_Actualizar_Propiedades)
7. [Sobrescribir SaveChanges](#Tema_08_DbContext_Sobrescribir_SaveChanges)
8. [Inyecci贸n de dependencias por constructor en DbContext](#Tema_08_DbContext_Iny_Dependencias)
9. [Eventos que se pueden capturar en el DBContext](#Tema_08_DbContext_Eventos)
10. [Sentencias SQL - Select](#Tema_08_DbContext_SQL_Select)
11. [Sentencias SQL - Inserts, updates, deletes](#Tema_08_DbContext_SQL_CRUD)
12. [Sentencias SQL - ToSqlQuery() - Centralizando queries Arbitrarios](#Tema_08_DbContext_SQL_ToSqlQuery)
13. [Uso de procedimientos almacenados](#Tema_08_DbContext_SQL_SP)
14. [Transacciones por defecto](#Tema_08_DbContext_Transacciones_por_defecto)
15. [Transacciones manuales - el mecanismo BeginTransaction() - una transacci贸n para varios SaveChanges](#Tema_08_DbContext_Transacciones_Manuales)
    
## 8.0 Migraciones 鈿欙笍 <a name="Tema_08_DbContext_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_08_DbContext]**.
  * Creaci贸n del esquema con todos los ejemplos del tema.
  * Inserci贸n de datos de prueba.

### 8.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD), aunque se a帽aden nuevas tablas.
 
## 8.1 Creando el proyecto <a name="Tema_08_DbContext_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **08_DbContext**
* BDD utilizada: **[EFCorePeliculasDB_08_DbContext]**

## 8.2 Principales propiedades del DbContext <a name="Tema_08_DbContext_Propiedades"></a>
* **Database**: permite acceder a propiedades relacionadas con: transacciones, creaci贸n y migraci贸n de base de datos, queries arbitrarias.
* **ChangeTracker**: permite acceder al c贸digo encargado de dar seguimiento a los cambios de las entidades, para poder realizar la acci贸n pertinente cuando se llame al m茅todo ```SaveChanges()```.
* **Model**: permite acceder al modelo de BDD que EF utiliza para conectarse a la BDD.
* **ContextId**: identificador 煤nico de cada instancia del contexto. Permite saber si una sequencia de queries est谩n siendo lanzadas por el mismo DbContext.

## 8.3 Configuraci贸n alternativa de DBContext: OnConfiguring <a name="Tema_08_DbContext_OnConfiguring"></a>
* Adem谩s de ```builder.Services.AddDbContext``` en la clase ```Program.cs```, existe otra manera de configurar el DBContext.
* Se trata del m茅todo ```OnConfiguring``` del propio ```DbContext```.
* Revisar clase ```ApplicationDbContext```:
  * Se puede chequear que no haya sido configurado previamente, por ejemplo, en ```program.cs```.

## 8.4 Cambiando el estatus de una entidad con Entry <a name="Tema_08_DbContext_Estatus"></a>
* Si se quiere cambiar manualmente el estado a una entidad, se puede hacer manualmente.
* Ejemplo para inserci贸n:
  * ```GenerosController```, m茅todo ```CambiarEstatusEntidadManualmente```.
  * El c贸digo utilizado: ```context.Entry(genero).State = EntityState.Added;```.

## 8.5 Actualizando algunas propiedades <a name="Tema_08_DbContext_Actualizar_Propiedades"></a>
* Se puede evitar actualizar todas las columnas de una tabla. Se puede realizar marcando las propiedades una por una.
* Ejemplo:
  * ```ActoresController```, m茅todo ```PutDesconectado```.
  * El c贸digo utilizado: ``` context.Entry(actor).Property(a => a.Nombre).IsModified = true;```.

## 8.6 Sobrescribir SaveChanges <a name="Tema_08_DbContext_Sobrescribir_SaveChanges"></a>
* Se puede sobrescribir SaveChanges para poder realizar una acci贸n espec铆fica al momento de guardar cambios de una manera centralizada. 
* Por ejemplo, para realizar auditor铆as con el usuario que realiza las acciones.
* Ejemplo:
  * Clase ```EntidadAuditable```: creaci贸n de la clase abstracta con usuario de creaci贸n y modificaci贸n.
  * Clase ```Genero```: heredar谩 de la clase ```EntidadAuditable```.
  * Se genera una migraci贸n ```GeneroAuditable``` para que realice los cambios a la tabla ```[Generos]```.
  * Clase ```ApplicationDbContext```:
    * Se genera un m茅todo ```ProcesarSalvado``` que incluye la l贸gica a incorporar.
    * Se sobreescribe ```SaveChangesAsync``` incluyendo el m茅todo ```ProcesarSalvado```.

## 8.7 Inyecci贸n de dependencias por constructor en DbContext <a name="Tema_08_DbContext_Iny_Dependencias"></a>
* Se pueden incorporar dependencias en el constructor del DbContext.
* Ejemplo:
  * Clase ```ApplicationDbContext```.

## 8.8 Eventos que se pueden capturar en el DBContext <a name="Tema_08_DbContext_Eventos"></a>
* Se pueden utilizar eventos en EF. Estos eventos se disparar谩n siempre y cuando no se est茅 usando ```AsNoTracking()```:
  * Evento **ChangeTracker.Tracked** se ejecuta cuando EF le empieza a dar seguimiento a una entidad.
  * Evento **ChangeTracker.StateChanged** se ejecuta cuando el estatus de una entidad que ya recibe seguimiento cambia. en este momento se conoce el estado anterior de la entidad y el nuevo.
  * Cuando se realizan cambios:
    * Evento **SavingChanges**: se dispara antes de guardar los cambios.
    * Evento **SavedChanges**: se dispara despu茅s de guardar los cambios.
    * Evento **SaveChangesFailed**: se dispara si el proceso de guardar cambios produce un error.
* Ejemplo:
  * Interfaz ```IEventosDbContext```, con los siguientes m茅todos: ```ManejarSaveChangesFailed();ManejarSavedChanges();ManejarSavingChanges();ManejarStateChange();ManejarTracked();```.
  * Clase ```EventosDbContext```: que implementa ```IEventosDbContext```.
  * Clase ```ApplicationDbContext```: en el constructor, se registran los eventos.
* Se puede comprobar lanzando cualquier operaci贸n con **Swagger**, y verificando la salida por consola.

## 8.9 Sentencias SQL - Select <a name="Tema_08_DbContext_SQL_Select"></a>
* Se pueden ejecutar sentencias SQL de tipo Select, de manera directa mediante EF.
* Es importante evitar SQL injection, por lo que los ejemplos a帽adidos lo evitan con declaraci贸n de variables.
* Para anexar una sentencia Select de SQL, se utiliza ```FromSqlRaw``` y ```FromSqlInterpolated```. Estos se pueden combinar con otros m茅todos cl谩sicos de EF como ```Include```.
* Ejemplo:
  * Clase ```GenerosController```, m茅todos:
    * GetFromSql_Forma1_FromSqlRaw
    * GetFromSql_Forma2_FromSqlInterpolated
  * Clase ```CinesController```, m茅todos:
    * GetFromSqlInterpolatedConIncludes: utiliza la combinaci贸n de sentencias sql e ```Include```.

## 8.10 Sentencias SQL - Inserts, updates, deletes <a name="Tema_08_DbContext_SQL_CRUD"></a>
* Se pueden ejecutar sentencias SQL de tipo Inserts, updates, deletes.
* Para anexar una sentencia Insert, etc de SQL, se utiliza ```ExecuteSqlInterpolatedAsync```.
* Ejemplo:
  * Clase ```GenerosController```, m茅todos:
    * PostFromSqlExecuteSqlInterpolatedAsync

## 8.11 Sentencias SQL - ToSqlQuery() - Centralizando queries Arbitrarios <a name="Tema_08_DbContext_SQL_ToSqlQuery"></a>
* Se puede mapear una vista a una clase. Del mismo modo se puede centralizar una sentencia sql y mapearlo a una entidad espec铆fica.
* Personalmente, me parece mejor realizarlo con una vista ```ToView("PeliculasConConteos")```.
* Ejemplo:
  * Clase ```ApplicationDbContext```, m茅todos:
    * Revisar ```modelBuilder.Entity<PeliculaConConteos>().ToSqlQuery(....query sql....)```.
    * Tambi茅n se encuentra comentada la opci贸n de llamar a una vista: ```ToView("PeliculasConConteos")```.

## 8.12 Uso de procedimientos almacenados <a name="Tema_08_DbContext_SQL_SP"></a>
* Se puede ejecutar directamente procedimientos almacenados. 
* Ejemplo:
  * Se genera una migraci贸n ```ProcedimientosAlmacenados``` con:
    * Generos_ObtenerPorId
    * Generos_Insertar
  * Clase ```GenerosController```: 
    * ```GetFromProcedimientoAlmacenado```: se ha hecho con ```FromSqlInterpolated```.
    * ```PostFromProcedimientoAlmacenado```: se ha ejecutado con ```ExecuteSqlRawAsync```.

## 8.13 Transacciones por defecto <a name="Tema_08_DbContext_Transacciones_por_defecto"></a>
* En el contexto de base de datos, una transacci贸n requiere que varias operaciones diferentes sean realizadas de manera at贸mica.
* Esto implica que todas las operaciones dentro de una operaci贸n, deben ser exitosas, o si no no se da como correcto y se deben deshacer los cambios. 
* Por ejemplo, esto sucede con la entidad ```Cine``` y ```SalaDeCine```. No se puede insertar una sala de cine con sus salas de cine si alguna de las dos operaciones falla. 
* Es la forma por defecto que trabaja el DBContext con ```context.SaveChangesAsync()```, por ejemplo, se requiere la inserci贸n de m煤ltiples cines.
* Ejemplo:
  * Clase ```GenerosController```: 
    * ```PostInsercionMultipleTransaccioPorDefecto```: si falla cualquier inserci贸n de cines de la lista, no se completar谩 el resto.

## 8.14 Transacciones manuales - el mecanismo BeginTransaction() - una transacci贸n para varios SaveChanges <a name="Tema_08_DbContext_Transacciones_Manuales"></a>
* En ocasiones no es suficiente el mecanismo de transacciones de ```context.SaveChangesAsync()```.
* A veces necesitamos realizar una operaci贸n, luego realizar otra, y si la segunda operaci贸n da error entonces revertir la primera operaci贸n.
* Supongamos que la aplicaci贸n trabajar谩 con ```Factura``` y ```FacturaDetalle```.
* Sin embargo, por alg煤n motivo, no vamos a establecer directamente una relaci贸n 1 a N entre las entidades mediante propiedades de navegaci贸n.
* En este caso, ser谩 necesario utilizar transacciones a la hora de insertar una factura.
* Ejemplo:
  * Clase ```Factura```.
  * Clase ```FacturaDetalle```.
  * Clase ```FacturaConfig```.  
  * Clase ```ApplicationDbContext```, se incluye el DbSet ```DbSet<FacturaDetalle>```.
  * Se genera la migraci贸n ```Facturas```.
  * Clase ```FacturasController```: 
    * ```PostConTransaccion```: si falla la inserci贸n de una factura, realiza el rollback ya que se est谩 controlando con ```context.Database.BeginTransactionAsync()```.

---

# M脫DULO 09. Entity Framework avanzado <a name="Tema_09_EF_Avanzado"></a>
**Objetivo:** profundizar en otras caracter铆sticas avanzadas dentro de EF.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_09_EF_Avanzado__Migraciones)
2. [Creando el proyecto](#Tema_09_EF_Avanzado_Creacion)
3. [Funciones escalares](#Tema_09_EF_Avanzado_Funciones_Escalares)
4. [Funciones con valores de tabla](#Tema_09_EF_Avanzado_Funciones_Tabla)
5. [Columnas calculadas (HasComputedColumnSql)](#Tema_09_EF_Avanzado_Columnas_Calculadas)
6. [Campo de secuencia para ordenaciones (HasSequence)](#Tema_09_EF_Avanzado_Campo_Secuencia)
7. [Conflictos de concurrencia por campo ([ConcurrencyCheck])](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Campo)
8. [Conflictos de concurrencia por fila ([Timestamp])](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Fila)
9. [Conflictos de concurrencia, mensajes de respuesta amigables capturando DbUpdateConcurrencyException](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Mensajes_Amigables)
10. [Conflictos de concurrencia con el modelo desconectado](#Tema_09_EF_Avanzado_Conflicto_Concurrencia_Desconectado)
11. [Tablas temporales (vigentes + hist贸rico): introducci贸n](#Tema_09_EF_Avanzado_Tablas_Intro)
12. [Tablas temporales: inserci贸n, edici贸n, borrado](#Tema_09_EF_Avanzado_Tablas_CRUD)
13. [Tablas temporales: consulta de tabla temporal e hist贸rica (TemporalAll)](#Tema_09_EF_Avanzado_Tablas_TemporalAsOf)
14. [Tablas temporales: consulta por fecha concreta (TemporalAsOf())](#Tema_09_EF_Avanzado_Tablas_TemporalAsOf)
15. [Tablas temporales: consulta por rangos de fechas (TemporalFromTo(), TemporalContainedIn(), TemporalBetween()](#Tema_09_EF_Avanzado_Tablas_Temporal__Rangos)
16. [Tablas temporales: restaurando un registro borrado](#Tema_09_EF_Avanzado_Tablas_Temporal_Borrado)
17. [Tablas temporales: personalizaci贸n de nombre de columnas y de tabla](#Tema_09_EF_Avanzado_Tablas_Temporal_Personalizacion)
18. [Trabajando con el DbContext en otro proyecto](#Tema_09_EF_Avanzado_Tablas_Temporal_DbContext)

## 9.0 Migraciones 鈿欙笍 <a name="Tema_09_EF_Avanzado__Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_09_EF_Avanzado]**.
  * Creaci贸n del esquema con todos los ejemplos del tema.
  * Inserci贸n de datos de prueba.

### 9.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD), aunque se a帽aden nuevas tablas.

## 9.1 Creando el proyecto <a name="Tema_09_EF_Avanzado_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la soluci贸n **09_EF_Avanzado**
* BDD utilizada: **[EFCorePeliculasDB_09_EF_Avanzado]**

## 9.2 Funciones escalares <a name="Tema_09_EF_Avanzado_Funciones_Escalares"></a>
* Una funci贸n definida por el usuario es una funci贸n en nuestra base de datos la cual podemos usar para encapsular funcionalidad.
* Son s贸lo para realizar consultas, no para modificar la base de datos.
* El resultado de esta funci贸n puede ser un escalar o un conjunto de resultado (valores de tabla).
* Se generar谩n dos funciones escalares:
  * ```FacturaDetalleSuma```: calcula la suma de los costos de las 贸rdenes de una factura.
  * ```FacturaDetallePromedio```: calcula el promedio de los costos.
* Ejemplo:
  * Clase ```SeedingFacturas```: para insertar datos.
  * Clase ```ApplicationDbContext```: a帽adir ```SeedingFacturas.Seed```.
  * Se agregan las migraciones:
    * ```DatosFacturaEjemplo```: con la alimentaci贸n de datos de facturas.
    * ```FuncionesDefinidasPorElUsuario```: con las funciones ```FacturaDetalleSuma``` y ```FacturaDetallePromedio```.
  * Clase ```ApplicationDbContext```:
    * Para ```FacturaDetalleSuma``: a帽adir un m茅todo llamado ```FacturaDetalleSuma```, decorado con el atributo ```[DbFunction]```.
    * Para ```FacturaDetallePromedio```:
      * Una buena pr谩ctica, en el caso de que existan muchas funciones, es poner estos m茅todos en una clsae auxiliar.
      * Revisar Entidades/Funciones/Escalares
  * Clase ```FacturasController```: 
    * ```GetFuncionesEscalares```: se llama a ambas funciones escalares.

## 9.3 Funciones con valores de tabla <a name="Tema_09_EF_Avanzado_Funciones_Tabla"></a>
* Al igual que cuando se llama a una vista, es necesario una clase Keyless (entidades sin Llave).
* Ejemplo:
 * Clase ```PeliculaConConteos```.
  * Se agrega la migraci贸n ```TVF``` (Table Value Function): con la funci贸n ```PeliculaConConteos```.
  * Clase ```ApplicationDbContext```:
    * A帽adir un m茅todo llamado ```PeliculaConConteos```.
    * Registrarlo a trav茅s de:
      * ```modelBuilder.Entity<PeliculaConConteos>().HasNoKey().ToTable(name: null);```
      * ```modelBuilder.HasDbFunction(() => PeliculaConConteos(0));```
  * Clase ```PeliculasController```: 
    * ```GetPeliculasConConteos```: se llama a la funci贸n.

## 9.4 Columnas calculadas (HasComputedColumnSql) <a name="Tema_09_EF_Avanzado_Columnas_Calculadas"></a>
* Permiten automatizar el rellenado de estas columnas con el resultado de alguna operaci贸n.
* De esta manera centralizamos el valor de estas columnas en la base de datos, a trav茅s de una columna "computed".
* Existes dos tipos de columnas calculadas:
  * **Las que guardan su valor final** en la columna.
  * **Las que no guardan dicho valor** y lo calculan "on the fly
    * Recomendado para operaciones r谩pidas. 
    * En ciertas operaciones puede ser lento, pero a la vez, se ahorra espacio en la base de datos.
* Se integrar谩 una columna calculada ```Total``` a ```FacturaDetalle```, que ser谩 la multiplicaci贸n de Precio * Cantidad.*.
* Ejemplo:
  * Clase ```PeliculaConConteos```.
    * Se agregan las propiedades ```Cantidad``` y ```Total```.
  * Clase ```FacturaDetalleConfig```.
    * Se a帽ade la configuraci贸n de Total mediante ```HasComputedColumnSql()```.
    * Si se quisiera guardar en base de datos, utilizar ```stored: true```: ```.HasComputedColumnSql("Precio * Cantidad", stored: true);```.
  * Se agrega la migraci贸n ```TotalCalculado```.
  * Clase ```FacturasController```: 
    * ```GetDetalle```: retornar谩 el campo calculado.

## 9.5 Campo de secuencia para ordenaciones (HasSequence)<a name="Tema_09_EF_Avanzado_Campo_Secuencia"></a>
* La idea de la secuencia es poder colocar n煤mero en secuencia en distintas filas, en orden.
* Si se utiliza un Id de llave primaria, realmente no hay garant铆a de que haya saltos en los n煤meros.
* Para utilizar una secuencia, se utiliza un valor por defecto en la columna donde se va a colocar el n煤mero de secuencia.
* Ejemplo:
  * Clase ```Factura```. Se agrega la propiedad:
    * ```NumeroFactura```    
  * Clase ```ApplicationDbContext```.
    * Se a帽ade la secuencia a trav茅s de: ```modelBuilder.HasSequence<int>("NumeroFactura", "factura");```
    * Incluso se puede configurar:
      * En qu茅 n煤mero debe comenzra la secuencia con ```.StartsAt(x)```.
      * En cu谩nto debe ser el incremento entre n煤meros de secuencia con ```.IncrementsBy(y)```.
  * Clase ```FacturaConfig```:
    * Se configura a trav茅s de ```HasDefaultValueSql()```.
  * Se agrega la migraci贸n ```SecuenciaEjemplo```.
  * Una vez realizado este proceso, cada vez que se inserte un valor en la tabla ```[Facturas]``` se incrementar谩 autom谩ticamente.

## 9.6 Conflictos de concurrencia por campo ([ConcurrencyCheck])<a name="Tema_09_EF_Avanzado_Conflicto_Concurrencia_Campo"></a>
* Los conflictos de concurrencia ocurren cuando dos procesos intentan realizar un cambio sobre un registro, y el cambio del segundo proceso sobrescribe sin querer el cambio del primer proceso.
* EF permite manejar esta situaci贸n en dos niveles:
  * Por campo.
  * Por fila.
* La idea del conflicto de concurrencia por campo es que pueden existir campos sensibles, los cuales se quieren tratar con seguridad.
* Si dos procesos hacen una lectura sobre el campo sensible y ambos intentan actualizar el mismo campo, al segundo usuario le dar谩 un error.
* Ejemplo:
  * En g茅neros, el campo concurrente ser谩 Nombre.
  * Existen dos maneras de realizarlo:
    * **Modo 1**: Clase ```Genero```: se agrega el atributo ```ConcurrencyCheck``` a la propiedad ```Nombre```.
    * **Modo 2**: Mediante Fluent API: Clase ```GeneroConfig```, en la propiedad ```Nombre``` configurar ```IsConcurrencyToken()```.
  * Clase ```GenerosController```: 
    * ```concurrency_token```: provocar谩 el fallo a la hora de intentar insertar dos veces el mismo campo (ver comentarios en el c贸digo que explican el ejemplo).

## 9.7 Conflictos de concurrencia por fila ([Timestamp])<a name="Tema_09_EF_Avanzado_Conflicto_Concurrencia_Fila"></a>
* A diferencia de la concurrencia por campo, en el caso por fila, cualquier cambio de registro implicar谩 un fallo en el proceso.
* Ejemplo:
  * En facturas, controlar que no se maneje una misma factura desde dos sitios sin tener el control.
  * Clase ```Factura```:
    * Propiedad de array de bytes ```Version```.    
  * Existen dos maneras de realizarlo:
    * **Modo 1**: Clase ```Factura```: se agrega el atributo ```Timestamp``` a la propiedad ```Version```.
    * **Modo 2**: Mediante Fluent API: Clase ```FacturaConfig```, en la propiedad ```Version``` configurar ```IsRowVersion()```.
  * Se agrega la migraci贸n ```FacturaVersion```.
  * Clase ```FacturasController```: 
    * ```Concurrencia_Fila```: retornar谩 el campo calculado.

## 9.8 Conflictos de concurrencia, mensajes de respuesta amigables capturando DbUpdateConcurrencyException<a name="Tema_09_EF_Avanzado_Conflicto_Concurrencia_Mensajes_Amigables"></a>
* Para evitar devolver un error al usuario, se puede gestionar los mensajes que se devuelven en la excepci贸n de tipo ```DbUpdateConcurrencyException```.
* Cuando se provoca un error por concurrencia, se tendr谩 acceso a dos valores:
  * El valor que se ha intentado insertar.
  * El valor anterior.
* A partir de esas informaciones, se puede tomar una decisi贸n de qu茅 hacer. Por ejemplo, mostrar ambos valores al usuario para que indique cu谩l debe prevalecer.
  * Clase ```FacturasController```: 
    * ```ConcurrenciaFilaManejandoError```: 
      * Revisar c贸mo est谩 capturando la excepci贸n ```ConcurrenciaFilaManejandoError```.
      * A trav茅s de las propiedades ```CurrentValue``` y ```OriginalValue``` se puede acceder a sus valores.

## 9.9 Conflictos de concurrencia con el modelo desconectado<a name="Tema_09_EF_Avanzado_Conflicto_Concurrencia_Desconectado"></a>
* Los ejemplos anteriores son de ejemplos de concurrencia con el modelo conectado.
* Sin embargo, en ambientes web es problable que se trabaje con un modelo desconectado.
* En el caso de **concurrencia por fila**:
  * Se debe enviar el campo que act煤a de versi贸n o timestamp (por ejemplo en ```Factura``` el campo ```Version```).
  * Clase ```FacturasController```: 
    * ```ObtenerFactura```: 
      * Para poder obtener una factura con la versi贸n.
      * Poderla copiar.
    * ```ActualizarFactura```:
      * Pegar la factura copiada de ```ObtenerFactura```.
      * Si se ejecuta 1 vez, funciona correctamente, pero si se hace 2 veces, se produce una excepci贸n, ya que se est谩 enviando la versi贸n que estaba anteriormente.
* En el caso de **concurrencia por campo**:
  * Hay que mandar el valor del campo nuevo y el original.
  * Clase ```GeneroActualizacionDTO```: tendr谩 el nombre nuevo y el original. 
  * Clase ```GenerosController```:
    * Revisar m茅todo ```PutConflictoConcurrenciaCampoDBContextDesconectado```.

## 9.10 Tablas temporales (vigentes + hist贸rico): introducci贸n<a name="Tema_09_EF_Avanzado_Tablas_Intro"></a>
* Las tablas temporales permiten tener un hist贸rico de todos los cambios que suceden en una tabla.
* Almacena los cambios que ha sufrido un registro, proporcionando un seguimiento del mismo.
* En la documentaci贸n oficial de Microsoft, se presenta este esquema y flujo de acciones:
![My Image](09_Tablas_Temporales_Esquema.PNG)
* Un enlace que lo explica muy bien es el siguiente: [Campus MVP - Manejo de tablas temporales de SQL Server con Entity Framework](https://www.campusmvp.es/recursos/post/manejo-de-tablas-temporales-de-sql-server-con-entity-framework-en-net-6-0.aspx)
* B谩sicamente tendremos:
  * **Una tabla temporal (o vigente)**, que es la que contiene los datos vigentes. Por ejemplo, la tabla ```[Generos]```.
  * **Una tabla hist贸rica**, que contiene los distintos cambios que han ocurrido en los datos de la tabla temporal (modificaci贸n o borrado, pero no inserci贸n). Por ejemplo, la tabla ```[GenerosHistory]```.
  * **Campos ```PeriodStart``` y ```PeriodEnd```**: es necesario que en ambas tablas haya unos campos que indiquen el inicio y fin. Por defecto se llaman ```PeriodStart``` y ```PeriodEnd```, aunque se pueden cambiar.
* Posteriormente se podr谩n hacer consultas a los registros hist贸ricos de las entidades.
* Para configurar la tabla ```[Generos]``` como una tabla temporal:
  * Clase ```GeneroConfig```: 
    * A trav茅s de Fluent API, se indica que la tabla es temporal con ```.IsTemporal()```.
    * Se configuran las propiedades ```PeriodStart``` y ```PeriodEnd``` para que acepten minutos. Esto es necesario porque a nivel global cualquier DateTime se ha indicado que por defecto no utilizar谩 minutos, etc.
  * Se agrega la migraci贸n ```GeneroTemporal```.
  * En Base de datos:
    * La tabla se habr谩 guardado como (```System-versioned```)
    * Se habr谩n creado los campos ```PeriodStart``` y ```PeriodEnd``` (en la imagen ```FechaDesde``` y ```FechaHasta```, ya que se realizar谩n acciones de nombrado personalizadas):
![My Image](09_Tablas_Temporales_Esquema2.PNG)

## 9.11 Tablas temporales: inserci贸n, edici贸n, borrado<a name="Tema_09_EF_Avanzado_Tablas_CRUD"></a>
* Una vez configurada la tabla, la inserci贸n de registros ser谩 autom谩tica.
* Se pueden realizar verificaciones mediante: 
  * Clase ```GenerosController```:
    * ```Post(Genero genero)```
    * ```Delete(int id)```
  * Resultados en las tablas ```[Generos]``` y ```[GenerosHistory]```.

## 9.12 Tablas temporales: consulta de tabla temporal e hist贸rica (TemporalAll)<a name="Tema_09_EF_Avanzado_Tablas_TemporalAsOf"></a>
* Se puede consultar tanto la tabla temporal como la hist贸rica.
* Ejemplo:
  * Carga de datos:
    * Se ha creado el endpoint ```ModificarVariasVeces``` en ```GenerosController``` para simular una modificaci贸n de un g茅nero n veces.
    * Ejecutar dicho EndPoint.
  * Mostrar datos de la tabla temporal o vigente:
    * Clase ```GenerosController```:
      * M茅todo ```GetTablaTemporalOVigente```. Podemos consultar los datos de ```PeriodStart``` y ```PeriodEnd```.
  * Mostrar datos de la tabla temporal pero tambi茅n el hist贸rico:
    * Clase ```GenerosController```:
      * M茅todo ```GetTablaTemporalEHistorico```. Podemos consultar los datos tanto vigentes como hist贸ricos, mediante```TemporalAll()```.

## 9.13 Tablas temporales: consulta por fecha concreta (TemporalAsOf())<a name="Tema_09_EF_Avanzado_Tablas_TemporalAsOf"></a>
* Para consultar en una tabla hist贸rica por una fecha espec铆fica incluida en el intervalo entre ```PeriodStart``` y ```PeriodEnd```.
* Ejemplo:
    * Clase ```GenerosController```:  M茅todo ```GetTemporalAsOf```.

## 9.14 Tablas temporales: consulta por rangos de fechas (TemporalFromTo(), TemporalContainedIn(), TemporalBetween()<a name="Tema_09_EF_Avanzado_Tablas_Temporal__Rangos"></a>
* Para consultar un rango de fechas existen los siguientes m茅todos:
  * **TemporalFromTo**: obtiene todos los registros que estaban activos entre dos horas UTC dadas.
  * **TemporalBetween**: lo mismo que el anterior, excepto que se incluyen tambi茅n los registros por la parte superior (o sea, incluye aquellos registros que cumplen con la fecha superior, mientras que el anterior no).
  * **TemporalContainedIn**: devuelve todos los registros que comenzaron a estar activos y terminaron estando activos entre dos horas UTC dadas.
* Ejemplos:
    * Clase ```GenerosController```, m茅todos: ```GetTemporalFromTo```, ```GetTemporalBetween```y ```GetTemporalContainedIn```.

## 9.15 Tablas temporales: restaurando un registro borrado<a name="Tema_09_EF_Avanzado_Tablas_Temporal_Borrado"></a>
* Se puede restaurar cualquier versi贸n del registro que se encuentren en la tabla de hist贸rico.
* Ejemplo:
    * Clase ```GenerosController```:  M茅todo ```RestaurarBorrado```.

## 9.16 Tablas temporales: personalizaci贸n de nombre de columnas y de tabla<a name="Tema_09_EF_Avanzado_Tablas_Temporal_Personalizacion"></a>
* Se pueden personalizar los nombres de:
  *  Campos ```PeriodStart``` y ```PeriodEnd```. 
     *  Se podr铆an cambiar a ```Desde``` y ```Hasta```.
  *  El nombre de la tabla hist贸rica lleva el nombre de ```[FacturasHistory]```.
     *  Se podr铆a cambiar a ```[FacturasHistorico]```.
* Ejemplo:
    * Clase ```FacturaConfig```, c贸digo:  
```
opciones.IsTemporal(t =>
{
    t.HasPeriodStart("Desde");
    t.HasPeriodEnd("Hasta");
    t.UseHistoryTable(name: "FacturasHistorico");
});
builder.Property("Desde").HasColumnType("datetime2");
builder.Property("Hasta").HasColumnType("datetime2");
```
  * Se agrega la migraci贸n ```FacturasTemporal```.
  * En Base de datos, el resultado ser谩: 
![My Image](09_Tablas_Temporales_Esquema3.PNG)

## 9.17 Trabajando con el DbContext en otro proyecto<a name="Tema_09_EF_Avanzado_Tablas_Temporal_DbContext"></a>
* Por temas de organizaci贸n es posible que se decida tener el DBContext en otro proyecto.
* La diferencia es que, a la hora de ejecutar comandos en el modelo **Code First**, hay que pasar el proyecto que contiene el DBContext, por ejemplo, si el proyecto se llama **Data**:
```Add-Migration Primera -Proyect Data```

---

# M脫DULO 10. Entity Framework y pruebas autom谩ticas <a name="Tema_10_Pruebas_Automaticas"></a>
**Objetivo:** configurar de manera autom谩tica el correcto funcionamiento de nuestras aplicaciones.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_10_Test_Migraciones)
2. [Creando el proyecto](#Tema_10_Test_Creacion)
3. [Configurando el Proveedor en memoria ```UseInMemoryDatabase```](#Tema_10_Test_Memoria)
4. [La primera prueba unitaria con EF Core](#Tema_10_Test_Primer_Test)
5. [Configurando AutoMapper para pruebas - Pruebas negativas](#Tema_10_Test_AutoMapper)
6. [Usando LocalDb para pruebas de integraci贸n](#Tema_10_Test_LocalDb)

## 10.0 Migraciones 鈿欙笍 <a name="Tema_10_Test_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_10_EF_Testing]**.
  * Creaci贸n del esquema con todos los ejemplos del tema.
  * Inserci贸n de datos de prueba.

### 10.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD), aunque se a帽aden nuevas tablas.

## 10.1 Creando el proyecto <a name="Tema_10_Test_Creacion"></a>
* Proyectos utilizados: ver carpeta virtual de la soluci贸n **10_Pruebas_Automaticas**
* BDD utilizada: **[EFCorePeliculasDB_10_EF_Testing]**

## 10.2 Configurando el Proveedor en memoria ```UseInMemoryDatabase```<a name="Tema_10_Test_Memoria"></a>
* Un proveedor en memoria permite utilizar una base de datos limitada pero r谩pida para pruebas.
* Una base de datos en memoria en muy velox, por lo que se podr谩n corrar pruebas una y otra vez sin temor a que sean lentas.
* Patrones y recomendaciones:
  * Por cada prueba se deber谩n instanciar 2 DBContext:
    * 1 para cargar los datos si es necesario.
    * 1 que es el que inyectaremos. Es necesario ya que el anterior, al tener los datos cargados en memoria, puede ocasionar falsos positivos en las pruebas.
  * Cada prueba debe tener su propia base de datos para tener las pruebas aisladas unas de otras (la prueba "a" no afecta a la prueba "b"). No es un proceso costoso a nivel de rendimiento.
* Ejemplo:
  * Instalar en el proyecto **EFMain.Pruebas** y **EFMain** el paquete Nuget ```Microsoft.EntityFrameworkCore.InMemory```.
  * El ```DBContext``` de ```InMemory```, se inyectar谩 en la clase a probar.
  * En el proyecto **EFMain.Pruebas** se crear谩 la clase ```BasePruebas```.
  * La clase ```BasePruebas```, tendr谩: 
    * El m茅todo ```ConstruirDbContext```.
    * Este construir谩 un contexto en memoria cada vez que se llame, mediante ```UseInMemoryDatabase```.  
  * En esta versi贸n de EF el proveedor de memoria no trabaja bien con tablas temporales:
    * Clase ```GeneroConfig``` y ```FacturaConfig```:
      * Se debe indicar el tipo de dato ```<DateTime>``` para las tablas temporales, por ejemplo:
        * ```builder.Property<DateTime>("PeriodStart").HasColumnType("datetime2");```
    * Clase ```ApplicationDbContext```:
      * Se debe evitar usar el seeding, ya que inserta datos en las tablas temporales.
      * Si se verifica a trav茅s de ```Database.IsInMemory()``` que no est谩 en memoria, realizar谩 los "seedings".

## 10.3 La primera prueba unitaria con EF Core<a name="Tema_10_Test_Primer_Test"></a>
* Ejemplo: se realizar谩 una prueba para verificar que GenerosController.Post() inserta N registros enviados.
  * Clase ```GenerosControllerPruebas```:
    * Hereda de ```BasePruebas```.
    * Revisar ```Post_SiEnvioDosGeneros_AmbosSonInsertados```.

## 10.4 Configurando AutoMapper para pruebas - Pruebas negativas<a name="Tema_10_Test_AutoMapper"></a>
* 驴Qu茅 sucede si se quiere probar un endpoint que utiliza Automapper?
* Tenemos dos opciones:
  * Utilizar un MOC de automapper.
  * Configurar Automapper desde el proyecto de pruebas, la cual puede ser mejor para poder probar tambi茅n Automapper.
* Ejemplo:
  * Clase ```BasePruebas```:
    * M茅todo ```ConfigurarAutoMapper```, que configurar谩 los profiles en base a la clase ```AutoMapperProfiles```.
  * Clase ```GenerosControllerPruebas```:
    * Revisar la prueba negativa: ```Put_SiEnvioUnGeneroConNombreOriginalIncorrecto_UnaExcepcionEsArrojada```.
    * Revisar la prueba positiva: ```Put_SiEnvioUnGeneroConNombreOriginalCorrecto_EntoncesSeActualizaElGenero```.

## 10.5 Usando LocalDb para pruebas de integraci贸n<a name="Tema_10_Test_LocalDb"></a>
* En la aplicaci贸n se ha utilizado ```NetTopologySuite``` para tener funcionalidad espacial.
* Si queremos probar el correcto funcionamiento de queries espaciales, en esta versi贸n de EF no funciona correctamente.
* Por lo tanto, ser谩 necesario crear una base de datos real, mediante **LocalDB**, una especia de mini SQL Server.
* Cada vez que se corra un test suite:
  * Se crear谩 la base de datos.
  * Se crear谩 una transacci贸n a la cual haremos un rollback para que no deje datos.
  * Se borrar谩 la base de datos.
* Ejemplo:
  * Se probar谩 ```CinesControllet.Get```, el cual prueba los cines m谩s cercanos a trav茅s de ```NetTopologySuite```.
  * Clase ```LocalDbInicializador```, realiza, a trav茅s de los m茅todos, estos eventos (borrar base de datos, crear, etc茅tera).
  * Clase ```CinesControllerPruebas```:
    * Revisar la prueba positiva: ```Get_MandoLatitudYLongitudDeSantoDomingo_Obtengo2CinesCercanos```.

---

# M脫DULO 11. Entity Framework y ASP Net Core <a name="Tema_11_EF_Y_ASP"></a>
**Objetivo:** caracter铆sticas especiales para ASP .Net Core.
**Principales caracter铆sticas del m贸dulo:**
1. [Migraciones](#Tema_11_Asp_Migraciones)
2. [Tiempo de Vida de los Servicios y del DBContext](#Tema_11_Asp_Vida)
3. [Instanciando el DbContext en un Singleton](#Tema_11_Asp_Singleton)
4. [Programaci贸n As铆ncrona](#Tema_11_Asp_Programa_Asincrona)
5. [Reciclando el DbContext (```AddDbContextPool```)](#Tema_11_Asp_Reciclando_DbContext)
6. [Factor铆a de DbContexts (```AddDbContextFactory```) ](#Tema_11_Asp_Factoria_DbContext)
7. [Consideraciones para Blazor Server](#Tema_11_Asp_Blazor)

## 11.0 Migraciones 鈿欙笍 <a name="Tema_11_Test_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutar谩 todas las migraciones:
  * ```Update-Database```
* Realizar谩 las siguientes migraciones:  
  * Creaci贸n de la BDD **[EFCorePeliculasDB_11_EF_Asp]**.
  * Creaci贸n del esquema con todos los ejemplos del tema.
  * Inserci贸n de datos de prueba.

### 11.0.1 驴C贸mo queda la base de datos? 馃敥
* Similar al esquema [Esquema de base de datos](#Esquema_BDD), aunque se a帽aden nuevas tablas.

## 11.1 Creando el proyecto <a name="Tema_11_Test_Creacion"></a>
* Proyectos utilizados: ver carpeta virtual de la soluci贸n **11_EF_Y_ASP**
* BDD utilizada: **[EFCorePeliculasDB_11_EF_Asp]**

## 11.2 Tiempo de Vida de los Servicios y del DBContext<a name="Tema_11_Asp_Vida"></a>
* Cuando hablamos de servicios nos referimos a interfaces o clases registradas en el sistema de inyecci贸n de dependencias.
* Nuestro ```ApplicationDbContext``` lo registramos de forma centralizada como un servicio utilizando la funci贸n ```builder.Services.AddDbContext```.
* Los servicios se diferencias por su tiempo de vida:
  * **Transient**: siempre se da una nueva instancia de un servicio.
  * **Scoped**: retorna la misma instancia de un servicio dentro del mismo contexto https.
  * **Singleton**: retorna la misma instancia de un servicio siempre. 
* El ```DbContext``` utiliza **Scoped** por defecto: 
  * Esto permite que las operaciones que haga un usuario en memoria no afecten a otros usuarios.
  * Es importante porque el DbContext no es "thread safe" (una misma instancia no debe ser utilizada en varios hilos al mismo tiempo).

## 11.3 Instanciando el DbContext en un Singleton<a name="Tema_11_Asp_Singleton"></a>
* Por defecto, el servicio de DbContext es **Scoped**.
* Sin embargo, puede que haya que utilizar un DBContext dentro de una clase registrada como Singleton. 
* Por ejemplo, si tenemos que ejecutar tareas en segundo plano, o cada x tiempo, a trav茅s de ```IHostedService```, ya que es Singleton.
* Ejemplo:
  * Clase ```ServicioSingletonFallo```: es un ejemplo de una clase registrada como Singleton, y que inyecta el DBContext. Si se ejecuta la aplicaci贸n dar谩 el siguiente error: ```System.AggregateException: 'Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: EFCorePeliculas.Servicios.ServicioSingletonFallo Lifetime: Singleton ImplementationType: EFCorePeliculas.Servicios.ServicioSingletonFallo': Cannot consume scoped service 'EFCorePeliculas.ApplicationDbContext' from singleton 'EFCorePeliculas.Servicios.ServicioSingletonFallo'.)'```
  * Clase ```ServicioSingletonCorrecto```: para poder registrarla como Singleton, se inyecta ```IServiceProvider```. A partir de este momento puedo instanciar el DBContext a trav茅s de un contexto.

## 11.4 Programaci贸n As铆ncrona<a name="Tema_11_Asp_Programa_Asincrona"></a>
* Es buena pr谩ctica utilizar programaci贸n as铆ncrona cuando se realizan operaciones I/O en ASP.NET Core.
* Al utilizar programaci贸n as铆ncrona, el hilo que realiz贸 la petici贸n es liberado y puede hacer otras tareas.
* En un ambiente web es fundamental, pues son los hilos los que responden a peticiones http.
* De esta manera, se pueden utilizar al m谩ximo los hilos disponibles para responder a peticiones http (**escalabilidad vertical**).
![My Image](11_ASP_Best_Practices.PNG)

## 11.5 Reciclando el DbContext (```AddDbContextPool```) <a name="Tema_11_Asp_Reciclando_DbContext"></a>
* Normalmente el DBContext es un objeto r谩pido de instanciar.
* En escenarios de alta demanda instanciar y eliminar el DBContext tiene su penalizaci贸n.
* Para evitarlo, se puede reciclar el DBContext y reutilizar las instancias por la aplicaci贸n.
* Limitaciones:
  * El DBContext pasa a ser un servicio Singleton.
  * No se podr谩 inyectar servicios en el constructor del ```ApplicationDbContext```.
* Ejemplo:
  * Clase ```Program```: Utilizar ```builder.Services.AddDbContextPool<ApplicationDbContext>```.

## 11.6 Factor铆a de DbContexts (```AddDbContextFactory```) <a name="Tema_11_Asp_Factoria_DbContext"></a>
* En ocasiones es posible que se quiera instanciar el DBContext manualmente y al mismo tiempo, tener la clase centralizada en ```Program.cs```.
* Para eso se utiliza ```AddDbContextFactory```, que permite registrar una factor铆a.
* Ejemplo:
  * Clase ```Program```: utilizar ```builder.Services.AddDbContextFactory<ApplicationDbContext>```.
  * Clase ```GenerosController```: 
    * Se inyecta ```IDbContextFactory<ApplicationDbContext> dbContextFactory```.
    * Revisar m茅todo ```Get()```, donde se hace referencia a la factor铆a.

## 11.7 Consideraciones para Blazor Server<a name="Tema_11_Asp_Blazor"></a>
* Blazor Server (diferente a Blazor Web Assembly) es un sistema con estado, la conexi贸n cliente - servidor sigue viva mientras el usuario use la aplicaci贸n.
* Se podr铆a dar el caso de tener varios usuarios utilizando el mismo DBContext, lo que puede provocar errores inesperados.
* La recomendaci贸n de Microsoft es utilizar una instancia de DBContext por operaci贸n. Conviene utilizar la factor铆a ```AddDbContextFactory```. 