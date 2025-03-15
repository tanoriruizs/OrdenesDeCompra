using Microsoft.AspNetCore.Mvc;
using OrdenesDeCompra.Models;
using Newtonsoft.Json;

namespace OrdenesDeCompra.Controllers
{
    public class OrdenDeCompraController : Controller
    {
        private const string SessionKey = "OrdenesCompra";

        private List<OrdenDeCompra> ObtenerOrdenes()
        {
            var sessionData = HttpContext.Session.GetString(SessionKey);

            if (sessionData == null)
            {
                var ordenesEjemplo = new List<OrdenDeCompra>
                {
                    new OrdenDeCompra { Id = 1, NumeroDeOrden = "OC-1001", Fecha = DateTime.Now.AddDays(-1), Proveedor = "Proveedor A", MontoTotal = 1500.50M },
                    new OrdenDeCompra { Id = 2, NumeroDeOrden = "OC-1002", Fecha = DateTime.Now.AddDays(-2), Proveedor = "Proveedor B", MontoTotal = 2500.75M },
                    new OrdenDeCompra { Id = 3, NumeroDeOrden = "OC-1003", Fecha = DateTime.Now.AddDays(-3), Proveedor = "Proveedor C", MontoTotal = 3200.00M },
                    new OrdenDeCompra { Id = 4, NumeroDeOrden = "OC-1004", Fecha = DateTime.Now.AddDays(-4), Proveedor = "Proveedor D", MontoTotal = 4500.30M },
                    new OrdenDeCompra { Id = 5, NumeroDeOrden = "OC-1005", Fecha = DateTime.Now.AddDays(-5), Proveedor = "Proveedor E", MontoTotal = 1800.90M },
                    new OrdenDeCompra { Id = 6, NumeroDeOrden = "OC-1006", Fecha = DateTime.Now.AddDays(-6), Proveedor = "Proveedor F", MontoTotal = 3700.20M },
                    new OrdenDeCompra { Id = 7, NumeroDeOrden = "OC-1007", Fecha = DateTime.Now.AddDays(-7), Proveedor = "Proveedor G", MontoTotal = 2900.50M },
                    new OrdenDeCompra { Id = 8, NumeroDeOrden = "OC-1008", Fecha = DateTime.Now.AddDays(-8), Proveedor = "Proveedor H", MontoTotal = 4100.75M },
                    new OrdenDeCompra { Id = 9, NumeroDeOrden = "OC-1009", Fecha = DateTime.Now.AddDays(-9), Proveedor = "Proveedor I", MontoTotal = 5100.60M },
                    new OrdenDeCompra { Id = 10, NumeroDeOrden = "OC-1010", Fecha = DateTime.Now.AddDays(-10), Proveedor = "Proveedor J", MontoTotal = 6200.40M },
                    new OrdenDeCompra { Id = 11, NumeroDeOrden = "OC-1011", Fecha = DateTime.Now.AddDays(-11), Proveedor = "Proveedor K", MontoTotal = 2200.80M },
                    new OrdenDeCompra { Id = 12, NumeroDeOrden = "OC-1012", Fecha = DateTime.Now.AddDays(-12), Proveedor = "Proveedor L", MontoTotal = 3300.90M },
                    new OrdenDeCompra { Id = 13, NumeroDeOrden = "OC-1013", Fecha = DateTime.Now.AddDays(-13), Proveedor = "Proveedor M", MontoTotal = 5500.10M },
                    new OrdenDeCompra { Id = 14, NumeroDeOrden = "OC-1014", Fecha = DateTime.Now.AddDays(-14), Proveedor = "Proveedor N", MontoTotal = 4400.50M },
                    new OrdenDeCompra { Id = 15, NumeroDeOrden = "OC-1015", Fecha = DateTime.Now.AddDays(-15), Proveedor = "Proveedor O", MontoTotal = 2600.20M },
                    new OrdenDeCompra { Id = 16, NumeroDeOrden = "OC-1016", Fecha = DateTime.Now.AddDays(-16), Proveedor = "Proveedor P", MontoTotal = 3900.60M },
                    new OrdenDeCompra { Id = 17, NumeroDeOrden = "OC-1017", Fecha = DateTime.Now.AddDays(-17), Proveedor = "Proveedor Q", MontoTotal = 4800.00M },
                    new OrdenDeCompra { Id = 18, NumeroDeOrden = "OC-1018", Fecha = DateTime.Now.AddDays(-18), Proveedor = "Proveedor R", MontoTotal = 5300.80M },
                    new OrdenDeCompra { Id = 19, NumeroDeOrden = "OC-1019", Fecha = DateTime.Now.AddDays(-19), Proveedor = "Proveedor S", MontoTotal = 2100.30M },
                    new OrdenDeCompra { Id = 20, NumeroDeOrden = "OC-1020", Fecha = DateTime.Now.AddDays(-20), Proveedor = "Proveedor T", MontoTotal = 3000.50M }
                };

                HttpContext.Session.SetString(SessionKey, JsonConvert.SerializeObject(ordenesEjemplo));

                return ordenesEjemplo;
            }

            return JsonConvert.DeserializeObject<List<OrdenDeCompra>>(sessionData);
        }

        private void GuardarOrdenes(List<OrdenDeCompra> ordenes)
        {
            HttpContext.Session.SetString(SessionKey, JsonConvert.SerializeObject(ordenes));
        }

        public IActionResult Index()
        {
            var ordenes = ObtenerOrdenes();
            return View(ordenes);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(OrdenDeCompra orden)
        {
            var ordenes = ObtenerOrdenes();
            orden.Id = ordenes.Any() ? ordenes.Max(o => o.Id) + 1 : 1;
            ordenes.Add(orden);
            GuardarOrdenes(ordenes);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var orden = ObtenerOrdenes().FirstOrDefault(o => o.Id == id);
            return View(orden);
        }

        [HttpPost]
        public IActionResult Editar(OrdenDeCompra orden)
        {
            var ordenes = ObtenerOrdenes();
            var index = ordenes.FindIndex(o => o.Id == orden.Id);
            if (index != -1)
            {
                ordenes[index] = orden;
                GuardarOrdenes(ordenes);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            var ordenes = ObtenerOrdenes();
            ordenes.RemoveAll(o => o.Id == id);
            GuardarOrdenes(ordenes);
            return RedirectToAction("Index");
        }
    }
}
