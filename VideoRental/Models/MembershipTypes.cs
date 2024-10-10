namespace WebMvcPruebaMosh.Models
{
    public class MembershipTypes
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static readonly byte Uknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}
