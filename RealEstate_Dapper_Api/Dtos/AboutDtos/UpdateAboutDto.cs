﻿namespace RealEstate_Dapper_Api.Dtos.AboutDtos
{
    public class UpdateAboutDto
    {
        public int WhoWeAreDetailID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
    }
}
