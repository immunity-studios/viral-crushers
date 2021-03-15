using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a Monster can have
    /// Used in Monster Crudi, and in Battles.
    /// </summary>
    public enum MonsterTypeEnum
    {
        // Not specified
        Unknown = 0,    

        Malaria = 18,

        Covid = 16,

        Measles = 14,

        Flu = 12,

        Cold = 10,

        Ebola = 20,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class MonsterTypeEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this MonsterTypeEnum value)
        {
            // Default String
            var Message = "Monster";

            switch (value)
            {
                case MonsterTypeEnum.Cold:
                    Message = "Cold";
                    break;

                case MonsterTypeEnum.Flu:
                    Message = "Flu";
                    break;

                case MonsterTypeEnum.Measles:
                    Message = "Measles";
                    break;

                case MonsterTypeEnum.Covid:
                    Message = "Covid";
                    break;

                case MonsterTypeEnum.Malaria:
                    Message = "Malaria";
                    break;

                case MonsterTypeEnum.Ebola:
                    Message = "Ebola";
                    break;

                case MonsterTypeEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for Character Jobs
    /// </summary>
    public static class MonsterTypeEnumHelper
    {
        /// <summary>
        /// Gets the list of Monster Types that a Monster can have.
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(MonsterTypeEnum)).ToList();

                var myReturn = myList.Where(job => job !=         MonsterTypeEnum.Unknown.ToString())
                    .OrderBy(a => a).ToList();

                return myReturn;
            }
        }

        public static string ToImageFile(this MonsterTypeEnum monsterType)
        {
            switch (monsterType)
            {
                case MonsterTypeEnum.Cold:
                    return "cold_monster_140.png";

                case MonsterTypeEnum.Flu:
                    return "flu_monster_140.png";

                case MonsterTypeEnum.Measles:
                    return "measles_monster_140.png";

                case MonsterTypeEnum.Covid:
                    return "covid_monster_140.png";

                case MonsterTypeEnum.Malaria:
                    return "malaria_monster_140.png";

                case MonsterTypeEnum.Ebola:
                    return "ebola_monster_140.png";

                default:
                    return null;
            }
        }

        public static string ToGifFile(this MonsterTypeEnum monsterType)
        {
            switch (monsterType)
            {
                case MonsterTypeEnum.Cold:
                    return "coldgif.gif";

                case MonsterTypeEnum.Flu:
                    return "flugif.gif";

                case MonsterTypeEnum.Measles:
                    return "measlesgif.gif";

                case MonsterTypeEnum.Covid:
                    return "covidgif.gif";

                case MonsterTypeEnum.Malaria:
                    return "malariagif.gif";

                case MonsterTypeEnum.Ebola:
                    return "ebolagif.gif";

                default:
                    return null;
            }
        }

        /// <summary>
        /// Mapping from string to enum value of monster type 
        /// </summary>
        private static Dictionary<string, MonsterTypeEnum> monsterTypeMapping = new Dictionary<string, MonsterTypeEnum>
        {
            {"Cold", MonsterTypeEnum.Cold },
            {"Flu", MonsterTypeEnum.Flu },
            {"Measles", MonsterTypeEnum.Measles },
            {"Covid", MonsterTypeEnum.Covid },
            {"Malaria", MonsterTypeEnum.Malaria },
            {"Ebola", MonsterTypeEnum.Ebola },
            {"Unknown", MonsterTypeEnum.Unknown }
        };

        /// <summary>
        /// Converts from mapped string of monster type to Monster Type enum value.
        /// </summary>
        public static MonsterTypeEnum ConvertMappedStringToEnum(this string mappedString)
        {
            if (monsterTypeMapping.TryGetValue(mappedString, out var monsterType))
            {
                return monsterType;
            }

            return MonsterTypeEnum.Unknown;
        }

        /// <summary>
        /// Converts from monster type enum value to mapped string 
        /// </summary>
        public static String ConvertEnumToMappedString(this MonsterTypeEnum monsterType)
        {
            foreach (var pair in monsterTypeMapping)
            {
                if (pair.Value == monsterType)
                {
                    return pair.Key;
                }
            }

            return "Unknown";
        }

    }

}