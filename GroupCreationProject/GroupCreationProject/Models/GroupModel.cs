using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GroupCreationProject.Models
{
    public class GroupModel
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int capacity { get; set; }
        public List<StuPrefModel> Members { get; set; }
        public List<string> groupAttributes { get; set; }


        public GroupModel(int Number, string Name)
        {
            this.Number = Number;
            this.Name = Name;
            this.capacity = 5;
            this.Members = new List<StuPrefModel>();
            this.groupAttributes = getAttributes();
        }

        // gets all attributes from a group into a list of strings
        public List<string> getAttributes()
        {
            List<string> groupAttributes = new List<string>();
            for (int i = 0; i < Members.Count; i++)
            {
                for (int j = 0; j < Members[i].get_preferences().Count; j++)
                {
                    groupAttributes.Add(Members[i].get_preferences()[j]);
                }
            }
            return groupAttributes;
        }
    }
}