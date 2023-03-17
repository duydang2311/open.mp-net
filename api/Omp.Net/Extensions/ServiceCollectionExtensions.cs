using Microsoft.Extensions.DependencyInjection;

namespace Omp.Net.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddOmpServices(this IServiceCollection self)
	{
		return self
			.AddSingleton(Core.Instance.PlayerPool)
			.AddSingleton(Core.Instance.GlobalTextDrawPool)
		;
	}
}
