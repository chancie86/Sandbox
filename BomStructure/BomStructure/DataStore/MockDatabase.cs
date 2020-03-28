using System.Collections.Generic;

namespace BomStructure.DataStore
{
    public class MockDatabase
        : IDatabase
    {
        public IList<KeyValuePair<string, string>> GetBomStructure()
        {
            return new List<KeyValuePair<string, string>>
            {
                GetKvp("FPA21-M20B", "FLB21-M20"),
                GetKvp("FPA21-M20B", "CPB21"),
                GetKvp("FPA21-M20B", "BAG 1"),
                GetKvp("FPA21-M20B", "LABEL TTR148"),
                GetKvp("FSO2222", "FLB21-M20"),
                GetKvp("FSO2222", "CPB21"),
                GetKvp("FSO2222", "BAG 1"),
                GetKvp("FSO2222", "LABEL TTR148"),
                GetKvp("FSO3333", "FLB21-M25"),
                GetKvp("FSO3333", "CPB21"),
                GetKvp("FSO3333", "BAG 1"),
                GetKvp("FSO3333", "LABEL TTR148"),
                GetKvp("FOO", "BAR")
            };
        }

        private KeyValuePair<string, string> GetKvp(string key, string value)
        {
            return new KeyValuePair<string, string>(key, value);
        }
    }
}
