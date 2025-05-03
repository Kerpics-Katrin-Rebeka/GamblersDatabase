using GamblersDatabase;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Gamber_DataBase
{
    public partial class MainWindow : Window
    {
        private ICollectionView _filteredGamblersView;

        private const string FilePath = "gamblers.txt";
        public ObservableCollection<Gamblers> GamblersList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            GamblersList = LoadGamblers();
            _filteredGamblersView = CollectionViewSource.GetDefaultView(GamblersList);
            _filteredGamblersView.Filter = null;

            GamblersDataGrid.ItemsSource = _filteredGamblersView;
        }

        private ObservableCollection<Gamblers> LoadGamblers()
        {
            var list = new ObservableCollection<Gamblers>();
            var lines = File.ReadAllLines(FilePath, Encoding.UTF8);

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(';').Select(p => p.Trim()).ToArray();
                if (parts.Length < 7) continue;

                if (!float.TryParse(parts[1].Replace(',', '.'), out float credit)) credit = 0;
                if (!float.TryParse(parts[4].Replace(',', '.'), out float debt)) debt = 0;
                if (!bool.TryParse(parts[6], out bool isMinor)) isMinor = false;

                list.Add(new Gamblers(parts[0], credit, parts[2], parts[3], debt, parts[5], isMinor));
            }

            return list;
        }

        private void TB_search_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            string query = TB_search.Text.ToLower();

            _filteredGamblersView.Filter = g =>
            {
                if (g is Gamblers gambler)
                {
                    return gambler.Name.ToLower().Contains(query)
                        || gambler.CardInfo.ToLower().Contains(query)
                        || gambler.Address.ToLower().Contains(query)
                        || gambler.Birthday.ToLower().Contains(query)
                        || gambler.CreditScore.ToString().ToLower().Contains(query)
                        || gambler.Debt.ToString().ToLower().Contains(query)
                        || gambler.isMinor.ToString().ToLower().Contains(query);
                }
                return false;
            };

            _filteredGamblersView.Refresh();
        }

        private void BTN_new_Click(object sender, RoutedEventArgs e)
        {
            var newDataWindow = new NewData(GamblersList);
            newDataWindow.ShowDialog(); // pauses current window
        }

        private void BTN_delete_Click(object sender, RoutedEventArgs e)
        {
            if (GamblersDataGrid.SelectedItem is Gamblers selected)
            {
                GamblersList.Remove(selected);
                SaveToFile();
            }
        }

        private void SaveToFile()
        {
            var sb = new StringBuilder();
            sb.AppendLine("{Name; CreditScore; CardInfo; Address; Debt; Birthday; isMinor}");
            foreach (var g in GamblersList)
            {
                sb.AppendLine($"{g.Name}; {g.CreditScore}; {g.CardInfo}; {g.Address}; {g.Debt}; {g.Birthday}; {g.isMinor.ToString().ToLower()}");
            }
            File.WriteAllText(FilePath, sb.ToString(), Encoding.UTF8);
        }
    }
}
