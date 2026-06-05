using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Adapter is a structural design pattern, 
 * which allows incompatible objects to collaborate.
 */
namespace CSharpPractice.DesignPatterns.StructuralPatterns.Adapter
{
   

    public class LegacyBankApi
    {
        public void MakeBankTransfer(double value)
        {
            Console.WriteLine($"Processing bank transfer of {value}");
        }
    }
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    public class LegacyBankApiAdapter : IPaymentProcessor
    {
        private readonly LegacyBankApi _legacyBankApi;

        public LegacyBankApiAdapter(LegacyBankApi legacyBankApi)
        {
            _legacyBankApi = legacyBankApi;
        }

        public void ProcessPayment(decimal amount)
        {
            //Convert decimal to double if needed
            _legacyBankApi.MakeBankTransfer((double)amount);
        }
    }

    public class PaymentService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        public PaymentService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor;
        }

        public void MakePayment(decimal amount)
        {
            _paymentProcessor.ProcessPayment(amount);
        }
    }

    public class AdapterClient
    {
        public static void Test()
        {
            Console.WriteLine(":::Adapter Pattern Test:::");
            var legacyApi = new LegacyBankApi();
            IPaymentProcessor paymentProcessor = new LegacyBankApiAdapter(legacyApi);

            var paymentService = new PaymentService(paymentProcessor);
            paymentService.MakePayment(150.75m);

            Console.WriteLine();
        }
    }

}
