using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using gMusic.Data;
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

        private void ActiveSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            EqualizerData.Active = e.Value;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ActiveSwitch.Toggled += ActiveSwitch_Toggled;
            ActiveSwitch.IsToggled = EqualizerData.Active;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ActiveSwitch.Toggled -= ActiveSwitch_Toggled;
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

            EqualizerGrid.Children.Add(slider, index, 0);
            var text = new Label
            {
                Text = band.ToString(),
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize =10,
            };
            EqualizerGrid.Children.Add(text, index, 1);
        }

        static float range = 12f;
        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var slider = sender as VerticalSlider;
            EqualizerData.UpdateBand(slider.Tag, (float)e.NewValue * range);  
        }
    }
}
