using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.DataAccess;

namespace HE.API.Controllers
{
    public class vIngredientsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/vIngredients
        public IQueryable<vIngredient> GetvIngredients()
        {
            return db.vIngredients;
        }

        // GET: api/vIngredients/5
        [ResponseType(typeof(vIngredient))]
        public async Task<IHttpActionResult> GetvIngredient(int id)
        {
            vIngredient vIngredient = await db.vIngredients.FindAsync(id);
            if (vIngredient == null)
            {
                return NotFound();
            }

            return Ok(vIngredient);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vIngredientExists(int id)
        {
            return db.vIngredients.Count(e => e.IngredientID == id) > 0;
        }
    }
}