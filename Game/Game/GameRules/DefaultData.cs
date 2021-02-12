﻿using System.Collections.Generic;

using Game.Models;
using Game.ViewModels;

namespace Game.GameRules
{
    public static class DefaultData
    {
        /// <summary>
        /// Load the Default data
        /// </summary>
        /// <returns></returns>
        public static List<ItemModel> LoadData(ItemModel temp)
        {
            var datalist = new List<ItemModel>()
            {
                new ItemModel {
                    Name = "Hand Soap",
                    Description = "",
                    ImageURI = "icon_hand_soap.png",
                    Range = 2,
                    Damage = 10,
                    Value = 7,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.CurrentHealth,
                    ItemType = ItemTypeEnum.HandSoap,
                },
                new ItemModel {
                    Name = "Tissue Box",
                    Description = "",
                    ImageURI = "icon_tissue_box.png",
                    IsConsumable = true,
                    Count = 10,
                    Range = 10,
                    Damage = 1,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.BoxOfTissues,
                },
                new ItemModel {
                    Name = "Mask",
                    Description = "",
                    ImageURI = "icon_mask.png",
                    Range = 10,
                    Damage = 10,
                    Value = 2,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Speed,
                    ItemType = ItemTypeEnum.Mask,
                },
                new ItemModel {
                    Name = "Sanitizer",
                    Description = "",
                    ImageURI = "icon_sanitizer.png",
                    Range = 10,
                    Damage = 5,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth,
                    ItemType = ItemTypeEnum.Sanitizer,
                },
                new ItemModel {
                    Name = "Face Shield",
                    Description = "",
                    ImageURI = "icon_face_shield.png",
                    Range = 4,
                    Damage = 10,
                    Value = 1,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.FaceShield,
                },
                new ItemModel {
                    Name = "Soup",
                    Description = "",
                    ImageURI = "icon_soup.png",
                    IsConsumable = true,
                    Count = 2,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Soup,
                },
                new ItemModel {
                    Name = "Bug Spray",
                    Description = "",
                    ImageURI = "icon_bug_spray.png",
                    IsConsumable = true,
                    Count = 5,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.BugSpray,
                },
                new ItemModel {
                    Name = "Mosquito Net",
                    Description = "",
                    ImageURI = "icon_mosquito_net.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.MosquitoNet,
                },
                new ItemModel {
                    Name = "Goggles",
                    Description = "",
                    ImageURI = "icon_goggles.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Goggles,
                },
                new ItemModel {
                    Name = "Gloves",
                    Description = "",
                    ImageURI = "icon_gloves.png",
                    IsConsumable = true,
                    Count = 4,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Gloves,
                },
                new ItemModel {
                    Name = "Vaccine",
                    Description = "",
                    ImageURI = "icon_vaccine.png",
                    IsConsumable = true,
                    Count = 1000,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Vaccine,
                },
                new ItemModel {
                    Name = "Medicine",
                    Description = "",
                    ImageURI = "icon_medicine.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Medicine,
                },
                new ItemModel {
                    Name = "Hazmat Suit",
                    Description = "",
                    ImageURI = "icon_hazmat_suit.png",
                    IsConsumable = true,
                    Count = 10,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.HazmatSuit,
                },
                new ItemModel {
                    Name = "Panacea",
                    Description = "",
                    ImageURI = "icon_panacea.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Panacea,
                },
                new ItemModel {
                    Name = "Invisible Cloak",
                    Description = "",
                    ImageURI = "icon_invisible_cloak.png",
                    IsConsumable = true,
                    Count = 10,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.InvisibleCloak,
                }
            };

            return datalist;
        }

    /// <summary>
    /// Load Example Scores
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<ScoreModel> LoadData(ScoreModel temp)
    {
        var datalist = new List<ScoreModel>()
            {
                new ScoreModel {
                    Name = "First Score",
                    Description = "Test Data",
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Test Data",
                }
            };

        return datalist;
    }

