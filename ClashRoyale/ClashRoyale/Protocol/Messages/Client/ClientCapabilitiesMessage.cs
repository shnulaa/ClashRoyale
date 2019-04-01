﻿using ClashRoyale.Extensions;
using ClashRoyale.Logic;
using DotNetty.Buffers;
using SharpRaven.Data;

namespace ClashRoyale.Protocol.Messages.Client
{
    public class ClientCapabilitiesMessage : PiranhaMessage
    {
        public ClientCapabilitiesMessage(Device device, IByteBuffer buffer) : base(device, buffer)
        {
            Id = 10107;
        }

        public int Ping { get; set; }
        public string ConnectionInterface { get; set; }

        public override void Decode()
        {
            Ping = Reader.ReadVInt();
            ConnectionInterface = Reader.ReadScString();
        }

        public override void Process()
        {
            if (Ping >= 500)
            {
                Logger.Log($"High latency! Ping: {Ping}.", GetType(), ErrorLevel.Warning);
            }
        }
    }
}