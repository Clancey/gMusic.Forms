using System;

using Xamarin.Forms;

namespace gMusic.Playback
{
    public class EqualizerData
    {
        public static Band[] Bands = TenBandPreset();


        public static Band[] TenBandPreset()
        {
            return new[]
            {
                new Band {Center = 32},
                new Band {Center = 64},
                new Band {Center = 125},
                new Band {Center = 250},
                new Band {Center = 500},
                new Band {Center = 1000},
                new Band {Center = 2000},
                new Band {Center = 4000},
                new Band {Center = 8000},
                new Band {Center = 16000},
            };
        }


        public Band[] ThreeBandPreset()
        {
            return new[]
            {
                new Band {Center = 100},
                new Band {Center = 1000},
                new Band {Center = 8000},
            };
        }
    }

    public class Band
    {
        public float Center { get; set; }

        public float Gain { get; set; }

        public override string ToString()
        {
            if (Center < 1000)
                return string.Format("{0}", Center);
            return string.Format("{0}K", Center / 1000);
        }
    }
}