    /// <summary>
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<CharacterModel> LoadData(CharacterModel temp)
    {
        var HeadString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Head);
        var NecklassString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Necklass);
        var PrimaryHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.PrimaryHand);
        var OffHandString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.OffHand);
        var FeetString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Feet);
        var RightFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);
        var LeftFingerString = ItemIndexViewModel.Instance.GetDefaultItemId(ItemLocationEnum.Finger);

            var datalist = new List<CharacterModel>()
            {
                new CharacterModel {
                    Name = "Mark",
                    Job = CharacterJobEnum.Doctor,
                    Description = "",
                    SpecialAbility = SpecialAbilityEnum.MakeVaccine,
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "icon_doctor.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Emily",
                    Job = CharacterJobEnum.Teacher,
                    Description = "",
                    SpecialAbility = SpecialAbilityEnum.IncreaseSpeed,
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "icon_teacher.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Ashley",
                    Job = CharacterJobEnum.Athlete,
                    Description = "",
                    SpecialAbility = SpecialAbilityEnum.IncreaseDefense,
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "icon_athlete.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Jeff",
                    Job = CharacterJobEnum.PoliceOfficer,
                    Description = "",
                    SpecialAbility = SpecialAbilityEnum.IncreaseAttack,
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "icon_officer.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Penny",
                    Job = CharacterJobEnum.CollegeStudent,
                    Description = "",
                    SpecialAbility = SpecialAbilityEnum.WeakenDefense,
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "icon_student.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Wendy",
                    Job = CharacterJobEnum.Firefighter,
                    Description = "",
                    SpecialAbility = SpecialAbilityEnum.MakePanacea,
                    Level = 1,
                    MaxHealth = 5,
                    ImageURI = "icon_firefighter.png",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                
            };

        return datalist;
    }

    /// <summary>
    /// Load Characters
    /// </summary>
    /// <param name="temp"></param>
    /// <returns></returns>
    public static List<MonsterModel> LoadData(MonsterModel temp)
    {
            var datalist = new List<MonsterModel>()
            {
                new MonsterModel {
                    Name = "Bubbletooth",
                    Type = MonsterTypeEnum.Ebola,
                    Description = "A viral hemorrhagic fever caused by ebolaviruses. Symptoms are fever, sore throat, muscular pain, and headaches.",
                    ImageURI = "icon_purple_monster.png",
                    Level = 1,
                    MaxHealth = 9,
                    Attack = 4,
                    Range = 8,
                    Defense = 3,
                    Speed = 6
                },

                new MonsterModel {
                    Name = "Frogjaw",
                    Type = MonsterTypeEnum.Malaria,
                    Description = "A mosquito-borned infectious disease whose symptoms include fever, tiredness, vomitting, and headaches.",
                    ImageURI = "icon_blue_monster.png",
                    Level = 1,
                    MaxHealth = 6,
                    Attack = 4,
                    Range = 3,
                    Defense = 7,
                    Speed = 5
                },

                new MonsterModel {
                    Name = "Batcape",
                    Type = MonsterTypeEnum.Covid,
                    Description = "A contagious disease caused by severe acute respiratory syndrome coronavirus 2 (SARS-CoV-2).",
                    ImageURI = "icon_green_monster.png",
                    Level = 1,
                    MaxHealth = 10,
                    Attack = 9,
                    Range = 8,
                    Defense = 9,
                    Speed = 10
                },

                new MonsterModel {
                    Name = "Nightbite",
                    Type = MonsterTypeEnum.Measles,
                    Description = "A highly contagious infectious disease caused by measles virus. Symptoms are fever, cough, runny nose, and imflamed eyes.",
                    ImageURI = "icon_magenta_monster.png",
                    Level = 1,
                    MaxHealth = 4,
                    Attack = 4,
                    Range = 6,
                    Defense = 3,
                    Speed = 5
                },

                new MonsterModel {
                    Name = "Startlescream",
                    Type = MonsterTypeEnum.Flu,
                    Description = "An infectious disease caused by influenza virus. Symptoms include fever, runny nose, sore throat, headache, and fatigue.",
                    ImageURI = "icon_neon_green_monster.png",
                    Level = 1,
                    MaxHealth = 6,
                    Attack = 3,
                    Range = 5,
                    Defense = 2,
                    Speed = 3
                },

                new MonsterModel {
                    Name = "Bristlehex",
                    Type = MonsterTypeEnum.Cold,
                    Description = "A viral infectious disease that primarily affects the respiratory mucosa of the nose, throat, sinuses, and larynx.",
                    ImageURI = "icon_orange_monster.png",
                    Level = 1,
                    MaxHealth = 4,
                    Attack = 2,
                    Range = 3,
                    Defense = 2,
                    Speed = 3
                },
            };

        return datalist;
    }
}
}