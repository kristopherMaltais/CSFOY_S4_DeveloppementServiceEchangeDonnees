using M01_Srv_Municipalite;

namespace M01_DAL_Import_Munic_JSON
{
    public class Record
    {
        public int Mcode { get; set; }
        public string Munnom { get; set; }
        public string Mcourriel { get; set; }
        public string Mweb { get; set; }
        public DateTime? Datelec { get; set; }

        public Municipalite VersEntite()
        {
            Municipalite municipaliteCree = new Municipalite(this.Mcode,
                                                             this.Munnom,
                                                             this.Mcourriel,
                                                             this.Mweb == "" ? null : this.Mweb,
                                                             this.Datelec);

            return municipaliteCree;
        }
    }
}