using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AzureOpenAIGPT.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private AzureOpenAIGPTClient _cptClient = null;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ChatGPTResponseString { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            
            _logger = logger;
        }
        /*
        public void OnGet()
        {
           
        }
        */
        public async Task OnGetAsync()
        {
            if(SearchString != null) {
                if(_cptClient == null)
                    _cptClient = new AzureOpenAIGPTClient();
                ChatGPTResponseString = await _cptClient.SendMessage(SearchString);
            }
        }
    }
}