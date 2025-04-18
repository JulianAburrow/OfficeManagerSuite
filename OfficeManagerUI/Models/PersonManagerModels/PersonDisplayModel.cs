﻿namespace OfficeManagerUI.Models.PersonManagerModels;

public class PersonDisplayModel
{
    public int PersonId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = default!;

    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "Middle Names")]
    public string? MiddleNames { get; set; } = null!;

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = default!;

    [StringLength(100, ErrorMessage = "{0} cannot be more than {1} characters")]
    public string? EmailAddress { get; set; } = null!;

    [StringLength(20, ErrorMessage = "{0} cannot be more than {1} characters")]
    public string? PhoneNumber { get; set; } = null!;

    [Range(0, int.MaxValue, ErrorMessage = "{0} is required")]
    [Display(Name = "Personal Pronouns")]
    public int? PersonalPronounsId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "{0} is required")]
    [Display(Name = "Gender")]
    public int? GenderId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "{0} is required")]
    [Display(Name = "Employment Status")]
    public int EmploymentStatusId { get; set; }

    public byte[]? Photo { get; set; } = null!;

    public byte[]? Pronunciation { get; set; } = null!;
}
