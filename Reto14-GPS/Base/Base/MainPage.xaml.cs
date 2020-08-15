using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Base
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnGPS.Clicked += BtnGPS_Clicked;
            btnNet.Clicked += BtnNet_Clicked;
        }

        private void BtnNet_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BtnGPS_Clicked(object sender, EventArgs e)
        {
            ObtenerUbica();
        }

        private async void ObtenerUbica()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = GeolocationAccuracy.Medium,
                        Timeout = TimeSpan.FromSeconds(30)
                    });
                }
                if (location == null)
                {
                    lblLocaliza.Text = "No hay GPS";
                }
                else
                {
                    lblLocaliza.Text = $"{location.Latitude}{location.Longitude}";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Algo sale mal :{ ex.Message}");
            }
        }
    }
}
