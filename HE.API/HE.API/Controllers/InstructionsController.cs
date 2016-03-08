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
    public class InstructionsController : ApiController
    {
        private HE_DbContext db = new HE_DbContext();

        // GET: api/Instructions
        public IQueryable<Instruction> GetInstructions()
        {
            return db.Instructions;
        }

        // GET: api/Instructions/5
        [ResponseType(typeof(Instruction))]
        public async Task<IHttpActionResult> GetInstruction(int id)
        {
            Instruction instruction = await db.Instructions.FindAsync(id);
            if (instruction == null)
            {
                return NotFound();
            }

            return Ok(instruction);
        }

        // PUT: api/Instructions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutInstruction(int id, Instruction instruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instruction.InstructionID)
            {
                return BadRequest();
            }

            db.Entry(instruction).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstructionExists(id))
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

        // POST: api/Instructions
        [ResponseType(typeof(Instruction))]
        public async Task<IHttpActionResult> PostInstruction(Instruction instruction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Instructions.Add(instruction);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = instruction.InstructionID }, instruction);
        }

        // DELETE: api/Instructions/5
        [ResponseType(typeof(Instruction))]
        public async Task<IHttpActionResult> DeleteInstruction(int id)
        {
            Instruction instruction = await db.Instructions.FindAsync(id);
            if (instruction == null)
            {
                return NotFound();
            }

            db.Instructions.Remove(instruction);
            await db.SaveChangesAsync();

            return Ok(instruction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstructionExists(int id)
        {
            return db.Instructions.Count(e => e.InstructionID == id) > 0;
        }
    }
}