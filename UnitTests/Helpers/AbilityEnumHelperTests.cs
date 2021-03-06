﻿using System;
using System.Linq;

using NUnit.Framework;

using Game.Models;
using Game.Helpers;
using System.Collections.Generic;

namespace UnitTests.Helpers
{
    [TestFixture]
    class AbilityEnumHelperTests
    {
        [Test]
        public void AbilityEnumHelper_GetFullList_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetFullList;

            // Assert
            Assert.AreEqual(10,result.Count());

            // Assert
        }

        [Test]
        public void AbilityEnumHelper_GetListFirefighter_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListFireFighter;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_GetListDoctor_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListDoctor;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_GetListFighter_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListFighter;

            // Assert
            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_GetListTeacher_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListTeacher;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_GetListCollegeStudent_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListCollegeStudent;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_GetListPoliceOfficer_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListPoliceOfficer;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_GetListAthlete_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListAthlete;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_GetListOthers_Should_Pass()
        {
            // Arrange

            // Act
            var result = AbilityEnumHelper.GetListOthers;

            // Assert
            Assert.AreEqual(1, result.Count());
        }

        [Test]
        public void AbilityEnumHelper_ConvertStringToEnum_Should_Pass()
        {
            // Arrange

            var myList = Enum.GetNames(typeof(AbilityEnum)).ToList();

            AbilityEnum myActual;
            AbilityEnum myExpected;

            // Act

            foreach (var item in myList)
            {
                myActual = AbilityEnumHelper.ConvertStringToEnum(item);
                myExpected = (AbilityEnum)Enum.Parse(typeof(AbilityEnum), item);

                // Assert
                Assert.AreEqual(myExpected, myActual, "string: " + item + TestContext.CurrentContext.Test.Name);
            }
        }
    }
}

