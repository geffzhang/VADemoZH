// <auto-generated>
// Code generated by LUISGen vDispatch.json -cs Luis.Dispatch -o 
// Tool github: https://github.com/microsoft/botbuilder-tools
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.Luis;
namespace Luis
{
    public class Dispatch: IRecognizerConvert
    {
        public string Text;
        public string AlteredText;
        public enum Intent {
            l_VAPOCen_Calendar, 
            l_VAPOCen_Email, 
            l_VAPOCen_General, 
            l_VAPOCen_PointOfInterest, 
            l_VAPOCen_ToDo, 
            l_VAPOCen_Weather, 
            None, 
            q_FAQ
        };
        public Dictionary<Intent, IntentScore> Intents;

        public class _Entities
        {
            // Simple entities
            public string[] ADDRESS;
            public string[] KEYWORD;

            // Pattern.any
            public string[] ShopContent;
            public string[] TaskContentPattern;

            // Instance
            public class _Instance
            {
                public InstanceData[] ADDRESS;
                public InstanceData[] KEYWORD;
                public InstanceData[] ShopContent;
                public InstanceData[] TaskContentPattern;
            }
            [JsonProperty("$instance")]
            public _Instance _instance;
        }
        public _Entities Entities;

        [JsonExtensionData(ReadData = true, WriteData = true)]
        public IDictionary<string, object> Properties {get; set; }

        public void Convert(dynamic result)
        {
            var app = JsonConvert.DeserializeObject<Dispatch>(JsonConvert.SerializeObject(result));
            Text = app.Text;
            AlteredText = app.AlteredText;
            Intents = app.Intents;
            Entities = app.Entities;
            Properties = app.Properties;
        }

        public (Intent intent, double score) TopIntent()
        {
            Intent maxIntent = Intent.None;
            var max = 0.0;
            foreach (var entry in Intents)
            {
                if (entry.Value.Score > max)
                {
                    maxIntent = entry.Key;
                    max = entry.Value.Score.Value;
                }
            }
            return (maxIntent, max);
        }
    }
}
