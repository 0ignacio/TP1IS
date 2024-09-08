namespace Clases;

public class Tienda{
    private List<Producto> inventario;
    public Tienda (){
        this.inventario = new List<Producto>();
    }
    public void agregar_producto(Producto producto){
        this.inventario.Add(producto);
    }
    public Producto buscar_producto(string nombre){
        foreach (var producto in this.inventario)
        {
            if(producto.Nombre == nombre) return producto;
        }
        throw new Exception("No se encontró un producto con el nombre especificado");
    }
    public bool eliminar_producto(string nombre){
        foreach (var producto in this.inventario)
        {
            if(producto.Nombre == nombre){
                this.inventario.Remove(producto);
                return true;
            }
        }
        throw new Exception("No se encontró un producto con el nombre especificado que quiere ser eliminado");
    }

    public List<Producto> listar_productos(){
        return this.inventario;
    }

    public void aplicar_descuento(string nombre, int descuento){
        Producto producto = buscar_producto(nombre);
        if(descuento < 0 || descuento > 100){
            throw new Exception("Porcentaje fuera de rango");
        }
        double nuevoPrecio = producto.Precio * (1 - descuento/100);
        producto.actualizar_precio(nuevoPrecio);
    }
}