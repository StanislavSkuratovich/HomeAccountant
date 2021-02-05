using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Data;
using Core.Data.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Core.API.Controllers
{
    /// <summary>
    /// API for deal with types of records of money changes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        IUnitOfWork _unitOfWork;

        public TypesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }





        // GET: api/<MoneyChangeTypeController>
        [HttpGet]
        public async Task<IEnumerable<MoneyChangeType>> GetTypes()
        {
            var result = await _unitOfWork.MoneyChangeTypes.GetAllAsync();
            return result.ToList();

        }

        // GET api/<MoneyChangeTypeController>/5
        [HttpGet("{id}")]
        public async Task<MoneyChangeType> GetType(int id)
        {
            var result = await _unitOfWork.MoneyChangeTypes.GetAsync(id);
            return result;
        }

        // POST api/<MoneyChangeTypeController>
        [HttpPost]
        public async Task<MoneyChangeType> CreateType(MoneyChangeType type)
        {
            
            await _unitOfWork.MoneyChangeTypes.AddAsync(type);
            await _unitOfWork.SaveChangesAsync();
            return type;
        }

        // PUT api/<MoneyChangeTypeController>/5
        [HttpPut("{id}")]
        public async Task<MoneyChangeType> UpdateType(int id, MoneyChangeType type)
        {
            var typeInDb = await _unitOfWork.MoneyChangeTypes.GetAsync(id);
            typeInDb.Name = type.Name;
           await _unitOfWork.SaveChangesAsync();
            return typeInDb;
        }

        // DELETE api/<MoneyChangeTypeController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var typeInDb = await _unitOfWork.MoneyChangeTypes.GetAsync(id);
            await _unitOfWork.MoneyChangeTypes.RemoteAsync(typeInDb);
           await _unitOfWork.SaveChangesAsync();

        }
    }
}
