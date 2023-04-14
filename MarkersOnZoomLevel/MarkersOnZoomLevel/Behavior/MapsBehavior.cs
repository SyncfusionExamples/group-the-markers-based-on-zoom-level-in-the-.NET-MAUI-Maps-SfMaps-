using Syncfusion.Maui.Maps;

namespace MarkersOnZoomLevel
{
    public class MapsBehavior : Behavior<ContentPage>
    {
        private MapTileLayer layer;
        private MapMarkerCollection markers;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.layer = bindable.FindByName<MapTileLayer>("layer");
            this.layer.ZoomLevelChanging += Layer_ZoomLevelChanging;
            this.markers = bindable.FindByName<MapMarkerCollection>("markers");

        }

        private void Layer_ZoomLevelChanging(object sender, ZoomLevelChangingEventArgs e)
        {
            if (e.NewZoomLevel <= 3 && markers.Count > 1)
            {
                markers.Clear();
                markers.Add(new MapMarker { Latitude = 20.766387, Longitude = 78.750000 });
            }
            else if (e.NewZoomLevel >= 4 && markers.Count == 1)
            {
                markers.Clear();
                markers.Add(new MapMarker { Latitude = 12.331952, Longitude = 78.002930 });
                markers.Add(new MapMarker { Latitude = 17.678045, Longitude = 78.793945 });
                markers.Add(new MapMarker { Latitude = 18.346705, Longitude = 73.608398 });
                markers.Add(new MapMarker { Latitude = 21.486297, Longitude = 84.418945 });
                markers.Add(new MapMarker { Latitude = 22.139076, Longitude = 72.905273 });
                markers.Add(new MapMarker { Latitude = 26.463197, Longitude = 81.166992 });
                markers.Add(new MapMarker { Latitude = 26.463197, Longitude = 74.487305 });
                markers.Add(new MapMarker { Latitude = 28.952879, Longitude = 77.915039 });
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.layer != null)
            {
                this.layer.ZoomLevelChanging -= Layer_ZoomLevelChanging;
            }

            this.layer = null;
            this.markers = null;
        }
    }
}
