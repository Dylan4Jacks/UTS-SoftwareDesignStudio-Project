using System;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;


namespace GroupCreationProject.Models
{
    public class TransformationModel
    {

        IEnumerable<StudentModel> dataStu { get; set; }
        IEnumerable<CategorySelectionModel> dataCatSel { get; set; }
        IEnumerable<CategoryItemModel> dataCatItem { get; set; }
        public List<int> allStuIds { get; set; }


        public TransformationModel( IEnumerable<StudentModel> datastu, IEnumerable<CategorySelectionModel> datacatsel, IEnumerable<CategoryItemModel> datacatitem)
        {
            dataStu = datastu;
            dataCatSel = datacatsel;
            dataCatItem = datacatitem;
            allStuIds = getAllStuIds();
        }

        
        public List<int> getAllStuIds()
        {
            List<int> stuIds = new List<int>();
            foreach (var stu in dataStu)
            {
                stuIds.Add(stu.StudentId);
            }
            return stuIds;
        }

        public Dictionary<int, List<int>> get_catSelect()
        {
            Dictionary<int, List<int>> stuId_catSelect = new Dictionary<int, List<int>>();
            for (int i = 0; i < allStuIds.Count; i++)
            {
                List<int> catItemId = new List<int>();
                catItemId.Clear();
                foreach (var catSelectId in dataCatSel)
                {
                    if (catSelectId.StudentId == allStuIds[i])
                    {
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
            foreach (KeyValuePair<int, List<int>> data in get_catSelect())
            {
                List<string> preferences = new List<string>();
                preferences.Clear();
                foreach (var catItemId in dataCatItem)
                {
                    for (int i = 0; i < data.Value.Count; i++)
                    {
                        if (catItemId.CategoryItemId == data.Value[i])
                        {
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
}

