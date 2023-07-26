using API_bank.Graph.Type;
using API_bank.Interfaces;
using API_bank.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API_bank.Graph.Mutation
{
    public class SacarContaMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ContaGType>("sacar",
            arguments: new QueryArguments(
               new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
               new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "valor" }

            ),
            resolve: context =>
            {

                var conta = context.GetArgument<int>("conta");
                var valor = context.GetArgument<double>("valor");

                var contaRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));
                var foundConta = contaRepository.GetByConta(conta);

                if (foundConta == null)
                {
                    throw new ExecutionError("Esta conta nao existe");
                }
                if (valor > foundConta.saldo)
                {
                    throw new ExecutionError($"Saque maior que seu saldo, Seu saldo é: {foundConta.saldo}");
                }
                else
                {
                    foundConta.conta = conta;
                    foundConta.saldo -= valor;
                }

                return contaRepository.Update(foundConta);
            });
        }
    }
}