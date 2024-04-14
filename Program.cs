namespace Taller_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte numeroMesa = 0;
            List<Producto> productos = new List<Producto>();

            for (byte i = 0; i < 1;)
            {

                Console.WriteLine("  +---------------------------------------------------------------------------+");
                Console.WriteLine(" ____  _                           _     _       _ ");
                Console.WriteLine("| __ )(_) ___ _ ____   _____ _ __ (_) __| | ___ | |");
                Console.WriteLine("|  _ \\| |/ _ \\ '_ \\ \\ / / _ \\ '_ \\| |/ _` |/ _ \\| |");
                Console.WriteLine("| |_) | |  __/ | | \\ V /  __/ | | | | (_| | (_) |_|");
                Console.WriteLine("|____/|_|\\___|_| |_|\\_/ \\___|_| |_|_|\\__,_|\\___/(_)");

                Console.WriteLine("Seleccione una opción: ");
                Console.WriteLine("1. Realizar venta ");
                Console.WriteLine("2. Editar productos");
                Console.WriteLine("3. Buscar factura");
                Console.WriteLine("4. Exportar factura");
                Console.WriteLine("0. Salir");
                Console.WriteLine("  +---------------------------------------------------------------------------+");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "0": Environment.Exit(0); ; break;
                    case "1": i++; break;
                    case "2":
                        for (byte j = 0; j < 1;)
                        {
                            Console.WriteLine("Seleccione una opción: ");
                            Console.WriteLine("1. Agregar Productos ");
                            Console.WriteLine("2. Eliminar productos");
                            Console.WriteLine("3. Mostrar carta");
                            Console.WriteLine("0. Volver al menu principal");

                            string opcionProductos = Console.ReadLine();
                            switch (opcionProductos)
                            {
                                case "0": j++; break;
                                case "1": AgregarProductos(productos); break;
                                case "2":
                                    EliminarProducto(productos);
                                    break;
                                case "3":
                                    MostrarMenu(productos);
                                    break;
                                default: Console.WriteLine("Seleccione una opcion valida"); break;
                            }
                        }
                        break;
                    default: Console.WriteLine("Seleccione una opción valida"); break;
                }
                Console.WriteLine();
            }

            for (byte i = 0; i < 1;)
            {
                Console.WriteLine("Seleccione una mesa entre 1 y 20 ");
                string mesa = Console.ReadLine();

                bool verifMesa = byte.TryParse(mesa, out numeroMesa);
                if (numeroMesa > 20 || verifMesa == false)
                {
                    Console.WriteLine("Seleccione una opcion valida");
                }
                else { i++; }

            }
            //Continuar
        
        
        
        }



        static void AgregarProductos(List<Producto> productos)
        {
            Console.WriteLine("Ingrese los productos:");

            while (true)
            {
                Console.Write("Nombre del producto (deje vacío para salir): ");
                string nombre = Console.ReadLine();

                // Si el usuario deja el nombre vacío, salir del bucle
                if (string.IsNullOrEmpty(nombre))
                    break;

                Console.Write("Precio del producto: ");
                float precio;
                while (!float.TryParse(Console.ReadLine(), out precio) || precio < 0)
                {
                    Console.WriteLine("Por favor, ingrese un precio válido.");
                    Console.Write("Precio del producto: ");
                }


                Console.Write("ID del producto (deje vacío para salir): ");
                string idStr = Console.ReadLine();

                // Si el usuario deja el ID vacío, salir del bucle
                if (string.IsNullOrEmpty(idStr))
                    break;

                int id;
                if (!int.TryParse(idStr, out id) || id <= 0)
                {
                    Console.WriteLine("Por favor, ingrese un ID válido (número entero positivo).");
                    continue;
                }

                // Crear un nuevo producto con los datos proporcionados y agregarlo a la lista
                Producto producto = new Producto(nombre, precio, id);
                productos.Add(producto);

                Console.WriteLine("Producto agregado con éxito.");
            }
        }
        static void MostrarMenu(List<Producto> productos)
        {
            // Mostrar los productos actuales para que el usuario pueda seleccionar uno para eliminar
            Console.WriteLine("Lista de Productos:");

            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine($"ID: {productos[i].Id} - Nombre: {productos[i].Nombre} - Precio: {productos[i].Precio}");
            }
        }
        static void EliminarProducto(List<Producto> productos)
        {
            // Mostrar los productos actuales para que el usuario pueda seleccionar uno para eliminar
            Console.WriteLine("Lista de Productos:");

            for (int i = 0; i < productos.Count; i++)
            {
                Console.WriteLine($"ID: {productos[i].Id} - Nombre: {productos[i].Nombre} - Precio: {productos[i].Precio}");
            }

            // Solicitar al usuario que ingrese el ID del producto que desea eliminar
            Console.Write("Ingrese el ID del producto que desea eliminar (0 para cancelar): ");
            int idEliminar;
            while (!int.TryParse(Console.ReadLine(), out idEliminar) || idEliminar < 0)
            {
                Console.WriteLine("Por favor, ingrese un ID válido.");
                Console.Write("Ingrese el ID del producto que desea eliminar (0 para cancelar): ");
            }

            // Si el ID es 0, cancelar la operación
            if (idEliminar == 0)
            {
                Console.WriteLine("Operación cancelada.");
                return;
            }

            // Buscar el producto con el ID especificado en la lista
            Producto productoEliminar = productos.Find(p => p.Id == idEliminar);

            // Si el producto no se encontró, mostrar un mensaje de error y salir de la función
            if (productoEliminar == null)
            {
                Console.WriteLine("No se encontró ningún producto con el ID especificado.");
                return;
            }

            // Confirmar la eliminación del producto
            Console.WriteLine($"¿Está seguro de que desea eliminar el producto '{productoEliminar.Nombre}' con ID {productoEliminar.Id}? (s/n)");
            string confirmacion = Console.ReadLine();

            // Si el usuario confirma la eliminación, eliminar el producto de la lista
            if (confirmacion.ToLower() == "s")
            {
                productos.Remove(productoEliminar);
                Console.WriteLine("Producto eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Operación cancelada.");
            }
        }


    }
}