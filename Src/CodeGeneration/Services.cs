using Microsoft.VisualStudio.ComponentModelHost;
using Microsoft.VisualStudio.Shell;

namespace Ollon.VisualStudio.CodeGeneration
{
    internal static class Services
    {
        public static IComponentModel ComponentModel => GetService<SComponentModel, IComponentModel>();

        public static TServiceInterface GetService<TService, TServiceInterface>()
        {
            return (TServiceInterface)Package.GetGlobalService(typeof(TService));
        }

        public static TServiceInterface GetComponentModelService<TServiceInterface>() where TServiceInterface : class
        {
            return ComponentModel.GetService<TServiceInterface>();
        }
    }
}
