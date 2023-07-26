using API_bank.Graph.Type;
using API_bank.Interfaces;
using API_bank.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;

namespace API_bank.Graph.Query.ContaCorrente
{
    public class ContaQuery : IFieldQueryServiceItem
    {
        public void Activate(ObjectGraphType objectGraph, IWebHostEnvironment env, IServiceProvider sp)
        {
            objectGraph.Field<ListGraphType<ContaGType>>("saldo",
               arguments: new QueryArguments(
                 new QueryArgument<IntGraphType> { Name = "conta" }
               ),
               resolve: context =>
               {
                   var contaRepository = (IGenericRepository<Conta>)sp.GetService(typeof(IGenericRepository<Conta>));
                   var baseQuery = contaRepository.GetAll();
                   int conta = context.GetArgument<int>("conta");
                   var foundConta = contaRepository.GetByConta(conta);

                   if (conta != default)
                   {
                       if (foundConta == null)
                       {
                           throw new ExecutionError("Essa conta não existe.");
                       }
                       return baseQuery.Where(w => w.conta.Equals(conta));
                   }
                   else
                   {
                       return baseQuery.ToList();
                   }
               });
        }
    }
}
