using SklepKomputerowy.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SklepKomputerowy.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Computer> Computers { get; set; } = [];
        public MainViewModel()
        {
            LoadMauiAsset();

        }
        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("data_store.txt");
            using var reader = new StreamReader(stream);



            string[] rows = reader.ReadToEnd().Split('\n');

            for(int i =1; i < rows.Length; i++)
            {
                var columns = rows[i].Split(";");
                Computers.Add(new Computer()
                {
                    Id = int.Parse(columns[0]),
                    Nazwa = columns[1],
                    ObrazekSrc = columns[2],
                    Cena = double.Parse(columns[3]),
                    Kategoria = columns[4],
                    DostepnaIlosc = int.Parse(columns[5])
                });
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
