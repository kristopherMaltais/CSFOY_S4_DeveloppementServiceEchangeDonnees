// See https://aka.ms/new-console-template for more information

using M02_ReconnaissanceVIsage_LibrairieClasses;
string path = "C:\\info\\S4\\CSFOY_S4_DeveloppementServiceEchangeDonnees\\M02_ReconnaissanceVisage\\foule.jpg";

ReconnaissanceVisage.detectFace(path).Wait();
ReconnaissanceVisage.CadrerVisage(ReconnaissanceVisage.Result, path);
