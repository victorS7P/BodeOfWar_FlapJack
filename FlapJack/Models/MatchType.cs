using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public class MatchType
    {
        public char type { get; set; }
        public string name { get; set; }

        public static MatchType FromType (char type)
        {
            MatchType matchType = new MatchType ();
            matchType.type = type;
            matchType.name = Server.MATCHES_NAMES[type];
            return matchType;
        }

        public override string ToString()
        {
            return this.name;
        }
    }
}
