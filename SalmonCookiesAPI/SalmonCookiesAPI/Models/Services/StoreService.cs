using Microsoft.EntityFrameworkCore;
using SalmonCookiesAPI.Data;
using SalmonCookiesAPI.Models.DTOs;
using SalmonCookiesAPI.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalmonCookiesAPI.Models.Services
{
    public class StoreService : IStore
    {
        private readonly CookieDbContext _context;

        public StoreService(CookieDbContext context)
        {
            _context = context;
        }

        public async Task<Store> Create(Store store)
        {
            _context.Entry(store).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task<StoreDTO> GetStore(int id)
        {
            Store store = await _context.Stores.FindAsync(id);
            StoreDTO newStore = new StoreDTO()
                {
                    Location = store.Location,
                    Description = store.Description,
                    MinimumCustomers = store.MinimumCustomers,
                    MaximumCustomers = store.MaximumCustomers,
                    AverageCookiePerSale = store.AverageCookiePerSale,
                    Owner = store.Owner,
                };
            newStore.HourlySales = RandomSales(newStore);
            return newStore;
        }

        public async Task<List<StoreDTO>> GetStores()
        {
            List<StoreDTO> stores = await _context.Stores
                .Select(s => new StoreDTO()
                {
                    Location = s.Location,
                    Description = s.Description,
                    MinimumCustomers = s.MinimumCustomers,
                    MaximumCustomers = s.MaximumCustomers,
                    AverageCookiePerSale = s.AverageCookiePerSale,
                    Owner = s.Owner,
                }).ToListAsync();
            foreach (StoreDTO store in stores)
            {
                store.HourlySales = RandomSales(store);
            }
            return stores;
        }

        public async Task<Store> UpdateStore(Store store)
        {
            _context.Entry(store).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return store;
        }

        public async Task Delete(int id)
        {
            Store store = await _context.Stores.FindAsync(id);
            _context.Entry(store).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public int[] RandomSales(StoreDTO store)
        {
            double[] hourFlux = new double[14] { 0.5, 0.75, 1.0, 0.6, 0.8, 1.0, 0.7, 0.6, 0.9, 0.7, 0.5, 0.3, 0.4, 0.6 };
            int[] returnArray = new int[14];
                for (int i = 0; i < 14; i++)
                {
                    Random rnd = new Random();
                    double thisHourSales = (double)rnd.Next(store.MinimumCustomers, store.MaximumCustomers) * hourFlux[i] * store.AverageCookiePerSale;
                    returnArray[i] = (int)thisHourSales;
                }
            return returnArray;
        }
    }
}
