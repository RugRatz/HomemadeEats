using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HE.Domain;
using HE.API.DbContexts;

namespace HE.API.Controllers
{
    public class vRecipeInstructionsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/vRecipeInstructions
        public IQueryable<vRecipeInstruction> GetvRecipeInstructions()
        {
            return db.vRecipeInstructions;
        }

        // GET: api/vRecipeInstructions/5
        [ResponseType(typeof(vRecipeInstruction))]
        public async Task<IHttpActionResult> GetvRecipeInstruction(int id)
        {
            vRecipeInstruction vRecipeInstruction = await db.vRecipeInstructions.FindAsync(id);
            if (vRecipeInstruction == null)
            {
                return NotFound();
            }

            return Ok(vRecipeInstruction);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool vRecipeInstructionExists(int id)
        {
            return db.vRecipeInstructions.Count(e => e.InstructionID == id) > 0;
        }
    }
}