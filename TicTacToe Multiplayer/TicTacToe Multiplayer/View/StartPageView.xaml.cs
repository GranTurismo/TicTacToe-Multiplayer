using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe_Multiplayer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPageView : ContentPage
    {
        static string _relevantGroupId = string.Empty;
        HubConnection hub = null;
        public StartPageView()
        {
            InitializeComponent();
            hub = new HubConnectionBuilder()
                .WithUrl("http://10.0.2.2:5001/ttt")
                .Build();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await hub.StartAsync();
            await hub.SendAsync("Join", hub.ConnectionId);
            hub.On<string>("JoinCallback", JoinCallback);
        }

        public async void JoinCallback(string id)
        {
            _relevantGroupId = id;
            await DisplayAlert("Connected", $"You Joined Group {_relevantGroupId}"ნწ , "OK");
        }
    }
}