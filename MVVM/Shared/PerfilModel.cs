using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVM.Shared
{
    public class PerfilModel
    {
        public const int MaxCharPerfilName = 30;

        private string _perfilName { get; set; } = "Vazio";
        public string PerfilName
        {
            get
            {
                // Lógica personalizada no getter (por exemplo, converter para maiúsculas)
                return _perfilName;
            }
            set
            {
                // Lógica personalizada no setter (por exemplo, remover espaços em branco)
                if (_perfilName != value)
                {
                    if (value.Length <= MaxCharPerfilName && value.Length > 0)
                        _perfilName = value;
                }
            }
        }

        private int _perfilId { get; set; } = 0;
        public int PerfilId
        {
            get
            {
                // Lógica personalizada no getter (por exemplo, multiplicar por 2)
                return _perfilId;
            }
            set
            {
                // Lógica personalizada no setter (por exemplo, garantir que seja positivo)
                if (value < ConfigModel.MaxPerfil && value >= 0)
                {
                    _perfilId = value;
                }
            }
        }

        public PagesModel[] PagesSovi { get; set; }

        public PerfilModel()
        {
            PagesSovi = new PagesModel[Enum.GetValues(typeof(PagesSovi)).Length];

            InitializeCraftPage();
            InitializePremiumPage();
            InitializeMainStreamPage();
        }

        public PerfilModel(string perfilName, int perfilId)
        {
            PagesSovi = new PagesModel[Enum.GetValues(typeof(PagesSovi)).Length];

            PerfilName = perfilName;
            PerfilId = perfilId;

            InitializeCraftPage();
            InitializePremiumPage();
            InitializeMainStreamPage();
        }


        private void InitializeCraftPage()
        {
            PagesSovi[(int)Shared.PagesSovi.Craft] = new PagesModel
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new ProdutosModel[]
                {
            new ProdutosModel
            {
                produtoType = (int)CraftProducts.Badden,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosModel
            {
                produtoType = (int)CraftProducts.Bluemoon,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosModel
            {
                produtoType = (int) CraftProducts.Lagunitas,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };
        }

        private void InitializePremiumPage()
        {
            PagesSovi[(int)Shared.PagesSovi.Premium] = new PagesModel
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new ProdutosModel[]
                {
            new ProdutosModel
            {
                produtoType = (int) PremiumProducts.Heineken,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosModel
            {
                produtoType = (int) PremiumProducts.Heineken00,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosModel
            {
                produtoType = (int) PremiumProducts.Eisenbahn,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosModel
            {
                produtoType = (int) PremiumProducts.Sol,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };
        }

        private void InitializeMainStreamPage()
        {
            PagesSovi[(int)Shared.PagesSovi.MainStream] = new PagesModel
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new ProdutosModel[]
                {
            new ProdutosModel
            {
                produtoType = (int) MainStreamProducts.Amstel,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosModel
            {
                produtoType = (int) MainStreamProducts.Devassa,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };
        }
    }
}
