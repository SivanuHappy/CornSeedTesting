using QA.Utilities.WebDriverUtils;
using CornSeedTesting.PageObjects;
using OpenQA.Selenium;

namespace CornSeedTesting.PageActions
{
    public class ReviewDetailsEGActions
    {
        WebElementUtil elementUtils;
        public ReviewDetailsEGActions()
        {
            elementUtils = new WebElementUtil();
        }
        public void FacilityReview(string claimType, string q2comment, string q2answer)
        {
            int size = elementUtils.CountTableRows(ReviewDetailsEGPage.FacilityGridRow);
            elementUtils.ClickElement(ReviewDetailsEGPage.DocAction);
            for(int i=2; i<size; i++)
            {
                elementUtils.ClickElement(ReviewDetailsEGPage.GetFacilityAction(i));
                elementUtils.ClickElement(ReviewDetailsEGPage.FacilityQ2BullsEye);
                elementUtils.SendKeys(ReviewDetailsEGPage.FacilityQ2Comment, q2comment);
                elementUtils.SelectRadioButtonByText(ReviewDetailsEGPage.FacilityQ2, q2answer);
            }           
        }

        public void ClickDocumentForBullsEye()
        {
            elementUtils.ClickElement(ReviewDetailsEGPage.DocAction);
        }
    }
}
