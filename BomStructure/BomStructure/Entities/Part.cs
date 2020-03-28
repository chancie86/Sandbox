using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BomStructure.Entities
{
    /// <summary>
    /// A Part is a collection of Components
    /// </summary>
    public class Part
    {
        public Part(PartId id, IList<Component> components)
        {
            Id = id;
            Components = components;
        }

        public PartId Id { get; }

        public IList<Component> Components { get; }

        /// <summary>
        /// Generates an encoded string based on the Components that are in this part. This will give the same
        /// result for any Part that has the same set of Components.
        /// </summary>
        /// <returns></returns>
        public string GetComponentHash()
        {
            var idString = string.Concat(Components.OrderBy(x => x.Id.ToString()).Select(x => x.Id));
            return EncodeString(idString);
        }

        private string EncodeString(string text)
        {
            var encoding = Encoding.UTF8;
            byte[] textAsBytes = encoding.GetBytes(text);
            return System.Convert.ToBase64String(textAsBytes);
        }
    }
}
