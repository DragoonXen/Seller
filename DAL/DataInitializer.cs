using System.Collections.Generic;
using System.Data.Entity;
using Seller.Models;

namespace Seller.DAL
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var magazines = new List<Magazine>
                                {
                                    new Magazine
                                        {
                                            Name = "Sli.by",
                                            Email = "price@sli.by",
                                            Course = 8500,
                                            Site = "Sli.by"
                                        }
                                };
            magazines.ForEach(magazine => context.Magazines.Add(magazine));
            //context.SaveChanges();
        }
    }
}