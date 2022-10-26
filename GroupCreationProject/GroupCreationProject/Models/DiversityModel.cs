using System.Linq;

namespace GroupCreationProject.Models;

public class DiversityModel
{
    protected List<StudentModel> students;
    protected List<CategorySelectionModel> catSelections;
    protected List<CategoryItemModel> catItems;

    public DiversityModel(IEnumerable<StudentModel> students, IEnumerable<CategorySelectionModel> catSelections, IEnumerable<CategoryItemModel> catItems)
    {
        this.students = students.ToList();
        this.catSelections = catSelections.ToList();
        this.catItems = catItems.ToList();
        //numberOfGroups based on NumOfStudents & groupCapacity (Rounded up); Case where NumOfStudents=0 then numberOfGroups defaults to 1 to show empty
        
    }

    internal List<GroupModel> getDiverseGroups(int groupSize, bool isDiverse)
    {
        int numberOfGroups = (students.Count - 1) / groupSize + 1;
        var newGroups = new List<GroupModel>();

        //Most Diverse Group

        int count = 0;
        Decimal mostDiverse;
        if (diverse == true) {
            mostDiverse = 999999999;
        }
        else {
            mostDiverse = -1;
        }
        Decimal diversity = mostDiverse;
        List<GroupPrefModel> mostDiverseGroup = new List<GroupPrefModel>();
        List<GroupPrefModel> current_group = new List<GroupPrefModel>();
        List<StuPrefModel> people = new List<StuPrefModel>();
        
        people = copyList(People);

        Console.WriteLine("----------------------------");
        while (count < 1000) {
            List<GroupPrefModel> groups = new List<GroupPrefModel>();
            //groups = Groups.ToList();


            //List<StuPrefModel> people = new List<StuPrefModel>();
            List<StuPrefModel> proper_list = copyList(people);
            for (int i = 0; i < Groups.Count; i++) {
                randomiseGroups(Groups[i], proper_list);
            }
            current_group = Groups.ToList();

            diversity = groupDiversity();
            if (diverse == true) {
                if (mostDiverse > diversity) {
                    mostDiverse = diversity;
                    diversity = 0;
                    mostDiverseGroup = current_group;
                }
            }
            else {
                if (mostDiverse < diversity) {
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


        //Calculate diversity
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
        //Return Diversity

        return newGroups;
    }


    

    // Randomises a group from a list of people
    public void randomiseGroups(GroupPrefModel group, List<StuPrefModel> listOfpeople)
    {
        int groupCounter = 0;
        Random rnd = this.rnd;
        group.Members.Clear();
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
        groupDiversity.Clear();
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
        groupA.Clear();
        groupA = group.getAttributes();
        Dictionary<string, int> groupAttributes = new Dictionary<string, int>();
        groupAttributes = attributesCount(groupA);

        return groupAttributes;
    }

    public List<GroupPrefModel> mostDiverseClass(bool diverse)
    {
        
    }

    //Transformation Model code
    IEnumerable<StudentModel> dataStu { get; set; }
    IEnumerable<CategorySelectionModel> dataCatSel { get; set; }
    IEnumerable<CategoryItemModel> dataCatItem { get; set; }
    public List<int> allStuIds { get; set; }



    public List<int> getAllStuIds()
    {
        List<int> stuIds = new List<int>();
        foreach (var stu in dataStu) {
            stuIds.Add(stu.StudentId);
        }
        return stuIds;
    }

    public Dictionary<int, List<int>> get_catSelect()
    {
        Dictionary<int, List<int>> stuId_catSelect = new Dictionary<int, List<int>>();
        for (int i = 0; i < allStuIds.Count; i++) {
            List<int> catItemId = new List<int>();
            catItemId.Clear();
            foreach (var catSelectId in dataCatSel) {
                if (catSelectId.StudentId == allStuIds[i]) {
                    catItemId.Add(catSelectId.CategoryItemId);
                }

            }
            stuId_catSelect.Add(allStuIds[i], catItemId);
        }
        return stuId_catSelect;
    }

    public List<StuPrefModel> transformStu()
    {
        List<StuPrefModel> students = new List<StuPrefModel>();
        foreach (KeyValuePair<int, List<int>> data in get_catSelect()) {
            List<string> preferences = new List<string>();
            preferences.Clear();
            foreach (var catItemId in dataCatItem) {
                for (int i = 0; i < data.Value.Count; i++) {
                    if (catItemId.CategoryItemId == data.Value[i]) {
                        preferences.Add(catItemId.Name);
                    }
                }
            }
            if (preferences.Count >= 4) {
                string preference1 = preferences[0];
                string preference2 = preferences[1];
                string preference3 = preferences[2];
                string preference4 = preferences[3];
                StuPrefModel new_student = new(data.Key, preference1, preference2, preference3, preference4);
                students.Add(new_student);
            }
        }
        return students;
    }

}
