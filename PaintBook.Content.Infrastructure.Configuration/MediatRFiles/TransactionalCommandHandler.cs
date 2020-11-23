using FrameWork.Core;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace PaintBook.Content.Infrastructure.Configuration.MediatRFiles
{
    public class TransactionalCommandHandler<TRequest,TResponse>: IPipelineBehavior<TRequest,TResponse>
    {
        IUnitOfWork _unitofWork;
        public TransactionalCommandHandler(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        public  Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _unitofWork.Begin();
            var res = next.Invoke();
            _unitofWork.Commit();
          return  res;
        }
    }
}
