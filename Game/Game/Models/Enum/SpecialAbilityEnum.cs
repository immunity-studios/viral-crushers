using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    /// <summary>
    /// The Types of Special Ability that Character Types can have
    /// </summary>
    public enum SpecialAbilityEnum
    {
        // Not specified
        Unknown = 0,

        // Not specified
        None = 1,

        // Can make vaccine
        MakeVaccine = 70,

        // Can increase speed for all characters
        IncreaseSpeed = 60,

        // Can increase defense for all characters
        IncreaseDefense = 50,

        // Can increase attack for all characters
        IncreaseAttack = 40,

        // Can weaken defense of all monsters
        WeakenDefense = 30,

        // Can make panacea
        MakePanacea = 80

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class SpcialAbilityEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this SpecialAbilityEnum value)
        {
            // Default String
            var Message = "None";

            switch (value)
            {
                case SpecialAbilityEnum.MakeVaccine:
                    Message = "Make Vaccine";
                    break;

                case SpecialAbilityEnum.IncreaseSpeed:
                    Message = "Increase Speed";
                    break;

                case SpecialAbilityEnum.IncreaseDefense:
                    Message = "Increase Defense";
                    break;

                case SpecialAbilityEnum.IncreaseAttack:
                    Message = "Increase Attack";
                    break;

                case SpecialAbilityEnum.WeakenDefense:
                    Message = "Weaken Defense";
                    break;

                case SpecialAbilityEnum.MakePanacea:
                    Message = "Make Panacea";
                    break;

                case SpecialAbilityEnum.None:
                case SpecialAbilityEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }

    /// <summary>
    /// Helper for the Special Ability Enum Class
    /// </summary>
    public static class SpecialAbilityEnumHelper
    {
        /// <summary>
        /// Returns a list of strings of the enum for SpecialAbility
        /// </summary>
        public static List<string> GetFullList
        {
            get
            {
                var myList = Enum.GetNames(typeof(SpecialAbilityEnum)).ToList();
                return myList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for Doctor
        /// </summary>
        public static List<string> GetListDoctor
        {
            get
            {

                List<string> SpecialAbilityList = new List<string>{
                    SpecialAbilityEnum.MakeVaccine.ToString()
                };

                return SpecialAbilityList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for Teacher
        /// </summary>
        public static List<string> GetListTeacher
        {
            get
            {
                List<string> SpecialAbilityList = new List<string>{
                    SpecialAbilityEnum.IncreaseSpeed.ToString()
                };

                return SpecialAbilityList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for Athlete
        /// </summary>
        public static List<string> GetListAthlete
        {
            get
            {
                List<string> SpecialAbilityList = new List<string>{
                    SpecialAbilityEnum.IncreaseDefense.ToString()
                };

                return SpecialAbilityList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for Police Officer
        /// </summary>
        public static List<string> GetListPoliceOfficer
        {
            get
            {
                List<string> SpecialAbilityList = new List<string>{
                    SpecialAbilityEnum.IncreaseAttack.ToString()
                };

                return SpecialAbilityList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for College Student
        /// </summary>
        public static List<string> GetListCollegeStudent
        {
            get
            {
                List<string> SpecialAbilityList = new List<string>{
                    SpecialAbilityEnum.WeakenDefense.ToString()
                };

                return SpecialAbilityList;
            }
        }


        /// <summary>
        /// Returns a list of strings of the enum for Firefighter
        /// </summary>
        public static List<string> GetListFireFighter
        {
            get
            {
                List<string> SpecialAbilityList = new List<string>{
                    SpecialAbilityEnum.MakePanacea.ToString()
                };

                return SpecialAbilityList;
            }
        }


        /// <summary>
        /// Given the String for an enum, return its value.  That allows for the enums to be numbered 2,4,6 rather than 1,2,3
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SpecialAbilityEnum ConvertStringToEnum(string value)
        {
            return (SpecialAbilityEnum)Enum.Parse(typeof(SpecialAbilityEnum), value);
        }
    }
}