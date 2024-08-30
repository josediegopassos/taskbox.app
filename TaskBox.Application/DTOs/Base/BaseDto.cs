using System.Text.Json.Serialization;
using TaskBox.Application.CustomAttributes;

namespace TaskBox.Application.DTOs.Base
{
    public class BaseDto
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        public BaseDto()
        {
        }
    }
}
