using entidad.inventario;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace backend.api.inventario.Controllers
{
    public class ProductoController : ApiController
    {
        private ModelSinergiaInventario mcontext = new ModelSinergiaInventario();

        [HttpGet]
        public IEnumerable<INV_PRODUCTO> Get()
        {
            List<INV_PRODUCTO> lstDatosProductos;
            INV_MARCA imarca = new INV_MARCA();
            INV_CATEGORIA icategoria = new INV_CATEGORIA();
            INV_MEDIDA imedida = new INV_MEDIDA();
            INV_PROVEEDOR iproveedor = new INV_PROVEEDOR();
            
            SqlParameter paMarca = null;
            SqlParameter paCategoria = null;
            SqlParameter paMedida = null;
            SqlParameter paProveedor = null;

            lstDatosProductos = mcontext.Database.SqlQuery<INV_PRODUCTO>("dbo.INVSP_PRODUCTO ").ToList();
            foreach (INV_PRODUCTO item in lstDatosProductos)
            {
                paMarca = new SqlParameter("@PA_ID_MARCA", item.INV_MARCA_ID);
                imarca = mcontext.Database.SqlQuery<INV_MARCA>("dbo.INVSP_MARCA @PA_ID_MARCA "
                                                                    , paMarca).ToList().FirstOrDefault();

                paCategoria = new SqlParameter("@PA_ID_CATEGORIA", item.INV_CATEGORIA_ID);
                icategoria = mcontext.Database.SqlQuery<INV_CATEGORIA>("dbo.INVSP_CATEGORIA @PA_ID_CATEGORIA "
                                                                    , paCategoria ).ToList().FirstOrDefault();

                paMedida = new SqlParameter("@PA_ID_MEDIDA", item.INV_MEDIDA_ID);
                imedida = mcontext.Database.SqlQuery<INV_MEDIDA>("dbo.INVSP_MEDIDA @PA_ID_MEDIDA "
                                                                    , paMedida).ToList().FirstOrDefault();

                paProveedor = new SqlParameter("@PA_ID_PROVEEDOR", item.INV_PROVEEDOR_ID);
                iproveedor = mcontext.Database.SqlQuery<INV_PROVEEDOR>("dbo.INVSP_PROVEEDOR @PA_ID_PROVEEDOR"
                                                                    , paProveedor ).ToList().FirstOrDefault();


                lstDatosProductos.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_MARCA = imarca;

                lstDatosProductos.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_CATEGORIA = icategoria;
                lstDatosProductos.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_MEDIDA = imedida;
                lstDatosProductos.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_PROVEEDOR = iproveedor;

            }



            //return _context.ING_PRODUCTO.ToList();
            return lstDatosProductos;

        }

        [HttpGet]
        public INV_PRODUCTO Get(int id)
        {
            List<INV_PRODUCTO> lstDatosProducto;
            INV_PRODUCTO producto;

            INV_MARCA marca = new INV_MARCA();
            INV_CATEGORIA categoria = new INV_CATEGORIA();
            INV_MEDIDA medida = new INV_MEDIDA();
            INV_PROVEEDOR proveedor = new INV_PROVEEDOR();

            //SqlParameter param = new SqlParameter("@origen", origen);
            //SqlParameter param1 = new SqlParameter("@periodo", periodo);
            SqlParameter paProducto = null;

            SqlParameter paMarca = null;
            SqlParameter paCategoria = null;
            SqlParameter paMedida = null;
            SqlParameter paProveedor = null;

            paProducto = new SqlParameter("@PA_ID_PRODUCTO", id);
            lstDatosProducto = mcontext.Database.SqlQuery<INV_PRODUCTO>("dbo.INVSP_PRODUCTO @PA_ID_PRODUCTO"
                                                                    , paProducto).ToList();
            foreach (INV_PRODUCTO item in lstDatosProducto)
            {
                paMarca = new SqlParameter("@PA_ID_MARCA", item.INV_MARCA_ID);
                marca = mcontext.Database.SqlQuery<INV_MARCA>("dbo.INVSP_MARCA @PA_ID_MARCA "
                                                                    , paMarca).ToList().FirstOrDefault();

                paCategoria = new SqlParameter("@PA_ID_CATEGORIA", item.INV_CATEGORIA_ID);
                categoria = mcontext.Database.SqlQuery<INV_CATEGORIA>("dbo.INVSP_CATEGORIA @PA_ID_CATEGORIA "
                                                                    , paCategoria).ToList().FirstOrDefault();

                paMedida = new SqlParameter("@PA_ID_MEDIDA", item.INV_MEDIDA_ID);
                medida = mcontext.Database.SqlQuery<INV_MEDIDA>("dbo.INVSP_MEDIDA @PA_ID_MEDIDA "
                                                                    , paMedida ).ToList().FirstOrDefault();

                paProveedor = new SqlParameter("@PA_ID_PROVEEDOR", item.INV_PROVEEDOR_ID);
                proveedor = mcontext.Database.SqlQuery<INV_PROVEEDOR>("dbo.INVSP_PROVEEDOR @PA_ID_PROVEEDOR "
                                                                    , paProveedor ).ToList().FirstOrDefault();


                lstDatosProducto.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_MARCA = marca;

                lstDatosProducto.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_CATEGORIA = categoria;
                lstDatosProducto.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_MEDIDA = medida;
                lstDatosProducto.Find(x => x.INV_PRODUCTO_ID == item.INV_PRODUCTO_ID).INV_PROVEEDOR = proveedor;

            }

            producto = lstDatosProducto.FirstOrDefault();

            //return _context.ING_PRODUCTO.ToList();
            return producto;

        }

        [HttpPost]
        public IHttpActionResult agregarproducto([FromBody]INV_PRODUCTO pro)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mcontext.INV_PRODUCTO.Add(pro);
                    mcontext.SaveChanges();
                    return Ok(pro);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }



            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IHttpActionResult actualizarproducto(string id, [FromBody]INV_PRODUCTO pro)
        {
            if (ModelState.IsValid)
            {
                INV_PRODUCTO prodExiste = null;

                prodExiste = (from prod in mcontext.INV_PRODUCTO
                                  where prod.INV_PRODUCTO_CODIGO == id
                                  select prod).ToList().FirstOrDefault();
                if (prodExiste != null)
                {

                    try
                    {

                        prodExiste.INV_CANTIDAD = pro.INV_CANTIDAD;
                        prodExiste.INV_PRECIO_UNITARIO = pro.INV_PRECIO_UNITARIO;
                        prodExiste.INV_DESCRIPCION = pro.INV_DESCRIPCION;
                        prodExiste.INV_CATEGORIA_ID = pro.INV_CATEGORIA_ID;
                        prodExiste.INV_MARCA_ID = pro.INV_MARCA_ID;
                        prodExiste.INV_MEDIDA_ID = pro.INV_MEDIDA_ID;
                        prodExiste.INV_PROVEEDOR_ID = pro.INV_PROVEEDOR_ID;

                        mcontext.SaveChanges();
                        return Ok();

                    }
                    catch (Exception ex)
                    {
                        return BadRequest();
                    }

                }
                else
                {
                    return NotFound();
                }

            }
            else
            {
                return BadRequest();
            }

        }
    }
}
