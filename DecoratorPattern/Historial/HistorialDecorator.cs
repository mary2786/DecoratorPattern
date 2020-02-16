using System;

namespace DecoratorPattern.Historial
{
    public class HistorialDecorator: ICuentaPorPagarService, IHistorialDecorator
    {
        private readonly ICuentaPorPagarService _guardarService;
        public HistorialDecorator(ICuentaPorPagarService guardarService)
        {
            _guardarService = guardarService;
        }

        public void GuardarCxP(CuentaPorPagar cuentaPorPagar)
        {
            _guardarService.GuardarCxP(cuentaPorPagar);
            GuardarHistorial(cuentaPorPagar);
        }

        public void GuardarHistorial(CuentaPorPagar cuentaPorPagar)
        {
            string mensaje = string.Format("Se guardó el historial de la CxP: Id = {0}, Importe = {1}, Naturaleza = {2}",
                cuentaPorPagar.Id.ToString(), cuentaPorPagar.Importe.ToString(), Enum.GetName(typeof(Naturaleza), cuentaPorPagar.Naturaleza));
            Console.WriteLine(mensaje);
        }
    }
}
