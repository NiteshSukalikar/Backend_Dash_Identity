using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IEH_Dashboard.ViewModel
{
    public class UpcommingAppointment
    {
        public int Id { get; set; }

        public long? PatientId { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
        public string AppointmentType { get; set; }
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Notes { get; set; }

        public int? AppointmentTypeId { get; set; }

        public string ColorLocationOfficeStartHour { get; set; }

        public string LocationOfficeEndHour { get; set; }

        public int? PatientAddressId { get; set; }

        public int? OfficeAddressId { get; set; }

        public int? ServiceLocationId { get; set; }

        public string RecurrenceRule { get; set; }

        public bool? IsRecurrence { get; set; }

        public bool? IsTelehealthAppointment { get; set; }

        public int? ParentAppointmentId { get; set; }

        public bool? IsClientRequired { get; set; }

        public long CheckInBy { get; set; }

        public bool IsCheckIn { get; set; }
        public string CustomAddress { get; set; }

        public int? CustomAddressId { get; set; }

        public int? DayId { get; set; }

        public decimal? Latitude { get; set; }

        public decimal? Longitude { get; set; }

        public string ApartmentNumber { get; set; }

        public int? CancelTypeId { get; set; }

        public int? StatusId { get; set; }

        public string CancelReason { get; set; }

        public bool? IsExcludedFromMileage { get; set; }

        public bool? IsDirectService { get; set; }

        public decimal? Mileage { get; set; }

        public int? PatientInsuranceId { get; set; }

        public int? AuthorizationId { get; set; }

        public DateTime? DriveTime { get; set; }

        public int? Offset { get; set; }

        public int? OrganizationId { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedOn { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public long? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ResponseResult { get; set; }

        public long ProviderId { get; set; }
        public string PatientName { get; set; }
        public string ProviderName { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string ProfilePicture { get; set; }

        public string ProviderFirstName { get; set; }

        public string ProviderLastName { get; set; }
    }
}
