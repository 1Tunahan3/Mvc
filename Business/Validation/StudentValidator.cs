using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation
{
    public class StudentValidator : AbstractValidator<Student>
    {

        public StudentValidator()
        {
            RuleFor(x => x.BirthDate).NotEmpty();
            RuleFor(x => x.DepartmentId).NotEmpty().WithMessage("Please specify a DEPARTMENT ID");
            RuleFor(x => x.Name).MinimumLength(2);
           
            
        }
    }
}
