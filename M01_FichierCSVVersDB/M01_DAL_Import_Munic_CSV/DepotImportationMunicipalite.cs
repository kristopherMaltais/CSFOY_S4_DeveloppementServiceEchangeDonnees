using M01_Srv_Municipalite;using System.Text.RegularExpressions;

namespace M01_DAL_Import_Munic_CSV
{
    public class DepotImportationMunicipalite : IDepotImportationMunicipalite
    {
        // ** Champs ** //
        private string m_chemin;

        // ** Propriétés ** //
        public List<Municipalite> Municipalites { get; set; }

        // ** Constructeurs ** //
        public DepotImportationMunicipalite(string p_chemin)
        {
            this.Municipalites = new List<Municipalite>();
            this.m_chemin = p_chemin;
        }

        // ** méthodes ** //
        public void MAJMunicipalite(Municipalite p_municipaliteAMettreAJour)
        {
            throw new NotImplementedException();
        }
        public Dictionary<int, Municipalite> ListerMunicipalite()
        {
            int codeGeographique = 0;
            int nomMunicipalite = 1;
            int adresseCourriel = 7;
            int adresseSiteWeb = 8;
            int dateProchaineElection = 20;

            string ligneFichierCsv;
            Dictionary<int, Municipalite> MunicipaliteARetourner = new Dictionary<int, Municipalite>();

            using (StreamReader streamReader = new StreamReader(this.m_chemin))
            {
                streamReader.ReadLine();
                while ((ligneFichierCsv = streamReader.ReadLine()) is not null)
                {
                    string[] ligneFichierCsvSplit = Regex.Split(ligneFichierCsv.Substring(1), "\",\"");

                    Municipalite municipaliteAAjouter = new Municipalite(Convert.ToInt32(ligneFichierCsvSplit[codeGeographique]),
                                                                         ligneFichierCsvSplit[nomMunicipalite],
                                                                         ligneFichierCsvSplit[adresseCourriel],
                                                                         ligneFichierCsvSplit[adresseSiteWeb] == "" ? null : ligneFichierCsvSplit[adresseSiteWeb],
                                                                         ligneFichierCsvSplit[dateProchaineElection] == "" ? null : Convert.ToDateTime(ligneFichierCsvSplit[dateProchaineElection]));
                    MunicipaliteARetourner.Add(municipaliteAAjouter.CodeGeographique, municipaliteAAjouter);
                }
            }

            return MunicipaliteARetourner;
        }
    }
}