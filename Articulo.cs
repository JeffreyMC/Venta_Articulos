using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
	class Articulo
	{
		public int IdArticulo { get; set; }
		public string Descripcion { get; set; }
		public bool Activo { get; set; }
		public decimal PrecioVendedor { get; set; }
		public decimal PrecioFinal { get; set; }
		public int CantidadDisponible { get; set; }

	}
}
