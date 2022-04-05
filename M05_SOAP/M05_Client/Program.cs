// See https://aka.ms/new-console-template for more information
using M05_Services;
using SoapCore;
using System.ServiceModel;
using System.ServiceModel.Channels;

Console.ReadLine();
Binding binding = new BasicHttpBinding();

EndpointAddress endpoint = new EndpointAddress(new Uri("http://localhost:5109/OperationService.svc"));
ChannelFactory<IOperation> channelFactory = new ChannelFactory<IOperation>(binding, endpoint);
IOperation operationService = channelFactory.CreateChannel();

float nombre = operationService.Addition(2, 4);

Console.WriteLine(nombre);
Console.ReadLine();