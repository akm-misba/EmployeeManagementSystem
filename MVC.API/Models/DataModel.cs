using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.API.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ComId { get; set; }
        public string ComName { get; set; }
        public byte Basic { get; set; }
        public byte Hrent { get; set; }
        public byte Medical { get; set; }
        public bool IsInactive { get; set; }

    }

    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DeptId { get; set; }
        public int ComId { get; set; }
        [ForeignKey("ComId")]
        public virtual Company Company { get; set; }
        public string DeptName { get; set; }


    }
    public class Designation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DesigId { get; set; }
        public int ComId { get; set; }
        [ForeignKey("ComId")]
        public virtual Company Company { get; set; }
        public string DesigName { get; set; }
        [NotMapped]
        public string Compname { get; set; }


    }
    public class Shift
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ShiftId { get; set; }
        public int ComId { get; set; }
        [ForeignKey("ComId")]
        public virtual Company Company { get; set; }

        public string ShiftName { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan ShiftIn { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan ShiftOut { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan ShiftLate { get; set; }
    }
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        public int ComId { get; set; }
        [ForeignKey("ComId")]
        public virtual Company Company { get; set; }
        public int ShiftId { get; set; }
        [ForeignKey("ShiftId")]
        public virtual Shift Shift { get; set; }
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
        public int DesigId { get; set; }
        [ForeignKey("DesigId")]
        public virtual Designation Designation { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public decimal Gross { get; set; }
        public decimal? Basic { get; set; }
        public decimal? HRent { get; set; }
        public decimal? Medical { get; set; }
        public decimal? Others { get; set; }
        public DateTime dtJoin { get; set; }
        [NotMapped]
        public string departName { get; set; }
        [NotMapped]
        public string Compname { get; set; }
        [NotMapped]
        //public string Empname { get; set; }
        //[NotMapped]
        public string DesigName { get; set; }
        [NotMapped]
        public string ShiftName { get; set; }


    }
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttdId { get; set; }
        public int ComId { get; set; }
        [ForeignKey("ComId")]
        public virtual Company Company { get; set; }
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        public DateTime dtDate { get; set; }
        public TimeSpan? TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
        public string AttStatus { get; set; }
        //[NotMapped]
        //public string Compname { get; set; }
        //[NotMapped]
        //public string Empname { get; set; }


    }
    public class AttendanceSummary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttdSuId { get; set; }
        public int ComId { get; set; }
        [ForeignKey("ComId")]
        public virtual Company Company { get; set; }
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        public int dtMonth { get; set; }
        public int dtYear { get; set; }
        public byte Present { get; set; }
        public byte Late { get; set; }
        public byte Absent { get; set; }
        public byte Holiday { get; set; }

        [NotMapped]
        public string Compname { get; set; }
        [NotMapped]
        public string Empname { get; set; }



    }
    public class Salary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalaryId { get; set; }
        public int ComId { get; set; }
        [ForeignKey("ComId")]
        public virtual Company Company { get; set; }
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }// Foreign key referencing the Employee table
        public int dtMonth { get; set; }
        public int dtYear { get; set; }
        public decimal Gross { get; set; }
        public decimal Basic { get; set; }
        public decimal Hrent { get; set; }
        public decimal Medical { get; set; }
        public decimal Others { get; set; }
        public decimal AbsentAmount { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool IsPaid { get; set; }
        public decimal PaidAmount { get; set; }
        [NotMapped]
        public string Compname { get; set; }
        [NotMapped]
        public string Empname { get; set; }



    }
}
