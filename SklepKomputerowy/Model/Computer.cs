using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace SklepKomputerowy.Model
{
    public class Computer : INotifyPropertyChanged
    {
        private int _dostepnaIlosc;
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string ObrazekSrc { get; set; }
        public double Cena { get; set; }
        public string Kategoria { get; set; }
        public int OryginalnaIlosc { get; set; }
        public int DostepnaIlosc { get=>_dostepnaIlosc; set {
                _dostepnaIlosc = value;
                OnPropertyChanged(nameof(DostepnaIlosc));
            } }

      
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
