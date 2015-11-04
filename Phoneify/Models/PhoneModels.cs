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
        // TODO: Confirm everything here is what we want before scaffolding
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
        public virtual PhoneType PhoneType { get; set; }

        // TODO: Find some open source code that does the Phone validation code for us.
        /// <summary>
        /// Phone number, validations on it are still a bit of a work in progress.
        /// </summary>
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public virtual string PhoneNumber { get; set; }
    }

    /// <summary>
    /// Enum listing phone types, to add more phone types just add them here.
    /// </summary>
    public enum PhoneType
    {
        Cellphone, Office, Home
    }
}