using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using QA.Utilities.WebDriverUtils;

namespace QA.Utilities.ConditionalTestCases
{
    public class ConditionalTestCase
    {
        public static bool IsWebsiteIsUp()
        {
            bool isUp = false;
            if (WebDriverUtil.GetTitle().Contains("Login") || WebDriverUtil.GetTitle().Contains("Testing"))
                isUp = true;
            return isUp;
        }
    }

    public class RunIfTheApplicationIsUp : Attribute, ITestAction
    {
        public ActionTargets Targets { get; private set; }

        public void AfterTest(ITest test)
        {
        }

        public void BeforeTest(ITest test)
        {
            if (!ConditionalTestCase.IsWebsiteIsUp())
            {
                Assert.Ignore("Website may be  down.");
            }
        }
    }
}
