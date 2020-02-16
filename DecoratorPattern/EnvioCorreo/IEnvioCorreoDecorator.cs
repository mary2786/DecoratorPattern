namespace DecoratorPattern.EnvioCorreo
{
    public interface IEnvioCorreoDecorator
    {
        void EnviarCorreo(CuentaPorPagar cuentaPorPagar);
    }
}
