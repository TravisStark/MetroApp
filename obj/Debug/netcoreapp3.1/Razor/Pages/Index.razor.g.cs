#pragma checksum "/Users/travisstark/repos/MetroApp/Pages/Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1263182b655a2f6cfafbc021a8a9bf970c0ef315"
// <auto-generated/>
#pragma warning disable 1591
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
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h1>Hello, world!</h1>\r\n\r\nWelcome to your new app.\r\n\r\n");
            __builder.OpenComponent<MetroApp.Shared.SurveyPrompt>(1);
            __builder.AddAttribute(2, "Title", "How is Blazor working for you?");
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
