using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace PromotionEngine.DataAccess
{
 public class ListToStringValueConverter : ValueConverter<IEnumerable<string>, string>
    {
        public ListToStringValueConverter() : base(le => ListToString(le), (s => StringToList(s)))
        {
        }

        public static string ListToString(IEnumerable<string> values)
        {
            if (values == null || values.Count() == 0)
            {
                return null;
            }

            return string.Join(',', values);
        }

        public static IEnumerable<string> StringToList(string value)
        {
            if (value == null || value == string.Empty)
            {
                return null;
            }

            return value.Split(',').Select(i => i);
        }
    }
}
