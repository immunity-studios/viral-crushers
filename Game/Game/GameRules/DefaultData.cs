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
                    Name = "I1",
                    Description = "I1",
                    ImageURI = "item.png",
                    Range = 2,
                    Damage = 10,
                    Value = 7,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.CurrentHealth
                },
                new ItemModel {
                    Name = "I2",
                    Description = "I2",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 1,
                    Value = 9,
                    Location = ItemLocationEnum.Head,
                    Attribute = AttributeEnum.Attack
                },
                new ItemModel {
                    Name = "I3",
                    Description = "I3",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 10,
                    Value = 2,
                    Location = ItemLocationEnum.Necklass,
                    Attribute = AttributeEnum.Speed
                },
                new ItemModel {
                    Name = "I4",
                    Description = "I4",
                    ImageURI = "item.png",
                    Range = 10,
                    Damage = 5,
                    Value = 9,
                    Location = ItemLocationEnum.OffHand,
                    Attribute = AttributeEnum.MaxHealth
                },
                new ItemModel {
                    Name = "I5",
                    Description = "I5",
                    ImageURI = "item.png",
                    Range = 4,
                    Damage = 10,
                    Value = 1,
                    Location = ItemLocationEnum.Finger,
                    Attribute = AttributeEnum.Defense
                },
                new ItemModel {
                    Name = "I6",
                    Description = "I6",
                    ImageURI = "item.png",
                    Range = 3,
                    Damage = 9,
                    Value = 6,
                    Location = ItemLocationEnum.Feet,
                    Attribute = AttributeEnum.Attack
                },
            };

            for (int i = 0; i < 20; i++)
            {
                var item = new ItemModel
                {
                    ImageURI = "item.png",
                    Range = 8,
                    Damage = 9,
                    Value = 2,
                    Location = ItemLocationEnum.PrimaryHand,
                    Attribute = AttributeEnum.Attack
                };
                item.Name = "I" + (datalist.Count+1).ToString();
                item.Description = item.Name;

                datalist.Add(item);
            }

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
                    Name = "Doctor",
                    Description = "Creates vaccine",
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
                    Name = "Teacher",
                    Description = "Increases speed (+10%) for all characters",
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
                    Name = "Athlete",
                    Description = "Increases defense (+10%) for all characters & Go first in the next level",
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
                    Name = "Police Officer",
                    Description = "Increases attack (+10%) for all characters",
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
                    Name = "College Student",
                    Description = "Decreases defense (-10%) of all monsters",
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
                    Name = "Firefighter",
                    Description = "Makes Panacea",
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
                    Name = "Ebola",
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
                    Name = "Malaria",
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
                    Name = "COVID-19",
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
                    Name = "Measles",
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
                    Name = "Flu",
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
                    Name = "Cold",
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