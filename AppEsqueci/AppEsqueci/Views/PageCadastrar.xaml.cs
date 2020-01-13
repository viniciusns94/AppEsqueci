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
    public partial class PageCadastrar : ContentPage
    {
        public PageCadastrar()
        {
            InitializeComponent();
        }

        private void Button_pagecadastrar_salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelNotas nota = new ModelNotas();
                nota.Titulo = entry_pagecadastrar_titulo.Text;
                nota.Dados = editor_pagecadastrar_dados.Text;
                nota.Favorito = swFavorito.IsToggled;

                ServicesDBNotas dbNotas = new ServicesDBNotas(App.DbPath);

                if (button_pagecadastrar_salvar.Text == "Inserir")
                {
                    dbNotas.Inserir(nota);
                    DisplayAlert("Resultado da operação: ", dbNotas.StatusMessage, "OK");
                }
                else //Alterar
                {

                }
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new PageHome();
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void Button_pagecadastrar_cancelar_Clicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new PageHome();
        }
    }
}