using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAiQuickStartCSharp.Configuration;

namespace OpenAiQuickStartCSharp.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenAiController : ControllerBase
{
    private readonly OpenAiConfig _config;

    public OpenAiController(IOptions<OpenAiConfig> config)
    {
        _config = config.Value;
    }
 
    [HttpPost]
    public async Task<IActionResult> GenerateSuperheroNames([FromBody] AnimalRequestModel request)
    {
        var apiKey = _config.ApiKey;

        if (string.IsNullOrEmpty(apiKey))
        {
            return StatusCode(500, new
            {
                error = new
                {
                    message = "OpenAI API key not configured, please follow instructions in README.md"
                }
            });
        }

        var openai = new OpenAI_API.OpenAIAPI(apiKey);

        var animal = request.Animal ?? "";
        if (string.IsNullOrWhiteSpace(animal))
        {
            return StatusCode(400, new
            {
                error = new
                {
                    message = "Please enter a valid animal"
                }
            });
        }

        try
        {
            var completion = await openai.Completions.CreateCompletionAsync(
                prompt: GeneratePrompt(animal),
                temperature: 1
            );

            return Ok(completion.Completions[0].Text);
        }
        catch (Exception error)
        {
            await Console.Error.WriteLineAsync($"Error with OpenAI API request: {error.Message}");
            return StatusCode(500, new
            {
                error = new
                {
                    message = "An error occurred during your request."
                }
            });
        }
    }

    private string GeneratePrompt(string animal)
    {
        var capitalizedAnimal = $"{char.ToUpper(animal[0])}{animal.Substring(1).ToLower()}";
        return @$"Suggest three names for an animal that is a superhero.

Animal: Cat
Names: Captain Sharpclaw, Agent Fluffball, The Incredible Feline
Animal: Dog
Names: Ruff the Protector, Wonder Canine, Sir Barks-a-Lot
Animal: {capitalizedAnimal}
Names:";
    }
}