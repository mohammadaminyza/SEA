using Arch.Core.Contracts.Orders.Commands.CreateOrder;
using Arch.Core.Contracts.Orders.Queries.GetOrders;
using Arch.UI.RequestHandlers;
using System.Text;
using System.Text.Json;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Queries;

public class ApiRequestHandler : IRequestMediator
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializerOptions;

    public ApiRequestHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
    }

    public async Task<CommandResult> Send<TRequest>(TRequest request) where TRequest : class, ICommand
    {
        string requestUri = ApiRoutes.CommandRoutes[typeof(TRequest)];
        return await SendRequest<TRequest, CommandResult>(request, requestUri);
    }

    public async Task<QueryResult<TResponse>> Send<TRequest, TResponse>(TRequest request) where TRequest : class, IQuery<TResponse>
    {
        string requestUri = ApiRoutes.QueryRoutes[typeof(TRequest)];
        return await SendRequest<TRequest, QueryResult<TResponse>>(request, requestUri);
    }

    private async Task<TResponse> SendRequest<TRequest, TResponse>(TRequest request, string requestUri) where TResponse : class
    {
        string jsonRequest = JsonSerializer.Serialize(request, _serializerOptions);
        HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await _httpClient.PostAsync(requestUri, content);
        response.EnsureSuccessStatusCode();

        string jsonResponse = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<TResponse>(jsonResponse, _serializerOptions);
    }
}

public static class ApiRoutes
{
    public static readonly IReadOnlyDictionary<Type, string> CommandRoutes = new Dictionary<Type, string>
    {
        { typeof(CreateOrderCommand), "/api/orders/create" },
    };

    public static readonly IReadOnlyDictionary<Type, string> QueryRoutes = new Dictionary<Type, string>
    {
        { typeof(GetOrdersQuery), "/api/orders/get" },
    };
}