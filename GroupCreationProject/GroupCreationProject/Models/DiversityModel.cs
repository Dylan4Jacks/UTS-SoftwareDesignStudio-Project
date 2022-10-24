using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;


// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System;

namespace GroupCreationProject.Models
{
    
    public class GroupFormation
    {
        public Random rnd { get; set; }
        public List<GroupPrefModel> Groups { get; set; }
        public List<StuPrefModel> People { get; set; }
        public int GroupCapacity { get; set; }
        public int numberOfGroups { get; set; }


        public GroupFormation(int GroupCapacity, List<StuPrefModel> people, int numberOfGroups)
        {
            this.rnd = new Random();
            this.Groups = createGroups();
            this.People = people;
            this.GroupCapacity = GroupCapacity;
            this.numberOfGroups = numberOfGroups;
        }


        public List<GroupPrefModel> createGroups()
        {
            List<GroupPrefModel> groups = new List<GroupPrefModel>();
            Console.WriteLine(groups.Count);

            for (int i = 0; i<3; i++)
            {
                string group_name = "group" + i;
                GroupPrefModel new_group = new(i, group_name);
                groups.Add(new_group);
                
            }
            return groups;
        }

        // Randomises a group from a list of people
        public void randomiseGroups(GroupPrefModel group, List<StuPrefModel> listOfpeople)
        {
            int groupCounter = 0;
            Random rnd = this.rnd;
            group.Members.Clear();
            while (groupCounter != GroupCapacity)
            {
                int people_free = listOfpeople.Count;
                for (int i = 0; i < GroupCapacity; i++)
                {
                    StuPrefModel person_selected = listOfpeople[rnd.Next(people_free)];
                    group.Members.Add(person_selected);
                    listOfpeople.Remove(person_selected);
                    people_free -= 1;
                    groupCounter += 1;
                }
            }
        }

        public List<StuPrefModel> copyList(List<StuPrefModel> listToCopy)
        {
            List<StuPrefModel> placeholder = listToCopy.ToList();
            return placeholder;
        }

        //Calculates the diversity rating for each attribute in a single group
        public List<Decimal> calculateDiveristy(GroupPrefModel group)
        {
            List<Decimal> groupDiversity = new List<Decimal>();
            Dictionary<string, int> groupAttributes = new Dictionary<string, int>();
            Dictionary<string, int> popAttributes = new Dictionary<string, int>();
            groupAttributes = getGroupAttributes(group);
            popAttributes = attributesCount(getAllAttributes());

            
            foreach (KeyValuePair<string, int> attr in popAttributes)
            {
                Decimal groupA;
                try
                {
                    groupA = groupAttributes[attr.Key];
                }
                catch (Exception)
                {
                    groupA = 0;
                }
                Decimal popA = popAttributes[attr.Key];
                Decimal calculation = Decimal.Divide(groupA, popA);
                
                //Console.WriteLine(attr.Key.ToUpper() + " pop: " + popA + " group: " + groupA + " calc: " + calculation);
                groupDiversity.Add(calculation);
            }
            return groupDiversity;
        }

        // Diversity points calculation logic
        public Decimal pointsCalculation(Decimal attRscore)
        {
            Decimal baseline = Decimal.Divide(1, numberOfGroups);
            Decimal groupScore = 0;
            if (attRscore == 0)
            {
                groupScore += 1;
            }
            else
            {
                if (attRscore > baseline)
                {
                    groupScore += (attRscore - baseline);
                }
                if (attRscore < baseline)
                {
                    groupScore += (baseline - attRscore);
                }
            }
            return groupScore;
        }

        // Returns the diversity score of all groups in a class
        public Decimal groupDiversity()
        {
            List<List<Decimal>> groupDiversity = new List<List<Decimal>>();
            groupDiversity.Clear();
            Decimal totalDiversityScore = 0;
            for (int i = 0; i < Groups.Count; i++)
            {
                groupDiversity.Add(calculateDiveristy(Groups[i]));
                //break; // REMOVE this after testing
            }
            
            for (int j = 0; j < groupDiversity.Count; j++)
            {
                
                for (int z = 0; z < groupDiversity[j].Count; z++)
                {
                    totalDiversityScore += pointsCalculation(groupDiversity[j][z]);
                    //Console.WriteLine("Score: " + groupDiversity[j][z]);
                    //Console.WriteLine("Points: " + pointsCalculation(groupDiversity[j][z]));
                }
            }
            return totalDiversityScore;
        }
        // Gets all the preferences for the whole population(class of students) as a list<string>
        public List<string> getAllAttributes()
        {
            List<string> all_preferences = new List<string>();
            List<string> individualPreferences = new List<string>();
            for (int i = 0; i < People.Count; i++)
            {
                individualPreferences = People[i].get_preferences();
                for (int j = 0; j < individualPreferences.Count; j++)
                {
                    all_preferences.Add(individualPreferences[j]);
                }
            }
            return all_preferences;
        }


        // Transforms a list of strings into a Dict<string, int> with the count of the strings in the list
        public Dictionary<string, int> attributesCount(List<string> allAttributes)
        {
            Dictionary<string, int> totalPop = new Dictionary<string, int>();
            string temp = null;
            totalPop.Clear();
            for (int i = 0; i < allAttributes.Count; i++)
            {
                temp = allAttributes[i];

                if (totalPop.ContainsKey(temp))
                {
                    totalPop[temp] += 1;
                }
                else
                {
                    totalPop.Add(temp, 1);
                }
            }
            return totalPop;
        }

        // Creates dictionary of the preferences and their counts for a particular group <string, int> --> <preference, count>
        public Dictionary<string, int> getGroupAttributes(GroupPrefModel group)
        {
            List<string> groupA = new List<string>();
            groupA.Clear();
            groupA = group.getAttributes();
            Dictionary<string, int> groupAttributes = new Dictionary<string, int>();
            groupAttributes = attributesCount(groupA);

            return groupAttributes;
        }

        public List<GroupPrefModel> mostDiverseClass(bool diverse)
        {
            int count = 0;
            Decimal mostDiverse;
            if (diverse == true)
            {
                mostDiverse = 999999999;
            }
            else
            {
                mostDiverse = -1;
            }
            Decimal diversity = mostDiverse;
            List<GroupPrefModel> mostDiverseGroup = new List<GroupPrefModel>();
            List<GroupPrefModel> current_group = new List<GroupPrefModel>();
            List<StuPrefModel> people = new List<StuPrefModel>();
            people = copyList(People);

            Console.WriteLine("----------------------------");
            while (count < 1000)
            {
                List<GroupPrefModel> groups = new List<GroupPrefModel>();
                //groups = Groups.ToList();
                
                
                //List<StuPrefModel> people = new List<StuPrefModel>();
                List<StuPrefModel> proper_list = copyList(people);
                for (int i = 0; i < Groups.Count; i++)
                {
                    randomiseGroups(Groups[i], proper_list);
                }
                current_group = Groups.ToList();
                
                diversity = groupDiversity();
                if (diverse == true)
                {
                    if (mostDiverse > diversity)
                    {
                        mostDiverse = diversity;
                        diversity = 0;
                        mostDiverseGroup = current_group;
                    }
                }
                else
                {
                    if (mostDiverse < diversity)
                    {
                        mostDiverse = diversity;
                        diversity = 0;
                        mostDiverseGroup = current_group;
                    }
                }
                count += 1;
                proper_list = copyList(people);
                

            }
            Console.WriteLine("MOST DIVERSE: " + mostDiverse);
            return mostDiverseGroup;
            
        }
    }
}


