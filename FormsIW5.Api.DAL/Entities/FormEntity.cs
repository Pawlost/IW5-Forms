﻿namespace FormsIW5.Api.DAL.Entities;

public record FormEntity : EntityBase
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    public ICollection<QuestionEntity> Questions { get; set; } = [];
}
