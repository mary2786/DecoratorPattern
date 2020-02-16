using DecoratorPattern.EnvioCorreo;

namespace DecoratorPattern
{
    public class HistorialEnvioCorreoDecorator: ICuentaPorPagarService, IEnvioCorreoDecorator
    {
        private readonly ICuentaPorPagarService _guardarService;
        private readonly IEnvioCorreoDecorator _envioCorreoDecorator;
        public HistorialEnvioCorreoDecorator(ICuentaPorPagarService guardarService, IEnvioCorreoDecorator envioCorreoDecorator)
        {
            _guardarService = guardarService;
            _envioCorreoDecorator = envioCorreoDecorator;
        }

        public void GuardarCxP(CuentaPorPagar cuentaPorPagar)
        {
            _guardarService.GuardarCxP(cuentaPorPagar);
            EnviarCorreo(cuentaPorPagar);
        }

        public void EnviarCorreo(CuentaPorPagar cuentaPorPagar)
        {
            _envioCorreoDecorator.EnviarCorreo(cuentaPorPagar);
        }
    }
}
