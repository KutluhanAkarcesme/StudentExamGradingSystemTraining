//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentExamGradingSystem.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_1
    {
        public int Id { get; set; }
        public string StdName { get; set; }
        public string StdSurname { get; set; }
        public string LessonName { get; set; }
        public Nullable<byte> Exam1 { get; set; }
        public Nullable<byte> Exam2 { get; set; }
        public Nullable<byte> Exam3 { get; set; }
        public Nullable<byte> Quiz1 { get; set; }
        public Nullable<byte> Quiz2 { get; set; }
        public Nullable<byte> ProjectGrade { get; set; }
        public Nullable<decimal> Average { get; set; }
    }
}
