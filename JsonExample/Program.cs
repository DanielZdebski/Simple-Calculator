using System.Dynamic;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace JsonExample
{
    public class ComponentThreeD
    { 
        public string Name { get; set; }
        public string Description { get; set; }
        public int[] Component { get; set; }

        public ComponentThreeD()
        {
            string type = this.GetType().ToString();
            Console.WriteLine();
        }

        public JsonNode SetJsonNode()
        {
            return JsonSerializer.SerializeToNode(this);
        }
    }

    public class ComponentZeroD
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Component { get; set; }
    }

    class Components : Dictionary<string, ComponentThreeD> 
    {
        public JsonObject SetJsonObject()
        {
            JsonObject outputJsonObject = new JsonObject();

            foreach (KeyValuePair<string, ComponentThreeD> item in this)
            {
                outputJsonObject.Add(item.Key, item.Value.SetJsonNode());    
            }

            return outputJsonObject;
        }
    }
    


    public class Program
    {
        public static void Main(string[] args)
        {
            ComponentThreeD comp1 = new ComponentThreeD()
            {
                Name = "comp1",
                Description = "First Component",
                Component = [1, 2, 3, 4]
            };

            ComponentThreeD comp3 = new ComponentThreeD()
            {
                Name = "comp3",
                Description = "First Component",
                Component = [1, 2, 3, 4]
            };

            ComponentZeroD comp2 = new ComponentZeroD()
            {
                Name = "comp1",
                Description = "First Component",
                Component = 1
            };

            Components components = new Components();


            components.Add("Daniel", comp1 );
            components.Add("Jiri", comp3);

            JsonObject jsonObject = components.SetJsonObject();

            ComponentThreeD compOut2 = components["Daniel"];

            JsonNode? jsonNode1 = JsonSerializer.SerializeToNode(comp1);
            JsonNode? jsonNode2 = JsonSerializer.SerializeToNode(comp2);

            KeyValuePair<string, JsonNode?> record = new KeyValuePair<string, JsonNode?>("comp1", jsonNode1);

            JsonObject jsonObject1 = new JsonObject();

            jsonObject1.Add(record);
            jsonObject1.Add("comp2", jsonNode2);

            string json = jsonObject1.ToString();

            JsonObject jsonObject2 = JsonSerializer.Deserialize<JsonObject>(json);

            ComponentThreeD output1 = JsonSerializer.Deserialize<ComponentThreeD>(jsonObject2["comp1"]);

            string type = output1.GetType().ToString();
            int index = type.LastIndexOf(".");
            type = type.Substring(index + 1);
            
            Console.WriteLine(type);
            
        
        
        }
    }
}