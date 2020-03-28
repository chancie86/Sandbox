using System;
using System.Text.RegularExpressions;

namespace BomStructure.Entities
{
    public class PartId
        : IEquatable<PartId>
    {
        private readonly string _value;

        public PartId(string value)
        {
            var validationRegex = new Regex(@"^[ A-Z0-9\-]+$");
            if (string.IsNullOrWhiteSpace(value)
                || !validationRegex.IsMatch(value))
            {
                throw new Exception($"Invalid {nameof(PartId)}: {value}");
            }
            _value = value;
        }

        public static explicit operator string(PartId id)
        {
            return id._value;
        }

        public static explicit operator PartId(string value)
        {
            return new PartId(value);
        }

        public static bool operator ==(PartId left, PartId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PartId left, PartId right)
        {
            return !left.Equals(right);
        }

        public bool Equals(PartId other)
        {
            return Equals(_value, other._value);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            return obj is PartId id && Equals(id);
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
