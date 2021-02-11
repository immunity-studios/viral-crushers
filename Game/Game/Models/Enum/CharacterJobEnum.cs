namespace Game.Models
{
    /// <summary>
    /// The Types of Jobs a character can have
    /// Used in Character Crudi, and in Battles.
    /// </summary>
    public enum CharacterJobEnum
    {
        // Not specified
        Unknown = 0,    

        //// Fighters hit hard and have fight abilities
        //Fighter = 10,

        //// Clerics defend well and have buff abilities
        //Cleric = 12,

        // Doctor can create vaccine
        Doctor = 18,

        // Teacher can increase speed for all characters
        Teacher = 16,

        // Athlete can increase defense for all characters
        Athlete = 14,

        // Police Officer can increase attack for all characters
        PoliceOfficer = 12,

        // College Student can weaken defense of all monsters
        CollegeStudent = 10,

        // Firefighter can make panacea
        Firefighter = 20,

    }

    /// <summary>
    /// Friendly strings for the Enum Class
    /// </summary>
    public static class CharacterJobEnumExtensions
    {
        /// <summary>
        /// Display a String for the Enums
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToMessage(this CharacterJobEnum value)
        {
            // Default String
            var Message = "Character";

            switch (value)
            {
                case CharacterJobEnum.Doctor:
                    Message = "Doctor";
                    break;

                case CharacterJobEnum.Teacher:
                    Message = "Teacher";
                    break;

                case CharacterJobEnum.Athlete:
                    Message = "Athelete";
                    break;

                case CharacterJobEnum.PoliceOfficer:
                    Message = "Police Officer";
                    break;

                case CharacterJobEnum.CollegeStudent:
                    Message = "College Student";
                    break;

                case CharacterJobEnum.Firefighter:
                    Message = "Firefighter";
                    break;

                case CharacterJobEnum.Unknown:
                default:
                    break;
            }

            return Message;
        }
    }
}