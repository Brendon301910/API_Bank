using API_bank.Models;
using GraphQL.Types;
using System;

namespace API_bank.Graph.Type
{
    public class ContaGType : ObjectGraphType<Conta>
    {
        public IServiceProvider Provider { get; set; }
        public ContaGType(IServiceProvider provider)
        {
            Field(x => x.conta, type: typeof(IntGraphType));
            Field(x => x.saldo, type: typeof(FloatGraphType));

        }
    }
}
