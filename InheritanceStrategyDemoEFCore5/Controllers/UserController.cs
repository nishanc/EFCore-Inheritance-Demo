using InheritanceStrategyDemoEFCore5.Data;
using InheritanceStrategyDemoEFCore5.Models.TPCModels;
using InheritanceStrategyDemoEFCore5.Models.TPHModels;
using InheritanceStrategyDemoEFCore5.Models.TPTModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InheritanceStrategyDemoEFCore5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        #region TPH Related Endpoints
        [HttpPost("create-tph-teacher")]
        public async Task<IActionResult> CreateTPHTeacher([FromBody] TPHTeacher teacher)
        {
            await _context.TPHUsers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPost("create-tph-student")]
        public async Task<IActionResult> CreateTPHStudent([FromBody] TPHStudent student)
        {
            await _context.TPHUsers.AddAsync(student);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [Route("get-tph-user/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTPHUser(int id)
        {
            var user = await _context.TPHUsers.FindAsync(id);
            return Ok(user);
        }

        [HttpGet("get-tph-teachers-only")]
        public async Task<IActionResult> GetTPHTeachers()
        {
            // Using discriminator (shadow property to filter rows)
            var users = await _context.TPHUsers.Where(b => EF.Property<string>(b, "UserType") == "Teacher").ToListAsync();
            return Ok(users);
        }
        #endregion

        #region TPT Related Endpoints
        [HttpPost("create-tpt-teacher")]
        public async Task<IActionResult> CreateTPTTeacher([FromBody] TPTTeacher teacher)
        {
            await _context.TPTTeachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPost("create-tpt-student")]
        public async Task<IActionResult> CreateTPTStudent([FromBody] TPTStudent student)
        {
            await _context.TPTStudents.AddAsync(student);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [Route("get-tpt-user/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTPTUser(int id)
        {
            var user = await _context.TPTUsers.FindAsync(id);
            return Ok(user);
        }
        #endregion

        #region TPC Related Endpoints
        [HttpPost("create-tpc-teacher")]
        public async Task<IActionResult> CreateTPCTeacher([FromBody] TPCTeacher teacher)
        {
            await _context.TPCTeachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [HttpPost("create-tpc-student")]
        public async Task<IActionResult> CreateTPCStudent([FromBody] TPCStudent student)
        {
            await _context.TPCStudents.AddAsync(student);
            await _context.SaveChangesAsync();
            return StatusCode(201);
        }

        [Route("get-tpc-teacher/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTPCTeacher(int id)
        {
            var user = await _context.TPCTeachers.FindAsync(id);
            return Ok(user);
        }

        [Route("get-tpc-student/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTPCStudent(int id)
        {
            var user = await _context.TPCStudents.FindAsync(id);
            return Ok(user);
        }
        #endregion
    }
}
