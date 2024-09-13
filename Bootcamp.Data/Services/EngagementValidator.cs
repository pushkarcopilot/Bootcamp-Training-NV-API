using Bootcamp.Data.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Data.Services
{
    public class EngagementValidator : AbstractValidator<Engagement>
    {
        public EngagementValidator()
        {
            RuleFor(x => x.EngagementId).NotNull();
            RuleFor(x => x.ClientName).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(100);
            RuleFor(x => x.AuditTypeId).NotNull();
            RuleFor(x => x.AuditStartDate).NotEmpty();
            RuleFor(x => x.AuditEndDate).NotEmpty();
            RuleFor(x => x.Auditors).NotEmpty();
            RuleFor(x => x.StatusId).NotNull();
        }
    }
}
