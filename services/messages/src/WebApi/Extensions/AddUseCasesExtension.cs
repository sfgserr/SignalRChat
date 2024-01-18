using Application.UseCases.DeleteMessageUseCase;
using Application.UseCases.EditMessage;
using Application.UseCases.GetMessages;
using Application.UseCases.SendMessage;

namespace WebApi.Extensions
{
    public static class AddUseCasesExtension
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IDeleteMessageUseCase, DeleteMessageUseCase>();
            services.Decorate<IDeleteMessageUseCase, DeleteMessageValidationUseCase>();

            services.AddScoped<IEditMessageUseCase, EditMessageUseCase>();
            services.Decorate<IEditMessageUseCase, EditMessageValidationUseCase>();

            services.AddScoped<ISendMessageUseCase, SendMessageUseCase>();
            services.Decorate<ISendMessageUseCase, SendMessageValidationUseCase>();

            services.AddScoped<IGetMessagesUseCase, GetMessagesUseCase>();

            return services;
        }
    }
}
