using System;
using System.Collections.Generic;

namespace ExpressionExample
{
    public class RelevantObject
    {
        public Guid Id { get; set; }
        public string CarMake { get; set; }

        public int CarYear { get; set; }

        public Dictionary<string, string> PersonData { get; set; }

        public override string ToString()
        {
            return $@"CarMake: {CarMake}, CarYear: {CarYear}, FirstName: {(PersonData.TryGetValue("FirstName", out var fn) ? fn : "N/A")}, FavoriteColor: {(PersonData.TryGetValue("FavoriteColor", out var fc) ? fc : "N/A")}";
        }
    }
}
