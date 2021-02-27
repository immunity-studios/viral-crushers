using System;

namespace Game.Helpers
{
    /// <summary>
    /// Helper to roll dice and random numbers
    /// </summary>
    public static class DiceHelper
    {
        /// <summary>
        /// Random should only be instantiated once
        /// Because each call to new Random will reset the seed value, and thus the numbers generated
        /// You can control the seed value for Random by passing a value to the constructor
        /// Do that if you want to be able able get the same sequence of Random over and over
        /// </summary>
        private static Random rnd = new Random();

        // Turn on to force Rolls to be non random
        public static bool ForceRollsToNotRandom = false;

        // Holds the random value for the sytem
        private static int _ForcedRandomValue = 1;
        
        /// <summary>
        /// What number should return for random numbers (1 is good choice...)
        /// </summary>
        public static int SetForcedRollValue(int value)
        {
            _ForcedRandomValue = value;
            return _ForcedRandomValue;
        }

        /// <summary>
        /// Turn Random State Off
        /// </summary>
        /// <returns></returns>
        public static bool DisableForcedRolls()
        {
            ForceRollsToNotRandom = false;
            return ForceRollsToNotRandom;
        }

        /// <summary>
        /// Turn Random State On
        /// </summary>
        public static void EnableForcedRolls()
        {
            ForceRollsToNotRandom = true;
        }

        /// <summary>
        /// Method to Roll A Random Dice, a Set number of times
        /// </summary>
        /// <param name="rolls">The number of Rolls to Make</param>
        /// <param name="dice">The Dice to Roll</param>
        /// <returns></returns>
        public static int RollDice(int rolls, int dice)
        {
            if (rolls < 1)
            {
                return 0;
            }

            // ForceRolls check after the rolls check, that prevents the bug of negative rolls
            if (ForceRollsToNotRandom)
            {
                return rolls * _ForcedRandomValue;
            }

            // Dice check is after Rolls number check to allow for force roll value even if dice it 0
            if (dice < 1)
            {
                return 0;
            }

            var myReturn = 0;

            for (var i = 0; i < rolls; i++)
            {
                // Add one to the dice, because random is between.  So 1-10 is rnd.Next(1,11)
                myReturn += rnd.Next(1, dice + 1);
            }

            return myReturn;
        }
    }
}