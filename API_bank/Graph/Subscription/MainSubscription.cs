using API_bank.Interfaces;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API_bank.Graph.Subscription
{
    public class MainSubscription : ObjectGraphType
    {
        public MainSubscription(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainSubscription";
            fieldService.ActivateFields(this, FieldServiceType.Subscription, env, provider);
        }
    }
}
