using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDParser;

namespace SDParserTest
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void Test1()
        {
            ServiceDesc sd = new ServiceDesc(@"http://demo.servicedeskplus.com/");
            int expectedCountAllTasks = 170;
            SdTask expected = new SdTask(16, "New employee joining the organization", "Chris Rooney", "PO-Approver");

            var tasks = sd.GetTasks();
            var count = sd.TasksCount;
            var actuals = tasks.Where(t => t.Id == expected.Id).ToArray();

            Assert.AreEqual(expectedCountAllTasks, count);
            Assert.AreEqual(1, actuals.Length);
            Assert.AreEqual(expected, actuals.FirstOrDefault());
        }
    }
}
