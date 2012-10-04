using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Utilities
{
    public static class Mapper
    {
        public static T Map<F, T>(
                        F from,
                        BindingFlags fromFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance,
                        BindingFlags toFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance
                        )
            where F : class
            where T : class, new()
        {
            T to = null;

            if (from != null)
            {
                to = new T();

                PropertyInfo[] fromProperties = from.GetType().GetProperties(fromFlags);
                PropertyInfo[] toProperties = to.GetType().GetProperties(toFlags);

                foreach (PropertyInfo fromProperty in fromProperties)
                {
                    foreach (PropertyInfo toProperty in toProperties)
                    {
                        if ((fromProperty.Name.Equals(toProperty.Name)) && (fromProperty.PropertyType == toProperty.PropertyType))
                        {
                            toProperty.SetValue(to, fromProperty.GetValue(from, null), null);
                            break;
                        }
                    }
                }
            }

            return to;
        }
    }
}
