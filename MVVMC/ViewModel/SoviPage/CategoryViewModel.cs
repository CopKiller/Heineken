using AplicativoPromotor.MVVMC.Controller;
using AplicativoPromotor.MVVMC.Model.SoviPage;
using Syncfusion.Licensing;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AplicativoPromotor.MVVMC.ViewModel.SoviPage
{
    public class CategoryViewModel : INotifyPropertyChanged
    {

        // --> Lista com todas as categorias
        readonly IList<CategoryModel> source;

        // --> Collection observável do componente
        public ObservableCollection<ProductsModel> ProductsModels { get; private set; }
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

            CurrentItem = ProductsModels.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        void CreateProductsModelCollection()
        {
            // Criação de categoria
            var craftProducts = CreateCraftProducts();
            source.Add(craftProducts);

            // Adição de produtos à categoria acima
            PopulateCraftProducts(craftProducts);

            // Converte a lista de categorias para uma ObservableCollection
            var productsModels = source[(int)PagesSovi.Craft].Products.ToList();

            //source[].Products;
            ProductsModels = new ObservableCollection<ProductsModel>(productsModels);
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

        private void PopulateCraftProducts(CategoryModel Products)
        {

            //var craftProducts = Products.Products;
            int totalSpace = Products.TotalSpace;

            for (int i = 0; i < Products.Products.Length; i++)
            {
                CraftProducts productEnum = (CraftProducts)i;

                //Debug.Print(Enum.GetName(typeof(CraftProducts), productEnum));

                //Products.Products[i].Name = Enum.GetName(typeof(CraftProducts), productEnum);
                Products.Products[i].Name = GetValues.GetEnumName(productEnum);
                Products.Products[i].Space.Centimeters = SharedSoviInfos.GetProductSpace(PagesSovi.Craft, productEnum);
                Products.Products[i].Space.Percentage = Products.Products[i].Space.Centimeters / totalSpace * 100;

                Products.Products[i].Picture = GetValues.GetEnumDescription(productEnum);
            }
        }


        void FilterItems(string filter)
        {
            var filteredItems = ProductsModels.Where(ProductsModel => ProductsModel.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var ProductsModel in ProductsModels)
            {
                if (!filteredItems.Contains(ProductsModel))
                {
                    ProductsModels.Remove(ProductsModel);
                }
                else
                {
                    if (!ProductsModels.Contains(ProductsModel))
                    {
                        ProductsModels.Add(ProductsModel);
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
            if (ProductsModels.Contains(ProductsModel))
            {
                ProductsModels.Remove(ProductsModel);
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
