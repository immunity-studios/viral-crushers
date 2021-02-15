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
                    Name = "Softsoap",
                    Description = "Soothing Clean Aloe Vera",
                    ImageURI = "icon_hand_soap.png",
                    Range = 2,
                    Damage = 10,
                    Value = 7,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.CurrentHealth,
                    ItemType = ItemTypeEnum.HandSoap,
                },
                new ItemModel {
                    Name = "Kleenex",
                    Description = "Ultra Soft Facial Tissues",
                    ImageURI = "icon_tissue_box.png",
                    IsConsumable = true,
                    Count = 10,
                    Range = 10,
                    Damage = 1,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.BoxOfTissues,
                },
                new ItemModel {
                    Name = "Breatheable",
                    Description = "Disposable Face Mask",
                    ImageURI = "icon_mask.png",
                    Range = 10,
                    Damage = 10,
                    Value = 2,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Speed,
                    ItemType = ItemTypeEnum.Mask,
                },
                new ItemModel {
                    Name = "Purell",
                    Description = "Unscent Advanced Hand Sanitizer",
                    ImageURI = "icon_sanitizer.png",
                    Range = 10,
                    Damage = 5,
                    Value = 9,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.MaxHealth,
                    ItemType = ItemTypeEnum.Sanitizer,
                },
                new ItemModel {
                    Name = "TCP Global",
                    Description = "Ultra Clear Protective Full Face Shield",
                    ImageURI = "icon_face_shield.png",
                    Range = 4,
                    Damage = 10,
                    Value = 1,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.FaceShield,
                },
                new ItemModel {
                    Name = "Whole Foods",
                    Description = "Mom's Chicken Soup",
                    ImageURI = "icon_soup.png",
                    IsConsumable = true,
                    Count = 2,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Soup,
                },
                new ItemModel {
                    Name = "REPEL",
                    Description = "Plant-Based Lemon Eucalyptus Insect Repellent",
                    ImageURI = "icon_bug_spray.png",
                    IsConsumable = true,
                    Count = 5,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.BugSpray,
                },
                new ItemModel {
                    Name = "Timbuktoo",
                    Description = "Luxury Mosquito Net King Size",
                    ImageURI = "icon_mosquito_net.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.MosquitoNet,
                },
                new ItemModel {
                    Name = "Gateway",
                    Description = "Safety Glasses Protective Eye Wear - Over-The-Glass",
                    ImageURI = "icon_goggles.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Goggles,
                },
                new ItemModel {
                    Name = "ProCure",
                    Description = "Disposable Nitrile Gloves, Powder Free, Rubber Latex Free",
                    ImageURI = "icon_gloves.png",
                    IsConsumable = true,
                    Count = 4,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Gloves,
                },
                new ItemModel {
                    Name = "Pfizer-BioNTech",
                    Description = "A COVID-19 vaccine authorized by FDA and recommended by the CDC",
                    ImageURI = "icon_vaccine.png",
                    IsConsumable = true,
                    Count = 1000,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Vaccine,
                },
                new ItemModel {
                    Name = "Tylenol",
                    Description = "It can treat minor aches and pains, and reduces fever.",
                    ImageURI = "icon_medicine.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Medicine,
                },
                new ItemModel {
                    Name = "PAGE ONE",
                    Description = "Disposable Isolation Suit,Long Front Zipper Elastic Waistband",
                    ImageURI = "icon_hazmat_suit.png",
                    IsConsumable = true,
                    Count = 10,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.HazmatSuit,
                },
                new ItemModel {
                    Name = "Magic Bullet",
                    Description = "Supposedly cure all diseases and prolong life indefinitely",
                    ImageURI = "icon_panacea.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Panacea,
                },
                new ItemModel {
                    Name = "Tarnkappe",
                    Description = "A cape that covers not just the head but enshrouds the body",
                    ImageURI = "icon_invisible_cloak.png",
                    IsConsumable = true,
                    Count = 10,
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
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
                    Description = "technical, swift, administrative",
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
                    Description = "coherent, didactic, safe",
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
                    Description = "diligent, breezy, thundering",
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
                    Description = "traditional, ceaseless, detailed",
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
                    Description = "blushing, observant, cooperative",
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
                    Description = "amazing, delightful, happy",
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
                    ImageURI = "ebola_monster_140.png",
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
                    ImageURI = "malaria_monster_140.png",
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
                    ImageURI = "covid_monster_140.png",
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
                    ImageURI = "measles_monster_140.png",
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
                    ImageURI = "flu_monster_140.png",
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
                    ImageURI = "cold_monster_140.png",
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