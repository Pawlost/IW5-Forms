﻿using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.AnswerSelection;
using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.Question;

public record QuestionAnswerModel : IModel
{
    public Guid Id { get; init; }
    public string? QuestionText { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
    public QuestionType QuestionType { get; set; }
    public string? Description { get; set; }

    [Required]
    public Guid FormId { get; set; }
    public AnswerDetailModel? Answer { get; set; }
    public ICollection<QuestionOptionListModel> QuestionOptions { get; set; } = [];
}
