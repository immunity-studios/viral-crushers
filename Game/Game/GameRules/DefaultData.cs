using System.Collections.Generic;

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
                    Range = 0,
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
                    Range = 0,
                    Damage = 1,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth,
                    ItemType = ItemTypeEnum.BoxOfTissues,
                },
                new ItemModel {
                    Name = "Breatheable",
                    Description = "Disposable Face Mask",
                    ImageURI = "icon_mask.png",
                    Range = 0,
                    Damage = 5,
                    Value = 2,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.Mask,
                },
                new ItemModel {
                    Name = "Purell",
                    Description = "Unscent Advanced Hand Sanitizer",
                    ImageURI = "icon_sanitizer.png",
                    Range = 2,
                    Damage = 5,
                    Value = 4,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack,
                    ItemType = ItemTypeEnum.Sanitizer,
                },
                new ItemModel {
                    Name = "TCP Global",
                    Description = "Ultra Clear Protective Full Face Shield",
                    ImageURI = "icon_face_shield.png",
                    Range = 0,
                    Damage = 6,
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
                    Range = 0,
                    Damage = 4,
                    Value = 2,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Speed,
                    ItemType = ItemTypeEnum.Soup,
                },
                new ItemModel {
                    Name = "REPEL",
                    Description = "Plant-Based Lemon Eucalyptus Insect Repellent",
                    ImageURI = "icon_bug_spray.png",
                    IsConsumable = true,
                    Count = 5,
                    Range = 0,
                    Damage = 6,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.BugSpray,
                },
                new ItemModel {
                    Name = "Timbuktoo",
                    Description = "Luxury Mosquito Net King Size",
                    ImageURI = "icon_mosquito_net.png",
                    Range = 0,
                    Damage = 3,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.MosquitoNet,
                },
                new ItemModel {
                    Name = "Gateway",
                    Description = "Safety Glasses Protective Eye Wear - Over-The-Glass",
                    ImageURI = "icon_goggles.png",
                    Range = 0,
                    Damage = 2,
                    Value = 6,
                    Location = ItemLocationEnum.RightFinger,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.Goggles,
                },
                new ItemModel {
                    Name = "ProCure",
                    Description = "Disposable Nitrile Gloves, Powder Free, Rubber Latex Free",
                    ImageURI = "icon_gloves.png",
                    IsConsumable = true,
                    Count = 4,
                    Range = 0,
                    Damage = 2,
                    Value = 6,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.Gloves,
                },
                new ItemModel {
                    Name = "Pfizer-BioNTech",
                    Description = "A COVID-19 vaccine authorized by FDA and recommended by the CDC",
                    ImageURI = "icon_vaccine.png",
                    IsConsumable = true,
                    Count = 5,
                    Range = 0,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth,
                    ItemType = ItemTypeEnum.Vaccine,
                },
                new ItemModel {
                    Name = "Tylenol",
                    Description = "It can treat minor aches and pains, and reduces fever.",
                    ImageURI = "icon_medicine.png",
                    Range = 0,
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
                    Count = 5,
                    Range = 0,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
                    ItemType = ItemTypeEnum.HazmatSuit,
                },
                new ItemModel {
                    Name = "Magic Bullet",
                    Description = "Supposedly cure all diseases and prolong life indefinitely",
                    ImageURI = "icon_panacea.png",
                    Range = 1,
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
                    Count = 5,
                    Range = 0,
                    Damage = 3,
                    Value = 6,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.Defense,
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
                    Description = "Great performance",
                    BattleNumber = 1,
                    GameDate = new System.DateTime(2019, 6, 1, 7, 47, 0),
                    AutoBattle = false,
                    TurnCount = 10,
                    RoundCount = 4,
                    MonsterSlainNumber = 20,
                    MonstersKilledList = "Joe (Ebola, Level 15), Chilly (Flu, Level 2)"
                },

                new ScoreModel {
                    Name = "Second Score",
                    Description = "Instant Replay worthy",
                    BattleNumber = 2,
                    GameDate = new System.DateTime(2020, 12, 4, 20, 30, 52),
                    AutoBattle = false,
                    TurnCount = 25,
                    RoundCount = 8,
                    MonsterSlainNumber = 28,
                    MonstersKilledList =  "Joe (Ebola, Level 15), Chilly (Flu, Level 2)"
                },

                new ScoreModel {
                    Name = "Third Score",
                    Description = "An exciting game",
                    BattleNumber = 3,
                    GameDate = new System.DateTime(2021, 1, 4, 12, 40, 1),
                    AutoBattle = false,
                    TurnCount = 10,
                    RoundCount = 4,
                    MonsterSlainNumber = 10,
                    MonstersKilledList =  "Joe (Ebola, Level 15), Chilly (Flu, Level 2)"
                },

                new ScoreModel {
                    Name = "Fourth Score",
                    Description = "One of the great games",
                    BattleNumber = 4,
                    GameDate = new System.DateTime(2021, 1, 20, 12, 0, 0),
                    AutoBattle = false,
                    TurnCount = 50,
                    RoundCount = 4,
                    MonsterSlainNumber = 10,
                    MonstersKilledList =  "Joe (Ebola, Level 15), Chilly (Flu, Level 2)"
                },
                
                new ScoreModel {
                    Name = "Fifth Score",
                    Description = "A cool autobattle",
                    BattleNumber = 5,
                    GameDate = new System.DateTime(2021, 2, 4, 12, 40, 1),
                    AutoBattle = true,
                    TurnCount = 75,
                    RoundCount = 30,
                    MonsterSlainNumber = 70,
                    MonstersKilledList =  "Will (Covid, Level 12), Mary (Cold, Level 1), Joe (Ebola, Level 12), Boop (Flu, Level 2)"
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
                    Description = "Technical, swift, administrative",
                    SpecialAbility = SpecialAbilityEnum.MakeVaccine,
                    Level = 1,
                    MaxHealth = 1,
                    //ImageURI = "icon_doctor.png",
                    ImageURI = "docgif.gif",
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
                    Description = "Coherent, didactic, safe",
                    SpecialAbility = SpecialAbilityEnum.IncreaseSpeed,
                    Level = 1,
                    MaxHealth = 5,
                    //ImageURI = "icon_teacher.png",
                    ImageURI = "teachergif.gif",
                    Head = HeadString,
                    Necklass = NecklassString,
                    PrimaryHand = PrimaryHandString,
                    OffHand = OffHandString,
                    Feet = FeetString,
                    RightFinger = RightFingerString,
                    LeftFinger = LeftFingerString,
                },

                new CharacterModel {
                    Name = "Ben",
                    Job = CharacterJobEnum.Athlete,
                    Description = "Diligent, breezy, thundering",
                    SpecialAbility = SpecialAbilityEnum.IncreaseDefense,
                    Level = 1,
                    MaxHealth = 5,
                    //ImageURI = "icon_athletegif.gif",
                    ImageURI = "athletegif.gif",
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
                    Description = "Traditional, ceaseless, detailed",
                    SpecialAbility = SpecialAbilityEnum.IncreaseAttack,
                    Level = 1,
                    MaxHealth = 5,
                    //ImageURI = "icon_officer.png",
                    ImageURI = "policegif.gif",
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
                    Description = "Blushing, observant, cooperative",
                    SpecialAbility = SpecialAbilityEnum.WeakenDefense,
                    Level = 1,
                    MaxHealth = 5,
                    //ImageURI = "icon_student.png",
                    ImageURI = "studentgif.gif",
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
                    Description = "Amazing, delightful, happy",
                    SpecialAbility = SpecialAbilityEnum.MakePanacea,
                    Level = 1,
                    MaxHealth = 5,
                    //ImageURI = "icon_firefighter.png",
                    ImageURI = "firefightergif.gif",
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
                    Name = "Giggleglow",
                    Type = MonsterTypeEnum.Ebola,
                    Description = "A viral hemorrhagic fever caused by ebolaviruses. Symptoms are fever, sore throat, muscular pain, and headaches.",
                    //ImageURI = "ebola_monster_140.png",
                    ImageURI = "ebolagif.gif",
                    Level = 1,
                    MaxHealth = 12,
                    CurrentHealth = 12,
                    Attack = 10,
                    Range = 2,
                    Defense = 5,
                    Speed = 6
                },

                new MonsterModel {
                    Name = "Frogjaw",
                    Type = MonsterTypeEnum.Malaria,
                    Description = "A mosquito-borned infectious disease whose symptoms include fever, tiredness, vomitting, and headaches.",
                    //ImageURI = "malaria_monster_140.png",
                    ImageURI = "malariagif.gif",
                    Level = 1,
                    MaxHealth = 12,
                    CurrentHealth = 12,
                    Attack = 4,
                    Range = 1,
                    Defense = 3,
                    Speed = 5
                },

                new MonsterModel {
                    Name = "Batcape",
                    Type = MonsterTypeEnum.Covid,
                    Description = "A contagious disease caused by severe acute respiratory syndrome coronavirus 2 (SARS-CoV-2).",
                    //ImageURI = "covid_monster_140.png",
                    ImageURI = "covidgif.gif",
                    Level = 1,
                    MaxHealth = 11,
                    CurrentHealth = 11,
                    Attack = 8,
                    Range = 2,
                    Defense = 6,
                    Speed = 6
                },

                new MonsterModel {
                    Name = "Nightbite",
                    Type = MonsterTypeEnum.Measles,
                    Description = "A highly contagious infectious disease caused by measles virus. Symptoms are fever, cough, runny nose, and imflamed eyes.",
                    //ImageURI = "measles_monster_140.png",
                    ImageURI = "measlesgif.gif",
                    Level = 1,
                    MaxHealth = 10,
                    CurrentHealth = 10,
                    Attack = 7,
                    Range = 1,
                    Defense = 5,
                    Speed = 5
                },

                new MonsterModel {
                    Name = "Laserbeak",
                    Type = MonsterTypeEnum.Flu,
                    Description = "An infectious disease caused by influenza virus. Symptoms include fever, runny nose, sore throat, headache, and fatigue.",
                    //ImageURI = "flu_monster_140.png",
                    ImageURI = "flugif.gif",
                    Level = 1,
                    MaxHealth = 6,
                    CurrentHealth = 6,
                    Attack = 5,
                    Range = 1,
                    Defense = 4,
                    Speed = 3
                },

                new MonsterModel {
                    Name = "Bristlehex",
                    Type = MonsterTypeEnum.Cold,
                    Description = "A viral infectious disease that primarily affects the respiratory mucosa of the nose, throat, sinuses, and larynx.",
                    //ImageURI = "cold_monster_140.png",
                    ImageURI = "coldgif.gif",
                    Level = 1,
                    MaxHealth = 6,
                    CurrentHealth = 6,
                    Attack = 5,
                    Range = 1,
                    Defense = 4,
                    Speed = 3
                },
            };

        return datalist;
    }
}
}