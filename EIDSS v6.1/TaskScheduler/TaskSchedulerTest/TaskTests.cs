using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskScheduler;
using Microsoft.Win32.TaskScheduler;

namespace TaskSchedulerTest
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void CreateTest()
        {
            Task task = TaskWrapper.Create("testTask", "notepad.exe", null, null, DateTime.Now, 1);
            Assert.IsNotNull(task);
            Task found = TaskWrapper.Find("testTask");
            Assert.IsNotNull(found);
            found.Run();
            if (found.State == TaskState.Running)
                found.Stop();
            TaskWrapper.Delete("testTask");
            found = TaskWrapper.Find("testTask");
            Assert.IsNull(found);

        }
        [TestMethod]
        public void CreateDailyTest()
        {
            Task task = TaskWrapper.CreateDaily("testDailyTask", "notepad.exe", null, null, DateTime.Now.TimeOfDay, 1);
            Assert.IsNotNull(task);
            Task found = TaskWrapper.Find("testDailyTask");
            Assert.IsNotNull(found);
            found.Run();
            if (found.State == TaskState.Running)
                found.Stop();
            TaskWrapper.Delete("testDailyTask");
            found = TaskWrapper.Find("testDailyTask");
            Assert.IsNull(found);

        }
        [TestMethod]
        public void CreateWeeklyTest()
        {
            Task task = TaskWrapper.CreateWeekly("testWeeklyTask", "notepad.exe", null, null, DateTime.Now, 
                (int)(DaysOfTheWeek.Monday | DaysOfTheWeek.Tuesday),
                DateTime.Now.TimeOfDay, 
                1);
            Assert.IsNotNull(task);
            Task found = TaskWrapper.Find("testWeeklyTask");
            Assert.IsNotNull(found);
            found.Run();
            if (found.State == TaskState.Running)
                found.Stop();
            TaskWrapper.Delete("testWeeklyTask");
            found = TaskWrapper.Find("testWeeklyTask");
            Assert.IsNull(found);

        }
    }
}
