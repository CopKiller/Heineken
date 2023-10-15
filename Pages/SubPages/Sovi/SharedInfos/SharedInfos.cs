using System.Text.Json;

namespace AplicativoPromotor.Pages.SubPages.Sovi
{
    public enum CraftProdutos
    {
        Badden,
        Bluemoon,
        Lagunitas,
    }
    public enum PremiumProdutos
    {
        Heineken,
        Heineken00,
    }
    public enum MainStreamProdutos
    {
        Amstel,
        Devassa
    }
    public enum PagesSovi
    {
        Craft,
        Premium,
        MainStream
    }

    public static class SharedSoviInfos
    {
        public static List<PagesData> Pages;

        public static async Task InitPages()
        {
            Pages = new List<PagesData>();



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
                produtoType = (int)CraftProdutos.Badden,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int)CraftProdutos.Bluemoon,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) CraftProdutos.Lagunitas,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };

            Pages.Add(craftPage);

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
                produtoType = (int) PremiumProdutos.Heineken,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) PremiumProdutos.Heineken00,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };

            Pages.Add(premiumPage);

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
                produtoType = (int) MainStreamProdutos.Amstel,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            },
            new ProdutosData
            {
                produtoType = (int) MainStreamProdutos.Devassa,
                produtoSovi = 0,
                produtoCentimetro = new int[9]
            }
                }
            };

            Pages.Add(mainStreamPage);

            return Task.CompletedTask;
        }

        public static int GetEspacoCategoria(PagesSovi pagina, CraftProdutos produto)
        {
            int espacoTotal = 0;

            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;

                int espacoIndividual = Pages[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
                espacoTotal += espacoIndividual;
            }

            return espacoTotal;
        }
        public static int GetEspacoCategoria(PagesSovi pagina, PremiumProdutos produto)
        {
            int espacoTotal = 0;

            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;

                int espacoIndividual = Pages[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
                espacoTotal += espacoIndividual;
            }

            return espacoTotal;
        }
        public static int GetEspacoCategoria(PagesSovi pagina, MainStreamProdutos produto)
        {
            int espacoTotal = 0;

            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;

                int espacoIndividual = Pages[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
                espacoTotal += espacoIndividual;
            }

            return espacoTotal;
        }

        public static async Task SavePagesToFile()
        {
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, "dadosapp.json");

            var json = JsonSerializer.Serialize(Pages);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async static Task<List<PagesData>> ReadPagesFromFile()
        {
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, "dadosapp.json");

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