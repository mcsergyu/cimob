using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cimob_BackOffice
{
    public class Destination : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
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

        private string cidade;
        public string Cidade
        {
            get
            {
                return cidade;
            }
            set
            {
                cidade = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Cidade"));
            }
        }

        private string pais;
        public string Pais
        {
            get
            {
                return pais;
            }
            set
            {
                pais = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Pais"));
            }
        }

        override
        public string ToString()
        {
            return (DestinationId + "- " + Cidade + " - "
                + Pais
                );
        }

        public Destination() : this(0, "N/A", "N/A")
        {

        }

        public Destination(string cidade, string pais) : this(0, cidade, pais)
        {

        }

        public Destination(int destinationId, string cidade, string pais)
        {
            DestinationId = destinationId;
            Cidade = cidade;
            Pais = pais;
        }

        public Destination(Destination destination)
        {
            DestinationId = destination.destinationId;
            Cidade = destination.cidade;
            Pais = destination.pais;
            
        }

    }
}
