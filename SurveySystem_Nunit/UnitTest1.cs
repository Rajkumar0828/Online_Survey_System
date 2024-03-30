using Survey_System.Controllers;
using NUnit.Framework;
using Moq;

using Survey_System.Model;
using Survey_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Survey_System;
using System.Reflection;


namespace SurveySystem_Nunit
{
    [TestFixture]
    public class SurveyControllerTests
    {
        private SurveyControllerTests _surveyController;
        private DbContextOptions<AppDbContext> _options;
        

        [SetUp]
        public void Setup()
        {
            // Configure DbContextOptions (use your actual connection string)
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql("server=localhost;user=root;password=Password@12345;database=OnlineSurveySystems;port=3306", new MySqlServerVersion(new Version()))
                .Options;

            // Instantiate ApplicationDbContext
           

            //_surveyController = new SurveyControllerTests(_applicationDbContext);
        }

       



        
        
    }
}



