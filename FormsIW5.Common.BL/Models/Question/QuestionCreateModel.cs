﻿using FormsIW5.Common.BL.Models.AnswerSelection;
using FormsIW5.Common.BL.Models.Interfaces;
using FormsIW5.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.Question;

public record QuestionCreateModel : ICreateModel
{
    public string? QuestionText { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public QuestionType QuestionType { get; set; }
    public string? Description { get; set; }

    [Required]
    public Guid FormId { get; set; }

    public ICollection<AnswerSelectionCreateModel> AnswerSelections { get; set; } = [];
}
