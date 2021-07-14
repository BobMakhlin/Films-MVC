using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Films.Infrastructure.Initializers.Common
{
    interface IArchitectureInitializer
    {
        void InitArchitecture(IServiceCollection services);
    }
}
