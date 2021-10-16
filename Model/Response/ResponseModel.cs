
using System.Collections.Generic;

namespace EarthQuake.Model{
    public record ResponseModel(bool IsSuccess, string Message, List<Feature> Data=null);
}