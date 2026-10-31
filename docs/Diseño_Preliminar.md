# Documento de Diseño Preliminar - Biblioteca Escolar

## 1. Análisis de Estructuras Candidatas

Para representar los títulos de la biblioteca con una cantidad irregular de ejemplares sin dejar celdas vacías, se evalúan tres opciones:

### A. Arreglo Escalonado (`int[][]` o similar)
- **Pros:** Control estricto de memoria, sin desperdicio de celdas, acceso directo por índices.
- **Contras:** Tamaño estático por cada fila; redimensionar los sub-arreglos al prestar o reponer libros es complejo y costoso en código.
- **¿Cumple restricciones?:** Sí, soporta ejemplares irregulares sin celdas vacías.

### B. `List<int[]>`
- **Pros:** Permite añadir o quitar títulos dinámicamente usando la lista principal.
- **Contras:** Mezcla listas dinámicas con arreglos fijos, lo que vuelve la legibilidad del código confusa y propensa a errores de sintaxis.
- **¿Cumple restricciones?:** Sí.

### C. `List<Título>` (Estructura Seleccionada)
- **Pros:** Excelente aplicación de la Programación Orientada a Objetos. Agrupa de forma limpia el ISBN, el nombre del título, el contador histórico de préstamos y la colección de ejemplares en una sola entidad cohesiva. Es altamente mantenible y escalable.
- **Contras:** Ligeramente mayor consumo de memoria por la sobrecarga de objetos.
- **¿Cumple restricciones?:** Sí, encapsulando colecciones internas ajustadas para cada título.

## 2. Conclusión del Diseño
Se selecciona la estructura **`List<Título>`** por su claridad, robustez y facilidad para implementar posteriormente el ordenamiento manual por inserción y la búsqueda binaria por ISBN.
