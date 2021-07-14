using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.Infrastructure.Initializers.Common
{
    interface IDbInitializer
    {
        void InitDb(IServiceCollection services);
    }
}
