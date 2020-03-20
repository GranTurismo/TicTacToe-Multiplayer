using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe_Multiplayer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
            GenerateSquares();
        }

        private void GenerateSquares()
        {
            GenerateDefinitons();
            GenerateSquareViews();
        }

        private void GenerateSquareViews()
        {
            double numerate = 0.5;
            for(int i=0;i<3;i++)//row
                for(int k = 0; k < 3; k++)//column
                {
                    var newSquare = new Button()
                    {
                        BackgroundColor = Color.Transparent,
                        ClassId = (numerate *= 2).ToString(),
                        BorderWidth=2,
                        BorderColor=Color.Black,
                    };
                    Grid.SetRow(newSquare, i);
                    Grid.SetColumn(newSquare, k);
                    mainGrid.Children.Add(newSquare);
                }
        }

        private void GenerateDefinitons()
        {
            ColumnDefinitionCollection columnDefinitions = new ColumnDefinitionCollection();
            RowDefinitionCollection rowDefinitions = new RowDefinitionCollection();

            for (int i = 0; i < 3; i++)
            {
                rowDefinitions.Add(new RowDefinition()
                {
                    Height = GridLength.Star,
                });
                columnDefinitions.Add(new ColumnDefinition()
                {
                    Width = GridLength.Star
                });
            }
            mainGrid.ColumnDefinitions = columnDefinitions;
            mainGrid.RowDefinitions = rowDefinitions;
        }
    }
}