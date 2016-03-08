using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.Domain;
using HE.API.DbContexts;

namespace HE.API.Controllers
{
    public class vCustomersController : ApiController
    {
        private HE_IdentityDbContext db = new HE_IdentityDbContext();

        // GET: api/vCustomers
        public IQueryable<vCustomer> GetvCustomers()
        {
            return db.vCustomers;
        }

        // GET: api/vCustomers/5
        [ResponseType(typeof(vCustomer))]
        public async Task<IHttpActionResult> GetvCustomer(string id)
        {
            vCustomer vCustomer = await db.vCustomers.FindAsync(id);
            if (vCustomer == null)
            {
                return NotFound();
            }

            return Ok(vCustomer);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vCustomerExists(string id)
        {
            return db.vCustomers.Count(e => e.CustomerProfileID == id) > 0;
        }
    }
}