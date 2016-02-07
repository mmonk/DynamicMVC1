using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DynamicMVC1.Custom
{
    class DateValidator : ValidationAttribute, IClientValidatable
    {
        private readonly string _minPropertyName;
        private readonly string _maxPropertyName;

        public DateValidator(string minPropName, string maxPropName)
        {
            _minPropertyName = minPropName;
            _maxPropertyName = maxPropName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime)value;

            if (currentValue >= DateTime.Now)
            {
                return new ValidationResult(string.Format(ErrorMessage, DateTime.MinValue.ToString(), DateTime.Now.ToString()));
            }

            return null;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "dynamicrange",
                ErrorMessage = ErrorMessage
            };

            rule.ValidationParameters["minvalueproperty"] = _minPropertyName;
            rule.ValidationParameters["maxvalueproperty"] = _maxPropertyName;
            yield return rule;
        }
    }
}