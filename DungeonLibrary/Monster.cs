﻿using System;
using System.Collections.Generic;
/*
 * Filename: Monster.cs
 * Author: Gabriel Ramirez
 * Date: 9/23/2023
 * Description: Extends the Character class while adding unique functionality to the Monster object
 */

namespace DungeonLibrary
{
    public class Monster : Character
    {

        private Race _monsterRace;

        public Race MonsterRace 
        {
            get 
            {
                return _monsterRace; 
            } 
            set
            {
                _monsterRace = value;
            }
        }

        
        public Monster() { }
        //Constructor with overload
        public Monster(string name, int hitChance, int block, int maxLife, Race _monsterRace, int initiative, int characterLevel, int characterExp) : base(name, hitChance, block, maxLife, initiative, characterLevel, characterExp)
        {

            MonsterRace = _monsterRace;
            switch (MonsterRace)
            {
                case Race.Human:
                    break;
                case Race.Elf:
                    break;
                case Race.Dwarf:
                    break;
                case Race.Gnome:
                    break;
                case Race.Troll:
                    break;
                case Race.Orc:
                    break;
                case Race.Goblin:
                    break;
                case Race.Demon:
                    break;
                case Race.Dragon:
                    break;
                case Race.Elemental:
                    break;
                case Race.Undead:
                    break;

            }

        }

        public override string ToString()
        {
            return base.ToString() + $"Race: {_monsterRace}"; 
        }
       
       

    }
}
