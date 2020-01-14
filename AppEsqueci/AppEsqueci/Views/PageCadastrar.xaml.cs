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

        public PageCadastrar(ModelNotas nota)
        {
            InitializeComponent();
            button_pagecadastrar_salvar.Text = "Alterar";

            entry_pagecadastrar_codigo.IsVisible = true;
            button_pagecadastrar_excluir.IsVisible = true;

            entry_pagecadastrar_codigo.Text = nota.Id.ToString();
            entry_pagecadastrar_titulo.Text = nota.Titulo;
            editor_pagecadastrar_dados.Text = nota.Dados;
            switch_pagecadastrar_favorito.IsToggled = nota.Favorito;
        }

        private void Button_pagecadastrar_salvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelNotas nota = new ModelNotas();
                nota.Titulo = entry_pagecadastrar_titulo.Text;
                nota.Dados = editor_pagecadastrar_dados.Text;
                nota.Favorito = switch_pagecadastrar_favorito.IsToggled;

                ServicesDBNotas dbNotas = new ServicesDBNotas(App.DbPath);

                if (button_pagecadastrar_salvar.Text == "Inserir")
                {
                    dbNotas.Inserir(nota);
                    DisplayAlert("Resultado da operação: ", dbNotas.StatusMessage, "OK");
                }
                else //Alterar
                {
                    nota.Id = Convert.ToInt32(entry_pagecadastrar_codigo.Text);
                    dbNotas.Alterar(nota);
                    DisplayAlert("Resultado da operação: ", dbNotas.StatusMessage, "OK");
                }
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
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

        private async void Button_pagecadastrar_excluir_Clicked(object sender, EventArgs e)
        {
            var resp = await DisplayAlert("Excluir Registro", "Deseja realmente excluir a nota ?", "Sim", "Não");
            if (resp)
            {
                ServicesDBNotas dbNotas = new ServicesDBNotas(App.DbPath);
                int id = Convert.ToInt32(entry_pagecadastrar_codigo.Text);
                dbNotas.Excluir(id);
                DisplayAlert("Resultado da Operação", dbNotas.StatusMessage, "OK");

                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new PageHome());
            }
        }
    }
}