using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_2
{
    public class Factura
    {
        private readonly Dictionary<byte, List<Producto>> _productosConsumidosPorMesa;

        public Factura(Dictionary<byte, List<Producto>> productosConsumidosPorMesa)
        {
            _productosConsumidosPorMesa = productosConsumidosPorMesa;
        }

        public void GenerarFactura(byte numeroMesa)
        {
            if (!_productosConsumidosPorMesa.ContainsKey(numeroMesa))
            {
                Console.WriteLine($"No hay productos consumidos en la mesa {numeroMesa}.");
                return;
            }

            List<Producto> productosConsumidos = _productosConsumidosPorMesa[numeroMesa];

            //ASCII 
            Console.WriteLine(@" _____ _    ____ _____ _   _ ____     _     
|  ___/ \  / ___|_   _| | | |  _ \   / \    
| |_ / _ \| |     | | | | | | |_) | / _ \   
|  _/ ___ | |___  | | | |_| |  _ < / ___ \  
|_|/_/   \_\____| |_|  \___/|_| \_/_/   \_\ ");
            Console.WriteLine($"----------------------------------");

            Console.WriteLine($"Fecha: {DateTime.Now.ToShortDateString()}");
            Console.WriteLine($"Hora: {DateTime.Now.ToShortTimeString()}");
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Número de mesa: {numeroMesa}"); //El número que identifica cada mesa para generar su respectiva factura
            Console.WriteLine($"----------------------------------");
            Console.WriteLine("Productos consumidos:");

            foreach (var producto in productosConsumidos)
            {
                Console.WriteLine($"- {producto.Nombre}: {producto.Precio:C}");
            }
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Total Productos Consumidos: {CalcularTotalProductos(productosConsumidos):C}");
            Console.WriteLine($"IVA: {CalcularIVA(productosConsumidos):C}");
            Console.WriteLine($"----------------------------------");
            Console.WriteLine($"Total a Pagar: {CalcularIVA(productosConsumidos) + CalcularTotalProductos(productosConsumidos):C}");
            Console.WriteLine($"----------------------------------");


            ExportarFacturaATXT(numeroMesa, productosConsumidos);




        }

        private float CalcularTotalProductos(List<Producto> productos) //Esta función toma el precio de cada producto y lo suma
        {
            return productos.Sum(producto => producto.Precio);
        }

        private float CalcularIVA(List<Producto> productos) //Calculamos el iba del total de los productos
        {
            float totalProductos = CalcularTotalProductos(productos);
            return totalProductos * 0.19f; // IVA del 19%
        }


        private void ExportarFacturaATXT(byte numeroMesa, List<Producto> productos) //La función para Exportar la factura de consola a un archivo .txt
        {
            string path = @"D:\Universidad\POO\Taller2_JuanMarin_DanielMonsalve-main"; //Esta es la ruta donde queremos que se guarde el archivo .txt
            string fileName = $"Factura_Mesa_{numeroMesa}.txt";
            string fullPath = Path.Combine(path, fileName);

            using (StreamWriter sw = File.CreateText(fullPath))
            {
                sw.WriteLine("FACTURA");
                sw.WriteLine("----------------------------------");
                sw.WriteLine($"Fecha: {DateTime.Now.ToShortDateString()}");
                sw.WriteLine($"Hora: {DateTime.Now.ToShortTimeString()}");
                sw.WriteLine("----------------------------------");
                sw.WriteLine($"Número de mesa: {numeroMesa}");
                sw.WriteLine("----------------------------------");
                sw.WriteLine("Productos consumidos: ");

                foreach (var producto in productos)
                {
                    sw.WriteLine($"- {producto.Nombre}: {producto.Precio:C}");
                }
                sw.WriteLine("----------------------------------");
                sw.WriteLine($"Total Productos Consumidos: {CalcularTotalProductos(productos):C}");
                sw.WriteLine($"IVA: {CalcularIVA(productos):C}");
                sw.WriteLine("----------------------------------");
                sw.WriteLine($"Total a Pagar: {CalcularIVA(productos) + CalcularTotalProductos(productos):C}");
                sw.WriteLine("----------------------------------");
            }

            Console.WriteLine("La factura ha sido generada y exportada exitosamente.");
        }

        

    }
}


