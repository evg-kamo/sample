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
            // 画面がロードされた時
            base.OnAppearing();

            // データ表示
            collectionView.ItemsSource = await App.Database.GetPeopleAsync();
        }

        // 登録ボタン押下
        async void OnButtonClicked(object sender, EventArgs e)
        {
            // nameEntryが空白でない場合
            if (!string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                // ローカルDBに登録
                await App.Database.SavePersonAsync(new Person
                {
                    Name = nameEntry.Text
                });

                // nameEntryを空文字にする
                nameEntry.Text = string.Empty;

                // 表示する
                collectionView.ItemsSource = await App.Database.GetPeopleAsync();
            }
        }

        // カレンダーアイコン押下
        async void Ondisplaycalenderclicked(object sender, EventArgs e)
        {
            // ポップアップ表示
            await DisplayAlert("カレンダー", "This is Calender!!!", "OK");
        }

        // カメラアイコン押下
        async void Ondisplaycameraclicked(object sender, EventArgs e)
        {
            // ポップアップ表示(タイトル・説明文・ボタン)
            await DisplayAlert("カメラ", "これはカメラです!!!", "OK");
        }

        // 貯金箱アイコン押下
        async void Ondisplaymoneyclicked(object sender, EventArgs e)
        {
            // ポップアップ表示
            await DisplayAlert("貯金箱", "이것은 돼지 저금통!!!", "OK");
        }

        // 設定アイコン押下
        async void Ondisplaysettingclicked(object sender, EventArgs e)
        {
            // ポップアップ表示
            await DisplayAlert("設定", "这是设置画面!!!", "OK");
        }
    }
}
