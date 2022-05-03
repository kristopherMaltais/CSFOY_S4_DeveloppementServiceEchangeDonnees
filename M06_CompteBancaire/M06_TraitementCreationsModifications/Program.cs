// See https://aka.ms/new-console-template for more information


using M06_BL_CompteBancaire;
using M06_DAL_CompteBancaire;
using M06_TraitementCreationsModifications;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

TraitementFilMessage traitementFilMessage = new TraitementFilMessage();
traitementFilMessage.EcouterFilMessage();
