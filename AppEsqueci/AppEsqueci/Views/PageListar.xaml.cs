using AppEsqueci.Models;
using AppEsqueci.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppEsqueci.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageListar : ContentPage
    {
        public PageListar()
        {
            InitializeComponent();
            AtualizaLista();
        }

        public object ModelNota { get; private set; }

        public void InserirItens()
        {
            ModelNotas nota = new ModelNotas();
            nota.Titulo = "Teste " + DateTime.Now.ToString();
            nota.Dados = "Testando dados";
            nota.Favorito= false;

            ServicesDBNotas dbNotas = new ServicesDBNotas(App.DbPath);
            dbNotas.Inserir(nota);
            DisplayAlert("Resultado da operação: ", dbNotas.StatusMessage, "OK");
        }

        public void AtualizaLista()
        {
            ServicesDBNotas dBNotas = new ServicesDBNotas(App.DbPath);
            listview_pagelistar_listarnotas.ItemsSource = dBNotas.Listar();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            InserirItens();
            AtualizaLista();
        }
    }
}