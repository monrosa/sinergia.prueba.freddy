using entidad.inventario;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace front.mvc.inventario.Controllers
{
    public class HomeController : Controller
    {
        ModelSinergiaInventario _context = new ModelSinergiaInventario();
        string BaseURLapi = "http://localhost:9388/";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> vproducto()
        {
            List<INV_PRODUCTO> dataProducto = new List<INV_PRODUCTO>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseURLapi);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //llama a los productos
                HttpResponseMessage res = await client.GetAsync("api/producto/");
                if (res.IsSuccessStatusCode)
                {
                    var proResponse = res.Content.ReadAsStringAsync().Result;
                    dataProducto = JsonConvert.DeserializeObject<List<INV_PRODUCTO>>(proResponse);
                }
                return View(dataProducto);
            }

        }

        public async Task<ActionResult> nproducto()
        {

            #region .:Categoria

            List<INV_CATEGORIA> ListCategoria = new List<INV_CATEGORIA>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage hrm = await hclient.GetAsync("api/categoria/");
                if (hrm.IsSuccessStatusCode)
                {
                    var result = hrm.Content.ReadAsStringAsync().Result;
                    ListCategoria = JsonConvert.DeserializeObject<List<INV_CATEGORIA>>(result);
                }

            }

            List<SelectListItem> liSelectcategoria = new List<SelectListItem>();
            foreach (INV_CATEGORIA item in ListCategoria)
            {
                liSelectcategoria.Add(new SelectListItem() { Text = item.INV_DESCRIPCION_CATEGORIA, Value = item.INV_CATEGORIA_ID.ToString() });
            }

            ViewBag.VBcategoria = new SelectList(liSelectcategoria, "Value", "Text");

            #endregion

            #region .:Medida

            List<INV_MEDIDA> listaMedida = new List<INV_MEDIDA>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage hrm = await hclient.GetAsync("api/medida/");
                if (hrm.IsSuccessStatusCode)
                {
                    var result = hrm.Content.ReadAsStringAsync().Result;
                    listaMedida = JsonConvert.DeserializeObject<List<INV_MEDIDA>>(result);
                }

            }

            List<SelectListItem> liSelectMedida = new List<SelectListItem>();
            foreach (INV_MEDIDA item in listaMedida)
            {
                liSelectMedida.Add(new SelectListItem() { Text = item.INV_DETALLE_MEDIDA, Value = item.INV_ID_MEDIDA.ToString() });
            }

            ViewBag.VBmedida = new SelectList(liSelectMedida, "Value", "Text");

            #endregion

            #region ..Proveedor

            List<INV_PROVEEDOR> listaProveedora = new List<INV_PROVEEDOR>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage hrm = await hclient.GetAsync("api/proveedor/");
                if (hrm.IsSuccessStatusCode)
                {
                    var result = hrm.Content.ReadAsStringAsync().Result;
                    listaProveedora = JsonConvert.DeserializeObject<List<INV_PROVEEDOR>>(result);
                }

            }

            List<SelectListItem> liSelectProveedor = new List<SelectListItem>();
            foreach (INV_PROVEEDOR item in listaProveedora)
            {
                liSelectProveedor.Add(new SelectListItem() { Text = item.INV_DETALLE_PROVEEDOR, Value = item.INV_PROVEEDOR_ID.ToString() });
            }

            ViewBag.VBproveedor = new SelectList(liSelectProveedor, "Value", "Text");

            #endregion

            #region .:Marca

            List<INV_MARCA> listaMarca = new List<INV_MARCA>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage hrm = await hclient.GetAsync("api/marca/");
                if (hrm.IsSuccessStatusCode)
                {
                    var result = hrm.Content.ReadAsStringAsync().Result;
                    listaMarca = JsonConvert.DeserializeObject<List<INV_MARCA>>(result);
                }

            }

            List<SelectListItem> liSelectMarca = new List<SelectListItem>();
            foreach (INV_MARCA item in listaMarca)
            {
                liSelectMarca.Add(new SelectListItem() { Text = item.INV_DETALLE_MARCA, Value = item.INV_MARCA_ID.ToString() });
            }

            ViewBag.VBmarca = new SelectList(liSelectMarca, "Value", "Text");

            #endregion

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> nproducto(INV_PRODUCTO producto)
        {
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi + "api/producto/");
                var hrmt = hclient.PostAsJsonAsync<INV_PRODUCTO>("productos", producto);
                hrmt.Wait();
                var result = hrmt.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("vproducto");
                }
            }
            ModelState.AddModelError(string.Empty, "Error, contacto con el jefe de area");
            return View(producto);
        }

        public async Task<ActionResult> eproducto(int id)
        {
            #region .:Categoria

            List<INV_CATEGORIA> listaCategoria = new List<INV_CATEGORIA>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage htmt = await hclient.GetAsync("api/categoria/");
                if (htmt.IsSuccessStatusCode)
                {
                    var result = htmt.Content.ReadAsStringAsync().Result;
                    listaCategoria = JsonConvert.DeserializeObject<List<INV_CATEGORIA>>(result);
                }

            }

            List<SelectListItem> liSelectcategoria = new List<SelectListItem>();
            foreach (INV_CATEGORIA item in listaCategoria)
            {
                liSelectcategoria.Add(new SelectListItem() { Text = item.INV_DESCRIPCION_CATEGORIA, Value = item.INV_CATEGORIA_ID.ToString() });
            }

            ViewBag.VBcategoria = new SelectList(liSelectcategoria, "Value", "Text");

            #endregion

            #region .:Medida

            List<INV_MEDIDA> listaMedida = new List<INV_MEDIDA>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage hrmt = await hclient.GetAsync("api/medida/");
                if (hrmt.IsSuccessStatusCode)
                {
                    var result = hrmt.Content.ReadAsStringAsync().Result;
                    listaMedida = JsonConvert.DeserializeObject<List<INV_MEDIDA>>(result);
                }

            }

            List<SelectListItem> lSelectMedida = new List<SelectListItem>();
            foreach (INV_MEDIDA item in listaMedida)
            {
                lSelectMedida.Add(new SelectListItem() { Text = item.INV_DETALLE_MEDIDA, Value = item.INV_ID_MEDIDA.ToString() });
            }

            ViewBag.VBmedida = new SelectList(lSelectMedida, "Value", "Text");

            #endregion

            #region .:Proveedor

            List<INV_PROVEEDOR> listaProveedora = new List<INV_PROVEEDOR>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //llama a los productos
                HttpResponseMessage hrmt = await hclient.GetAsync("api/proveedor/");
                if (hrmt.IsSuccessStatusCode)
                {
                    var result = hrmt.Content.ReadAsStringAsync().Result;
                    listaProveedora = JsonConvert.DeserializeObject<List<INV_PROVEEDOR>>(result);
                }

            }

            List<SelectListItem> liSelectProveedor = new List<SelectListItem>();
            foreach (INV_PROVEEDOR item in listaProveedora)
            {
                liSelectProveedor.Add(new SelectListItem() { Text = item.INV_DETALLE_PROVEEDOR, Value = item.INV_PROVEEDOR_ID.ToString() });
            }

            liSelectProveedor.First().Selected = true;

            ViewBag.VBproveedor = new SelectList(liSelectProveedor, "Value", "Text");

            #endregion


            #region .:Marca

            List<INV_MARCA> listaMarca = new List<INV_MARCA>();
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                hclient.DefaultRequestHeaders.Clear();
                hclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //llama a los productos
                HttpResponseMessage hrmt = await hclient.GetAsync("api/marca/");
                if (hrmt.IsSuccessStatusCode)
                {
                    var result = hrmt.Content.ReadAsStringAsync().Result;
                    listaMarca = JsonConvert.DeserializeObject<List<INV_MARCA>>(result);
                }

            }

            List<SelectListItem> liSelectMarca = new List<SelectListItem>();
            foreach (INV_MARCA item in listaMarca)
            {
                liSelectMarca.Add(new SelectListItem() { Text = item.INV_DETALLE_MARCA, Value = item.INV_MARCA_ID.ToString() });
            }

            ViewBag.VBmarca = new SelectList(liSelectMarca, "Value", "Text");

            #endregion

            INV_PRODUCTO producto = null;
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                var hrmt = hclient.GetAsync($"api/producto/{id}");
                hrmt.Wait();
                var result = hrmt.Result;
                if (result.IsSuccessStatusCode)
                {
                    var hct = result.Content.ReadAsAsync<INV_PRODUCTO>();
                    hct.Wait();
                    producto = hct.Result;
                }
            }
            return View(producto);

        }

        [HttpPost]
        public ActionResult eproducto(INV_PRODUCTO producto)
        {
            using (var hclient = new HttpClient())
            {
                hclient.BaseAddress = new Uri(BaseURLapi);
                var hrmt = hclient.PutAsJsonAsync<INV_PRODUCTO>($"api/producto/{producto.INV_PRODUCTO_CODIGO}", producto);
                hrmt.Wait();
                var result = hrmt.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("producto");
                }
            }
            return View(producto);
        }
    }
}