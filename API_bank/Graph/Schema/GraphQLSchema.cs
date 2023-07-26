using API_bank.Graph.Mutation;
using API_bank.Graph.Query;
using API_bank.Graph.Subscription;
using API_bank.Interfaces;
using GraphQL;

namespace API_bank.Graph.Schema
{
    public class GraphQLSchema : GraphQL.Types.Schema
    {
        public GraphQLSchema(IDependencyResolver resolver) : base(resolver)
        {
            var fieldService = resolver.Resolve<IFieldService>();
            fieldService.RegisterFields();
            Mutation = resolver.Resolve<MainMutation>();
            Query = resolver.Resolve<MainQuery>();
            Subscription = resolver.Resolve<MainSubscription>();
        }
    }
}
