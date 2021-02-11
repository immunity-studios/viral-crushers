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
    }
}
