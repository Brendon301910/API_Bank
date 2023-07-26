using API_bank.Interfaces;
using API_bank.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API_bank.Graph.Mutation
{
    public class DeleteContaMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<IntGraphType>("deletarconta",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" }
            ),
            resolve: context =>
            {
                var conta = context.GetArgument<int>("conta");
                var contaRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));
                var foundConta = contaRepository.GetByConta(conta);

                if (foundConta == null)
                {
                    throw new ExecutionError("Conta inexistente.");
                }

                return contaRepository.Delete(conta);
            });
        }
    }
}
