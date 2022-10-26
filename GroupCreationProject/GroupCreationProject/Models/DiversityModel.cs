using System.Linq;

namespace GroupCreationProject.Models;

public class DiversityModel
{
	protected List<StudentModel> students;
	protected List<CategorySelectionModel> catSelections;
	protected List<CategoryItemModel> catItems;

	//===========Transformation Model REFERENCE ==============
	// IEnumerable<StudentModel> dataStu { get; set; }
	// IEnumerable<CategorySelectionModel> dataCatSel { get; set; }
	// IEnumerable<CategoryItemModel> dataCatItem { get; set; }
	// public List<int> allStuIds { get; set; }

	public DiversityModel(IEnumerable<StudentModel> students, IEnumerable<CategorySelectionModel> catSelections, IEnumerable<CategoryItemModel> catItems)
	{
		this.students = students.ToList();
		this.catSelections = catSelections.ToList();
		this.catItems = catItems.ToList();
		//numberOfGroups based on NumOfStudents & groupCapacity (Rounded up); Case where NumOfStudents=0 then numberOfGroups defaults to 1 to show empty

	}

	public List<GroupModel> getDiverseGroups(int groupSize, bool isDiverse)
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
		//=========== COPYLIST ===================
		peopleCopy = copyList(People);

		Console.WriteLine("----------------------------");
		while (count < 1000) {
			List<GroupPrefModel> groups = new List<GroupPrefModel>();
			//groups = Groups.ToList();


			//=========== COPYLIST ===================
			List<StuPrefModel> proper_list = copyList(people);
			for (int i = 0; i < Groups.Count; i++) {
				//=========== RANDOMIZE GROUPS ===================
				GroupPrefModel group = Groups[i];
				List<StuPrefModel> proper_list;
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
			current_group = Groups.ToList();

			//==================GROUP DIVERSITY===================
			//Calculates the diversity rating for each attribute in a single group
			List<List<Decimal>> groupDiversity = new List<List<Decimal>>();
			groupDiversity.Clear();
			Decimal totalDiversityScore = 0;
			for (int i = 0; i < Groups.Count; i++) {
				// ================= GROUP DIVERSITY =====================
				List<Decimal> groupDiversity = new List<Decimal>();
				Dictionary<string, int> groupAttributes = new Dictionary<string, int>();
				Dictionary<string, int> popAttributes = new Dictionary<string, int>();

				//============GET GROUP ATTRIBUTES==============
				// Returns the diversity score of all groups in a class
				List<string> groupA = new List<string>();
				groupA.Clear();
				groupA = Groups[i].getAttributes();
				Dictionary<string, int> groupAttributes = new Dictionary<string, int>();
				groupAttributes = attributesCount(groupA);

				//===========GET ALL ATTRIBUTES==============
				// Gets all the preferences for the whole population(class of students) as a list<string>
				List<string> all_preferences = new List<string>();
				List<string> individualPreferences = new List<string>();
				for (int i = 0; i < People.Count; i++) {
					individualPreferences = People[i].get_preferences();
					for (int j = 0; j < individualPreferences.Count; j++) {
						all_preferences.Add(individualPreferences[j]);
					}
				}
				popAttributes = attributesCount(all_preferences());


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
				groupDiversity.Add(groupDiversity);
				//break; // REMOVE this after testing
			}

			for (int j = 0; j < groupDiversity.Count; j++) {

				for (int z = 0; z < groupDiversity[j].Count; z++) {
					Decimal attRscore = groupDiversity[j][z];
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
					totalDiversityScore += groupScore;
					//Console.WriteLine("Score: " + groupDiversity[j][z]);
					//Console.WriteLine("Points: " + pointsCalculation(groupDiversity[j][z]));
				}
			}
			diversity = totalDiversityScore; ;

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







}
