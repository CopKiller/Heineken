

using System;
using System.ComponentModel;
using System.Text.Json;

namespace AplicativoPromotor.Pages.SubPages.Sovi
{
    public enum ProdutosSovi
    {
        Badden,
        Bluemoon,
        Lagunitas,
        Heineken,
        Heineken00,
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
                    produtosSovi = ProdutosSovi.Badden,
                    ProdutoSovi = 0,
                    ProdutoCentimetros = new int[9]
                },
                new InfosProdutos
                {
                    produtosSovi = ProdutosSovi.Bluemoon,
                    ProdutoSovi = 0,
                    ProdutoCentimetros = new int[9]
                },
                new InfosProdutos
                {
                    produtosSovi = ProdutosSovi.Lagunitas,
                    ProdutoSovi = 0,
                    ProdutoCentimetros = new int[9]
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
                    produtosSovi = ProdutosSovi.Heineken,
                    ProdutoSovi = 0,
                    ProdutoCentimetros = new int[9]
                },
                new InfosProdutos
                {
                    produtosSovi = ProdutosSovi.Heineken00,
                    ProdutoSovi = 0,
                    ProdutoCentimetros = new int[9]
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
                    produtosSovi = ProdutosSovi.Amstel,
                    ProdutoSovi = 0,
                    ProdutoCentimetros = new int[9]
                },
                new InfosProdutos
                {
                    produtosSovi = ProdutosSovi.Devassa,
                    ProdutoSovi = 0,
                    ProdutoCentimetros = new int[9]
                }
                }
            };

            Pages.Add(mainStreamPage);
        }
        public static int GetEspacoCategoria(PagesSovi pagina, ProdutosSovi produto)
        {
            int espacoTotal = 0;

            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;

                int espacoIndividual = Pages[(int)pagina].Produtos[(int)produto].ProdutoCentimetros[i];
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
        public ProdutosSovi produtosSovi { get; set; }
        public byte ProdutoSovi { get; set; }
        public int[] ProdutoCentimetros { get; set; }
    }
}