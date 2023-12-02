using AplicativoPromotor.MVVM.Model.SoviPage;
using AplicativoPromotor.MVVM.Shared;
using AplicativoPromotor.MVVM.ViewModel.SoviPage;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace AplicativoPromotor.MVVM.View.SoviPage
{
    public partial class ResumoPage : ContentPage
    {
        private ObservableCollection<ProductsModel> _craftProductsModels;
        public ObservableCollection<ProductsModel> CraftProductsModels
        {
            get { return _craftProductsModels; }
            private set
            {
                _craftProductsModels = value;
                OnPropertyChanged(nameof(CraftProductsModels));
            }
        }

        private ObservableCollection<ProductsModel> _premiumProductsModels;
        public ObservableCollection<ProductsModel> PremiumProductsModels
        {
            get { return _premiumProductsModels; }
            private set
            {
                _premiumProductsModels = value;
                OnPropertyChanged(nameof(PremiumProductsModels));
            }
        }

        private ObservableCollection<ProductsModel> _mainStreamProductsModels;
        public ObservableCollection<ProductsModel> MainStreamProductsModels
        {
            get { return _mainStreamProductsModels; }
            private set
            {
                _mainStreamProductsModels = value;
                OnPropertyChanged(nameof(MainStreamProductsModels));
            }
        }

        public ResumoPage()
        {
            InitializeComponent();
            InitializeCarouselHeights();
            InitializeCarouselItems();
        }

        private void InitializeCarouselItems()
        {
            var ViewModel = new CategoryViewModel();

            CraftProductsModels = ViewModel.CreateProductsModelCollection(PagesSovi.Craft);
            OnPropertyChanged(nameof(CraftProductsModels));  // Adicione esta linha

            PremiumProductsModels = ViewModel.CreateProductsModelCollection(PagesSovi.Premium);
            OnPropertyChanged(nameof(PremiumProductsModels));  // Adicione esta linha

            MainStreamProductsModels = ViewModel.CreateProductsModelCollection(PagesSovi.MainStream);
            OnPropertyChanged(nameof(MainStreamProductsModels));  // Adicione esta linha

            // Force an update by setting ItemsSource to null and then back to the collection
            //CarouselCraft.ItemsSource = null;
            CarouselCraft.ItemsSource = CraftProductsModels;
            //CarouselPremium.ItemsSource = null;
            CarouselPremium.ItemsSource = PremiumProductsModels;
            //CarouselMainStream.ItemsSource = null;
            CarouselMainStream.ItemsSource = MainStreamProductsModels;
        }

        private Dictionary<PagesSovi, double> carouselHeights = new Dictionary<PagesSovi, double>();

        private void InitializeCarouselHeights()
        {
            foreach (PagesSovi pageType in Enum.GetValues(typeof(PagesSovi)))
            {
                carouselHeights[pageType] = 0;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            InitializeCarouselItems();
            SetCarouselHeights();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            UpdateCarouselHeights();
            // Remova a assinatura do evento PropertyChanged para evitar memory leak
            CraftProductsModels = null;
            PremiumProductsModels = null;
            MainStreamProductsModels = null;
        }

        private void SetCarouselHeights()
        {
            foreach (PagesSovi pageType in Enum.GetValues(typeof(PagesSovi)))
            {
                double height = GetCarouselHeightForPageType(pageType);
                carouselHeights[pageType] = height;

                SetCarouselHeight(pageType, height);
            }
        }

        private double GetCarouselHeightForPageType(PagesSovi pageType)
        {
            switch (pageType)
            {
                case PagesSovi.Craft:
                    return CarouselCraft.Height;
                case PagesSovi.Premium:
                    return CarouselPremium.Height;
                case PagesSovi.MainStream:
                    return CarouselMainStream.Height;
                // Adicione mais casos conforme necessário
                default:
                    return 0;
            }
        }

        private void SetCarouselHeight(PagesSovi pageType, double height)
        {
            switch (pageType)
            {
                case PagesSovi.Craft:
                    CarouselCraft.HeightRequest = height;
                    break;
                case PagesSovi.Premium:
                    CarouselPremium.HeightRequest = height;
                    break;
                case PagesSovi.MainStream:
                    CarouselMainStream.HeightRequest = height;
                    break;
                    // Adicione mais casos conforme necessário
            }
        }

        private void UpdateCarouselHeights()
        {
            foreach (PagesSovi pageType in Enum.GetValues(typeof(PagesSovi)))
            {
                carouselHeights[pageType] = GetCarouselHeightForPageType(pageType);
            }
        }

        //void ItemChanged(ProductsModel item)
        //{
        //    PreviousProductsModel = CurrentProductsModel;
        //    CurrentProductsModel = item;
        //    OnPropertyChanged("PreviousProductsModel");
        //    OnPropertyChanged("CurrentProductsModel");
        //}

        //void PositionChanged(int position)
        //{
        //    PreviousPosition = CurrentPosition;
        //    CurrentPosition = position;
        //    OnPropertyChanged("PreviousPosition");
        //    OnPropertyChanged("CurrentPosition");
        //}

        //void RemoveProductsModel(ProductsModel ProductsModel)
        //{
        //    if (CraftProductsModels.Contains(ProductsModel))
        //    {
        //        CraftProductsModels.Remove(ProductsModel);
        //    }
        //}

        //void FilterItems(string filter)
        //{
        //    var filteredItems = CraftProductsModels
        //        .Where(ProductsModel => ProductsModel.Name.ToLower().Contains(filter.ToLower()))
        //        .ToList();

        //    CraftProductsModels.Clear();
        //    foreach (var ProductsModel in filteredItems)
        //    {
        //        CraftProductsModels.Add(ProductsModel);
        //    }
        //}
    }
}
