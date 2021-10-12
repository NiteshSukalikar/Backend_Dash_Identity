namespace IEH_Dashboard.Model
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines the <see cref="AddNoteMasterModel" />
    /// </summary>
    [DataContract]
    public class Dashboard
    {
        /// <summary>
        /// Gets or sets the Id
        /// </summary>
        [Required]
        [DataMember(Name = "Id")]
        /// <summary>
        /// Gets or sets the NoteReasons
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the ActiveMembers
        /// </summary>
        [DataMember(Name = "ActiveMembers")]
        /// <summary>
        /// Gets or sets the NoteReasons
        /// </summary>
        public int ActiveMembers { get; set; }

        /// <summary>
        /// Gets or sets the InactiveMembers
        /// </summary>
        [DataMember(Name = "InactiveMembers")]
        /// <summary>
        /// Gets or sets the NoteReasons
        /// </summary>
        public int InactiveMembers { get; set; }

        /// <summary>
        /// Gets or sets the TotalMembers
        /// </summary>
        [DataMember(Name = "TotalMembers")]      
        public int TotalMembers { get; set; }

        /// <summary>
        /// Gets or sets the TotalNoOfCases
        /// </summary>
        [DataMember(Name = "TotalNoOfCases")]     
        public int TotalNoOfCases { get; set; }

        /// <summary>
        /// Gets or sets the Onboard
        /// </summary>
        [DataMember(Name = "Onboard")]
        public int Onboard { get; set; }

        /// <summary>
        /// Gets or sets the ActiveStatusId
        /// </summary>
        [DataMember(Name = "ActiveStatusId")]     
        public byte ActiveStatusId { get; set; }

        /// <summary>
        /// Gets or sets the CreatedBy
        /// </summary>
        [DataMember(Name = "CreatedBy")]
        public long CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the CreatedOn
        /// </summary>
        [DataMember(Name = "CreatedOn")]
        /// <summary>
        /// Gets or sets the NoteReasons
        /// </summary>
        public long CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedBy
        /// </summary>
        [DataMember(Name = "UpdatedBy")]
        /// <summary>
        /// Gets or sets the NoteReasons
        /// </summary>
        public long UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the UpdatedOn
        /// </summary>
        [DataMember(Name = "UpdatedOn")]
        /// <summary>
        /// Gets or sets the NoteReasons
        /// </summary>
        public long UpdatedOn { get; set; }

        /// <summary>
        /// Gets or sets the ReturnCode
        /// </summary>
        public string ReturnCode { get; set; }

        /// <summary>
        /// Gets or sets the ActivePatients
        /// </summary>
        [DataMember(Name = "ActivePatients")]
        /// <summary>
        /// Gets or sets the ActivePatients
        /// </summary>
        public int ActivePatients { get; set; }

        /// <summary>
        /// Gets or sets the InactivePatients
        /// </summary>
        [DataMember(Name = "InactivePatients")]
        /// <summary>
        /// Gets or sets the InactivePatients
        /// </summary>
        public int InactivePatients { get; set; }

        /// <summary>
        /// Gets or sets the TotalPatients
        /// </summary>
        [DataMember(Name = "TotalPatients")]
        public int TotalPatients { get; set; }
    }
}
