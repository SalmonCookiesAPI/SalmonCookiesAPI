using SalmonCookiesAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalmonCookiesAPI.Models.Interfaces
{
    public interface IStore
    {
        // Create
        Task<Store> Create(Store store);

        // GET ALL

        Task<List<StoreDTO>> GetStores();

        // GET ONE BY ID
        Task<StoreDTO> GetStore(int id);

        // UPDATE
        Task<Store> UpdateStore(Store store);

        // DELETE
        Task Delete(int id);
    }
}
