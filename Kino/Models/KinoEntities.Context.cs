﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kino.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KinoEntities : DbContext
    {
        public KinoEntities()
            : base("name=KinoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Adresy> Adresy { get; set; }
        public virtual DbSet<Filmy> Filmy { get; set; }
        public virtual DbSet<Gatunki> Gatunki { get; set; }
        public virtual DbSet<Klienci> Klienci { get; set; }
        public virtual DbSet<Pracownicy> Pracownicy { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<Seanse> Seanse { get; set; }
        public virtual DbSet<TypyBiletow> TypyBiletow { get; set; }
        public virtual DbSet<TypySeansow> TypySeansow { get; set; }
        public virtual DbSet<Zamowienia> Zamowienia { get; set; }
    }
}