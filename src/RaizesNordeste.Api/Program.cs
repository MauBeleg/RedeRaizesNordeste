using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RaizesNordeste.Api.DTOs;
using RaizesNordeste.Api.Middlewares;
using RaizesNordeste.Application.Gateways;
using RaizesNordeste.Application.Repositories;
using RaizesNordeste.Application.Security;
using RaizesNordeste.Application.Services;
using RaizesNordeste.Application.Servicos;
using RaizesNordeste.Infrastructure.Gateways;
using RaizesNordeste.Infrastructure.Persistence;
using RaizesNordeste.Infrastructure.Repositories;
using RaizesNordeste.Infrastructure.Security;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{ //define atributos de token
    var chaveJwt = builder.Configuration["Jwt:Chave"];
    var issuer = builder.Configuration["Jwt:Issuer"];
    var audience = builder.Configuration["Jwt:Audience"];

    var chave = new SymmetricSecurityKey(
    Convert.FromBase64String(chaveJwt!)
    );


    options.TokenValidationParameters = new TokenValidationParameters //define validações do token
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = issuer,
        ValidAudience = audience,
        IssuerSigningKey = chave
    };


    options.Events = new JwtBearerEvents //define eventos que podem ocorrer por conta de não validade de token ou não acesso
    {
        OnChallenge = async context =>
        {
            context.HandleResponse();

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            context.Response.ContentType = "application/json";

            var erro = new ErroRespostaDTO
            {
                Status = 401,
                Erro = "Não autenticado",
                Mensagem = "Autenticação necessária para acessar este recurso"
            };

            await context.Response.WriteAsJsonAsync(erro);
        },

        OnForbidden = async context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;

            context.Response.ContentType = "application/json";

            var erro = new ErroRespostaDTO
            {
                Status = 403,
                Erro = "Acesso negado",
                Mensagem = "Usuário não possui permissão para acessar este recurso"
            };

            await context.Response.WriteAsJsonAsync(erro);
        }
    };

});

builder.Services.AddAuthorization();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ISenhaHasher, SenhaHasher>();
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUnidadeRepository, UnidadeRepository>();
builder.Services.AddScoped<UnidadeService>();
builder.Services.AddScoped<ICardapioRepository, CardapioRepository>();
builder.Services.AddScoped<CardapioService>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<EstoqueService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IPagamentoGateway, PagamentoMockGateway>();
builder.Services.AddScoped<PedidoStatusService>();
builder.Services.AddScoped<IPagamentoRepository, PagamentoRepository>();
builder.Services.AddScoped<PagamentoService>();
builder.Services.AddScoped<IAuditoriaRepository, AuditoriaRepository>();
builder.Services.AddScoped<AuditoriaService>();
builder.Services.AddScoped<IConsentimentoRepository, ConsentimentoRepository>();
builder.Services.AddScoped<ConsentimentoService>();

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("Jwt"));

var app = builder.Build();
app.UseMiddleware<TratamentoErrosMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();