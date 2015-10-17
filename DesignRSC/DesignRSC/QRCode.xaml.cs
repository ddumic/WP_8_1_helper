using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Capture;
using Windows.Media.MediaProperties;
using Windows.Storage.Streams;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using ZXing;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace DesignRSC
{
    public sealed partial class QRCode : Page
    {
        private MediaCapture _mediaCapture;
        public QRCode()
        {
            this.InitializeComponent();
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private async Task InitializeQrCode()
        {
            // Find all available webcams
            DeviceInformationCollection webcamList = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);

            // Get the proper webcam (default one)
            DeviceInformation backWebcam = (from webcam in webcamList
                                            where webcam.IsEnabled
                                            select webcam).FirstOrDefault();

            // Initializing MediaCapture
            _mediaCapture = new MediaCapture();
            await _mediaCapture.InitializeAsync(new MediaCaptureInitializationSettings
            {
                VideoDeviceId = backWebcam.Id,
                AudioDeviceId = "",
                StreamingCaptureMode = StreamingCaptureMode.Video,
                PhotoCaptureSource = PhotoCaptureSource.VideoPreview
            });

            // Set the source of CaptureElement to MediaCapture
            captureElement.Source = _mediaCapture;
            await _mediaCapture.StartPreviewAsync();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            await InitializeQrCode();
            var imgProp = new ImageEncodingProperties { Subtype = "BMP", Width = 600, Height = 800 };
            var bcReader = new BarcodeReader();

            while (true)
            {
                var stream = new InMemoryRandomAccessStream();
                await _mediaCapture.CapturePhotoToStreamAsync(imgProp, stream);

                stream.Seek(0);
                var wbm = new WriteableBitmap(600, 800);
                await wbm.SetSourceAsync(stream);

                var result = bcReader.Decode(wbm);

                if (result != null)
                {
                    var msgbox = new MessageDialog(result.Text);
                    await msgbox.ShowAsync();
                }
            }

        }
    }
}
