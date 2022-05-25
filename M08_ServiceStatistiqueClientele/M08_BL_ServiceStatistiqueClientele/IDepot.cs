namespace M08_Application.Entite
{
    public interface IDepot
    {
        public void CreerAppel(Appel m_appelAAjouter);
        public void MAJAppel(Guid? p_identifiantAppel);
        public List<Appel> ObtenirAppels();
    }
}
