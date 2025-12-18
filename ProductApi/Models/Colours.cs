namespace ProductApi.Models
{
    public class GetColours
    {
        public int ColNo { get; set; }
        public string ColName { get; set; }
    }

    public class CreateColour
    {
        public string ColName { get; set; }
    }
}
