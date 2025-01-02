namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int SQ_ProductID { get; set; }
        public string CD_Title { get; set; }
        public string DC_Price { get; set;}
        public string CD_City { get; set;}
        public string CD_District { get; set;}
        public int RF_ProductCategory {  get; set;}
    }
}
