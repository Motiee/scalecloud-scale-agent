using scalecloud_scale_agent.Events.Interfaces;
using scalecloud_scale_agent.Model;

namespace scalecloud_scale_agent.Events
{
    public class WeightReceivedEvent : ScaleEvent
    {
        public ScaleChannelId ChannelId { get; }

        public ScaleData Data { get; }

        public WeightReceivedEvent(
            ScaleChannelId channelId,
            ScaleData data)
        {
            ChannelId = channelId;
            Data = data;
        }
    }
}