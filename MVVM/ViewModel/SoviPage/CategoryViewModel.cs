using AplicativoPromotor.MVVM.Shared;
using AplicativoPromotor.MVVM.Model.SoviPage;
using Syncfusion.Licensing;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AplicativoPromotor.MVVM.ViewModel.SoviPage
{
    public class CategoryViewModel : INotifyPropertyChanged
    {

        // --> Lista com todas as categorias
        readonly IList<CategoryModel> source;

        // --> Collection observável do componente
        public ObservableCollection<ProductsModel> CraftProductsModels { get; private set; } //Craft
        public ObservableCollection<ProductsModel> PremiumProductsModels { get; private set; } //Premium
        public ObservableCollection<ProductsModel> MainStreamProductsModels { get; private set; } //Main Stream
        public IList<ProductsModel> EmptyProductsModels { get; private set; }

        public ProductsModel PreviousProductsModel { get; set; }
        public ProductsModel CurrentProductsModel { get; set; }
        public ProductsModel CurrentItem { get; set; }
        public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand ItemChangedCommand => new Command<ProductsModel>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);
        public ICommand DeleteCommand => new Command<ProductsModel>(RemoveProductsModel);

        //public ICommand FavoriteCommand => new Command<ProductsModel>(FavoriteCattegoryModel);

        public CategoryViewModel()
        {
            source = new List<CategoryModel>();
            CreateProductsModelCollection();

            CurrentItem = CraftProductsModels.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        void CreateProductsModelCollection()
        {
            // Criação de categoria Craft
            var craftProducts = CreateCraftProducts();
            source.Add(craftProducts);
            // Adição de produtos à categoria acima
            PopulateCraftProducts(craftProducts);

            // Criação de categoria Premium
            var premiumProducts = CreatePremiumProducts();
            source.Add(premiumProducts);
            // Adição de produtos à categoria acima
            PopulatePremiumProducts(premiumProducts);

            // Criação de categoria MainStream
            var mainStreamProducts = CreateMainStreamProducts();
            source.Add(mainStreamProducts);
            // Adição de produtos à categoria acima
            PopulateMainStreamProducts(mainStreamProducts);

            // Converte a lista de categorias para uma ObservableCollection
            var productsModels = source[(int)PagesSovi.Craft].Products.ToList();
            CraftProductsModels = new ObservableCollection<ProductsModel>(productsModels);

            productsModels = source[(int)PagesSovi.Premium].Products.ToList();
            PremiumProductsModels = new ObservableCollection<ProductsModel>(productsModels);

            productsModels = source[(int)PagesSovi.MainStream].Products.ToList();
            MainStreamProductsModels = new ObservableCollection<ProductsModel>(productsModels);
        }
        private CategoryModel CreateCraftProducts()
        {
            var length = Enum.GetValues(typeof(CraftProducts)).Length;

            var craftProducts = new CategoryModel
            {
                CategoryName = "CRAFT's",
                TotalSpace = SharedSoviInfos.GetAllCraftSpace(),
                CategorySpace = SharedSoviInfos.GetAllCraftPortfolioSpace(),
                Products = new ProductsModel[length]
            };

            for (var i = 0; i < length; i++)
            {
                craftProducts.Products[i] = new ProductsModel();
            }

            return craftProducts;
        }

        private CategoryModel CreatePremiumProducts()
        {
            var length = Enum.GetValues(typeof(PremiumProducts)).Length;

            var premiumProducts = new CategoryModel
            {
                CategoryName = "PREMIUM's",
                TotalSpace = SharedSoviInfos.GetAllPremiumSpace(),
                CategorySpace = SharedSoviInfos.GetAllPremiumPortfolioSpace(),
                Products = new ProductsModel[length]
            };

            for (var i = 0; i < length; i++)
            {
                premiumProducts.Products[i] = new ProductsModel();
            }

            return premiumProducts;
        }

        private CategoryModel CreateMainStreamProducts()
        {
            var length = Enum.GetValues(typeof(MainStreamProducts)).Length;

            var mainStreamProducts = new CategoryModel
            {
                CategoryName = "MAINSTREAM's",
                TotalSpace = SharedSoviInfos.GetAllMainStreamSpace(),
                CategorySpace = SharedSoviInfos.GetAllMainStreamPortfolioSpace(),
                Products = new ProductsModel[length]
            };

            for (var i = 0; i < length; i++)
            {
                mainStreamProducts.Products[i] = new ProductsModel();
            }

            return mainStreamProducts;
        }

        private void PopulateCraftProducts(CategoryModel Products)
        {

            //var craftProducts = Products.Products;
            double totalSpace = Products.TotalSpace;

            for (int i = 0; i < Products.Products.Length; i++)
            {
                CraftProducts productEnum = (CraftProducts)i;

                //Debug.Print(Enum.GetName(typeof(CraftProducts), productEnum));

                //Products.Products[i].Name = Enum.GetName(typeof(CraftProducts), productEnum);
                Products.Products[i].Name = GetValues.GetEnumName(productEnum);
                Products.Products[i].Space.Centimeters = SharedSoviInfos.GetProductSpace(PagesSovi.Craft, productEnum);
                Products.Products[i].Space.Percentage = totalSpace != 0 ? Math.Round(((Products.Products[i].Space.Centimeters / totalSpace) * 100), 2) : 0;

                Products.Products[i].Picture = GetValues.GetEnumDescription(productEnum);
            }
        }

        private void PopulatePremiumProducts(CategoryModel Products)
        {

            //var craftProducts = Products.Products;
            int totalSpace = Products.TotalSpace;

            for (int i = 0; i < Products.Products.Length; i++)
            {
                PremiumProducts productEnum = (PremiumProducts)i;

                Products.Products[i].Name = GetValues.GetEnumName(productEnum);
                Products.Products[i].Space.Centimeters = SharedSoviInfos.GetProductSpace(PagesSovi.Premium, productEnum);
                Products.Products[i].Space.Percentage = totalSpace != 0 ? Products.Products[i].Space.Centimeters / totalSpace * 100 : 0;

                Products.Products[i].Picture = GetValues.GetEnumDescription(productEnum);
            }
        }

        private void PopulateMainStreamProducts(CategoryModel Products)
        {

            //var craftProducts = Products.Products;
            int totalSpace = Products.TotalSpace;

            for (int i = 0; i < Products.Products.Length; i++)
            {
                MainStreamProducts productEnum = (MainStreamProducts)i;

                Products.Products[i].Name = GetValues.GetEnumName(productEnum);
                Products.Products[i].Space.Centimeters = SharedSoviInfos.GetProductSpace(PagesSovi.MainStream, productEnum);
                Products.Products[i].Space.Percentage = totalSpace != 0 ? Products.Products[i].Space.Centimeters / totalSpace * 100 : 0;

                Products.Products[i].Picture = GetValues.GetEnumDescription(productEnum);
            }
        }


        void FilterItems(string filter)
        {
            var filteredItems = CraftProductsModels.Where(ProductsModel => ProductsModel.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var ProductsModel in CraftProductsModels)
            {
                if (!filteredItems.Contains(ProductsModel))
                {
                    CraftProductsModels.Remove(ProductsModel);
                }
                else
                {
                    if (!CraftProductsModels.Contains(ProductsModel))
                    {
                        CraftProductsModels.Add(ProductsModel);
                    }
                }
            }
        }

        void ItemChanged(ProductsModel item)
        {
            PreviousProductsModel = CurrentProductsModel;
            CurrentProductsModel = item;
            OnPropertyChanged("PreviousProductsModel");
            OnPropertyChanged("CurrentProductsModel");
        }

        void PositionChanged(int position)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
            OnPropertyChanged("PreviousPosition");
            OnPropertyChanged("CurrentPosition");
        }

        void RemoveProductsModel(ProductsModel ProductsModel)
        {
            if (CraftProductsModels.Contains(ProductsModel))
            {
                CraftProductsModels.Remove(ProductsModel);
            }
        }

        //void FavoriteCattegoryModel(ProductsModel CattegoryModel)
        //{
        //    CattegoryModel.IsFavorite = !CattegoryModel.IsFavorite;
        //}

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
