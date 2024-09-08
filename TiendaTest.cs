namespace TP1IS;

using System.Reflection;
using Clases;
using Xunit;
using Moq;
public class TiendaTest
{
    [Fact]
    public void AgregarProducto_AgregadoCorrectamente()
    {
        string nombre = "Manzana";
        double precio = 500;
        string categoria = "Fruta";
        Producto producto = new Producto(nombre, precio, categoria);

        Tienda tienda = new Tienda();
        tienda.agregar_producto(producto);

        /*Controla que el producto este contenido en el inventario de la tienda para comprobar que 
        que se añadio correctamente*/
        Assert.Contains(producto,tienda.listar_productos());
    }

    // [Fact]
    // public void AgregarProducto_ProductoEnNull()
    // {
    //     //Controla que cuando se intentan agregar un producto en NULL el test lance una excepcion
    //     Tienda tienda = new Tienda();
    //     Assert.Throws<ArgumentNullException>(() => tienda.agregar_producto(null));
    // }

    [Fact]
    public void BuscarProducto_EncuentraProductoCorrecto()
    {
        string nombre = "Manzana";
        double precio = 500;
        string categoria = "Fruta";
        Producto producto = new Producto(nombre, precio, categoria);

        Tienda tienda = new Tienda();
        tienda.agregar_producto(producto);

        var productoEncontrado = tienda.buscar_producto(nombre);
        
        Assert.NotNull(productoEncontrado);
        Assert.Equal(producto.Nombre, productoEncontrado.Nombre);
        Assert.Equal(producto.Precio, productoEncontrado.Precio);
        Assert.Equal(producto.Categoria, productoEncontrado.Categoria);
    }

    // [Fact]
    // public void BuscarProducto_NoEncuentraProducto()
    // {
    //     string nombre = "Manzana";
    //     double precio = 500;
    //     string categoria = "Fruta";
    //     Producto producto = new Producto(nombre, precio, categoria);

    //     Tienda tienda = new Tienda();
    //     tienda.agregar_producto(producto);

    //     string nombreBuscar = "Pera";

    //     var productoEncontrado = tienda.buscar_producto(nombreBuscar);
        
    //     Assert.Null(productoEncontrado);
    
    // }

    [Fact]
    public void BuscarProducto_NoEncuentraProductoException()
    {
        string nombre = "Manzana";
        double precio = 500;
        string categoria = "Fruta";
        Producto producto = new Producto(nombre, precio, categoria);

        Tienda tienda = new Tienda();
        tienda.agregar_producto(producto);

        string nombreBuscar = "Pera";

        var excepcion = Assert.Throws<Exception>(() => tienda.buscar_producto(nombreBuscar));
        Assert.Equal("No se encontró un producto con el nombre especificado", excepcion.Message);
    }
    
    [Fact]
    public void EliminarProducto_EliminaProductoCorrecto()
    {
        string nombre = "Manzana";
        double precio = 500;
        string categoria = "Fruta";
        Producto producto = new Producto(nombre, precio, categoria);

        Tienda tienda = new Tienda();
        tienda.agregar_producto(producto);

        var eliminado = tienda.eliminar_producto(nombre);
        //var productoEncontrado = tienda.buscar_producto(nombre);
        
        Assert.True(eliminado);
        Assert.DoesNotContain(producto, tienda.listar_productos());
        //Assert.Null(productoEncontrado);
    }

    [Fact]
    public void EliminarProducto_ProductoNoEncontradoException()
    {
        string nombre = "Manzana";
        double precio = 500;
        string categoria = "Fruta";
        Producto producto = new Producto(nombre, precio, categoria);

        Tienda tienda = new Tienda();
        tienda.agregar_producto(producto);

        string nombreBuscar = "Pera";
        var excepcion = Assert.Throws<Exception>(() => tienda.eliminar_producto(nombreBuscar));
        Assert.Equal("No se encontró un producto con el nombre especificado que quiere ser eliminado", excepcion.Message);
    }

    [Fact]
    public void AplicarDescuento_ActualizarPrecioCorrectamente()
    {
        string nombre = "Manzana";
        double precio = 1000;
        string categoria = "Fruta";
        var tienda = new Tienda();
        //Creacion del mock de producto
        var mockProducto = new Mock<Producto>(nombre, precio, categoria);
        mockProducto.SetupGet(p => p.Precio).Returns(1000); // Precio inicial del producto
        tienda.agregar_producto(mockProducto.Object);
        int porcentaje = 50;
        tienda.aplicar_descuento(nombre, porcentaje);
        //Se verifica que el metodo actualizar_precio funciono correctamente una sola vez
        mockProducto.Verify(p => p.actualizar_precio(500), Times.Once);
    }
}