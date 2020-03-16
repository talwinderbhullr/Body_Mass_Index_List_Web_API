using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Body_Mass_Index_List_Web_API.Business;
using Body_Mass_Index_List_Web_API.Models;

namespace Body_Mass_Index_List_Web_API.Controllers
{
    //BMI controller
    [Route("api/[controller]")]
    [ApiController]
    public class BMIRecordsController : ControllerBase
    {
        private readonly Body_Mass_Index_List_Web_APIDataContext _context;

        public BMIRecordsController(Body_Mass_Index_List_Web_APIDataContext context)
        {
            _context = context;
        }

        // GET: api/BMIRecords
        //Gets all BMI records using linq 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BMIRecord>>> GetBMIRecord()
        {
            return await (from bmi in _context.BMIRecord select bmi).ToListAsync();
        }

        // GET: api/BMIRecords/5
        //Gets the BMI details record.
        [HttpGet("{id}")]
        public async Task<ActionResult<BMIRecord>> GetBMIRecord(int id)
        {
            var bMIRecord = await _context.BMIRecord.FindAsync(id);

            if (bMIRecord == null)
            {
                return NotFound();
            }

            return bMIRecord;
        }

        // PUT: api/BMIRecords/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Updates the BMI record.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBMIRecord(int id, BMIRecord bMIRecord)
        {
            if (id != bMIRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(bMIRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BMIRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BMIRecords
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //Adds  a BMI record to the database.
        [HttpPost]
        public async Task<ActionResult<BMIRecord>> PostBMIRecord(BMIRecord bMIRecord)
        {
            _context.BMIRecord.Add(bMIRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBMIRecord", new { id = bMIRecord.Id }, bMIRecord);
        }

        // DELETE: api/BMIRecords/5
        //Removes the BMI record from DB
        [HttpDelete("{id}")]
        public async Task<ActionResult<BMIRecord>> DeleteBMIRecord(int id)
        {
            var bMIRecord = await _context.BMIRecord.FindAsync(id);
            if (bMIRecord == null)
            {
                return NotFound();
            }

            _context.BMIRecord.Remove(bMIRecord);
            await _context.SaveChangesAsync();

            return bMIRecord;
        }

        //Check the existance of BMI record using a lamda
        private bool BMIRecordExists(int id)
        {
            return _context.BMIRecord.Any(e => e.Id == id);
        }
    }
}
