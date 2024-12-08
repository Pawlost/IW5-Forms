﻿using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components;

public partial class FormListPage
{
    [Inject]
    private FormFacade facade { get; set; } = null!;

    private ICollection<FormListModel> formList { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        form.Id
        formList = await facade.FormGetAsync();
        await base.OnInitializedAsync();
    }

    public void Redirect(Guid id)
    {
        form.Id
        formList = await facade.FormGetAsync();
        await base.OnInitializedAsync();
    }
}
