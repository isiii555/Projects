using BingMapsRESTToolkit;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Maps.MapControl.WPF;
using ServiceBusApp.Models;
using ServiceBusApp.Views.RidesView;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using Location = BingMapsRESTToolkit.Location;

namespace ServiceBusApp.ViewModels.RidesViewModel
{
    public class RideStartViewModel : ViewModelBase
    {
        private ObservableCollection<UIElement> elements = new();

        public string Provider { get; set; } = ConfigurationManager.AppSettings["apiKey"];

        public ObservableCollection<UIElement> Elements
        {
            get => elements; set
            {
                Set(ref elements, value);
            }
        }

        public Ride Ride { get; set; }

        public Map Map { get; set; }

        public int Count { get; set; } = 0;

        public Pushpin DriverHome { get; set; } = new();

        public Pushpin Bus { get; set; } = new();

        public Pushpin School { get; set; } = new();

        public MapPolyline Locations { get => locations; set => Set(ref locations,value); }

        public Dictionary<Microsoft.Maps.MapControl.WPF.Location, double> Distances { get; set; } = new();

        public ObservableCollection<Pushpin> Students1 { get; set; } = new();

        public DispatcherTimer Timer { get; set; } = new();

        public Window CurrentWindow { get; set; }

        public int count;

        public RideStartViewModel(Ride ride, Map map,Window window)
        {
            this.Ride = ride;
            CurrentWindow = window;
            Map = map;
            Provider = ConfigurationManager.AppSettings["apiKey"];
            count = Ride.Students.Count + 1;
            StartRide();
            Timer.Tick += Timer_Tick;
            Timer.Interval = (new TimeSpan(0,0,0,0,20));
        }

        private async void Timer_Tick(object? sender, EventArgs e)
        {
            Bus.Location = Locations.Locations[0];
            this.Map.Center = Bus.Location;
            Locations.Locations.Remove(Locations.Locations[0]);
            if (Ride.ToSchool)
            {
                if (count != 0)
                {
                    if (Locations.Locations.Count == 0)
                    {
                        count--;
                        Timer.Stop();
                        await Refresh();
                        Timer.Start();
                    }
                }
                else
                {
                    Ride.ToSchool = false;
                    Timer.Stop();
                }
            }
            else
            {
                if (count != 0)
                {
                    if (Locations.Locations.Count == 0)
                    {
                        count--;
                        Timer.Stop();
                        await Refresh();
                        Timer.Start();
                    }
                }
                else
                {
                    Ride.ToSchool = true;
                    Timer.Stop();
                }
            }
        }

        public async void StartRide()
        {
            await FirstAdress();
            await SecondAdress();
            await Students();
            for (int i = 0; i < Students1.Count; i++)
            {
                if (Ride.ToSchool)
                {
                    await Distance(Bus.Location, Students1[i].Location);
                }
                else
                    await Distance(School.Location, Students1[i].Location);
            }
            await Refresh();
            Timer.Start();
        }

        public async Task Refresh()
        {
            Microsoft.Maps.MapControl.WPF.Location location1 = new() ;
            Microsoft.Maps.MapControl.WPF.Location From = new() ;
            if (Distances.Count > 0)
            {
                location1 = Distances.MinBy(kvp => kvp.Value).Key;
                Distances.Remove(location1);
            }
            else
            {
                if (Ride.ToSchool)
                    location1 = School.Location;
                else
                    location1 = DriverHome.Location;
            }
            From = Bus.Location;

            string routeRequest = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=" +
              From.Latitude + "," +
              From.Longitude + "&wp.1=" +
              location1.Latitude + "," +
              location1.Longitude + "&optmz=distance&rpo=Points&key=" +
              ConfigurationManager.AppSettings["apiKey"];

            Response r = await GetResponse(new Uri(routeRequest));
            
            if (r != null && r.ResourceSets != null && r.ResourceSets.Length > 0
                && r.ResourceSets[0].Resources != null && r.ResourceSets[0].Resources.Length > 0)
            {
                Route route = r.ResourceSets[0].Resources[0] as Route;

                double[][] routePath = route.RoutePath.Line.Coordinates;

                LocationCollection locations = new LocationCollection();

                for (int i = 0; i < routePath.Length; i++)
                {
                    if (routePath[i].Length >= 2)
                    {
                        locations.Add(new Microsoft.Maps.MapControl.WPF.Location(routePath[i][0], routePath[i][1]));
                    }
                }

                if (Elements.Count > 0)
                {
                    Elements.Clear();
                }

                Locations = new MapPolyline();
                Locations.ToolTip = "Task";
                Locations.Locations = locations;
                Locations.Stroke = new SolidColorBrush(Colors.Blue);
                Locations.Opacity = 150;
                Locations.StrokeThickness = 5;

                Elements.Add(Locations);
            }
        }

