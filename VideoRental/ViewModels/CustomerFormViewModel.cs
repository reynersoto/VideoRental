using System.ComponentModel.DataAnnotations;
using WebMvcPruebaMosh.Models;

namespace WebMvcPruebaMosh.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }
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
        [Display(Name = "Suscribed to Newsletter")]
        public bool isSubscribeToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypesId { get; set; }

        [Display(Name = "Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
        public string PageTitle
        {
            get
            {
                return (Id != 0) ? "Edit Movie" : "New Movie";
            }
        }
        public CustomerFormViewModel()
        {
            Id = 0;
        }
        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            LastName = customer.LastName;
            Email = customer.Email;
            Phone = customer.Phone;
            Extension = customer.Extension;
            Address = customer.Address;
            City = customer.City;
            Region = customer.Region;
            Country = customer.Country;
            PostalCode = customer.PostalCode;
            Birthday = customer.Birthday;
            MembershipTypesId = customer.MembershipTypesId;
            isSubscribeToNewsletter = customer.isSubscribeToNewsletter;
        }
    }
}
