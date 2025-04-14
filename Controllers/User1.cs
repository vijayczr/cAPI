using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.DataContext;
using WebApplication1.DataEntities;

namespace TRAVEAMER_DBO.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class User1:ControllerBase
    {
        private DataAccessContext _DBContext;

        public User1(DataAccessContext dataAccess)
        {
            _DBContext = dataAccess;
        }

        [HttpPost("New_User")]

        public async Task<IActionResult> NewUsers(Users input)
        {
            

            try
            {
                if (input == null)
                {
                    return BadRequest();
                }
                else
                {
                    var val = _DBContext.Users.Count();
                    var response = new Users();
                    response.code = String.Format("{0:00000000}", val+1);
                    response.First_Name = input.First_Name;
                    response.Last_Name = input.Last_Name;
                    response.Number = input.Number;
                    response.Email = input.Email;
                    response.country = input.country;
                    response.city = input.city;
                    response.state = input.state;
                    response.Gender = input.Gender;
                    _DBContext.Users.Add(response);
                    await _DBContext.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500,"error");
            }
        }

        [HttpGet("View_User")]

        public async Task<IActionResult> ViewUser(int Id)
        {


            try
            {

                // in services folder
                if (Id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    var response = await _DBContext.Users.Where(u => u.Id == Id).FirstOrDefaultAsync();
                    if(response == null)
                    {
                        return BadRequest();
                    }
                    return Ok(response);
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "error");
            }
        }

        [HttpPost("Update_id")]

        public async Task<IActionResult> Update_User(Users input)
        {


            try
            {

                // in services folder
                if (input.Id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    var response = await _DBContext.Users.Where(u => u.Id == input.Id).FirstOrDefaultAsync();
                    if (response == null)
                    {
                        return BadRequest();
                    }
                    response.First_Name = input.First_Name;
                    response.Last_Name = input.Last_Name;
                    response.Number = input.Number;
                    response.Email = input.Email;
                    response.country = input.country;
                    response.city = input.city;
                    response.state = input.state;
                    response.Gender = input.Gender;
                    await _DBContext.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "error");
            }
        }

        [HttpPost("Delete_id")]

        public async Task<IActionResult> Delete_User(int Id)
        {


            try
            {

                // in services folder
                if (Id == 0)
                {
                    return BadRequest();
                }
                else
                {
                    var response = await _DBContext.Users.Where(u => u.Id == Id).FirstOrDefaultAsync();
                    if (response == null)
                    {
                        return BadRequest();
                    }
                    _DBContext.Users.Remove(response);
                    await _DBContext.SaveChangesAsync();
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, "error");
            }
        }



    }
}
