using FemiSQLITE.Services;
using FemiSQLITE.View;
using Microsoft.Extensions.Logging;

namespace FemiSQLITE
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<IItemService, ItemService>();
            //viewmodel
            builder.Services.AddSingleton<ViewModels.ItemListPageViewModel>();
            builder.Services.AddTransient<ViewModels.AddUpdateItemDetailViewModel>();


            //View 
            builder.Services.AddSingleton<Cart>();
            builder.Services.AddSingleton<Profile>();
            builder.Services.AddSingleton<HomeFeminhilo>();
            builder.Services.AddSingleton<ItemListPage>();
            builder.Services.AddTransient<AddUpdateItemDetail>();



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
