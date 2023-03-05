using Microsoft.Extensions.DependencyInjection;

namespace Omp.Net.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddOmpServices(this IServiceCollection self)
	{
		return self
			.AddSingleton(Core.Instance.GetTextDrawFactory())
			.AddSingleton(Core.Instance.GetPlayerFactory())
		;
	}
}
