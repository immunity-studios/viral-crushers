using Game.Engine.EngineBase;
using System;
using System.Collections.Generic;
using System.Linq;

using Game.Engine.EngineInterfaces;
using Game.Engine.EngineModels;
using Game.GameRules;
using Game.Models;
using Game.ViewModels;

namespace Game.Engine.EngineGame
{
    /// <summary>
    /// Manages the Rounds
    /// </summary>
    public class RoundEngine : RoundEngineBase, IRoundEngineInterface
    {
        // Hold the BaseEngine
        public new EngineSettingsModel EngineSettings = EngineSettingsModel.Instance;

        /// <summary>
        /// Default RoundEngine constructor
        /// </summary>
        public RoundEngine()
        {
            Turn = new TurnEngine();
        }

        /// <summary>
        /// Clear the List between Rounds
        /// </summary>
        public override bool ClearLists()
        {
            EngineSettings.ItemPool.Clear();
            EngineSettings.MonsterList.Clear();
            return true;
        }

        /// <summary>
        /// Set the Current Attacker
        /// </summary>
        public override bool SetCurrentAttacker(PlayerInfoModel player)
        {
            EngineSettings.CurrentAttacker = player;

            return true;
        }

        /// <summary>
        /// Set the Current Attacker
        /// </summary>
        public override bool SetCurrentDefender(PlayerInfoModel player)
        {
            EngineSettings.CurrentDefender = player;

            return true;
        }

        /// <summary>
        /// Call to make a new set of monsters..
        /// </summary>
        public override bool NewRound()
        {
            // End the existing round
            EndRound();

            // Remove Character Buffs
            RemoveCharacterBuffs();

            // Populate New Monsters..
            AddMonstersToRound();

            // Make the BaseEngine.PlayerList
            MakePlayerList();

            // Set Order for the Round
            OrderPlayerListByTurnOrder();

            // Populate BaseEngine.MapModel with Characters and Monsters
            EngineSettings.MapModel.PopulateMapModel(EngineSettings.PlayerList);

            // Update Score for the RoundCount
            EngineSettings.BattleScore.RoundCount++;

            return true;
        }

        /// <summary>
        /// Add Monsters to the Round
        /// 
        /// Because Monsters can be duplicated, will add 1, 2, 3 to their name
        ///   
        /*
            * Hint: 
            * I don't have crudi monsters yet so will add 6 new ones..
            * If you have crudi monsters, then pick from the list

            * Consdier how you will scale the monsters up to be appropriate for the characters to fight
            * 
            */
        /// </summary>
        /// <returns></returns>
        public override int AddMonstersToRound()
        {
            int TargetLevel = 1;

            if (EngineSettings.CharacterList.Count() > 0)
            {
                // Get the Min Character Level (linq is soo cool....)
                TargetLevel = Convert.ToInt32(EngineSettings.CharacterList.Min(m => m.Level));
            }
            // Loop through all monsters in database
            for (var i = 0; i < BattleEngineViewModel.Instance.DatabaseMonsterList.Count(); i++)
            {
                var data = BattleEngineViewModel.Instance.DatabaseMonsterList.ElementAt(i);

                // Only get monster who has level <= characters' level
                if (data.Level <= TargetLevel)
                {
                    EngineSettings.MonsterList.Add(new PlayerInfoModel(data));
                }
            }

            return EngineSettings.MonsterList.Count();
        }

        /// <summary>
        /// At the end of the round
        /// Clear the ItemModel List
        /// Clear the MonsterModel List
        /// </summary>
        public override bool EndRound()
        {
            // In Auto Battle this happens and the characters get their items, In manual mode need to do it manualy
            if (EngineSettings.BattleScore.AutoBattle)
            {
                PickupItemsForAllCharacters();
            }

            // Reset Monster and Item Lists
            ClearLists();

            return true;
        }

        /// <summary>
        /// For each character pickup the items
        /// </summary>
        public override void PickupItemsForAllCharacters()
        {
            // In Auto Battle this happens and the characters get their items
            // When called manualy, make sure to do the character pickup before calling EndRound

            // TOD: Return for now, and revisit this functionality.
            return;
        }

