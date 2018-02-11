using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimob_BackOffice
{
    public partial class Candidatura
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private int candidaturaId;
        public int CandidaturaId
        {
            get { return candidaturaId; }
            set
            {
                candidaturaId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("CandidaturaId"));
            }
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

        private string userId;
        public string UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("SubmissionUserId"));
            }
        }

        private int interviewId;
        public int InterviewId
        {
            get
            {
                return interviewId;
            }
            set
            {
                interviewId = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InterviewId"));
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

        private DateTime lastDate;
        public DateTime LastDate
        {
            get
            {
                return lastDate;
            }
            set
            {
                lastDate = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LastDate"));
            }
        }

        private CandidaturaState candidaturaState;
        public CandidaturaState CandidaturaState
        {
            get
            {
                return candidaturaState;
            }
            set
            {
                candidaturaState = value;
                OnPropertyChanged(new PropertyChangedEventArgs("State"));
            }
        }


        override
        public string ToString()
        {
            return (candidaturaId + " - "
                + startDate + " - "
                + lastDate + " - "
                + candidaturaState// + " - "
                                  //+ EndDate + " - "
                                  //+ Bolsa + " - "
                                  //+ EntityId + " - "
                                  //+ DestinationId
                );
        }

        public Candidatura() : this(0, 0, 0, new DateTime().AddDays(1).AddMonths(1).AddYears(2000), new DateTime().AddDays(1).AddMonths(1).AddYears(2000), CandidaturaState.scheduling, "N/A")
        {

        }

        public Candidatura(DateTime startDate, DateTime lastDate, CandidaturaState candidaturaState, string userId) : this(0, 0, 0, startDate, lastDate, candidaturaState, userId)
        {

        }

        public Candidatura(int candidaturaIr, int interviewId, int programId,
                        DateTime startDate, DateTime lastDate, CandidaturaState candidaturaState,
                        string userId)
        {
            CandidaturaId = candidaturaId;
            InterviewId = interviewId;
            ProgramId = programId;
            StartDate = startDate;
            LastDate = lastDate;
            CandidaturaState = candidaturaState;
            UserId = userId;
        }

        public Candidatura(Candidatura candidatura)
        {
            CandidaturaId = candidatura.CandidaturaId;
            InterviewId = candidatura.InterviewId;
            ProgramId = candidatura.ProgramId;
            StartDate = candidatura.StartDate;
            LastDate = candidatura.LastDate;
            CandidaturaState = candidatura.CandidaturaState;
            UserId = candidatura.UserId;
        }

    }

    public enum CandidaturaState
    {
        [Display(Name = "Aguarda agendamento")]
        scheduling,
        [Display(Name = "Aguarda entrevista")]
        interview,
        [Display(Name = "Cancelada")]
        canceled,
        [Display(Name = "Rejeitada")]
        rejected,
        [Display(Name = "Aprovada")]
        approved
    }
}