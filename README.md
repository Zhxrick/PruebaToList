## TODOLIST 


## Requisitos

- [.NET Core SDK](https://dotnet.microsoft.com/download) (versión 8.0 o superior)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) o [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-editions)
- [Visual Studio](https://visualstudio.microsoft.com/) o [Visual Studio Code](https://code.visualstudio.com/) (opcional, pero recomendado para desarrollo)

### 1. Base de Datos en SQL Server

Para esta API, la base de datos fue creada en SQL Server y consta de una tabla principal llamada `Employees` con los siguientes campos:

- `Idtarea` (Primary Key, int, Identity)
- `titulo` (nvarchar(255))
- `descripcion` (text)
- `estado` (nvarchar(5))
- `creado_en` (datetime)
- `actualizado_en` (datetime)

### 2. Procedimientos Almacenados

Se han creado los siguientes procedimientos almacenados para gestionar las operaciones en la base de datos:

### `sp_listaEmpleados`

```sql
    CREATE proc FiltrarTareasPorEstado
           @estado NVARCHAR(50) 
    AS 
    BEGIN
        SELECT
             IdTarea,
              titulo,
              descripcion,
              estado,
              creado_en,
              actualizado_en
        FROM tareas
WHERE estado = @estado
    END
  ```
## Instalación y Configuración

1. **Instalación de Paquetes:**
   - Utiliza NuGet Package Manager para instalar los siguientes paquetes:
     - `Microsoft.EntityFrameworkCore` (versión 8.0.8)
     - `Microsoft.EntityFrameworkCore.SqlServer` (versión 8.0.8)
     - `Pomelo.EntityFrameworkCore.MySql` (versión 8.0.2)

2. **Configuración de la Cadena de Conexión:**
   - Abre el archivo `appsettings.json` y agrega tu cadena de conexión a la base de datos SQL Server:

     ```json
     {
       "ConnectionStrings": {
         "ConexionSQL": "Data Source=(local)\\SQLEXPRESS;Initial Catalog=DBTodo;Trusted_Connection=True;TrustServerCertificate=True;"
       }
     }
     ```


