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
    
    public partial class TblGrade
    {
        public int Id { get; set; }
        public Nullable<int> Exam1 { get; set; }
        public Nullable<int> Exam2 { get; set; }
        public Nullable<int> Exam3 { get; set; }
        public Nullable<int> Quiz1 { get; set; }
        public Nullable<int> Quiz2 { get; set; }
        public Nullable<int> ProjectGrade { get; set; }
        public Nullable<int> Lesson { get; set; }
        public Nullable<int> Student { get; set; }
        public Nullable<decimal> Average { get; set; }
    
        public virtual TblLesson TblLesson { get; set; }
        public virtual TblStudent TblStudent { get; set; }
    }
}