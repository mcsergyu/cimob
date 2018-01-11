using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cimob.Models;

namespace Cimob.Data
{



    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Questions.Any())
            {
                context.Questions.Add(new Question { Description = "Primeiro Nome?" });
                context.Questions.Add(new Question { Description = "Nome do Animal de estimação?" });
                context.SaveChanges();
            }
            if (!context.ProfileTypes.Any())
            {
                context.ProfileTypes.Add(new ProfileType { Description = "Estudante" });
                 context.ProfileTypes.Add(new ProfileType { Description = "~Trabalhador" });
                context.SaveChanges();
            }
            if (!context.Destinations.Any())
            {
                context.Destinations.Add(new Destination { Pais = "Portugal", Cidade = "Lisboa" });
                context.Destinations.Add(new Destination { Pais = "França", Cidade = "Paris" });
                context.SaveChanges();
            }
            if (!context.Entities.Any())
            {
                context.Entities.Add(new Entity { EntityName = "Santader" });
                context.Entities.Add(new Entity { EntityName = "Ips" });
                context.SaveChanges();
            }
            if (!context.Programs.Any())
            {
                context.Programs.Add(new Models.Program
                {
                    Name = "ProgramaXPTO",
                    DestinationId=2,
                    Description = "Programa XPTO para xpto",
                    Vacancies = 12,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now

                });


                context.Programs.Add(new Models.Program
                {
                    Name = "ProgramaADVANCED",
                    Description = "Programa Avançado",
                    DestinationId=1,
                    Vacancies = 8,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now

                });
                context.SaveChanges();

            }

            context.Entities.Add(new Entity { EntityName = "Ips" });
            context.SaveChanges();
        }
    }
}


