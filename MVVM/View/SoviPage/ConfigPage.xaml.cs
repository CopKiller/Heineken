using AplicativoPromotor.MVVM.Model.SoviPage;
using AplicativoPromotor.MVVM.Shared;
using AplicativoPromotor.MVVM.ViewModel.SoviPage;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace AplicativoPromotor.MVVM.View.SoviPage
{
    public partial class ConfigPage : ContentPage
    {
        public int SelectedPerfil;

        public ConfigPage()
        {
            InitializeComponent();

            Task.Run(() => LoadingData());
        }
        private async Task LoadingData()
        {
            await SharedSoviInfos.InitPages();

            await LoadingPickerData();
        }

        private async Task LoadingPickerData()
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                // Add items from the current profile data
                var lstPerfil = new List<string>();
                foreach (var perfil in SharedSoviInfos.SharedPerfil.Perfil)
                {
                    lstPerfil.Add(perfil.PerfilName);
                }
                PerfilPicker.ItemsSource = lstPerfil;

                // Se necessário, selecione o perfil padrão ou atual
                SelectedPerfil = SharedSoviInfos.SharedPerfil.SelectedPerfil;
                PerfilPicker.SelectedIndex = SelectedPerfil;
            });
        }
        private void OnPerfilPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((Picker)sender).SelectedIndex >= 0)
            {
                SharedSoviInfos.SharedPerfil.SelectedPerfil = PerfilPicker.SelectedIndex;
                SelectedPerfil = SharedSoviInfos.SharedPerfil.SelectedPerfil;
                EntryPerfilName.Text = SharedSoviInfos.SharedPerfil.Perfil[SelectedPerfil].PerfilName;
            }
        }

        private void ButtonAtualizar_Clicked(object sender, EventArgs e)
        {
            var perfilName = EntryPerfilName.Text;
            var length = perfilName.TrimStart().TrimEnd().Length;
            var lengthMax = PerfilModel.MaxCharPerfilName;
            var selectedPerfil = SharedSoviInfos.SharedPerfil.SelectedPerfil;

            if (length > 0 && length <= lengthMax)
            {
                SharedSoviInfos.SharedPerfil.Perfil[selectedPerfil].PerfilName = perfilName;
                SharedSoviInfos.SavePagesToFile();

                perfilName = SharedSoviInfos.SharedPerfil.Perfil[selectedPerfil].PerfilName;
            }
            else
            {
                perfilName = SharedSoviInfos.SharedPerfil.Perfil[selectedPerfil].PerfilName;
            }

            EntryPerfilName.Text = perfilName;
            _ = LoadingPickerData();

        }
    }

}
