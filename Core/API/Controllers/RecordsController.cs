using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Core.Data;
using Core.Data.Entities;
using Core.Servises.Interfaces;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Core.API.Controllers
{
    /// <summary>
    /// Endpoint used to interact with the records of money changes in the database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _logger;
        
        public RecordsController(IUnitOfWork unitOfWork, ILoggerService logger)
        {
           
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Returns a list of all records
        /// </summary>
        /// <returns></returns>
        // GET: api/<MoneyChanges>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bar = this.HttpContext;
            var foobar = HttpContext;
            var fofobar = (bar == foobar);
            var result = await _unitOfWork.MoneyChangeRecords.GetAllAsync();
            _logger.LogInfo(DateTime.Now.ToString() + "-  test");
            
            return Ok(result);
        }
        /// <summary>
        /// Returns a record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var zoo = HttpContext.Request;
            var result = await _unitOfWork.MoneyChangeRecords.GetAsync(id);
            if (null == result)
            {
                return NotFound(id);
            }
            return Ok(result);
        }
        /// <summary>
        /// Returns list of a month records of selected date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(RecordsController.ByMonth))]
        public async Task<IActionResult> ByMonth([FromBody] DateTime date)
        {
            var result = await _unitOfWork.MoneyChangeRecords.GetChangesOfMonthAsync(date);
            if (null == result)
            {
                return NotFound(date.ToShortDateString());
            }
            return Ok(result);
        }
        /// <summary>
        /// Returns list of a day records of selected date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(nameof(RecordsController.ByDay))]
        public async Task<IActionResult> ByDay([FromBody] DateTime date)
        {
            var result = await _unitOfWork.MoneyChangeRecords.GetChangesOfDayAsync(date);
            if (null == result)
            {
                return NotFound(date.ToShortDateString());
            }
            return Ok(result);
        }

        /// <summary>
        /// creates a new record
        /// </summary>
        /// <param name="moneyChange"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateRecord(MoneyChangeRecord moneyChange)
        {
            if(null == moneyChange.Date)
            {
                moneyChange.Date = DateTime.Now;
            }
            await _unitOfWork.MoneyChangeRecords.AddAsync(moneyChange);
            await _unitOfWork.SaveChangesAsync();
            return Ok(moneyChange);
        }

        /// <summary>
        /// Update  selected record if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <param name="moneyChange"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateRecord(int id, MoneyChangeRecord moneyChange)
        {
            var dbRecord = await _unitOfWork.MoneyChangeRecords.GetAsync(id);
            if(dbRecord == null)
            {
                return NotFound(moneyChange); 
            };
            dbRecord.Amount = moneyChange.Amount;
            dbRecord.Date = moneyChange.Date;
            dbRecord.MoneyChangeTypeId = moneyChange.MoneyChangeTypeId;
            dbRecord.UserId = moneyChange.UserId;
            await _unitOfWork.SaveChangesAsync();
            return Ok(dbRecord);
        }

        // DELETE api/<MoneyChanges>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var record = await _unitOfWork.MoneyChangeRecords.GetAsync(id);
            if (record == null) { return NotFound(id); };
            await _unitOfWork.MoneyChangeRecords.RemoteAsync(record);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }
    }
}
