#pragma checksum "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7031d21f73eb61181a346ac0c30130dc82ba50a"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorClient.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\_Imports.razor"
using BlazorClient.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor"
using BlazorClient.Authentication;

#line default
#line hidden
#nullable disable
    public partial class NavMenu : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "navbar navbar-expand-lg");
            __builder.AddAttribute(2, "b-9woexif8f0");
            __builder.AddMarkupContent(3, "<a class=\"navbar-brand\" href b-9woexif8f0></a>\r\n    ");
            __builder.OpenElement(4, "button");
            __builder.AddAttribute(5, "class", "navbar-toggler");
            __builder.AddAttribute(6, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 35 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor"
                                             ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "b-9woexif8f0");
            __builder.AddMarkupContent(8, "<span class=\"navbar-toggler-icon\" b-9woexif8f0></span>");
            __builder.CloseElement();
            __builder.AddMarkupContent(9, "\r\n    ");
            __builder.OpenElement(10, "div");
            __builder.AddAttribute(11, "class", (
#nullable restore
#line 38 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor"
                 NavMenuCssClass

#line default
#line hidden
#nullable disable
            ) + " mr-auto");
            __builder.AddAttribute(12, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 38 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor"
                                                    ToggleNavMenu

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "b-9woexif8f0");
            __builder.AddMarkupContent(14, "<div class=\"nav nav-tabs\" b-9woexif8f0><a class=\"nav-item nav-link\" href b-9woexif8f0>Home</a>\r\n            <a class=\"nav-item nav-link\" href=\"Users\" b-9woexif8f0>Register User </a></div>");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\r\n    ");
            __builder.OpenElement(16, "span");
            __builder.AddAttribute(17, "class", "navbar-text");
            __builder.AddAttribute(18, "b-9woexif8f0");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(19);
            __builder.AddAttribute(20, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(21, "a");
                __builder2.AddAttribute(22, "href", "");
                __builder2.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 47 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor"
                                     PerformLogin

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(24, "b-9woexif8f0");
                __builder2.AddMarkupContent(25, "\r\n                    Login\r\n                ");
                __builder2.CloseElement();
            }
            ));
            __builder.AddAttribute(26, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(27, "a");
                __builder2.AddAttribute(28, "href", "");
                __builder2.AddAttribute(29, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor"
                                     PerformLogout

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(30, "b-9woexif8f0");
                __builder2.AddMarkupContent(31, "\r\n                    Logout\r\n                ");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 60 "C:\Users\HP\SEP3\Group6System\BlazorClient\BlazorClient\Shared\NavMenu.razor"
       
    /*private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }*/

    private bool collapseNavMenu = true;

    private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    private void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }

    private void PerformLogin()
    {
        NavMgr.NavigateTo("/Login");
    }
    
    private void PerformLogout()
    {
        try
        {
            ((CustomAuthenticationStateProvider) AuthenticationStateProvider).Logout();
            NavMgr.NavigateTo("/Login");
        }
        catch (Exception e)
        {
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavMgr { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
