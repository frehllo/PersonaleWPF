using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using ClassiPersonale;
using System.IO;

namespace PersonaleWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txt_cod.Focus();
        }

        string[] tipologie = new string[] { "Aziendale", "SubFornitore", "Fornitore", "Consulente" };
        List<Persona> Persone = new List<Persona>();
        private HashSet<string> esistenti = new HashSet<string>();

        public void cmb_loader(object sender,RoutedEventArgs e)
        {
            foreach(string s in tipologie)
            {
                cmb_tipologia.Items.Add(s);
            }
        }

        private void LeggiFile()
        {
            string line;
            StreamReader sr = new StreamReader(filec.DIR + filec.file);

            do
            {
                line = sr.ReadLine();
                if (line != null)
                {
                    string[] personale = line.Split(';');
                    esistenti.Add(personale[0]);
                }
            } while (line != null);

            sr.Close();
        }

        private void btn_Esci_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Pulisci_Click(object sender, RoutedEventArgs e)
        {
            txt_cod.Clear();
            txt_Cognome.Clear();
            txt_nome.Clear();
            cmb_tipologia.SelectedIndex = -1;
        }

        private void btn_Inserisci_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_cod.Text == null)
                    throw new Exception("Riempire il campo Cod.Fiscale");
                if (txt_nome.Text == null)
                    throw new Exception("Riempire il campo Nome");
                if (txt_Cognome.Text == null)
                    throw new Exception("Riempire il campo Cognome");
                if (cmb_tipologia.SelectedIndex == -1)
                    throw new Exception("Devi selezionare una Tipologia");

                Persona p = new Persona(txt_cod.Text, txt_nome.Text, txt_Cognome.Text, cmb_tipologia.SelectedIndex);

                if (esistenti.Contains(p.CodiceFiscale))
                    throw new Exception("Codice fiscale già esistente");
                else
                {
                    esistenti.Add(txt_cod.Text);
                }
                if (cmb_tipologia.SelectedIndex == 0)
                    new Qualifiche(p).ShowDialog();
                if (cmb_tipologia.SelectedIndex == 1)
                    MessageBox.Show("Presto disponibile!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (cmb_tipologia.SelectedIndex == 2)
                    MessageBox.Show("Presto disponibile!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                if (cmb_tipologia.SelectedIndex == 3)
                    MessageBox.Show("Presto disponibile!", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            catch
            {
                MessageBox.Show(ex.Message, "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
