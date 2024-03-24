namespace Shared.Core.Abstractions
{
    public interface IHandlerAsync<Response, Request>
    {
        public Task<Response> HandleAsync(Request request);
    }
}
