using Common.Contracts.Document;
using Common.Model.Document;
using ProxyPattern.Contracts.VirtualProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
                var fileData = cachedDocument == null ? new byte[1] : GetFileData(cachedDocument);
                return fileData;
            }
        }
       
        private byte[] GetFileData(IDocument document)
        {
            byte[] fileData;
            if (IsFileDataExists(document))
            {
                fileData = document.FileData;
            }
            else
            {
                fileData = SetFileData(document);
            }
            return fileData;
        }

        private byte[] SetFileData(IDocument document)
        {
            byte[] fileData;
            var file = document as Common.Model.Document.Document;
            if (file != null)
            {
                file.FileData = new byte[400];
                MemoryCache.Default.Remove(documentCacheKey);
               
                MemoryCache.Default.Add(documentCacheKey, document, DateTimeOffset.Now.AddMinutes(30));

                if (IsDocumentExists())
                {
                    //Just for check after updating cache is working or not.
                    var FullCachedDocument = GetCachedDocument();
                }
            }
            fileData = file.FileData;
            return fileData;
        }

        private bool IsFileDataExists(IDocument document)
        {
            var file = document as Common.Model.Document.Document;
            return file != null && file.FileData != null && file.FileData.Length > 0;
        }
        private IDocument? GetCachedDocument()
        {
            IDocument? documentcachedDocument = null;
            if (IsDocumentExists())
            {
                documentcachedDocument = (IDocument)MemoryCache.Default.Get(documentCacheKey);
            }
            else
            {
                SetDocumentIntoCache();
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
        public bool IsDocumentExists()
        {
            return MemoryCache.Default.Contains(documentCacheKey) && MemoryCache.Default.Get(documentCacheKey) is IDocument;
        }
    }
}
