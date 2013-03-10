using System;
using System.Collections.Generic;
using System.IO;
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

        public string[] GetAll()
        {
            return _data.ToArray();
        }

        public void Clear()
        {
            _data.Clear();
        }
    }
}
