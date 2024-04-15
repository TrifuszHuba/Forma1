using Forma1.Model;
using Forma1.ViewModel.Commands;
using Forma1.ViewModel.Helper;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forma1.ViewModel
{
    public class MainVM
    {
        public List<Csapat> Csapatok { get; set; }
        public string NévQuery { get; set; } = String.Empty;
        public Csapat SelectedCsapat { get; set; }
        public ObservableCollection<Versenyző> Versenyzők { get; set; } = new();

        public SearchCommand SearchCommand { get; set; }

        public MainVM() {
            Csapatok = SqlData.Select();
            SelectedCsapat = Csapatok[0];
            GetVersenyzők();

            SearchCommand = new SearchCommand(this);
        }

        public void GetVersenyzők()
        {
            Versenyzők.Clear();
            var versenyzők = SqlData.VSelect(NévQuery, SelectedCsapat.Csapatnév);
            foreach (var item in versenyzők)
            {
                Versenyzők.Add(item);
            }
        }

        public void Delete()
        {

        }
    }
}
