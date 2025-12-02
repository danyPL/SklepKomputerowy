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
        public ObservableCollection<Computer> Computers { get; set; }
        public MainViewModel()
        {
            LoadMauiAsset();

        }
        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("data_store.txt");
            using var reader = new StreamReader(stream);

            reader.ReadLine();
            var contents = reader.ReadToEnd();

            string[] rows = contents.Split("\n");
            foreach (string row in rows)
            {
                Computers.Add(new Computer()
                {
                    Id = row[0],
                    Nazwa = row[1].ToString(),
                    ObrazekSrc = row[2].ToString(),
                    Cena = row[3],
                    Kategoria = row[4].ToString(),
                    DostepnaIlosc = row[5]
                });
            }
        }
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
