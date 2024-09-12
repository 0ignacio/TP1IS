# TP1_IS
## Ejercicio 1) 
* ¿Puedes identificar pruebas de unidad y de integración en la práctica que realizaste?
En la practica realizada solo se pueden ver pruebas de unidad ya que solo se prueban funcionalidades
basicas de las clases producto y tienda.
Se podria ver la integracion de la clase producto a la clase tienda para su funcionamiento, pero esta dependencia
no es de gran complejidad.


## Ejercicio 2)
* ¿Podría haber escrito las pruebas primero antes de modificar el código de la aplicación?
 ¿Cómo sería el proceso de escribir primero los tests?

Si se podrian haber escrito las pruebas primero antes que el codigo. (Investigacion) Esta practica se conoce 
con el nombre de Desarrollo Dirigido por Pruebas, y permite pensar sobre el comportamiento esperado de cada modulo.

El proceso tendria el siguiente orden:
1ero - Se escribe una prueba de una funcionalidad que aun no existe.
2do - Se escribe el codigo de la funcionalidad que cumpla con el objetivo de la prueba.
3ero - Se repite el paso 1 y 2.

## Ejercicio 3)
* En lo que va del trabajo práctico, ¿puedes identificar 'Controladores' y 'Resguardos'?
 ¿Qué es un mock? ¿Hay otros nombres para los objetos/funciones simulados?

Se podria llamar 'Controlador' a la clase Tienda, ya que es ella la que se encarga del funcionamiento del sistema en su conjunto.
El mock de Producto que se utiliza en este punto esta en la categoria de 'Resguardo'.

Un 'Mock' es una simulacion de un objeto que se utiliza para reemplazar una parte del sistema al momento de realizar pruebas unitarias,
permitiendo que la parte del sistema que se quiere testear se encuente aislada de sus dependencias.

Stubs: Objetos simulados que solo devuelven valores predeterminados, no tienen una logica interna.
Fakes: Objetos simulados que tiene una logica simplificada de la logica real implementada.
Spies: Objetos simulados que tienen la capacidad de registrar cuando son llamados, registrando de esta manera las interacciones
con el mismo.

## Ejercicio 4)
* ¿Qué ventajas ve en el uso de fixtures? ¿Qué enfoque estaría aplicando?
  Explique los conceptos de Setup y Teardown en testing.

  Los 'Fixtures' son escenarios configurados para la ejecucion de pruebas, este contiene el conjunto de pruebas iniciales,
  datos de prueba y objetos necesarios para que las pruebas puedan se ejecutadas.
  Las ventajas de utilizar fixtures son:
  - Mejora en la legibilidad, ya que se separa la configuracion de las pruebas de el codigo de las pruebas.
  - Reutilizacion de codigo, ya que al encapsular la configuracion de las pruebas, esta puede ser utilizada sin la necesidad
  de repetir la configuracion en cada test.
  - Consistencia, ya que todas las pruebas se realizan con la misma configuracion.

  El concepto 'SetUp' es el proceso en el cual se realiza la configuracion del entorno de prueba antes del testeo.
  El concepto 'Teardown' es el proceso 'limpiar' el entorno de prueba despues del testeo (Ej: libera recursos, cerrar conexciones, etc).

## Ejercicio 5)
* ¿Puede describir una situación de desarrollo para este caso en donde se plantee pruebas de
  integración ascendente? Describa la situación

  Las pruebas de integracion ascendente comienzan con la construcción y prueba de los módulos mas esenciales, y luego se agrupan respecto
  a funcionalidades que se quieren probar, hasta completar el sistema.

  En este caso:
  1) Empezariamos con las pruebas de las funciones de la clase Producto.
  2) Lo siguiente seria integrar la calse Tienda y realizar pruebas de sus funciones (agregar, eliminar, buscar, actualizar
  precio de productos y calcular carrito).
  3) Por ultimo realizariamos pruebas de los recorridos completos del sistema.