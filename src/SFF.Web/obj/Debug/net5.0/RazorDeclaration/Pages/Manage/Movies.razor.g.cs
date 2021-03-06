// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace SFF.Web.Pages.Manage
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using SFF.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using SFF.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using MudBlazor.ThemeManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Pages\Manage\Movies.razor"
using SFF.Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Pages\Manage\Movies.razor"
using SFF.Core.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Pages\Manage\Movies.razor"
using SFF.Core.Constants;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Pages\Manage\Movies.razor"
using Microsoft.EntityFrameworkCore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Pages\Manage\Movies.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Pages\Manage\Movies.razor"
using Microsoft.AspNetCore.SignalR.Client;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/Movies")]
    public partial class Movies : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 186 "c:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Pages\Manage\Movies.razor"
       
    private IEnumerable<Movie> _movies = new List<Movie>();
    private List<Movie> _newMovie = new List<Movie>();
    private HubConnection hubConnection;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(NavigationManager.ToAbsoluteUri("/movieHub"))
            .Build();
        hubConnection.On("LaddaAldrigOmTack", async () =>
        {
            using var context = DbFactory.CreateDbContext();
            _movies = await context.Movies.ToListAsync();
            await InvokeAsync(() => StateHasChanged());
        });
        await hubConnection.StartAsync();
        using var context = DbFactory.CreateDbContext();
        _movies = await context.Movies.ToListAsync();
        _newMovie.Clear();
        _newMovie.Add(new Movie());
    }

    private async Task UpdateDb(Movie movie)
    {
        using var context = DbFactory.CreateDbContext();
        context.Movies.Update(movie);
        await context.SaveChangesAsync();
        await Send();
    }
    private async Task DeleteFromDb(Movie movie)
    {
        using var context = DbFactory.CreateDbContext();
        context.Movies.Remove(movie);
        await context.SaveChangesAsync();
        await Send();
        await OnInitializedAsync();
    }

    private async Task AddToDb(Movie movie)
    {
        using var context = DbFactory.CreateDbContext();
        context.Movies.Add(movie);
        await context.SaveChangesAsync();
        await Send();
        await OnInitializedAsync();
    }

    private async Task ResetLicenses(Movie movie)
    {
        if (!movie.IsDigital) movie.NbrOfLicenses = 0;
        if (!movie.IsPhysical) movie.NbrOfPhysicalCopies = 0;
        await UpdateDb(movie);
    }

    Task Send() => 
        hubConnection.SendAsync("Send");

    public async ValueTask DisposeAsync()
    {
        await hubConnection.DisposeAsync();
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDbContextFactory<SFFDbContext> DbFactory { get; set; }
    }
}
#pragma warning restore 1591
