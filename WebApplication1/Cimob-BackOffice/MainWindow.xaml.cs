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
    }
}

