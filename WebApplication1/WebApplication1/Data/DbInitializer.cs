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
                context.Questions.Add(new Question { Description = "Primeiro nome da mãe?" });
                context.Questions.Add(new Question { Description = "Nome do animal de estimação?" });
                context.Questions.Add(new Question { Description = "Nome da professora Primária?" });
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
                context.Destinations.Add(new Destination { Pais = "Macau", Cidade = "Macau" });
                context.SaveChanges();
            }
            if (!context.Entities.Any())
            {
                context.Entities.Add(new Entity { EntityName = "Santander" });
                context.Entities.Add(new Entity { EntityName = "IPS" });
                context.Entities.Add(new Entity { EntityName = "Illuminati" });

                context.SaveChanges();
            }
            if (!context.Programs.Any())
            {
                context.Programs.Add(new Models.Program
                {
                    Name = "ProgramaXPTO 18-19",
                    DestinationId=2,
                    Description = "Programa XPTO para xpto 2018-2019",
                    Vacancies = 12,
                    StartDate = DateTime.Parse("2018-3-1"),
                    EndDate = DateTime.Parse("2019-3-31"),
                    EntityId =1,
                    Bolsa=2200
                });


                context.Programs.Add(new Models.Program
                {
                    Name = "ProgramaADVANCED 2018",
                    Description = "Programa Avançado 2018",
                    DestinationId=1,
                    Vacancies = 8,
                    StartDate = DateTime.Parse("2018-4-1"),
                    EndDate = DateTime.Parse("2018-7-31"),
                    EntityId =2,
                    Bolsa=800
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "Erasmus+ 2018",
                    Description = "Programa Erasmus 2018",
                    DestinationId = 3,
                    Vacancies = 8,
                    StartDate = DateTime.Parse("2018-3-1"),
                    EndDate = DateTime.Parse("2018-10-31"),
                    EntityId = 2,
                    Bolsa = 1800
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "IberiaCOM 18-19",
                    Description = "Programa Iberia Tecnologia 2018/2019",
                    DestinationId = 1,
                    Vacancies = 8,
                    StartDate = DateTime.Parse("2018-2-14"),
                    EndDate = DateTime.Parse("2019-3-1"),
                    EntityId = 1,
                    Bolsa = 1500
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "IPMacau 18-19",
                    Description = "Programa IPMacau 2018/2019 para Engenharia Informática",
                    DestinationId = 7,
                    Vacancies = 8,
                    StartDate = DateTime.Parse("2018-2-14"),
                    EndDate = DateTime.Parse("2019-3-1"),
                    EntityId = 1,
                    Bolsa = 3000
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "TEDin",
                    Description = "Programa TEDin - TED International 2018",
                    DestinationId = 3,
                    Vacancies = 8,
                    StartDate = DateTime.Parse("2018-4-4"),
                    EndDate = DateTime.Parse("2019-9-15"),
                    EntityId = 1,
                    Bolsa = 1900
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "IberiaCOM 19-20",
                    Description = "Programa Iberia Tecnologia 2019/2020",
                    DestinationId = 3,
                    Vacancies = 8,
                    StartDate = DateTime.Parse("2019-2-14"),
                    EndDate = DateTime.Parse("2020-3-1"),
                    EntityId = 1,
                    Bolsa = 2500
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "NSA19",
                    Description = "Programa NSA para 2019",
                    DestinationId = 4,
                    Vacancies = 1,
                    StartDate = DateTime.Parse("2019-2-14"),
                    EndDate = DateTime.Parse("2019-7-1"),
                    EntityId = 2,
                    Bolsa = 2500
                });

                context.Programs.Add(new Models.Program
                {
                    Name = "PPP2020",
                    Description = "Programa PPP 2020",
                    DestinationId = 3,
                    Vacancies = 3,
                    StartDate = DateTime.Parse("2018-2-14"),
                    EndDate = DateTime.Parse("2020-3-1"),
                    EntityId = 3,
                    Bolsa = 1500
                });
                context.SaveChanges();

            }


        }
    }
}


