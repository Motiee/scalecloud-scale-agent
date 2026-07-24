using scalecloud_scale_agent.Protocols.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace scalecloud_scale_agent.Protocols
{
    public static class ScaleProtocolRegistry
    {
        private static readonly Dictionary<string, Type>
            _protocols =
                new Dictionary<string, Type>(
                    StringComparer.OrdinalIgnoreCase);

        static ScaleProtocolRegistry()
        {
            RegisterAllProtocols();
        }

        private static void RegisterAllProtocols()
        {
            Assembly assembly =
                typeof(ScaleProtocolRegistry).Assembly;

            var protocolTypes =
                assembly
                    .GetTypes()
                    .Where(t =>
                        !t.IsAbstract &&
                        typeof(IScaleProtocol)
                            .IsAssignableFrom(t));

            foreach (Type type in protocolTypes)
            {
                IScaleProtocol protocol =
                    (IScaleProtocol)
                    Activator.CreateInstance(type);

                if (_protocols.ContainsKey(protocol.Id))
                {
                    throw new InvalidOperationException(
                        $"Duplicate Protocol Id: {protocol.Id}");
                }

                _protocols.Add(
                    protocol.Id,
                    type);
            }
        }

        public static IScaleProtocol Create(
            string protocolId)
        {
            if (string.IsNullOrWhiteSpace(protocolId))
            {
                throw new ArgumentException(
                    "ProtocolId is empty.",
                    nameof(protocolId));
            }

            if (!_protocols.TryGetValue(
                protocolId,
                out Type type))
            {
                throw new InvalidOperationException(
                    $"Protocol '{protocolId}' not found.");
            }

            return (IScaleProtocol)
                Activator.CreateInstance(type);
        }

        public static IReadOnlyList<IScaleProtocol> GetAll()
        {
            return _protocols
                .Values
                .Select(t =>
                    (IScaleProtocol)
                    Activator.CreateInstance(t))
                .ToList();
        }
    }
}