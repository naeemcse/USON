using Autofac;

public class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        // Register your services here
        // Example:
        // builder.RegisterType<MyService>().As<IMyService>().InstancePerLifetimeScope();
    }
}
