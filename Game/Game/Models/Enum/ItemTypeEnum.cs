using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Models
{
    public enum ItemTypeEnum
    {
        Unknown = 0,
        HandSoap = 2,
        BoxOfTissues = 4,
        Mask = 8,
        Sanitizer = 16,
        FaceShield = 32,
        Soup = 64,
        BugSpray = 128,
        MosquitoNet = 256,
        Goggles = 13,
        Gloves = 25,
        Vaccine = 20,
        Medicine = 9,
        HazmatSuit = 6,
        Panacea = 5,
        InvisibleCloak = 3
    }


    /// <summary>
    /// Helper for Item Types
    /// </summary>
    public static class ItemTypeEnumHelper
    {
        /// <summary>
        /// Gets the list of Types that an Item can have.
        /// </summary>
        public static List<string> GetListItem
        {
            get
            {
                var myList = Enum.GetNames(typeof(ItemTypeEnum));
                var myReturn = myList.Where(item => item != ItemTypeEnum.Unknown.ToString())
                                     .OrderBy(a => a)
                                     .ToList();
                return myReturn;
            }
        }

        /// <summary>
        /// Returns true if the Item type is a consumable item type,
        /// false otherwise.
        /// </summary>
        public static bool IsConsumableItemType(this ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                case ItemTypeEnum.BoxOfTissues:
                case ItemTypeEnum.Soup:
                case ItemTypeEnum.BugSpray:
                case ItemTypeEnum.Gloves:
                case ItemTypeEnum.Vaccine:
                case ItemTypeEnum.HazmatSuit:
                case ItemTypeEnum.InvisibleCloak:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Returns the count for a consumable item type, or one if it is not
        /// a consumable item type.
        /// </summary>
        public static int CountOfConsumable(this ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                case ItemTypeEnum.BoxOfTissues:
                    return 10;
                case ItemTypeEnum.Soup:
                    return 2;
                case ItemTypeEnum.BugSpray:
                    return 5;
                case ItemTypeEnum.Gloves:
                    return 4;
                case ItemTypeEnum.Vaccine:
                    return 1000;
                case ItemTypeEnum.HazmatSuit:
                    return 10;
                case ItemTypeEnum.InvisibleCloak:
                    return 10;
                default:
                    return 1;
            }
        }

        /// <summary>
        /// Mapping from string to enum value of item type 
        /// </summary>
        private static Dictionary<string, ItemTypeEnum> itemTypeMapping = new Dictionary<string, ItemTypeEnum>
        {
            {"HandSoap", ItemTypeEnum.HandSoap },
            {"BoxOfTissues", ItemTypeEnum.BoxOfTissues },
            {"Mask", ItemTypeEnum.Mask },
            {"Sanitizer", ItemTypeEnum.Sanitizer },
            {"FaceShield", ItemTypeEnum.FaceShield },
            {"Soup", ItemTypeEnum.Soup },
            {"BugSpray", ItemTypeEnum.BugSpray },
            {"MosquitoNet", ItemTypeEnum.MosquitoNet },
            {"Goggles", ItemTypeEnum.Goggles },
            {"Gloves", ItemTypeEnum.Gloves },
            {"Vaccine", ItemTypeEnum.Vaccine },
            {"Medicine" , ItemTypeEnum.Medicine },
            {"HazmatSuit", ItemTypeEnum.HazmatSuit },
            {"Panacea", ItemTypeEnum.Panacea },
            {"InvisibleCloak", ItemTypeEnum.InvisibleCloak }
        };

        /// <summary>
        /// Converts from mapped string of item type to ItemType enum value.
        /// </summary>
        public static ItemTypeEnum ConvertMappedStringToEnum(string mappedString)
        {
            if (itemTypeMapping.TryGetValue(mappedString, out var itemType))
            {
                return itemType;
            }

            return ItemTypeEnum.Unknown;
        }

        /// <summary>
        /// Converts from item type enum value to mapped string 
        /// </summary>
        public static String ConvertEnumToString(ItemTypeEnum itemType)
        {
            foreach (var pair in itemTypeMapping)
            {
                if (pair.Value == itemType)
                {
                    return pair.Key;
                }
            }

            return "";

            //switch (itemType)
            //{
            //    case ItemTypeEnum.HandSoap:
            //        return "HandSoap";

            //    case ItemTypeEnum.BoxOfTissues:
            //        return "BoxOfTissues";

            //    case ItemTypeEnum.Mask:
            //        return "Mask";

            //    case ItemTypeEnum.Sanitizer:
            //        return "Sanitizer";

            //    case ItemTypeEnum.FaceShield:
            //        return "FaceShield";

            //    case ItemTypeEnum.Soup:
            //        return "Soup";

            //    case ItemTypeEnum.BugSpray:
            //        return "BugSpray";

            //    case ItemTypeEnum.MosquitoNet:
            //        return "MosquitoNet";

            //    case ItemTypeEnum.Goggles:
            //        return "Goggles";

            //    case ItemTypeEnum.Gloves:
            //        return "Gloves";

            //    case ItemTypeEnum.Vaccine:
            //        return "Vaccine";

            //    case ItemTypeEnum.Medicine:
            //        return "Medicine";

            //    case ItemTypeEnum.HazmatSuit:
            //        return "HazmatSuit";

            //    case ItemTypeEnum.Panacea:
            //        return "Panacea";

            //    case ItemTypeEnum.InvisibleCloak:
            //        return "InvisibleCloak";

            //    default:
            //        return "";
            //}
        }
    }
}

