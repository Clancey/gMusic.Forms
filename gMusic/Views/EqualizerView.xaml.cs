using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using gMusic.Data;
using gMusic.Managers;
using gMusic.Models;
using gMusic.Playback;
using Localizations;
using Xamarin.Forms;

namespace gMusic.Views
{
    public partial class EqualizerView : ContentPage
    {
        public EqualizerView()
        {
            InitializeComponent();
            this.Title = Strings.Equalizer;

            Enumerable.Range(0, EqualizerData.Bands.Length)
                .ForEach(CreateSlider);
            ActiveSwitch.Toggled += ActiveSwitch_Toggled;
            ActiveSwitch.IsToggled = EqualizerData.Active;

        }

        private void Shared_EqualizerChanged(object sender, EventArgs e)
        {
            ApplyEqualizerPreset(EqualizerData.Bands);
        }

        private void ActiveSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            EqualizerData.Active = e.Value;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ActiveSwitch.Toggled += ActiveSwitch_Toggled;
            NotificationManager.Shared.EqualizerChanged += Shared_EqualizerChanged;
            ActiveSwitch.IsToggled = EqualizerData.Active;

            EqualizerPicker.Text = EqualizerData.CurrentPreset.Name;
            ApplyEqualizerPreset(EqualizerData.Bands);

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ActiveSwitch.Toggled -= ActiveSwitch_Toggled;
            NotificationManager.Shared.EqualizerChanged -= Shared_EqualizerChanged;
        }

        List<Slider> sliders = new List<Slider>();
        List<Label> labels = new List<Label>();

        void CreateSlider(int index)
        {
            var band = EqualizerData.Bands[index];
            var slider = new VerticalSlider();

            slider.Tag = index;
            slider.ValueChanged += Slider_ValueChanged;
            slider.Minimum = -1;
            slider.Maximum = 1;
            slider.Value = band.Gain / range;

            EqualizerGrid.Children.Add(slider, index, 0);
            var text = new Label
            {
                Text = band.ToString(),
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 10,
            };
            EqualizerGrid.Children.Add(text, index, 1);
            labels.Add(text);
            sliders.Add(slider);
        }

        static float range = 12f;
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var slider = sender as VerticalSlider;
            EqualizerData.UpdateBand(slider.Tag, (float)e.NewValue * range);
        }

        async void EqualizerPicker_Clicked(System.Object sender, System.EventArgs e)
        {
            var picker = new EqualizerPickerPage();
            this.Navigation.PushModalAsync(new NavigationPage(picker));
            try
            {
                var preset = await picker.SelectionAsync();
                EqualizerPicker.Text = preset.Name;
                EqualizerData.CurrentPreset = preset;

            }
            catch (TaskCanceledException)
            {

            }
        }

        void ApplyEqualizerPreset(Band[] bands)
        {
            if (sliders.Count == 0)
                return;
            Device.BeginInvokeOnMainThread(() =>
            {
                for (var i = 0; i < bands.Length; i++)
                {
                    sliders[i].Value = bands[i].Gain / range;
                }
            });
        }
    }
}
