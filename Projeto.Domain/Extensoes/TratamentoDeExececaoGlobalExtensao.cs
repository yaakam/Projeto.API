using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Dominio.Manipuladores;

namespace Projeto.Dominio.Extensoes
{
    public static class TratamentoDeExececaoGlobalExtensao
    {
		public static IServiceCollection AddTratamentoGlobalDeExececao(this IServiceCollection services)
		{
			return services.AddTransient<TratamentoDeExececaoGlobal>();
		}

		public static void UseTratamentoGlobalDeExececao(this IApplicationBuilder app)
		{
			app.UseMiddleware<TratamentoDeExececaoGlobal>();
		}
	}
}
