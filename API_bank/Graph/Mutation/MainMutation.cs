using API_bank.Interfaces;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API_bank.Graph.Mutation
{
    public class MainMutation : ObjectGraphType
    {
        public MainMutation(IServiceProvider provider, IWebHostEnvironment env, IFieldService fieldService)
        {
            Name = "MainMutation";
            fieldService.ActivateFields(this, FieldServiceType.Mutation, env, provider);
        }
    }
}
