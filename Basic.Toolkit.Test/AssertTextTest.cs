using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Basic.Toolkit;

namespace Basic.Toolkit.Test
{
    /// <summary>
    /// Teste referente a classe AssertText.
    /// </summary>
    [TestClass]
    public class AssertTextTest
    {
        #region Test OK
        [TestMethod]
        public void RemoveCharacter_TestOK1()
        {
            var value = "Basic.Toolkit - V1";
            var retire = " - ";
            var expected = "Basic.ToolkitV1";
            var actual = value.RemoveCharacter(retire);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveCharacter_TestOK2()
        {
            var value = "Basic.Toolkit - V1V1V1V1V1";
            var expected = "Basic.Toolkit11111";
            var actual = value.RemoveCharacter("V", " ", "-");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContainsLetter_TestOK()
        {
            var value = "01010101010101010A01101010101010";
            var actual = value.ContainsLetter();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ContainsNumber_TestOK()
        {
            var value = "ADADFADFASDDOKOKOKAOK-0-KDFADANDMYUKTYUKYOIOOTHDTS";
            var actual = value.ContainsNumber();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void ContainsOnlyNumber_TestOK()
        {
            var value = "11122334455667788990099877665443211112233445566778899009987766544321";
            var actual = value.ContainsOnlyNumber();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsCEP_TestOK()
        {
            var value = "82.113-000";
            var actual = value.IsCEP();
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void IsEmail_TestOK()
        {
            var value1 = "teste@teste.com";
            var value2 = "teste@teste.com.br";
            Assert.IsTrue(value1.IsEmail());
            Assert.IsTrue(value2.IsEmail());
        }

        [TestMethod]
        public void IsUrl_TestOK()
        {
            var value1 = "http://wwww.teste.com";
            var value2 = "https://wwww.teste.com.br";
            var value3 = "ftp://wwww.teste.com.br";
            Assert.IsTrue(value1.IsUrl());
            Assert.IsTrue(value2.IsUrl());
            Assert.IsTrue(value3.IsUrl());
        }

        [TestMethod]
        public void IsFone_TestOK()
        {
            var value1 = "9900-0099";
            var value2 = "(48) 99001-0099";
            Assert.IsTrue(value1.IsFone());
            Assert.IsTrue(value2.IsFone());
        }

        [TestMethod]
        public void IsCpf_TestOK()
        {
            var value1 = "97807382902";
            var value2 = "711.286.276-04";
            Assert.IsTrue(value1.IsCpf());
            Assert.IsTrue(value2.IsCpf());
        }

        [TestMethod]
        public void IsCnpj_TestOK()
        {
            var value1 = "88861728000159";
            var value2 = "30.365.481/0001-08";
            Assert.IsTrue(value1.IsCnpj());
            Assert.IsTrue(value2.IsCnpj());
        }

        [TestMethod]
        public void IsHour_TestOK()
        {
            var value = "12:01";
            var actual = value.IsHour();
            Assert.IsTrue(actual);
        }
        #endregion

        #region Test Fail
        [TestMethod]
        public void RemoveCharacter_TestFail1()
        {
            string value = null;
            var retire = " - ";
            string expected = null;
            var actual = value.RemoveCharacter(retire);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveCharacter_TestFail2()
        {
            var value = string.Empty;
            var expected = string.Empty;
            var actual = value.RemoveCharacter("V", " ", "-");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ContainsLetter_TestFailNull()
        {
            string value = null;
            var actual = value.ContainsLetter();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ContainsNumber_TestFailNull()
        {
            string value = null;
            var actual = value.ContainsNumber();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void ContainsOnlyNumber_TestFailNull()
        {
            string value = null;
            var actual = value.ContainsOnlyNumber();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsCEP_TestFailNull()
        {
            string value = null;
            var actual = value.IsCEP();
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void IsEmail_TestFail()
        {
            string value = null;
            Assert.IsFalse(value.IsEmail());
        }

        [TestMethod]
        public void IsUrl_TestFailNull()
        {
            string value = null;
            Assert.IsFalse(value.IsUrl());
        }

        [TestMethod]
        public void IsUrl_TestFail1()
        {
            var value2 = "teste.com.br";
            Assert.IsFalse(value2.IsUrl());
        }

        [TestMethod]
        public void IsUrl_TestFail2()
        {
            var value = "teste@teste.com.br";
            Assert.IsFalse(value.IsUrl());
        }

        [TestMethod]
        public void IsFone_TestFailNull()
        {
            string value = null;
            Assert.IsFalse(value.IsFone());
        }

        [TestMethod]
        public void IsFone_TestFail()
        {
            string value = "123-1233";
            Assert.IsFalse(value.IsFone());
        }

        [TestMethod]
        public void IsCpf_TestFailNull()
        {
            string value = null;
            Assert.IsFalse(value.IsCpf());
        }

        [TestMethod]
        public void IsCpf_TestFailEmpty()
        {
            string value = string.Empty;
            Assert.IsFalse(value.IsCpf());
        }

        [TestMethod]
        public void IsCpf_TestFailInvalid()
        {
            string value = "123.123.1-44";
            Assert.IsFalse(value.IsCpf());
        }

        [TestMethod]
        public void IsCnpj_TestFailNull()
        {
            string value = null;
            Assert.IsFalse(value.IsCnpj());
        }

        [TestMethod]
        public void IsCnpj_TestFailEmpty()
        {
            string value = string.Empty;
            Assert.IsFalse(value.IsCnpj());
        }

        [TestMethod]
        public void IsCnpj_TestFailInvalid()
        {
            string value = "10487511000102";
            Assert.IsFalse(value.IsCnpj());
        }

        [TestMethod]
        public void IsHour_TestFailNull()
        {
            string value = null;
            Assert.IsFalse(value.IsHour());
        }

        [TestMethod]
        public void IsHour_TestFailEmpty()
        {
            string value = string.Empty;
            Assert.IsFalse(value.IsHour());
        }

        [TestMethod]
        public void IsHour_TestFailInvalid()
        {
            string value = "123";
            Assert.IsFalse(value.IsHour());
        }
        #endregion
    }
}
