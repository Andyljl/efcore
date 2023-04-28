using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EFMysql
{
    public partial class Parameter
    {
        [Key]
        [Column("id")]
        [Description("id")]
        public int Id { get; set; }

        [Column("name")]
        [Description("姓名")]
        public string Name { get; set; } = null!;

        [Column("plcaddress")]
        [Description("地址")]
        public string Plcaddress { get; set; } = null!;

        [Column("type")]
        [Description("类型")]
        public string Type { get; set; } = null!;

        [Column("swith")]
        public string Swith { get; set; } = null!;

        [Column("ceiling")]
        public string Ceiling { get; set; } = null!;

        [Column("limit")]
        public string Limit { get; set; } = null!;
    }

}