using System;
using NuGet.Protocol.Plugins;

namespace GroupCreationProject.Models
{
    public class StuPrefModel
    {
        public int StuID;
        public string Preference;
        public string Capability;
        public string Background;
        public string Interest;

        public StuPrefModel(int id, string preference, string capability, string background, string interest)
        {
            StuID = id;
            Preference = preference;
            Capability = capability;
            Background = background;
            Interest = interest;
        }

        public List<string> get_preferences()
        {
            List<string> preferences_list = new List<string>();
            preferences_list.Add(Preference);
            preferences_list.Add(Capability);
            preferences_list.Add(Background);
            preferences_list.Add(Interest);
            return preferences_list;
        }

        // Function used for testing to display preferences nicely
        public void displayPreferences()
        {
            List<string> preferences = new List<string>();
            preferences = get_preferences();
            Console.WriteLine("ID: " + StuID + " -- " + preferences[0] + ", " + preferences[1] + ", " + preferences[2] + ", " + preferences[3]);
        }
    }
}

