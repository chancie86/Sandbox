using System;
using System.Collections.Generic;
using System.Linq;
using BomStructure.DataStore;
using BomStructure.Entities;
using BomStructure.Services;

namespace BomStructure
{
    class Program
    {
        private static IDatabase _database;
        private static PartService _partService;

        static void Main(string[] args)
        {
            _database = new MockDatabase();
            _partService = new PartService(_database);

            var duplicateParts = FindDuplicateParts();

            foreach (var duplicates in duplicateParts)
            {
                Console.WriteLine($"The following parts have the same components: {string.Join(',', duplicates.Select(x => x.Id))}");
                Console.WriteLine($"Components: {string.Join(',', duplicates.First().Components.Select(x => x.Id))}");
                Console.WriteLine();
            }
        }

        public static IList<IList<Part>> FindDuplicateParts()
        {
            var parts = _partService.GetParts();
            var duplicateParts = parts.GroupBy(part => part.GetComponentHash());

            return duplicateParts.Select(group => (IList<Part>)group.ToList()).ToList();
        }
    }
}
