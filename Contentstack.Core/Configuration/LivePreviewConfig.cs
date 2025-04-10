﻿using Newtonsoft.Json.Linq;

namespace Contentstack.Core.Configuration
{
    public class LivePreviewConfig
    {
        public string ManagementToken { get; set; }
        public string PreviewToken { get; set; }
        public bool Enable { get; set; }
        public string Host { get; set; }
        internal string LivePreview { get; set; }
        internal string ContentTypeUID { get; set; }
        internal string EntryUID { get; set; }
        internal JObject PreviewResponse { get; set; }
        public string ReleaseId {get; set;}
        public string PreviewTimestamp {get; set;}
    }
}
