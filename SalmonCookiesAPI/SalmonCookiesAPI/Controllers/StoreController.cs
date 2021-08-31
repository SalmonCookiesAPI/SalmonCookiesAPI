using Microsoft.AspNetCore.Mvc;
using SalmonCookiesAPI.Models;
using SalmonCookiesAPI.Models.DTOs;
using SalmonCookiesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalmonCookiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStore _storeService;

        public StoreController(IStore s)
        {
            _storeService = s;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StoreDTO>>> GetStores()
        {
            var list = await _storeService.GetStores();
            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDTO>> GetStore(int id)
        {
            return await _storeService.GetStore(id);
        }

        [HttpPost]
        public async Task<ActionResult<Store>> CreateStore(Store store)
        {
            return await _storeService.Create(store);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Store>> PutStore(int id, Store store)
        {
            if(id != store.Id)
            {
                return BadRequest("ID does not exist. Please choose a valid index.");
            }
            var updatedStore = await _storeService.UpdateStore(store);
            return Ok(updatedStore);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            await _storeService.Delete(id);
            return NoContent();
        }
    }
}
