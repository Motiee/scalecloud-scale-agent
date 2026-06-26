using scalecloud_scale_agent.Events;

namespace scalecloud_scale_agent.Events.Interfaces
{
    public interface IEventHandler<T>
        where T : ScaleEvent
    {
        void Handle(T @event);
    }
}