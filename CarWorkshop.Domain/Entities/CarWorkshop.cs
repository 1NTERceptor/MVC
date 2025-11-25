namespace CarWorkshop.Domain.Entities
{
    class CarWorkshop
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public CarWorkshopContactDetails ContactDetails { get; set; } = default!;
        public string EncodedName { get; private set; } = default!;
        public void EncodeName() => EncodedName = Name.ToLower().Replace(" ","-")
}
