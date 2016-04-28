using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            //InsertNinja();
            //QueryAndUpdateNinja();
            //LoadRelatedData();
            QueryAnonymusType();
            Console.ReadLine();
        }

        private static void QueryAnonymusType()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var result = context.Ninjas.Select(x => new { x.Name, x.EquipmentOwned, x.Clan.ClanName }).ToList();
            }
        }

        private static void LoadRelatedData()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.Include(e=>e.EquipmentOwned).FirstOrDefault(x => x.Id == 28);

                int countEquipment = ninja.EquipmentOwned.Count();

            }
        }

        private static void QueryAndUpdateNinja()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninjas = context.Ninjas.FirstOrDefault(x => x.Name == "SalihSan3");
            }
        }

        private static void InsertNinja()
        {
            var ninjas = new List<Ninja>();
            for (int i = 21; i < 30; i++)
            {
                var ninja = new Ninja
                {
                    Name = "SalihSan" + i,
                    ServedInOniwaban = (i % 2 == 0),
                    DateOfBirth = new DateTime(1978, 11, i),
                    ClanId = (i % 2 == 0) ? 1 : 2
                };

                var equipment = new NinjaEquipment()
                {
                    Name = "equipment " + i,
                    Type = EquipmentType.Weapon
                };

                ninja.EquipmentOwned.Add(equipment);

                equipment = new NinjaEquipment()
                {
                    Name = "equipmentTool " + i,
                    Type = EquipmentType.Tool
                };

                ninja.EquipmentOwned.Add(equipment);

                ninjas.Add(ninja);
            }
            

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(ninjas);
                context.SaveChanges();
            }
        }
    }
}
