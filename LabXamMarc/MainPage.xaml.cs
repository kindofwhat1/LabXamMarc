using LabXamMarc.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LabXamMarc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RetriveCrimesAsync();
        }

        // Collect data of crimes
        private async Task RetriveCrimesAsync()
        {
            try
            {
                string apiURL = @"https://brottsplatskartan.se/api/events";
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(new Uri(apiURL));
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Crime crimeList = JsonConvert.DeserializeObject <Crime>(content);

                    // loop för att ta bort <p> taggar´i beskrivning
                    foreach (var item in crimeList.data)
                    {
                        item.content = Regex.Replace(item.content, "<.*?>", String.Empty);
                    }

                    crimelst.ItemsSource = crimeList.data;

                }
                else
                    // Lägg till annat meddelande, typ att api kan använts för många gånger etc
                    await DisplayAlert("Error", "We are sorry, the internet connection is not available.", "OK");
            }
            catch (Exception e)
            {
                await DisplayAlert("Error" , "We are sorry, the internet connection is not available. ("+ e.Message + ")", "OK");
            }
            
        }
    }
}
