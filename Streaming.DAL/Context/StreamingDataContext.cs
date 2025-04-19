using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Streaming.DAL.Models;

namespace Streaming.DAL.Context;

public partial class StreamingDataContext : DbContext
{
    public StreamingDataContext()
    {
    }

    public StreamingDataContext(DbContextOptions<StreamingDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CAST> CASTs { get; set; }

    public virtual DbSet<CATEGORY> CATEGORies { get; set; }

    public virtual DbSet<CONTENT> CONTENTs { get; set; }

    public virtual DbSet<FILM> FILMs { get; set; }

    public virtual DbSet<FILM_CATEGORY> FILM_CATEGORies { get; set; }

    public virtual DbSet<FILM_CONTENT> FILM_CONTENTs { get; set; }

    public virtual DbSet<KEEP_WHATCHING> KEEP_WHATCHINGs { get; set; }

    public virtual DbSet<MY_LIST> MY_LISTs { get; set; }

    public virtual DbSet<PROFILE> PROFILEs { get; set; }

    public virtual DbSet<SERIES> SERIES { get; set; }

    public virtual DbSet<SERIES_EPISODE> SERIES_EPISODEs { get; set; }

    public virtual DbSet<USER> USERs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CAST>(entity =>
        {
            entity.HasKey(e => e.ID_CAST).HasName("PK__CAST__7A168884B2C6BE42");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.CASTs).HasConstraintName("FK__CAST__ID_FILM__68487DD7");

            entity.HasOne(d => d.ID_SERIESNavigation).WithMany(p => p.CASTs).HasConstraintName("FK__CAST__ID_SERIES__693CA210");
        });

        modelBuilder.Entity<CATEGORY>(entity =>
        {
            entity.HasKey(e => e.ID_CATEGORY).HasName("PK__CATEGORY__EC9B18B785831442");
        });

        modelBuilder.Entity<CONTENT>(entity =>
        {
            entity.HasKey(e => e.ID_CONTENT).HasName("PK__CONTENT__D9FD679E02CE61F8");
        });

        modelBuilder.Entity<FILM>(entity =>
        {
            entity.HasKey(e => e.ID_FILM).HasName("PK__FILM__62C9DB1C2779642A");
        });

        modelBuilder.Entity<FILM_CATEGORY>(entity =>
        {
            entity.HasKey(e => e.ID_FILM_CATEGORY).HasName("PK__FILM_CAT__F1103A3C2C71F391");

            entity.HasOne(d => d.ID_CATEGORYNavigation).WithMany(p => p.FILM_CATEGORies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FILM_CATE__ID_CA__619B8048");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.FILM_CATEGORies)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FILM_CATE__ID_FI__60A75C0F");
        });

        modelBuilder.Entity<FILM_CONTENT>(entity =>
        {
            entity.HasKey(e => e.ID_FILM_CONTENT).HasName("PK__FILM_CON__782E262EC7D33C19");

            entity.HasOne(d => d.ID_CONTENTNavigation).WithMany(p => p.FILM_CONTENTs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FILM_CONT__ID_CO__656C112C");

            entity.HasOne(d => d.ID_FILMNavigation).WithMany(p => p.FILM_CONTENTs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FILM_CONT__ID_FI__6477ECF3");
        });

        modelBuilder.Entity<KEEP_WHATCHING>(entity =>
        {
            entity.HasKey(e => e.ID_KEEP_WHATCHING).HasName("PK__KEEP_WHA__07C65FDDD57C5E46");

            entity.HasOne(d => d.ID_PROFILENavigation).WithMany(p => p.KEEP_WHATCHINGs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__KEEP_WHAT__ID_PR__5165187F");
        });

        modelBuilder.Entity<MY_LIST>(entity =>
        {
            entity.HasKey(e => e.ID_MY_LIST).HasName("PK__MY_LIST__B98514CBE6676166");

            entity.HasOne(d => d.ID_PROFILENavigation).WithMany(p => p.MY_LISTs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MY_LIST__ID_PROF__4E88ABD4");
        });

        modelBuilder.Entity<PROFILE>(entity =>
        {
            entity.HasKey(e => e.ID_PROFILE).HasName("PK__PROFILE__0DB303E0F5A9DDD4");

            entity.HasOne(d => d.ID_USERNavigation).WithMany(p => p.PROFILEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PROFILE__ID_USER__4BAC3F29");
        });

        modelBuilder.Entity<SERIES>(entity =>
        {
            entity.HasKey(e => e.ID_SERIES).HasName("PK__SERIES__3DCEE9629CDC0744");

            entity.HasOne(d => d.ID_CATEGORYNavigation).WithMany(p => p.SERIES)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERIES__ID_CATEG__4222D4EF");
        });

        modelBuilder.Entity<SERIES_EPISODE>(entity =>
        {
            entity.HasKey(e => e.ID_SERIES_EDIPOSE).HasName("PK__SERIES_E__E7BD1614258B9CA2");

            entity.HasOne(d => d.ID_CONTENTNavigation).WithMany(p => p.SERIES_EPISODEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERIES_EP__ID_CO__46E78A0C");

            entity.HasOne(d => d.ID_SERIESNavigation).WithMany(p => p.SERIES_EPISODEs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERIES_EP__ID_SE__45F365D3");
        });

        modelBuilder.Entity<USER>(entity =>
        {
            entity.HasKey(e => e.ID_USER).HasName("PK__USER__95F48440ADAF4DF9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
