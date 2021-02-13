using App_Cadastro.Models;
using LiteDB;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App_Cadastro.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cadastro : ContentPage
    {
        public string GetFilePath(string file)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return Path.Combine(path, file);
        }

        void Cadastrar()
        {
            try
            {
                using (var db = new LiteDatabase(GetFilePath("Banco.db")))
                {
                    var col = db.GetCollection<Dados>("dados");                    

                    var dados = new Dados
                    {
                        Descricao = txtDescricao.Text,
                        Data = dtpData.Date,
                        Status = pckStatus.SelectedItem.ToString()
                    };

                    col.Insert(dados);
                    DisplayAlert("Atenção", "Cadastro realizado com sucesso", "OK");
                    txtDescricao.Text = string.Empty;
                    pckStatus.SelectedIndex = -1;
                    dtpData.Date = DateTime.Now;
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Ocorreu um erro", ex.Message, "OK");
            }
            
        }

        public Cadastro()
        {
            InitializeComponent();

            pckStatus.Items.Add("Pendente");
            pckStatus.Items.Add("Finalizado");
        }        

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                DisplayAlert("Atenção", "Informe a descrição", "OK");
            }
            else if (pckStatus.SelectedIndex == -1)
            {
                DisplayAlert("Atenção", "Informe um status", "OK");
            }
            else
            {
                Cadastrar();
            }
        }
    }
}