#pragma checksum "/Users/travisstark/repos/MetroApp/Pages/Metro.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c45bdbf72e868f74dac3f2b90e276d27fc860112"
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
#line 1 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using System.Linq;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using MetroApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using MetroApp.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using MetroApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using MetroApp.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using AspNetMonsters.Blazor.Geolocation;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/metro")]
    public partial class Metro : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 76 "/Users/travisstark/repos/MetroApp/Pages/Metro.razor"
       
    private IEnumerable<Train> trains;
    private Dictionary<double, Station> stations;


    Location location;

    async void GetNextTrains(ChangeEventArgs args)
    {
        trains = await MetroApiService.GetNextTrainsAsync(args.Value.ToString());
    }

    async void GetNearestStationsAsync()
    {
        location = await LocationService.GetLocationAsync();
        stations = MetroApiService.GetNearestStations(location);
    }




#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private LocationService LocationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private MetroApiService MetroApiService { get; set; }
    }
}
#pragma warning restore 1591
