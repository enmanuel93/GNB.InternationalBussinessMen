using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GNB.Domain.Entities.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
    }
}
