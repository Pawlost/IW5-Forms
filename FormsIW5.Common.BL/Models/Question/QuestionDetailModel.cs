﻿using FormsIW5.Common.BL.Models.Answer;
using FormsIW5.Common.BL.Models.AnswerSelection;
using FormsIW5.Common.BL.Models.Interfaces;
using FormsIW5.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.Question;

public record QuestionDetailModel : IModel
{
    public Guid Id { get; init; }
    public string? QuestionText { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public QuestionType QuestionType { get; set; }
    public string? Description { get; set; }

    [Required]
    public Guid FormId { get; set; }

    public ICollection<AnswerListModel> Answers { get; set; } = [];
    public ICollection<AnswerSelectionListModel> AnswerSelections { get; set; } = [];
}
