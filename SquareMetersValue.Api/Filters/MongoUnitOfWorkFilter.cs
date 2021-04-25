using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using SquareMetersValue.Domain.Core;
using SquareMetersValue.Infra.Configurations;

namespace SquareMetersValue.Api.Filters
{
    public class MongoUnitOfWorkFilter : IAsyncActionFilter
    {
        private readonly NotificationContext _notificationContext;
        private readonly IUnitOfWork _unitOfWork;
        public MongoUnitOfWorkFilter(NotificationContext notificationContext, IUnitOfWork unitOfWork)
        {
            _notificationContext = notificationContext;
            _unitOfWork = unitOfWork;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            try
            {
                await next.Invoke();


                if (_notificationContext.HasNotifications)
                {
                    _unitOfWork.Dispose();
                }
                else
                {
                    _unitOfWork.Commit();
                }

            }
            catch (Exception)
            {



                throw;
            }
        }
    }
}
