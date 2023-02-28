# Ejemplos de Entity Framework
Ejercicios tomados del curso de **Felipe Gavilán: Introducción a Entity Framework Core 6 - De Verdad**, y complementado con apuntes propios.

# Índice de contenidos 📋
1. [Toma de contacto](#Toma_Contacto)
2. [Introducción a Entity Framework](#Tema_01_Intro)
   1. [Configurando una aplicación de consola con EF Core y Code first](#Tema_01_Demo_Consola)       
   2. [Configurando una aplicación ASP MVC con EF Core y Code first](#Tema_01_Demo_MVC)         
2. [Modelado de base de datos](#Tema_02_Modelado_BDD)
3. [Consultando la base de datos](#Tema_03_Consultanto)
4. [Crear, modificar y borrar datos](#Tema_04_CRUD)
5. [Configurando propiedades de entidades y BDD (avanzado)](#Tema_05_Propiedades)
6. [Configurando relaciones](#Tema_06_Configurando_Relaciones)
7. [Comandos y migraciones](#Tema_07_Comandos_Y_Migraciones)
8. [El DbContext](#Tema_08_DbContext)
9. [Entity Framework avanzado](#Tema_09_EF_Avanzado)
10. [Entity Framework y pruebas automáticas](#Tema_10_Pruebas_Automaticas)
11. [Entity Framework y ASP Net Core](#Tema_11_EF_Y_ASP)

# Toma de contacto  🚀 <a name="Toma_Contacto"></a>

## Principales puntos 📋
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

## Pre-requisitos 📋
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

## Esquema de base de datos <a name="Esquema_BDD"></a>⚙️
![My Image](00_Esquema_BDD.PNG)

## Construido con 🛠️
* [Microsoft Visual Studio Profesional 2022](https://visualstudio.microsoft.com/es/vs/) - IDE  de desarrollo
* [SQL Server Management Studio](https://docs.microsoft.com/es-es/sql/?view=sql-server-ver15/) - IDE de base de datos

## Autores ✒️
* **Felipe Gavilán** - *Trabajo Inicial* - [gavilanch](https://github.com/gavilanch/Entity-Framework-Core-De-Verdad.git)
* **David Santesteban** - *Trabajos con apuntes propios* - [davidsantes](https://github.com/davidsantes)

## Agradecimientos 🎁

* Plataforma de aprendizaje online [Udemy](https://www.udemy.com/course/introduccion-a-entity-framework-core-2-1-de-verdad/)
* A cualquiera que me invite a una cerveza 🍺.

---

# MÓDULO 01. Introducción a Entity Framework <a name="Tema_01_Intro"></a>
**Objetivo:** creación y configuración de una base de datos.
**Principales características:**
* Code First: a partir de C#, se crea la BDD.
* Database First: ya existe la BDD.

## 1.1 Configurando una aplicación de consola con EF Core y Code first <a name="Tema_01_Demo_Consola"></a>

### Objetivo 🚀
* Crear migraciones para crear la Base de datos en base a una clase **[Persona]**, que a través de un DBSet, creará su correspondiente tabla en la BDD.

### Principales puntos técnicos 📋
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.SqlServer**, necesario para utilizar EF.
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.Tools**, necesario para ejecutar comandos de EF desde el Package Manager Console.
* Utilización de un DBContext: **ApplicationDbContext.cs**.
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion]**

### Comenzando 🚀

* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion]**

### Migraciones ⚙️
* ```Add-Migration 01_Inicial```: Código necesario para la migración con la entidad **[Personas]**
* ```Update-Database```: ejecución de la migración y creación de la BDD **[EFCorePeliculasDB_01Introduccion]**.

### ¿Cómo queda la base de datos? 🔩
![My Image](01_Intro_Consola_Esquema_BDD.PNG)
---

## 1.2 Configurando una aplicación ASP MVC con EF Core y Code first <a name="Tema_01_Demo_MVC"></a>
Toma de contacto con EF y una aplicación ASP MVC.

### Objetivo 🚀
* Crear migraciones para crear la Base de datos en base a una clase **[Persona]**, que a través de un DBSet, creará su correspondiente tabla en la BDD.

### Principales puntos técnicos 📋
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.SqlServer**, necesario para utilizar EF.
* Instalar el paquete Nuget **Microsoft.EntityFrameworkCore.Tools**, necesario para ejecutar comandos de EF desde el Package Manager Console.
* Utilización de un DBContext: **ApplicationDbContext.cs**.
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion_MVC]**

### Comenzando 🚀
* Omitir los warnings que aparecen debido al error [CS8618 - Non-nullable variable must contain a non-null value when exiting constructor. Consider declaring it as nullable](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings). Pondremos la propiedad del proyecto ```<Nullable>disable</Nullable>```
* Usar **appsettings.Development.json** para almacenar el connectionstring DbContextOptions
* Base de datos utilizada: **[EFCorePeliculasDB_01Introduccion_MVC]**

### Migraciones ⚙️
* ```Add-Migration 01_Inicial```: Código necesario para la migración con la entidad **[Personas]**
* ```Update-Database```: ejecución de la migración y creación de la BDD **[EFCorePeliculasDB_01Introduccion]**.

### ¿Cómo queda la base de datos? 🔩
![My Image](01_Intro_Consola_Esquema_BDD.PNG)
---

# MÓDULO 02. Modelado de base de datos <a name="Tema_02_Modelado_BDD"></a>
**Objetivo:** creación y configuración de una base de datos a través de Code First y migraciones. Exceptuando las migraciones, el resto vale para Database first).
**Principales características:**
* Creación de la BDD de la que se basará el resto de ejemplos a través de entidades cine, película, actor, etc, de c# (code first).
* Creación de llaves primarias, tanto por convención como por configuración.
* Campos de texto: longitud máxima de los campos, que no sean nulos y tipo de dato de la columna.
* Campos espaciales (longitud, latitud): utilización de la librería [**NetApologySuite**](https://github.com/NetTopologySuite/NetTopologySuite).
* Campos Unicode para reducir el tamaño de dicho campo y que no acepte caracteres extraños en una URL (```varchar``` vs ```nvarchar```).
* Configuración de relaciones 1 a 1, 1 a N, N a N.
* Configuración de relaciones N a N de manera automática (renunciando al control de la clase intermedia) o manual (debemos configurar completamente la tabla intermedia, aunque es recomendable).
* Hacer configuraciones por convenciones automáticas de EF:
  * Por atributo en la entidad (```Key, StringLength, MaxLength, Required, etc```)
  * Por Fluent API del ```DBContext``` (método ```OnModelCreating```).
  * Configurando convenciones reutilizables: por ejemplo, si queremos que un ```DateTime``` de c# se mapee siempre a ```date``` de SQL.
* Utilización de **IEntityTypeConfiguration** para separar en clases las configuraciones de Fluent API.
---

## 2.0 Migraciones ⚙️ <a name="Tema_02_Modelado_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutará todas las migraciones:
  * ```Update-Database```
* Realizará las siguientes migraciones:  
  * Creación de la BDD **[EFCorePeliculasDB_02_Modelado_BDD]**.

### 2.0.1 ¿Cómo queda la base de datos? <a name="Tema_02_Modelado_Esquema"></a> 🔩
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)

## 2.1 Creando el proyecto <a name="Tema_02_Modelado_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la solución **02_Modelado_Bdd**
* BDD utilizada: **[EFCorePeliculasDB_02_Modelado_BDD]**

## 2.2 Llaves primarias <a name="Tema_02_Modelado_Llaves_Primarias"></a>
* **Con convención de EF**: si un campo se llama "Id" o "NombreTablaId" automáticamente se configura como una llave primaria
* **Sin convención de EF**: para determinar que un campo [identificador] es una llave primaria, se puede hacer con atributos ```[Key]``` o mediante Fluent API del ```ApplicationDbContext``` (método ```OnModelCreating```)

## 2.3 Longitud máxima de campos <a name="Tema_02_Modelado_Longitud_Campos"></a>
* Longitud máxima:
  * **StringLength y MaxLength**: revisar la clase Genero.cs.
  * **A través de Fluent API**: revisar ```ApplicationDbContext``` (método ```OnModelCreating```)
* Campos no nulos:
  * **Required**: revisar la clase Genero.cs.
  * **A través de Fluent API**: revisar ```ApplicationDbContext``` (método ```OnModelCreating```) 

## 2.4 Cambiando nombres y esquema de tablas y columnas <a name="Tema_02_Modelado_Nombres_Esquema"></a>
* Si no quiero que la tabla o columnas, utilicen el mismo nombre que la entidad, o si quiero añadir (opcionalmente), el esquema:
  * **Tablas**: revisar código comentado en Genero.cs ```[Table("TablaGeneros", Schema = "peliculas")]```.
  * **Columnas**:  revisar código comentado en Genero.cs ```[Column("NombreGenero")]```.
  * **A través de Fluent API**: revisar ```ApplicationDbContext``` (método ```OnModelCreating```) y ```GeneroConfig.cs```. El código está comentado.

## 2.5 Creando la entidad Actor: Mapeo de DateTime a Date <a name="Tema_02_Modelado_MapeoDateTimeDate"></a>
* Campo Actor.cs **FechaNacimiento**, de tipo fecha:
  * Por defecto, un campo ```DateTime``` se va a mapear en BDD con un tipo ```datetime2``` (con hora, minutos...) y no va a ser null.
  * Mapear a tipo ```Date``` en vez de ```datetime2```:
    * Modo 1: Poner en el campo el atributo [Column(TypeName = "Date")]
    * Modo 2: A través de Fluent API, revisar ```ApplicationDbContext``` (método ```OnModelCreating```) y ```ActorConfig.cs```. El código está comentado.
  * Mapear a nullable: ```DateTime? FechaNacimiento```.

## 2.6 Otras propiedades interesantes <a name="Tema_02_Modelado_OtrasPropiedades"></a>
* **Uso de Enums**: campo de tipo enum, en SalaDeCine.cs, de tipo ```TipoSalaDeCine``` (enum).
  * Creará un campo de tipo numérico.
* **Valores por defecto**:
  * Para configurar valores por defecto, utilizaremos en la configuración **HasDefaultValue** (un valor por defecto de C#) o **HasDefaultValueSql** (para utilizar funciones de sql como ```getdate()```).

## 2.7 Creando entidades <a name="Tema_02_Modelado_CreandoEntidades"></a>
* Clase ```Cine```, características destacables:
  * Ubicación geográfica, que se guardará en BDD en un campo de tipo ```geography```. Para ello, se utilizará la librería [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite) y el tipo ```Point```.
  * Para usar [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite) en el program.cs, cuando se crea ```builder.Services.AddDbContext```, hay que informarlo.
* Clase ```SalaDeCine```, características destacables:
  * La propiedad **Precio** es decimal. Por defecto creará en la base de datos un ```decimal(18,2)```. Para limitar las precisiones a 9 y 2 comas flotantes, y que ocupe casi la mitad de bytes:
    * Modo 1: Revisar SalaDeCine.cs ```[Precision(precision: 9, scale: 2)]```
    * Modo 2: A través de Fluent API (revisar la clase ```SalaDeCineConfig.cs```)
* Clase ```Pelicula```, características destacables:
  * La propiedad **Url** solo aceptará **Unicode** (```varchar```), por lo que no aceptará caracteres extraños (```nvarchar```). Para hacerlo:
    * Modo 1: Revisar Pelicula.cs ```[Unicode(false)]```
    * Modo 2: A través de Fluent API (revisar la clase ```PeliculaConfig.cs```)   

## 2.8 Creando relaciones <a name="Tema_02_Modelado_CreandoRelaciones"></a> 
* **Relación 1 a 1**:
  * Oferta de un cine:
    * 1 Cine tiene 1 oferta.
    * Para enlazar:
      * Clase ```Cine```: tendrá como propiedad a ```CineOferta```.
      * Clase ```CineOferta```: tendrá como propiedad el cine ```CineId```, indicando que es una clave foránea.     
* **Relación 1 a N**:
  * Cine con sus salas de cine (2D, 3D, etc):
    * 1 Cine tiene N salas con precios diferentes.
    * Para enlazar:
      * Clase ```Cine```: 
        * Tendrá una lista de ```SalaDeCine```. En este caso, es ```HashSet``` (no ordena aunque es más rápido). Si se quiere, podría ser ```ICollection```, ```List```, etc.
      * Clase ```SalaDeCine```: 
        * Tendrá como propiedad de navegación a la clase ```Cine```.
        * Tendrá como propiedad el cine ```CineId```, indicando que es una clave foránea.     
* **Relación N a N**:
  * 1 película puede tener N géneros, y 1 género puede tener N películas.
  * 1 película puede emitirse en N salas de cine, y 1 sala de cine puede emitir N películas.
  * 1 actor puede participar en N películas, y 1 película pueden participar N actores.
  * Para enlazar, modos de generación:
    * **De manera automática (No recomendado)**: se renuncia al control directo de la tabla intermedia, ya que no existe entidad que lo maneje.
      * Clase ```Pelicula``` una lista de ```Generos```. Se ha puesto como HashSet.
      * Clase ```Genero``` una lista de ```Peliculas```. Se ha puesto como HashSet.
      * Clase ```Pelicula``` una lista de ```SalaDeCine```. Se ha puesto como HashSet.
      * Clase ```SalaDeCine``` una lista de ```Peliculas```. Se ha puesto como HashSet.      
    * **De manera manual (Sí recomendado)**: si se quiere introducir información extra en la tabla intermedia que relacione película y actores, como el nombre del personaje y el nombre de los actores, o en qué orden se mostrarán los actores en una película.
      * Clase ```PeliculaActor``` es la entidad intermedia, donde estarán: 
        * Las propiedades de unión ```PeliculaId``` y ```ActorId```.
        * Las propiedades de navegación ```Pelicula``` y ```Actor```.
      * Clase ```Pelicula```, una lista de ```PeliculaActor```.
      * Clase ```Actor```, una lista de ```PeliculaActor```.
      * Se deberá configurar la llave primaria compuesta:
        * Mediante Fluent API: ```builder.HasKey(prop => new { prop.PeliculaId, prop.ActorId });```

## 2.9 Configurando convenciones reutilizables <a name="Tema_02_Modelado_ConfigurandoConvenciones"></a> 
* Por ejemplo, EF mapea un string a un nvarchar(max). Esto no quiere decir que no se pueda tener dicho caso, sino que no va a ser el comportamiento por defecto.
* De esta manera se puede ahorrar mucho código repetido.
* Existe un ejemplo en ```ApplicationDbContext```, método ```ConfigureConventions```, para que los métodos ```DateTime``` sean mapeados a ```Date```.
* Si se quiere que algún método ```DateTime``` se convierta a otro tipo, habrá que hacerlo explícitamente. Existe un ejemplo comentado en ```ActorConfig```.

## 2.10 Organizando OnModelCreating para organizar el código <a name="Tema_02_Modelado_OrganizandoOnModelCreating"></a> 
* Se pueden crear clases más pequeñas para organizar el Fluent API. Revisar ```OnModelCreating```.
* Se podrán registrar las clases 1 a 1 o todo el ensamblado a la vez.

---

# MÓDULO 03. Consultando datos <a name="Tema_03_Consultanto"></a>
**Objetivo:** creación de métodos de consulta.
**Principales características:**.
* Inserción de datos con Data Seeding.
* Queries más rápidas con ```AsNoTracking```.
* Obtener el primer registro con ```First``` y ```FirstOrDefault```.
* Filtros con ```Where```.
* Ordenación con ```OrderBy``` y ```OrderByDescending```.
* Paginando con ```Skip``` y ```Take```.
* Seleccionar columnas con ```Select``` o con Automapper.
* Consulta de datos Espaciales (longitud, latitud).
* Automapper: ```ProjectTo```.
* Agrupar con ```GroupBy```. 
* Eager Loading - ```Include``` y ```ThenInclude```: cargando datos relacionados.
* Select Loading - Cargado selectivo.
* Explicit loading - Carga Explícita.
* Lazy Loading - Carga perezosa.
* Ejecución diferida (AsQueryAble): Filtros dinámicos.
---

## 3.0 Migraciones ⚙️ <a name="Tema_03_Consultanto_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutará todas las migraciones:
  * ```Update-Database```
* Realizará las siguientes migraciones:  
  * Creación de la BDD **[EFCorePeliculasDB_03_Consulta_BDD]**.
  * Creación del esquema.
  * Inserción de datos de prueba.

### 3.0.1 ¿Cómo queda la base de datos? 🔩
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 3.1 Creando el proyecto <a name="Tema_03_Consultanto_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la solución **03_Consultando_Datos**
* BDD utilizada: **[EFCorePeliculasDB_03_Consulta_BDD]**

## 3.2 Inserción de datos con Data Seeding <a name="Tema_03_Consultanto_DataSeeding"></a> 
* Se puede realizar una carga de datos inicial a través del Data Seeding.
* Revisar el método ```OnModelCreating``` de la clase ```ApplicationDbContext```.
* Se llama a la clase ```SeedingModuloConsulta```, donde se insertan los datos de la base de datos.
* Al añadir la migración ```DatosDePrueba``` añade todos esos datos.

## 3.3 Queries más rápidas con ```AsNoTracking``` <a name="Tema_03_Consultanto_AsNoTracking"></a> 
* Si no se tiene interés en manejar el estado de una entidad (updated, etc), se puede utilizar ```AsNoTracking```.
* Se utiliza para cuando el fin es lectura pero no actualización de los datos.
* **Ventaja:** son más rápidos que los queries normales.
* Se puede hacer la configuración de AsNoTracking:
  * De manera individual: revisar ```GenerosController```, código comentado en método ```Get()```.
  * De manera global: 
    * Revisar ```program```, código ```UseQueryTrackingBehavior``` a la hora de configurar el DbContext.
    * Si se quiere activar el seguimiento de un método, se puede utilizar ```.AsTracking()```. revisar ```GenerosController```, código comentado en método ```Get()```.

## 3.4 Obtener el primer registro con ```First``` y ```FirstOrDefault``` <a name="Tema_03_Consultanto_First"></a> 
* Revisar ```GenerosController```, código en método ```GetPrimerGeneroConNombreEmpiezaConLetraC()```.

## 3.5 Obtener elementos filtrados con ```Where```<a name="Tema_03_Consultanto_Where"></a> 
* Revisar ```GenerosController```, código en método ```GetFiltroPorNombre()```.
* Se puede filtrar por más de un elemento, por ejemplo, que empiece por una letra y otra. Revisar ```GenerosController```, código comentado en método ```GetFiltroPorNombre()```.

## 3.6 Ordenación con ```OrderBy``` y ```OrderByDescending```<a name="Tema_03_Consultanto_Order"></a> 
* Revisar ```GenerosController```, código en método ```Get()```.

## 3.7 Paginando con ```Skip``` y ```Take```<a name="Tema_03_Consultanto_Paginacion"></a> 
* Para no traer todos los registros de la base de datos.
* Para ello, se utiliza Take y Skip.
* Revisar ```GenerosController```, código en método ```GetPaginacion()```.

## 3.8 Seleccionar columnas con ```Select```<a name="Tema_03_Consultanto_Select"></a> 
* Para no traer todos los campos de una entidad.
* Revisar ```AutoresController```, código en método ```GetConSelectAnonimo()``` y ```GetConSelectADto```.
* Esto genera una SQL (se puede ver en la consola.exe de VS) que retorna solo los datos solicitados.

## 3.9 Seleccionar columnas con ```Select``` o con Automapper<a name="Tema_03_Consultanto_Select"></a> 
* Para no traer todos los campos de una entidad.
* Revisar ```AutoresController```, código en método ```GetConSelectAnonimo()``` y ```GetConSelectADto```.
* Esto genera una SQL (se puede ver en la consola.exe de VS) que retorna solo los datos solicitados.
* También se puede ahorrar el Select utilizando Automapper. 
  * Revisar ```AutoresController```, código en método ```GetAutomapper()```. Revi
  * Revisar la clase ```AutoMapperProfiles```.

## 3.10 Consulta de datos Espaciales - Point (longitud, latitud)<a name="Tema_03_Consultanto_Point"></a> 
* Para datos complejos como latitud / longitud, se puede utilizar **NetTopologySuite**. Se puede filtrar, o indicar los cines o puntos más cercanos.
* Revisar:
  * ```CinesController```, código en método ```GetCinesCercanosConNetTopologySuite()```.
  * Revisar la clase ```AutoMapperProfiles```, donde se hacen transformaciones de longitud y latitud.

## 3.11 Agrupar con ```GroupBy```<a name="Tema_03_Consultanto_GroupBy"></a> 
* Revisar ```PeliculasController```, código en método ```GetAgrupadasPorCantidadDeGeneros()```.

## 3.12 Eager Loading - ```Include``` y ```ThenInclude```: cargando datos relacionados <a name="Tema_03_Consultanto_Eager"></a> 
* **Eager loading:** en la query se indica explícitamente los datos a cargar. Hay que utilizar include para los hijos a retornar.
* Revisar en **PeliculasController**, método ```GetEagerLoading```:
  * **Include**: permite cargar el hijo.
  * **ThenInclude**: permite entrar en el hijo del hijo del hijo. Por ejemplo, en una película, que cargue la tabla intermedia peliculas actores, y a su vez los actores. 
  * **IgnoreCycles**: para evitar redundancia cíclica (una clase película tiene actores, pero los actores tienen películas), se utiliza IgnoreCycles en program.cs  
  * También se ordenan los hijos y se filtran por valores específicos (por ejemplo, que la fecha de nacimiento de los actores sea >= 1980)

## 3.13 Select Loading - Cargado selectivo <a name="Tema_03_Consultanto_Select"></a> 
* **Select loading:** para devolver clases anónimas con solo los datos que me interesan.
  * Por ejemplo, nombre película y número de cines que la emiten. 
  * Es una opción a tener en cuenta para queries complicadas.
* En anteriores ejemplos se ha hecho un select simple, pero se pueden cargar entidades relacionadas.
* Revisar en **PeliculasController**, método ```GetSelectLoading```:
  * Además de devolver una clase anónima, devuelve datos interesantes como el número de coincidencias total.

## 3.14 Explicit loading - Carga explícita <a name="Tema_03_Consultanto_Explicit"></a> 
* **Explicit loading:** útil para hacer filtros en los hijos del padre, u operaciones secundarias con los hijos.
  * Se carga en diferentes líneas de código.
  * Es necesario utilizar AsTracking().
  * No es tan eficiente como hacer 1 query, ya que obliga a volver a cargar la entidad principal. 
  * Es más recomendado hacer eager o select loading.
* Revisar en **PeliculasController**, método ```GetExplicitLoading```.

## 3.15 Lazy loading - Carga perezosa <a name="Tema_03_Consultanto_Lazy"></a> 
* **Lazy loading:** (no recomendado y no existe método de ejemplo en el código):
  * Si alguien intenta acceder a datos de hijos, los intentará cargar. Si los datos hijos no han sido cargados, los carga de las bdd. Si ya está cargado en memoria, utiliza esa. Un ejemplo algo oculto es Automapper, que intentará analizar todas las propiedades.
  * Ineficiente. Hay que hacer varias queries separadas. También nos exponemos a peligros como el problema N+1, una query por cada entidad (por ejemplo, si hay foreach).
  * Se recomienda utilizar antes, eager loading, select loading, y en último caso caso, explicit loading.
  * Hay que instalar **Microsoft.EntityFrameworkCore.Proxies**.
  * Hay que configurar el dbContext para usar ```UseLazyLoadingProxies```, normalmente en el ```program.cs```.
  * Todas las entidades del modelo hijas, deben ser virtual (virtual HashSet, virtual CineOferta, virtual List, etc)
  * Las consultas utilizan ```AsTracking()```

## 3.16 Ejecución diferida (AsQueryAble): Filtros dinámicos <a name="Tema_03_Consultanto_Diferida"></a> 
* Se utiliza para componer la query en función de si se pasan los parámetros o no.
* Se debe utilizar ```AsQueryAble()```, el cual nos permite ir construyendo la query.
* Revisar en **PeliculasController**, método ```GetFiltrarDinamicoEjecucionDiferida```. 

---

# MÓDULO 04. Crear, modificar y borrar datos <a name="Tema_04_CRUD"></a>
**Objetivo:** manejo de datos, creación, modificación y eliminación de los datos.
**Principales características:**
* Modelo conectado y modelo desconectado - estatus.
* Insertar registros de manera individual.
* Insertar registros de manera múltiple.
* Insertar registros con datos relacionados inexistentes.
* Insertar registros con datos relacionados inexistentes a través de un DTO (recomendado).
* Insertar registros con datos relacionados existentes.
* Mapeo flexible de campos en vez de propiedades (HasField).
* Actualizando registros - modelo conectado.
* Actualizando registros - modelo desconectado.
* Borrado normal o físico.
* Borrado suave o lógico.
* Filtros al nivel del modelo (añadir e ignorar).
---

## 4.0 Migraciones ⚙️ <a name="Tema_04_Crud_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutará todas las migraciones:
  * ```Update-Database```
* Realizará las siguientes migraciones:  
  * Creación de la BDD **[EFCorePeliculasDB_04_CRUD_BDD]**.
  * Creación del esquema.
  * Inserción de datos de prueba.

### 4.0.1 ¿Cómo queda la base de datos? 🔩
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 4.1 Creando el proyecto <a name="Tema_04_Crud_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la solución **04_Crear_Actualizar_Borrar**
* BDD utilizada: **[EFCorePeliculasDB_04_CRUD_BDD]**

## 4.2 Modelo Conectado y Modelo Desconectado - Estatus <a name="Tema_04_Crud_Modelo"></a> 
* **Modo desconectado**:
	* Utilizado en el típico escenario web, donde el usuario rellena un formulario y esos datos se utilizan para crear un dato. 
	* El modelo no es el responsable de pasar una nueva entidad. 
	* El DbContext puede ser diferente para una consulta, que para una inserción.
* **Modo conectado**:
	* AsTracking, misma instancia del DbContext tanto para consultar los datos como para editarlos. 
	* Manera más simple para trabajar.
	* Sin embargo, esta manera de trabajar no siempre es realista, ya que puede ser el cliente quien nos pase el dato para insertar, modificar, etc.
* **Status de la entidad**: para poder hacer el seguimiento en el equ se encuentra una entidad:
	* **Added** (agregado): una entidad debe ser creada en la BDD.
	* **Modified** (modificado): la entidad representa un registro existente en la BDD que debe actualizarse.
	* **Unchanged** (sin modificar): la entidad representa un registro existente en la BDD que no tiene cambios.
	* **Deleted** (borrado): la entidad representa un registro existente en la BDD que debe borrarse.
	* **Detached** (sin seguimiento): cuando una entidad no está recibiendo ningún seguimiento por EF.
* **context.Entry(entidad).State** para conocer el estado de una entidad.
* **SaveChanges** del DbContext es el método que guarda los cambios.

## 4.3 Insertar registros de manera individual <a name="Tema_04_Crud_Insertar_Individual"></a> 
* Revisar en **GenerosController**, método ```InsertarIndividual```.
* Para probar con Swagger:
```
    {
	    "nombre":"Biografia"
    }
```

## 4.4 Insertar registros de manera múltiple <a name="Tema_04_Crud_Insertar_Multiple"></a> 
* Revisar en **GenerosController**, método ```InsertarMultiple```.
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
* Revisar en **CinesController**, método ```InsertarDatosRelacionados```.

## 4.6 Insertar registros con datos relacionados inexistentes a través de un DTO (recomendado) <a name="Tema_04_Crud_Insertar_Relacionado_Dto"></a> 
* Revisar en **CinesController**, método ```InsertarDatosRelacionadosConDTO```.
* Recomendable ya que indico qué datos debo pasar, además de que se pueden poner comprobaciones de valores (Required, etc) en el DTO para que sean datos correctos.
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
* Si queremos insertar una película con sus géneros, sin embargo, los géneros ya existen en la tabla de géneros.
* Se necesita reutilizar géneros ya existentes.
* Revisar en **PeliculasController**, método ```InsertarDatosRelacionados```.
* Se trabaja con el State, indicando que los géneros y salas de cine de la película, se tratarán como consulta (sin modificar), y que sólo sirve para relacionarlos con la entidad pelicula. Esto se realiza con el estado ```EntityState.Unchanged```.
* Para probar con Swagger:
```
{
  "titulo": "mi película",
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
* Por ejemplo, que a la hora de insertar un actor, su primera letra del nombre y del apellido estén en mayúscula.
* Revisar: 
  * **Actor.cs**, propiedad ```Nombre```.
  * **ActoresController**, método ```InsertarConMapeoFlexibleDeCampo```.
  * **ActorConfig.cs**, se indica que la propiedad ```Nombre``` tiene un campo privado asociado, a través de ```.HasField("_nombre")```.
* Para probar con Swagger:
```
{
  "nombre": "jUaN valdEZ",
  "biografia": "Biografía...",
  "fechaNacimiento": "2023-02-21T17:31:09.905Z"
}
```

## 4.9 Actualizando registros - modelo conectado <a name="Tema_04_Crud_Modelo_Conectado"></a> 
* La entidad a actualizar va a ser cargada por el mismo DbContext. Ambas operaciones serán realizadas por la misma instancia del DbContext.
* La forma de realizarlo debe ser ```AsTracking()```, ya que es conectado.
* Revisar:  
  * **ActorController**, método ```ModificarConectado```. Modificar un actor existente.
  * **GenerosController**, método ```ModificarConectadoAgregar2```. Agregar un 2 al final de un nombre de un género. Es un ejemplo muy simple.

## 4.10 Actualizando registros - modelo desconectado <a name="Tema_04_Crud_Modelo_Desconectado"></a> 
* La entidad a actualizar va a ser cargada en diferentes DbContext, uno para buscar la entidad a modificar, y otro para modificarla).
* **Modelo conectado vs desconectado:** en el caso del modelo desconectado, actualiza todas las propiedades de la entidad, mientras que el conectado actualiza solo las modificadas, por lo que el primero es menos eficiente.
* La forma de realizarlo es mediante ```context.Update()```.
* Revisar:  
  * **ActorController**, método ```ModificarDesconectado```. Modificar un actor existente.

## 4.11 Borrado normal o físico <a name="Tema_04_Crud_Borrado_Normal"></a> 
* Se utiliza para eliminar el registro de la tabla.
* Se debe cambiar el estatus de la entidad a ```deleted``` antes de hacer un ```SaveChanges()```.
* La forma de realizarlo es mediante ```context.Remove()```.
* Revisar:  
  * **GenerosController**, método ```BorradoNormalFisico```.

## 4.12 Borrado suave o lógico <a name="Tema_04_Crud_Borrado_Suave"></a> 
* Se utiliza si no se quiere remover el registro de la tabla. Realmente es una actualización de un registro con un campo flag ```EstaBorrado```.
* La manera más sencilla es realizar una actualización con el modelo conectado y ```AsTracking()```.
* Revisar:  
  * **GenerosController**, método ```BorradoSuaveLogico```.

## 4.13 Filtros al nivel del modelo (añadir e ignorar) <a name="Tema_04_Crud_Filtro"></a> 
* En ocasiones va a haber filtros que queramos aplicar en todas las consultas que se hagan a la base de datos.
* Por ejemplo, si queremos retornar solo los géneros que estén activos.
* Si se genera un filtro, siempre se aplicará sobre la entidad.
* Revisar:  
  * **GeneroConfig**, método ```HasQueryFilter```.
  * Si se ejecuta en Swagger cualquier Get de géneros, o se revisa la sentencia SQL que lanza, se puede comprobar que no devolverá los géneros que tengan un borrado lógico.
* En el caso de que necesitemos acceder a los borrados lógicos, es posible saltarse el filtro mediante ```IgnoreQueryFilters```:
  * Por ejemplo:
    * Si queremos restaurar un género previamente borrado, y lo tenemos que retornar.
    * Si queremos mostrar a un administrador todos los géneros, incluidos los borrados.
  * Revisar **GenerosController**, método ```RestaurarGeneroBorrado```.
---

# MÓDULO 05. Configurando propiedades de entidades y BDD (avanzado) <a name="Tema_05_Propiedades"></a>
**Objetivo:** ahondar más en el manejo de las propiedades.
**Principales características:**
* Modos de configuración.
* Llaves primarias.
* Ignorando propiedades y clases para no trasladarlas a BDD.
* Índices e índices con filtros (índice parcial).
* HasConversion, conversiones de datos especiales (EF - BDD - EF) - Introducción.
* HasConversion, conversiones de datos especiales (EF - BDD - EF) - Personalizado.
* Keyless (entidades sin Llave), ejecución de sentencias SQL (**ToSqlQuery**).
* Keyless (entidades sin Llave), ejecución de vistas de SQL (**ToView**).
* Shadow properties, propiedades Sombra, cómo manejar datos que no están en entidades.
* Configuración masiva de propiedades mediante automaticación de Fluent API.

## 5.0 Migraciones ⚙️ <a name="Tema_05_Propiedades_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutará todas las migraciones:
  * ```Update-Database```
* Realizará las siguientes migraciones:  
  * Creación de la BDD **[EFCorePeliculasDB_05_Propiedades]**.
  * Creación del esquema con todos los ejemplos del tema.
  * Inserción de datos de prueba.

### 5.0.1 ¿Cómo queda la base de datos? 🔩
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 5.1 Creando el proyecto <a name="Tema_05_Propiedades_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la solución **05_Configurando_Propiedades**
* BDD utilizada: **[EFCorePeliculasDB_05_Propiedades]**

## 5.2 Modos de configuración <a name="Tema_05_Propiedades_Modos"></a>
* Existen 3 maneras de realizar configuraciones en EF Core para los campos:
  * **Por convención**: funciona en base a los estilos de código y nombres utilizados en las entidades. 
    * Por ejemplo, una propiedad ```Id``` será considerada una llave primaria.
  * **Por anotaciones de datos**:
    * Atributos colocados sobre las propiedades de las entidades:
    * Por ejemplo, ```Key``` será considerada una llave primaria.
  * **Por Fluent API**:
    * Configurado en el método ```OnModelCreating``` de la clase ```DBContext```. Es la manera más potente de realizar configuraciones.
    * Por ejemplo, ```HasMaxLength``` o ```IsRequired```.

## 5.3 Llaves primarias <a name="Tema_05_PropiedadesLlaves_primarias"></a>
* Se pueden definir llaves primarias con **Integer**.
* Se pueden definir llaves primarias con un **GUID (Global Unique Identifier)**
  * Revisar **LogsController**, método ```Get```.
  * Se puede indicar que en el campo no introduzca ningún valor de forma automática mediante:
    * Modo 1: a través del atributo ```[DatabaseGenerated(DatabaseGeneratedOption.None)]```. Revisar ```Logs.cs```.
    * Modo 2: a través del fluent API ```modelBuilder.Entity<Log>().Property(l => l.Id).ValueGeneratedNever()```. Revisar ```ApplicationDbContext.cs```.* 
    * En este caso, se deberá generar de manera manual, aunque no es recomendable.

## 5.4 Ignorando propiedades y clases para no trasladarlas a BDD <a name="Tema_05_Ignorando Propiedades y Clases"></a>
* Por defecto en EF, cualquier clase o propiedad se mapea en alguna columna de la tabla correspondiente.
* En alguna circunstancia, puede que este comportamiento no interese.
* Se pueden ignorar campos o clases enteras:
  * **Campos**:
    * Por ejemplo: un campo **[Edad]** para un Actor. Esta campo será claulado a partir de la fecha de nacimiento.
    * Se puede realizar mediante:
      * Modo 1: a través del atributo ```[NotMapped]```. Revisar ```Actor.cs```.
      * Modo 2: a través del fluent API ```.Ignore```. Revisar ```ActorConfig.cs```.* 
      * En este caso, se deberá generar de manera manual, aunque no es recomendable.
  * **Clases**:
    * Por ejemplo: **[Direccion]**. Se puede hacer:
    * Cuando la clase está nivel de nivel de propiedad, dentro de otra clase (**Actor** tiene **Direccion**)
      * Modo 1: a través del atributo ```[NotMapped]```. Revisar ```Actor.cs```.
      * Modo 2: a través del fluent API ```.Ignore```. Revisar ```ActorConfig.cs```.* 
    * Que ignore la clase siempre:
      * Modo 1: a través del atributo ```[NotMapped]```. Revisar ```Direccion.cs```.
      * Modo 2: a través del fluent API ```modelBuilder.Ignore<Direccion>()```. Revisar ```ApplicationDbContext.cs```.* 

## 5.5 Índices e índices con filtros (índice parcial) <a name="Tema_05_Propiedades Indices"></a>
* **Índices únicos**:
    * Podemos configurar **índices únicos** en nuestras tablas para aumentar la velocidad de ciertas consultas.
    * Recomendable cuando no es viable hacer un full scan o búsquedas completas cada vez que se haga una query.*
    * Los índices pueden configurarse como únicos, garantizando que otra fila no vaya a tener el mismo valor (por ejemplo, un campo email).*
    * Las llaves primarias son automáticamente configuradas como índices únicos.
      * Por ejemplo, si se quiere poner un índice único para la propiedad ```Nombre``` de la entidad ```Genero```:
          * Modo 1: a través del atributo ```[Index(nameof(Nombre), IsUnique = true)]```. Revisar ```Genero.cs```.
          * Modo 2: a través del fluent API ```HasIndex().... .IsUnique()```. Revisar ```GeneroConfig```. 
    * Revisar ```GenerosController```, método ```Post``` para ver cómo realizar comprobaciones.
    * Para probar con Swagger:
```
{
    "nombre": "Anime"
}
```
* **Índices con filtros (índice parcial)**:
  * Quizás interesen índices que se apliquen de manera parcial.
  * Un ejemplo puede ser un género que tiene un borrado lógico, solo queremos que aplique cuando el campo ```[EstaBorrado]=0```, es decir, que no se repitan elementos únicamente si están activos.
  * Se realizará con Fluent API:
    * Revisar en ```GeneroConfig``` el código ```.IsUnique().HasFilter("EstaBorrado = 'false'");```.
    * En BDD se generará un índice con la ssiguientes características:
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

## 5.6 HasConversion, conversiones de datos especiales (EF - BDD - EF) - Introducción <a name="Tema_05_Propiedades HasConversion"></a>
* Se pueden realizar transformaciones de datos en ambos sentidos:
  * De BDD a EF.
  * De EF a BDD.
* Un ejemplo típico es la conversión de un ```enum``` de c# a un ```nvarchar``` de BDD. Por ejemplo, de ```DosDimensiones``` al enum ```TipoSalaDeCine.DosDimensiones = 1```.
* Se puede realizar a través del fluent API ```.HasConversion<string>();```. Revisar ```SalaDeCineConfig```.* 
* Además, se puede poner un valor por defecto.
* Se puede comprobar con **Swagger** que cuando se está leyendo el valor de BDD, lo transforma a un enum:
  * Lanzar el método /api/cines/{id}

## 5.7 HasConversion, conversiones de datos especiales (EF - BDD - EF) - Personalizado <a name="Tema_05_Propiedades HasConversion_Personalizado"></a>
* Se pueden realizar conversiones personalizadas, y no solamente a string.
* Un ejemplo puede ser el campo moneda, que en EF. Por ejemplo, de ```€``` al enum ```Moneda.Euro = 3```.
* Clase ```MonedaASimboloConverter```:
  * Se deberá crear una clase que herede de ```ValueConverter```. 
  * En esta clase se configuran los dos mapeos, de EF a BDD y de BDD a EF.
* Registro de la clase:
  * La clase ```MonedaASimboloConverter``` deberá ser configurada en **Fluent API**
  * Se puede realizar a través del fluent API ```.HasConversion<MonedaASimboloConverter>();```. Revisar ```SalaDeCineConfig```.*   
* Se puede comprobar con **Swagger** que:
  * Cuando se está leyendo el valor de BDD, lo transforma a un enum: lanzar el método /api/cines/Post
  * En BDD guarda en la tabla **[SalasDeCine]** los valores correspondientes a "RD$", "$" y "€".

## 5.8 Keyless (entidades sin Llave), ejecución de sentencias SQL (**ToSqlQuery**) <a name="Tema_05_Propiedades Keyless_SQL"></a>
* Hasta este momento todas las entidades tenían una llave primaria, ya sea unitaria o compuesta. EF exige normalmente una llave primaria para trabajar.
* Se pueden configurar entidades para que trabajen sin llaves. En el pasado se llamaban **Modelos de query**.
* Algunas ventajas que tiene son:
  * Poder expresar el resultado de queries arbitrarias en términos de una clase, con un lenguaje fuertemente tipado.
  * Centralizar las queries que realizamos.
  * No tenemos que preocuparnos por temas de eficiencia del seguidos de cambios, aunque es algo que ya lo tenemos resuelto con ```AsNoTracking()```.
* Por ejemplo, supongamos que queremos realizar una sentencia SQL para traer los cines sin incluir la ubicación:
  * Aunque se puede realizar con un Select de EF lo vamos a hacer a través de una SQL.
  * Generar una entidad sin llave llamada ```CineSinUbicacion```:
    * Modo 1: a través del atributo ```[Keyless]```. Mirar la propiedad clase.
    * Modo 2: a través del fluent API ```.HasNoKey()```. Revisar ```ApplicationDbContext```. 
  * Configurar la entidad en ApplicationDbContext:
    * Con la sentencia SQL a ejecutar en ```ToSqlQuery()```: revisar ```ApplicationDbContext```.
    * ToView(null) se utiliza para que no se agregue una tabla en la BDD con un esquema de **CineSinUbicacion**.
    * Generar un DBSet de ```DbSet<CineSinUbicacion>```.
* Se puede comprobar con **Swagger** a través del método /api/cines/SinUbicacion de ```CinesController```

## 5.9 Keyless (entidades sin Llave), ejecución de vistas de SQL (**ToView**) <a name="Tema_05_Propiedades Keyless"></a>
* Además de sentencias SQL, se pueden ejecutar directamente vistas de SQL.
* La vista, se puede o bien crear en BDD o bien hacerlo a través de una migración si se realiza con Code First. 
* En el ejemplo se ha creado la migración ```VistaConteoPeliculas```, la cual genera la vista SQL ```[PeliculasConConteos]```.
* Esta vista retorna las películas, y por cada uno la cantidda de géneros, cines y actores que contiene.
 * Generar una entidad sin llave llamada ```PeliculaConConteos```:
    * Modo 1: a través del atributo ```[Keyless]```. Mirar la propiedad clase.
    * Modo 2: a través del fluent API ```.HasNoKey()```. Revisar ```ApplicationDbContext```. 
  * Configurar la entidad en el ApplicationDbContext:
    * Con la sentencia SQL a ejecutar en ```ToView()```: revisar ```ApplicationDbContext```.
    * Generar un DBSet de ```DbSet<PeliculaConConteos>```.
* Se puede comprobar con **Swagger** a través del método /api/peliculas/PeliculasConConteos de ```PeliculasController```

## 5.10 Shadow properties, propiedades Sombra, cómo manejar datos que no están en entidades. <a name="Tema_05_Propiedades Shadow"></a>
* Permiten acceder a columnas que no se encuentran presentes en las entidades de c#, pero sí en BDD. Esto es útil cuando no queremos ver expuestos datos en las entidades, y que no añada complejidad extra al modelo.
* Ejemplo: fecha de creación en género:
  * Se realiza a través del Fluent API.
  * Revisar ```GeneroConfig```. Aquí se realizará con ```HasDefaultValueSql()``` y ```HasColumnType()```.
  * Para acceder al valor de la columna desde c#:
    * Revisar ```GenerosController```, ```método Get(int id)```: ```context.Entry(genero).Property<DateTime>("FechaCreacion").CurrentValue```
  * Para ordenar por un campo sombra desde c#:
    * Revisar ```GenerosController```, ```método Get()```: ```.OrderByDescending(g => EF.Property<DateTime>(g, "FechaCreacion"))```
* Se puede comprobar con **Swagger**:
  * Inserción: generar un género a través del método /api/generos/Post de ```GenerosController```, se puede lanzar y verificar posteriormente en BDD:
```
{
  "nombre": "Tragicomedia"
}
```   
  * Lectura: lanzar método /api/generos/Get{id:int} de ```GenerosController```.

## 5.11 Configuración masiva de propiedades mediante automaticación de Fluent API <a name="Tema_05_Propiedades Configuracion"></a>
* Permiten realizar convenciones masivas en base al nombre de una propiedad.
* Por ejemplo, si queremos configurar:
  * Cualquier propiedad del tipo string y cuyo nombre contiente "URL".
  * Para que no sea Unicode (que permita caracteres especiales) y de un tamaño máximo de 500 caracteres.
* Ejemplo: 
  * Se realiza a través del Fluent API.
  * Revisar ```ApplicationDbContext```, método ```OnModelCreating```.
  * Se crea un campo en la entidad ```Actor``` llamado ```FotoURL```.
  * Se puede verificar que en BDD, en la tabla ```[Actores]``` genera una columna ```FotoURL``` de tipo ```varchar(500)```.

---

# MÓDULO 06. Configurando relaciones <a name="Tema_06_Relaciones"></a>
**Objetivo:** ahondar más en el manejo de las propiedades.
**Principales características:**
* Conceptos básicos.
* Relaciones por convención.
* Relaciones requeridas y opcionales en la llave foránea.
* Relaciones con anotaciones: llaves foráneas explícitas con [ForeignKey].
* Relaciones con anotaciones: dos propiedades de navegación a la mista entidad con [InverseProperty].
* Relación 1 a 1 con Fluent API.
* Relación 1 a N con Fluent API.
* Relación 1 a 1 con Fluent API - Con clase intermedia.
* Relación N a N con Fluent API - Sin clase intermedia (skip navigation).
* Relaciones y borrado, Fluent API y OnDelete: ¿Qué Ocurre al borrar?
* División de una tabla (Table Splitting) en más de una entidad (datos principales y secundarios).
* División de una tabla (Table Splitting) mediante entidades de propiedad (reutilización de entidades secundarias [Owned]).
* Herencia de clases - una sola tabla por jerarquía (Table per Hierarchy - TPH).
* Herencia de clases - una sola tabla por cada tipo (Table per Type - TPT).

## 6.0 Migraciones ⚙️ <a name="Tema_06_Relaciones_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutará todas las migraciones:
  * ```Update-Database```
* Realizará las siguientes migraciones:  
  * Creación de la BDD **[EFCorePeliculasDB_06_Relaciones]**.
  * Creación del esquema con todos los ejemplos del tema.
  * Inserción de datos de prueba.

### 6.0.1 ¿Cómo queda la base de datos? 🔩
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 6.1 Creando el proyecto <a name="Tema_06_Relaciones_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la solución **06_Configurando_Relaciones**
* BDD utilizada: **[EFCorePeliculasDB_06_Relaciones]**

## 6.2 Conceptos básicos <a name="Tema_06_Relaciones_Basico"></a>
* **Tipos básicos de relaciones** (ya comentado en el apartado [2.8 Creando relaciones](#Tema_02_Modelado_CreandoRelaciones):
  * **Relación 1 a 1**:
    * Oferta de un cine:
      * 1 Cine tiene 1 oferta.  
  * **Relación 1 a N**:
    * Cine con sus salas de cine (2D, 3D, etc):      
  * **Relación N a N**:
    * 1 película puede tener N géneros, y 1 género puede tener N películas.
    * 1 película puede emitirse en N salas de cine, y 1 sala de cine puede emitir N películas.
    * 1 actor puede participar en N películas, y 1 película pueden participar N actores.
* **Llave principal o primaria**:
  * Puede ser simple o compuesta.
* **Entidad principal**:
  * Es aquella entidad que contiene la llave principal.
  * Por ejemplo: en el caso de 1 ```Cine``` con N ```Salas de Cine```, la entidad principal es ```Cine```.
* **Entidad dependiente**:
  * Es aquella entidad que no contiene la llave principal como una columna propia.
  * Por ejemplo: en el caso de ```Salas de Cine```, esta no contiene un valor propio, sino que lo usa simplemente para enlazarse con 1 ```Cine``` mediante una llave foránea.
* **Llave foránea**:
  * Valor de la llave principal en la entidad dependiente.
* **Propiedad de navegación**:
  * Se refiere a una propiedad de una entidad que permite enlazar con otras entidades relacionadas, ya sea en formato 1 a 1 o 1 a N.
  * Por ejemplo: en la clase ```Cine```, las siguientes propiedades:
    * Formato 1 a N: propiedad ```HashSet<SalaDeCine> SalasDeCine {get; set;}```.
    * Formato 1 a 1: propiedad ```CineOferta CineOferta {get; set;}```.
* **Relación requerida**:
  * Es una relación en la cual la llave foránea NO es nula, por lo que la relación siempre debe existir.
  * Por ejemplo: 1 ```Salas de Cine``` siempre debe estar enlazada con 1 ```Cine```. No puede existir 1 ```Sala de Cine``` sin su ```Cine```.
* **Relación opcional**:
  * Es una relación en la cual la llave foránea PUEDE ser nula, por lo que la relación no siempre debe existir.
  * Por ejemplo: un foro de mensajes, donde queremos conservar los mensajes incluso si el usuario elimina su cuenta.
* **Administrar relaciones**: existen 3 maneras de configurar las relaciones:
  * Por convención.
  * Por anotación.
  * Por Fluent API.
 
## 6.3 Relaciones por convención <a name="Tema_06_Relaciones_Convencion"></a>
* Revisar el apartado [2.8 Creando relaciones](#Tema_02_Modelado_CreandoRelaciones)

## 6.4 Relaciones requeridas y opcionales en la llave foránea<a name="Tema_06_Relaciones_Requeridas_Opcionales"></a>
* En el caso de querer configurar llaves foráneas, pueden ser requeridas u opcionales. Un caso de querer que sea opcional, es porque el padre puede haber sido eliminado con un borrado lógico (suave):
* **Requeridas:**
  * Cualquier entidad hija será eliminada junto con la entidad padre.
  * Por ejemplo, una oferta de un cine, requiere siempre que exista un Cine.
    * Declaración de la propiedad: ```public int CineId { get; set; }```
    * A nivel de base de datos se creará como ```[CineId] [int] NOT NULL```
* **Opcionales:**
  * Cualquier entidad hija NO será eliminada junto con la entidad padre.
  * Si se quisiera que fuera opcionales, se pondría:
    * Declaración de la propiedad: ```public int? CineId { get; set; }```
    * ```public int? CineId { get; set; }```
    * En el caso de realizar un borrado:
      * En la entidad principal, debería configurarse para con la palabra clave ```Include```, para que en los hijos elimine la clave foránea.
      * Revisar ```CinesController```, método ```Delete```.
    * A nivel de base de datos se creará como ```[CineId] [int] NULL```

## 6.5 Relaciones con anotaciones de datos: llaves foráneas explícitas con [ForeignKey]<a name="Tema_06_Relaciones_Foreign"></a>
* Se puede utilizar el atributo ```[ForeignKey]``` para indicar claves foráneas.
* Puede servir si los nombres no corresponden a un estándar.
* De una propiedad de navegación, por ejemplo en ```SalaDeCine``` se puede poner: ```[ForeignKey(nameof(ElCine))]```.

## 6.6 Relaciones con anotaciones: dos propiedades de navegación a la mista entidad con [InverseProperty]<a name="Tema_06_Relaciones_InverseProperty"></a>
* Cuando tenemos dos relaciones hacia la misma entidad.
* Por ejemplo: 
  * Si queremos implementar una funcionalidad de mensajería en nuestra aplicación donde los usuarios van a poder enviarse mensajes privados entre sí.
  * Cada mensaje tendrá un emisor y un receptor, que es la misma entidad: ```Persona```.
  * Revisar:
    * Clase ```Persona```, la cual contendrá una lista de mensajes enviados y otra de mensajes recibidos.
    * Clase ```Mensaje```, la cual tendrá propiedades de navegación hacia el emisor y el receptor.
    * Para que sepa cómo realizar la unión, se utiliará ```[InverseProperty]``` para que:
      * Los mensajes enviados se correspondan con aquellos en los cuales el valor de la persona sea igual al emisor.
      * Los mensajes recibidos se correspondan con aquellos en los cuales el valor de la persona sea igual al receptor.
* Se puede comprobar con **Swagger**:
  * Get: retornar los mensajes a través del método /api/personas/Get de ```PersonasController```.

## 6.6 Relación 1 a 1 con Fluent API<a name="Tema_06_Relaciones_1_1"></a>
* Fluent API Es la herramienta más potente para realizar relaciones.
* 1 Cine tiene 1 oferta:
  * Revisar ```CineConfig```
    * ```HasOne()```: 1 Cine tiene 1 CineOferta
    * ```WithOne()```: 1 CineOferta tiene 1 Cine

## 6.7 Relación 1 a N con Fluent API<a name="Tema_06_Relaciones_1_N"></a>
* Normalmente con la configuración por convención suele ser necesario para este caso.
* 1 Cine tiene N salas de cine:
  * Revisar ```CineConfig```
    * ```HasMany()```: 1 Cine tiene N SalaDeCine
    * ```WithOne()```: 1 CineOferta tiene 1 Cine

## 6.8 Relación N a N con Fluent API con clase intermedia<a name="Tema_06_Relaciones_N_N"></a>
* El ejemplo se va a hacer con una clase intermedia personalizada.
* 1 Pelicula tiene N Actores y 1 Actor está en N Películas:
  * Revisar ```PeliculaActorConfig```
    * ```HasOne()``` y ``WithMany()``` para ambas propiedades (Actores y Peliculas)

## 6.9 Relación N a N con Fluent API sin clase intermedia (skip navigation)<a name="Tema_06_Relaciones_N_N_sin_intermedia"></a>
* Oficialmente su nombre es ```skip navigation```, porque se salta la entidad intermedia de navegación.
* 1 Pelicula tiene N Generos y 1 Genero tiene N Películas:
  * Revisar ```PeliculaConfig```
    * ```HasMany()``` y ``WithMany()```.

## 6.10 Relaciones y borrado, Fluent API y OnDelete: ¿Qué Ocurre al borrar?<a name="Tema_06_Relaciones_Borrado"></a>
* ¿Qué ocurre entre la entidad principal ```Cine``` y ```SalaDeCine()``` cuando se elimina la primera?
* OnDelete permite configurar la siguientes opciones:
  * **Cascade**: 
    * Si la entidad principal es borrada, se eliminarán las entidades dependientes.
  * **Client Cascade**: 
    * Para las bases de datos que puede que no soporten la característica de borrado en cascada.
    * El borrado en cascada se realiza desde la aplicación.
    * Requiere que al cargar la entidad principal, se carguen las entidades dependientes.
  * **No Action**: 
    * No hace nada.
    * Puede provocar errores a la hora de realizar la acción. Por ejemplo, si se intenta borrar un cine que tiene sals de cine relacionadas.
  * **Client No Action**: 
    * No hace nada, aunque la misma documentación oficial considera inusual su uso.
  * **Restrict**: 
    * La acción a realizar en la entidad principal no se va a realizar en las entidades dependientes.
    * En algunos motores de BDD como SQL y MySQL, es similar a **No Action** ya que no tienen restricciones diferidas.
    * Esta opción puede ser relevante cuando se usa para PostgreSQL.
  * **Set Null**: 
    * Coloca el valor NULL en la columna de la clave foránea.
  * **Client Set Null**: 
    * Se coloca el valor NULL en la columna de la clave foráneas desde la aplicación.
    * Requiere que al cargar la entidad principal, se carguen las entidades dependientes.
  * Ejemplo: no se podrá eliminar un cine si contiene salas de cine.
  * Revisar ```CineConfig```
    * ```.OnDelete(DeleteBehavior.Restrict)()```.    
    * Migración: ```NoPodemosBorrarCineConSalasDeCine```
    * Controller:
      * ```CineController```, métodos:
        * ```DeleteConRestrict```: primero elimina los hijos para posteriormente eliminar el padre.
        * ```DeleteSinRestrict```: debido a la configuración **Restrict**, actualmente provocará un fallo.

## 6.11 División de una tabla (Table Splitting) en más de una entidad (datos principales y secundarios)<a name="Tema_06_Relaciones_Division_Tabla"></a>
* A veces es una buena idea crear más de una entidad para dividir los datos esenciales con los que normalmente se trabaja de otros secundarios.
* La tabla realmente será 1, pero se dividirá en entidades con subconjuntos de datos.
* Por ejemplo, si la tabla **[Cines]** tiene datos secundarios como: ```Historia, Valores, Misiones, CodigoDeEtica```, los cuales normalmente no van a ser necesario.
* Para realizar el split:
  * Clase ```CineDetalle```:
    * Se creará una clase para los datos secundarios ```CineDetalle```.
    * Tendrá una propiedad de navegación ```Cine```.
    * A partir de EF6 es necesario que para utilizar Table Splitting, al menos un campo sea ```[Required]```.
  * Clase ```Cine```:
    * Tendrá una propiedad de navegación ```CineDetalle```.
  * Clase ```ApplicationDbContext```:
    * Se añade un DBSet ```DbSet<CineDetalle>```.
  * Clase ```CineConfig```:
    * Se configura la relación 1 a 1.
  * Clase ```CineDetalleConfig```:
    * Se configura para que mapee el resultado a la tabla **[Cines]**.
  * Migración: ```CineDetalleTableSplitting```.
* Se puede comprobar con **Swagger**, en ```CinesController```, mediante:
  * postCineSinDetalle
  * postCineConDetalle

## 6.12 División de una tabla mediante entidades de propiedad (reutilización de entidades secundarias [Owned])<a name="Tema_06_Relaciones_Entidad_Propiedad"></a>
* Similar a la división de una tabla (Table Splitting), la división mediante entidades de propiedad permite reutilizar entidades secundarias.
* La principales diferencias con el anterior puntos son:
  * En las entidades de propiedad, la entidad dependiente puede ser utilizada en muchas otras entidades, por ejemplo ```Direccion```.
  * Retorna de manera automática los datos de la entidad secundaria.
* Es posible que varias entidades necesiten almacenar 1 ```Direccion```, por ejemplo ```Cine``` y ```Actor```.
* En BDD, cada tabla tendrá los campos ```Calle```, ```Pais```, ```Provincia```.
* Para realizar la reutilización:
  * Clase ```Direccion```:
    * Se marcará como ```Owned``` (adueñado o propiedad de otra entidad).
    * A partir de EF6 es necesario que para utilizar Table Splitting, al menos un campo sea ```[Required]```.
  * Clase ```Cine```:
    * Tendrá una propiedad de navegación ```Direccion```.
  * Clase ```Actor```:
    * Tendrá una propiedad de navegación ```DireccionHogar``` y otra ```BillingAddress```.
  * Clase ```CineConfig```:
    * Si no se quiere que los nombre sean: ```BillingAddress_Calle```, ```BillingAddress_Pais``` y ```BillingAddress_Provincia```:
    * Configurar la salida con el método ```OwnsOne```
   * Clase ```ActorConfig```:
    * Similar configuración que ```ActorConfig```.
  * Migración: ```EjemploOwned```.
* Se puede comprobar con **Swagger**, en ```CinesController```, mediante:
  * Método ```/api/cines/{id}```: la query generada devuelve los campos de dirección: ```[t0].[Calle], [t0].[Pais], [t0].[Provincia]```.

## 6.12 Herencia de clases - una sola tabla por jerarquía (Table per Hierarchy - TPH) <a name="Tema_06_Relaciones_Herencia_TPH_"></a>
* Las entidades pueden relacionarse utilizando el mecanismo de herencia.
* Queremos manejar clases diferentes, con sus propios datos, pero que van a ir a la misma tabla.
* Por ejemplo:
  * Un sistema de alquiler de películas, en donde haya diferentes métodos de pago (paypal, tarjeta), con elementos comunes de pago.
  * Se crearán dos clases para Pagos, con sus datos comunes y específicos, pero que van a ir a la misma tabla de **[Pagos]**
  * A nivel de BDD, todos los datos se guardarán en la tabla ```[Pagos]```.
  * ![My Image](06_Relaciones_BDD_Pagos.PNG)
* Para realizar la herencia de clases:
  * Enum ```TipoPago```: para indicar si es paypal o tarjeta.
  * Clase ```Pago```: 
    * Clase abstracta, la cual va a tener propiedades comunes de todos los tipos de pago.
    * Se crea abstracta porque no queremos que nadie genere un pago de este tipo sin instanciarlo y configurarlo.
    * Contiene una propiedad ```TipoPago```, que discriminará el tipo de pago.
  * Clase ```PagoPaypal```: clase que deriva de ```Pago```.
  * Clase ```PagoTarjeta```: clase que deriva de ```Pago```.
  * Clase ```AlquilerPelicula```: gestionará un alquiler, así como el método de Pago.
  * Clase ```ApplicationDbContext```: se genera el ```DbSet<Pago> Pagos```.
  * Clase ```PagoConfig```: se configurará mediante ```HasDiscriminator```, que permite a EF indicar en la relación entre una clase derivada utilizada, y el enum correspondiente un registro (PayPal o Tarjeta).
  * Clase ```PagoPaypalConfig```
  * Clase ```PagoTarjetaConfig```
  * Migración: ```HerenciaTPH```. 
  * Clase ```PagosController```
    * Se puede filtrar que devuelva los de un tipo específico:
      * Todos los pagos: ```return await context.Pagos.ToListAsync();```
      * Pagos mediante tarjeta: ```return await context.Pagos.OfType<PagoTarjeta>().ToListAsync();```
      * Pagos mediante paypal: ```return await context.Pagos.OfType<PagoTarjeta>().ToListAsync();```

## 6.13 Herencia de clases - una sola tabla por cada tipo (Table per Type - TPT) <a name="Tema_06_Relaciones_Herencia_TPT_"></a>
* A diferencia de la Herencia de clases - TPH, se crea una tabla por cada una de las clases involucradas en la relación.
* Es útil si las clases derivadas tienen demasiados datos diferentes y por tanto una sola tabla tendría demasiadas columnas.
* Por ejemplo:
  * Una relación con una entidad abstracta de producto.
  * A nivel de BDD, los datos se guardarán en varias tablas: ```[Productos]```, ```[Merchandising]``` y ```[PeliculasAlquilables]```.
  * ![My Image](06_Relaciones_BDD_Productos.PNG)
* Para realizar la herencia de clases:
  * Clase ```Producto```: 
    * Clase abstracta, la cual va a tener propiedades comunes al resto de elementos que hereden de esta clase.
    * Se crea abstracta porque no queremos que nadie genere un producto de este tipo sin instanciarlo y configurarlo.
  * Clase ```PeliculaAlquilable```: clase que deriva de ```Producto```.
  * Clase ```Merchandising```: clase que deriva de ```Producto```.
  * Clase ```ApplicationDbContext```: 
    * En el método ```OnModelCreating``` se configura para que cada clase derivada vaya a una tabla específica.
    * Se genera el ```DbSet<Producto> Productos```.
  * Migración: ```HerenciaTPT```. 
  * Clase ```ProductosController```
    * Se puede filtrar que devuelva los de un tipo específico:
      * Todos los productos: ```return await context.Productos.ToListAsync();```
      * Productos de tipo Merchandising: ```return await context.Set<Merchandising>().ToListAsync();```
      * Productos de tipo PeliculaAlquilable: ```return await context.Set<PeliculaAlquilable>().ToListAsync();```

---

# MÓDULO 07. Comandos y migraciones <a name="Tema_07_Comandos_Y_Migraciones"></a>
**Objetivo:** ahondar más en el manejo de comandos y migraciones.
**Principales características:**
* Comando Get-Help.
* Comando Add-Migration.
* Comando Update-Database.
* Comando Remove-Migration.
* Comando Get-Migration.
* Comando Drop-Database.
* Modificando las migraciones manualmente.
* Migration bundles o empaquetado de migraciones.
* Comando Script-Migration.
* Database Migrate - Aplicando las migraciones desde C#.
* Modelos compilados.
* Base de Datos Primero (Database first) - Scaffold-DbContext.

## 7.0 Migraciones ⚙️ <a name="Tema_07_Comandos_Y_Migraciones_Migraciones"></a>
* Ejecutar la siquiente sentencia en el **Package Manager Console** (cuidado con el proyecto de inicio en la consola), la cual ejecutará todas las migraciones:
  * ```Update-Database```
* Realizará las siguientes migraciones:  
  * Creación de la BDD **[EFCorePeliculasDB_06_Relaciones]**.
  * Creación del esquema con todos los ejemplos del tema.
  * Inserción de datos de prueba.

### 7.0.1 ¿Cómo queda la base de datos? 🔩
* Similar al esquema [Esquema de base de datos](#Esquema_BDD)
 
## 7.1 Creando el proyecto <a name="Tema_07_Comandos_Y_Migraciones_Creacion"></a>
* Proyecto utilizado: ver carpeta virtual de la solución **06_Configurando_Relaciones**
* BDD utilizada: **[EFCorePeliculasDB_06_Relaciones]**

---

# MÓDULO 08. El DbContext <a name="Tema_08_DbContext"></a>
**Objetivo:** lorem ipsum.
**Principales características:**
* Lorem ipsum
* Lorem ipsum
---

# MÓDULO 09. Entity Framework avanzado <a name="Tema_09_EF_Avanzado"></a>
**Objetivo:** lorem ipsum.
**Principales características:**
* Lorem ipsum
* Lorem ipsum
---

# MÓDULO 10. Entity Framework y pruebas automáticas <a name="Tema_10_Pruebas_Automaticas"></a>
**Objetivo:** lorem ipsum.
**Principales características:**
* Lorem ipsum
* Lorem ipsum
---

# MÓDULO 11. Entity Framework y ASP Net Core <a name="Tema_11_EF_Y_ASP"></a>
**Objetivo:** lorem ipsum.
**Principales características:**
* Lorem ipsum
* Lorem ipsum