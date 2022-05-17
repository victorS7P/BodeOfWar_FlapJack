using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlapJack
{
    public class TableModel
    {
        public int IslandValue = 0;
        public Dictionary<string, string> PlayersCards = new Dictionary<string, string>();
        public string LastPlayer = "";
        
        static public TableModel FromServer(string[] serverTable)
        {
            TableModel table = new TableModel();

            if (serverTable.Count() == 0)
            {
                return table;
            }

            int FirstCardsLine = 0;
            if (serverTable[0][0] == 'I')
            {
                table.IslandValue = int.Parse(serverTable[0].Replace("I", ""));
                FirstCardsLine = 1;
            }

            for (int i = FirstCardsLine; i < serverTable.Length; i++)
            {
                string[] playerData = serverTable[i].Split(',');
                table.PlayersCards[playerData[0]] = playerData[1];
                table.LastPlayer = playerData[0];
            }

            return table;
        }

        public List<int> GetTableCards()
        {
            return PlayersCards.Select(c => int.Parse(c.Value)).ToList();
        }
    }
}
