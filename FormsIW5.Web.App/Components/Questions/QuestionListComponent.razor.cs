using FormsIW5.BL.Models.Common.Question;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Questions;

public partial class QuestionListComponent
{
    [Parameter]
    public ICollection<QuestionListModel> Questions { get; set; } = []; 
}
