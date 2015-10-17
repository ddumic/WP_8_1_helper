using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.Networking.Proximity;
using Windows.Phone.Devices.Notification;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace suitApp.Helper
{
    public class MobileHelper
    {
        public static void MobileVibration()
        {
            VibrationDevice testVibrationDevice = VibrationDevice.GetDefault();
            testVibrationDevice.Vibrate(TimeSpan.FromSeconds(0.2));
        }

        public static string CheckTheme()
        {
            Visibility darkBackgroundVisibility = (Visibility)Application.Current.Resources["PhoneDarkThemeVisibility"];
            if (darkBackgroundVisibility == Visibility.Visible)
            {
                return "dark";
            }
            else
            {
                return "white";
            }
        }

        private static bool CheckInternetetConnection()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                return true;
            }
            return false;
        }


        public static async void MessageBoxDialog(string message)
        {
            ResourceLoader resourceLoader = new ResourceLoader();
            string messageString = resourceLoader.GetString(message);
            MessageDialog msgbox = new MessageDialog(messageString);
            await msgbox.ShowAsync();
        }


        public static void ProgressBarControl(ProgressBar progress, Visibility visibility)
        {
            progress.Visibility = visibility;
        }


        public static async Task<object> HttpRequest(string url, object abstractObject)
        {
            HttpClient client = new HttpClient();

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(abstractObject.GetType());
                //loginJSON odgovor = JsonConvert.DeserializeObject<loginJSON>(response.Content.ReadAsStringAsync().Result);
                object returnObject = Activator.CreateInstance(abstractObject.GetType());
                returnObject = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                return returnObject;
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static async Task<object> HttpRequest(string url, object abstractObject, List<KeyValuePair<string, string>> content)
        {
            HttpClient client = new HttpClient();
            var header = new FormUrlEncodedContent(content);

            var response = await client.PostAsync(url, header);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(abstractObject.GetType());
                //loginJSON odgovor = JsonConvert.DeserializeObject<loginJSON>(response.Content.ReadAsStringAsync().Result);
                object returnObject = Activator.CreateInstance(abstractObject.GetType());
                returnObject = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);
                return returnObject;
            }
            else
            {
                return response.StatusCode.ToString();
            }
        }

        public static void GetNewToken()
        {

        }


        public void RecognizeNFC()
        {
            ProximityDevice device = ProximityDevice.GetDefault();
            if (device != null)
            {
                device.DeviceArrived += _proximityDevice_DeviceArrived;
                device.DeviceDeparted += ProximityDeviceDeparted;
            }
        }
        private void _proximityDevice_DeviceArrived(Windows.Networking.Proximity.ProximityDevice device)
        {
            Debug.WriteLine("pronasa san uredjaj");
            //Debug.WriteLine("Received from {0}:'{1}'", sender.DeviceId, message.DataAsString);
        }

        private void ProximityDeviceDeparted(Windows.Networking.Proximity.ProximityDevice device)
        {
            Debug.WriteLine("otisa je uredjaj");
        }

        public async void MultipartPostRequest(byte[] fb)
        {
            using (var client = new HttpClient())
            {
                using (var content =
                    new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    /*content.Add(new StringContent(GlobalHelpers.ReadFromSettings("token")), "token");
                    content.Add(new StringContent(review.GroupId), "groupId");
                    content.Add(new StringContent(review.Comment), "comment");
                    content.Add(new StringContent(review.Latitude), "latitude");
                    content.Add(new StringContent(review.Longitude), "longitude");
                    content.Add(new StringContent(review.Rating.ToString()), "rating");
                    content.Add(new StringContent(review.Time.ToString()), "comment");*/
                    content.Add(new StreamContent(new MemoryStream(fb)), "file", "file.jpg");
                    using (
                        var message =
                            await client.PostAsync("http://128.199.32.207:8080/Reviewer/api/reviews", content))
                        message.EnsureSuccessStatusCode();
                    {

                    }
                }
            }

        }

    }
}
