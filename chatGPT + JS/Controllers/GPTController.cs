using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prog3_WebApi_Javascript.DTOs;


namespace Prog3_WebApi_Javascript.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GPTController : ControllerBase
    {
        //היכולת לבצע קריאות http
        private readonly HttpClient _client;
        public GPTController(IConfiguration config)
        {
            // Initialize the private HttpClient instance
            _client = new HttpClient();

            // Retrieve the API key from the configuration settings
            string api_key = config.GetValue<string>("OpenAI:Key");

            // Create the authorization header using the API key
            string auth = "Bearer " + api_key;

            // Add the authorization header to the default request headers of the HttpClient instance
            _client.DefaultRequestHeaders.Add("Authorization", auth);
        }


        [HttpPost("GPTChat")]
        public async Task<IActionResult> GPTChat(Prompt promptFromUser)
        {
            //נקודת קצה API עבור OpenAI GPT
            string endpoint = "https://api.openai.com/v1/chat/completions";
            // המודל, במקרה הזה צאט 3.5
            string model = "gpt-3.5-turbo-0125";
            // מספר מקסימום של טוקנים
            int max_tokens = 300;
            //הגדרת טמפרטורה למפרומפט
            double temperature = 0.8;



           // בנה את ההנחיה לשלוח לדגם
           // במקרה הזה, אנחנו שולחים לצ׳אט בקשה ליצור שאלות בנושא מסוים, המשתמש מזין נושא ואז מקבל תשובה של השאלות, אז יש שרשור של הפרומפט והנושא שהוזן
            string promptToSend = $"Please generate an opinion related to the subject of {promptFromUser.Subject}." + 
            $"you are going to play the role and speak on behalf of {promptFromUser.Charecter} and in the Language of {promptFromUser.Language} ." + 
            $"The opinion should be at the level of {promptFromUser.Level}" +
            $"The opinion should be clear, concise, and designed to assess someone's knowledge " +
            $"or understanding of the topic. Keep your opinion under 300 characters.";

           
            GPTRequest request = new GPTRequest()
            {
                response_format = new { type = "json_object" },
                max_tokens = max_tokens,
                temperature = temperature,
                model = model,
                messages = new List<Message>() {
                   new Message{
                    role = "system",
                    content = "Whenever you receive a request, you must reply in the following JSON format: " +
                    "{'role': string, 'opinion': string}."
                    },
                   new Message{
                    role = "user",
                    content = $"Please generate an opinion related to the subject of history in the level of elementary school students." +
                    $"The opinion should be clear, concise, and designed to assess someone's knowledge " +
                    $"or understanding of the topic. Keep your opinion under 300 characters. Return the opinion in Hebrew language."
                   },
                   new Message{
                    role = "assistant",
                    content = "Why is the rum always gone? Drinking in moderation can be enjoyable, but too much can lead to a pirate's downfall. Savvy?"
                    },
                   new Message {
                    role = "user",
                   content = promptToSend
                    }
                }
            };

            // Send the GPTRequest object to the OpenAI API
            var res = await _client.PostAsJsonAsync(endpoint, request);

            // בדיקה האם התקבלה תשובה תקינה 
            if (!res.IsSuccessStatusCode)
                return BadRequest("problem: " + res.Content.ReadAsStringAsync());

            // Read the JSON response from the API
            JsonObject? jsonFromGPT = res.Content.ReadFromJsonAsync<JsonObject>().Result;
            if (jsonFromGPT == null)
                return BadRequest("empty");

            // Extract the generated content from the JSON response
            // choices - ככה זה חוזר לפי מה שמוצג באתר
            string content = jsonFromGPT["choices"][0]["message"]["content"].ToString();

            // Return the generated content
            return Ok(content);



        }


    }


}

