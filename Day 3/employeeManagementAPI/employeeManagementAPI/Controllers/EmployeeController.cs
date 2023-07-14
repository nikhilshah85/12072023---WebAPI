using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using employeeManagementAPI.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace employeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        Employees eObj = new Employees();

        #region HttpGet Methods
        [HttpGet]
        [Route("/elist")]
        public IActionResult GetAllEmployees()
        {
            var allemp = eObj.GetAllEmployees();
            return Ok(allemp);
        }
        [HttpGet]
        [Route("/elist/empno/{id}")]
        public IActionResult GetEmpById(int id)
        {
            try
            {
                var emp = eObj.GetEmpById(id);
                return Ok(emp.GetEmpById(id));
            }
            catch (Exception es)
            {
                return NotFound(es.Message);                
            }           
        }


        [HttpGet]
        [Route("/elist/total")]
        public IActionResult GetTotalEmployee()
        {
            var total = eObj.GetTotalEmployees();
            return Ok(total);
        }

        [HttpGet]
        [Route("/elist/desigantion/{designation}")]
        public IActionResult GetEmployeeByDesigantion(string designation)
        {
            var emp = eObj.GetEmpByDesignation(designation);
            return Ok(emp);
        }
        #endregion

        #region HttpPost
        [HttpPost]
        [Route("/elist/add")]
        public IActionResult AddnewEmployee(Employees newEmp)
        {
          var addEmp =  eObj.AddEmployee(newEmp);
            return Created("", addEmp);
        }
        #endregion

        #region HttpPut
        [HttpPut]
        [Route("/elist/edit")]
        public IActionResult UpdateEmployee(Employees updates)
        {
            try
            {
                var update = eObj.UpdateEmployee(updates);
                return Accepted(update);
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);                
            }
        }
        #endregion
        #region HttpDelete
        [HttpDelete]
        [Route("/elist/delete/{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var delete = eObj.DeleteEmployee(id);
                return Accepted(delete);
            }
            catch (Exception es)
            {
                return NotFound(es.Message);
            }

            #endregion
        }
    }
}
