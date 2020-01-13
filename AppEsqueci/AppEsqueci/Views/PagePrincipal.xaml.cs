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
    public partial class PagePrincipal : MasterDetailPage
    {
        public PagePrincipal()
        {
            InitializeComponent();
            Button_pageprincipal_home_Clicked(new Object(), new EventArgs());
            testeDB.Text ="Dir: "+ App.DbPath + " Name: " + App.DbName;
        }

        private void FecharGaveta()
        {
            IsPresented = false;
        }

        private void Button_pageprincipal_home_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageHome());
            FecharGaveta();
        }

        private void Button_pageprincipal_cadastrar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageCadastrar());
            FecharGaveta();
        }

        private void Button_pageprincipal_listar_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageListar());
            FecharGaveta();
        }

        private void Button_pageprincipal_sobre_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new PageSobre());
            FecharGaveta();
        }
    }
}