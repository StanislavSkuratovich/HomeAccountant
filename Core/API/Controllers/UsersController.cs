using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Data;
using Core.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Core.API.Controllers
{
    /// <summary>
    /// API for deal with users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        //public UsersController(DataContext context)
        public UsersController(IUnitOfWork unitOfWork)
        {
           // _unitOfWork = new UnitOfWork(context);
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var result = await _unitOfWork.AppUsers.GetAllAsync();

            return result.ToList();
            
        }

        // api/users/3
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            var user = await _unitOfWork.AppUsers.GetAsync(id);
            if (null == user)
            {
                return StatusCode(statusCode:404);
            }

            return user;
        }

        //POST api/users
        [HttpPost]
        public async Task<AppUser> CreateUser(AppUser user)
        {
           await _unitOfWork.AppUsers.AddAsync(user);
           await _unitOfWork.SaveChangesAsync();
            return user;
        }

        //PUT api/users
        [HttpPut]
        public async Task<AppUser> UpdateUser(int id, AppUser user)
        {
            var userInDatabase = await _unitOfWork.AppUsers.GetAsync(id);
            userInDatabase.UserName = user.UserName;
            await _unitOfWork.SaveChangesAsync();
            return userInDatabase;
        }

        //DELETE api/users
        [HttpDelete]
        public async Task DeleteUser(int id)
        {
           var userInDatabase = await _unitOfWork.AppUsers.GetAsync(id);
           await _unitOfWork.AppUsers.RemoteAsync(userInDatabase);
           await _unitOfWork.SaveChangesAsync();
        }


    }
}