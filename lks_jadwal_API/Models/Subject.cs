//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lks_jadwal_API.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subject()
        {
            this.HeaderSchedules = new HashSet<HeaderSchedule>();
        }
    
        public int subjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Asignment { get; set; }
        public int Mid_exam { get; set; }
        public int Final_Exam { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HeaderSchedule> HeaderSchedules { get; set; }
    }
}
