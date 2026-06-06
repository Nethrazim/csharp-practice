namespace CSharpPractice.DesignPatterns.StructuralPatterns.Proxy
{
    public interface IService
    {
        void Operation();
    }

    public class Service : IService
    {
        public void Operation()
        {
            Console.WriteLine("Service Operation()");
        }
    }

    public class ProxyService : IService
    {
        private IService _service;
        public ProxyService(IService service) => _service = service;

        public void Operation()
        {
            Console.WriteLine("Do some more things before the actual service operation");
            _service.Operation();
        }
    }

    public class ServiceClient
    {
        private IService _service;
        public ServiceClient(IService service) => _service = service;

        public void Do()
        {
            _service.Operation();
        }
    }

    public class ProxyClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Proxy Test:::");

            IService service = new Service();
            IService proxyService = new ProxyService(service);

            ServiceClient clientService = new(service);
            clientService.Do();

            ServiceClient proxyClientService = new(proxyService);
            proxyClientService.Do();

            Console.WriteLine();
        }
    }
}
