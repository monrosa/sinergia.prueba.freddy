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
    public class MedidaController : ApiController
    {
        private ModelSinergiaInventario mcontext = new ModelSinergiaInventario();

        [HttpGet]
        public IEnumerable<INV_MEDIDA> Get()
        {
            List<INV_MEDIDA> lmedida = new List<INV_MEDIDA>();
            SqlParameter paMedida = null;

            paMedida = new SqlParameter("@PA_ID_MEDIDA", DBNull.Value);
            lmedida = mcontext.Database.SqlQuery<INV_MEDIDA>("dbo.INVSP_MEDIDA "
                                                                    , paMedida ).ToList();

            return lmedida;

        }
    }
}
