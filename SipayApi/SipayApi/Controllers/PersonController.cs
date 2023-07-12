using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SipayApi.Controllers;
public class PersonValidator: AbstractValidator<Person>
{
    public PersonValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(x=>x.Name).MaximumLength(100);
        RuleFor(x => x.Lastname).NotEmpty().WithMessage("Last name is required");
        RuleFor(x=>x.Lastname).MaximumLength(100);
        RuleFor(x=>x.Phone).NotEmpty().WithMessage("Phone is required");
        RuleFor(x => x.AccessLevel).NotEmpty().WithMessage("Access level is required");
        RuleFor(x => x.AccessLevel).LessThanOrEqualTo(5);
        RuleFor(x=>x.AccessLevel).GreaterThanOrEqualTo(1);
        RuleFor(x=>x.Salary).NotEmpty();
        When(x => x.AccessLevel == 1, () =>
        {
            RuleFor(x => x.Salary).LessThanOrEqualTo(10000);
        });
        When(x => x.AccessLevel == 2, () =>
        {
            RuleFor(x => x.Salary).LessThanOrEqualTo(20000);
        });
        When(x => x.AccessLevel == 3, () =>
        {
            RuleFor(x => x.Salary).LessThanOrEqualTo(30000);
        });
        When(x => x.AccessLevel == 4, () =>
        {
            RuleFor(x => x.Salary).LessThanOrEqualTo(40000);
        });
        When(x => x.AccessLevel == 5, () =>
        {
            RuleFor(x => x.Salary).LessThanOrEqualTo(50000);
        });
    }
}
public class Person
{
  //  [DisplayName("Staff person name")]
    //[Required]
    //[StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Name { get; set; }


   // [DisplayName("Staff person lastname")]
    //[Required]
    //[StringLength(maximumLength: 100, MinimumLength = 5)]
    public string Lastname { get; set; }


   // [DisplayName("Staff person phone number")]
    //[Required]
    //[Phone]
    public string Phone { get; set; }


  //  [DisplayName("Staff person access level to system")]
    //[Range(minimum: 1, maximum: 5)]
    //[Required]
    public int AccessLevel { get; set; }



  //  [DisplayName("Staff person salary")]
    //[Required]
  //  [Range(minimum: 5000, maximum: 50000)]
    //[SalaryAttribute]
    public decimal Salary { get; set; }
}


/*public class SalaryAttribute : ValidationAttribute
{
    public SalaryAttribute()
    {

    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var person = (Person)validationContext.ObjectInstance;
        decimal salary = (decimal)value;
        ValidationResult? message = ValidationResult.Success;
        switch (person.AccessLevel)
        {
            case 1:
                message = salary > 10000 ? new ValidationResult("Salary cannot be greater then 10000") : ValidationResult.Success;
                return message;
            case 2:
                message = salary > 20000 ? new ValidationResult("Salary cannot be greater then 20000") : ValidationResult.Success;
                return message;
            case 3:
                message = salary > 30000 ? new ValidationResult("Salary cannot be greater then 30000") : ValidationResult.Success;
                return message;
            case 4:
                message = salary > 40000 ? new ValidationResult("Salary cannot be greater then 40000") : ValidationResult.Success;
                return message;
            default:
                message = new ValidationResult("Salary cannot invalid");
                break;
        }
        return message;
    }
}*/

[ApiController]
[Route("sipy/api/[controller]")]
public class PersonController : ControllerBase
{

    public PersonController() { }


    [HttpPost]
    public Person Post([FromBody] Person person)
    {
        return person;
    }
}
