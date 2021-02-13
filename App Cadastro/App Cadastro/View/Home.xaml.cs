using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Cadastro.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Cadastro());
        }

        private async void btnAlterar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Alterar());
        }

        private async void btnExluir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Excluir());
        }

        private async void btnListar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listar());
        }
    }
}