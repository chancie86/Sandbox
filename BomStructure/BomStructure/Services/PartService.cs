using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BomStructure.DataStore;
using BomStructure.Entities;

namespace BomStructure.Services
{
    public class PartService
    {
        private readonly IDatabase _database;

        public PartService(IDatabase database)
        {
            _database = database;
        }

        public IList<Part> GetParts()
        {
            var records = _database.GetBomStructure();
            var parts = new Dictionary<string, Part>();

            foreach (var record in records)
            {
                if (parts.TryGetValue(record.Key, out Part part))
                {
                    part.Components.Add(new Component((ComponentId)record.Value));
                }
                else
                {
                    parts.Add(record.Key, new Part((PartId)record.Key, new List<Component>
                    {
                        new Component((ComponentId)record.Value)
                    }));
                }
            }

            return parts.Values.ToList();
        }
    }
}
