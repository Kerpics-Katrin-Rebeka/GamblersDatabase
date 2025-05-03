using GamblersDatabase;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;
using System.Xml.Linq;

namespace Gamber_DataBase
{
    public partial class NewData : Window
    {
        private ObservableCollection<Gamblers> _gamblerList;
        private const string FilePath = "gamblers.txt";

        public NewData(ObservableCollection<Gamblers> list)
        {
            InitializeComponent();
            _gamblerList = list;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var name = tbName.Text.Trim();
                float credit = float.Parse(tbCredit.Text.Replace(',', '.'));
                var card = tbCard.Text.Trim();
                var addr = tbAddress.Text.Trim();
                float debt = float.Parse(tbDebt.Text.Replace(',', '.'));
                var birth = tbBirth.Text.Trim();

                var birthYear = int.Parse(birth.Split('.')[0]);
                bool isMinor = DateTime.Now.Year - birthYear < 18;

                var g = new Gamblers(name, credit, card, addr, debt, birth, isMinor);
                _gamblerList.Add(g);

                File.AppendAllText(FilePath, $"{name}; {credit}; {card}; {addr}; {debt}; {birth}; {isMinor.ToString().ToLower()}\n", Encoding.UTF8);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Hibás adatbevitel!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
