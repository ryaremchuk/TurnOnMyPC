using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurnOnMyPC.Logic
{
    public class PCToTurnOnQueue
    {
        private static List<string> _data = new List<string>();

        public void AddItem(string item)
        {
            item = item.ToLower();

            if (!_data.Contains(item))
            {
                _data.Add(item);
            }
        }

        public IEnumerable<string> GetAll()
        {
            return _data;
        }

        public void Clear()
        {
            _data.Clear();
        }
    }
}