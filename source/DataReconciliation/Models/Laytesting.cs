using Ganss.Excel;

namespace DataReconciliation.Models
{
    public class Laytesting
    {
        [Column(1)]
        public string global_id { get; set; }
        //public string ngay_capnhat { get; set; }
        [Column(3)]
        public string ngay_td { get; set; }
        [Column(4)]
        public string ma_cs { get; set; }
        [Column(5)]
        public int? loai_dv { get; set; }
        [Column(6)]
        public string nvht_congdong { get; set; }
        //[Column(7)]
        //public string ten_nvht_congdong { get; set; }
        [Column(8)]
        public int? tc_congdong { get; set; }
        [Column(9)]
        public int? xn_congdong { get; set; }
        [Column(10)]
        public string ma_duan_conogdong { get; set; }
        [Column(11)]
        public string stt { get; set; }
        [Column(12)]
        public string ma_xnsl { get; set; }
        [Column(13)]
        public string nguon_gioithieu { get; set; }
        [Column(14)]
        public string ma_tccd { get; set; }
        [Column(15)]
        public string ma_ict { get; set; }
        [Column(16)]
        public string ma_sns { get; set; }
        [Column(17)]
        public string csty_gt { get; set; }
        [Column(18)]
        public string mxh_gt { get; set; }
        [Column(19)]
        public int? hdxh { get; set; }
        [Column(20)]
        public string ho_ten { get; set; }
        [Column(21)]
        public int? gioi_tinh { get; set; }
        [Column(22)]
        public string ngay_sinh { get; set; }
        [Column(23)]
        public int? nam_sinh { get; set; }
        [Column(24)]
        public string sdt { get; set; }
        [Column(25)]
        public string cccd { get; set; }
        [Column(26)]
        public string diachi_cutru { get; set; }
        [Column(27)]
        public int? tt_cutru { get; set; }
        [Column(28)]
        public int? qh_cutru { get; set; }
        [Column(29)]
        public int? px_cutru { get; set; }
        [Column(30)]
        public string diachi_hk { get; set; }
        [Column(31)]
        public int? tt_hk { get; set; }
        [Column(32)]
        public int? qh_hk { get; set; }
        [Column(33)]
        public int? px_hk { get; set; }
        [Column(34)]
        public int? nghe_nghiep { get; set; }
        [Column(35)]
        public int? dan_toc { get; set; }
        [Column(36)]
        public string dtnc { get; set; }
        [Column(37)]
        public string dtnc_khac { get; set; }
        [Column(38)]
        public string hvnc { get; set; }
        [Column(39)]
        public string hvnc_khac { get; set; }
        [Column(40)]
        public string ls_kqxn { get; set; }
        [Column(41)]
        public DateTime? ls_ngayxn { get; set; }
        [Column(42)]
        public int? ls_prep { get; set; }
        [Column(43)]
        public int? ls_arv { get; set; }
        [Column(44)]
        public int? dongy_cgarv { get; set; }
        [Column(45)]
        public int? xn_lai { get; set; }
        [Column(46)]
        public int? dongy_sddv { get; set; }
        [Column(47)]
        public int? loai_dvxn { get; set; }
        [Column(48)]
        public int? txn_nhan_sp { get; set; }
        [Column(49)]
        public int? txn_sp { get; set; }
        [Column(50)]
        public string txn_sp_khac { get; set; }
        [Column(51)]
        public string txn_ngaynhan { get; set; }
        [Column(52)]
        public int? txn_kq { get; set; }
        [Column(53)]
        public int? loai_xnsl { get; set; }
        [Column(54)]
        public int? kq_xnsl { get; set; }
        [Column(55)]
        public int? kq_xn_knkt { get; set; }
        [Column(56)]
        public int? tinh_cscg { get; set; }
        [Column(57)]
        public string ma_cscg { get; set; }
        [Column(58)]
        public string ten_cscg_khac { get; set; }
        [Column(59)]
        public string ngay_dk_sddv { get; set; }
        [Column(60)]
        public string ma_cs_xnkd { get; set; }
        [Column(61)]
        public string ten_cs_xnkd_khac { get; set; }
        [Column(62)]
        public string ma_xnkd_hiv { get; set; }
        [Column(63)]
        public int? loai_xnkd_hiv { get; set; }
        [Column(64)]
        public int? kq_xnkd_hiv { get; set; }
        [Column(65)]
        public string ngay_tv_sauxn { get; set; }
        [Column(66)]
        public string nvtv_sauxn { get; set; }
        [Column(67)]
        public string ten_nvtv_sauxn { get; set; }
        [Column(68)]
        public int? du_tc_prep { get; set; }
        [Column(69)]
        public int? dongy_prep { get; set; }
        [Column(70)]
        public string lydo_ko_prep { get; set; }
        [Column(71)]
        public string ngay_prep { get; set; }
        [Column(72)]
        public string ma_prep { get; set; }
        [Column(73)]
        public string ma_cs_prep { get; set; }
        [Column(74)]
        public string cs_prep_khac { get; set; }
        [Column(75)]
        public int? dv_duphong { get; set; }
        [Column(76)]
        public int? dongy_npep { get; set; }
        [Column(77)]
        public string lydo_ko_npep { get; set; }
        [Column(78)]
        public string ngay_npep { get; set; }
        [Column(79)]
        public string ma_npep { get; set; }
        [Column(80)]
        public string cs_npep { get; set; }
        [Column(81)]
        public string dv_duphong_khac { get; set; }
        [Column(82)]
        public int? dongy_arv { get; set; }
        [Column(83)]
        public string lydo_ko_arv { get; set; }
        [Column(84)]
        public string ma_cs_arv { get; set; }
        [Column(85)]
        public string ten_cs_arv_khac { get; set; }
        [Column(86)]
        public string ngay_arv { get; set; }
        [Column(87)]
        public string ma_arv { get; set; }
        [Column(88)]
        public string ngay_gn_duytri_dt { get; set; }
        [Column(89)]
        public int? kq_duytri_dt { get; set; }
        [Column(90)]
        public string loai_giayto { get; set; }
        [Column(91)]
        public string cmnd { get; set; }
        [Column(92)]
        public string ho_chieu { get; set; }
        [Column(93)]
        public string gplx { get; set; }
        [Column(94)]
        public string bhyt { get; set; }
        [Column(95)]
        public string giayto_khac { get; set; }
        [Column(96)]
        public string khongco_giayto { get; set; }
        [Column(97)]
        public int? tinh_cs_xnkd { get; set; }
        [Column(98)]
        public string ngay_xnkd { get; set; }
        [Column(99)]
        public string ngay_nhan_kq_xnkd { get; set; }
        [Column(100)]
        public int? sangloc_prep { get; set; }
        [Column(101)]
        public int? tinh_cs_prep { get; set; }
        [Column(102)]
        public int? tinh_cs_arv { get; set; }
        [Column(103)]
        public string phieu_dongy_cgxn { get; set; }

        public int? status { get; set; }
    }

    public class FileValue
    {
        public string FileName { get; set; }
        public string Id { get; set; }
        public string FieldName { get; set; }
        public string Value { get; set; }
    }

    public class Result
    {
        [Column(1)]
        public string Global_id { get; set; }
        [Column(2)]
        public bool Error { get; set; }
        [Column(3)]
        public string Field { get; set; }
        [Column(4)]
        public string Message { get; set; }
    }
} 
