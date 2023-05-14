using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1;


namespace Test {
    public class Tests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void CalculateTest() {
            float a = 12f;
            float b = 6f;
            float result = a * b;
            Assert.True(Calculator.calculateMultiplication(a, b) == result);
        }
    }
}