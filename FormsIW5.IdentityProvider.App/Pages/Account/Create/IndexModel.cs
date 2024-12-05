// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.ComponentModel.DataAnnotations;

namespace FormsIW5.IdentityProvider.App.Pages.Account.Create;

public class InputModel
{
    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Password { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }

    public string? ReturnUrl { get; set; }

    public string? Button { get; set; }
}
