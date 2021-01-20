using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Labmark.Extensions
{
    public static class EnumExtension
    {
        public static String GetDescription(this Enum item)
        {
            Type type = item.GetType();
            FieldInfo fi = type.GetField(item.ToString());
            DescriptionAttribute[] attributes =
            fi.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    as DescriptionAttribute[];
            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return String.Empty;
        }
        public static T GetEnumValue<T>(this string description)
        {
            var type = typeof(T);
            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException();

            var field = type.GetFields().SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a })
                                        .SingleOrDefault(a => ((DescriptionAttribute)a.Att).Description == description);
            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }
    }
}
