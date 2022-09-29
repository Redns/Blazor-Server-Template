using Blazor_Server_Template.Logger;
using MudBlazor;
using MudBlazor.Services;
using ILogger = Blazor_Server_Template.Services.Logger.ILogger;

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
                // Snackbar ����
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
                // ��δ������쳣����ʱ����������ϸ�Ĵ�����Ϣ�� Javascript
                // ��������Ӧ���رգ�������ܱ�©������Ϣ
                option.DetailedErrors = false;
                // JS �����ó�ʱ�¼�����
                option.JSInteropDefaultCallTimeout = TimeSpan.FromSeconds(10);
            });
            builder.Services.AddLogging(logging =>
            {
                // ���Ĭ����־���
                logging.ClearProviders();
            });
            builder.Services.AddSingleton<ILogger>(logger => new Log4netLogger("log4net.config"));


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
            // �󶨶˿ں�
            app.Urls.Add("http://*:16238");

            app.Run();
        }
    }
}