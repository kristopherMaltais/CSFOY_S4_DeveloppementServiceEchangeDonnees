// See https://aka.ms/new-console-template for more information

using M03_ServicesSOAP;
using SoapCore;
using System.ServiceModel;
using System.ServiceModel.Channels;


Console.ReadLine();

Binding binding = new BasicHttpBinding();

EndpointAddress endpoint = new EndpointAddress(new Uri("http://localhost:5267/MunicipaliteService.svc"));
ChannelFactory<IMunicipaliteService> channelFactory = new ChannelFactory<IMunicipaliteService>(binding, endpoint);
IMunicipaliteService municipaliteService = channelFactory.CreateChannel();


MunicipaliteSOAPDTO municipaliteTrouvee = municipaliteService.ChercherMunicipaliteParCodeGeographique(1023);

Console.WriteLine(municipaliteTrouvee.NomMunicipalite);

Console.ReadLine();