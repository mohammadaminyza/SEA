using Arch.Core.Contracts.Orders.Commands.CreateOrder;
using Arch.UI.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Arch.UI.Pages.Orders
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public CreateOrderCommand CreateOrderCommand { get; set; }

        public string ErrorMessage { get; set; } = "";

        private readonly IRequestHandler _requestHandler;

        public CreateModel(IRequestHandler requestHandler)
        {
            _requestHandler = requestHandler;
        }
        public void OnGet()
        {
        }

        public async Task OnPost()
        {
            var result = await _requestHandler.Send(CreateOrderCommand);
            ErrorMessage = string.Join(",", result.Messages);
        }
    }
}
