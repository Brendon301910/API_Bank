using API_bank.Dto;
using API_bank.Graph.Type;
using API_bank.Interfaces;
using GraphQL.Resolvers;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API_bank.Graph.Subscription
{
    public class ContaAddedSubscription : IFieldSubscriptionServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.AddField(new EventStreamFieldType
            {
                Name = "contaAdded",
                Type = typeof(ContaAddedMessageGType),
                Resolver = new FuncFieldResolver<ContaAddedMensage>(context => context.Source as ContaAddedMensage),
                Arguments = new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" }
                ),

            });
        }
    }
}
