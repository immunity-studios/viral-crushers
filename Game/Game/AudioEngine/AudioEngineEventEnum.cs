using System;
using System.Collections.Generic;
using System.Text;

namespace Game.AudioSystem
{
    /// <summary>
    /// Enum which contains all the supported events in the audio engine.
    /// When the specific event occurs in code, pass the appropriate enum
    /// into the AudioEngine.Instance.ProcessAudioEvent method
    /// </summary>
    public enum AudioEngineEventEnum
    {
        Unknown = 0,

        // UI click events
        Button_Default = 10,
        Button_GameStart = 11,

        // Character Select Events
        Character_Selected_Athlete = 20,
        Character_Selected_CollegeStudent = 21,
        Character_Selected_Doctor = 22,
        Character_Selected_Firefighter = 23,
        Character_Selected_PoliceOfficer = 24,
        Character_Selected_Teacher = 25,

        // Monster Select Events
        Monster_Selected_Measles = 30,
        Monster_Selected_Flu = 31,
        Monster_Selected_Cold = 32,
        Monster_Selected_Ebola = 33,
        Monster_Selected_Malaria = 34,
        Monster_Selected_Covid19 = 35,

        // Character Level Up Events
        Character_LevelUp_Athlete = 40,
        Character_LevelUp_CollegeStudent = 41,
        Character_LevelUp_Doctor = 42,
        Character_LevelUp_Firefighter = 43,
        Character_LevelUp_PoliceOfficer = 44,
        Character_LevelUp_Teacher = 45
    }
}
