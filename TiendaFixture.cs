using Moq;
using Xunit;
namespace Clases;

public class TiendaFixture : IDisposable
{
    private Tienda tiendaFix;

    public Tienda TiendaFix { get => tiendaFix; set => tiendaFix = value; }

    public TiendaFixture()
    {
        tiendaFix = new Tienda();
        tiendaFix.agregar_producto(new Producto("Costilla", 1000, "Carne"));
        tiendaFix.agregar_producto(new Producto("Nalga", 1000, "Carne"));
        tiendaFix.agregar_producto(new Producto("Crema de manos", 1000, "Cuidado Personal"));
        tiendaFix.agregar_producto(new Producto("Taza de te", 1000, "Hogar"));
    }

    public void Dispose()
    {
        tiendaFix = null;
    }
}