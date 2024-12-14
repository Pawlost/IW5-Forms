using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Forms;

public partial class FormCreatePage
{
    [Parameter]
    public Guid Id { get; set; } = Guid.Empty;
}
