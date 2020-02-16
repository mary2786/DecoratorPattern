using DecoratorPattern.EnvioCorreo;
using DecoratorPattern.Historial;
using System;

namespace DecoratorPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            CuentaPorPagar cuentaPorPagar = new CuentaPorPagar()
            {
                Id = 1,
                Importe = 1003.64,
                Naturaleza = Naturaleza.Acreedora
            };

            Console.WriteLine("----- Guardar una de CXP -----");
            ICuentaPorPagarService guardarService = new CuentaPorPagarService();
            guardarService.GuardarCxP(cuentaPorPagar);
            Console.WriteLine("\t");

            Console.WriteLine("----- Guardar un historial al guardar una CXP -----");
            ICuentaPorPagarService guardarService2 = new CuentaPorPagarService();
            ICuentaPorPagarService historial = new HistorialDecorator(guardarService2);
            historial.GuardarCxP(cuentaPorPagar);
            Console.WriteLine("\t");

            Console.WriteLine("----- Enviar un correo a un usuario al guardar una CXP -----");
            ICuentaPorPagarService guardarService3 = new CuentaPorPagarService();
            ICuentaPorPagarService envioCorreo = new EnvioCorreoDecorator(guardarService3);
            envioCorreo.GuardarCxP(cuentaPorPagar);
            Console.WriteLine("\t");

            Console.WriteLine("----- Guardar un historial y enviar un correo a un usuario al guardar una CXP -----");
            ICuentaPorPagarService guardarService4 = new CuentaPorPagarService();
            ICuentaPorPagarService historial2 = new HistorialDecorator(guardarService4);
            IEnvioCorreoDecorator envioCorreo2 = new EnvioCorreoDecorator(guardarService3);
            ICuentaPorPagarService HistorialEnvioCorreo  = new HistorialEnvioCorreoDecorator(historial2, envioCorreo2);

            HistorialEnvioCorreo.GuardarCxP(cuentaPorPagar);
            Console.WriteLine("\t");
        }
    }
}