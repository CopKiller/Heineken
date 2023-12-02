using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicativoPromotor.MVVM.Shared;
using AplicativoPromotor.MVVM.Model.SoviPage;
using System.Collections.ObjectModel;

namespace AplicativoPromotor.MVVM.ViewModel.SoviPage
{
    internal class CategoryViewModel
    {
        public CategoryViewModel() { }

        public ObservableCollection<ProductsModel> CreateProductsModelCollection(PagesSovi pagesSovi)
        {
            CategoryModel productCategory = new CategoryModel();

            switch (pagesSovi)
            {
                case PagesSovi.Craft:
                    // Criação de categoria Craft
                    productCategory = CreateCraftProducts();
                    // Adição de produtos à categoria acima
                    PopulateCraftProducts(productCategory);
                    break;
                case PagesSovi.Premium:
                    // Criação de categoria Premium
                    productCategory = CreatePremiumProducts();
                    // Adição de produtos à categoria acima
                    PopulatePremiumProducts(productCategory);
                    break;
                case PagesSovi.MainStream:
                    // Criação de categoria MainStream
                    productCategory = CreateMainStreamProducts();
                    // Adição de produtos à categoria acima
                    PopulateMainStreamProducts(productCategory);
                    break;
            }

            var products = productCategory.Products.ToList();

            var result = new ObservableCollection<ProductsModel>(products);

            return result;
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

                Products.Products[i].Name = GetValues.GetEnumName(productEnum);
                Products.Products[i].Space.Centimeters = SharedSoviInfos.GetProductSpace(PagesSovi.Craft, productEnum);
                Products.Products[i].Space.Percentage = totalSpace != 0 ? Math.Round(Products.Products[i].Space.Centimeters / totalSpace * 100, 2) : 0;
                Products.Products[i].Space.MetaCentimeters = SharedSoviInfos.GetProductMetaCentimeters(PagesSovi.Craft, productEnum);
                Products.Products[i].Space.MetaPercentage = SharedSoviInfos.GetProductMetaPercentage(PagesSovi.Craft, productEnum);

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
                Products.Products[i].Space.MetaCentimeters = SharedSoviInfos.GetProductMetaCentimeters(PagesSovi.Premium, productEnum);
                Products.Products[i].Space.MetaPercentage = SharedSoviInfos.GetProductMetaPercentage(PagesSovi.Premium, productEnum);

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
                Products.Products[i].Space.MetaCentimeters = SharedSoviInfos.GetProductMetaCentimeters(PagesSovi.MainStream, productEnum);
                Products.Products[i].Space.MetaPercentage = SharedSoviInfos.GetProductMetaPercentage(PagesSovi.MainStream, productEnum);

                Products.Products[i].Picture = GetValues.GetEnumDescription(productEnum);
            }
        }
    }
}
