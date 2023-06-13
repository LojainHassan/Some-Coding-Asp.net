using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Dto
{
    public class EmailDto
    {

        [Key]
        public int emailId { get; set; }
        public int parentId { get; set; }
        public string subject { get; set; }
        public string frome { get; set; }

        public string text { get; set; }
        public DateTime date { get; set; }
        public bool isNew { get; set; }
        public bool hasAttachment { get; set; }


    }
}
