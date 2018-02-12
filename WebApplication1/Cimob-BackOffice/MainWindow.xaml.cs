using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Cimob_BackOffice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Program> programas;
        private ObservableCollection<Candidatura> candidaturas;
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            programas = App.BdApplication.GetPrograms();

            ListBoxProgramas.ItemsSource = programas;
            ListBoxProgramas.SelectedValuePath = "ProgramId";
            //ListBoxProgramas.DisplayMemberPath = "Name" + "Description";
            ListBoxProgramas.SelectedIndex = 0;
            ListBoxProgramas.IsSynchronizedWithCurrentItem = true;

            DataGridProgramas.ItemsSource = programas;


            //Para as estatísticas
            candidaturas = App.BdApplication.GetCandidaturas();
            var id = from c in candidaturas join p in programas on c.ProgramId equals p.ProgramId select new { p.ProgramId, p.Name, p.Description, c.StartDate, c.CandidaturaState };
            ListBoxEstatisticasProg.ItemsSource = programas;
            ListBoxEstatisticasProg.SelectedValuePath = "ProgramaId";
            ListBoxEstatisticasProg.SelectedIndex = 0;
            ListBoxEstatisticasProg.IsSynchronizedWithCurrentItem = true;
            
        }

        private void ListBoxProgramas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void MenuItem_ClickSair(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListBox_SelectionChanged(object sender, EventArgs e)
        {
            AtualizarEstado();
        }

        private void AtualizarEstado()
        {
            var candidaturaPrograma = from c in candidaturas join p in programas on c.ProgramId equals p.ProgramId where ListBoxEstatisticasProg.Items.CurrentPosition.Equals(c.ProgramId - 1) select new { p.Name, p.Description, c.StartDate, c.CandidaturaState };
            var nomePrograma = from c in candidaturas join p in programas on c.ProgramId equals p.ProgramId where ListBoxEstatisticasProg.Items.CurrentPosition.Equals(c.ProgramId - 1) select p.Name;
            DataEstatisticas.ItemsSource = candidaturaPrograma;
            TotalCandidaturas.Content = string.Format("Total de {0} candidaturas.", candidaturaPrograma.Count());
        }

        private void DataEstatisticas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxProgramas.SelectedItem == null)
                return;

            Program program = ListBoxProgramas.SelectedItem as Program;
            EditarPrograma edicaoPrograma = new EditarPrograma(App.BdApplication.GetPrograms(), new Program(program)) { Title = "Editar um programa de mobilidade" };

            if(edicaoPrograma.ShowDialog()==true && edicaoPrograma.Program != program)
            {
                program.DestinationId = edicaoPrograma.Program.DestinationId;
                program.EntityId = edicaoPrograma.Program.EntityId;
                program.Name = edicaoPrograma.Program.Name;
                program.Description = edicaoPrograma.Program.Description;
                program.Vacancies = edicaoPrograma.Program.Vacancies;
                program.StartDate = edicaoPrograma.Program.StartDate;
                program.EndDate = edicaoPrograma.Program.EndDate;
                program.Bolsa = edicaoPrograma.Program.Bolsa;

                App.BdApplication.UpdateProgram(program);

                ListBoxProgramas.Items.Refresh();
                DataGridProgramas.Items.Refresh();
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            EditarPrograma addPrograma = new EditarPrograma(App.BdApplication.GetPrograms()) { Title = "Adicionar Programa de mobilidade" };

            if (addPrograma.ShowDialog() == true)
            {
                int id = App.BdApplication.InsertPrograms(addPrograma.Program);
                if(id > 0)
                {
                    addPrograma.Program.ProgramId = id;
                    programas.Add(addPrograma.Program);
                }

                ListBoxProgramas.Items.MoveCurrentToLast();
                //DataGridProgramas.Items.MoveCurrentToLast();
            }
        }

        private void ButtonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxProgramas.SelectedItem == null)
                return;

            Program programa = ListBoxProgramas.SelectedItem as Program;

            if (MessageBox.Show("Deseseja mesmo apagar o programa (Y/N)?", "Apagar Programa?", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {

                App.BdApplication.RemoverPrograma(programa.ProgramId);
                programas.Remove(programa);

                ListBoxProgramas.Items.MoveCurrentToFirst();
                
            }
        }

        private void ListBoxProgramas_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ButtonEdit_Click(sender, e);
        }
    }
}

