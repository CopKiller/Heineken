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
        public static List<InfosPages> Pages;

        public static async Task InitPages()
        {
            Pages = new List<InfosPages>();



            // Inicialize as páginas chamando métodos separados
            await InitializeCraftPageAsync();
            await InitializePremiumPageAsync();
            await InitializeMainStreamPageAsync();
        }

        private static async Task InitializeCraftPageAsync()
        {
            var craftPage = new InfosPages
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new List<InfosProdutos>
            {
                new InfosProdutos
                {
                    produtoType = (int)CraftProdutos.Badden,
                    produtoSovi = 0,
                    produtoCentimetro = new int[9]
                },
                new InfosProdutos
                {
                    produtoType = (int)CraftProdutos.Bluemoon,
                    produtoSovi = 0,
                    produtoCentimetro = new int[9]
                },
                new InfosProdutos
                {
                    produtoType = (int) CraftProdutos.Lagunitas,
                    produtoSovi = 0,
                    produtoCentimetro = new int[9]
                }
            }
            };

            Pages.Add(craftPage);
        }

        private static async Task InitializePremiumPageAsync()
        {
            var premiumPage = new InfosPages
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new List<InfosProdutos>
                {new InfosProdutos
                {
                    produtoType = (int) PremiumProdutos.Heineken,
                    produtoSovi = 0,
                    produtoCentimetro = new int[9]
                },
                new InfosProdutos
                {
                    produtoType = (int) PremiumProdutos.Heineken00,
                    produtoSovi = 0,
                    produtoCentimetro = new int[9]
                }
                }
            };

            Pages.Add(premiumPage);
        }

        private static async Task InitializeMainStreamPageAsync()
        {
            var mainStreamPage = new InfosPages
            {
                TotalCentimetros = 0,
                PortfolioCentimetros = 0,
                Produtos = new List<InfosProdutos>
                {new InfosProdutos
                {
                    produtoType = (int) MainStreamProdutos.Amstel,
                    produtoSovi = 0,
                    produtoCentimetro = new int[9]
                },
                new InfosProdutos
                {
                    produtoType = (int) MainStreamProdutos.Devassa,
                    produtoSovi = 0,
                    produtoCentimetro = new int[9]
                }
                }
            };

            Pages.Add(mainStreamPage);
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
            string filePath = Path.Combine(mainDir, "dadosaqui.json");

            var json = JsonSerializer.Serialize(Pages);
            await File.WriteAllTextAsync(filePath, json);
        }

        public async static Task<List<InfosPages>> ReadPagesFromFile()
        {
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, "dadosaqui.json");

            if (File.Exists(filePath))
            {
                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<InfosPages>>(json);
            }
            else
            {
                await SavePagesToFile();

                var json = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<List<InfosPages>>(json);
            }
        }
    }

    public class InfosPages
    {
        public int TotalCentimetros { get; set; }
        public int PortfolioCentimetros { get; set; }
        public List<InfosProdutos> Produtos { get; set; }
    }

    public class InfosProdutos
    {
        // Tipo, usado com enum
        public int produtoType { get; set; }
        // Numerico, recebido pela Entry
        public byte produtoSovi { get; set; }
        // Centimetros de cada box em array
        public int[] produtoCentimetro { get; set; }
    }
}