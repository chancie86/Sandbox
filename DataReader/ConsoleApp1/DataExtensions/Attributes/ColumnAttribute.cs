using System;
using System.Collections.Generic;
using System.Text;

namespace DataExtensions.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute
        : Attribute
    {
        public string Name { get; set; }
    }
}
