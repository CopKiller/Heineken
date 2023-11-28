using System.ComponentModel;
using System.Diagnostics;


/* Alteração não mesclada do projeto 'AplicativoPromotor (net7.0-ios)'
Antes:
using System.Text.Json;
Após:
using System.Text.Json;
using AplicativoPromotor;
using AplicativoPromotor.Controller;
using AplicativoPromotor.Controller;
using AplicativoPromotor.Controller.SharedInfos;
*/
using System.Text.Json;

namespace AplicativoPromotor.MVVM.Shared
{

    public static class SharedSoviInfos
    {
        // Como a interface do XAML não recebe retorno de métodos diretamente
        // Adicionei aqui no topo os dados que serão utilizados na página Resumo do XAML
        public static int GetAllCraftSpace()
        {
            return PagesData[(int)PagesSovi.Craft].TotalCentimetros;
        } // Total
        public static int GetAllPremiumSpace()
        {
            return PagesData[(int)PagesSovi.Premium].TotalCentimetros;
        } // Total
        public static int GetAllMainStreamSpace()
        {
            return PagesData[(int)PagesSovi.MainStream].TotalCentimetros;
        } // Total

        public static int GetAllCraftPortfolioSpace()
        {
            int soma = 0;

            for (int i = 0; i < Enum.GetValues(typeof(CraftProducts)).Length; i++)
            {
                soma += GetProductSpace(PagesSovi.Craft, (CraftProducts)i);
            }

            return soma;
        } // Portfólio
        public static int GetAllPremiumPortfolioSpace()
        {
            int soma = 0;

            for (int i = 0; i < Enum.GetValues(typeof(PremiumProducts)).Length; i++)
            {
                soma += GetProductSpace(PagesSovi.Premium, (PremiumProducts)i);
            }

            return soma;
        } // Portfólio
        public static int GetAllMainStreamPortfolioSpace()
        {
            int soma = 0;

            for (int i = 0; i < Enum.GetValues(typeof(MainStreamProducts)).Length; i++)
            {
                soma += GetProductSpace(PagesSovi.MainStream, (MainStreamProducts)i);
            }

            return soma;
        } // Portfólio


        public static List<PagesData> PagesData;

        public static async Task InitPages()
        {
            PagesData = new List<PagesData>();



            // Inicialize as páginas chamando métodos separados
            await InitializeCraftPage();
            await InitializePremiumPage();
            await InitializeMainStreamPage();

            return;
        }

        private static Task InitializeCraftPage()
        {
            var craftPage = new PagesData
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new ProdutosData[]
                {
            new ProdutosData
            {
                produtoType = (int)CraftProducts.Badden,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int)CraftProducts.Bluemoon,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) CraftProducts.Lagunitas,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };

            PagesData.Add(craftPage);

            return Task.CompletedTask;
        }

        private static Task InitializePremiumPage()
        {
            var premiumPage = new PagesData
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new ProdutosData[]
                {
            new ProdutosData
            {
                produtoType = (int) PremiumProducts.Heineken,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) PremiumProducts.Heineken00,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) PremiumProducts.Eisenbahn,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) PremiumProducts.Sol,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };

            PagesData.Add(premiumPage);

            return Task.CompletedTask;
        }

        private static Task InitializeMainStreamPage()
        {
            var mainStreamPage = new PagesData
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new ProdutosData[]
                {
            new ProdutosData
            {
                produtoType = (int) MainStreamProducts.Amstel,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) MainStreamProducts.Devassa,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };

            PagesData.Add(mainStreamPage);

            return Task.CompletedTask;
        }

        public static int GetProductSpace(PagesSovi pagina, CraftProducts produto)
        {
            int espacoTotal = 0;
            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;

                int espacoIndividual = PagesData[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
                espacoTotal += espacoIndividual;
            }
            return espacoTotal;
        }
        public static int GetProductSpace(PagesSovi pagina, PremiumProducts produto)
        {
            int espacoTotal = 0;

            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;

                int espacoIndividual = PagesData[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
                espacoTotal += espacoIndividual;
            }

            return espacoTotal;
        }
        public static int GetProductSpace(PagesSovi pagina, MainStreamProducts produto)
        {
            int espacoTotal = 0;

            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;

                int espacoIndividual = PagesData[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
                espacoTotal += espacoIndividual;
            }

            return espacoTotal;
        }

        public static async Task SavePagesToFile()
        {
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, "dadosapp.json");

            var json = JsonSerializer.Serialize(PagesData);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async static Task<List<PagesData>> ReadPagesFromFile()
        {
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, "dadosapp.json");

            Debug.Print(filePath);

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<PagesData>>(json);
            }
            else
            {
                await SavePagesToFile();

                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<PagesData>>(json);
            }
        }
    }

    public class PagesData
    {
        public int TotalCentimetros { get; set; }
        public int PortfolioCentimetros { get; set; }
        public ProdutosData[] Produtos { get; set; }
    }

    public class ProdutosData
    {
        // Tipo, usado com enum
        public int produtoType { get; set; }
        // Numerico, recebido pela Entry
        public byte produtoSovi { get; set; }
        // Centimetros de cada box em array
        public int[] produtoCentimetro { get; set; }
    }
}