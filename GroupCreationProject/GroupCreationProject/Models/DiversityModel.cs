using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
namespace GroupCreationProject.Models;

public class DiversityModel
{
	protected Random rng;
	protected List<StudentModel> students;
	protected List<CategorySelectionModel> catSelections;
	protected List<CategoryItemModel> catItems;
	
	public DiversityModel(IEnumerable<StudentModel> students, IEnumerable<CategorySelectionModel> catSelections, IEnumerable<CategoryItemModel> catItems)
	{
		rng = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId));
		this.students = students.ToList();
		this.catSelections = catSelections.ToList();
		this.catItems = catItems.ToList();
		//numberOfGroups based on NumOfStudents & groupCapacity (Rounded up); Case where NumOfStudents=0 then numberOfGroups defaults to 1 to show empty

	}

	private IEnumerable<List<int>> splitRandomGroups(int nSize = 30)
	{
		
		//get only Id's
		List<int> studentIds = students.Select(x => x.StudentId).ToList();
		//Suffle student Id's
		int n = studentIds.Count;
		while (n > 1) {
			n--;
			int k = rng.Next(n + 1);
			int value = studentIds[k];
			studentIds[k] = studentIds[n];
			studentIds[n] = value;
		}

		//Create groups
		for (int i = 0; i < studentIds.Count; i += nSize) {
			yield return studentIds.GetRange(i, Math.Min(nSize, studentIds.Count - i));
		}
	}

	public List<List<int>> getDiverseGroups(int groupSize, bool isDiverse)
	{
		Decimal currentDiversity = (isDiverse) ? Decimal.MaxValue : Decimal.MinValue;
		Decimal newDiversity;

		List<List<int>> currentDiverseGroups = new();

		Dictionary<int, int> popAttributes = new();
		foreach(var category in catSelections.GroupBy(x => x.CategoryItemId)){
			popAttributes[category.Key] = category.Count();
		}

		Decimal baseline = Decimal.Divide(1, splitRandomGroups(groupSize).ToList().Count());

		int count = 0;
		while (count < 1000) {

			//Randomize Groups
			List<List<int>> randomGroups = splitRandomGroups(groupSize).ToList();
			int numberOfGroups = randomGroups.Count();

			List<decimal> diversityScores = new();
			foreach(List<int> group in randomGroups) {
				HashSet<int> excludedPopAttr = new(popAttributes.Keys);
				var groupedCatSelection= catSelections.Where(x => group.Contains(x.StudentId));
				foreach (var GroupAttribute in groupedCatSelection.GroupBy(x => x.CategoryItemId)) {
					excludedPopAttr.Remove(GroupAttribute.Key);
					diversityScores.Add(decimal.Divide(GroupAttribute.Count(), popAttributes[GroupAttribute.Key]));
				}
                diversityScores.AddRange(new decimal[(excludedPopAttr.Count)]);
			}
			
			newDiversity = diversityScores.Sum(attRscore => {
				decimal retScore = 0;
				if (attRscore == 0) {
					retScore += 1;
				}
				else {
					if (attRscore > baseline) retScore += (attRscore - baseline);
					if (attRscore < baseline) retScore += (baseline - attRscore);
				}
				return retScore;
			});
			
			
			if (isDiverse & currentDiversity > newDiversity) {
				currentDiversity = newDiversity;
				currentDiverseGroups = randomGroups;
			}
			else if (currentDiversity < newDiversity) {
				currentDiversity = newDiversity;
				currentDiverseGroups = randomGroups;
			}

			count += 1;
		}

		return currentDiverseGroups;
	}

    
}
