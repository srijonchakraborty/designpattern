using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts.Document
{
    public interface IDocument
    {
        string FileId { get; }
        string DocumentName { get; }
        string FilePath { get; }
        byte[] FileData { get; }
    }
}
