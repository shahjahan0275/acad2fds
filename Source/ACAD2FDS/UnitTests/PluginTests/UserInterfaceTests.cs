namespace UnitTests.PluginTests
{
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Fds2AcadPlugin.BLL;
    using Fds2AcadPlugin.BLL.Helpers;
    using Fds2AcadPlugin.UserInterface;
    using Fds2AcadPlugin.UserInterface.Materials;
    using MaterialManager.BLL;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UserInterfaceTests
    {
        private static Surface surface;

        private static Material material;

        [ClassInitialize]
        public static void TestSetup(TestContext context)
        {
            var r1 = new Ramp("C_P", 0.0, 0.0);
            var r2 = new Ramp("C_P", 1.0, 5.0);
            var r3 = new Ramp("C_P", 2.0, 15.0);

            var ramp_C_P = new List<Ramp> { r1, r2, r3 };

            surface = new Surface
                              {
                                  ID = "TestSurface",
                                  Alpha = 0.11,
                                  Backing = Backing.INSULATED,
                                  BurnAway = false,
                                  BurningRateMax = 0.03,
                                  C_Delta_Rho = 1.0,
                                  C_P = 0.88,
                                  Color = new FdsColor(255, 0, 0),
                                  Delta = 0.1,
                                  Density = 810,
                                  Emissivity = 0.8,
                                  ExtinguishingCoefficients = 0.5,
                                  ForYouInformation = "Test surface",
                                  HeatOfVaporization = 1620,
                                  KS = 0.19,
                                  Porosity = 0.5,
                                  RAMP_C_P = ramp_C_P,
                                  RAMP_KS = ramp_C_P,
                                  Ramp_Q = ramp_C_P,
                                  MaterialID = "TestMaterial"
                              };


            var r1_m = new Ramp("C_P", 0.0, 0.0);
            var r2_m = new Ramp("C_P", 1.0, 5.0);
            var r3_m = new Ramp("C_P", 2.0, 15.0);

            var ramp_SPECIFIC_HEAT_RAMP = new List<Ramp> { r1_m, r2_m, r3_m };

            material = new Material
                           {
                               CONDUCTIVITY = 0.1,
                               DENSITY = 100.0,
                               FYI = "Test material",
                               HEAT_OF_COMBUSTION = 1500.0,
                               HEAT_OF_REACTION = 3000,
                               ID = "TestMaterial",
                               N_REACTIONS = 1,
                               NU_FUEL = 1.0,
                               MaterialCategory = MaterialCategory.LiquidFuel,
                               REFERENCE_TEMPERATURE = 200,
                               SPECIFIC_HEAT = 1.0,
                               SPECIFIC_HEAT_RAMP = ramp_SPECIFIC_HEAT_RAMP,
                               CONDUCTIVITY_RAMP = ramp_SPECIFIC_HEAT_RAMP
                           };

            Application.EnableVisualStyles();
        }

        [TestMethod]
        public void PluginOptionsTest()
        {
            Application.EnableVisualStyles();
            var plugionOptions = new PluginOptions();
            plugionOptions.ShowDialog();
        }

        [TestMethod]
        public void CalculationInfoTest()
        {
            var calculationInfo = new CalculationInfo();
            calculationInfo.ShowDialog();
        }

        [TestMethod]
        public void SurfaceEditorTest()
        {
            var surfaceEditor1 = new SurfaceEditor(surface);
            surfaceEditor1.ShowDialog();

            var surfaceEditor2 = new SurfaceEditor(surfaceEditor1.Surface);
            surfaceEditor2.ShowDialog();
        }

        [TestMethod]
        public void MaterialEditorTest()
        {
            TestSetup(null);

            var materialEditor1 = new MaterialEditor(material);
            materialEditor1.ShowDialog();

            var materialEditor2 = new MaterialEditor(materialEditor1.Material);
            materialEditor2.ShowDialog();
        }

        [TestMethod]
        public void MaterialMapperTest()
        {
            var usedMaterials = new List<string> { "wood", "plastic", "metan", "C4", "steel" };
            var availableSurfaces = new List<Surface> {
                new Surface{ID = "Surface for plastic"},
                new Surface{ID = "Surface for steel"},
                new Surface{ID = "Surface for metan"},
                new Surface{ID = "Surface for wood"},
                new Surface{ID = "Surface for C4"}
            };

            //var materialMapper = new MaterialMapper(usedMaterials, availableSurfaces, new List<MaterialAndSurface>());
            //materialMapper.ShowDialog();

            //XmlSerializer<List<MaterialAndSurface>>.Serialize(materialMapper.MappingMaterials, @"C:\surface.xml");
            var deserialized = XmlSerializer<List<MaterialAndSurface>>.Deserialize(@"C:\surface.xml");

            //var dict = deserialized.ToDictionary();

            var materialMapper2 = new MaterialMapper(usedMaterials, availableSurfaces, deserialized);
            materialMapper2.ShowDialog();
        }

        [TestMethod]
        public void MaterialProviderTest()
        {
            TestSetup(null);

            var materials = new List<Material>();
            var surfaces = new List<Surface>();

            materials.Add(material);
            materials.Add(material);
            materials.Add(material);
            materials.Add(material);

            surfaces.Add(surface);
            surfaces.Add(surface);
            surfaces.Add(surface);
            surfaces.Add(surface);

            var materialProvider = new MaterialProvider(materials, surfaces);
            materialProvider.ShowDialog();
        }

        [TestMethod]
        public void SerializationTest()
        {
            //var r1 = new Ramp("C_P", 0.0, 0.0);
            //var r2 = new Ramp("C_P", 1.0, 5.0);
            //var r3 = new Ramp("C_P", 2.0, 15.0);

            //var ramp_C_P = new List<Ramp> { r1, r2, r3 };

            //var surface = new Surface
            //{
            //    ID = "Test",
            //    Alpha = 0.11,
            //    Backing = Backing.INSULATED,
            //    BurnAway = false,
            //    BurningRateMax = 0.03,
            //    C_Delta_Rho = 1.0,
            //    C_P = 0.88,
            //    Color = new FdsColor(255, 0, 0),
            //    Delta = 0.1,
            //    Density = 810,
            //    Emissivity = 0.8,
            //    ExtinguishingCoefficients = 0.5,
            //    ForYouInformation = "Test surface",
            //    // HeatOfCombustion = 4000,
            //    HeatOfVaporization = 1620,
            //    KS = 0.19,
            //    MaterialCategory = MaterialCategory.LiquidFuel,
            //    Porosity = 0.5,
            //    RAMP_C_P = ramp_C_P,
            //    RAMP_KS = ramp_C_P,
            //    Ramp_Q = ramp_C_P
            //};

            //var entries = new List<Entry>
            //                  {
            //                      new Entry("qwerty", surface),
            //                      new Entry("asdff", surface),
            //                      new Entry("zxcvcz", surface)
            //                  };

            //var store = @"C:\surface.xml";

            //XmlSerializer<List<Entry>>.Serialize(entries, store);

            //var entries2 = XmlSerializer<List<Entry>>.Deserialize(store);

        }

        [TestMethod]
        public void AboutFormTest()
        {
            var about = new About
            {
                ProductLogo = PluginInfoProvider.ProductLogo,
                PluginName = PluginInfoProvider.ProductName,
                Authors = string.Join(", ", PluginInfoProvider.Authors),
                Description = PluginInfoProvider.ProductDescription,
                Version = PluginInfoProvider.ProductVersion
            };

            about.ShowDialog();
        }
    }
}