﻿using FormsIW5.Common.BL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.Answer;

public record AnswerCreateModel : ICreateModel
{
    public string? TextAnswer { get; set; }
    public int? IntegerAnswer { get; set; }
    
    public Guid? AnswerSelectionId { get; set; }

    [Required]
    public Guid QuestionId { get; set; }
}
