namespace TP1IS;
using Xunit;
using Moq;
using Clases;
public class ProductoTest
{
    [Fact]
    public void CrearProducto_InicializadoCorrectamente()
    {
        string nombre = "Monitor";
        double precio = 10000;
        string categoria = "Tecnologia";

        Producto producto = new Producto(nombre, precio, categoria);

        Assert.NotNull(producto);
        Assert.Equal(nombre, producto.Nombre);
        Assert.Equal(precio, producto.Precio);
        Assert.Equal(categoria, producto.Categoria);
    }

    [Fact]
    public void ActualizarPrecioProducto_PrecioNegativo()
    {
        string nombre = "Monitor";
        double precio = 10000;
        string categoria = "Tecnologia";

        Producto producto = new Producto(nombre, precio, categoria);

        double precioNuevo = -10000;
        //Assert.Throws<ArgumentException>(() => producto.actualizar_precio(-50));
        var excepcion = Assert.Throws<Exception>(() => producto.actualizar_precio(precioNuevo));
        Assert.Equal("El precio que se quiere actualizar es negativo", excepcion.Message);
    }

    [Fact]
    public void ActualizarPrecioProducto_ActualizarCorrectamente()
    {
        string nombre = "Monitor";
        double precio = 10000;
        string categoria = "Tecnologia";

        Producto producto = new Producto(nombre, precio, categoria);
        double nuevoPrecio = 1000;
        producto.actualizar_precio(nuevoPrecio);

        Assert.Equal(nuevoPrecio, producto.Precio);
    }
}