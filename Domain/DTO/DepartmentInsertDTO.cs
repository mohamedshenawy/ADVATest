namespace Domain.DTO
{
    public class DepartmentInsertDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? DepartmentManagerId { get; set; }
    }
}
