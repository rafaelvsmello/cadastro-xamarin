using App_Cadastro.Models;
using LiteDB;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Cadastro.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listar : ContentPage
    {
        LiteDatabase _dataBase;
        LiteCollection<Dados> Registros;

        public string GetFilePath(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }

        void Carregar()
        {
            try
            {
                _dataBase = new LiteDatabase(GetFilePath("Banco.db"));
                Registros = (LiteCollection<Dados>)_dataBase.GetCollection<Dados>();

                if (Registros.Count() > 0)
                {
                    lstDados.ItemsSource = Registros.FindAll();
                    BindingContext = this;
                }
                else
                {
                    DisplayAlert("Atenção", "Nenhum registro para exibir", "OK");
                }

                
            }
            catch (Exception ex)
            {
                DisplayAlert("Ocorreu um erro", ex.Message, "OK");
            }
        }
        public Listar()
        {
            InitializeComponent();
            Carregar();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        
    }
}