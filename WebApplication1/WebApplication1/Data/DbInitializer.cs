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
                 context.ProfileTypes.Add(new ProfileType { Description = "Trabalhador" });
                context.SaveChanges();
            }
            if (!context.Destinations.Any())
            {
                context.Destinations.Add(new Destination { Pais = "Portugal", Cidade = "Lisboa" });
                context.Destinations.Add(new Destination { Pais = "França", Cidade = "Paris" });
                context.Destinations.Add(new Destination { Pais = "Alemanha", Cidade = "Berlim" });
                context.Destinations.Add(new Destination { Pais = "Estados Unidos da América", Cidade = "Houston" });
                context.Destinations.Add(new Destination { Pais = "Russia", Cidade = "Moscovo" });
                context.Destinations.Add(new Destination { Pais = "Alemanha", Cidade = "Dusseldorf" });
                context.SaveChanges();
            }
            if (!context.Entities.Any())
            {
                context.Entities.Add(new Entity { EntityName = "Santander" });
                context.Entities.Add(new Entity { EntityName = "IPS" });

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
                    EndDate = System.DateTime.Now,
                    EntityId=1,
                    Bolsa=2200
                });


                context.Programs.Add(new Models.Program
                {
                    Name = "ProgramaADVANCED",
                    Description = "Programa Avançado",
                    DestinationId=1,
                    Vacancies = 8,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now,
                    EntityId=2,
                    Bolsa=800
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "Erasmus+",
                    Description = "Programa Erasmus",
                    DestinationId = 3,
                    Vacancies = 8,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now,
                    EntityId = 2,
                    Bolsa = 1800
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "IberiaCOM",
                    Description = "Programa Iberia Tecnologia",
                    DestinationId = 1,
                    Vacancies = 8,
                    StartDate = System.DateTime.Now,
                    EndDate = System.DateTime.Now,
                    EntityId = 1,
                    Bolsa = 1500
                });
                context.SaveChanges();

            }


        }
    }
}


