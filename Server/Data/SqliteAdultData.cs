using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Server.DataAccess;
using Server.Models;

namespace Server.Data
{
    public class SqliteAdultData : IAdultData
    {
        private FamilyDBContext context;

        public SqliteAdultData(FamilyDBContext context)
        {
            this.context = context;
        }
        public async Task<IList<Adult>> GetAdults()
        {
            return await context.Adults.ToListAsync();
        }

        public async Task<Adult> AddAdult(Adult adult)
        {
            EntityEntry<Adult> newlyAdded = await context.Adults.AddAsync(adult);
            await context.SaveChangesAsync();
            return newlyAdded.Entity;
        }

        public async Task<Adult> UpdateAdult(Adult adult)
        {
            try
            {
                Adult update = await context.Adults.FirstAsync(t => t.Id == adult.Id);
                update.Id = adult.Id;
                update.FirstName = adult.FirstName;
                update.LastName = adult.LastName;
                update.HairColor = adult.HairColor;
                update.EyeColor = adult.EyeColor;
                update.Age = adult.Age;
                update.Height = adult.Height;
                update.Weight = adult.Weight;
                update.Sex = adult.Sex;
                update.JobTitle = adult.JobTitle;
                context.Update(update);
                await context.SaveChangesAsync();
                return update;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception($"Did not find adult with id{adult.Id}");
            }
        }

        public async Task DeleteAdult(int adultId)
        {
            Adult toDelete = await context.Adults.FirstOrDefaultAsync(t => t.Id == adultId);
            if (toDelete != null)
            {
                context.Adults.Remove(toDelete);
                await context.SaveChangesAsync();
            }
        }

        public Adult GetId(int id)
        {
            return context.Adults.FirstOrDefault(a => a.Id == id);
        }
    }
}