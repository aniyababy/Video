using System.Text;

using FreeRedis;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

using Serilog;
using Serilog.Events;

using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

using Video.Application;
using Video.EntityFrameworkCore;
using Video.HttpApi.Host.Filters;
using Video.HttpApi.Host.Options;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
    .ReadFrom.Configuration(new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRNMENT") ?? "Production"}.json", optional: true).Build())//���ݻ�����������ָ������ 
    .Enrich.FromLogContext()
    .WriteTo.Async(c => c.File(Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "/log/", "log"),
    rollingInterval:RollingInterval.Day))//д����־���ļ�
    .WriteTo.Async(c => c.Console())
    .CreateLogger();

var builder = WebApplication.CreateBuilder(new WebApplicationOptions()
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory
});

builder.Host.UseSerilog();
 

#region Swagger
builder.Services.AddSwaggerGen(delegate (SwaggerGenOptions option)
{
    option.SwaggerDoc("v1.0", new OpenApiInfo
    {
        Version = "v1.0",//�汾
        Title = "Video Api �ĵ�",//����
        Description = "Video Api �ĵ�",//����
        Contact = new OpenApiContact
        {
            Name = "Aniya",//����
            Email = "1224278459@qq.com",//����
            Url = new Uri("https://github.com/aniyababy?tab=repositories")
        }
    });

    //����xml�ĵ� ��ʾswagger��ע��
    string[] files = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");//��ȡapi�ĵ�
    string[] array = files;
    foreach(string filePath in array)
    {
        option.IncludeXmlComments(filePath,includeControllerXmlComments:true);
    }

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id="Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            Array.Empty<string>()
        }
    });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value,Format:Bearer{token}",
        Name="Authorization",
        In =ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
});
#endregion

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IHttpContextAccessor,HttpContextAccessor>();

builder.Services.AddVideoApplication();
//��ӹ�����
builder.Services.AddMvcCore(options =>
{
    options.Filters.Add<ExceptionFilter>();
    options.Filters.Add<ResponseFilter>();
});

#region Options
var configuration = builder.Services.BuildServiceProvider().GetRequiredService<IConfiguration>();
var jwtsection = configuration.GetSection(nameof(JWTOptions));
builder.Services.Configure<JWTOptions>(jwtsection);

//var fileOptions = configuration.GetSection(nameof(VideoFileOptions));
//builder.Services.Configure<VideoFileOptions>(fileOptions);

#endregion
var jwt = jwtsection.Get<JWTOptions>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(option =>
    {
        option.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer= true,//�Ƿ��������ڼ���֤ǩ����
            ValidateAudience = true,//�Ƿ���֤������
            ValidateLifetime = true,//�Ƿ���֤ʧЧʱ��
            ValidateIssuerSigningKey = true,//�Ƿ���֤ǩ��
            ValidAudience = jwt.Audience,//������
            ValidIssuer=jwt.Issuer,//ǩ���ߣ�ǩ����Token����
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey!))//��Կ
        };
    });
//ע��redis
builder.Services.AddSingleton(new RedisClient(configuration["RedisConnection"]));
//ע��efcore����
builder.Services.AddVideoEntityFrameworkCore();


var app = builder.Build();


// Set up custom content types - associating file extension to MIME type
var provider = new FileExtensionContentTypeProvider();
// Add new mappings
provider.Mappings[".exe"] = "application/octet-stream";
app.UseStaticFiles(new StaticFileOptions
{
    ContentTypeProvider = provider
});
#region Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Video Web Api");
    c.DocExpansion(DocExpansion.None);
    c.DefaultModelExpandDepth(-1);
    c.RoutePrefix = string.Empty;
});
#endregion
app.UseAuthentication();//��֤
app.UseAuthorization();//��Ȩ



app.MapControllers();
app.Run();
