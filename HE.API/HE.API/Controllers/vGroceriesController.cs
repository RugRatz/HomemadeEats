using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.Domain;
using HE.API.DbContexts;

namespace HE.API.Controllers
{
    public class vGroceriesController : ApiController
    {
        private HE_IdentityDbContext db = new HE_IdentityDbContext();

        // GET: api/vGroceries
        public IQueryable<vGrocery> GetvGroceries()
        {
            return db.vGroceries;
        }

        // GET: api/vGroceries/5
        [ResponseType(typeof(vGrocery))]
        public async Task<IHttpActionResult> GetvGrocery(int id)
        {
            vGrocery vGrocery = await db.vGroceries.FindAsync(id);
            if (vGrocery == null)
            {
                return NotFound();
            }

            return Ok(vGrocery);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vGroceryExists(int id)
        {
            return db.vGroceries.Count(e => e.GroceryID == id) > 0;
        }
    }
}