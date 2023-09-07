using Core.Application.Logger;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Pipelines.Logging
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly BaseLogger _baseLogger;


        public LoggingBehavior(BaseLogger loggerServiceBase)
        {
            _baseLogger = loggerServiceBase;

        }
        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            List<LogParameter> logParameters = new();
            logParameters.Add(new LogParameter
            {
                Type = request.GetType().Name,
                Value = request
            });

            LogDetails logDetail = new()
            {
                MethodName = next.Method.Name,
                Parameters = logParameters
            };

            _baseLogger.Info(JsonConvert.SerializeObject(logDetail));
            return next();
        }
    }
}
