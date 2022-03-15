using M01_Srv_Municipalite;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace M01_testsUnitaires_TransfertMunicipalite
{
    public class UnitTest1
    {
        [Fact]
        public void constructeur_PreconditionDepotSourceEstNull_NullException()
        {
            // Arrange
            IDepotImportationMunicipalite depotSource = null;
            Mock<IDepotMunicipalite> mockDepotDestination = new Mock<IDepotMunicipalite>();

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(depotSource, mockDepotDestination.Object); });
        }
        [Fact]
        public void constructeur_PreconditionDepotDestinatiomEstNull_NullException()
        {
            // Arrange
            Mock<IDepotImportationMunicipalite> mockDepotSource = new Mock<IDepotImportationMunicipalite>();
            IDepotMunicipalite DepotDestination = null;

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => { TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockDepotSource.Object, DepotDestination); });
        }
        [Fact]
        public void Executer_EnregistrementPresentUniquementDansSource_AjouterMunicipalite()
        {
            // Arrange

            Municipalite municipalite = new Municipalite(10, "alma", "alma@hotmail.ca", "alma.com", new System.DateTime(2020, 08, 24));
            Dictionary<int, Municipalite> municipaliteSource = new Dictionary<int, Municipalite>();
            municipaliteSource.Add(10, municipalite);
            Mock<IDepotImportationMunicipalite> mockDepotCSV = new Mock<IDepotImportationMunicipalite>();
            mockDepotCSV.Setup(depot => depot.ListerMunicipalite()).Returns(municipaliteSource);

            Dictionary<int, Municipalite> municipaliteDestination = new Dictionary<int, Municipalite>();
            Mock<IDepotMunicipalite> mockDepotSQL = new Mock<IDepotMunicipalite>();
            mockDepotSQL.Setup(depot => depot.ListerMunicipalite()).Returns(municipaliteDestination);

            // Act
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockDepotCSV.Object, mockDepotSQL.Object);
            traitement.Executer();

            // Assert
            mockDepotCSV.Verify(depot => depot.ListerMunicipalite(), Times.Once);
            mockDepotCSV.VerifyNoOtherCalls();

            mockDepotSQL.Verify(depot => depot.AjouterMunicipalite(It.IsAny<Municipalite>()), Times.Once);
            mockDepotSQL.Verify(depot => depot.ListerMunicipalite(), Times.Once);
            mockDepotSQL.VerifyNoOtherCalls();
        }
        [Fact]
        public void Executer_EnregistrementPresentDansDeuxDepot_MiseAJour()
        {
            // Arrange

            Municipalite municipalite1 = new Municipalite(10, "alma", "alma@hotmail.ca", "alma.com", new System.DateTime(2020, 08, 24));
            Dictionary<int, Municipalite> municipaliteSource = new Dictionary<int, Municipalite>();
            municipaliteSource.Add(10, municipalite1);
            Mock<IDepotImportationMunicipalite> mockDepotCSV = new Mock<IDepotImportationMunicipalite>();
            mockDepotCSV.Setup(depot => depot.ListerMunicipalite()).Returns(municipaliteSource);

            Municipalite municipalite2 = new Municipalite(10, "alma", "alma_belleRegion@hotmail.ca", "alma.com", new System.DateTime(2020, 08, 24));
            Dictionary<int, Municipalite> municipaliteDestination = new Dictionary<int, Municipalite>();
            municipaliteDestination.Add(10, municipalite2);
            Mock<IDepotMunicipalite> mockDepotSQL = new Mock<IDepotMunicipalite>();
            mockDepotSQL.Setup(depot => depot.ListerMunicipalite()).Returns(municipaliteDestination);

            // Act
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockDepotCSV.Object, mockDepotSQL.Object);
            traitement.Executer();

            // Assert
            mockDepotCSV.Verify(depot => depot.ListerMunicipalite(), Times.Once);
            mockDepotCSV.VerifyNoOtherCalls();

            mockDepotSQL.Verify(depot => depot.MAJMunicipalite(It.IsAny<Municipalite>()), Times.Once);
            mockDepotSQL.Verify(depot => depot.ListerMunicipalite(), Times.Once);
            mockDepotSQL.VerifyNoOtherCalls();
        }
        [Fact]
        public void Executer_EnregistrementPresentUniquementDansDestination_MiseAJour()
        {
            // Arrange

            Dictionary<int, Municipalite> municipaliteSource = new Dictionary<int, Municipalite>();
            Mock<IDepotImportationMunicipalite> mockDepotCSV = new Mock<IDepotImportationMunicipalite>();
            mockDepotCSV.Setup(depot => depot.ListerMunicipalite()).Returns(municipaliteSource);

            Municipalite municipalite2 = new Municipalite(10, "alma", "alma_belleRegion@hotmail.ca", "alma.com", new System.DateTime(2020, 08, 24));
            Dictionary<int, Municipalite> municipaliteDestination = new Dictionary<int, Municipalite>();
            municipaliteDestination.Add(10, municipalite2);
            Mock<IDepotMunicipalite> mockDepotSQL = new Mock<IDepotMunicipalite>();
            mockDepotSQL.Setup(depot => depot.ListerMunicipalite()).Returns(municipaliteDestination);

            // Act
            TraitementImporterDonneesMunicipalite traitement = new TraitementImporterDonneesMunicipalite(mockDepotCSV.Object, mockDepotSQL.Object);
            traitement.Executer();

            // Assert
            mockDepotCSV.Verify(depot => depot.ListerMunicipalite(), Times.Once);
            mockDepotCSV.VerifyNoOtherCalls();

            mockDepotSQL.Verify(depot => depot.DesactiverMunicipalite(It.IsAny<Municipalite>()), Times.Once);
            mockDepotSQL.Verify(depot => depot.ListerMunicipalite(), Times.Once);
            mockDepotSQL.VerifyNoOtherCalls();
        }
    }
}