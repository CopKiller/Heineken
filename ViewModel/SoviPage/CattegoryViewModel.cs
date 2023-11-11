
using AplicativoPromotor.Model.SoviPage;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AplicativoPromotor.Pages.SubPages.Sovi.ResumoPage
{
    public class CattegoryModelsViewModel : INotifyPropertyChanged
    {
        readonly IList<CategoryModel> source;

        public ObservableCollection<CategoryModel> CattegoryModels { get; private set; }
        public IList<CategoryModel> EmptyCattegoryModels { get; private set; }

        public CategoryModel PreviousCattegoryModel { get; set; }
        public CategoryModel CurrentCattegoryModel { get; set; }
        public CategoryModel CurrentItem { get; set; }
        public int PreviousPosition { get; set; }
        public int CurrentPosition { get; set; }
        public int Position { get; set; }

        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand ItemChangedCommand => new Command<CategoryModel>(ItemChanged);
        public ICommand PositionChangedCommand => new Command<int>(PositionChanged);
        public ICommand DeleteCommand => new Command<CategoryModel>(RemoveCattegoryModel);

        //public ICommand FavoriteCommand => new Command<CategoryModel>(FavoriteCattegoryModel);

        public CattegoryModelsViewModel()
        {
            source = new List<CategoryModel>();
            CreateCattegoryModelCollection();

            CurrentItem = CattegoryModels.Skip(3).FirstOrDefault();
            OnPropertyChanged("CurrentItem");
            Position = 3;
            OnPropertyChanged("Position");
        }

        void CreateCattegoryModelCollection()
        {
            // Criação de categoria
            var craftCategory = CreateCraftCategory();
            source.Add(craftCategory);

            // Adição de produtos à categoria acima
            PopulateCraftProducts(craftCategory);

            // Converte a lista de categorias para uma ObservableCollection
            CattegoryModels = new ObservableCollection<CategoryModel>(source);
        }

        private CategoryModel CreateCraftCategory()
        {
            var craftCategory = new CategoryModel
            {
                CategoryName = "CRAFT's",
                TotalSpace = SharedSoviInfos.GetAllCraftSpace(),
                CategorySpace = SharedSoviInfos.GetAllCraftPortfolioSpace(),
                Products = new ProductsModel[Enum.GetValues(typeof(CraftProducts)).Cast<int>().Max() + 1]
            };

            return craftCategory;
        }

        private void PopulateCraftProducts(CategoryModel category)
        {
            var craftProducts = category.Products;
            int totalSpace = category.TotalSpace;

            for (int i = 0; i < craftProducts.Length; i++)
            {
                var product = craftProducts[i];
                CraftProducts productEnum = (CraftProducts)i;

                product.Name = Enum.GetName(typeof(CraftProducts), productEnum);
                product.Space.Centimeters = SharedSoviInfos.GetProductSpace(PagesSovi.Craft, productEnum);
                product.Space.Percentage = (product.Space.Centimeters / totalSpace) * 100;
            }
        }


        void FilterItems(string filter)
        {
            var filteredItems = source.Where(CattegoryModel => CattegoryModel.CategoryName.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var CattegoryModel in source)
            {
                if (!filteredItems.Contains(CattegoryModel))
                {
                    CattegoryModels.Remove(CattegoryModel);
                }
                else
                {
                    if (!CattegoryModels.Contains(CattegoryModel))
                    {
                        CattegoryModels.Add(CattegoryModel);
                    }
                }
            }
        }

        void ItemChanged(CategoryModel item)
        {
            PreviousCattegoryModel = CurrentCattegoryModel;
            CurrentCattegoryModel = item;
            OnPropertyChanged("PreviousCattegoryModel");
            OnPropertyChanged("CurrentCattegoryModel");
        }

        void PositionChanged(int position)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition = position;
            OnPropertyChanged("PreviousPosition");
            OnPropertyChanged("CurrentPosition");
        }

        void RemoveCattegoryModel(CategoryModel CattegoryModel)
        {
            if (CattegoryModels.Contains(CattegoryModel))
            {
                CattegoryModels.Remove(CattegoryModel);
            }
        }

        //void FavoriteCattegoryModel(CategoryModel CattegoryModel)
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
