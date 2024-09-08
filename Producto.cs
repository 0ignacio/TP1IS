namespace Clases;

public class Producto{
    private string nombre;
    private double precio;
    private string categoria;

    public Producto(string nombre, double precio, string categoria)
    {
        this.nombre = nombre;
        this.precio = precio;
        this.categoria = categoria;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public virtual double Precio { get => precio; set => precio = value; }
    public string Categoria { get => categoria; set => categoria = value; }

    public virtual void actualizar_precio(double precio){
        if(precio < 0){
            throw new Exception("El precio que se quiere actualizar es negativo");
        }
        this.precio = precio;
    }
}