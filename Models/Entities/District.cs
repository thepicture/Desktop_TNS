//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TelekomNevaSvyazWpfApp.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class District
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal AreaInSquareMeters { get; set; }
        public long CountOfPeople { get; set; }
        public int CountOfSubways { get; set; }
        public int BuildingTypeId { get; set; }
    
        public virtual DistrictBuildingType DistrictBuildingType { get; set; }
    }
}