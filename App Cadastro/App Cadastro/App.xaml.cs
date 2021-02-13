using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App_Cadastro.View;

namespace App_Cadastro
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Home());
        }
        
    }
}
