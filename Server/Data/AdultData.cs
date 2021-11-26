// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Server.Models;
// using Server.Persistance;
//
// namespace Server.Data
// {
//     public class AdultData : IAdultData
//     {
//         private FileContext saveFile;
//
//         public AdultData()
//         {
//             saveFile = new FileContext();
//         }
//         
//         public async Task<IList<Adult>> GetAdults()
//         {
//             return saveFile.Adults;
//         }
//
//         public async Task<Adult> AddAdult(Adult adult)
//         {
//             await Task.Run(() =>
//             {
//                 int max = saveFile.Adults.Max(adult => adult.Id);
//                 adult.Id = (++max);
//                 saveFile.Adults.Add(adult);
//                 saveFile.SaveChanges();
//             });
//            return adult;
//         }
//
//         public async Task UpdateAdult(Adult adult)
//         {
//             await Task.Run(() =>
//             {
//                 Adult update = saveFile.Adults.First(t => t.Id == adult.Id);
//                 update.FirstName = adult.FirstName;
//                 update.LastName = adult.LastName;
//                 update.HairColor = adult.HairColor;
//                 update.EyeColor = adult.EyeColor;
//                 update.Age = adult.Age;
//                 update.Height = adult.Height;
//                 update.Weight = adult.Weight;
//                 update.Sex = adult.Sex;
//                 update.JobTitle = adult.JobTitle;
//                 saveFile.SaveChanges();
//             });
//         }
//
//         public async Task DeleteAdult(Adult adult)
//         {
//             await Task.Run(() =>
//             {
//                 saveFile.Adults.Remove(adult);
//                 saveFile.SaveChanges();
//             });
//         }
//
//         public Adult GetId(int id)
//         {
//             return saveFile.Adults.FirstOrDefault(a => a.Id == id);
//         }
//     }
// }