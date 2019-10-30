using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using gMusic.Models;
using gMusic.Playback;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views
{
    public partial class EqualizerPickerPage : ContentPage
    {
        TaskCompletionSource<EqualizerPreset> tcs = new TaskCompletionSource<EqualizerPreset>();
        public Task<EqualizerPreset> SelectionAsync() => tcs.Task;

        public EqualizerPickerPage()
        {
            InitializeComponent();
            this.ListView.ItemsSource = EqualizerData.Presets;
            Title = Strings.EqualizerPresets;
            this.ToolbarItems.Add(new ToolbarItem(Strings.Cancel, "", () =>
              {
                  tcs.TrySetCanceled();
                  this.Navigation.PopModalAsync();
              }));
        }

        void ListView_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as EqualizerPreset;
            tcs.TrySetResult(item);

            this.Navigation.PopModalAsync();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            tcs.TrySetCanceled();
        }
    }
}
