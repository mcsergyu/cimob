using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cimob_BackOffice
{
    public class BdApplication
    {
        private string connectionString = Properties.Settings.Default.DefaultConnection;

        public ObservableCollection<Program> GetPrograms()
        {
            ObservableCollection<Program> programas = new ObservableCollection<Program>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sql = "select * from Programs";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Program program = new Program();

                    program.ProgramId = (int)dr["ProgramId"];
                    program.DestinationId = (int)dr["DestinationId"];
                    program.EntityId = (int)dr["EntityId"];
                    program.Name = (string)dr["Name"];
                    program.Description = (string)dr["Description"];
                    program.Vacancies = (int)dr["Vacancies"];
                    program.StartDate = (DateTime)dr["StartDate"];
                    program.EndDate = (DateTime)dr["EndDate"];
                    program.Bolsa = (double)dr["Bolsa"];

                    programas.Add(program);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return programas;
        }

        public ObservableCollection<Candidatura> GetCandidaturas()
        {
            ObservableCollection<Candidatura> candidaturas = new ObservableCollection<Candidatura>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sql = "select * from Candidatura";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Candidatura candidatura = new Candidatura();

                    candidatura.CandidaturaId = (int)dr["CandidaturaId"];
                    candidatura.InterviewId = (int)dr["InterviewId"];
                    candidatura.ProgramId = (int)dr["ProgramId"];
                    candidatura.UserId = (string)dr["UserId"];
                    candidatura.StartDate = (DateTime)dr["StartDate"];
                    candidatura.LastDate = (DateTime)dr["LastStateDate"];
                    candidatura.CandidaturaState = (CandidaturaState)dr["State"];

                    candidaturas.Add(candidatura);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            return candidaturas;
        }

        
    }
}