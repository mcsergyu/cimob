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
        
        public int InsertPrograms(Program program)
        {
            decimal newId = -1m;

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sql = "insert into Programs (DestinationId, EntityId, Name, Description, Vacancies, StartDate, EndDate, Bolsa) values (@detinationId, @entityId,@name,@description,@vacancies,@startDate,@endDate,@bolsa); select scope_identity()";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@detinationId", program.DestinationId);
            cmd.Parameters.AddWithValue("@entityId", program.EntityId);
            cmd.Parameters.AddWithValue("@name", program.Name);
            cmd.Parameters.AddWithValue("@description", program.Description);
            cmd.Parameters.AddWithValue("@vacancies", program.Vacancies);
            cmd.Parameters.AddWithValue("@startDate", program.StartDate);
            cmd.Parameters.AddWithValue("@endDate", program.EndDate);
            cmd.Parameters.AddWithValue("@bolsa", program.Bolsa);

            try
            {
                con.Open();


                newId = (decimal)cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show("Foi adicionado o programa com o registo (" + newId + ")");
            return Convert.ToInt32(newId);
        }

        public void UpdateProgram(Program program)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sql = "update Programs set DestinationId = @detinationId, EntityId = @entityId, Name = @name, Description = @description, Vacancies = @vacancies, StartDate = @startDate, EndDate = @endDate, Bolsa = @bolsa where (ProgramId=@id)";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue("@detinationId", program.DestinationId);
            cmd.Parameters.AddWithValue("@entityId", program.EntityId);
            cmd.Parameters.AddWithValue("@name", program.Name);
            cmd.Parameters.AddWithValue("@description", program.Description);
            cmd.Parameters.AddWithValue("@vacancies", program.Vacancies);
            cmd.Parameters.AddWithValue("@startDate", program.StartDate);
            cmd.Parameters.AddWithValue("@endDate", program.EndDate);
            cmd.Parameters.AddWithValue("@bolsa", program.Bolsa);
            cmd.Parameters.AddWithValue("@id", program.ProgramId);

            int reg = 0;

            try
            {
                con.Open();

                reg = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(reg + " registo atualizado!");

        }

        public void RemoverPrograma(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = con;

            string sql = "delete from Programs where (ProgramId = @id)";
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("@id", id);

            int regs = 0;

            try
            {
                con.Open();

                regs = cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                con.Close();
            }

            MessageBox.Show(regs + " registo apagado");
        }

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

        public ObservableCollection<Destination> GetDestinos()
        {
            ObservableCollection<Destination> candidaturas = new ObservableCollection<Destination>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sql = "select * from Destination";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Destination candidatura = new Destination();

                    candidatura.DestinationId = (int)dr["DestinationId"];
                    candidatura.Cidade = (string)dr["Cidade"];
                    candidatura.Pais = (string)dr["Pais"];

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

        public ObservableCollection<Entity> GetEntidades()
        {
            ObservableCollection<Entity> candidaturas = new ObservableCollection<Entity>();

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            string sql = "select * from Entity";

            cmd.CommandText = sql;

            try
            {
                con.Open();

                SqlDataReader dr;

                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Entity candidatura = new Entity();

                    candidatura.EntityId = (int)dr["EntityId"];
                    candidatura.EntityName = (string)dr["EntityName"];

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