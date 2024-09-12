namespace TP1IS;

using System.Reflection;
using Clases;
using Xunit;
using Moq;
public class TiendaTest : IClassFixture<TiendaFixture>
{
    private TiendaFixture _fixture;

    public TiendaTest(TiendaFixture tiendaFix)
    {
        _fixture = tiendaFix;
    }

    [Fact]
    public void AgregarProducto_AgregadoCorrectamente()
    {
        Producto producto = new Producto("Mayonesa", 1000, "Aderesos"); 
        _fixture.TiendaFix.agregar_producto(producto);

        /*Controla que el producto este contenido en el inventario de la tienda para comprobar que 
        que se añadio correctamente*/
        Assert.Contains(producto,_fixture.TiendaFix.listar_productos());
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
        var productoEncontrado = _fixture.TiendaFix.buscar_producto("Costilla");
        
        Assert.NotNull(productoEncontrado);
        Assert.Equal("Costilla", productoEncontrado.Nombre);
        Assert.Equal(1000, productoEncontrado.Precio);
        Assert.Equal("Carne", productoEncontrado.Categoria);
    }

    // [Fact]
    // public void BuscarProducto_NoEncuentraProducto()
    // {
    //     var productoEncontrado = _fixture.TiendaFix.buscar_producto("Pera");
        
    //     Assert.Null(productoEncontrado);
    // }

    [Fact]
    public void BuscarProducto_NoEncuentraProductoException()
    {
        string nombreBuscar = "Pera";

        var excepcion = Assert.Throws<Exception>(() => _fixture.TiendaFix.buscar_producto(nombreBuscar));
        Assert.Equal("No se encontró un producto con el nombre especificado", excepcion.Message);
    }
    
    [Fact]
    public void EliminarProducto_EliminaProductoCorrecto()
    {
        Producto producto = _fixture.TiendaFix.buscar_producto("Costilla");
        var eliminado = _fixture.TiendaFix.eliminar_producto("Costilla");
        
        Assert.True(eliminado);
        Assert.DoesNotContain(producto, _fixture.TiendaFix.listar_productos());
    }

    [Fact]
    public void EliminarProducto_ProductoNoEncontradoException()
    {
        var excepcion = Assert.Throws<Exception>(() => _fixture.TiendaFix.eliminar_producto("Pera"));
        Assert.Equal("No se encontró un producto con el nombre especificado que quiere ser eliminado", excepcion.Message);
    }

    [Fact]
    public void AplicarDescuento_ActualizarPrecioCorrectamente()
    {
        //Creacion del mock de producto
        var mockProducto = new Mock<Producto>("Manzana", 1000, "Fruta");
        mockProducto.SetupGet(p => p.Precio).Returns(1000); // Precio inicial del producto
        _fixture.TiendaFix.agregar_producto(mockProducto.Object);
    
        _fixture.TiendaFix.aplicar_descuento("Manzana", 50); //parametros nombre y descuento
        //Se verifica que el metodo actualizar_precio funciono correctamente una sola vez
        mockProducto.Verify(p => p.actualizar_precio(500), Times.Once);
    }

    [Fact]
    public void CalcularCarrito_FlujoCompleto()
    {
        List<String> carrito = new List<String>();
        //Funcionalidad: agregar producto
        _fixture.TiendaFix.agregar_producto(new Producto("Mayonesa", 1000, "Aderesos"));
        _fixture.TiendaFix.agregar_producto(new Producto("Mostaza", 1000, "Aderesos"));
        _fixture.TiendaFix.agregar_producto(new Producto("Salsa picante", 1000, "Aderesos"));
        //Funcionalidad: eliminar producto
        _fixture.TiendaFix.eliminar_producto("Mayonesa");
        //Funcionalidad: aplicar descuento
        _fixture.TiendaFix.aplicar_descuento("Mostaza", 50);
        //Se añaden los productos al carrito
        carrito.Add(_fixture.TiendaFix.buscar_producto("Mostaza").Nombre);
        carrito.Add(_fixture.TiendaFix.buscar_producto("Nalga").Nombre);
        carrito.Add(_fixture.TiendaFix.buscar_producto("Crema de manos").Nombre);
        //Calculo del total del carrito
        double totalCarrito = _fixture.TiendaFix.calcular_total_carrito(carrito);
        //Total esperado
        double totalEsperado = 500 + 1000 + 1000; //Primer precio mostaza con 50% desc, Nalga 1000 y Crema de manos 1000
        //Assert
        Assert.Equal(totalCarrito, totalEsperado);
    }

    [Fact]
    public void CalcularCarrito_FlujoCompleto_CarritoVacio()
    {
        List<String> carrito = new List<String>();
        //Funcionalidad: agregar producto
        _fixture.TiendaFix.agregar_producto(new Producto("Mayonesa", 1000, "Aderesos"));
        _fixture.TiendaFix.agregar_producto(new Producto("Mostaza", 1000, "Aderesos"));
        _fixture.TiendaFix.agregar_producto(new Producto("Salsa picante", 1000, "Aderesos"));
        //Funcionalidad: eliminar producto
        _fixture.TiendaFix.eliminar_producto("Mayonesa");
        //Funcionalidad: aplicar descuento
        _fixture.TiendaFix.aplicar_descuento("Salsa picante", 50);
        
        var excepcion = Assert.Throws<Exception>(() => _fixture.TiendaFix.calcular_total_carrito(carrito));
        Assert.Equal("El carrito esta vacio", excepcion.Message);
    }
}