using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Features;

namespace ProtoService.ServiceOptions
{
    public class SalaryServer:IServer
    {
        private readonly Server _server;
        private int _stopped;
        
        /// <summary>---------------------------------------
        /// Salary Service Constructor
        /// </summary>--------------------------------------
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="serviceDefinitions"></param>
        public SalaryServer(string host, int port, ServerServiceDefinition serviceDefinitions)
        {
            _server = new Server
            {
                Services =
                {
                    serviceDefinitions
                },
                Ports = {new ServerPort(host, port, ServerCredentials.Insecure)}
            };
            Features=new FeatureCollection();
            Features.Set<IServerAddressesFeature>(new ServerAddressesFeature{Addresses = {$"http://{host}:{port}"}});
        }
       
        /// <summary>---------------------------------------
        ///  Stop server and released resources
        /// </summary>--------------------------------------
        public void Dispose()
        {
            CancellationTokenSource cancellationTokenSource=new CancellationTokenSource();
            cancellationTokenSource.Cancel();
            StopAsync(cancellationTokenSource.Token).GetAwaiter().GetResult();
            Console.WriteLine("Server Stopped");
        }

        /// <summary>----------------------------------------
        /// Start GRPC Server Asynchronously
        /// </summary>---------------------------------------
        /// <param name="application"></param>
        /// <param name="cancellationToken"></param>
        /// <typeparam name="TContext"></typeparam>
        /// <returns></returns>
        public async Task StartAsync<TContext>(IHttpApplication<TContext> application, CancellationToken cancellationToken)
        {
            await Task.Run(() => _server.Start(), cancellationToken).ConfigureAwait(false);
        }
        /// <summary>-----------------------------------------
        ///  Stop Server
        /// </summary>----------------------------------------
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (Interlocked.Exchange(ref this._stopped, 1) == 1)
                return;
            await _server.ShutdownAsync();
        }

        public IFeatureCollection Features { get; }
        /// <summary>-----------------------------------------
        /// Start Server Synchronously
        /// </summary>----------------------------------------
        public void Start()
        {
            _server.Start();
            Console.WriteLine("GRPC server listening");
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();
        }
    }
}