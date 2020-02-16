using System;

namespace DecoratorPattern
{
    public class CuentaPorPagarService : ICuentaPorPagarService
    {
        public void GuardarCxP(CuentaPorPagar cuentaPorPagar)
        {
            string mensaje = string.Format("Se guardó la CxP: Id = {0}, Importe = {1}, Naturaleza = {2}",
                cuentaPorPagar.Id.ToString(), cuentaPorPagar.Importe.ToString(), Enum.GetName(typeof(Naturaleza), cuentaPorPagar.Naturaleza));
            Console.WriteLine(mensaje);
        }
    }
}
