﻿using BookScanner.OpenLibClient;
using System;
using System.Linq;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;

namespace BookScanner
{
    public partial class MainPage : ContentPage
    {
        ZXingScannerPage scanPage;
        private OpenLibraryClient _client;

        public MainPage()
        {
            InitializeComponent();
            _client = new OpenLibraryClient();
        }

        private async void ScanButton_Clicked(object sender, EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += UpdateBookInformation;
            await Navigation.PushAsync(scanPage);
        }

        private void UpdateBookInformation(Result result)
        {
            scanPage.IsScanning = false;

            Device.BeginInvokeOnMainThread(async () =>
            {
                await Navigation.PopAsync();
                var bookResult = await _client.GetBookByIsbnAsync(result.Text);
                if(bookResult == null)
                {
                    BookInformationsLayout.IsVisible = false;
                    DisplayAlert("No book found for scanned barcode", result.Text, "OK");
                    return;
                }

                BookInformationsLayout.IsVisible = true;
                TitleLabel.Text = bookResult.title;
                PublischerLbl.Text = bookResult.publishers?.FirstOrDefault()?.name;
                AuthorsLbl.Text = bookResult.AuthorsText;
                if (bookResult.cover != null)
                    Image.Source = ImageSource.FromUri(new Uri(bookResult.cover.large));

            });
        }
    }
}
