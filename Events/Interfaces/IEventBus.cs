using scalecloud_scale_agent.Events;

namespace scalecloud_scale_agent.Events.Interfaces
{
    public interface IEventBus
    {
        void Publish<T>(T @event)
            where T : ScaleEvent;

        void Subscribe<T>(IEventHandler<T> handler)
            where T : ScaleEvent;

        void Unsubscribe<T>(IEventHandler<T> handler)
            where T : ScaleEvent;
    }
}