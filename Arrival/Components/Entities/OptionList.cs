using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class OptionList : BaseEntity
    {
        public string ListId { get; set; }
        public int ListValue { get; set; }
        public string ListDesc { get; set; }



        public OptionList()
        {
        }

        public OptionList(string listId, int listValue, string listDesc)
        {
            ListId = listId;
            ListValue = listValue;
            ListDesc = listDesc;
        }
    }
}
