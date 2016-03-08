using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.Domain;
using HE.API.DbContexts;

namespace HE.API.Controllers
{
    public class CustomerContactInfoesController : ApiController
    {
        private HE_IdentityDbContext db = new HE_IdentityDbContext();

        // GET: api/CustomerContactInfoes
        public IQueryable<CustomerContactInfo> GetCustomerContactInfoes()
        {
            return db.CustomerContactInfoes;
        }

        // GET: api/CustomerContactInfoes/5
        [ResponseType(typeof(CustomerContactInfo))]
        public async Task<IHttpActionResult> GetCustomerContactInfo(int id)
        {
            CustomerContactInfo customerContactInfo = await db.CustomerContactInfoes.FindAsync(id);
            if (customerContactInfo == null)
            {
                return NotFound();
            }

            return Ok(customerContactInfo);
        }

        // PUT: api/CustomerContactInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCustomerContactInfo(int id, CustomerContactInfo customerContactInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerContactInfo.CustomerContactInfoID)
            {
                return BadRequest();
            }

            db.Entry(customerContactInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerContactInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CustomerContactInfoes
        [ResponseType(typeof(CustomerContactInfo))]
        public async Task<IHttpActionResult> PostCustomerContactInfo(CustomerContactInfo customerContactInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerContactInfoes.Add(customerContactInfo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = customerContactInfo.CustomerContactInfoID }, customerContactInfo);
        }

        // DELETE: api/CustomerContactInfoes/5
        [ResponseType(typeof(CustomerContactInfo))]
        public async Task<IHttpActionResult> DeleteCustomerContactInfo(int id)
        {
            CustomerContactInfo customerContactInfo = await db.CustomerContactInfoes.FindAsync(id);
            if (customerContactInfo == null)
            {
                return NotFound();
            }

            db.CustomerContactInfoes.Remove(customerContactInfo);
            await db.SaveChangesAsync();

            return Ok(customerContactInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerContactInfoExists(int id)
        {
            return db.CustomerContactInfoes.Count(e => e.CustomerContactInfoID == id) > 0;
        }
    }
}