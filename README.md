# Spectre vs MassTransit

Registering MT works fine and registering a `IHostedService` to send a message works fine. 

Adding in Spectre commands that take an `IBus` ctor dependency causes the below exception:

```
Spectre.Console.Extensions.Hosting.Worker.SpectreConsoleWorker[0]
      An unexpected error occurred
      Spectre.Console.Cli.CommandRuntimeException: Could not resolve type 'DeploySeederCommand'.
       ---> MassTransit.ConfigurationException: An exception occurred during bus creation
       ---> MassTransit.ConfigurationException: The ReceivePipeConfiguration can only be used once.
         at MassTransit.Configuration.ReceivePipeConfiguration.CreatePipe(IConsumePipe consumePipe, ISerialization serializers) in /_/src/MassTransit/Configuration/Configuration/ReceivePipeConfiguration.cs:line 36
         at MassTransit.Configuration.ReceiveEndpointConfiguration.CreateReceivePipe() in /_/src/MassTransit/Configuration/Configuration/ReceiveEndpointConfiguration.cs:line 93
         at System.Lazy`1.ViaFactory(LazyThreadSafetyMode mode)
         at System.Lazy`1.ExecutionAndPublication(LazyHelper executionAndPublication, Boolean useDefaultConstructor)
         at System.Lazy`1.CreateValue()
         at MassTransit.Transports.BaseReceiveEndpointContext.get_ReceivePipe() in /_/src/MassTransit/Transports/BaseReceiveEndpointContext.cs:line 122
         at MassTransit.Configuration.BaseHostConfiguration`2.ConnectReceiveEndpointContext(ReceiveEndpointContext context) in /_/src/MassTransit/Configuration/Configuration/BaseHostConfiguration.cs:line 73
         at MassTransit.Transports.BaseReceiveEndpointContext..ctor(IHostConfiguration hostConfiguration, IReceiveEndpointConfiguration configuration) in /_/src/MassTransit/Transports/BaseReceiveEndpointContext.cs:line 68
         at MassTransit.InMemoryTransport.TransportInMemoryReceiveEndpointContext..ctor(IInMemoryHostConfiguration hostConfiguration, IInMemoryReceiveEndpointConfiguration configuration) in /_/src/MassTransit/InMemoryTransport/InMemoryTransport/TransportInMemoryReceiveEndpointContext.cs:line 17
         at MassTransit.InMemoryTransport.Configuration.InMemoryReceiveEndpointBuilder.CreateReceiveEndpointContext() in /_/src/MassTransit/InMemoryTransport/InMemoryTransport/Configuration/InMemoryReceiveEndpointBuilder.cs:line 33
         at MassTransit.InMemoryTransport.Configuration.InMemoryReceiveEndpointConfiguration.CreateInMemoryReceiveEndpointContext() in /_/src/MassTransit/InMemoryTransport/InMemoryTransport/Configuration/InMemoryReceiveEndpointConfiguration.cs:line 79
         at MassTransit.InMemoryTransport.Configuration.InMemoryReceiveEndpointConfiguration.Build(IHost host) in /_/src/MassTransit/InMemoryTransport/InMemoryTransport/Configuration/InMemoryReceiveEndpointConfiguration.cs:line 48
         at MassTransit.InMemoryTransport.Configuration.InMemoryHostConfiguration.Build() in /_/src/MassTransit/InMemoryTransport/InMemoryTransport/Configuration/InMemoryHostConfiguration.cs:line 109
         at MassTransit.Configuration.TransportRegistrationBusFactory`1.CreateBus[T,TConfigurator](T configurator, IBusRegistrationContext context, Action`2 configure, IEnumerable`1 specifications) in /_/src/MassTransit/DependencyInjection/Configuration/TransportRegistrationBusFactory.cs:line 55
         --- End of inner exception stack trace ---
         at MassTransit.Configuration.TransportRegistrationBusFactory`1.CreateBus[T,TConfigurator](T configurator, IBusRegistrationContext context, Action`2 configure, IEnumerable`1 specifications) in /_/src/MassTransit/DependencyInjection/Configuration/TransportRegistrationBusFactory.cs:line 78
         at MassTransit.InMemoryTransport.Configuration.InMemoryRegistrationBusFactory.CreateBus(IBusRegistrationContext context, IEnumerable`1 specifications, String busName) in /_/src/MassTransit/InMemoryTransport/InMemoryTransport/Configuration/InMemoryRegistrationBusFactory.cs:line 33
         at MassTransit.Configuration.ServiceCollectionBusConfigurator.CreateBus[T](T busFactory, IServiceProvider provider) in /_/src/MassTransit/DependencyInjection/Configuration/ServiceCollectionBusConfigurator.cs:line 86
         at MassTransit.Configuration.ServiceCollectionBusConfigurator.<>c__DisplayClass3_0`1.<SetBusFactory>b__0(IServiceProvider provider) in /_/src/MassTransit/DependencyInjection/Configuration/ServiceCollectionBusConfigurator.cs:line 65
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitFactory(FactoryCallSite factoryCallSite, RuntimeResolverContext context)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitRootCache(ServiceCallSite callSite, RuntimeResolverContext context)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
         at Microsoft.Extensions.DependencyInjection.ServiceProvider.CreateServiceAccessor(Type serviceType)
         at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
         at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.ServiceProviderEngineScope.GetService(Type serviceType)
         at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService(IServiceProvider provider, Type serviceType)
         at Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService[T](IServiceProvider provider)
         at MassTransit.Configuration.ServiceCollectionBusConfigurator.<>c__3`1.<SetBusFactory>b__3_4(IServiceProvider provider) in /_/src/MassTransit/DependencyInjection/Configuration/ServiceCollectionBusConfigurator.cs:line 70
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitFactory(FactoryCallSite factoryCallSite, RuntimeResolverContext context)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitRootCache(ServiceCallSite callSite, RuntimeResolverContext context)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitConstructor(ConstructorCallSite constructorCallSite, RuntimeResolverContext context)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSiteMain(ServiceCallSite callSite, TArgument argument)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.VisitRootCache(ServiceCallSite callSite, RuntimeResolverContext context)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteVisitor`2.VisitCallSite(ServiceCallSite callSite, TArgument argument)
         at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteRuntimeResolver.Resolve(ServiceCallSite callSite, ServiceProviderEngineScope scope)
         at Microsoft.Extensions.DependencyInjection.ServiceProvider.CreateServiceAccessor(Type serviceType)
         at System.Collections.Concurrent.ConcurrentDictionary`2.GetOrAdd(TKey key, Func`2 valueFactory)
         at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType, ServiceProviderEngineScope serviceProviderEngineScope)
         at Microsoft.Extensions.DependencyInjection.ServiceProvider.GetService(Type serviceType)
         at Spectre.Console.Extensions.Hosting.Infrastructure.TypeResolver.Resolve(Type type)
         at Spectre.Console.Cli.TypeResolverAdapter.Resolve(Type type) in /_/src/Spectre.Console.Cli/Internal/TypeResolverAdapter.cs:line 21
         --- End of inner exception stack trace ---
         at Spectre.Console.Cli.TypeResolverAdapter.Resolve(Type type) in /_/src/Spectre.Console.Cli/Internal/TypeResolverAdapter.cs:line 36
         at Spectre.Console.Cli.CommandTree.CreateCommand(ITypeResolver resolver) in /_/src/Spectre.Console.Cli/Internal/Parsing/CommandTree.cs:line 27
         at Spectre.Console.Cli.CommandExecutor.Execute(CommandTree leaf, CommandTree tree, CommandContext context, ITypeResolver resolver, IConfiguration configuration) in /_/src/Spectre.Console.Cli/Internal/CommandExecutor.cs:line 136
         at Spectre.Console.Cli.CommandExecutor.Execute(IConfiguration configuration, IEnumerable`1 args) in /_/src/Spectre.Console.Cli/Internal/CommandExecutor.cs:line 85
         at Spectre.Console.Cli.CommandApp.RunAsync(IEnumerable`1 args) in /_/src/Spectre.Console.Cli/CommandApp.cs:line 84
         at Spectre.Console.Extensions.Hosting.Worker.SpectreConsoleWorker.<>c__DisplayClass5_0.<<StartAsync>b__0>d.MoveNext()

```