using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.DataAccess;

namespace HE.API.Controllers
{
    public class vHomemadeItemsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/vHomemadeItems
        public IQueryable<vHomemadeItem> GetvHomemadeItems()
        {
            return db.vHomemadeItems;
        }

        // GET: api/vHomemadeItems/5
        [ResponseType(typeof(vHomemadeItem))]
        public async Task<IHttpActionResult> GetvHomemadeItem(int id)
        {
            vHomemadeItem vHomemadeItem = await db.vHomemadeItems.FindAsync(id);
            if (vHomemadeItem == null)
            {
                return NotFound();
            }

            return Ok(vHomemadeItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vHomemadeItemExists(int id)
        {
            return db.vHomemadeItems.Count(e => e.HomemadeItemID == id) > 0;
        }
    }
}