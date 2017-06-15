﻿using AwesomeSockets.Domain.Sockets;
using AwesomeSockets.Sockets;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using TeamCoding.Options;
using ASBuffer = AwesomeSockets.Buffers.Buffer;

namespace TeamCoding.VisualStudio.Models.ChangePersisters.ChangePropagationServerPersister
{
    public class ChangePropagationServerClient : IDisposable
    {
        public class MessageReceivedEventArgs : EventArgs { public byte[] Message; }

        private ISocket Socket;
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;
        private readonly SettingProperty<string> IPAddressSetting;
        private CancellationTokenSource CancelTokenSource;
        private CancellationToken CancelToken;
        private Task ListenTask;
        public ChangePropagationServerClient(SettingProperty<string> ipAddressSetting)
        {
            IPAddressSetting = ipAddressSetting;
            IPAddressSetting.Changed += IpAddressSetting_Changed;
            ListenTask = ListenAsync();
        }
        private void IpAddressSetting_Changed(object sender, EventArgs e)
        {
            Disconnect();
            ListenTask = ListenAsync();
        }
        private Task ListenAsync()
        {
            CancelTokenSource = new CancellationTokenSource();
            CancelToken = CancelTokenSource.Token;
            var listenTask = ListenInternalAsync();

            return listenTask;
        }
        private async Task ListenInternalAsync()
        {
            try
            {
                if (await IPAddressSetting.IsValidAsync())
                {
                    Socket = AweSock.TcpConnect(IPAddressSetting.Value.Split(':')[0], int.Parse(IPAddressSetting.Value.Split(':')[1]));

                    ListenForMessages(Socket);
                }
            }
            catch (SocketException)
            {
                await Task.Delay(1000);
                if (!CancelToken.IsCancellationRequested)
                {
                    // TODO: Handle socket exception (try and re-connect after a while?)
                }
            }
        }
        private void ListenForMessages(ISocket socket)
        {
            var callbackFired = new ManualResetEventSlim(false);
            var receiveBuffer = ASBuffer.New();
            while (!CancelToken.IsCancellationRequested)
            {
                ASBuffer.ClearBuffer(receiveBuffer);
                Tuple<int, EndPoint> result = null;
                try
                {
                    AweSock.ReceiveMessage(socket, receiveBuffer, AwesomeSockets.Domain.SocketCommunicationTypes.NonBlocking, (b, endPoint) =>
                    {
                        result = new Tuple<int, EndPoint>(b, endPoint); callbackFired.Set();
                    });
                }
                catch (ArgumentOutOfRangeException)
                { // Swallow the exception caused by AweSock's construction of an invalid endpoint

                }
                try
                {
                    callbackFired.Wait(CancelToken);
                }
                catch (OperationCanceledException)
                {

                }
                if (!CancelToken.IsCancellationRequested)
                {
                    callbackFired.Reset();
                    ASBuffer.FinalizeBuffer(receiveBuffer);
                    if (result.Item1 == 0) return;

                    var length = ASBuffer.Get<short>(receiveBuffer);
                    var bytes = new byte[length];
                    ASBuffer.BlockCopy(ASBuffer.GetBuffer(receiveBuffer), sizeof(short), bytes, 0, length);
                    MessageReceived?.Invoke(this, new MessageReceivedEventArgs() { Message = bytes });
                }
            }
        }
        public void SendModel(RemoteIDEModel model)
        {
            if (Socket != null)
            {
                using (var ms = new MemoryStream())
                {
                    ProtoBuf.Serializer.Serialize(ms, model);

                    var buffer = ASBuffer.New((int)ms.Length + sizeof(short));
                    ASBuffer.ClearBuffer(buffer);
                    // TODO: Remove AwesomeSocket and roll my own or find another because of crap like this
                    ASBuffer.Add(buffer, BitConverter.GetBytes((short)ms.Length).Concat(ms.ToArray()).ToArray());
                    ASBuffer.FinalizeBuffer(buffer);
                    try
                    {
                        Socket.SendMessage(buffer);
                    }
                    catch (Exception ex)
                    {
                        TeamCodingPackage.Current.Logger.WriteError(ex);
                    }
                }
            }
        }
        public static Task<string> GetIPSettingErrorText(string ipSetting)
        {
            if (ipSetting == null)
            {
                return Task.FromResult("No IP address given");
            }

            var split = ipSetting.Split(':');

            if (split.Length != 2)
            {
                return Task.FromResult("Port missing, use the format IPAddress:Port");
            }
            if (!IPAddress.TryParse(split[0], out var tmpIP))
            {
                return Task.FromResult("IP address could not be parsed");
            }
            if (!int.TryParse(split[1], out int port))
            {
                return Task.FromResult("Port could not be parsed");
            }
            if (port < IPEndPoint.MinPort || port > IPEndPoint.MaxPort)
            {
                return Task.FromResult($"Port out of expected range ({IPEndPoint.MinPort} - {IPEndPoint.MaxPort})");
            }

            // TODO: Actually do a test send/receive for testing the win service setting
            return Task.FromResult<string>(null);

        }
        private void Disconnect()
        {
            Socket?.Close();
            CancelTokenSource.Cancel();
            ListenTask?.Wait();
        }
        public void Dispose()
        {
            Disconnect();
            IPAddressSetting.Changed -= IpAddressSetting_Changed;
        }
    }
}