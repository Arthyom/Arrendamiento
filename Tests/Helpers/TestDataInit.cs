using Core.DTOs.Base;
using Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;

namespace Tests.Helpers
{
    public static class TestDataInit
    {
        public static List<TBaseEntity> GetTestData<TBaseEntity>(string nameSpace) where TBaseEntity : BaseEntity
        {
            string entityName = typeof(TBaseEntity).Name;
            string documentName = $"{entityName}TestData.json";
            string stringContent;
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"Tests.{nameSpace}." + documentName;

            using (Stream? stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        stringContent = reader.ReadToEnd().CorrectSeederBoolen();

                        var testData = JsonConvert.DeserializeObject<List<TBaseEntity>>(stringContent);

                        return testData != null ? testData : new List<TBaseEntity>();
                    }
                }
                else
                    throw new Exception("Cannot read test data json");
            }
        }
    }
}
