using DesignRSC.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace DesignRSC.ViewModel
{
    public class ListItemManVM : Page, INotifyPropertyChanged
    {

        DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();


        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<OtherItem> _items = new ObservableCollection<OtherItem>();


        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public ObservableCollection<OtherItem> Lista
        {
            get
            {

                return _items;
            }
            set
            {
                _items = value;
                NotifyPropertyChanged("izbrisano");
            }
        }
        private void ShareTextHandler(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;

            // The Title is mandatory
            request.Data.Properties.Title = "Share Text Example";

            // Now add the data you want to share.
            request.Data.Properties.Description = "A demonstration that shows how to share text.";
            request.Data.SetText("Hello World!");
        }
        public ListItemManVM()
        {

            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.ShareTextHandler);

            for (int i = 0; i < 7; i++)
            {
                OtherItem oi = new OtherItem();
                oi.ManipulationDelta += MainPage_ManipulationDelta;
                oi.ManipulationStarted += MainPage_ManipulationStarted;
                oi.ManipulationCompleted += MainPage_ManipulationCompleted;
                oi.ManipulationMode = ManipulationModes.TranslateX;
                oi.IsTapEnabled = false;
                oi.Holding += ItemHolding;
                oi.PointerReleased += FocusLost;
                //oi.IsHoldingEnabled = false;
                oi.IsTabStop = false;
                //oi.IsEnabled = false;
                //oi.ManipulationMode = ManipulationModes.TranslateY;
                _items.Add(oi);
            }
        }
        bool avaliable = true;
        private void ItemHolding (object sender, HoldingRoutedEventArgs e)
        {
            
            if (avaliable)
            {
                avaliable = false;
                MenuFlyout mf = new MenuFlyout();
                mf.Placement = FlyoutPlacementMode.Bottom;

                MenuFlyoutItem _share = new MenuFlyoutItem();
                _share.Text = "Share";
                _share.Click += ShareTask;
                mf.Items.Add(_share);

                MenuFlyoutItem _delete = new MenuFlyoutItem();
                _delete.Text = "Delete";
                mf.Items.Add(_delete);

                mf.ShowAt((FrameworkElement)sender);
            }
        }
        private void FocusLost(object sender, RoutedEventArgs e)
        {
            avaliable = true;
        }

        private void ShareTask(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.DataTransfer.DataTransferManager.ShowShareUI();
        }

        int x1, x2;
        private void MainPage_ManipulationStarted(object sender, ManipulationStartedRoutedEventArgs e)
        {
            x1 = (int)e.Position.X;
        }

        int currentPosition;
        private void MainPage_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var item = (OtherItem)sender;
            x2 = (int)e.Position.X;
            if (x2 > currentPosition)
            {
                currentPosition = x2;
                Thickness t = new Thickness(x2, 0, 0, 0);
                item.Margin = t;
            }
            if (x2 > x1 * 4.1)
            {
                item.HorizontalAlignment = HorizontalAlignment.Right;
                //Thickness t = new Thickness(110, 0, 0, 0);
                //item.Margin = t;
            }
        }

        private void MainPage_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {
            currentPosition = 0;
            x2 = (int)e.Position.X;
            if (x2 > x1 * 4.1)
            {
                _items.Remove((OtherItem)sender);
                NotifyPropertyChanged("izbrisano");
            }
            else
            {
                var item = (OtherItem)sender;
                Thickness t = new Thickness(10, 0, 0, 0);
                item.Margin = t;
            }
        }
        
    }

}
