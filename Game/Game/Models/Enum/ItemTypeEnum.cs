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
                var myList = itemTypeMapping.Keys;
                var myReturn = myList.OrderBy(a => a)
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

        public static string ToImageFile(this ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                case ItemTypeEnum.HandSoap:
                    return "icon_hand_soap.png";

                case ItemTypeEnum.BoxOfTissues:
                    return "icon_tissue_box.png";

                case ItemTypeEnum.Mask:
                    return "icon_mask.png";

                case ItemTypeEnum.Sanitizer:
                    return "icon_sanitizer.png";

                case ItemTypeEnum.FaceShield:
                    return "icon_face_shield.png";

                case ItemTypeEnum.Soup:
                    return "icon_soup.png";

                case ItemTypeEnum.BugSpray:
                    return "icon_bug_spray.png";

                case ItemTypeEnum.MosquitoNet:
                    return "icon_mosquito_net.png";

                case ItemTypeEnum.Goggles:
                    return "icon_goggles.png";

                case ItemTypeEnum.Gloves:
                    return "icon_gloves.png";

                case ItemTypeEnum.Vaccine:
                    return "icon_vaccine.png";

                case ItemTypeEnum.Medicine:
                    return "icon_medicine.png";

                case ItemTypeEnum.HazmatSuit:
                    return "icon_hazmat_suit.png";

                case ItemTypeEnum.Panacea:
                    return "icon_panacea.png";

                case ItemTypeEnum.InvisibleCloak:
                    return "icon_invisible_cloak.png";

                default:
                    return null;
            }
        }

        /// <summary>
        /// Mapping from string to enum value of item type 
        /// </summary>
        private static Dictionary<string, ItemTypeEnum> itemTypeMapping = new Dictionary<string, ItemTypeEnum>
        {
            {"Hand Soap", ItemTypeEnum.HandSoap },
            {"Box Of Tissues", ItemTypeEnum.BoxOfTissues },
            {"Mask", ItemTypeEnum.Mask },
            {"Sanitizer", ItemTypeEnum.Sanitizer },
            {"Face Shield", ItemTypeEnum.FaceShield },
            {"Soup", ItemTypeEnum.Soup },
            {"Bug Spray", ItemTypeEnum.BugSpray },
            {"Mosquito Net", ItemTypeEnum.MosquitoNet },
            {"Goggles", ItemTypeEnum.Goggles },
            {"Gloves", ItemTypeEnum.Gloves },
            {"Vaccine", ItemTypeEnum.Vaccine },
            {"Medicine" , ItemTypeEnum.Medicine },
            {"Hazmat Suit", ItemTypeEnum.HazmatSuit },
            {"Panacea", ItemTypeEnum.Panacea },
            {"Invisible Cloak", ItemTypeEnum.InvisibleCloak }
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
        public static String ConvertEnumToMappedString(ItemTypeEnum itemType)
        {
            foreach (var pair in itemTypeMapping)
            {
                if (pair.Value == itemType)
                {
                    return pair.Key;
                }
            }

            return "Unknown";
        }
    }
}

