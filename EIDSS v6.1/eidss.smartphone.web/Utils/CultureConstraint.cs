using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace eidss.smartphone.web.Utils
{
    public enum CultureConstraintType
    {
        Include,
        Exclude
    }

    public class CultureConstraint : IRouteConstraint
    {

        public CultureConstraintType ConstraintType { get; set; }

        private string[] _values;

        public CultureConstraint(params string[] values)
            : this(CultureConstraintType.Include, values)
        {
        }

        public CultureConstraint(CultureConstraintType constraintType, params string[] values)
        {
            ConstraintType = constraintType;
            this._values = values;
        }

        public bool Match(HttpContextBase httpContext, Route route, string parameterName,
                            RouteValueDictionary values, RouteDirection routeDirection)
        {
            // Get the value called "parameterName" from the 
            // RouteValueDictionary called "value"
            string value = values[parameterName].ToString();
            // Return true is the list of allowed values contains 
            // this value.            
            bool match = ValueExists(value);
            return ConstraintType == CultureConstraintType.Include ? match : !match;
        }

        private bool ValueExists(string value)
        {
            if (value.EndsWith(".axd")) return false;
            foreach (string s in _values)
                if (String.Equals(value, s, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }
    }
}