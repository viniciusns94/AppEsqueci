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

        public void AtualizaLista()
        {
            ServicesDBNotas dBNotas = new ServicesDBNotas(App.DbPath);
            if (switch_pagelistar_favorito.IsToggled)
                listview_pagelistar_listarnotas.ItemsSource = dBNotas.ListarFavoritos();
            else
                listview_pagelistar_listarnotas.ItemsSource = dBNotas.Listar();
        }

        private void Listview_pagelistar_listarnotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ModelNotas nota = (ModelNotas)listview_pagelistar_listarnotas.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new PageCadastrar(nota));
        }

        private void switch_pagelistar_favorito_Toggled(object sender, ToggledEventArgs e)
        {
            AtualizaLista();
        }
    }
}