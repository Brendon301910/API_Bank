using API_bank.Graph.Type;
using API_bank.Interfaces;
using API_bank.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;

namespace API_bank.Graph.Mutation
{
    public class DepositarContaMutation : IFieldMutationServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ContaGType>("depositar",
            arguments: new QueryArguments(
               new QueryArgument<IntGraphType> { Name = "conta" },
               new QueryArgument<FloatGraphType> { Name = "valor" }
            ),
            resolve: context =>
            {

                var conta = context.GetArgument<int>("conta");
                var valor = context.GetArgument<double>("valor");
                var contaRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));
                var foundConta = contaRepository.GetByConta(conta);

                if (foundConta != null)
                {
                    foundConta.conta = conta;
                    foundConta.saldo += valor;
                }
                else
                {
                    throw new ExecutionError("Não existe esta conta");
                }

                return contaRepository.Update(foundConta);
            });
        }
    }
}