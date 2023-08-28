using Common.Contracts.Document;
using Common.Model.Document;
using ProxyPattern.Contracts.VirtualProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPattern.Implementation.VirtualProxy
{
    public class DocumentVirtualProxyMemoryCache : IDocumentVirtualProxyMemoryCache
    {
        private readonly Func<IDocument> documentInitializer;
        private readonly string documentCacheKey;

        public DocumentVirtualProxyMemoryCache(Func<IDocument> initializer, string documentCacheKey)
        {
            documentInitializer = initializer;
            this.documentCacheKey = documentCacheKey;
        }
        public string DocumentName
        {
            get
            {
                var cachedDocument = GetCachedDocument();
                return cachedDocument?.DocumentName ?? string.Empty;
            }
        }
        public string FilePath
        {
            get
            {
                var cachedDocument = GetCachedDocument();
                return cachedDocument?.FilePath ?? string.Empty;
            }
        }
        public string FileId
        {
            get
            {
                var cachedDocument = GetCachedDocument();
                return cachedDocument?.FileId ?? string.Empty;
            }
        }
        public byte[] FileData
        {
            get
            {
                var cachedDocument = GetCachedDocument();
                return cachedDocument?.FileData?? new byte[0];
            }
        }
        public bool IsDocumentExists()
        {
            return MemoryCache.Default.Contains(documentCacheKey) && MemoryCache.Default.Get(documentCacheKey) is IDocument;
        }
        private IDocument? GetCachedDocument()
        {
            SetDocumentIntoCache();

            IDocument? documentcachedDocument = null;
            if (IsDocumentExists())
            {
                documentcachedDocument = (IDocument)MemoryCache.Default.Get(documentCacheKey);
            }
            return documentcachedDocument;
        }
        private void SetDocumentIntoCache()
        {
            if ((MemoryCache.Default.Get(documentCacheKey) is not IDocument cachedDocument))
            {
                cachedDocument = documentInitializer.Invoke();
                MemoryCache.Default.Add(documentCacheKey, cachedDocument, DateTimeOffset.Now.AddMinutes(30));
            }
        }
    }
}
