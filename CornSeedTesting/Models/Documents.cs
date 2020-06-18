using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CornSeedTesting.Models
{
    public class Document : IEquatable<Document>
    {
        public string DocId { get; set; }
        public string DocType { get; set; }
        public string FileName { get; set; }
        public string Comments { get; set; }
        public string BGReceivedDate { get; set; }
        public string PostMarkDate { get; set; }
        public string DateUploaded { get; set; }
        public string UploadedBy { get; set; }
        public override string ToString()
        {
            return DocId + " " + DocType + " " + FileName + " " + Comments + " " + BGReceivedDate + " " + PostMarkDate + " "
                + DateUploaded + " " + UploadedBy;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Acres objAsPart = obj as Acres;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        public bool Equals([AllowNull] Document other)
        {
            throw new NotImplementedException();
        }
    }
}
