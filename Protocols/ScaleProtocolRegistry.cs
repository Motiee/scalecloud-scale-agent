using scalecloud_scale_agent.Protocols.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace scalecloud_scale_agent.Protocols
{
    public static class ScaleProtocolRegistry
    {
        private static readonly Dictionary<string, Type> _protocols;

        static ScaleProtocolRegistry()
        {
            _protocols = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    typeof(IScaleProtocol).IsAssignableFrom(t) &&
                    !t.IsInterface &&
                    !t.IsAbstract)
                .Select(t => (IScaleProtocol)Activator.CreateInstance(t))
                .ToDictionary(
                    p => p.Id,
                    p => p.GetType());
        }

        public static IReadOnlyList<IScaleProtocol> GetProtocols()
        {
            return _protocols.Values
                .Select(t => (IScaleProtocol)Activator.CreateInstance(t))
                .OrderBy(p => p.DisplayName)
                .ToList();
        }

        public static IScaleProtocol Create(string id)
        {
            if (!_protocols.TryGetValue(id, out var type))
                throw new Exception($"Unknown protocol : {id}");

            return (IScaleProtocol)Activator.CreateInstance(type);
        }
    }
}