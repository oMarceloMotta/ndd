using System;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using domain.Entity;

namespace infrastructure.Persistence.Configuration
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasData(
                new Cliente
                {
                    Id = new Guid("b5f3944c-b7f9-4e53-91ad-10feeb8d88fb"),
                    CPF = "30030030030",
                    Nome = "Marcelo",
                    Sexo = "Masculino",
                    Telefone = "12996857740",
                    Email = "imarcelomgl@gmail.com",
                    DataNascimento = DateTime.Now,
                    Observacao = "",
                });

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
