using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using StockAPI.Controllers;
using StockAPI.Models;
using StockAPI.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace StockTest
{
    [TestFixture]
    public class UnitTest1
    {
        
        private Mock<IStockrepo> _repo;
        public IStockrepo repo;
        
        List<MedicineStock> medicineStock;
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IStockrepo>();
           
            medicineStock = new List<MedicineStock> {
             new MedicineStock
            {
                Name = "Dolo 650",
                ChemicalComposition = new List<string> { "Paracetamol", "Acetaminophen" },
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("2022-12-31"),
                NumberOfTabletsInStock = 300
            },
            new MedicineStock
            {
                Name = "Orthoherb",
                ChemicalComposition = new List<string> { "Castor Plant", ",Adulsa","Neem","Guggul"},
                TargetAilment = "Orthopaedics",
                DateOfExpiry = DateTime.Parse("2021-11-26"),
                NumberOfTabletsInStock = 190
            },


            new MedicineStock
            {
                Name = "Cholecalciferol",
                ChemicalComposition = new List<string> { "ergocalciferol", "cholecalciferol","22-dihydroergocalciferol" },
                TargetAilment = "Orthopaedics",
                DateOfExpiry = DateTime.Parse("2023-11-10"),
                NumberOfTabletsInStock = 200
            },

            new MedicineStock
            {
                Name = "Gaviscon",
                ChemicalComposition = new List<string> { "Magnesium", "Oxide", "Silicon", "Sodium" },
                TargetAilment = "General",
                DateOfExpiry = DateTime.Parse("2022-08-20"),
                NumberOfTabletsInStock = 150
            },
            new MedicineStock
            {
                Name = "Hilact",
                ChemicalComposition = new List<string> { "Pancreatin", "Dimethicone","Polydimethylsiloxane" },
                TargetAilment = "Gynaecology",
                DateOfExpiry = DateTime.Parse("2024-06-11"),
                NumberOfTabletsInStock = 400
            },

             new MedicineStock
            {
                Name = "Cyclopam",
                ChemicalComposition = new List<string> { "Dicyclomine", "hydrochloride", "paracetamol" },
                TargetAilment = "Gynaecology",
                DateOfExpiry = DateTime.Parse("2025-11-02"),
                NumberOfTabletsInStock = 500
            }

            };
            _repo.Setup(x => x.GetStockDetails()).Returns(medicineStock);
            repo = _repo.Object;
           

        }


        [Test]
        public void MedicineStockInfoTest()
        {
            List<MedicineStock> answer = repo.GetStockDetails();
            Assert.AreEqual(medicineStock, answer);
            Assert.Pass();
        }

        
        [Test]
        public void MedicineStockInfoTest_PassCase_Repository()
        {
            IEnumerable<MedicineStock> result = repo.GetStockDetails();
            Assert.IsNotNull(result);
        }
        [Test]
        public void MedicineStockInfoTest_FailCase_Repository()
        {
            medicineStock = null;
            _repo.Setup(m => m.GetStockDetails()).Returns(medicineStock);
            repo = _repo.Object;
            List<MedicineStock> result = (List<MedicineStock>)repo.GetStockDetails();
            Assert.IsNull(result);
        }
        



    }
}
