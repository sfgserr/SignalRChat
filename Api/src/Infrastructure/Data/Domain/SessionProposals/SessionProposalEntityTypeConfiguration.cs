using Domain.SessionProposals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Domain.SessionProposals
{
    internal class SessionProposalEntityTypeConfiguration : IEntityTypeConfiguration<SessionProposal>
    {
        public void Configure(EntityTypeBuilder<SessionProposal> builder)
        {
            builder.ToTable("SessionProposals");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.ProposingUserId).HasColumnName("ProposingUserId");
            builder.Property(p => p.ProposedUserId).HasColumnName("ProposedUserId");
            builder.Property(p => p.ProposedDate).HasColumnName("ProposedDate");
        }
    }
}