        async Task FirstAdress()
        {
            var request = new GeocodeRequest();
            request.BingMapsKey = Provider;
            if (Ride.ToSchool)
            {
                request.Query = Ride.Driver.Adress;
            }
            else
                request.Query = Ride.SchoolAdress;

            var result = await request.Execute();

            if (result.StatusCode == 200)
            {
                var toolkitLocation = (result.ResourceSets?.FirstOrDefault())
                        ?.Resources?.FirstOrDefault()
                        as BingMapsRESTToolkit.Location;
                if (toolkitLocation != null)
                {
                    var latitude = toolkitLocation.Point.Coordinates[0];
                    var longitude = toolkitLocation.Point.Coordinates[1];
                    var mapLocation = new Microsoft.Maps.MapControl.WPF.Location(latitude, longitude);
                    if (Ride.ToSchool)
                    {
                        Bus = new Pushpin() { Location = mapLocation, ToolTip = "Bus" };
                        Bus.Background = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ConsoleApplication45\\ServiceBusApp\\ServiceBusApp\\Resources\\422962.png")));
                        Map.Children.Add(Bus);

                        DriverHome = new Pushpin() { Location = mapLocation, ToolTip = "Driver's Home" };
                        DriverHome.Background = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ConsoleApplication45\\ServiceBusApp\\ServiceBusApp\\Resources\\25694.png")));
                        Map.Children.Add(DriverHome);
                    }
                    else
                    {
                        Bus = new Pushpin() { Location = mapLocation, ToolTip = "Bus" };
                        Bus.Background = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ConsoleApplication45\\ServiceBusApp\\ServiceBusApp\\Resources\\422962.png")));
                        Map.Children.Add(Bus);

                        School = new Pushpin() { Location = mapLocation, ToolTip = "School" };
                        School.Background = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ConsoleApplication45\\ServiceBusApp\\ServiceBusApp\\Resources\\167707.png")));
                        Map.Children.Add(School);
                    }
                }
            }
        }

        async Task SecondAdress()
        {
            var request = new GeocodeRequest();
            request.BingMapsKey = Provider;
            if (Ride.ToSchool)
            {
                request.Query = Ride.SchoolAdress;
            }
            else
                request.Query = Ride.Driver.Adress;
            var result = await request.Execute();
            if (result.StatusCode == 200)
            {
                var toolkitLocation = (result.ResourceSets?.FirstOrDefault())
                        ?.Resources?.FirstOrDefault()
                        as BingMapsRESTToolkit.Location;
                if (toolkitLocation != null)
                {
                    var latitude = toolkitLocation.Point.Coordinates[0];
                    var longitude = toolkitLocation.Point.Coordinates[1];
                    var mapLocation = new Microsoft.Maps.MapControl.WPF.Location(latitude, longitude);
                    if (!Ride.ToSchool)
                    {
                        DriverHome = new Pushpin() { Location = mapLocation, ToolTip = "Driver's Home" };
                        DriverHome.Background = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ConsoleApplication45\\ServiceBusApp\\ServiceBusApp\\Resources\\25694.png")));
                        Map.Children.Add(DriverHome);
                    }
                    else if (Ride.ToSchool)
                    {
                        School = new Pushpin() { Location = mapLocation, ToolTip = $"School" };
                        School.Background = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ConsoleApplication45\\ServiceBusApp\\ServiceBusApp\\Resources\\167707.png")));
                        Map.Children.Add(School);
                    }
                }
            }
        }

        async Task Students()
        {
            for (int i = 0; i < Ride.Students.Count; i++)
            {
                var request = new GeocodeRequest();
                request.BingMapsKey = Provider;
                request.Query = Ride.Students[i].Adress;
                var result = await request.Execute();
                if (result.StatusCode == 200)
                {
                    var toolkitLocation = (result.ResourceSets?.FirstOrDefault())
                            ?.Resources?.FirstOrDefault()
                            as BingMapsRESTToolkit.Location;
                    if (toolkitLocation != null)
                    {
                        var latitude = toolkitLocation.Point.Coordinates[0];
                        var longitude = toolkitLocation.Point.Coordinates[1];
                        var mapLocation = new Microsoft.Maps.MapControl.WPF.Location(latitude, longitude);
                        var p = new Pushpin() { Location = mapLocation, ToolTip = $"{Ride.Students[i].Name}'s Home" };
                        p.Background = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\user\\source\\repos\\ConsoleApplication45\\ServiceBusApp\\ServiceBusApp\\Resources\\201818.png")));
                        Map.Children.Add(p);
                        Students1.Add(p);
                    }
                }
            }
        }

        async Task Distance(Microsoft.Maps.MapControl.WPF.Location from,Microsoft.Maps.MapControl.WPF.Location to)
        {
            string routeRequest = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=" +
              from.Latitude + "," +
              from.Longitude + "&wp.1=" +
              to.Latitude + "," +
              to.Longitude + "&optmz=distance&rpo=Points&key=" +
              ConfigurationManager.AppSettings["apiKey"];

            Response r = await GetResponse(new Uri(routeRequest));
            if (r != null && r.ResourceSets != null && r.ResourceSets.Length > 0
                && r.ResourceSets[0].Resources != null && r.ResourceSets[0].Resources.Length > 0)
            {
                Route route = r.ResourceSets[0].Resources[0] as Route;
                double[][] routePath = route.RoutePath.Line.Coordinates;

                double distance = route.TravelDistance;
                
                Distances.Add(to,distance);
            }
        }

        private async Task<Response> GetResponse(Uri uri)
        {
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();

            var response = await client.GetAsync(uri);

            using (var stream = await response.Content.ReadAsStreamAsync())
            {

                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));

                return ser.ReadObject(stream) as Response;
            }
        }

        private MapPolyline locations;

    }
}
