using System.Xml;

namespace PlayerService.Data
{
    public static class Seed
    {
        public static void SeedPlayer0(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Player.Any())
            {
                Console.WriteLine("Seeding Data...");
                //var dob = new DateTime(1969, 04, 20);
                //var charInfo = new Models.CharInfo() { FirstName = "Tony", LastName = "Tono", Backstory = "Son of the great Tono Tono.", Phone = 1558679267, Sex = 1, BirthDate = dob};
                //var player0Meta = new Models.MetaData() { BloodType = "AB+", CurrentApartment = "Office", Fingerprint = "JB632M89XoO2437", InJail = 0 };
                Guid userLicense = Guid.NewGuid();
                var player0 = new Models.Player()
                {
                    UserLicense = userLicense,
                    Name = "Carrucan",
                    Money = "{'crypto':0,'bank':5120,'cash':500}",
                    //CharInfo = charInfo,
                    Job = "{'label':'Civilian','name':'unemployed','payment':10,'grade':{'level':0,'name':'Freelancer'},'onduty':true,'isboss':false}",
                    Gang = "{'isboss':false,'label':'No Gang Affiliaton','grade':{'level':0,'name':'none'},'name':'none'}",
                    Position = "{'x':0.0,'y':0.0,'z':0.0}",
                    //MetaData = player0Meta,
                    Inventory = "",
                    LastUpdated = DateTime.Now,
                };
                context.Player.AddRange(
                    player0
                );
                context.SaveChanges();
            }
            else
            { 
                Console.WriteLine("Data is persisted.");
            }
        }
    }
}
