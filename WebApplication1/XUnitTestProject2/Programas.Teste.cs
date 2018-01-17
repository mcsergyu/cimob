using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Cimob.Test
{
    public class Programas
    {
        public Programas()
        {
            ProgramCreateTest();
        }

        [Fact]
        public void ProgramCreateTest()
        {
            String nomeDeTeste = "Programa de teste";
            // ProgramId,Name,DestinationId,EntityId,Description,Vacancies,StartDate,EndDate
            Cimob.Models.Program programa = new Cimob.Models.Program() { Name = nomeDeTeste, Description = "Programa para efeitos de testes xunit" };

            Assert.Matches(programa.Name, nomeDeTeste);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        [InlineData(10000001)]
        public void ProgramVacanciesUpdateTest(int value)
        {
            Cimob.Models.Program programa = new Cimob.Models.Program() { Name = "Programa de teste", Description = "Programa para efeitos de testes xunit", Vacancies = value };
            Assert.Equal(programa.Vacancies, value);
        }
    }
}
