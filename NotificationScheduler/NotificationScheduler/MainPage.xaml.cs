using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotificationScheduler
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            List<String> stringsItems = new List<string>();
            stringsItems.Add("Alarm");
            stringsItems.Add("Calendar");
            stringsItems.Add("Ring");
            LvControls.ItemsSource = stringsItems;
        }

        private void btnTakePic_Click(object sender, RoutedEventArgs e)
        {
            //Windows.Phone.Devices.Notification.VibrationDevice.GetDefault().Vibrate(new TimeSpan(TimeSpan.TicksPerSecond * 3));

            //Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI("+38762267377", "Salih Hajlakovic");
            // Windows.Phone.UI.Input.HardwareButtons.CameraPressed += HardwareButtons_CameraPressed;
            //Windows.Phone.Media.Devices.AudioRoutingManager.GetDefault()
            GetPreview();
        }

        async private void GetPreview()
        {
            Windows.Media.Capture.MediaCapture takePhotoManager = new Windows.Media.Capture.MediaCapture();
            await takePhotoManager.InitializeAsync();

            // start previewing
            PhotoPreview.Source = takePhotoManager;
            await takePhotoManager.StartPreviewAsync();
            // to stop it
            await takePhotoManager.StopPreviewAsync();

            ImageEncodingProperties imgFormat = ImageEncodingProperties.CreateJpeg();

            // a file to save a photo
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    "Photo.jpg", CreationCollisionOption.ReplaceExisting);

            await takePhotoManager.CapturePhotoToStorageFileAsync(imgFormat, file);

            // Get photo as a BitmapImage
            BitmapImage bmpImage = new BitmapImage(new Uri(file.Path));

            // imagePreivew is a <Image> object defined in XAML
            imagePreivew.Source = bmpImage;
        }

        private void HardwareButtons_CameraPressed(object sender, Windows.Phone.UI.Input.CameraEventArgs e)
        {
            
        }
    }
}
