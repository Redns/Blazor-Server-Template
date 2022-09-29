using MudBlazor;
using MudBlazor.Services;

// TODO Blazor_Server_Template ---> $safeprojectname$
namespace Blazor_Server_Template
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddControllers();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMudServices(config =>
            {
                // Snackbar 配置
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
                config.SnackbarConfiguration.PreventDuplicates = true;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Text;
                config.SnackbarConfiguration.ShowCloseIcon = false;
                config.SnackbarConfiguration.VisibleStateDuration = 1500;
                config.SnackbarConfiguration.HideTransitionDuration = 200;
                config.SnackbarConfiguration.ShowTransitionDuration = 200;
            });
            builder.Services.AddServerSideBlazor(option =>
            {
                // 当未处理的异常产生时，不发送详细的错误信息至 Javascript
                // 生产环境应当关闭，否则可能暴漏程序信息
                option.DetailedErrors = false;
                // JS 互调用超时事件设置
                option.JSInteropDefaultCallTimeout = TimeSpan.FromSeconds(10);
            });
            builder.Services.AddLogging(logging =>
            {
                // 清除默认日志组件
                logging.ClearProviders();
            });


            var app = builder.Build();

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapBlazorHub();
                endpoint.MapControllers();
                endpoint.MapFallbackToPage("/_Host");
            });
            // 绑定端口号
            app.Urls.Add("http://*:16238");

            app.Run();
        }
    }
}