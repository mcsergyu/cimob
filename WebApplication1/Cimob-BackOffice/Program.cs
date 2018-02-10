using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimob_BackOffice
{
    public class Program : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private int programId;
        public int ProgramId
        {
            get { return programId; }
            set
            {
                programId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ProgramId"));
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Nome"));
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Description"));
            }
        }

        private int vacancies;
        public int Vacancies
        {
            get
            {
                return vacancies;
            }
            set
            {
                vacancies = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Vacancies"));
            }
        }

        private DateTime startDate;
        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("StartDate"));
            }
        }

        private DateTime endDate;
        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EndDate"));
            }
        }

        private double bolsa;
        public double Bolsa
        {
            get
            {
                return bolsa;
            }
            set
            {
                bolsa = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Bolsa"));
            }
        }

        private int destinationId;
        public int DestinationId
        {
            get
            {
                return destinationId;
            }
            set
            {
                destinationId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DestinationId"));
            }
        }

        private int entityId;
        public int EntityId
        {
            get
            {
                return entityId;
            }
            set
            {
                entityId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("EntityId"));
            }
        }

        override
        public string ToString()
        {
            return (ProgramId + "-" + Name + " - "
                + Description //+ " - " 
                              //+ Vacancies + " - "
                              //+ StartDate + " - "
                              //+ EndDate + " - "
                              //+ Bolsa + " - "
                              //+ EntityId + " - "
                              //+ DestinationId
                );
        }

        public Program() : this(0, "N/A", "N/A", 0, new DateTime().AddDays(1).AddMonths(1).AddYears(2000), new DateTime().AddDays(1).AddMonths(1).AddYears(2000), 0.0, 0, 0)
        {

        }

        public Program(string name, string description, int vacancies,
                        DateTime startDate, DateTime endDate, double bolsa, int destinationId,
                        int entityId) : this(0, name, description, vacancies, startDate, endDate, bolsa, destinationId, entityId)
        {

        }

        public Program(int programId, string name, string description, int vacancies,
                        DateTime startDate, DateTime endDate, double bolsa, int destinationId,
                        int entityId)
        {
            ProgramId = programId;
            Name = name;
            Description = description;
            Vacancies = vacancies;
            StartDate = startDate;
            EndDate = endDate;
            Bolsa = bolsa;
            DestinationId = destinationId;
            EntityId = entityId;
        }

        public Program(Program program)
        {
            ProgramId = program.programId;
            Name = program.name;
            Description = program.description;
            Vacancies = program.vacancies;
            StartDate = program.startDate;
            EndDate = program.endDate;
            Bolsa = program.bolsa;
            DestinationId = program.destinationId;
            EntityId = program.entityId;
        }
    }
}
