using mloitzl.demos.functionpipeline.Model;

namespace mloitzl.demos.functionpipeline.Service
{
    public interface ILicenseGenerator
    {
        License Generate(string owner);
    }
}