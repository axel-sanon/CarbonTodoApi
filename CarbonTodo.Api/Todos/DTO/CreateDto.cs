﻿using System.ComponentModel.DataAnnotations;

namespace CarbonTodo.Api.Todos.DTO;

public class CreateDto
{
    public CreateDto(string title)
    {
        Title = title;
    }

    [Required] public string Title { get; }
}