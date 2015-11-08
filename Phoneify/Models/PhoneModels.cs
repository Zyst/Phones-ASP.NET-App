using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Phoneify.Models
{
    /// <summary>
    /// Phone class. Represents a phone number. A user can have 'N' Phone numbers.
    /// </summary>
    public class Phone
    {
        [Required]
        public virtual int PhoneId { get; set; }

        /// <summary>
        /// The Username, should be bound server-side to User.Identity.Name .
        /// 
        /// This should never be touched by the end-user. If the end-user can touch this in any way, shape, or form, it should be considered a vulnerability.
        /// </summary>
        [ScaffoldColumn(false)]
        [ReadOnly(true)]
        public virtual string Username { get; set; }

        [Required]
        [Display(Name = "Phone Type")]
        [Range(0, 2, ErrorMessage = "No hackers in here please!")]
        public virtual PhoneType PhoneType { get; set; }

        /// <summary>
        /// Phone number, validations on it are still a bit of a work in progress.
        /// </summary>
        [Required]
        [Phone(ErrorMessage = "This doesn't look like a valid phone number.")]
        [Display(Name = "Phone Number")]
        public virtual string PhoneNumber { get; set; }

        /// <summary>
        /// Takes in a Phone and a String, and checks if the Phone number belongs to the String. Validation created to do CRUD on Phone.
        /// </summary>
        /// <param name="phoneToCheck">A Phone object in the database</param>
        /// <param name="usernameToCheck">Usually User.Identity.Name, must be our username</param>
        /// <returns>True if Phone.Username is equal to the Username to check, false otherwise.</returns>
        public static bool DoesUserMatchOrAdmin(Phone phoneToCheck, string usernameToCheck)
        {
            // TODO: Add the admin logic if relevant
            return String.Equals(phoneToCheck.Username, usernameToCheck);
        }

        /// <summary>
        /// Gets all the phones that a user owns and returns them as a List.
        /// </summary>
        /// <param name="usernameToGet">The user who you are checking for phones</param>
        /// <returns>List of phones a user owns.</returns>
        public static List<Phone> PhonesByUser(string usernameToGet)
        {
            PhoneifyDB db = new PhoneifyDB();

            return db.Phones.Where(phone => phone.Username == usernameToGet).ToList();
        }
    }

    /// <summary>
    /// Enum listing phone types. 
    /// 
    /// To add more phone types just add them here, and edit the range in PhoneType above.
    /// </summary>
    public enum PhoneType
    {
        Cellphone, Office, Home
    }
}