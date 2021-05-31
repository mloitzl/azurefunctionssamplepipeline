using System;
using mloitzl.demos.functionpipeline.Model;

namespace mloitzl.demos.functionpipeline.Service
{
    public class LicenseGenerator : ILicenseGenerator
    {
        public License Generate(string owner)
        {
            var id = Guid.NewGuid();
            return new License
            {
                Id = id,
                IsssuedTo = owner,
                RowKey = id.ToString(),
                PartitionKey = "active",
                LicenseData = Convert.ToBase64String(
                    System.Text.Encoding.Unicode.GetBytes(
                        id.ToString()))
            };
        }
    }
}