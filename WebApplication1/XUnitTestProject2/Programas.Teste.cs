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
            
        }

        [Fact]
        public void CreateProgram()
        {
            String nomeDeTeste = "Programa de teste";
            Cimob.Models.Program programa = new Cimob.Models.Program()
            { Name = nomeDeTeste, Description = "Programa para efeitos de testes xunit" };

            Assert.Matches(programa.Name, nomeDeTeste);
        }

        /*
        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        [InlineData(10000001)]
        public void ProgramVacanciesUpdateTest(int value)
        {
            Cimob.Models.Program programa = new Cimob.Models.Program();
            programa.Vacancies = value;
            Assert.Equal(programa.Vacancies, value);
        }
        */

        [Fact]
        public void UpdateVacancies()
        {
            int vacancies = 10;
            Cimob.Models.Program programa = new Cimob.Models.Program();
            programa.Vacancies = vacancies;
            Assert.Equal(programa.Vacancies, vacancies);
        }
    }
}
