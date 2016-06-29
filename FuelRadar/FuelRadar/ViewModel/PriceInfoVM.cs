using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using GalaSoft.MvvmLight.Command;
using PropertyChanged;
using Plugin.ExternalMaps;
using Plugin.ExternalMaps.Abstractions;

using FuelRadar.Data;
using FuelRadar.Model;
using FuelRadar.Settings;
using FuelRadar.UI.Toast;

namespace FuelRadar.ViewModel
{
    [ImplementPropertyChanged]
    public class PriceInfoVM
    {
        #region | EmptyPage | 
        public bool IsEmptyPage { get; set; }
        #endregion // EmptyPage

        public Station RepresentedStation { get; set; }
        public Price RepresentedPrice { get; set; }

        public String Name
        {
            get { return this.RepresentedStation.Name; }
        }

        public GlobalCoordinate Location
        {
            get { return this.RepresentedStation.Location; }
        }

        public Brand Brand
        {
            get { return this.RepresentedStation.Brand; }
        }

        public bool IsPriceAvailable
        {
            get { return this.RepresentedPrice != null; }
        }

        public String MainPriceType
        {
            get { return this.SelectedFuelType.Name(); }
        }

        public double MainPrice
        {
            get { return (this.RepresentedPrice != null) ? this.RepresentedPrice.GetPrice(this.SelectedFuelType) : 0; }
        }

        public String MainPriceString
        {
            get { return this.MainPrice.ToString() + " €"; }
        }

        public String SecondPriceType
        {
            get { return this.SelectedFuelType.Next().Name(); }
        }

        public double SecondPrice
        {
            get { return (this.RepresentedPrice != null) ? this.RepresentedPrice.GetPrice(this.SelectedFuelType.Next()) : 0; }
        }

        public String SecondPriceString
        {
            get { return this.SecondPrice.ToString() + " €"; }
        }

        public String ThirdPriceType
        {
            get { return this.SelectedFuelType.Next().Next().Name(); }
        }

        public double ThirdPrice
        {
            get { return (this.RepresentedPrice != null) ? this.RepresentedPrice.GetPrice(this.SelectedFuelType.Next().Next()) : 0; }
        }

        public String ThirdPriceString
        {
            get { return this.ThirdPrice.ToString() + " €"; }
        }

        public ICommand Navigate { get; set; }

        public bool IsFavorite { get; set; }

        public String FavoriteText
        {
            get { return this.IsFavorite ? "Aus Favoriten entfernen" : "Zu Favoriten hinzufügen"; }
        }

        public String FavoriteIcon
        {
            get { return this.IsFavorite ? "favorite_remove" : "favorite_add.png"; }
        }

        public ICommand ToggleFavorite
        {
            get { return this.IsFavorite ? this.RemoveFromFavorites : this.AddToFavorites; }
        }

        private ICommand AddToFavorites;
        private ICommand RemoveFromFavorites;

        private FuelType SelectedFuelType { get; set; }

        public PriceInfoVM(PriceInfo repObject, bool isFav = false)
        {
            this.IsEmptyPage = false;
            this.SelectedFuelType = AppSettings.FuelType;
            this.RepresentedStation = repObject.GasStation;
            this.RepresentedPrice = repObject.CurrentPrice;
            this.Navigate = new RelayCommand(() => this.StartNavigation());
            this.AddToFavorites = new RelayCommand(() => this.AddStationToFavorites());
            this.RemoveFromFavorites = new RelayCommand(() => this.RemoveStationFromFavorites());
            this.IsFavorite = isFav || DbDataProvider.Instance.IsFavorite(this.RepresentedStation.ID);
        }

        private void StartNavigation()
        {
            CrossExternalMaps.Current.NavigateTo(this.RepresentedStation.Name, this.RepresentedStation.Location.Latitude, 
                this.RepresentedStation.Location.Longitude, NavigationType.Driving);
        }

        private void AddStationToFavorites()
        {
            bool favoriteKicked = DbDataProvider.Instance.AddFavouriteStation(this.RepresentedStation);
            if (favoriteKicked) CrossToast.ShowToast("Ein Favorit wurde entfernt und durch diese Tankstelle ersetzt.");
            this.IsFavorite = DbDataProvider.Instance.IsFavorite(this.RepresentedStation.ID);
        }

        private void RemoveStationFromFavorites()
        {
            DbDataProvider.Instance.RemoveFavouriteStation(this.RepresentedStation.ID);
            this.IsFavorite = DbDataProvider.Instance.IsFavorite(this.RepresentedStation.ID);
        }

    }
}
