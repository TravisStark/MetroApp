#pragma checksum "E:\repos\MetroApp\Pages\Metro.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cf91a70f7a9f174b2205ae7e1c2b30e24c05e75b"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace MetroApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\repos\MetroApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\repos\MetroApp\_Imports.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\repos\MetroApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\repos\MetroApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\repos\MetroApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\repos\MetroApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\repos\MetroApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\repos\MetroApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\repos\MetroApp\_Imports.razor"
using MetroApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\repos\MetroApp\_Imports.razor"
using MetroApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\repos\MetroApp\_Imports.razor"
using MetroApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\repos\MetroApp\_Imports.razor"
using MetroApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\repos\MetroApp\_Imports.razor"
using AspNetMonsters.Blazor.Geolocation;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Metro : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 88 "E:\repos\MetroApp\Pages\Metro.razor"
       
    private IEnumerable<Train> trains;
    private Dictionary<double, Station> stationsWithDistance;
    private IEnumerable<Station> stations;
    private Station defaultStation;

    Location location;

    protected override async Task OnInitializedAsync()
    {
        var sql = "SELECT * FROM c";
        stations = await CosmosDbService.GetStationsAsync(sql);
        defaultStation = stations.First();
    }

    async void GetNextTrains(ChangeEventArgs args)
    {
        trains = await MetroApiService.GetNextTrainsAsync(args.Value.ToString());
    }

    async void GetNearestStationsAsync()
    {
        location = await LocationService.GetLocationAsync();
        stationsWithDistance = MetroApiService.GetNearestStations(stations, location);
    }

    async void UpdateStationsInDb()
    {
        var stations = await MetroApiService.GetStationsAsync();
        await CosmosDbService.AddStationsAsync(stations);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MetroApp.Services.ICosmosDbService CosmosDbService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private LocationService LocationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MetroApiService MetroApiService { get; set; }
    }
}
#pragma warning restore 1591
