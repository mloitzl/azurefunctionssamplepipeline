using System;
using Microsoft.WindowsAzure.Storage.Table;

namespace mloitzl.demos.functionpipeline.Model
{
    public class License : TableEntity
    {
        public string IsssuedTo { get; set; }
        public Guid Id { get; set; }
        public string LicenseData { get; set; }
    }
}