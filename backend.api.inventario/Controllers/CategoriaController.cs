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
    public class CategoriaController : ApiController
    {
        private ModelSinergiaInventario mcontext = new ModelSinergiaInventario();

        [HttpGet]
        public IEnumerable<INV_CATEGORIA> Get()
        {
            List<INV_CATEGORIA> lcategoria = new List<INV_CATEGORIA>();

            SqlParameter paCategoria = null;

            paCategoria = new SqlParameter("@PA_ID_CATEGORIA", DBNull.Value);
            lcategoria = mcontext.Database.SqlQuery<INV_CATEGORIA>("dbo.INVSP_CATEGORIA "
                                                                    , paCategoria ).ToList();

            return lcategoria;

        }
    }
}
