using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DTOLayer.DTOs.DestinationDTOs
{
    public record GetCityByNameResultDTO(
        int DestinationId
        , string? City
        , string? DayNight
        , decimal Price
        , int Capacity);
   
}
