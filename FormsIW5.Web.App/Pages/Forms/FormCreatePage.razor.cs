using System.Xml.Linq;
using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Forms;

public partial class FormCreatePage
{
    [Parameter]
    public Guid Id { get; set; } = Guid.Empty;
}
