#if DEBUG // Ensure this never leaves debug stages.
using System.Reflection;
using System.Reflection.Emit;

using Javax.Net.Ssl;
using Xamarin.Android.Net;

namespace LCPFavThings.Platforms.Android;

public static class DangerousAndroidMessageHandlerEmitter
{
    #nullable enable

    private const string NAME = "DangerousAndroidMessageHandler";

    private static Assembly? EmittedAssembly { get; set; } = null;

    public static void Register(string handlerName = NAME, string assemblyName = NAME) =>
      AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        assemblyName.Equals(args.Name)
          ? (EmittedAssembly ??= Emit(handlerName, assemblyName))
          : null;

    private static AssemblyBuilder Emit(string handlerName, string assemblyName)
    {
        var assembly = AssemblyBuilder.DefineDynamicAssembly(
          new AssemblyName(assemblyName), AssemblyBuilderAccess.Run);
        var builder = assembly.DefineDynamicModule(assemblyName)
                              .DefineType(handlerName, TypeAttributes.Public);
        builder.SetParent(typeof(AndroidMessageHandler));
        builder.DefineDefaultConstructor(MethodAttributes.Public);

        var generator = builder.DefineMethod(
                                 "GetSSLHostnameVerifier",
                                 MethodAttributes.Public | MethodAttributes.Virtual,
                                 typeof(IHostnameVerifier),
                                 new[] { typeof(HttpsURLConnection) })
                               .GetILGenerator();
        generator.Emit(
          OpCodes.Call,
          typeof(DangerousHostNameVerifier)
            .GetMethod(nameof(DangerousHostNameVerifier.Create))!);
        generator.Emit(OpCodes.Ret);

        builder.CreateType();

        return assembly;
    }

    public class DangerousHostNameVerifier : Java.Lang.Object, IHostnameVerifier
    {
        public bool Verify(string? hostname, ISSLSession? session) => true;

        public static IHostnameVerifier Create() => new DangerousHostNameVerifier();
    }
}
#endif