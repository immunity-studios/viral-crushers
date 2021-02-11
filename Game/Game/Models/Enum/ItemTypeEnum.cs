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
    }
}
