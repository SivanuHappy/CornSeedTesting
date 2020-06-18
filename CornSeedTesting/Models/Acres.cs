using System;
using System.Collections.Generic;
using NUnit.Framework;
namespace CornSeedTesting.Models
{
    public class Acres : IEquatable<Acres>
    {
        public string Source { get; set; }
        public string Relevance { get; set; }
        public string FarmNumber { get; set; }
        public string TractNumber { get; set; }
        public string FieldNumber { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string FailedAcreage { get; set; }
        public string SiloAcreage { get; set; }
        public string MarketingYear { get; set; }
        public string PlantingPrimCode { get; set; }
        public string CornAcreage { get; set; }
        public string SharePercentage { get; set; }
        public string TotalSharePercentage { get; set; }
        public string AdjSharePercentage { get; set; }
        public string LinkedClaimantId { get; set; }

        public override string ToString()
        {
            return Source + " " + Relevance + " " +
                   MarketingYear + " " + FarmNumber + " " + TractNumber + " " + FieldNumber + " " +
                   State + " " + County + " " +
                   CornAcreage + " " + FailedAcreage + " " + SiloAcreage + " " +
                   PlantingPrimCode + " " + SharePercentage + " " + TotalSharePercentage + " " + AdjSharePercentage + " " + LinkedClaimantId;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Acres objAsPart = obj as Acres;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public int SortByNameAscending(string name1, string name2)
        {

            return name1.CompareTo(name2);
        }

        public int CompareTo(Acres comparePart)
        {
            // A null value means that this object is greater.
            if (comparePart == null)
                return 1;

            else
                return this.MarketingYear.CompareTo(comparePart.MarketingYear);
        }

        public bool Equals(Acres other)
        {
            if (other == null) return false;
            return (this.FarmNumber.Equals(other.FarmNumber));
        }

        public void FarmAcresAreSame(List<Acres> acre1, List<Acres> acre2)
        {
            bool isSame = false;
            int size1 = acre1.Count;
            for (int i = 0; i < size1; i++)
            {
                try
                {
                    if (acre1[i].FarmNumber == acre2[i].FarmNumber)
                        isSame = true;
                    Assert.IsTrue(isSame);
                    Console.WriteLine("{0} - {1} acre of farm number {2} matches with table data", acre1[i].Source, acre1[i].MarketingYear, acre1[i].FarmNumber);
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} - {1} acre of farm number {2} does not match with table data", acre1[i].Source, acre1[i].MarketingYear, acre1[i].FarmNumber);
                }
            }
        }

        public void SharePercentageAreSame(List<Acres> acre1, List<Acres> acre2)
        {
            int size1 = acre1.Count;
            for (int i = 0; i < size1; i++)
            {
                if (acre1[i].SharePercentage == acre2[i].SharePercentage)
                    Console.WriteLine("{0} - {1} acre of share percentage {2} matches with table data", acre1[i].Source, acre1[i].MarketingYear, acre1[i].SharePercentage);
                else
                    Console.WriteLine("{0} - {1} acre of share percentage {2} does not match with table data", acre1[i].Source, acre1[i].MarketingYear, acre1[i].SharePercentage);
            }
        }

        //Assert.IsTrue(isSame);
        //        if (acre1[i].TractNumber == acre2[i].TractNumber)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].FieldNumber == acre2[i].FieldNumber)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].MarketingYear == acre2[i].MarketingYear)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].PlantingPrimCode == acre2[i].PlantingPrimCode)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].CornAcreage == acre2[i].CornAcreage)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].SharePercentage == acre2[i].SharePercentage)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].TotalSharePercentage == acre2[i].TotalSharePercentage)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].AdjSharePercentage == acre2[i].AdjSharePercentage)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
        //        if (acre1[i].LinkedClaimantId == acre2[i].LinkedClaimantId)
        //            isSame = true;
        //        Assert.IsTrue(isSame);
    }
}
