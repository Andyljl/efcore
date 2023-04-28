using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EFMysql
{
    public partial class test
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

    }

}