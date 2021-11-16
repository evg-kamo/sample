using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        // 登録ボタン押下
        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text
                });

                nameEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }

        // カレンダーアイコン押下
        async void Ondisplaycalenderclicked(object sender, EventArgs e)
        {
            await DisplayAlert("カレンダー", "This is Calender!!!", "OK");
        }

        // カメラアイコン押下
        async void Ondisplaycameraclicked(object sender, EventArgs e)
        {
            await DisplayAlert("カメラ", "これはカメラです!!!", "OK");
        }

        // 貯金箱アイコン押下
        async void Ondisplaymoneyclicked(object sender, EventArgs e)
        {
            await DisplayAlert("貯金箱", "이것은 돼지 저금통!!!", "OK");
        }

        // 設定アイコン押下
        async void Ondisplaysettingclicked(object sender, EventArgs e)
        {
            await DisplayAlert("設定", "这是设置画面!!!", "OK");
        }
    }
}
