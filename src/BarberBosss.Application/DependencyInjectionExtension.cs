using BarberBoss.Application.AutoMapper;
using BarberBoss.Application.UseCases.Billings.Create;
using BarberBoss.Application.UseCases.Billings.Delete;
using BarberBoss.Application.UseCases.Billings.Read;
using BarberBoss.Application.UseCases.Billings.ReadAt;
using BarberBoss.Application.UseCases.Billings.Update;
using Microsoft.Extensions.DependencyInjection;

namespace BarberBoss.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile<BillingMapper>());
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateBillingUseCase, CreateBillingUseCase>();
        services.AddScoped<IReadAtBillingUseCase, ReadAtBillingUseCase>();
        services.AddScoped<IUpdateBillingUseCase, UpdateBillingUseCase>();
        services.AddScoped<IDeleteBillingUseCase, DeleteBillingUseCase>();
        services.AddScoped<IReadBillingUseCase, ReadBillingUseCase>();
    }
}
