using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Tools;
public interface ICoreModule
{
    void Load(IServiceCollection services);
}
