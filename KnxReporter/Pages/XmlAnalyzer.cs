using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace KnxReporter.Pages
{
    public class XmlAnalyzer
    {

        private long currentCount = 0;

        public async Task<string> AnalyzeEmiLengths(MemoryStream memStream)
        {
            var doc = "";

            var emiLengths = "";
            var lenghtResultsTable = new ConcurrentDictionary<int, int>();
            {
                currentCount = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(memStream);
                XmlNodeList tList = xmlDoc.GetElementsByTagName("Telegram");
                currentCount = tList.Count;
                var tListGenercic = tList.Cast<XmlElement>();
                var maxIterations = (tListGenercic.Count() > 10) ? 10 : tList.Count;

                var tempLength = 0;
                Parallel.ForEach(tListGenercic, (t) =>
                {
                    XmlElement temp = (XmlElement)t;

                    tempLength = temp.GetAttributeNode("RawData").Value.Length;
                    if (lenghtResultsTable.ContainsKey(tempLength))
                    {
                        int tempValue = 0;
                        lenghtResultsTable.TryGetValue(tempLength, out tempValue);
                        lenghtResultsTable.TryUpdate(tempLength, tempValue + 1, tempValue);
                    }
                    else
                    {
                        lenghtResultsTable.TryAdd(tempLength, 1);
                    }
                    currentCount = currentCount++;
                });
                foreach (var ent in lenghtResultsTable)
                {
                    doc += "\n\r" + ent.Key.ToString() + " : " + ent.Value.ToString() + ",";
                }
            }

            return doc;
        }
    }
}
