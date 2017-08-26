using System;
using Xamarin.Forms;
using static Redux.Store;

namespace Redux
{
    public partial class MainPage : ContentPage
    {
        public Store Store { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Store = new Store(new State());
            BindingContext = Store;
        }

        private void Button_Clicked_Minus(object sender, EventArgs e)
        {
            Store.Dispather(new ActionMinus(), Store.State);
        }

        private void Button_Clicked_Plus(object sender, EventArgs e)
        {
            Store.Dispather(new ActionPlus(), Store.State);
        }
    }
}