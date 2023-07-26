using API_bank.Dto;
using System.Reactive.Subjects;

namespace API_bank.Services
{
    public class ContaAddedService
    {
        private readonly ISubject<ContaAddedMensage> _messageStream = new ReplaySubject<ContaAddedMensage>(1);
        public ContaAddedMensage AddContaAddedMessage(ContaAddedMensage message)
        {
            _messageStream.OnNext(message);
            return message;
        }
    }
}
