using System;
using System.Collections.Generic;
using System.Text;
using ESD6NL.DriverSystem.BLL.Implementations;
using ESD6NL.DriverSystem.DAL.Interfaces;
using ESD6NL.DriverSystem.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ESD6.NL.DriverSystem.UnitTests
{
    [TestClass]
    public class TranslationServiceTests
    {

        private TranslationService _service;

        public TranslationServiceTests()
        {
            var mock = new Mock<ITranslationRepository>();
            mock.Setup(trans => trans.GetTranslationFromTerm("Test", "ENG"))
                .Returns(new Translation {Language = "ENG",Term= "Test", Translated = "Testing"});
            mock.Setup(trans => trans.GetTranslationFromTerm("Test", "NLD"))
                .Returns(new Translation {Language = "NLD", Term = "Test", Translated = "Uitprobeersel"});
            mock.Setup(trans => trans.Add(It.IsAny<Translation>())).Returns((Translation t) => t);
            _service = new TranslationService(mock.Object);
        }

        [TestMethod]
        public void TranslateTerm_NotInDB_ReturnsTermAsTranslation()
        {
            Assert.AreEqual("aaa", _service.Translate("aaa","NLD"));
        }

        [TestMethod]
        public void TranslateTermDutch_InDb_ReturnsTranslatedTerm()
        {
            Assert.AreEqual("Uitprobeersel", _service.Translate("Test", "NLD"));
        }
    }
}
