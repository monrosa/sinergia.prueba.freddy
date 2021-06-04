using entidad.inventario;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace backend.api.inventario.Controllers
{
    public class ProveedorController : ApiController
    {
        private ModelSinergiaInventario mcontext = new ModelSinergiaInventario();

        [HttpGet]
        public IEnumerable<INV_PROVEEDOR> Get()
        {
            
            List<INV_PROVEEDOR> lproveedor = new List<INV_PROVEEDOR>();
            
            SqlParameter paProveedor = null;

            paProveedor = new SqlParameter("@PA_ID_PROVEEDOR", DBNull.Value);
            lproveedor = mcontext.Database.SqlQuery<INV_PROVEEDOR>("dbo.INVSP_PROVEEDOR "
                                                                    , paProveedor ).ToList();

            return lproveedor;

        }
    }
}
