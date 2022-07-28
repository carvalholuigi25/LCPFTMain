#if DEBUG // Ensure this never leaves debug stages.
using Java.Net;
using Java.Security;
using Java.Security.Cert;
using Javax.Net.Ssl;

namespace LCPFavThings.Platforms.Android;

public class DangerousTrustProvider : Provider
{
    #nullable enable

    private const string DANGEROUS_ALGORITHM = nameof(DANGEROUS_ALGORITHM);

    // NOTE: Empty ctor, i. e. without Put(), works for me as well,
    // but I'll keep it for the sake of completeness.
    public DangerousTrustProvider()
      : base(nameof(DangerousTrustProvider), 1, "Dangerous debug TrustProvider") =>
      Put(
        $"{nameof(DangerousTrustManagerFactory)}.{DANGEROUS_ALGORITHM}",
        Java.Lang.Class.FromType(typeof(DangerousTrustManagerFactory)).Name);

    public static void Register()
    {
        if (Security.GetProvider(nameof(DangerousTrustProvider)) is null)
        {
            Security.InsertProviderAt(new DangerousTrustProvider(), 1);
            Security.SetProperty(
              $"ssl.{nameof(DangerousTrustManagerFactory)}.algorithm", DANGEROUS_ALGORITHM);
        }
    }

    public class DangerousTrustManager : X509ExtendedTrustManager
    {
        public override void CheckClientTrusted(X509Certificate[]? chain, string? authType) { }
        public override void CheckClientTrusted(X509Certificate[]? chain, string? authType,
          Socket? socket)
        { }
        public override void CheckClientTrusted(X509Certificate[]? chain, string? authType,
          SSLEngine? engine)
        { }
        public override void CheckServerTrusted(X509Certificate[]? chain, string? authType) { }
        public override void CheckServerTrusted(X509Certificate[]? chain, string? authType,
          Socket? socket)
        { }
        public override void CheckServerTrusted(X509Certificate[]? chain, string? authType,
          SSLEngine? engine)
        { }
        public override X509Certificate[] GetAcceptedIssuers() =>
          Array.Empty<X509Certificate>();
    }

    public class DangerousTrustManagerFactory : TrustManagerFactorySpi
    {
        protected override ITrustManager[] EngineGetTrustManagers() =>
          new[] { new DangerousTrustManager() };

        protected override void EngineInit(IManagerFactoryParameters? parameters) { }

        protected override void EngineInit(KeyStore? store) { }
    }
}
#endif