using NUnit.Framework;
using SCommon.Helpers;
using SCore;
using SCore.Pages;
using Newtonsoft.Json.Linq;



namespace STest.TestSuite
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    internal class SaveTests : Base
    {

        [Test]
        [Category("Regression")]
        public void CheckHomePageLoading()
        {
            //JObject scenarioData = ReadJsonTestData.ReadJSonTestDataForScenario("SaveService");

            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.verifyHomepageLoading();

            //homePage.expandLeftMenu();
            //BasePage basePage = homePage.clickMenu("Resources");
            //basePage = homePage.clickMenu("Employees");
            //Console.WriteLine("This object is of first: " + basePage.GetType().Name);
            //Console.WriteLine("This object is of first: " + basePage.GetType().FullName);
            //Console.WriteLine("This object is of first: " + basePage.GetType().GetType());
            //if (basePage.GetType() == typeof(ServiceListPage))
            //{
            //    basePage = (ServiceListPage)basePage;
            //    Console.WriteLine("This object is of: " + basePage.GetType());
            //}

            //Thread.Sleep(20000);
        }

        [Test]
        [Category("Regression")]
        public void CheckServiceListPageLoading()
        {
            //JObject scenarioData = ReadJsonTestData.ReadJSonTestDataForScenario("SaveService");

            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            ServiceListPage serviceListPage = (ServiceListPage)homePage.clickMenu("Services");
            Thread.Sleep(5000);
            serviceListPage.verifyServiceListPageLoading();

            //Thread.Sleep(20000);
        }

        [Test]
        [Category("Regression")]
        public void CheckServicePlanningListPageLoading()
        {
            //JObject scenarioData = ReadJsonTestData.ReadJSonTestDataForScenario("SaveService");

            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            ServicePlanningListPage servicePlanningListPage = (ServicePlanningListPage)homePage.clickMenu("Service planning");
            Thread.Sleep(5000);
            servicePlanningListPage.verifyServicePlanListPageLoading();

            //Thread.Sleep(20000);
        }

        [Test]
        [Category("Regression")]
        public void SaveService()
        {
            JObject scenarioData = ReadJsonTestData.ReadJSonTestDataForScenario("SaveService");

            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            ServiceListPage serviceListPage = (ServiceListPage)homePage.clickMenu("Services");
            Thread.Sleep(5000);
            //            serviceListPage.verifyServiceListPageLoading();
            serviceListPage.ClickAddServiceButton();
            Thread.Sleep(5000);
            serviceListPage.createService("10R Reumatologia", "Doctor Service" + DateTime.Now.ToString(), "08", "12", "Doctor", "Employee", "Haavahoitaja", 2);

            Thread.Sleep(5000);
        }

        [Test]
        [Category("Regression")]
        public void UpdateService()
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            ServiceListPage serviceListPage = (ServiceListPage)homePage.clickMenu("Services");
            Thread.Sleep(5000);
            serviceListPage.ClickAddServiceButton();
            Thread.Sleep(5000);
            string servicename = serviceListPage.createService("10R Reumatologia", "Doctor Service" + DateTime.Now.ToString(), "08", "12", "Doctor", "Employee", "Haavahoitaja", 2);
            Thread.Sleep(5000);
            serviceListPage.openServiceFromListForEditing(servicename);
            Thread.Sleep(2000);
            serviceListPage.updateService("Doctor Service updated Auto " + DateTime.Now.ToString("hh:mm"), "09", "14", "High", "Facility", "Ortopedi", 2, "Lifecare", "LC001");
            Thread.Sleep(5000);

        }

        [Test]
        [Category("Regression")]
        public void CheckFacilitiesListPageLoading()                                    // Verifys the Facilities List page is loading correctly
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Resources");
            FacilitiesListPage facilitiesListPage = (FacilitiesListPage)homePage.clickMenu("Facilities");
            Thread.Sleep(5000);
            facilitiesListPage.verifyFacilitiesListPageLoading();

            Thread.Sleep(20000);
        }


        [Test]
        [Category("Regression")]
        public void SaveNewFacility()                                                   // create a new facility and save it.
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Resources");
            FacilitiesListPage facilitiesListPage = (FacilitiesListPage)homePage.clickMenu("Facilities");
            Thread.Sleep(3000);
            facilitiesListPage.ClickAddFacilityButton();
            Thread.Sleep(5000);
            facilitiesListPage.createFacility("B302-" + DateTime.Now.ToString("hh:mm"), "Ortopedia, työpiste", "88-8888-190", "00000");

        }

        [Test]
        [Category("Regression")]
        public void UpdateFacilityRecord()                                         //creates a new facility and updates it.
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Resources");
            FacilitiesListPage facilitiesListPage = (FacilitiesListPage)homePage.clickMenu("Facilities");
            Thread.Sleep(5000);
            facilitiesListPage.ClickAddFacilityButton();
            string facilityname = facilitiesListPage.createFacility("B203-" + DateTime.Now.ToString("hh:mm"), "Ortopedia, työpiste", "88-7777-190", "00000");
            Thread.Sleep(5000);
            facilitiesListPage.openFacilityForEditing(facilityname);
            Thread.Sleep(5000);
            facilitiesListPage.updateFacility(facilityname + " Updated", "Urologia, urodynamia", "88-8888-190", "Kirurgian poliklinikka");

        }


        [Test]
        [Category("Regression")]                                                  // picks first employee in the list and updates it record    
        public void UpdateEmployeeRecord()
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Resources");
            EmployeeListPage employeeListPage = (EmployeeListPage)homePage.clickMenu("Employees");
            Thread.Sleep(5000);
            employeeListPage.openEmployeeForEditing();
            Thread.Sleep(5000);
            employeeListPage.updateEmployee("Lifecare", "LC-01");

        }

        [Test]
        [Category("Regression")]
        public void CheckSpecialityRolesTabLoading()                        //Verifys the Speciality Roles tab is loading correctly
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Settings");
            ResourceDefinitions resourceDefinitions = (ResourceDefinitions)homePage.clickMenu("Resource definitions");
            resourceDefinitions.openSpecialityRolesTab();
            Thread.Sleep(3000);
            resourceDefinitions.verifySpecialityRolesTabLoaded();
            Thread.Sleep(5000);
        }

        [Test]
        [Category("Regression")]
        public void CreateSpecialityRole()                              // Creates a new Speciality Role
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Settings");
            ResourceDefinitions resourceDefinitions = (ResourceDefinitions)homePage.clickMenu("Resource definitions");
            resourceDefinitions.openSpecialityRolesTab();
            Thread.Sleep(3000);
            resourceDefinitions.ClickAddSpecialityRoleButton();
            Thread.Sleep(5000);
            resourceDefinitions.createSpecialityRole("Lääkäri " + DateTime.Now.ToString("hh:mm"), "Doctor");
            Thread.Sleep(5000);
        }

        [Test]
        [Category("Regression")]
        public void UpdateSpecialityRole()                              // Creates a new Speciality Role and updates it.
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Settings");
            ResourceDefinitions resourceDefinitions = (ResourceDefinitions)homePage.clickMenu("Resource definitions");
            resourceDefinitions.openSpecialityRolesTab();
            Thread.Sleep(5000);
            resourceDefinitions.ClickAddSpecialityRoleButton();
            string specialityRoleName = resourceDefinitions.createSpecialityRole("Lääkäri " + DateTime.Now.ToString("hh:mm"), "Doctor");
            Thread.Sleep(5000);
            resourceDefinitions.openSpecialityRoleForEditing(specialityRoleName);
            Thread.Sleep(2000);
            resourceDefinitions.updateSpecialityRole("Updated " + specialityRoleName, "Nurse");
            Thread.Sleep(5000);
        }


        [Test]
        [Category("Regression")]
        public void CheckAvailabilityInfoPageLoading()                              //Verifys the Availability Information page is loading correctly
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(5000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Resources");
            AvailabilityInformationPage availabilityInfoPage = (AvailabilityInformationPage)homePage.clickMenu("Availability information");
            Thread.Sleep(3000);
            availabilityInfoPage.verifyAvailabilityInfoPageLoading();
            Thread.Sleep(5000);
        }

        [Test]
        [Category("Regression")]
        public void CreateEmployeeAvailability()                                    //Creates a new availability for an employee
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(2000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Resources");
            AvailabilityInformationPage availabilityInfoPage = (AvailabilityInformationPage)homePage.clickMenu("Availability information");
            Thread.Sleep(3000);
            availabilityInfoPage.selectUnitThatContainsResource();
            Thread.Sleep(2000);
            availabilityInfoPage.openAvailabilityDetailsDialog();
            Thread.Sleep(2000);
            availabilityInfoPage.createAvailability("08", "14");
            Thread.Sleep(2000);
        }

        [Test]
        [Category("Regression")]
        public void UpdateEmployeeAvailability()                                    //create and update an availability for an employee
        {
            HomePage homePage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            homePage.setLanguage("English");
            Thread.Sleep(2000);
            homePage.expandLeftMenu();
            homePage.clickMenu("Resources");
            AvailabilityInformationPage availabilityInfoPage = (AvailabilityInformationPage)homePage.clickMenu("Availability information");
            Thread.Sleep(2000);
            availabilityInfoPage.selectUnitThatContainsResource();
            Thread.Sleep(2000);
            availabilityInfoPage.openAvailabilityDetailsDialog();
            Thread.Sleep(1000);
            availabilityInfoPage.createAvailability("08", "14");
            Thread.Sleep(1000);
            availabilityInfoPage.updateCreatedAvailability("10", "16");
            Thread.Sleep(2000);
        }
        //[Test]
        [Category("Regression")]
        public void SaveDevice()
        {
            JObject scenarioData = ReadJsonTestData.ReadJSonTestDataForScenario("SaveDevice");
            //Console.WriteLine(scenarioData["unit"].ToString());
            HomePage landingPage = CoreBase.Login.launchAndLoginProductionManagmentWebsite();
            landingPage.ClickMenuArrow();
            landingPage.ClickResourceMenu();
            DeviceLandingPage deviceLandingPage = landingPage.ClickDeviceMenu();
            //Thread.Sleep(5000);
            AddEditDevicePage addEditDevicePage = deviceLandingPage.ClickAddNewDeviceButton();
            //Thread.Sleep(5000);
            addEditDevicePage.enterDeviceName(scenarioData["device_name"].ToString());
            addEditDevicePage.setDeviceType(scenarioData["device_type"].ToString());
            addEditDevicePage.setUnit(scenarioData["unit"].ToString());

            Thread.Sleep(20000);
        }
    }
}
