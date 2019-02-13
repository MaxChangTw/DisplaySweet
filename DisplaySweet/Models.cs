using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace DisplaySweet
{
    public class Navigation
    {
        [Key]
        [JsonIgnore]
        public string Id { get; set; }
        
        public int Index { get; set; }

        public string Type { get; set; }

        [JsonIgnore]
        public virtual ICollection<Child> Children { get; set; }
    }

    public class Child
    {
        [Key]
        [JsonIgnore]
        public string Id { get; set; }

        public int? Index { get; set; }

        public string ParentId { get; set; }

        public string Template { get; set; }

        public string Type { get; set; }

        [JsonIgnore]
        public string NavigationId { get; set; }

        [JsonIgnore]
        public virtual Navigation Navigation { get; set; }
    }

    public class Component
    {
        [Key]
        public string Id { get; set; }

        public string CompanyLogo { get; set; }

        public string MainImage { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Data> Data { get; set; }
    }

    public class Data
    {
        public string Id { get; set; }

        public string Asset { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Caption> Captions { get; set; }

        public virtual ICollection<Style> Styles { get; set; }

        [JsonIgnore]
        public string ComponentId { get; set; }

        [JsonIgnore]
        public virtual Component Component { get; set; }
    }

    public class Caption
    {
        [JsonIgnore]
        public string Id { get; set; }

        public string Language_0 { get; set; }

        public string Language_1 { get; set; }

        [JsonIgnore]
        public string DataId { get; set; }

        [JsonIgnore]
        public virtual Data Data { get; set; }

        [JsonIgnore]
        public string ComponentId { get; set; }

        [JsonIgnore]
        public virtual Component Component { get; set; }
    }

    public class Style
    {
        [JsonIgnore]
        public string Id { get; set; }

        public string Asset { get; set; }

        [InverseProperty("Style")]
        public virtual ICollection<Name> Names { get; set; }

        [JsonIgnore]
        public string DataId { get; set; }

        [JsonIgnore]
        public virtual Data Data { get; set; }

        [JsonIgnore]
        public string ComponentId { get; set; }

        [JsonIgnore]
        public virtual Component Component { get; set; }
    }

    public class Name
    {
        [JsonIgnore]
        public string Id { get; set; }

        public string Language_0 { get; set; }

        public string Language_1 { get; set; }

        [JsonIgnore]
        public string StyleId { get; set; }

        [JsonIgnore]
        public virtual Style Style { get; set; }

        [JsonIgnore]
        public string DataId { get; set; }

        [JsonIgnore]
        public virtual Data Data { get; set; }

        [JsonIgnore]
        public string ComponentId { get; set; }

        [JsonIgnore]
        public virtual Component Component { get; set; }
    }
}
