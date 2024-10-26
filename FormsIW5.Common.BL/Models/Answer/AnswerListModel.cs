﻿using FormsIW5.Common.BL.Models.AnswerSelection;
using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models.Answer;

public record AnswerListModel : IModel
{
    public string? TextAnswer { get; set; }
    public int? IntegerAnswer { get; set; }
    public AnswerSelectionListModel? SelectedAnswer { get; set; }
    public Guid Id { get; init; }
}
