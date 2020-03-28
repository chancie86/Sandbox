using System;
using System.Text.RegularExpressions;

namespace BomStructure.Entities
{
    public class ComponentId
        : IEquatable<ComponentId>
    {
        private readonly string _value;

        public ComponentId(string value)
        {
            var validationRegex = new Regex(@"^[ A-Z0-9\-]+$");
            if (string.IsNullOrWhiteSpace(value)
                || !validationRegex.IsMatch(value))
            {
                throw new Exception($"Invalid {nameof(ComponentId)}: {value}");
            }
            _value = value;
        }

        public static explicit operator string(ComponentId id)
        {
            return id._value;
        }

        public static explicit operator ComponentId(string value)
        {
            return new ComponentId(value);
        }

        public static bool operator ==(ComponentId left, ComponentId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ComponentId left, ComponentId right)
        {
            return !left.Equals(right);
        }

        public bool Equals(ComponentId other)
        {
            return Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is ComponentId id && Equals(id);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
