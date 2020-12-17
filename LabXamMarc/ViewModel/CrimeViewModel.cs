using LabXamMarc.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace LabXamMarc.ViewModel
{
    public class CrimeViewModel: INotifyPropertyChanged 
    {
        public ObservableCollection<data> CrimeList { get; set; } = new ObservableCollection<data>();
        internal async System.Threading.Tasks.Task LoadCrimesAsync()
        {
         
            // Collect data of crimes
            try
                {
                   

                    string apiURL = @"https://brottsplatskartan.se/api/events";
                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.GetAsync(new Uri(apiURL));
                    if (response.IsSuccessStatusCode)
                    {
                    string content = await response.Content.ReadAsStringAsync();
                    Crime crimeList  = JsonConvert.DeserializeObject<Crime>(content);

                    foreach (var item in crimeList.data)
                    {
                        CrimeList.Add(item); 
                    }

                    //loop för att ta bort <p> taggar´i beskrivning
                    foreach (var item in crimeList.data)

                    {
                        item.content = Regex.Replace(item.content, "<.*?>", String.Empty);
                    }

                    RaisePropertyChanged(nameof(CrimeList)); 
                    }
                    else
                    await Application.Current.MainPage.DisplayAlert("Error", "There is an issue at the moment and the API could not be reached.", "OK");
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "There is an issue at the moment and the API could not be reached. (" + e.Message + ")", "OK");
                }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
