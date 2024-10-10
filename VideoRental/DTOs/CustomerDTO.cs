using System.ComponentModel.DataAnnotations;
using WebMvcPruebaMosh.Models;

namespace WebMvcPruebaMosh.DTOs
{
    public class CustomerDTO
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; }

        [StringLength(200)]
        [Required]
        public string Address { get; set; }

        [StringLength(500)]
        [Required]
        public string City { get; set; }

        [StringLength(100)]
        [Required]
        public string Region { get; set; }

        [StringLength(100)]
        public string PostalCode { get; set; }

        [StringLength(100)]
        [Required]
        public string Country { get; set; }

        [StringLength(100)]
        [Required]
        [Phone]
        public string Phone { get; set; }

        [StringLength(15)]
        public string Extension { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }
        public bool isSubscribeToNewsletter { get; set; }
        public MembershipTypeDTO MembershipTypes { get; set; }
        public byte MembershipTypesId { get; set; }

       public DateTime? Birthday { get; set; }
    }
}
