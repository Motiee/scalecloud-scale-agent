using scalecloud_scale_agent.Events.Interfaces;
using System;
using System.Collections.Generic;

namespace scalecloud_scale_agent.Events
{
    public class EventBus : IEventBus
    {
        private readonly object _sync = new object();

        private readonly Dictionary<Type, List<object>>
            _handlers =
                new Dictionary<Type, List<object>>();

        public void Publish<T>(T @event)
            where T : ScaleEvent
        {
            List<object> handlers = null;

            lock (_sync)
            {
                if (_handlers.TryGetValue(typeof(T), out var list))
                {
                    handlers = new List<object>(list);
                }
            }

            if (handlers == null)
                return;

            foreach (var item in handlers)
            {
                try
                {
                    ((IEventHandler<T>)item).Handle(@event);
                }
                catch (Exception)
                {
                    // TODO:
                    // Logger
                }
            }
        }

        public void Subscribe<T>(
            IEventHandler<T> handler)
            where T : ScaleEvent
        {
            lock (_sync)
            {
                if (!_handlers.ContainsKey(typeof(T)))
                {
                    _handlers[typeof(T)] =
                        new List<object>();
                }

                _handlers[typeof(T)].Add(handler);
            }
        }

        public void Unsubscribe<T>(
            IEventHandler<T> handler)
            where T : ScaleEvent
        {
            lock (_sync)
            {
                if (_handlers.TryGetValue(typeof(T), out var list))
                {
                    list.Remove(handler);
                }
            }
        }
    }
}