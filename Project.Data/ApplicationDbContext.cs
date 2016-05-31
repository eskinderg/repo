﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Project.Model;
using System.Data.Entity.ModelConfiguration;


namespace Project.Data
{
    public class ApplicationDbContext : DbContext, IDbContext
    {
        public ApplicationDbContext() : base("ProjectDB")
        {
            Database.SetInitializer<ApplicationDbContext>(null);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                                        .Where(type => !string.IsNullOrEmpty(type.Namespace))
                                        .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                                                        type.BaseType.GetGenericTypeDefinition() == typeof (EntityTypeConfiguration<>));

            foreach (var configurationInstance in typesToRegister.Select(Activator.CreateInstance))
            {
                modelBuilder.Configurations.Add((dynamic) configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }


    }
}
