using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum CharacterJobEnum
    {
        // Not specified
        Unknown = 0,    

        // Doctor can create vaccine
        Doctor = 18,

        // Teacher can increase speed for all characters
        Teacher = 16,

        // Athlete can increase defense for all characters
        Athlete = 14,

        // Police Officer can increase attack for all characters
        PoliceOfficer = 12,

        // College Student can weaken defense of all monsters
        CollegeStudent = 10,

        // Firefighter can make panacea
        Firefighter = 20,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class CharacterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this CharacterJobEnum value)
        {
            // Default String
            var Message = "Character";

            switch (value)
            {
                case CharacterJobEnum.Doctor:
                    Message = "Doctor";
                    break;

                case CharacterJobEnum.Teacher:
                    Message = "Teacher";
                    break;

                case CharacterJobEnum.Athlete:
                    Message = "Athlete";
                    break;

                case CharacterJobEnum.PoliceOfficer:
                    Message = "Police Officer";
                    break;

                case CharacterJobEnum.CollegeStudent:
                    Message = "College Student";
                    break;

                case CharacterJobEnum.Firefighter:
                    Message = "Firefighter";
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for Character Jobs
    /// </summary>
    public static class CharacterJobEnumHelper
    {
        /// <summary>
        /// Gets the list of Character Jobs that a Character can have.
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                //var myList = Enum.GetNames(typeof(CharacterJobEnum)).ToList();
                var myList = characterTypeMapping.Keys;
                var myReturn = myList.Where(job => job !=         CharacterJobEnum.Unknown.ConvertEnumToMappedString())
                    .OrderBy(a => a).ToList();

                return myReturn;
            }
        }


        public static string ToImageFile(this CharacterJobEnum characterJob)
        {
            switch (characterJob)
            {
                case CharacterJobEnum.Doctor:
                    return "icon_doctor.png";

                case CharacterJobEnum.Teacher:
                    return "icon_teacher.png";

                case CharacterJobEnum.Athlete:
                    return "icon_athlete.png";

                case CharacterJobEnum.PoliceOfficer:
                    return "icon_officer.png";

                case CharacterJobEnum.CollegeStudent:
                    return "icon_student.png";

                case CharacterJobEnum.Firefighter:
                    return "icon_firefighter.png";

                default:
                    return null;
            }
        }

        public static string ToGifFile(this CharacterJobEnum characterJob)
        {
            switch (characterJob)
            {
                case CharacterJobEnum.Doctor:
                    return "docgif.gif";

                case CharacterJobEnum.Teacher:
                    return "teachergif.gif";

                case CharacterJobEnum.Athlete:
                    return "athletegif.gif";

                case CharacterJobEnum.PoliceOfficer:
                    return "police.gif";

                case CharacterJobEnum.CollegeStudent:
                    return "studentgif.gif";

                case CharacterJobEnum.Firefighter:
                    return "firefightergif.gif";

                default:
                    return null;
            }
        }

        /// <summary>
        /// Mapping from string to enum value of item type 
        /// </summary>
        private static Dictionary<string, CharacterJobEnum> characterTypeMapping = new Dictionary<string, CharacterJobEnum>
        {
            {"Doctor", CharacterJobEnum.Doctor },
            {"Teacher", CharacterJobEnum.Teacher },
            {"Athlete", CharacterJobEnum.Athlete },
            {"Police Officer", CharacterJobEnum.PoliceOfficer },
            {"College Student", CharacterJobEnum.CollegeStudent },
            {"Firefighter", CharacterJobEnum.Firefighter },
            {"Unknown", CharacterJobEnum.Unknown }
        };

        /// <summary>
        /// Converts from mapped string of character type to CharacterJob enum value.
        /// </summary>
        public static CharacterJobEnum ConvertMappedStringToEnum(this string mappedString)
        {
            if (characterTypeMapping.TryGetValue(mappedString, out var characterType))
            {
                return characterType;
            }

            return CharacterJobEnum.Unknown;
        }

        /// <summary>
        /// Converts from character type enum value to mapped string 
        /// </summary>
        public static String ConvertEnumToMappedString(this CharacterJobEnum characterType)
        {
            foreach (var pair in characterTypeMapping)
            {
                if (pair.Value == characterType)
                {
                    return pair.Key;
                }
            }

            return "Unknown";
        }


    }

}