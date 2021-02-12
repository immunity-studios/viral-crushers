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
                    Message = "Covid-19";
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

        
    }

}