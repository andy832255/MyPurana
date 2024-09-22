namespace MyPurana.Data.DataAnnotation
{
    public class BaDeserializeAttribute : Attribute
    {
        public string JsonValue { get; protected set; }
        public BaDeserializeAttribute(string _jsonStr)
        {
            this.JsonValue = _jsonStr;
        }
    }
}
