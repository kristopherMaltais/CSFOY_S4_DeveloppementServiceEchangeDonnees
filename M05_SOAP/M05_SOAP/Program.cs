using M05_Services;
using SoapCore;
using System.ServiceModel;

var builder = WebApplication.CreateBuilder(args);

// INJECTION DES DÉPENDANCES
builder.Services.AddScoped<IOperation, Operation>();
builder.Services.AddSoapCore();

var app = builder.Build();

// CONFIGURATION

app.UseSoapEndpoint<IOperation>("/OperationService.svc", new SoapEncoderOptions());
app.UseSoapEndpoint<IOperation>("/OperationService.asmx", new SoapEncoderOptions());
app.Run();

