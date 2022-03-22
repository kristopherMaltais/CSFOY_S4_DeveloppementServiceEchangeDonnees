namespace M02_ReconnaissanceVIsage_LibrairieClasses
{
    public class Face
    {
        // ** Champs ** //

        // ** Propriétés ** //
        public string gender { get; set; }
        public float confidence { get; set; }
        public int y_min { get; set; }
        public int x_min { get; set; }
        public int y_max { get; set; }
        public int x_max { get; set; }

        // ** Constructeurs ** //
        public Face(string p_gender, float p_confidence, int p_yMin, int p_xMin, int p_yMax, int p_xMax )
        {
            this.gender = p_gender;
            this.confidence = p_confidence;
            this.y_min = p_yMin;
            this.x_min = p_xMin;
            this.y_max = p_yMax;
            this.x_max = p_xMax;
        }

        // ** Méthodes ** //
        public override string ToString()
        {
            return $"{this.y_min}   {this.x_min}   {this.y_max}   {this.x_max}";
        }
    }
}