        /// <summary>
        /// Manage Next Turn
        /// 
        /// Decides Who's Turn
        /// Remembers Current Player
        /// 
        /// Starts the Turn
        /// 
        /// </summary>
        public override RoundEnum RoundNextTurn()
        {
            // No characters, game is over..

            // Check if round is over

            // If in Auto Battle pick the next attacker

            // Do the turn..

            return base.RoundNextTurn();
        }

        /// <summary>
        /// Get the Next Player to have a turn
        /// </summary>
        public override PlayerInfoModel GetNextPlayerTurn()
        {
            // Remove the Dead
            RemoveDeadPlayersFromList();

            // Get Next Player
            var PlayerCurrent = GetNextPlayerInList();

            return PlayerCurrent;
        }

        /// <summary>
        /// Remove Dead Players from the List
        /// </summary>
        public override List<PlayerInfoModel> RemoveDeadPlayersFromList()
        {
            return base.RemoveDeadPlayersFromList();
        }

        /// <summary>
        /// Order the Players in Turn Sequence
        /// </summary>
        public override List<PlayerInfoModel> OrderPlayerListByTurnOrder()
        {
            // TODO
            // Order is based by... 
            // Order by Speed (Desending)
            // Then by Highest level (Descending)
            // Then by Highest Experience Points (Descending)
            // Then by Character before MonsterModel (enum assending)
            // Then by Alphabetic on Name (Assending)
            // Then by First in list order (Assending

            EngineSettings.PlayerList = EngineSettings.PlayerList.OrderByDescending(a => a.GetSpeed())
                .ThenByDescending(a => a.Level)
                .ThenByDescending(a => a.ExperienceTotal)
                .ThenByDescending(a => a.PlayerType)
                .ThenBy(a => a.Name)
                .ThenBy(a => a.ListOrder)
                .ToList();

            return EngineSettings.PlayerList;
        }

        /// <summary>
        /// Who is Playing this round?
        /// </summary>
        public override List<PlayerInfoModel> MakePlayerList()
        {
            // Start from a clean list of players

            // Remember the Insert order, used for Sorting

            // Add the Characters

            // Add the Monsters

            return base.MakePlayerList();
        }

        /// <summary>
        /// Get the Information about the Player
        /// </summary>
        public override PlayerInfoModel GetNextPlayerInList()
        {

            //var Defender = EngineSettings.PlayerList
            //    .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
            //    .OrderBy(m => m.CurrentHealth).FirstOrDefault();
            // Walk the list from top to bottom
            // If Player is found, then see if next player exist, if so return that.
            // If not, return first player (looped)

            // If List is empty, return null
            if (EngineSettings.PlayerList.Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster).Count() == 0)
            {
                return null;
            }

            // No current player, so set the first one
            if (EngineSettings.CurrentDefender == null)
            {
                return EngineSettings.PlayerList.Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster).FirstOrDefault();
            }

            // Find current player in the list
            // var index = EngineSettings.PlayerList.FindIndex(m => m.Guid.Equals(EngineSettings.CurrentAttacker.Guid));

            // If at the end of the list, return the first element
            //if (index == EngineSettings.PlayerList.Count() - 1)
            //{
            //    return EngineSettings.PlayerList.FirstOrDefault();
            //}

            // Return the next element
            return EngineSettings.PlayerList
                .Where(m => m.Alive && m.PlayerType == PlayerTypeEnum.Monster)
                .OrderBy(m => m.CurrentHealth).FirstOrDefault();
        }

        /// <summary>
        /// Pickup Items Dropped
        /// </summary>
        public override bool PickupItemsFromPool(PlayerInfoModel character)
        {

            // TODO: Teams, You need to implement your own Logic if not using auto apply

            // I use the same logic for Auto Battle as I do for Manual Battle

            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Swap out the item if it is better
        /// 
        /// Uses Value to determine
        /// </summary>
        public override bool GetItemFromPoolIfBetter(PlayerInfoModel character, ItemLocationEnum setLocation)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Swap the Item the character has for one from the pool
        /// 
        /// Drop the current item back into the Pool
        /// </summary>
        public override ItemModel SwapCharacterItem(PlayerInfoModel character, ItemLocationEnum setLocation, ItemModel PoolItem)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// For all characters in player list, remove their buffs
        /// </summary>
        public override bool RemoveCharacterBuffs()
        {
            return base.RemoveCharacterBuffs();
        }
    }
}