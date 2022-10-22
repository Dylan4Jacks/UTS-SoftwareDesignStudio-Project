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


        public GroupFormation(int GroupCapacity, List<GroupPrefModel> groups, List<StuPrefModel> people, int numberOfGroups)
        {
            this.rnd = new Random();
            this.Groups = groups;
            this.People = people;
            this.GroupCapacity = GroupCapacity;
            this.numberOfGroups = numberOfGroups;
        }

        // Randomises a group from a list of people
        public void randomiseGroups(GroupPrefModel group, List<StuPrefModel> listOfpeople)
        {
            int groupCounter = 0;
            Random rnd = this.rnd;

            while (groupCounter != GroupCapacity) {
                int people_free = listOfpeople.Count;
                for (int i = 0; i < GroupCapacity; i++) {
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
            foreach (KeyValuePair<string, int> attr in popAttributes) {
                Decimal groupA;
                try {
                    groupA = groupAttributes[attr.Key];
                }
                catch (Exception) {
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
            if (attRscore == 0) {
                groupScore += 1;
            }
            else {
                if (attRscore > baseline) {
                    groupScore += (attRscore - baseline);
                }
                if (attRscore < baseline) {
                    groupScore += (baseline - attRscore);
                }
            }
            return groupScore;
        }

        // Returns the diversity score of all groups in a class
        public Decimal groupDiversity()
        {
            List<List<Decimal>> groupDiversity = new List<List<Decimal>>();
            Decimal totalDiversityScore = 0;
            for (int i = 0; i < Groups.Count; i++) {
                groupDiversity.Add(calculateDiveristy(Groups[i]));
                //break; // REMOVE this after testing
            }

            for (int j = 0; j < groupDiversity.Count; j++) {
                for (int z = 0; z < groupDiversity[j].Count; z++) {
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
            for (int i = 0; i < People.Count; i++) {
                individualPreferences = People[i].get_preferences();
                for (int j = 0; j < individualPreferences.Count; j++) {
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
            for (int i = 0; i < allAttributes.Count; i++) {
                temp = allAttributes[i];

                if (totalPop.ContainsKey(temp)) {
                    totalPop[temp] += 1;
                }
                else {
                    totalPop.Add(temp, 1);
                }
            }
            return totalPop;
        }

        // Creates dictionary of the preferences and their counts for a particular group <string, int> --> <preference, count>
        public Dictionary<string, int> getGroupAttributes(GroupPrefModel group)
        {
            List<string> groupA = new List<string>();
            groupA = group.getAttributes();
            Dictionary<string, int> groupAttributes = new Dictionary<string, int>();
            groupAttributes = attributesCount(groupA);

            return groupAttributes;
        }

        public void transformStudent(StudentModel student)
        {
            // Transform StudentModel --> StuPrefModel
            // Return StuPrefModel
            // get students 
            //StuPrefModel newStuPref = new(student.StudentId);
        }

        public void transformGroup(GroupPrefModel group)
        {
            // Form groups as 'DiversityGroups'
            // Once all groups are formed transform 'DiversityGroups' --> database groups
        }
    }
}


        



        /*
        public static void Main()
        {
            void initaliseData(List<GroupPrefModel> groups, List<StuPrefModel> people)
            {
                GroupPrefModel group1 = new(1, "group1");
                GroupPrefModel group2 = new(2, "group2");
                GroupPrefModel group3 = new(3, "group3");
                GroupPrefModel group4 = new(4, "group4");
                //Group group5 = new(5, "group5");

                groups.Add(group1);
                groups.Add(group2);
                groups.Add(group3);
                groups.Add(group4);
                //groups.Add(group5);

                StuPrefModel preference1 = new("true", "back end", "implementation", "python");
                StuPrefModel preference2 = new("true", "front end", "design", "python");
                StuPrefModel preference3 = new("true", "front end", "design", "java");
                StuPrefModel preference4 = new("false", "front end", "implementation", "c++");
                StuPrefModel preference5 = new("false", "back end", "design", "java");
                StuPrefModel preference6 = new("false", "back end", "design", "java");
                StuPrefModel preference7 = new("false", "database", "design", "c++");
                StuPrefModel preference8 = new("false", "database", "implementation", "c++");
                StuPrefModel preference9 = new("true", "back end", "social", "java");
                StuPrefModel preference10 = new("false", "front end", "social", "python");
                StuPrefModel preference11 = new("false", "back end", "design", "java");
                StuPrefModel preference12 = new("true", "back end", "implementation", "java");
                StuPrefModel preference13 = new("true", "database", "social", "c++");
                StuPrefModel preference14 = new("false", "back end", "implementation", "python");
                //StuPrefModel preference15 = new("false", "back end", "implementation");
                StuPrefModel preference15 = new("true", "front end", "design", "c++");
                StuPrefModel preference16 = new("false", "database end", "implementation", "c++");
                StuPrefModel preference17 = new("false", "database end", "implementation", "python");
                StuPrefModel preference18 = new("false", "front end", "social", "java");
                StuPrefModel preference19 = new("false", "back end", "design", "java");
                StuPrefModel preference20 = new("false", "back end", "design", "java");
                //StuPrefModel preference21 = new("false", "front end", "implementation");


                people.Add(preference1);
                people.Add(preference2);
                people.Add(preference3);
                people.Add(preference4);
                people.Add(preference5);
                people.Add(preference6);
                people.Add(preference7);
                people.Add(preference8);
                people.Add(preference9);
                people.Add(preference10);
                people.Add(preference11);
                people.Add(preference12);
                people.Add(preference13);
                people.Add(preference14);
                people.Add(preference15);
                people.Add(preference16);
                people.Add(preference17);
                people.Add(preference18);
                people.Add(preference19);
                people.Add(preference20);
                //people.Add(preference21);
            }
            // if diverese == true: get the most diverse groups
            // if diverese == false: get the most similar groups


            void getMostDiverseClass(bool diverse)
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

                Console.WriteLine("----------------------------");
                while (count < 10000)
                {
                    List<GroupPrefModel> groups = new List<GroupPrefModel>();
                    List<StuPrefModel> people = new List<StuPrefModel>();
                    initaliseData(groups, people);
                    GroupFormation make_groups = new GroupFormation(5, groups, people, 4);
                    List<StuPrefModel> proper_list = make_groups.copyList(people);
                    for (int i = 0; i < make_groups.Groups.Count; i++)
                    {
                        make_groups.randomiseGroups(make_groups.Groups[i], proper_list);
                    }
                    current_group = groups.ToList();
                    diversity = make_groups.groupDiversity();
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
                    proper_list = make_groups.copyList(people);
                }
                Console.WriteLine("MOST DIVERSE: " + mostDiverse);

                // This loop below is for showing the most diverse group
                for (int z = 0; z < mostDiverseGroup.Count; z++)
                {
                    GroupPrefModel iteratedGroup = mostDiverseGroup[z];
                    Console.WriteLine(iteratedGroup.Name);
                    for (int j = 0; j < 5; j++)
                    {
                        iteratedGroup.Members[j].displayPreferences();
                    }
                }
            }
            getMostDiverseClass(true);
        }
    }
}
*/


