using System;
using System.Data;
using System.Reflection;
using DataExtensions.Attributes;

namespace DataRowExtensions
{
    public static class DataRowExtensions
    {
        /// <summary>
        /// Reads values from a <see cref="DataRow"/> into the target <param name="data" /> object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="self"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static void ReadObject<T>(this DataRow self, T data)
            where T : class
        {
            data = data ?? throw new ArgumentNullException(nameof(data));

            if (data.GetType().GetCustomAttribute(typeof(TableAttribute)) == null)
            {
                throw new ArgumentException($"{nameof(data)} is not decorated with TableAttribute");
            }

            var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var propInfo in properties)
            {
                if (Attribute.GetCustomAttribute(propInfo, typeof(ColumnAttribute)) is ColumnAttribute attribute)
                {
                    self.ParseValue(data, propInfo, attribute);
                }
            }
        }

        /// <summary>
        /// Parses and sets a data value on <param name="output" /> given a column name to the specified property.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="output"></param>
        /// <param name="propInfo"></param>
        /// <param name="attribute"></param>
        private static void ParseValue(this DataRow self, object output, PropertyInfo propInfo, ColumnAttribute attribute)
        {
            var columnName = string.IsNullOrWhiteSpace(attribute.Name)
                ? propInfo.Name
                : attribute.Name;

            var value = self[columnName];

            if (value == null)
            {
                // Nothing to do
                return;
            }

            if (propInfo.PropertyType == typeof(string))
            {
                propInfo.SetValue(output, value);
            }
            else if (propInfo.PropertyType == typeof(int))
            {
                if (int.TryParse(value.ToString(), out int i))
                {
                    propInfo.SetValue(output, i);
                }
            }
            else if (propInfo.PropertyType == typeof(double))
            {
                if (double.TryParse(value.ToString(), out double d))
                {
                    propInfo.SetValue(output, d);
                }
            }
            else if (propInfo.PropertyType == typeof(float))
            {
                if (float.TryParse(value.ToString(), out float f))
                {
                    propInfo.SetValue(output, f);
                }
            }
            else if (propInfo.PropertyType == typeof(char))
            {
                if (char.TryParse(value.ToString(), out char c))
                {
                    propInfo.SetValue(output, c);
                }
            }
        }
    }
}
