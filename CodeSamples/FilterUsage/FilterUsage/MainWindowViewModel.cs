using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Prism.Commands;
using Prism.Mvvm;

namespace FilterUsage
{
    public class MainWindowViewModel : BindableBase
    {
        private string searchCriteria;

        public string SearchCriteria
        {
            get { return searchCriteria; }
            set { SetProperty(ref searchCriteria, value); }
        }

        private Station selectedStaion;
        public Station SelectedStation
        {
            get { return selectedStaion; }
            set { SetProperty(ref selectedStaion, value); }
        }

        public DelegateCommand WindowLoadedCommand { get; set; }
        public DelegateCommand SearchTextChangedCommand { get; set; }
        public DelegateCommand ListViewLostFocusCommand { get; set; }
        public ObservableCollection<Station> StationList { get;  set;} = new ObservableCollection<Station>();

        public List<Station> stations = new List<Station>();

        public MainWindowViewModel()
        {
            WindowLoadedCommand = new DelegateCommand(WindowLoaded);
            SearchTextChangedCommand = new DelegateCommand(SearchTextChanged);
            ListViewLostFocusCommand = new DelegateCommand(ListViewLostFocus);
        }

        private void ListViewLostFocus()
        {
            //do something with the selected station
        }

        private void SearchTextChanged()
        {
            CollectionViewSource.GetDefaultView(StationList).Refresh();
        }

        private void LoadStationList()
        {
            stations = new List<Station>();
            stations.Add(new Station { StationName = "Mogra", StationId = 1 });
            stations.Add(new Station { StationName = "Dahisar", StationId = 2 });
            stations.Add(new Station { StationName = "Dahanukar Wadi", StationId = 3 });
            stations.Add(new Station { StationName = "Andheri", StationId = 4 });
            stations.Add(new Station { StationName = "National Park", StationId = 5 });
            stations.Add(new Station { StationName = "Gundavali", StationId = 6 });
            stations.Add(new Station { StationName = "Goregaon", StationId = 7 });
            StationList.AddRange(stations);
        }

        private void WindowLoaded()
        {
            LoadStationList();
            CollectionViewSource.GetDefaultView(StationList).Filter = FilterStations;
        }

        private bool FilterStations(object obj)
        {
            if (string.IsNullOrEmpty(SearchCriteria))
                return true;

            Station station = (Station)obj;

            var result = station.StationName.ToLower().StartsWith(SearchCriteria)
                || station.StationName.ToLower().Contains(SearchCriteria);

            return result;
        }
    }
}
