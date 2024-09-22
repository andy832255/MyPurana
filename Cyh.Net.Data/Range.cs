using System.Text.Json.Serialization;

namespace Cyh.Net.Data
{
    public class Range<T>
    {
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        [JsonPropertyName("begin")]
        public T Begin { get; set; }

        [JsonPropertyName("count")]
        public T Count { get; set; }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    }
}
