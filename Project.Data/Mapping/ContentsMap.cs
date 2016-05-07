using System.Data.Entity.ModelConfiguration;

using Project.Model.Models;

namespace Project.Data.Mapping
{
    public class ContentsMap : EntityTypeConfiguration<Content>
    {
        public ContentsMap()
        {
            //Primary Key
            this.HasKey(c => c.Id);

            //Properties
            

            //Table & Column Mapping
            this.ToTable("content");
            this.Property(c => c.Id).HasColumnName("content_id").IsRequired();
            this.Property(c => c.Title).HasColumnName("content_title");
            this.Property(c => c.HTML).HasColumnName("content_html");
            this.Property(c => c.Summary).HasColumnName("content_teaser");
            this.Property(c => c.XmlConfigId).HasColumnName("xml_config_id");
            this.Property(c => c.FolderId).HasColumnName("folder_id").IsOptional();
            this.HasOptional(c => c.Folder);
        }
    }
}
