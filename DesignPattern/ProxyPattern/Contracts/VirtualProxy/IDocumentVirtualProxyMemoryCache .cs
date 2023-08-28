using Common.Contracts.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Contracts.VirtualProxy
{
    public interface IDocumentVirtualProxyMemoryCache :IDocument
    {
        bool IsDocumentExists();
    }
}
