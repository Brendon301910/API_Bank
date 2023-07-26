using API_bank.Graph.Type;
using API_bank.Interfaces;
using API_bank.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API_bank.Graph.Mutation
{
    public class AddContaMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ContaGType>("adicionarconta",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
               new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "saldo" }
            ),
            resolve: (Func<ResolveFieldContext<object>, object>)(context =>
            {
                var conta = context.GetArgument<int>("conta");
                var saldo = context.GetArgument<double>("saldo");

                var contaRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));
                var saldoRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));

                var foundConta = contaRepository.GetByConta(conta);

                if (foundConta != null)
                {
                    throw new ExecutionError("Essa conta já existe.");
                }

                var newConta = new Conta
                {
                    conta = conta,
                    saldo = saldo
                };

                var addedConta = contaRepository.Insert(newConta);

                return addedConta;

            }));
        }
    }
}
