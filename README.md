# Simulador de Gestión de Procesos en Memoria

## Descripción

Este proyecto académico simula el comportamiento básico de un sistema operativo al administrar procesos que compiten por una cantidad limitada de memoria RAM. El simulador representa cómo el SO decide qué procesos pueden ejecutarse de forma concurrente, cuáles deben esperar en una cola y cómo se libera memoria cuando un proceso finaliza.

## Objetivo

Comprender de forma práctica conceptos fundamentales de sistemas operativos:

- Gestión de procesos
- Asignación y liberación de memoria
- Colas de espera (FIFO)
- Ejecución concurrente con recursos limitados
- Simulación de tiempo de ejecución con programación asíncrona

## Características

- Gestión dinámica de memoria RAM (1024 MB)
- Creación de procesos con PID automático e incremental
- Nombre opcional o generación automática (`Proceso_1`, `Proceso_2`, ...)
- Ejecución concurrente de múltiples procesos cuando hay memoria suficiente
- Cola de espera FIFO para procesos sin RAM disponible
- Liberación automática de memoria al finalizar un proceso
- Visualización en tiempo real del uso de RAM con barra de progreso
- Estados de procesos: Nuevo, En espera, Ejecutando, Finalizado
- Simulación en tiempo real con `async/await` y `Task`
- Interfaz gráfica organizada con Windows Forms

## Tecnologías utilizadas

```text
C#
.NET 8
Windows Forms
xUnit
Visual Studio 2022
Git
GitHub
```

## Arquitectura

El proyecto está organizado en capas simples para facilitar el mantenimiento y la evaluación académica:

```text
Models/     → Clase Proceso y estructura de datos del simulador
Services/   → GestorProcesos (lógica de memoria, cola y ejecución)
Utils/      → GeneradorPID (identificadores únicos)
Forms/      → FormPrincipal (interfaz gráfica)
Tests/      → Pruebas unitarias xUnit de la lógica del gestor
```

La interfaz no contiene la lógica del simulador; delega las operaciones al servicio `GestorProcesos`.

## Instalación

```bash
git clone URL_DEL_REPOSITORIO
cd SimuladorGestionProcesos
```

Luego:

1. Abrir **Visual Studio 2022**
2. Abrir `SimuladorGestionProcesos.sln`
3. Restaurar dependencias si Visual Studio lo solicita
4. Compilar el proyecto (`Ctrl + Shift + B`)
5. Ejecutar con **F5**

También puede compilarse desde terminal:

```bash
dotnet build SimuladorGestionProcesos.sln
dotnet run --project SimuladorGestionProcesos/SimuladorGestionProcesos.csproj
dotnet test SimuladorGestionProcesos.sln
```

## Pruebas unitarias

El proyecto `SimuladorGestionProcesos.Tests` contiene pruebas xUnit para la lógica de `GestorProcesos` (memoria, cola de espera, validaciones y admisión de procesos).

Para ejecutarlas:

```bash
dotnet test SimuladorGestionProcesos.sln
```

Para ver detalle de cada prueba:

```bash
dotnet test SimuladorGestionProcesos.sln --verbosity normal
```

## Uso

1. Escribir el **nombre** del proceso (opcional)
2. Ingresar la **memoria requerida** en MB
3. Ingresar la **duración** en segundos
4. Presionar **Agregar Proceso**
5. Observar los procesos en ejecución y su tiempo restante
6. Si no hay RAM suficiente, el proceso aparecerá en la cola de espera
7. Cuando un proceso finaliza, su memoria se libera y se intenta ejecutar el siguiente en cola

## Capturas de pantalla

Agregar las capturas en la carpeta `screenshots/` antes de publicar el repositorio:

```markdown
![Pantalla principal](screenshots/simulador-principal.png)

![Procesos en ejecución](screenshots/procesos-ejecucion.png)

![Cola de procesos](screenshots/procesos-cola.png)

![Estado de memoria](screenshots/memoria.png)
```

## Ejemplo de funcionamiento

```text
Proceso 1
Nombre: Chrome
RAM: 400 MB
Duración: 10 segundos

Proceso 2
Nombre: Visual Studio
RAM: 500 MB
Duración: 15 segundos

Proceso 3
Nombre: Spotify
RAM: 300 MB
Duración: 8 segundos
```

Los dos primeros procesos utilizan:

```text
900 MB
```

Quedan disponibles:

```text
124 MB
```

Por esta razón **Spotify** entra en la cola de espera.

Cuando **Chrome** termina:

```text
400 MB son liberados
```

El sistema dispone entonces de memoria suficiente para ejecutar **Spotify**.

## Escenarios de prueba

### Prueba 1

```text
Proceso A = 300 MB
Proceso B = 400 MB
Proceso C = 200 MB
```

Resultado esperado:

```text
Memoria utilizada = 900 MB
Memoria disponible = 124 MB
Los tres procesos deben ejecutarse.
```

### Prueba 2

Agregar:

```text
Proceso D = 300 MB
```

Resultado esperado:

```text
Proceso D → En espera
```

### Prueba 3

Cuando termine Proceso A (300 MB):

```text
RAM liberada = 300 MB
Proceso D → Ejecutando
```

### Prueba 4

Intentar crear un proceso de 1500 MB:

```text
Error: La memoria requerida no puede ser mayor a 1024 MB.
```

## Integrantes

```text
Nombre                     Carné
---------------------------------------
Integrante 1               XXXXXXXX
Integrante 2               XXXXXXXX
Integrante 3               XXXXXXXX
```

## Historial de contribuciones

Cada integrante debe realizar commits individuales en GitHub para demostrar su participación en el desarrollo.

### Distribución sugerida de trabajo

**Integrante 1:**

- Clase `Proceso`
- Generación de PID
- Validaciones

**Integrante 2:**

- Gestión de memoria
- Cola de espera
- Ejecución concurrente

**Integrante 3:**

- Diseño de interfaz
- DataGridView
- README

### Commits sugeridos

```text
feat: crear modelo de procesos
feat: implementar control de memoria RAM
feat: implementar cola FIFO
feat: agregar ejecución asíncrona de procesos
feat: agregar liberación automática de memoria
ui: crear interfaz principal del simulador
ui: agregar indicador de memoria RAM
docs: agregar documentación del proyecto
docs: agregar capturas de funcionamiento
```

## Git y GitHub

Inicializar el repositorio:

```bash
git init
git add .
git commit -m "Initial project structure"
git branch -M main
git remote add origin URL_REPOSITORIO
git push -u origin main
```

## Licencia

Proyecto desarrollado con fines educativos.
