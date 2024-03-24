namespace Shared.Core.Abstractions
{
    public interface IHandler<Response, Request>
    {
        public Response Handle(Request request);
    }
}
