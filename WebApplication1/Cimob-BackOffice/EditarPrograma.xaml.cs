using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cimob_BackOffice
{
    /// <summary>
    /// Interaction logic for EditarPrograma.xaml
    /// </summary>
    public partial class EditarPrograma : Window
    {
        public Program Program { get; set; }
        private IEnumerable<Program> listaProgram;

        private ObservableCollection<Destination> destinos;
        private ObservableCollection<Entity> entidades;

        public EditarPrograma(IEnumerable<Program> programas, Program program=null)
        {
            InitializeComponent();

            listaProgram = programas;
            Program = program ?? new Program();

            this.DataContext = Program;

            //destinos = App.BdApplication.GetDestinos();
            //entidades = App.BdApplication.GetEntidades();

            //ListBoxDestino.ItemsSource = destinos;
            //ListBoxDestino.SelectedValuePath = "DestinationId";
            ////ListBoxProgramas.DisplayMemberPath = "Name" + "Description";
            //ListBoxDestino.SelectedIndex = Program.DestinationId;
            //ListBoxDestino.IsSynchronizedWithCurrentItem = true;


            //ListBoxEntidade.ItemsSource = entidades;
            //ListBoxEntidade.SelectedValuePath = "EntityId";
            //ListBoxEntidade.SelectedIndex = Program.EntityId;
            //ListBoxEntidade.IsSynchronizedWithCurrentItem = true;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            TextName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextDescricao.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextVagas.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextBolsa.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            //ListBoxDestino.GetBindingExpression(ListBox.SelectedItemProperty).UpdateSource();
            //ListBoxEntidade.GetBindingExpression(ListBox.SelectedItemProperty).UpdateSource();

            StartDate.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();
            EndDate.GetBindingExpression(DatePicker.SelectedDateProperty).UpdateSource();

            TextVagas.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextBolsa.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            string message;
            if(this.DialogResult == true && FormHasErrors(out message))
            {
                // Errors still exist.
                MessageBox.Show(message);

                e.Cancel = true;
            }
        }

        private bool AtualizarPrograma()
        {
            if (listaProgram.Any(p => p.ProgramId == Program.ProgramId && p.EntityId == Program.EntityId 
            && p.DestinationId == Program.DestinationId && p.Name == Program.Name 
            && p.Description == Program.Description && p.StartDate == Program.StartDate
            && p.EndDate == Program.EndDate && p.Vacancies == Program.Vacancies
            && p.Bolsa == Program.Bolsa))
            {
                MessageBox.Show("Esse Programa já existe!");
                return false;
            }
            return true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (AtualizarPrograma())
                DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            destinos = App.BdApplication.GetDestinos();
            entidades = App.BdApplication.GetEntidades();

            ListBoxDestino.ItemsSource = destinos;
            ListBoxDestino.SelectedValuePath = "DestinationId";
            //ListBoxProgramas.DisplayMemberPath = "Name" + "Description";
            ListBoxDestino.SelectedIndex = Program.DestinationId;
            ListBoxDestino.IsSynchronizedWithCurrentItem = true;


            ListBoxEntidade.ItemsSource = entidades;
            ListBoxEntidade.SelectedValuePath = "EntityId";
            ListBoxEntidade.SelectedIndex = Program.EntityId;
            ListBoxEntidade.IsSynchronizedWithCurrentItem = true;

            //Para as estatísticas
            //candidaturas = App.BdApplication.GetCandidaturas();
            //var id = from c in candidaturas join p in programas on c.ProgramId equals p.ProgramId select new { p.ProgramId, p.Name, p.Description, c.StartDate, c.CandidaturaState };
            //ListBoxEstatisticasProg.ItemsSource = programas;
            //ListBoxEstatisticasProg.SelectedValuePath = "ProgramaId";
            //ListBoxEstatisticasProg.SelectedIndex = 0;
            //ListBoxEstatisticasProg.IsSynchronizedWithCurrentItem = true;
        }

        private bool FormHasErrors(out string message)
        {
            StringBuilder sb = new StringBuilder();
            GetErrors(sb, GridFormPrograma);
            message = sb.ToString();
            return message != "";
        }

        private void GetErrors(StringBuilder sb, DependencyObject obj)
        {
            foreach (object child in LogicalTreeHelper.GetChildren(obj))
            {
                TextBox element = child as TextBox;
                if (element == null) continue;
                if (Validation.GetHasError(element))
                {
                    sb.Append(element.Text + " has errors:\r\n");
                    foreach (ValidationError error in Validation.GetErrors(element))
                    {
                        sb.Append(" " + error.ErrorContent.ToString());
                        sb.Append("\r\n");
                    }
                }

                // Check the children of this object for errors.
                GetErrors(sb, element);
            }
        }

    }
}
