#pragma checksum "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Shared\Error.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "898fc4bc6a52aaa692036cd92b71192a920c10fe"
// <auto-generated/>
#pragma warning disable 1591
namespace SFF.Web.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using SFF.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using SFF.Web.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\_Imports.razor"
using MudBlazor.ThemeManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Shared\Error.razor"
using Microsoft.Extensions.Logging;

#line default
#line hidden
#nullable disable
    public partial class Error : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __Blazor.SFF.Web.Shared.Error.TypeInference.CreateCascadingValue_0(__builder, 0, 1, 
#nullable restore
#line 4 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Shared\Error.razor"
                      this

#line default
#line hidden
#nullable disable
            , 2, (__builder2) => {
                __builder2.AddContent(3, 
#nullable restore
#line 5 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Shared\Error.razor"
     ChildContent

#line default
#line hidden
#nullable disable
                );
            }
            );
        }
        #pragma warning restore 1998
#nullable restore
#line 8 "C:\Users\rifri\OneDrive\Dokument\Program plugg\sff-RikardF\src\SFF.Web\Shared\Error.razor"
       
    [Parameter]
    public RenderFragment ChildContent { get; set; }

    public void ProcessError(Exception ex)
    {
        Logger.LogError("Error:ProcessError - Type: {Type} Message: {Message}", 
            ex.GetType(), ex.Message);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILogger<Error> Logger { get; set; }
    }
}
namespace __Blazor.SFF.Web.Shared.Error
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateCascadingValue_0<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, TValue __arg0, int __seq1, global::Microsoft.AspNetCore.Components.RenderFragment __arg1)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.CascadingValue<TValue>>(seq);
        __builder.AddAttribute(__seq0, "Value", __arg0);
        __builder.AddAttribute(__seq1, "ChildContent", __arg1);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
