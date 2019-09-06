using System;
using gMusic.Models;
using gMusic.CometViews;
using gMusic.Views.Controls;
using Localizations;
using Xamarin.Forms;
using Comet;

namespace gMusic.Views
{
    public class ArtistDetailsPage :  ContentPage
    {
        PanaramaView panarama;
        public ArtistDetailsPage(Artist artist)
        {
            Content = panarama = new PanaramaView();
            panarama.AddPage(Strings.Albums, new CometView {
                View = new ArtistAlbumsView().SetEnvironment("artist",artist)});
            panarama.AddPage(Strings.Songs,
                new CometView { View = new ArtistSongsView().SetEnvironment("artist", artist) });
        }
    }
}
