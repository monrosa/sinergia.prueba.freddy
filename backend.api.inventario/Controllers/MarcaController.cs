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
    public class MarcaController : ApiController
    {
        private ModelSinergiaInventario mcontext = new ModelSinergiaInventario();

        [HttpGet]
        public IEnumerable<INV_MARCA> Get()
        {
            List<INV_MARCA> lmarca = new List<INV_MARCA>();

            SqlParameter paMARCA = null;

            paMARCA = new SqlParameter("@PA_ID_MARCA", DBNull.Value);
            lmarca = mcontext.Database.SqlQuery<INV_MARCA>("dbo.INVSP_MARCA "
                                                                    , paMARCA ).ToList();

            return lmarca;

        }
    }
}
