using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cimob.Models
{
    [JsonObject(IsReference = true)]
    public class ProgramByDestination
    {
        public List<Program> programs;
       
    }
}
