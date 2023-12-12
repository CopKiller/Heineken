using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;

namespace AplicativoPromotor.MVVM.Shared
{

    public static class SharedSoviInfos
    {
        // Implementa a versão no JSON, para saber se houve alterações na estrutura
        // Alterar aqui sempre quando houver alguma mudança na estrutura do código.
        public const int CurrentVersion = 1;
        public const string FileName = "dadosapp.json";

        // Como a interface do XAML não recebe retorno de métodos diretamente
        // Adicionei aqui no topo os dados que serão utilizados na página Resumo do XAML
        public static int GetAllCraftSpace()
        {
            var selectedPerfil = SharedPerfil.SelectedPerfil;
            var pageID = (int)PagesSovi.Craft;

            return SharedPerfil.Perfil[selectedPerfil].PagesSovi[pageID].TotalCentimetros;
        } // Total
        public static int GetAllPremiumSpace()
        {
            var selectedPerfil = SharedPerfil.SelectedPerfil;
            var pageID = (int)PagesSovi.Premium;

            return SharedPerfil.Perfil[selectedPerfil].PagesSovi[pageID].TotalCentimetros;
        } // Total
        public static int GetAllMainStreamSpace()
        {
            var selectedPerfil = SharedPerfil.SelectedPerfil;
            var pageID = (int)PagesSovi.MainStream;

            return SharedPerfil.Perfil[selectedPerfil].PagesSovi[pageID].TotalCentimetros;
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

        public static ConfigModel SharedPerfil;

        public static async Task InitPages()
        {
            SharedPerfil = new ConfigModel();
            SharedPerfil.Version = CurrentVersion;

            await LoadingData();
        }

        #region Obter Espaço Centimetros- GetProductSpace
        public static int GetProductSpace(PagesSovi pagina, CraftProducts produto)
        {
            int espacoTotal = 0;
            // Itera através dos espaços ocupados pelo produto em 9 posições
            for (int i = 0; i < 9; i++)
            {
                var indiceReal = i;


                int espacoIndividual = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
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

                int espacoIndividual = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
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

                int espacoIndividual = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoCentimetro[i];
                espacoTotal += espacoIndividual;
            }

            return espacoTotal;
        }
        #endregion

        #region Obter Meta Porcentagem - GetProductMetaPercentage
        public static double GetProductMetaPercentage(PagesSovi pagina, CraftProducts produto)
        {

            double meta = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoSovi;
            return meta;
        }
        public static double GetProductMetaPercentage(PagesSovi pagina, PremiumProducts produto)
        {

            double meta = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoSovi;
            return meta;
        }
        public static double GetProductMetaPercentage(PagesSovi pagina, MainStreamProducts produto)
        {

            double meta = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoSovi;
            return meta;
        }
        #endregion

        #region Obter Meta Cent - GetProductMetaCentimeters
        public static int GetProductMetaCentimeters(PagesSovi pagina, CraftProducts produto)
        {

            int meta = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoSovi;
            int espaco = GetAllCraftSpace();
            double result = Convert.ToDouble(meta > 0 && espaco > 0 ? (meta / 100f) * espaco : 0);

            return Convert.ToInt32(result);
        }

        public static int GetProductMetaCentimeters(PagesSovi pagina, PremiumProducts produto)
        {

            int meta = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoSovi;
            int espaco = GetAllPremiumSpace();
            double result = Convert.ToDouble(meta > 0 && espaco > 0 ? (meta / 100f) * espaco : 0);

            return Convert.ToInt32(result);
        }

        public static int GetProductMetaCentimeters(PagesSovi pagina, MainStreamProducts produto)
        {

            int meta = SharedPerfil.Perfil[SharedPerfil.SelectedPerfil].PagesSovi[(int)pagina].Produtos[(int)produto].produtoSovi;
            int espaco = GetAllMainStreamSpace();
            double result = Convert.ToDouble(meta > 0 && espaco > 0 ? (meta / 100f) * espaco : 0);

            return Convert.ToInt32(result);
        }
        #endregion

        public static async Task SavePagesToFile()
        {
            try
            {
                string mainDir = FileSystem.AppDataDirectory;
                string filePath = Path.Combine(mainDir, FileName);

                var json = JsonSerializer.Serialize(SharedPerfil, new JsonSerializerOptions { WriteIndented = true });
                await File.WriteAllTextAsync(filePath, json);
            }
            catch (IOException ioException)
            {
                Debug.WriteLine($"IOException ao salvar o arquivo: {ioException.Message}");
                throw; // Tratamento específico para IOException (pode ocorrer ao acessar o arquivo)
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exceção ao salvar o arquivo: {ex.Message}");
                throw; // Tarefa falhada com a exceção fornecida
            }
        }

        public static void ClearFileData()
        {
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, FileName);

            File.Delete(filePath);
        }

        public static async Task<ConfigModel> ReadPagesFromFile()
        {
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, FileName);

            if (!File.Exists(filePath))
            {
                await SavePagesToFile();
            }

            // Agora que as páginas foram salvas, leia novamente o arquivo
            await Task.Run(async () =>
            {
                var json = await File.ReadAllTextAsync(filePath);
                SharedPerfil = JsonSerializer.Deserialize<ConfigModel>(json);
            });

            return SharedPerfil;
        }

        public static async Task LoadingData()
        {
            var cfgModel = await SharedSoviInfos.ReadPagesFromFile();
            string mainDir = FileSystem.AppDataDirectory;
            string filePath = Path.Combine(mainDir, FileName);

            if (cfgModel.Version == 0)
            {
                cfgModel.Version = CurrentVersion;
                ClearFileData();
                await SavePagesToFile();
            }
            else if (cfgModel.Version == CurrentVersion)
            {
                SharedSoviInfos.SharedPerfil = cfgModel;
            } else
            {

            }
        }
    }
}