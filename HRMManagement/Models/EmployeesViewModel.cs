//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;

//namespace HRMManagement.Models
//{
//    public class EmployeesViewModel
//    {
//        public string ID { get; set; }

//        [DisplayName("Họ đệm")]
//        public string HoDem { get; set; }

//        [DisplayName("Tên")]
//        public string Ten { get; set; }

//        [DisplayName("Ngày sinh")]
//        public DateTime? NgaySinh { get; set; }
//        [DisplayName("Giới tính")]
//        public bool? GioiTinh { get; set; }

//        [DisplayName("Căn cước")]
//        public string CCCD { get; set; }

//        [DisplayName("Địa chỉ")]
//        public string DiaChi { get; set; }

//        [DisplayName("Điện thoại")]
//        public string SDT { get; set; }

//        [DisplayName("Mail")]
//        public string Email { get; set; }

//        [DisplayName("Quê quán")]
//        public string QueQuan { get; set; }

//        [DisplayName("Ngày tuyển")]
//        public DateTime? NgayTuyenDung { get; set; }
//        [DisplayName("Ảnh Profile")]
//        [Column(TypeName = "image")]
//        public byte[] AnhProfile { get; set; }
        
//        public int? IDViTri { get; set; }

//        public int? IDChucVu { get; set; }

//        public int? IDPhongBan { get; set; }


//        [DisplayName("Họ Tên")]
//        public String HoVaTen {
//            get { return HoDem + " " + Ten;} 
//        }
//    }
//}
