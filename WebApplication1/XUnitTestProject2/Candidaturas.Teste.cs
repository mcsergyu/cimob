using Cimob.Controllers;
using Cimob.Data;
using Cimob.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Cimob.Test
{
    public class CandidaturasControllerTest : Controller
    {

        private ApplicationDbContext _context;
        private CandidaturasController _controller;
        private UserManager<ApplicationUser> _userManager;

        public CandidaturasControllerTest()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName:"Add_Candidaturas_to_database")
                .Options;
//#pragma warning disable CS0618 // Type or member is obsolete
//            //optionsBuilder.UseInMemoryDatabase().Options;
//#pragma warning restore CS0618 // Type or member is obsolete
            _context = new ApplicationDbContext(optionsBuilder);

            //seed data
            Cimob.Models.ApplicationUser fernando
                = new Models.ApplicationUser()
                {
                    Id = "1",
                    UserName = "Fernando Correia",
                    Email = "fcorreia@estudantes.ips.pt",
                    PasswordHash = "pass"
                };

            Cimob.Models.Program program
                = new Models.Program()
                {
                    ProgramId = 1,
                    Name = "Erasmus Tota",
                    Bolsa = 120,
                    Description = "Programas Erasmus do Tota",
                    StartDate = new DateTime().AddDays(12).AddMonths(10).AddYears(2016),
                    EndDate = new DateTime().AddDays(12).AddMonths(3).AddYears(2017),
                    DestinationId = 1
                };

            Cimob.Models.Destination destination
                = new Models.Destination()
                {
                    DestinationId = 1,
                    Pais = "Inglaterra",
                    Cidade = "Londres"
                };

            
            Cimob.Models.CandidaturaState candidaturaState
                = new Models.CandidaturaState();

            Cimob.Models.Candidatura candidatura
                = new Cimob.Models.Candidatura()
                {
                    CandidaturaId = 1,
                    ProgramId = 1,
                    AppliedProgram = program,
                    UserId = "1",
                    SubmissionUser = fernando,
                    State = candidaturaState,
                    StartDate = new DateTime().AddDays(12).AddMonths(12).AddYears(2016)
                };


            _context.Users.Add(fernando);

            _context.Programs.Add(program);

            _context.Destinations.Add(destination);

            _context.Candidatura.Add(candidatura);

            _context.SaveChanges();

            //_userManager.AddLoginAsync(fernando, new UserLoginInfo().LoginProvider());
            //new IdentityResult x = await  .AddPasswordAsync(fernando, fernando.PasswordHash.ToString().SignIn )

            _controller = new CandidaturasController(_context, _userManager);
        }

        [Fact]
        public void CreateCandidatura()
        {
            //arrange
            //act
            Cimob.Models.ApplicationUser applicationUser 
                = new Models.ApplicationUser()
                    {
                        Id = "2",
                        UserName = "Francisco Correia",
                        Email = "frcorreia@estudantes.ips.pt"
                    };

            Cimob.Models.Program program
                = new Models.Program()
                    {
                        ProgramId = 2,
                        Name = "Erasmus Espanha",
                        Bolsa = 120,
                        Description ="Programas Erasmus para Espanha",
                        StartDate = new DateTime().AddDays(12).AddMonths(10).AddYears(2016),
                        EndDate = new DateTime().AddDays(12).AddMonths(3).AddYears(2017)
                    };

            Cimob.Models.Destination destination
                = new Models.Destination()
                {
                    DestinationId = 2,
                    Pais = "Espanha",
                    Cidade = "Madrid"
                };

            Cimob.Models.CandidaturaState candidaturaState
                = new Models.CandidaturaState();

            Cimob.Models.Candidatura candidatura
                = new Cimob.Models.Candidatura()
                {
                    CandidaturaId = 1,
                    ProgramId = 2,
                    AppliedProgram = program,
                    UserId = "2",
                    SubmissionUser = applicationUser,
                    State = candidaturaState,
                    StartDate = new DateTime().AddDays(12).AddMonths(10).AddYears(2016),
                    LastStateDate = new DateTime().AddDays(12).AddMonths(10).AddYears(2016)

                };
            

            //assert programa da candidatura
            Assert.Matches(candidatura.AppliedProgram.Name, program.Name);
            Assert.Equal(candidatura.AppliedProgram.Bolsa, program.Bolsa);
            Assert.Matches(candidatura.AppliedProgram.Description, program.Description);
            Assert.Equal(candidatura.AppliedProgram.StartDate, program.StartDate);
            Assert.Equal(candidatura.AppliedProgram.EndDate, program.EndDate);

            //assert user da candidatura
            Assert.Matches(candidatura.SubmissionUser.UserName, applicationUser.UserName);
            Assert.Matches(candidatura.SubmissionUser.Email, applicationUser.Email);


        }

        [Fact]
        public void DetalhesCandidatura()
        {
            DateTime d = new DateTime().AddDays(12).AddMonths(12).AddYears(2016);

            //act
            var result = _controller.Details(1).Result as ViewResult;

            //assert
            Assert.IsType<Candidatura>((Candidatura)result.Model);
            Candidatura c = (Candidatura)result.ViewData.Model;
            Assert.Matches("1", c.UserId);
            Assert.Equal(d.GetDateTimeFormats(), c.StartDate.GetDateTimeFormats());
            Assert.Matches("Inglaterra", c.AppliedProgram.ProgramDestination.Pais);
            Assert.Matches("Londres", c.AppliedProgram.ProgramDestination.Cidade);
            //Assert.Matches("");
        }

        [Fact]
        public void CancelarCandidatura()
        {
            var result = _controller.Cancel(1);
        }


        //    [Fact]
        //    public void GetCandidaturaInexistente()
        //    {

        //        //arrange
        //        //act
        //        Cimob.Models.ApplicationUser applicationUser
        //            = new Models.ApplicationUser()
        //            {
        //                UserName = "Fernando Correia",
        //                Email = "fcorreia@estudantes.ips.pt"
        //            };
        //        Cimob.Models.Program program
        //            = new Models.Program()
        //            {
        //                Name = "Erasmus Tota",
        //                Bolsa = 120,
        //                Description = "Programas Erasmus do Tota",
        //                StartDate = new DateTime().AddDays(12).AddMonths(10).AddYears(2016),
        //                EndDate = new DateTime().AddDays(12).AddMonths(3).AddYears(2017)
        //            };
        //        Cimob.Models.CandidaturaState candidaturaState
        //            = new Models.CandidaturaState();
        //        Cimob.Models.Candidatura candidatura
        //            = new Cimob.Models.Candidatura()
        //            {
        //                AppliedProgram = program,
        //                SubmissionUser = applicationUser,
        //                State = candidaturaState,
        //                StartDate = new DateTime().AddDays(12).AddMonths(10).AddYears(2016),
        //                LastStateDate = new DateTime().AddDays(12).AddMonths(10).AddYears(2016)

        //            };


        //        //assert programa da candidatura
        //        Assert.NotSame(candidatura.SubmissionUser.UserName = "Frederico Tavares", applicationUser.UserName);
        //        Assert.Null(candidatura.SubmissionUser.Email = "ftavares@estudantes.ips.pt");

        //}

    }
}
