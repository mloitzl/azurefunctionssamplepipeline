using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using mloitzl.demos.functionpipeline.Service;

[assembly: FunctionsStartup(typeof(mloitzl.demos.functionpipeline.Services.Startup))]

namespace mloitzl.demos.functionpipeline.Services
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<ILicenseGenerator, LicenseGenerator>();
        }
    }
}