﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace landSelling.Models.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class landSellingEntity : DbContext
    {
        public landSellingEntity()
            : base("name=landSellingEntity")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<administration> administrations { get; set; }
        public virtual DbSet<buyer> buyers { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<request> requests { get; set; }
        public virtual DbSet<seller> sellers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
