using System;

namespace DecoratorPattern.EnvioCorreo
{
    public class EnvioCorreoDecorator : ICuentaPorPagarService, IEnvioCorreoDecorator
    {
        private readonly ICuentaPorPagarService _guardarService;

        public EnvioCorreoDecorator(ICuentaPorPagarService guardarService)
        {
            _guardarService = guardarService;
        }

        public void GuardarCxP(CuentaPorPagar cuentaPorPagar)
        {
            _guardarService.GuardarCxP(cuentaPorPagar);
            EnviarCorreo(cuentaPorPagar);
        }

        public void EnviarCorreo(CuentaPorPagar cuentaPorPagar)
        {
            string mensaje = string.Format("Se envío un correo para la CxP: Id = {0}, Importe = {1}, Naturaleza = {2}",
                cuentaPorPagar.Id.ToString(), cuentaPorPagar.Importe.ToString(), Enum.GetName(typeof(Naturaleza), cuentaPorPagar.Naturaleza));
            Console.WriteLine(mensaje);
        }
    }
}
