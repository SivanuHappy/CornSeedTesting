using System;
using System.Collections.Generic;
using CornSeedTesting.Models;
using CornSeedTesting.PageObjects;
using QA.Utilities.WebDriverUtils;

namespace CornSeedTesting.PageActions
{
    /*
    Claimant details page actions - Upload document
    */
    public class ClaimantDetailsActions : WebDriverUtil
    {
        private WebElementUtil elementUtils;
        public static List<string> claimantDocId = new List<string>();
        public ClaimantDetailsActions()
        {
            elementUtils = new WebElementUtil();
        }

        public void ClickClaimantID()
        {
            elementUtils.ClickElement(ClaimantSearchPage.ClaimantLink);
        }

        public void ClickDocument()
        {
            elementUtils.ClickElement(ClaimantDetailsPage.Documents);
        }

        public void ClickEditW9Form()
        {
            elementUtils.ClickElement(ClaimantDetailsPage.EditW9);
        }

        public void ClickDMIReview()
        {
            elementUtils.ClickElement(ClaimantDetailsPage.DMIReview);
        }
        public void ClaimantUploadDocument(string docType, string fileType)
        {
            elementUtils.ClickElement(ClaimantDetailsPage.UploadDocument);
            elementUtils.SetVisibilityOfAllElementsWait(ClaimantDetailsPage.DocumentType);
            elementUtils.SelectDropDownByText(ClaimantDetailsPage.DocumentType, docType);
            elementUtils.UploadPDFDocument(ClaimantDetailsPage.ChooseFile, ClaimantDetailsPage.Upload, fileType);
        }

        public List<Document> ReadDocumentGrid()
        {
            List<string> DocData = null;
            List<Document> documents = new List<Document>();
            int row = elementUtils.CountTableRows(ClaimantDetailsPage.DocumentGridRow);
            for(int i=2; i<=row; i++)
            {
                DocData = new List<string>();
                DocData = elementUtils.ReadTableRowData(DocData, ClaimantDetailsPage.DocumentGridCol, ClaimantDetailsPage.GetTableXPathRowForDoc(i), ClaimantDetailsPage.DThirdPart);
                documents.Add(new Document() { DocId = DocData[0], DocType = DocData[1], FileName = DocData[2], Comments = DocData[3], BGReceivedDate = DocData[4], PostMarkDate = DocData[5], DateUploaded = DocData[6], UploadedBy = DocData[7] });
            }
            return documents;          
        }

        //Example = 30835-Claim Form
        public List<string> GetClaimantDocId()
        {            
            List<Document> documents = ReadDocumentGrid();           
            foreach(Document document in documents)
            {
                claimantDocId.Add(document.DocId + "-" + document.DocType);
            }
            return claimantDocId;
        }

        public string ClaimantViewDocument(string DocType, string FileType)
        {     
            elementUtils.SwitchWindow(ClaimantDetailsPage.DocLink);
            string url = WebDriverUtil.GetUrl();
            return url;
        }

        public void PerformDMIReview(string repReasonType, string repDocProvide, string repDocSufficient, string repDocType)
        {
            elementUtils.SelectRadioButtonByText(ClaimantDetailsPage.RepClaimantReason, repReasonType);
            elementUtils.SelectRadioButtonByText(ClaimantDetailsPage.RepClaimantDocument, repDocProvide);
            elementUtils.SelectRadioButtonByText(ClaimantDetailsPage.RepClaimantDocSufficient, repDocSufficient);
            ClickDocument();
            List<string> docId = GetClaimantDocId();
            elementUtils.SelectDropDownByText(ClaimantDetailsPage.RepDMIDocID, docId[0]);
            elementUtils.SelectDropDownByText(ClaimantDetailsPage.RepDMIDocType, repDocType);
            elementUtils.ClickElement(ClaimantDetailsPage.RepApplyEvent);
            elementUtils.SetElementClickableWait(ClaimantDetailsPage.RepApplyEventPopup);
            elementUtils.ClickElement(ClaimantDetailsPage.RepApplyEventPopup);
        }

        public List<Events> ReadEventGrid()
        {
            List<string> EventData = null;
            List<Events> events = new List<Events>();
            int row = 0;
            if (elementUtils.CheckElementExists(ClaimantDetailsPage.EventShowAll))
            {
                elementUtils.SetStaleElementWait(ClaimantDetailsPage.EventShowAll);
                elementUtils.ClickElement(ClaimantDetailsPage.EventShowAll);
                row = elementUtils.CountTableRows(ClaimantDetailsPage.EventDetailGridRow);
                for(int i=2; i<=row; i++)
                {
                    EventData = new List<string>();
                    EventData = elementUtils.ReadTableRowData(EventData, ClaimantDetailsPage.EventDetailGridCol, ClaimantDetailsPage.GetTableXPathRowForEventDetails(i), ClaimantDetailsPage.EThirdPart);
                    events.Add(new Events() { EventDesc = EventData[3], EventDate = DateTime.Parse(EventData[4]) });
                }
                elementUtils.ClickElement(ClaimantDetailsPage.EventGridClose);
                return events;
            }
            else
            {
                row = elementUtils.CountTableRows(ClaimantDetailsPage.EventGridRow);
                for(int i=2; i<row; i++)
                {
                    EventData = new List<string>();
                    EventData = elementUtils.ReadTableRowData(EventData, ClaimantDetailsPage.EventGridCol, ClaimantDetailsPage.GetTableXPathColumnForEvent(i), ClaimantDetailsPage.EThirdPart);
                    events.Add(new Events() { EventDesc = EventData[3], EventDate = DateTime.Parse(EventData[4]), Comments = EventData[5] });
                }
                return events;
            }
        }

        public void FillW9Form(string taxClassification, string taxWithHold, string taxSigned, string w9Signature)
        {
            elementUtils.SelectRadioButtonByText(ClaimantDetailsPage.W9TaxClassification, taxClassification);
            elementUtils.SelectRadioButtonByText(ClaimantDetailsPage.W9TaxWithHolding, taxWithHold);
            elementUtils.SelectRadioButtonByText(ClaimantDetailsPage.W9TaxSigned, taxSigned);
            elementUtils.SendKeys(ClaimantDetailsPage.W9Signature, w9Signature);
            elementUtils.ClickElement(ClaimantDetailsPage.W9Submit);
        }

        public void SwitchToIFrame()
        {
           // elementUtils.SetIFrameWait(ClaimantDetailsPage.W9IFrame);
            elementUtils.GoToiFrame(ClaimantDetailsPage.frameId);
        }
    }
}
