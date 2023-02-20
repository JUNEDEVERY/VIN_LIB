using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VIN_LIB.dll  ;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {


        [TestMethod]
        public void TestMethod_VinNumberLenght_TRUE()
        {
            // проверка на то, что наш вин == 17 символов
            string vin = "2C4GJ453XYR693697";
            Assert.IsTrue(vin.Length == 17);


        }



        [TestMethod]
        public void TestMethod_CHECKVIN_TRUE()
        {
            // проверка на то, что наш вин проходит по регулярке 
            string vin = "2C4GJ453XYR693697";
            bool actual = VIN.CheckVin(vin);
            Assert.IsTrue(actual);
          

        }
        [TestMethod]
        public void TestMethod_CHECKVIN_FALSE()
        {
            // проверка на то, что наш вин не проходит по регулярке 
            string vin = "2C4GJ453XYR693697123"; // добавил больше 17 цифр
            bool actual = VIN.CheckVin(vin);
            Assert.IsFalse(actual);


        }
        [TestMethod]
        public void TestMethod_CHECKVIN_TYPEOF_bool()
        {
            // проверка на то, что наш тип подходит к булл (если стринговый тип возвращается - то тру, иначе фалс)
            string vin = "2C4GJ453XYR693697";
            bool actual = VIN.CheckVin(vin);
            Assert.IsInstanceOfType(actual, typeof(bool));


        }
        [TestMethod]
        public void TestMethod_CHECKVIN_TYPEOF_int()
        {
            // проверка на то, что наш тип НЕ  подходит к булл (если стринговый тип возвращается - то тру, иначе фалс)
            string vin = "2C4GJ453XYR693697";
            bool actual = VIN.CheckVin(vin);
            Assert.IsNotInstanceOfType(actual, typeof(int));


        }


        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_UZH_AMERIKA_TRUE()
        {
            // проверка на то, что вин номер относится к южной америке
            string vin = "8C4GJ453XYR693697";
            string actual = VIN.GetVINCountry(vin);
            Assert.AreEqual(actual, "Южная Америка");

            
        }



        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_SAME_TRUE()
        {
            // проверка на то, что две переменные не ссылаются на один и тот же метод
 
            string vin = "8C4GJ453XYR693697";
            string actual = VIN.GetVINCountry(vin);
            Assert.AreNotSame(vin, actual);
        }
        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_UZH_AMERIKA_False()
        {
            // проверка на то, что вин номер не относится к южной америке
            string vin = "";
            string actual = VIN.GetVINCountry(vin);
            Assert.AreNotEqual(actual, "Южная Америка");


        }

        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_SEVERNAYA_AMERIKA_TRUE()
        {
            // проверка на то, что вин номер относится к северной америке
            string vin = "2C4GJ453XYR693697";
            string actual = VIN.GetVINCountry(vin);
            Assert.AreEqual(actual, "Северная Америка");


        }
        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRYnotVIN_TRUE()
        {
            // проверка на то, что несуществующий вин номер не относится к северной америке
            string vin = "DACADADADA";
            string actual = VIN.GetVINCountry(vin);
            Assert.AreNotEqual(actual, "Северная Америка");


        }
        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_ASIA_TRUE()
        {
            // проверка на то, что вин номер относится относится к азии
            string vin = "JC4GJ453XYR693697";
            string actual = VIN.GetVINCountry(vin);
            Assert.AreEqual(actual, "Азия");


        }
        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_True()
        {
            // проверка на то, что если мы добавим букву о на второе место, а букву о нельзя использовать, то такой страны не будет
            string vin = "2O4GJ453XYR693697";
            string actual = VIN.GetVINCountry(vin);
            Assert.AreEqual(actual, null);


        }
        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_OKEANIA_TRUE()
        {
            // проверка на то, что наш вин относится к континенту океании
            string vin = "7C4GJ453XYR693697";
            string except = VIN.GetVINCountry(vin);
            Assert.AreEqual(except, "Океания");


        }

        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_EUROPE_FALSE()
        {
            // проверка на то, что наш вин не относится к континенту европа
            string vin = "7C4GJ453XYR693697";
            string except = VIN.GetVINCountry(vin);
            Assert.AreNotEqual(except, "Европа");


        }


        [TestMethod]
        public void TestMethod_VINCHECKCOUNTRY_OKEANIA_IsTrue()
        {
            // проверка на то, что наш вин дает тру при том, когда вин == континенту
            string vin = "7C4GJ453XYR693697";
            string except = VIN.GetVINCountry(vin);
            Assert.IsTrue(except == "Океания");


        }









        // сложные
        [TestMethod]
        public void TestMethod_VINCOUNTRY_IsAbsent()
        {
            // проверка на то, что наш вин  дает null при том, когда вин не существует и такая страна не определяется
            string vin = "qw]djaw9odhwqidhqwdhqw[d0qwhd098qw3hbdbqwdbwq9dbqw";
            string except = VIN.GetVINCountry(vin);
            Assert.IsNull(except);


        }



        [TestMethod]
        public void TestMethod_VINCOUNTRY_ISNOTNULL_TRUE()
        {
            // проверка на то, что наш вин  не нулевой
            string vin = "7C4GJ453XYR693697";
            string except = VIN.GetVINCountry(vin);
            Assert.IsNotNull(except);


        }
        [TestMethod]
        public void TestMethod_IsNotNull_NothingException_TRUE()
        {
            // ПРОВЕРКА НА ТО, ЧТО НАШ МЕТОД ЧЕК ВИН НЕ ДАЕТ ЭКСШЕПШН ПРИ НУЛЕВОМ ВИНЕ
            string vin = "";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => VIN.CheckVin(vin)));
        }
        [TestMethod]
        public void TestMethod_IsNotNull_IsTrueVINnumber_NotException()
        {
            // ПРОВЕРКА НА ТО, ЧТО НАШ МЕТОД ЧЕК ВИН НЕ ДАЕТ ЭКСШЕПШН ПРИ НАЛИЧИИ ВИН НОМЕРА
            string vin = "2C4GJ453XYR693697";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => VIN.CheckVin(vin)));
        }

        [TestMethod]
        public void TestMethod_IsNotException_TRUE()
        {
            // ПРОВЕРКА НА ТО, ЧТО НАШ МЕТОД ЧЕК ВИН НЕ ДАЕТ ЭКСШЕПШН ПРИ определнии страны для текущего вин номера 
            string vin = "2C4GJ453XYR693697";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => VIN.GetVINCountry(vin)));
        }

        [TestMethod]
        public void TestMethod_IsNotException_GetVinCountry_TRUE()
        {
            // ПРОВЕРКА НА ТО, ЧТО НАШ МЕТОД ЧЕК ВИН НЕ ДАЕТ ЭКСШЕПШН ПРИ пустом вине определения страны
            string vin = "";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => VIN.GetVINCountry(vin)));
        }

        [TestMethod]
        public void TestMethod_IsAbsentException_CheckVin_TRUE()
        {
            // ПРОВЕРКА НА ТО, ЧТО НАШ МЕТОД ЧЕК ВИН НЕ ДАЕТ ЭКСШЕПШН ПРИ нереально большом вине
            string vin = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => VIN.CheckVin(vin)));
        }

        [TestMethod]
        public void TestMethod_IsAbsentException_CheckVinCountry_TRUE()
        {
            // ПРОВЕРКА НА ТО, ЧТО НАШ МЕТОД ЧЕК ВИН НЕ ДАЕТ ЭКСШЕПШН ПРИ нереально большой несуществущей страны для вин номера
            string vin = "ЫФОВУФЫДЛВФЫЩДВОФЫЩШВФЫЩШВТФЫЩШВТФЫЩШТВЩШФЫВЩШФЫВЩШФЫВЫФВФЩШВРФЩШВРФЩШРВФЩРВФЩШРВЩШЦФРВЩШФРВ";
            Assert.ThrowsException<AssertFailedException>(() => Assert.ThrowsException<SystemException>(() => VIN.GetVINCountry(vin)));
        }
    }
}
