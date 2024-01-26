using Zamin.Core.Contracts.ApplicationServices.Commands;
using Zamin.Core.Contracts.ApplicationServices.Queries;
using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Queries;

namespace Arch.UI.RequestHandlers;

public class DirectRequestHandler : IRequestMediator
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public DirectRequestHandler(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    public async Task<CommandResult> Send<TRequest>(TRequest request) where TRequest : class, ICommand
    {
        return await _commandDispatcher.Send(request);
    }

    public async Task<QueryResult<TResponse>> Send<TRequest, TResponse>(TRequest request) where TRequest : class, IQuery<TResponse>
    {
        return await _queryDispatcher.Execute<TRequest, TResponse>(request);
    }
}