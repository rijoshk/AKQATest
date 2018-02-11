using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AKQAService;
using AKQAService.Controllers;
using AKQAService.Repository;

namespace AKQAService.Tests.Controllers
{
    [TestClass]
    public class APIServiceTest
    {
        private readonly string sAKQASvcControllerName = "AKQAService.Controllers.AKQAServiceController";

        [TestMethod]
        public void Test_AKQAController_Type()
        {
            //Arrange
            var controller = new AKQAServiceController(new NumberConverter());

            //Act
            string sControllerName = controller.GetType().ToString();

            //Assert
            Assert.IsNotNull(sControllerName);
            Assert.AreEqual(sAKQASvcControllerName, sControllerName);
        }

        [TestMethod]
        public void Test_AKQAController_Method_NULL_Input()
        {
            //Arrange
            var controller = new AKQAServiceController(new NumberConverter());

            //Act
            string samount = controller.ConvertAmount("1");

            //Assert
            Assert.IsNotNull(samount);
            //Assert.AreEqual("ONE DOLLAR", samount);
        }

        [TestMethod]
        public void Test_AKQAController_Method_InputType()
        {
            //Arrange
            var controller = new AKQAServiceController(new NumberConverter());

            //Act
            Type type = controller.ConvertAmount("1").GetType();

            //Assert
            Assert.AreEqual(type.ToString(), "System.String");
        }

        [TestMethod]
        public void Test_NumberConverter_Type()
        {
            //Arrange
            var function = new NumberConverter();

            //Act
            string sName = function.ToString();

            //Assert
            Assert.AreEqual(sName, "AKQAService.Repository.NumberConverter");
        }

        [TestMethod]
        public void Test_NumberConverter_OutputType()
        {
            string input = "100"; 

            //Arrange
            var function = new NumberConverter();

            //Act
            string sActual = function.amountToString(input, false);

            //Assert
            Assert.AreEqual(sActual.GetType().ToString(), "System.String");
        }

        [TestMethod]
        public void Test_NumberConverter_OutputIsCapital()
        {
            string input = "0";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sActual = function.amountToString(input, true);

            //Assert
            Assert.AreEqual("ZERO DOLLAR", sActual, false);
        }

        [TestMethod]
        public void Test_NumberConverter_ZeroOutput()
        {
            string input = "0";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sActual = function.amountToString(input, true);

            //Assert
            Assert.AreEqual("ZERO DOLLAR", sActual, true);
        }

        [TestMethod]
        public void Test_NumberConverter_FailingNegative()
        {
            string input = "-10";

            //Arrange
            var function = new NumberConverter();

            //Act
            Exception expExcetion = null;
            try
            {
                string sActual = function.amountToString(input, true);
            }
            catch (Exception ex)
            {
                expExcetion = ex;
            }

            //Assert
            Assert.IsNotNull(expExcetion);
        }

        [TestMethod]
        public void Test_NumberConverter_FailingMaxRange()
        {
            string input = "10000000000";

            //Arrange
            var function = new NumberConverter();

            //Act
            string expExcetion = string.Empty;
            try
            {
                string sActual = function.amountToString(input, true);
            }
            catch (Exception ex)
            {
                expExcetion = ex.Message;
            }

            //Assert
            Assert.IsNotNull(expExcetion, "Value was either too large or too small for an Int32.");
        }

        [TestMethod]
        public void Test_NumberConverter_PassingRange_OnesnTeens()
        {
            string[] onesnTeens = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };

            //Arrange
            var function = new NumberConverter();

            //Act
            for(int i = 0; i < 20; i++)
            {
                string sExpected = function.amountToString(i.ToString(), true);
                string sResult = onesnTeens[i].ToString();
                sResult += (i.ToString().Length > 1) ? " dollars" : " dollar";

                //Assert
                Assert.AreEqual(sExpected, sResult.ToUpper(), false);
            }
        }

        [TestMethod]
        public void Test_NumberConverter_PassingRange_Tens()
        {
            string[] tens = { "Zero", "One", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

            //Arrange
            var function = new NumberConverter();

            //Act
            for (int i = 2; i < 10; i++)
            {
                int n = i * 10;
                string sExpected = function.amountToString(n.ToString(), true);
                string sResult = tens[i].ToString();
                sResult += " dollars";

                //Assert
                Assert.AreEqual(sExpected, sResult.ToUpper(), false);
            }
        }

        [TestMethod]
        public void Test_NumberConverter_Random2DigitTest()
        {
            string input = "12";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "TWELVE DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_Random3DigitTest()
        {
            string input = "123";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "ONE HUNDRED AND TWENTY THREE DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_Random4DigitTest()
        {
            string input = "1234";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "ONE THOUSAND TWO HUNDRED AND THIRTY FOUR DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_Random5DigitTest()
        {
            string input = "12345";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "TWELVE THOUSAND THREE HUNDRED AND FORTY FIVE DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_Random6DigitTest()
        {
            string input = "123456";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "ONE HUNDRED AND TWENTY THREE THOUSAND FOUR HUNDRED AND FIFTY SIX DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_Random7DigitTest()
        {
            string input = "1234567";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "ONE MILLION TWO HUNDRED AND THIRTY FOUR THOUSAND FIVE HUNDRED AND SIXTY SEVEN DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_Random8DigitTest()
        {
            string input = "12345678";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "TWELVE MILLION THREE HUNDRED AND FORTY FIVE THOUSAND SIX HUNDRED AND SEVENTY EIGHT DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_Random9DigitTest()
        {
            string input = "123456789";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "ONE HUNDRED AND TWENTY THREE MILLION FOUR HUNDRED AND FIFTY SIX THOUSAND SEVEN HUNDRED AND EIGHTY NINE DOLLARS", false);
        }
        
        [TestMethod]
        public void Test_NumberConverter_Random10DigitTest()
        {
            string input = "1234567890";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "ONE BILLION TWO HUNDRED AND THIRTY FOUR MILLION FIVE HUNDRED AND SIXTY SEVEN THOUSAND EIGHT HUNDRED AND NINETY DOLLARS", false);
        }

        [TestMethod]
        public void Test_NumberConverter_4PlaceDecimal()
        {
            string input = "123.5678";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "ONE HUNDRED AND TWENTY THREE DOLLARS AND FIFTY SIX CENTS", false);
        }

        [TestMethod]
        public void Test_NumberConverter24PlaceDecimal()
        {
            string input = "999999.99";

            //Arrange
            var function = new NumberConverter();

            //Act
            string sExpected = function.amountToString(input, true);

            //Assert
            Assert.AreEqual(sExpected, "NINE HUNDRED AND NINETY NINE THOUSAND NINE HUNDRED AND NINETY NINE DOLLARS AND NINETY NINE CENTS", false);
        }
    }
}
