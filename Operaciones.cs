using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
	class Operaciones
	{
		public Operaciones() { }

		//se inicializan los arreglos de artículos, vendores y orden de compras
		Articulo[] articulos = new Articulo[20];
		Vendedor[] vendedores = new Vendedor[20];
		OrdenCompra[] ordenCompras = new OrdenCompra[15];
		//OrdenCompraDetalle[] ordenesCompraDetalle = new OrdenCompraDetalle[15];


		//contadores para saber cuántos artículos, vendedores, órdenes, y detalles de compras hay.
		int contArticulo = 0;
		int contVendedor = 0;
		int contOrden = 0;
		int contDetalle = 0;

		/// <summary>
		/// FUNCIONES PRINCIPALES
		/// </summary>
		/// 

		/*REGISTRAR ARTÍCULO*/
		public void registrarArticulo()
		{
			//valida si el usuario desea salir al menú principal
			bool seguir = true;
			do
			{
				//cuenta y valida que los artículos sean menos de 20
				//si es mayor a 20 la función cuentaArtículos envía un mensaje al usuario
				if (cuentaArticulos())
				{

					Console.Clear();
					//valida el ciclo si el usuario comete errores en el formulario
					//en ese caso el ciclo se sigue cumpliendo, de lo contrario pasa a false
					bool continuar = true;
					//objeto que guardará el nuevo artículo
					Articulo nuevoArticulo = new Articulo();

					//***ID ARTICULO***//
					do
					{
						Console.WriteLine("*** REGISTRO DE ARTÍCULO ***\n\n");
						Console.Write("Ingrese el ID del artículo --> ");
						string id = Console.ReadLine();
						if (esEntero(id)) //verifica la cadena ingresada sea un número entero
						{
							int idA = int.Parse(id); //se castea a entero

							//si no existe el artículo se agrega al objeto
							if (!existeArticulo(idA))
							{
								nuevoArticulo.IdArticulo = idA;
								continuar = false;
							}
							else
							{
								Console.Clear();
								Console.WriteLine("El ID del artículo ya existe. Por favor intente de nuevo\n\n");
							}

						}
					} while (continuar);

					//***DESCRIPCIÓN ARTICULO***//
					Console.Clear();
					Console.Write("Ingrese la descripción del artículo ---> ");
					string descripcion = Console.ReadLine();
					nuevoArticulo.Descripcion = descripcion;

					Console.Clear();
					//se le vuelve a asignar el valor true para validar el siguiente ciclo
					continuar = true;
					do
					{
						Console.Write("¿El artículo está activo? S/N ---> ");
						string opcion = Console.ReadLine();

						if (opcion.Equals("S") || opcion.Equals("s"))
						{
							nuevoArticulo.Activo = true;
							continuar = false;
						}
						else if (opcion.Equals("N") || opcion.Equals("n"))
						{
							nuevoArticulo.Activo = false;
							continuar = false;
						}
						else
						{
							Console.Clear();
							Console.WriteLine("Por favor ingrese una opción válida. Intente de nuevo\n\n");
						}

					} while (continuar);

					//***PRECIO VENDEDOR***//
					Console.Clear();
					//se le asignar el valor a true para seguir validado el siguiente ciclo
					continuar = true;
					do
					{
						Console.Write("Por favor digite el precio vendedor ---> ");
						string precioVendedor = Console.ReadLine();
						//se valida que el string ingresado sea un número
						if (esDecimal(precioVendedor))
						{
							decimal precio = decimal.Parse(precioVendedor);
							nuevoArticulo.PrecioVendedor = precio;
							continuar = false;
						}

					} while (continuar);

					//***PRECIO FINAL***//
					Console.Clear();
					//se vuelve a asignar a true para seguir validando
					continuar = true;
					do
					{
						Console.Write("Por favor digite el precio final ---> ");
						string precioFinal = Console.ReadLine();

						if (esDecimal(precioFinal))
						{
							decimal precio = decimal.Parse(precioFinal);
							nuevoArticulo.PrecioFinal = precio;
							continuar = false;
						}

					} while (continuar);

					//***CANTIDAD DISPONIBLE***//
					Console.Clear();
					continuar = true;
					do
					{
						Console.Write("Por favor digite la cantidad disponible ---> ");
						string cantidad = Console.ReadLine();

						if (esPositivo(cantidad))
						{
							int cant = int.Parse(cantidad);
							nuevoArticulo.CantidadDisponible = cant;
							continuar = false;
						}
					} while (continuar);

					//****SE AGREGA EL ARTÍCULO AL ARREGLO DE OBJETOS****///
					articulos[contArticulo] = nuevoArticulo;
					//aumentar el contador de artículos
					contArticulo++;

					Console.Clear();
					continuar = true;
					//ciclo que valida si el usuario desea seguir agregando artículos
					do
					{
						Console.Write("¿Desea agregar otro artículo? S/N ---> ");
						string respuesta = Console.ReadLine();

						if (respuesta.Equals("S") || respuesta.Equals("s"))
						{
							seguir = true;
							continuar = false;
						}
						else if (respuesta.Equals("N") || respuesta.Equals("n"))
						{
							continuar = false;
							seguir = false;
						}
						else
						{
							Console.Clear();
							Console.WriteLine("Por favor ingrese una opción válida. Intente de nuevo\n\n");
						}
					} while (continuar);

				}
				//
				else
					seguir = false;

			} while (seguir);
		}

		//*FUNCIÓN REGISTRAR VENDEDOR*//
		public void registrarVendedor()
		{
			//valida si el usuario desea seguir agrenando vendedores
			bool seguir = true;

			do
			{
				//si los vendedores son más de 20 se notifica al usuario
				if (cuentaVendedores())
				{
					Console.Clear();
					//valida los ciclos que verifican que los datos sean correctos
					bool continuar = true;
					//objeto que contiene al nuevo vendedor
					Vendedor nuevoVendedor = new Vendedor();

					//****IDENTIFICACIÓN****//
					do
					{
						Console.WriteLine("****REGISTRAR VENDEDOR****\n\n");
						Console.Write("Ingrese la identificación del vendedor: ---> ");
						string id = Console.ReadLine();

						//valida que el vendedor no exista y que tampoco sea un campo en blanco
						if (!existeVendedor(id) && !id.Equals(""))
						{
							nuevoVendedor.IdVendedor = id;
							continuar = false;
						}
						else if (id.Equals(""))
						{
							Console.Clear();
							Console.WriteLine("Este campo no debe quedar en blanco. Intente de nuevo\n\n");
						}
						else
						{
							Console.Clear();
							Console.WriteLine("Ya existe un vendedor con esa identificación. Intente de nuevo.\n\n");
						}

					} while (continuar);

					//****NOMBRE****//
					continuar = true;
					do
					{
						Console.Clear();
						Console.Write("Ingrese el nombre del vendedor: ---> ");
						string nombre = Console.ReadLine();

						//valida que el el campo no sea en blanco
						if (nombre.Equals(""))
						{
							Console.Clear();
							Console.WriteLine("Este campo no puede quedar en blanco. Intente de nuevo\n\n");
						}
						else
						{
							nuevoVendedor.Nombre = nombre;
							continuar = false;
						}

					} while (continuar);

					//***PRIMER APELLIDO***//
					continuar = true;
					do
					{
						Console.Clear();
						Console.Write("Ingrese el primer apellido del vendedor: ---> ");
						string apellido1 = Console.ReadLine();

						if (apellido1.Equals(""))
						{
							Console.Clear();
							Console.WriteLine("Este campo no puede quedar en blanco. Intente de nuevo\n\n");
						}
						else
						{
							nuevoVendedor.PrimerApellido = apellido1;
							continuar = false;
						}

					} while (continuar);

					//***Segundo APELLIDO***//
					continuar = true;
					do
					{
						Console.Clear();
						Console.Write("Ingrese el segundo apellido del vendedor: ---> ");
						string apellido2 = Console.ReadLine();

						if (apellido2.Equals(""))
						{
							Console.Clear();
							Console.WriteLine("Este campo no puede quedar en blanco. Intente de nuevo\n\n");
						}
						else
						{
							nuevoVendedor.SegundoApellido = apellido2;
							continuar = false;
						}

					} while (continuar);

					//***FECHA DE NACIMIENTO***//
					continuar = true;
					Console.Clear();
					do
					{
						Console.Write("Ingrese su fecha de nacimiento en el formato MM/dd/yyyy: ---> ");
						string fecha = Console.ReadLine();

						if (fechaFormato(fecha))
						{
							DateTime fechaN = DateTime.Parse(fecha);
							fechaN.ToString("dd/MM/yyyy");
							nuevoVendedor.FechaNacimiento = fechaN;
							continuar = false;

						}

					} while (continuar);

					//***GENERO***//
					continuar = true;
					Console.Clear();
					do
					{
						Console.Write("Ingrese el género del vendedor: H/M ---> ");
						string genero = Console.ReadLine();
						genero = genero.ToUpper();

						if (genero.Equals("H") || genero.Equals("M"))
						{
							char gender = char.Parse(genero);
							nuevoVendedor.Genero = gender;
							continuar = false;
						}
						else
						{
							Console.Clear();
							Console.WriteLine("Por favor ingrese solo el caracter que se le solicita. Intente de nuevo\n\n");
						}

					} while (continuar);

					//***FECHA DE INGRESO***//
					continuar = true;
					Console.Clear();
					do
					{
						Console.Write("Ingrese la fecha de ingreso en el formato MM/dd/yyyy: ---> ");
						string fechaIngreso = Console.ReadLine();

						if (fechaFormato(fechaIngreso))
						{
							DateTime fechaI = DateTime.Parse(fechaIngreso);
							fechaI.ToString("dd/MM/yyyy"); //se le da formato a la fecha
							nuevoVendedor.FechaIngreso = fechaI;
							continuar = false;
						}

					} while (continuar);

					//****SE AGREGA EL Vendedor AL ARREGLO DE OBJETOS****///
					vendedores[contVendedor] = nuevoVendedor;
					//aumentar el contador de vendedores
					contVendedor++;

					Console.Clear();
					continuar = true;
					do
					{
						Console.Write("¿Desea agregar otro vendedor? S/N ---> ");
						string respuesta = Console.ReadLine();

						if (respuesta.Equals("S") || respuesta.Equals("s"))
						{
							seguir = true;
						}
						else if (respuesta.Equals("N") || respuesta.Equals("n"))
						{
							continuar = false;
							seguir = false;
						}
						else
						{
							Console.Clear();
							Console.WriteLine("Por favor ingrese una opción válida. Intente de nuevo\n\n");
						}
					} while (continuar);
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Ya no se pueden registrar más vendedores.\n\n");
					seguir = false;
				}
			} while (seguir);
		}

		/*FUNCIÓN VENTA ARTÍCULOS*/
		public void ventaArticulo()
		{
			//verifica que al menos haya un vendedor registrado
			if (contVendedor > 0)
			{
				//***IMPRIME LISTA DE VENDEDORES****//
				Console.Clear();

				bool continuar = true;
				do
				{
					//formato tabla para la lista de vendedores
					Console.WriteLine("*** LISTA DE VENDEDORES ***\n");
					string str1 = "| ID ";
					string str2 = "| Nombre";
					string str3 = "| Apellidos";
					Console.Write(str1.PadRight(15));
					Console.Write(str2.PadRight(15));
					Console.Write(str3.PadRight(25));
					Console.Write("|\n");
					foreach (Vendedor v in vendedores)
					{
						//si hay un objeto null se ignora y no se imprime
						//sin esta validación se cae el programa
						if (v != null)
						{
							str1 = "| " + v.IdVendedor;
							str2 = "| " + v.Nombre;
							str3 = "| " + v.PrimerApellido + " " + v.SegundoApellido;
							Console.Write(str1.PadRight(15));
							Console.Write(str2.PadRight(15));
							Console.Write(str3.PadRight(25));
							Console.Write("|");

						}
					}

					Console.Write("\n\nPor favor ingrese el ID del vendedor que realiza la venta ---> ");
					string id = Console.ReadLine();
					//se verifica que no exista un vendedor con el mismo ID
					if (existeVendedor(id))
					{
						//*** IMPRIME LOS ARTÍCULOS PARA VENTA***//
						bool seguir = true;
						//objeto de 15 posiciones con los detalles de la compra
						OrdenCompraDetalle[] detalle = new OrdenCompraDetalle[15];

						//precios finales de los artículos
						decimal precioTotalVendedor = 0, precioTotalFinal = 0;

						do
						{
							//valida que exista al menos un artículo
							//valida que la cantidad de artículos no sea mayor a 20
							if (contArticulo > 0 && contArticulo < 20)
							{
								Console.Clear();

								str1 = "| ID ";
								str2 = "| Descripción";
								str3 = "| Precio vendedor";
								string str4 = "| Precio final";
								string str5 = "| Cantidad disponible";
								Console.WriteLine("|");

								Console.Write(str1.PadRight(20));
								Console.Write(str2.PadRight(20));
								Console.Write(str3.PadRight(20));
								Console.Write(str4.PadRight(20));
								Console.Write(str5.PadRight(20));
								Console.Write("|\n");
								foreach (Articulo art in articulos)
								{
									if (art != null)
									{
										str1 = "| " + art.IdArticulo;
										str2 = "| " + art.Descripcion;
										str3 = "| " + art.PrecioVendedor;
										str4 = "| " + art.PrecioFinal;
										str5 = "| " + art.CantidadDisponible;

										Console.Write(str1.PadRight(20));
										Console.Write(str2.PadRight(20));
										Console.Write(str3.PadRight(20));
										Console.Write(str4.PadRight(20));
										Console.Write(str5.PadRight(20));
										Console.Write(" |\n");

									}
								}
								Console.Write("\nIngrese el ID del artículo que desea vender: ---> ");
								string idArt = Console.ReadLine();


								if (esEntero(idArt))
								{
									int ident = int.Parse(idArt);


									if (existeArticulo(ident))
									{
										//se obtiene el objeto del artículo
										Articulo articuloVendido = new Articulo();
										//se obtiene el index del objeto que contiene el artículo seleccionado
										int indexA = Array.FindIndex(articulos, i => i.IdArticulo == ident);
										//se asigna el artículo seleccionado a articulo vendido
										articuloVendido = articulos[indexA];

										//valida que el artículo esté activo
										if (articuloVendido.Activo == true)
										{
											Console.Write("\n\nIngrese la cantidad que desea vender: ---> ");
											string cant = Console.ReadLine();

											if (esEntero(cant))
											{
												int cantidad = int.Parse(cant);

												//valida que la cantidad disponible menos la cantidad
												//seleccionada por el usuario sea mayor o igual a 0
												if (articuloVendido.CantidadDisponible - cantidad >= 0)
												{
													//se actualiza la cantidad disponible
													articuloVendido.CantidadDisponible -= cantidad;


													//datos del detalle
													OrdenCompraDetalle detalleCompra = new OrdenCompraDetalle();
													detalleCompra.InfoArticulo = articuloVendido;
													//precios del detalle multiplicados por la cantidad
													detalleCompra.InfoArticulo.PrecioVendedor *= cantidad;
													detalleCompra.InfoArticulo.PrecioFinal *= cantidad;
													detalleCompra.Cantidad = cantidad;


													//se pasa el artículo a la lista de artículos de la venta
													detalle[contDetalle] = detalleCompra;



													//se actualiza la cantidad de artículos de la orden
													contDetalle++;

													Console.Clear();
													Console.WriteLine("ORDEN REALIZADA CON ÉXITO\n\n");

													do
													{
														Console.Write("¿Desea agregar otra orden? S/N: ---> ");
														string opcion = Console.ReadLine();

														if (opcion.ToUpper().Equals("N"))
														{
															Console.Clear();
															//DATOS DE LA ORDEN con ID aleatorio
															Random ran = new Random();
															int idOrden = ran.Next(0, 10000);
															DateTime fecha = DateTime.Now; //fecha actual
															fecha.ToString("dd/MM/yyy"); //se cambia el formato de la fecha
															Vendedor ven = new Vendedor();

															//se busca el index del vendedor y se obtiene el objeto
															int indexV = Array.FindIndex(vendedores, v => v.IdVendedor == id);
															ven = vendedores[indexV];

															//se crear el objeto de orden de compra y se ingresan los datos
															OrdenCompra ordenCom = new OrdenCompra();
															ordenCom.IdCompra = idOrden;
															ordenCom.Fecha = fecha;
															ordenCom.Detalle = detalle;
															ordenCom.InfoVendedor = ven;


															//se guarda la orden en el arreglo
															ordenCompras[contOrden] = ordenCom;

															//se actualiza el contador de la orden
															contOrden++;

															//el contador de detalle vuelve a 0
															contDetalle = 0;

															//DETALLE FINAL DE LA COMPRA
															Console.WriteLine("\n***DETALLES FINALES DE LA VENTA***\n");
															//se reinician los sumadores de precios
															precioTotalFinal = 0;
															precioTotalVendedor = 0;
															foreach (OrdenCompraDetalle o in ordenCom.Detalle)
															{
																if (o != null)
																{
																	//se suman los precios finales
																	precioTotalFinal += o.InfoArticulo.PrecioFinal;
																	precioTotalVendedor += o.InfoArticulo.PrecioVendedor;
																}
															}

															Console.WriteLine("\nPrecio vendedor total: " + precioTotalVendedor);
															Console.WriteLine("Precio final total: " + precioTotalFinal);
															Console.WriteLine("\n\nPresione una tecla para volver al menú principal");
															Console.ReadKey();

															Console.Clear();
															continuar = false;
															seguir = false;
														}
														else if (opcion.ToUpper().Equals("S"))
														{
															if (contDetalle > 15)
															{
																//DATOS DE LA ORDEN
																Random ran = new Random();
																int idOrden = ran.Next(0, 10000); //se asigna un ID aleatorio
																DateTime fecha = DateTime.Now;
																fecha.ToString("dd/MM/yyy");
																Vendedor ven = new Vendedor();

																//se busca el index del vendedor y se obtiene el objeto
																int indexV = Array.FindIndex(vendedores, v => v.IdVendedor == id);
																ven = vendedores[indexV]; //se obtiene le objeto con los datos del vendedor

																//se crear el objeto de orden de compra y se ingresan los datos
																OrdenCompra ordenCom = new OrdenCompra();
																ordenCom.IdCompra = idOrden;
																ordenCom.Fecha = fecha;
																ordenCom.Detalle = detalle;
																ordenCom.InfoVendedor = ven;


																//se guarda la orden en el arreglo
																ordenCompras[contOrden] = ordenCom;

																//se actualiza el contador de la orden
																contOrden++;

																//el contador de detalle vuelve a 0 / se reinicia
																contDetalle = 0;

																Console.Clear();
																continuar = false;
																seguir = false;

																Console.Clear();
																Console.WriteLine("Ya no puede almacenar más compras");

																//DETALLE FINAL DE LA COMPRA
																Console.WriteLine("\n***DETALLES FINALES DE LA VENTA***\n");
																//precios finales de los artículos
																precioTotalVendedor = 0;
																precioTotalFinal = 0;

																foreach (OrdenCompraDetalle o in ordenCom.Detalle)
																{
																	if (o != null)
																	{
																		//se suman los precios finales por cada orden
																		precioTotalFinal += o.InfoArticulo.PrecioFinal;
																		precioTotalVendedor += o.InfoArticulo.PrecioVendedor;
																	}
																}

																Console.WriteLine("\nPrecio vendedor total: " + precioTotalVendedor);
																Console.WriteLine("Precio final total: " + precioTotalFinal);
																Console.WriteLine("\n\nPresione una tecla para volver al menú");
																Console.ReadKey();
															}
															else
															{
																Console.Clear();
																continuar = false;
															}
														}

														else
														{
															Console.Clear();
															Console.WriteLine("Por favor ingrese una opción valida. \n\n");
														}
													} while (continuar);
												}
												else
												{
													Console.Clear();
													Console.WriteLine("La cantidad indicada sobrepasa a la cantidad en Stock. \n");
													Console.WriteLine("Presione una tecla para volver al menú");
													Console.ReadKey();
													Console.Clear();
												}
											}

										}

										else
										{
											Console.Clear();
											Console.WriteLine("El artículo seleccionado no está activo. Intente con otro\n");
											Console.WriteLine("Presione cualquier tecla seguido de la tecla ENTER para volver a la lista de artículos");
											Console.Write("O bien digite la letra 'M' seguido de la tecla ENTER para volver al menú principal ---> ");
											string opcionUser = Console.ReadLine();

											if (opcionUser.ToUpper().Equals("M"))
											{
												seguir = false;
												continuar = false;
											}

										}

									}
									else
									{
										Console.Clear();
										Console.WriteLine("El ID ingresado no existe. Intente de nuevo\n\n");
										Console.WriteLine("Presione cualquier tecla para volver a la lista de artículos");
										Console.ReadKey();
									}
								}

							}

							else
							{
								//si no hay artículos registrados se notifica
								if (contArticulo == 0)
								{
									Console.Clear();
									Console.WriteLine("No existen artículos registrados. Debe registrar un artículo primero");
									Console.WriteLine("\nPresione una tecla para volver al menú principal");
									Console.ReadKey();
									continuar = false;
								}
								//si la cantidad de artículos ya llegó a los 20, se notifica.
								else if (contArticulo > 20)
								{
									Console.Clear();
									Console.WriteLine("Ya no se pueden agregar más artículos");
									Console.WriteLine("\nPresione una tecla para volver al menú principal");
									Console.ReadKey();
									continuar = false;
								}
							}
						} while (seguir);
					}
					else
					{
						Console.Clear();
						Console.WriteLine("No existe un vendendor con ese ID. Intente de nuevo\n\n");
					}

				} while (continuar);

				//
			}
			else
			{
				Console.Clear();
				Console.WriteLine("No hay vendedores registrados. Debe registrar al menos uno.\n");
				Console.WriteLine("Presione una tecla para volver al menú principal");
				Console.ReadKey();
			}
		}

		/*FUNCIÓN PARA CONSULTAR VENTAS*/
		public void consultaVentas()
		{
			//Imprime las órdenes de compra realizadas
			Console.Clear();

			//si no existen órdenes lo indica, de lo contrario imprime las órdenes
			if (contOrden == 0)
			{
				Console.WriteLine("No existen órdenes de compra.");
				Console.WriteLine("\nPresione una tecla para volver al menú principal");
				Console.ReadKey();
			}
			else
			{
				Console.WriteLine("**** ÓRDENES DE COMPRA REALIZADAS ****\n\n");

				int contador = 1; //cuenta las órdenes para ir enumerándolas

				decimal precioTotalVendedor = 0; //suma el total de precio de vendedor
				decimal precioTotalFinal = 0; //suma el total del precio final

				//navega por el arreglo de órdenes de compra
				foreach (OrdenCompra orden in ordenCompras)
				{
					if (orden != null)
					{
						Console.WriteLine("COMPRA NÚMERO: " + contador + "\n\n");
						Console.WriteLine("ID Compra: " + orden.IdCompra);
						Console.WriteLine("Fecha: " + orden.Fecha.ToString("dd/MM/yyyy"));

						Console.WriteLine("\nINFORMACIÓN DEL VENDEDOR\n\n");
						Console.WriteLine("ID: " + orden.InfoVendedor.IdVendedor);
						Console.WriteLine("Nombre completo: " + orden.InfoVendedor.Nombre + " " + orden.InfoVendedor.PrimerApellido + " " + orden.InfoVendedor.SegundoApellido);
						Console.WriteLine("Fecha de nacimiento: " + orden.InfoVendedor.FechaNacimiento.ToString("dd/MM/yyyy"));
						Console.WriteLine("Género: " + orden.InfoVendedor.Genero);
						Console.WriteLine("Fecha de ingreso: " + orden.InfoVendedor.FechaIngreso.ToString("dd/MM/yyyy"));

						Console.WriteLine("\n\nINFORMACIÓN DE LOS ARTÍCULOS COMPRADOS");
						OrdenCompraDetalle[] detalle = orden.Detalle;

						//se recorre la lista de artículos de la compra
						for (int i = 0; i < detalle.Length; i++)
						{
							if (detalle[i] != null)
							{
								Console.WriteLine("\n\nArtículo número: " + i + 1);
								Console.WriteLine("ID artículo: " + detalle[i].InfoArticulo.IdArticulo);
								Console.WriteLine("Descripción: " + detalle[i].InfoArticulo.Descripcion);
								Console.WriteLine("Cantidad comprada: " + detalle[i].Cantidad);

								//suma los precios finales y totales de vendedor
								precioTotalVendedor += detalle[i].InfoArticulo.PrecioVendedor;
								precioTotalFinal += detalle[i].InfoArticulo.PrecioFinal;
							}
						}
					}

				}

				Console.WriteLine("\n\nPRECIOS FINALES DE LAS COMPRAS");
				Console.WriteLine("Total del precio vendedor: " + precioTotalVendedor);
				Console.WriteLine("Precio final total: " + precioTotalFinal);

				Console.WriteLine("\n\nPresione una tecla para volver al menú principal");
				Console.ReadKey();

			}
		}

		/*FUNCIÓN PARA ACTUALIZAR INVENTARIO*/
		public void actualizarInventario()
		{
			//valida si el usuario desea seguir actualizando artículos
			bool continuar = true;

			do
			{
				Console.Clear();
				//formato tabla para la lista de artículos
				Console.WriteLine("****ACTUALIZAR ARTÍCULOS****\n\n");
				Console.WriteLine("LISTA DE ARTÍCULOS\n");

				string str1 = "| ID ";
				string str2 = "| Descripción";
				string str3 = "| Precio vendedor";
				string str4 = "| Precio final";
				string str5 = "| Cantidad disponible";
				Console.WriteLine("|");

				Console.Write(str1.PadRight(20));
				Console.Write(str2.PadRight(20));
				Console.Write(str3.PadRight(20));
				Console.Write(str4.PadRight(20));
				Console.Write(str5.PadRight(20));
				Console.Write("|\n");
				foreach (Articulo art in articulos)
				{
					if (art != null)
					{
						str1 = "| " + art.IdArticulo;
						str2 = "| " + art.Descripcion;
						str3 = "| " + art.PrecioVendedor;
						str4 = "| " + art.PrecioFinal;
						str5 = "| " + art.CantidadDisponible;

						Console.Write(str1.PadRight(20));
						Console.Write(str2.PadRight(20));
						Console.Write(str3.PadRight(20));
						Console.Write(str4.PadRight(20));
						Console.Write(str5.PadRight(20));
						Console.Write(" |\n");

					}
				}

				Console.Write("\nIngrese el ID del artículo que desea vender: ---> ");
				string idArt = Console.ReadLine();

				if (esEntero(idArt))
				{
					int id = int.Parse(idArt);

					//se busca el objeto del artículo por su ID
					Articulo art = Array.Find(articulos, a => a.IdArticulo == id);

					//Ciclo que sale hasta que la cantidad sea entera positiva
					bool seguir = true;
					do
					{
						//actualiza la cantidad
						Console.Clear();
						Console.Write("Ingrese la cantidad nueva: ---> ");
						string cantidad = Console.ReadLine();

						//verifica que sea un número entero
						if (esEntero(cantidad))
						{
							int cant = int.Parse(cantidad);
							//verifica que no sea negativo
							if (cant < 0)
							{
								Console.Clear();
								Console.WriteLine("La cantidad no puede ser un número negativo");
								Console.WriteLine("\nPresione una tecla para volver al menú");
								Console.ReadKey();
								seguir = false;
							}
							else
							{
								//actualiza la cantidad de artículos disponibles
								art.CantidadDisponible = cant;
								Console.Clear();
								Console.WriteLine("ARTÍCULO ACTUALIZADO\n");

								do
								{
									Console.Write("¿Desea actualizar otro artículo? S/N ---> ");
									string respuesta = Console.ReadLine();

									if (respuesta.ToUpper().Equals("S"))
									{
										seguir = false;
									}
									else if (respuesta.ToUpper().Equals("N"))
									{
										seguir = false;
										continuar = false;
									}
									else
									{
										Console.Clear();
										Console.WriteLine("Respuesta inválida. Intente de nuevo\n\n");
									}
								} while (continuar);
							}

						}

					} while (seguir);
				}
			} while (continuar);
		}

		/*FUNCIÓN CONSULTAR INVENTARIO*/
		public void consultaInventario()
		{
			//Lista todos los artículos
			Console.Clear();
			Console.WriteLine("****INVENTARIO****\n\n");
			Console.WriteLine("LISTA DE ARTÍCULOS\n");

			string str1 = "| ID ";
			string str2 = "| Descripción";
			string str3 = "| Precio vendedor";
			string str4 = "| Precio final";
			string str5 = "| Cantidad disponible";
			string str6 = "| Activo";

			Console.Write(str1.PadRight(20));
			Console.Write(str2.PadRight(20));
			Console.Write(str3.PadRight(20));
			Console.Write(str4.PadRight(20));
			Console.Write(str5.PadRight(20));
			Console.Write(str6.PadRight(20));
			Console.Write(" |\n");
			foreach (Articulo art in articulos)
			{
				if (art != null)
				{
					str1 = "| " + art.IdArticulo;
					str2 = "| " + art.Descripcion;
					str3 = "| " + art.PrecioVendedor;
					str4 = "| " + art.PrecioFinal;
					str5 = "| " + art.CantidadDisponible;
					str6 = "| " + art.Activo;

					Console.Write(str1.PadRight(20));
					Console.Write(str2.PadRight(20));
					Console.Write(str3.PadRight(20));
					Console.Write(str4.PadRight(20));
					Console.Write(str5.PadRight(20));
					Console.Write(str6.PadRight(20));
					Console.Write("  |\n");

				}
			}

			Console.WriteLine("\n\nPresione una tecla para volver al menú principal");
			Console.ReadKey();
		}

		/*FUNCIÓN SALIR DEL PROGRAMA*/
		public bool salir()
		{
			Console.Clear();

			do
			{
				Console.WriteLine("¿Está seguro de que desea salir? S/N");
				Console.Write("\nTu opción ---> ");
				string opcion = Console.ReadLine();

				if (opcion.Equals("S") || opcion.Equals("s"))
				{
					return true;
				}
				else if (opcion.Equals("N") || opcion.Equals("n"))
				{
					return false;
				}

				Console.Clear();
				Console.WriteLine("Por favor ingrese una opción válida. Intente de nuevo\n\n");

			} while (true);

		}

		///VALIDACIONES NECESARIAS///
		////////////////////////////
		///

		//valida que exista el artículo
		public bool existeArticulo(int id)
		{
			foreach (Articulo articulo in articulos)
			{
				if (articulo != null)
				{
					//si encuentra una coincidencia devuelve true
					if (articulo.IdArticulo == id)
					{
						return true;
					}
				}
			}
			//si no encuentra coincidencias devuelve false
			return false;
		}

		//valida que exista el vendedor
		public bool existeVendedor(string id)
		{
			foreach (Vendedor v in vendedores)
			{
				if (v != null)
				{
					//si encuentra coincidencias devuelve true
					if (v.IdVendedor.Equals(id))
						return true;
				}
			}
			//si no encuentra coincidencias devuelve false
			return false;
		}

		// Valida si el string corresponde a un número entero
		public bool esEntero(string data)
		{
			try
			{
				//se realizauna conversión a entero
				int numero = int.Parse(data);
				//si no salta una excepción se devuelve true
				return true;
			}
			catch (Exception)
			{
				Console.Clear();
				Console.WriteLine("Por favor ingrese solo números\n\n");
				//devuelve false indicando que el string no corresponde a un número
				return false;
			}
		}

		//valida que un string corresponda a un número racional
		public bool esDecimal(string data)
		{
			try
			{
				//se realiza la conversión
				decimal numero = decimal.Parse(data);
				//devuelve true indicando que efectivamente es un número racional
				return true;
			}
			catch (Exception)
			{
				Console.Clear();
				Console.WriteLine("Por favor ingrese solo números\n\n");
				//devuelve false indicando que el string no pertenece a un número racional
				return false;
			}
		}

		//valida que el número ingresado no sea negativo
		public bool esPositivo(string data)
		{
			try
			{
				int numero = int.Parse(data);
				//si es positivo devuelve true
				if (numero > 0)
					return true;
				//si es negativo devuelve false
				return false;
			}
			catch (Exception)
			{
				Console.Clear();
				//excepción en caso de no tratarde de un número
				Console.WriteLine("Por favor ingrese solo números positivos\n\n");
				return false;
			}
		}

		//valida que el formato de la fecha sea el correcto
		public bool fechaFormato(string dato)
		{
			try
			{
				//se convierte a formato fecha
				DateTime fecha = DateTime.Parse(dato);
				//en caso de ser correcto devuelve true
				return true;
			}
			catch (Exception)
			{
				Console.Clear();
				Console.WriteLine("El formato de fecha es incorrecto. Intente de nuevo\n\n");
				//devuelve false si la fecha tiene formato incorrecto
				return false;
			}
		}

		//valida la cantidad de artículos almacenados en el arreglo
		public bool cuentaArticulos()
		{
			//si la cantidad es 20 indica que ya no se pueden agregar más
			if (contArticulo == 20)
			{
				Console.Clear();
				Console.WriteLine("Ya no se pueden agregar más artículos\n\n");
				//devuelve false indicando que se alcanzó la cantidad máxima permitida
				return false;
			}
			//devuelve true si la cantidad de artículos no ha alcanzado el máximo permitido
			return true;
		}

		//cuenta la cantidad de artículos almacenados en el arreglo
		public bool cuentaCantArticulos()
		{
			//si la cantidad de artículos es mayor a 0 devuelve true
			if (contArticulo > 0)
				return true;
			//si la cantidad de artículos es 0 devuelve false
			return false;
		}

		//valida la cantidad de vendedores
		public bool cuentaVendedores()
		{
			//si la cantidad de vendedores alcanzó su máximo permitido devuelve false
			if (contVendedor == 20)
			{
				Console.Clear();
				Console.WriteLine("Ya no se pueden agregar más vendedores\n\n");
				return false;
			}
			//si la cantidad de vendedores aún no alcanza la cantidad máxima devuelve true
			return true;
		}

		//valida la cantidad de órdenes realizadas
		public bool cuentaOrden()
		{
			//si alcanzó su máximo lo notifica y devuelve false
			if (contOrden == 15)
			{
				Console.Clear();
				Console.WriteLine("Ya no se pueden agregar más órdenes\n\n");
				return false;
			}
			//si aún no se alcanza la cantidad máxima permitida devuelve true
			return true;
		}

		//cuenta la cantidad de detalles en cada órden
		public bool cuentaDetalle()
		{
			//si se alcanzó la cantidad máxima permitida devuelve false
			if (contDetalle == 15)
			{
				Console.Clear();
				Console.WriteLine("Ya no se pueden agregar más detalles\n\n");
				return false;
			}
			//si aún no se alcanza la cantidad máxima permitida devuelve true
			return true;
		}
	}


}

