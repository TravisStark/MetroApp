#pragma checksum "/Users/travisstark/repos/MetroApp/Pages/FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e1a47fd6319335d86f0448ea296ecaaabc38dc0"
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
#line 13 "/Users/travisstark/repos/MetroApp/_Imports.razor"
using AspNetMonsters.Blazor.Geolocation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/travisstark/repos/MetroApp/Pages/FetchData.razor"
using MetroApp.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public partial class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "/Users/travisstark/repos/MetroApp/Pages/FetchData.razor"
       
    private WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
