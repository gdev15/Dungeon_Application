using Xunit.Sdk;
using DungeonLibrary;
namespace TestProject
{
    public class UnitTest1
    {
        //Testing for Troll Class Override CalcDamage
        //Checking to make sure that if the DamageBuff is > than the MaxDamage
        //If it does the value should never go over the max damage
   
        [Fact]
        public void TestTrollCalcDamage()
        {
            //Arrange
            Troll troll = new Troll();

            troll.MinDamage = 0;
            troll.MaxDamage = 6;
            troll.DamageBuff = 10;
            int expected = 6;

            //Act
            int actual = troll.CalcDamage();
            //Assert
            Assert.Equal(expected, actual);
        }

        //Testing for Undead Class Override HitChance()
        //Check ensures the HitBuff adds to the HitChance
        [Fact]
        public void TestUndeadCalcHitChance()
        {
            //Arrange
            Undead undead = new();
            undead.HitChance = 50;
            undead.HitBuff = 50;
            int expected = 100;
            //Act
            int actual = undead.CalcHitChance();
            //Assert
            Assert.Equal(expected, actual);
        }

        //Testing for Goblin Class Override HitChance()       
        [Fact]
        public void TestGoblinCalcHitChance()
        {
            //Arrange
            Goblin goblin = new();
            goblin.HitChance = 50;
            goblin.HitBuff = 21;
            int expected = 71;
            //Act
            int actual = goblin.CalcHitChance();
            //Assert
            Assert.Equal(expected, actual);
        }
        //Dragon attack test to make sure the dragon will dmg for a min of 6
        //If the roll is between 1 - 5, the dragon will deal 6 damage
        [Fact]
        public void TestDragonCalcDamage()
        {
            //Arrange
            Dragon dragon = new Dragon();

            dragon.MinDamage = 1;
            dragon.MaxDamage = 6;
            dragon.DamageBuff = 0;
            int expected = 6;

            //Act
            int actual = dragon.CalcDamage();
            //Assert
            Assert.Equal(expected, actual);
        }

        //Demon test for the initiatve bonus
        [Fact]
        public void TestDemonCalcInitiative()
        {
            //Arrange
            Demon demon = new();
            demon.Initiative = 5;
            demon.InitiativeBonus = 7;
            int expected = 12;
            //Act
            int actual = demon.CalcInitiative();
            //Assert
            Assert.Equal(expected, actual);

        }
       
    }
}