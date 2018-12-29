using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace ParkingPalServ.Models
{
    public partial class data
    {
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }
        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Total))
                yield return new RuleViolation("Total required","Total");
            if (String.IsNullOrEmpty(Open))
                yield return new RuleViolation("Open required","Open");
            if (String.IsNullOrEmpty(OpenH))
                yield return new RuleViolation("OpenH required","OpenH");
            if (String.IsNullOrEmpty(Occupied))
                yield return new RuleViolation("Occupied required","Occupied");
            if (String.IsNullOrEmpty(OccupiedH))
                yield return new RuleViolation("OccupiedH required","OccupiedH");

            yield break;
        }
        partial void OnValidate(ChangeAction action)
        {
            if (!IsValid)
                throw new ApplicationException("Rule violations prevent saving");
        }
    }

    public class RuleViolation
    {
        public string ErrorMessage { get; private set; }
        public string PropertyName { get; private set; }

        public RuleViolation(string errorMessage, string propertyName)
        {
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }
}