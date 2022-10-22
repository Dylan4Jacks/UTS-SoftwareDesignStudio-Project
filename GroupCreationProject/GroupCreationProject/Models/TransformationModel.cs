using System;
namespace GroupCreationProject.Models
{
    public class TransformationModel
    {
        List<StuPrefModel> studentPrefs { get; set; }
        GroupPrefModel groupPref { get; set; }

        public TransformationModel(GroupPrefModel group)
        {
            groupPref = group;
            studentPrefs = getStudentPref();
        }

        public List<StuPrefModel> getStudentPref()
        {
            List<StuPrefModel> groupMembers = new List<StuPrefModel>();
            for (int i =0; i<groupPref.Members.Count; i++)
            {
                groupMembers.Add(groupPref.Members[i]);
            }
            return groupMembers;
        }

        public StudentModel transformStudent(StuPrefModel student){
            // Store procedured get student
            int stuId = student.StuID;
            int groupId = groupPref.ID;
            StudentModel new_student = new StudentModel(stuId, groupId /* other attributes from query */ );
            return new_student;
        }

        public void transformGroup()
        {
            int groupId = groupPref.ID;
            string groupName = groupPref.Name;
            // create group with stored procedure
            GroupModel new_group
        }
    }
}

