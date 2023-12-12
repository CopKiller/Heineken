using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicativoPromotor.MVVM.Shared
{
    public class ConfigModel
    {
        public int Version { get; set; } = SharedSoviInfos.CurrentVersion;

        public const int MaxPerfil = 3;

        public int SelectedPerfil { get; set; } = 0;

        public PerfilModel[] Perfil { get; set; }

        public ConfigModel()
        {
            // Inicialize o array com 3 posições
            Perfil = new PerfilModel[MaxPerfil];

            // Preencha cada posição do array com instâncias de PerfilModel (opcional)
            for (int i = 0; i < Perfil.Length; i++)
            {
                Perfil[i] = new PerfilModel($"Perfil {i + 1}", i);
            }
        }
    }
}
