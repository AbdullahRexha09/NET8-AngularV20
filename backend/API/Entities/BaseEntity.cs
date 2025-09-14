namespace API.Models
{
    public abstract class BaseEntity: Auditable
    {
        public int Id { get; set; }
        public bool IsDel { get; set; }
    }
}
