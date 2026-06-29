# EventPlanner.Web

## 1. Descripción del proyecto

EventPlanner.Web es una aplicación web desarrollada en ASP.NET MVC para la gestión de eventos. El sistema permite administrar eventos, equipos, usuarios e inscripciones mediante una interfaz web, incorporando control de acceso por roles y generación de reportes.

Además, integra un asistente virtual para responder consultas relacionadas con el funcionamiento del sistema y los procesos de gestión de eventos.

---

## 2. Tecnologías

- **Lenguaje:** C#
- **Framework:** ASP.NET MVC 5 (.NET Framework 4.8)
- **Frontend:**
  - HTML5
  - CSS3
  - Bootstrap 5
  - JavaScript
  - jQuery
- **Motor de vistas:** Razor
- **Base de datos:** SQL Server
- **Acceso a datos:** ADO.NET (DAO)
- **Optimización de recursos:** Microsoft ASP.NET Web Optimization
- **Serialización JSON:** Newtonsoft.Json
- **IA / Asistente virtual:** Groq API (SDK y consumo HTTP)
- **IDE recomendado:** Microsoft Visual Studio

---

## 3. Arquitectura

El proyecto implementa una **arquitectura MVC (Model-View-Controller)** con una separación clara de responsabilidades:

- **Models**
  - Representan las entidades del sistema.

- **ViewModels**
  - Modelos específicos para la comunicación entre controladores y vistas.

- **Views**
  - Interfaces desarrolladas con Razor.

- **Controllers**
  - Gestionan las solicitudes HTTP y coordinan la lógica de negocio.

- **Data**
  - Contiene las clases DAO encargadas del acceso a la base de datos.

- **Services**
  - Servicios reutilizables para funcionalidades específicas.

- **Helpers**
  - Métodos auxiliares utilizados por diferentes módulos.

Esta organización facilita el mantenimiento, la reutilización del código y la escalabilidad del proyecto.

---

## 4. Funcionalidades

El sistema incluye los siguientes módulos identificados en el código:

- Inicio de sesión de usuarios.
- Administración de usuarios.
- Gestión de eventos.
- Gestión de equipos.
- Inscripción de participantes a eventos.
- Administración de eventos por usuarios con rol **ADMIN**.
- Generación de reportes.
- Gestión de tipos de evento.
- Control de acceso mediante sesiones y roles.
- Asistente virtual integrado para consultas sobre la plataforma.
- Página principal, información y contacto.

---

## 5. Cómo ejecutarlo

### Requisitos

- Visual Studio 2022 (o compatible)
- .NET Framework 4.8
- SQL Server
- IIS Express (incluido con Visual Studio)
- Restaurar los paquetes NuGet

### Pasos

1. Clonar el repositorio.

```bash
git clone <URL_DEL_REPOSITORIO>
```

2. Abrir la solución en Visual Studio.

```text
EventPlanner.Web.csproj
```

3. Restaurar los paquetes NuGet.

4. Crear la base de datos utilizando los scripts ubicados en:

```text
02_BaseDatos/
```

5. Configurar la cadena de conexión correspondiente en el archivo de configuración de la aplicación.

6. Compilar la solución.

7. Ejecutar el proyecto utilizando IIS Express (F5).

---

## 6. Estructura del proyecto

```text
EventPlanner.Web/
│
├── 02_BaseDatos/              # Scripts SQL de creación y migración
│
├── App_Start/                 # Configuración de rutas, filtros y bundles
│
├── Controllers/               # Controladores MVC
│   ├── AdminController.cs
│   ├── ChatbotController.cs
│   ├── EquipoController.cs
│   ├── EventoController.cs
│   ├── HomeController.cs
│   ├── InscripcionController.cs
│   ├── ReporteController.cs
│   └── UsuarioController.cs
│
├── Data/                      # Acceso a datos (DAO)
│
├── Models/                    # Entidades del sistema
│
├── ViewModels/                # Modelos para las vistas
│
├── Services/                  # Servicios de negocio
│
├── Helpers/                   # Métodos auxiliares
│
├── Views/                     # Vistas Razor
│
├── Content/                   # Archivos CSS e imágenes
│
├── Scripts/                   # JavaScript y librerías
│
├── Properties/                # Configuración del proyecto
│
├── packages.config            # Dependencias NuGet
├── Global.asax                # Punto de entrada de la aplicación MVC
└── EventPlanner.Web.csproj    # Proyecto principal
```
