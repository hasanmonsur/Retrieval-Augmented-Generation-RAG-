namespace RagApi.Helpers
{
    public class DataRetriever
    {
        private readonly List<string> _data;

        public DataRetriever()
        {
            _data = new List<string>
        {
            //"What is the weather today?",
            "The weather today is sunny and warm.",
            "I enjoy learning new programming languages.",
            "The stock market is seeing some fluctuations.",
            "AI and machine learning are transforming industries."
        };
        }

        // Simulating a simple retrieval process
        public string RetrieveRelevantData(string query)
        {
            // Simple search for matching keywords (can be replaced with advanced retrieval logic)
            var relevantData = _data.FirstOrDefault(d => d.Contains(query, StringComparison.OrdinalIgnoreCase));
            return relevantData ?? "No relevant information found.";
        }
    }
}
