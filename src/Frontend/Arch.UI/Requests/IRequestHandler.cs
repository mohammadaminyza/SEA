using Zamin.Core.RequestResponse.Commands;
using Zamin.Core.RequestResponse.Queries;

namespace Arch.UI.Requests;

public interface IRequestHandler
{
    Task<CommandResult> Send<TRequest>(TRequest request) where TRequest : class, ICommand;
    Task<QueryResult<TResponse>> Send<TRequest, TResponse>(TRequest request) where TRequest : class, IQuery<TResponse>;
}