using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
	class Program
	{
		static void Main(string[] args)
		{
			//instancia clase que contiene las operaciones necesarias
			Operaciones op = new Operaciones();

			//centinela
			bool continuar = true;
			do
			{
				//Menú principal
				Console.Clear();
				Console.WriteLine("*** SISTEMA DE VENTAS FARO ***");
				Console.WriteLine("\nElija alguna de las siguientes opciones: \n");
				Console.WriteLine("1. Registrar artículos\n2. Registrar vendedores" +
								  "\n3. Realizar venta de artículos\n4. Consultar ventas" +
								  "\n5. Actualizar inventario\n6. Consultar inventario\n7. Salir");
				int opcion;
				Console.Write("\nTu opción --> ");

				try
				{
					opcion = int.Parse(Console.ReadLine());

					//opciones del menú
					switch (opcion)
					{

						case 1:
							if (op.cuentaArticulos())
							{
								op.registrarArticulo();
							}
							break;
						case 2:
							//verifica que hayan vendedores registrados
							if (op.cuentaVendedores())
							{
								op.registrarVendedor();
							}
							break;
						case 3:
							op.ventaArticulo();
							break;
						case 4:
							op.consultaVentas();
							break;
						case 5:
							//verifica que haya al menos un artículo
							if (op.cuentaCantArticulos())
							{
								op.actualizarInventario();
							}
							break;
						case 6:
							//consulta que hayan artículos
							if (op.cuentaCantArticulos())
							{
								op.consultaInventario();
							}
							break;
						case 7:
							bool decision = op.salir();
							if (decision == continuar)
								continuar = false;
							break;
						default:
							Console.Clear();
							Console.WriteLine("Por favor ingrese solo opciones del 1 al 7\n\n");
							break;
					}
				}
				catch (Exception e)
				{
					Console.Clear();
					Console.WriteLine("Por favor ingrese solo opciones válidas. Intente de nuevo\n\n");
				}

			} while (continuar);
		}
	}
}
