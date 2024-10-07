using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SCommon.Helpers
{
    public class ReadJsonTestData
    {
        public static JObject ReadJSonTestDataForScenario(string scenarioName)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            using (StreamReader r = new StreamReader(projectDirectory + "/STests/TestData/TestData.json"))
            {
                string json = r.ReadToEnd();
                //var jsonData = JObject.Parse(json).Children();
                //List<JToken> tokens = jsonData.Children().ToList();
                dynamic array = JsonConvert.DeserializeObject(json);
                //string []arr = array.ToObject<string[]>();
                //JArray jArray = (JArray)array[scenarioName];
                //Console.WriteLine(array[scenarioName]["unit"]);
                //foreach (var item in array)
                //{
                //Console.WriteLine(arr);
                //}
                return array[scenarioName];
            }
        }
    }
}
