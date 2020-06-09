using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace chatapp.web.server
{
    /// <summary>
    /// Out Settings database table representational model
    /// </summary>
    public class SettingsDataModel
    {
        /// <summary>
        /// The unique Id for this entry
        /// </summary>
        [Key]
        public string Id { get; set; }

        /// <summary>
        /// The settings Name
        /// </summary>
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        /// <summary>
        /// The setting Value
        /// </summary>
        [Required]
        [MaxLength(2048)]
        public string Value { get; set; }
    }
}
