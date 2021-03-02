using System.Linq;
using System.Threading.Tasks;
using Game.Engine.EngineBase;
using Game.Engine.EngineInterfaces;
using Game.GameRules;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// AutoBattle Engine
    /// 
    /// Runs the engine simulation with no user interaction
    /// 
    /// </summary>
    public class AutoBattleEngine : AutoBattleEngineBase, IAutoBattleInterface
    {
        #region Algrorithm
        // Prepare for Battle
        // Pick 6 Characters
        // Initialize the Battle
        // Start a Round

        // Fight Loop
        // Loop in the round each turn
        // If Round is over, Start New Round
        // Check end state of round/game

        // Wrap up
        // Get Score
        // Save Score
        // Output Score
        #endregion Algrorithm

        /// <summary>
        /// Default AutoBattleEngine constructor
        /// </summary>
        public AutoBattleEngine()
        {
            Battle = new BattleEngine();
        }

        public override bool CreateCharacterParty()
        {
            for (int i = Battle.EngineSettings.CharacterList.Count(); i < Battle.EngineSettings.MaxNumberPartyCharacters; i++)
            {
                Battle.PopulateCharacterList(RandomPlayerHelper.GetRandomCharacter(1));
            }

            return true;
        }

        public override bool DetectInfinateLoop()
        {
            return base.DetectInfinateLoop();
        }

        public override Task<bool> RunAutoBattle()
        {
            return base.RunAutoBattle();
        }
    }
}