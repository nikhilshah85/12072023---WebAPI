﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using employee_webapi_EF_.Models.EF;

namespace employee_webapi_EF_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class deptController : ControllerBase
    {
        private readonly EmployeeManagementApiDbContext _context;

        public deptController(EmployeeManagementApiDbContext context)
        {
            _context = context;
        }

        // GET: api/dept
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeptInfo>>> GetDeptInfos()
        {
          if (_context.DeptInfos == null)
          {
              return NotFound();
          }
            return await _context.DeptInfos.ToListAsync();
        }

        // GET: api/dept/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeptInfo>> GetDeptInfo(int id)
        {
          if (_context.DeptInfos == null)
          {
              return NotFound();
          }
            var deptInfo = await _context.DeptInfos.FindAsync(id);

            if (deptInfo == null)
            {
                return NotFound();
            }

            return deptInfo;
        }

        // PUT: api/dept/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeptInfo(int id, DeptInfo deptInfo)
        {
            if (id != deptInfo.DeptNo)
            {
                return BadRequest();
            }

            _context.Entry(deptInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeptInfoExists(id))
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

        // POST: api/dept
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DeptInfo>> PostDeptInfo(DeptInfo deptInfo)
        {
          if (_context.DeptInfos == null)
          {
              return Problem("Entity set 'EmployeeManagementApiDbContext.DeptInfos'  is null.");
          }
            _context.DeptInfos.Add(deptInfo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeptInfoExists(deptInfo.DeptNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeptInfo", new { id = deptInfo.DeptNo }, deptInfo);
        }

        // DELETE: api/dept/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeptInfo(int id)
        {
            if (_context.DeptInfos == null)
            {
                return NotFound();
            }
            var deptInfo = await _context.DeptInfos.FindAsync(id);
            if (deptInfo == null)
            {
                return NotFound();
            }

            _context.DeptInfos.Remove(deptInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeptInfoExists(int id)
        {
            return (_context.DeptInfos?.Any(e => e.DeptNo == id)).GetValueOrDefault();
        }
    }
}
