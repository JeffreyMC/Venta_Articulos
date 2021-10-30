using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
	class OrdenCompra
	{
		public int IdCompra { get; set; }
		public DateTime Fecha { get; set; }
		public Vendedor InfoVendedor { get; set; }
		public OrdenCompraDetalle[] Detalle { get; set; }
	}
}
