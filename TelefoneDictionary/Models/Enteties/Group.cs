using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelefoneDictionary.Models.Enteties
{
    public class Group
    {
        public int GroupPK { get; set; }
        public string name { get; set; }
        public List<Group> children { get; set; }
        public int? ParentPk { get; set; }
        public int? LeaderFK { get; set; }
        public string Photo { get; set; }
    }
}