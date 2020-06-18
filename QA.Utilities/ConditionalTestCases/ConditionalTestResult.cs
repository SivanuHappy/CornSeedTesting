using System;
using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace QA.Utilities.ConditionalTestCases
{
    public class ConditionalTestResult
    {
        public static bool isPass = false;
        public static bool IsTestResultPass()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (TestStatus.Passed == status)
                isPass = true;
            return isPass;
        }
    }
    public class GetTestResult : Attribute, ITestAction
    {
        public ActionTargets Targets { get; private set; }

        public void AfterTest(ITest test)
        {
            if (!ConditionalTestResult.IsTestResultPass())
            {
                Assert.Fail("Test case is failed.");
            }
        }
        public void BeforeTest(ITest test)
        {

        }
    }
    public class RunIfPrevTestIsPass : Attribute, ITestAction
    {
        public ActionTargets Targets { get; private set; }
        public void AfterTest(ITest test)
        {

        }

        public void BeforeTest(ITest test)
        {
            if (!ConditionalTestResult.isPass)
            {
                Assert.Ignore("Previous test case failed");
            }
        }
    }

}
