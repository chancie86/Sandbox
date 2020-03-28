using System.Collections.Generic;

namespace BomStructure.DataStore
{
    public interface IDatabase
    {
        IList<KeyValuePair<string, string>> GetBomStructure();
    }
}
