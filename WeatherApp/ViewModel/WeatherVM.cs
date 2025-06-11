using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Model;
using WeatherApp.ViewModel.Commands;
using WeatherApp.ViewModel.Helpers;

namespace WeatherApp.ViewModel
{
        public class WeatherVM : INotifyPropertyChanged
        {
            #region Constructors
            public WeatherVM()
            { 
                // This code is only for DesignMode to view the values.
                if(DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                {
                    SelectedCity = new City();
                    SelectedCity.LocalizedName = "New York";

                    CurrentConditions = new CurrentConditions
                    {
                        WeatherText = "Partly cloudy",
                        Temperature = new Temperature
                        {
                            Metric = new Units
                            {
                                Value = "21"
                            }
                        }
                    };
                }

                SearchCommand = new SearchCommand(this);
                Cities = new ObservableCollection<City>();          // Initial the new observable collection of City.
            }
            #endregion

#region Properties
            #region Query property
            private string query;

            public string Query
            {
                get { return query; }
                set 
                {
                    query = value;
                    OnPropertyChanged("Query");
                }
            }
            #endregion

            #region CurrentConditions property
            private CurrentConditions currentConditions;

            public CurrentConditions CurrentConditions
            {
                get { return currentConditions; }
                set 
                { 
                    currentConditions = value;
                    OnPropertyChanged("CurrentConditions");
                }
            }
            #endregion

            #region SelectedCity property
            private City selectedCity;
            public City SelectedCity
            {
                get { return selectedCity; }

                set 
                { 
                    selectedCity = value;

                    OnPropertyChanged("SelectedCity");

                    if (!DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                        GetCurrentConditions();
                }
            }
            #endregion

            public SearchCommand SearchCommand { get; set; }

            public ObservableCollection<City> Cities { get; set; }
#endregion

            #region events
            public event PropertyChangedEventHandler? PropertyChanged;
            #endregion

            #region methods
            ///  <Summary> 
            ///  This method is used with ICommand when the search button is pressed. 
            ///  <Summary>
            public async void MakeQuery()
            {
                var cities = await AccuWeatherHelper.GetCities(Query);

                Cities.Clear();         // First clear the observable collection Cities.
                foreach (var city in cities)
                    Cities.Add(city);
            }

            private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            private async void GetCurrentConditions()
            {
                Query = string.Empty;
                Cities.Clear();

                CurrentConditions = await AccuWeatherHelper.GetCurrentConditions(SelectedCity.Key);
            }
            #endregion
        }
    }
    