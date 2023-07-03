using Azure;
using Azure.AI.OpenAI;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using static System.Environment;

namespace AzureOpenAIGPT
{
    public class AzureOpenAIGPTClient
    {
        private readonly OpenAIClient _client;
        // Enter the deployment name you chose when you deployed the model.
        private readonly string engine = "REPLACE_WITH_YOUR_MODEL_HERE";
        private readonly string endpoint = "REPLACE_WITH_YOUR_END_POINT_HERE";
        private readonly string key = "REPLACE_WITH_YOUR_KEY_VALUE_HERE"; 

        public AzureOpenAIGPTClient()
        {            
            _client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
        }

        // Method to send a message to the ChatGPT API and return the response
        public async Task<string>  SendMessage(string prompt)
        {
            try
            {
                Response<Completions> completionsResponse = await _client.GetCompletionsAsync(engine, prompt);
                string completion = completionsResponse.Value.Choices[0].Text;
                // Extract and return the chatbot's response text
                return completion ?? string.Empty;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
           
        }
    }
}
