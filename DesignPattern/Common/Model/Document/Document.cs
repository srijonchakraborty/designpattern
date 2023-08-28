using Common.Contracts.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Document
{
    public class Document: IDocument
    {
        public string FileId { get; set; }
        public string DocumentName { get; set; }
        public string FilePath { get; set; }
        public byte[] FileData { get; set; }
    }
}
