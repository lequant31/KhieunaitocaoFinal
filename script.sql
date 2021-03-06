USE [khieunaitocao]
GO
/****** Object:  Table [dbo].[tb_nhatky_guidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_nhatky_guidon](
	[id_nhatky_guidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtinkhieunai] [int] NULL,
	[nguondon_bandau] [nvarchar](max) NULL,
	[ngay_vietdon] [date] NULL,
	[ngay_nhandon_bandau] [date] NULL,
	[canbo_tiepnhan_bandau] [nvarchar](max) NULL,
	[coquan_chuyenden] [nvarchar](max) NULL,
	[kyhieu_donvi] [nvarchar](50) NULL,
	[so_congvan] [nvarchar](50) NULL,
	[hinhthuc_bandau_cua_donthu] [nvarchar](max) NULL,
	[hinhthuc_tiepnhan] [nvarchar](max) NULL,
	[ngay_tiepnhan] [date] NULL,
 CONSTRAINT [PK_tb_nhatky_guidon] PRIMARY KEY CLUSTERED 
(
	[id_nhatky_guidon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[nhatky_guidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[nhatky_guidon] as(
SELECT DISTINCT
        bag2.id_thongtinkhieunai,
        (   SELECT bag1.nguondon_bandau +', '
            FROM tb_nhatky_guidon bag1
            WHERE bag1.id_thongtinkhieunai=bag2.id_thongtinkhieunai
            ORDER BY bag1.id_thongtinkhieunai
            FOR XML PATH(''))[nguondon_bandau]
    FROM tb_nhatky_guidon bag2)
GO
/****** Object:  Table [dbo].[tb_bidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_bidon](
	[id_bidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtinkhieunai] [int] NULL,
	[bidon_tochuc_canhan] [nvarchar](500) NULL,
	[hoten_canhan] [nvarchar](500) NULL,
	[sohieu_cand] [nvarchar](150) NULL,
	[nghe_nghiep] [nvarchar](500) NULL,
	[capbac] [nvarchar](500) NULL,
	[chucvu] [nvarchar](500) NULL,
	[ten_coquandonvi] [nvarchar](500) NULL,
	[diachi] [nvarchar](500) NULL,
	[thuoc_lucluong] [nvarchar](500) NULL,
 CONSTRAINT [PK_tb_bidon] PRIMARY KEY CLUSTERED 
(
	[id_bidon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[bidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[bidon] as(
SELECT DISTINCT
        bag2.id_thongtinkhieunai,
        (   SELECT bag1.hoten_canhan +', '
            FROM tb_bidon bag1
            WHERE bag1.id_thongtinkhieunai=bag2.id_thongtinkhieunai
            ORDER BY bag1.id_thongtinkhieunai
            FOR XML PATH(''))[canhan_tochuc]
    FROM tb_bidon bag2)
GO
/****** Object:  Table [dbo].[tb_thongtinkhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_thongtinkhieunai](
	[id_thongtinhieunai] [int] IDENTITY(1,1) NOT NULL,
	[ma_donthu_khieunai] [nvarchar](50) NOT NULL,
	[ma_canbo_nhapdulieu] [int] NULL,
	[ma_donvi_nhapdulieu] [int] NULL,
	[tochuc_canhan] [bit] NULL,
	[nacdanh_codanh] [bit] NULL,
	[chuky_nhieunguoi_motnguoi] [bit] NULL,
	[loai_don] [nvarchar](50) NULL,
	[tomtat_noidung] [nvarchar](max) NULL,
	[dieukien_xuly_du_hoackhong] [bit] NULL,
	[giayto_tailieugoc_kemtheo] [bit] NULL,
	[tinhchat_vuviec_phuctap_dongian] [bit] NULL,
	[ma_khieunai] [nvarchar](5) NULL,
	[khieunai_lienquanden_thamquyen_nhieucand_co_khong] [bit] NULL,
	[khieunai_conoidung_tocao] [bit] NULL,
	[lydo_khongdu_dieukien] [nvarchar](max) NULL,
	[noigui] [nvarchar](max) NULL,
	[tailieu_dinhkem] [nvarchar](max) NULL,
	[ngaygio_nhap] [nvarchar](max) NULL,
	[ngaygio_sua] [nvarchar](max) NULL,
	[status_sua_xoa] [bit] NULL,
	[donvichuyenden] [int] NULL,
	[ma_quatrinhgiaiquyet_donvichuyenden] [int] NULL,
	[ten_canhan_tochuc] [nvarchar](500) NULL,
	[sdt] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[so_cmnd] [nvarchar](50) NULL,
	[ngaycap_cmnd] [date] NULL,
	[noicap_cmnd] [nvarchar](500) NULL,
	[dia_chi] [nvarchar](max) NULL,
	[ten_cqdv_canhan] [nvarchar](max) NULL,
	[nguoi_ky_trong_don] [nvarchar](max) NULL,
	[ghi_chu] [nvarchar](max) NULL,
	[CreateDated] [datetime] NULL,
	[UpdateDated] [datetime] NULL,
 CONSTRAINT [PK_tb_thongtinkhieunai] PRIMARY KEY CLUSTERED 
(
	[id_thongtinhieunai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[tb_bieudocot_donthukhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[tb_bieudocot_donthukhieunai]
as
select ma_donvi_nhapdulieu,ma_donthu_khieunai,nam=year(ngay_tiepnhan),thang=Min(MONTH(ngay_tiepnhan))
from tb_thongtinkhieunai, tb_nhatky_guidon where tb_thongtinkhieunai.id_thongtinhieunai = tb_nhatky_guidon.id_thongtinkhieunai
group by ma_donthu_khieunai,year(ngay_tiepnhan),ma_donvi_nhapdulieu
GO
/****** Object:  Table [dbo].[tb_nhatky_guidon_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_nhatky_guidon_tocao](
	[id_nhatky_guidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtintocao] [int] NULL,
	[ngaynhan_dontocao_bandau] [date] NULL,
	[ngay_tocao] [date] NULL,
	[canbo_tiepnhan_bandau] [nvarchar](max) NULL,
	[coquan_chuyenden] [nvarchar](max) NULL,
	[kyhieu_donvi] [nvarchar](50) NULL,
	[so_congvan] [nvarchar](50) NULL,
	[hinhthuc_bandau_cua_donthu] [nvarchar](max) NULL,
	[hinhthuc_tiepnhan] [nvarchar](max) NULL,
	[ngay_tiepnhan] [date] NULL,
	[nguondon_bandau] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_nhatky_guidon_tocao] PRIMARY KEY CLUSTERED 
(
	[id_nhatky_guidon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_thongtintocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_thongtintocao](
	[id_thongtintocao1] [int] IDENTITY(1,1) NOT NULL,
	[ma_donthu_tocao] [nvarchar](50) NOT NULL,
	[ma_canbo_nhapdulieu] [int] NULL,
	[ma_donvi] [int] NULL,
	[tochuc_canhan] [int] NULL,
	[nacdanh_codanh] [int] NULL,
	[hinhthuc_tocao] [nvarchar](50) NULL,
	[tomtat_noidung] [nvarchar](max) NULL,
	[dieukien_xuly_du_hoackhong] [int] NULL,
	[giayto_tailieugoc_kemtheo] [int] NULL,
	[tinhchat_vuviec_phuctap_dongian] [int] NULL,
	[ma_tocao] [nvarchar](5) NULL,
	[tocao_lienquanden_thamquyen_nhieucand_co_khong] [int] NULL,
	[tocao_conoidung_khieunai] [int] NULL,
	[tocao_nhieunoidung_linhvuc] [int] NULL,
	[lydo_khongdu_dieukien] [nvarchar](max) NULL,
	[xuly_tocao_khongthuoc_thamquyen] [nvarchar](250) NULL,
	[chuyentocao_chodonvingoai] [nvarchar](max) NULL,
	[duoc_nhanketqua] [int] NULL,
	[duoc_baove] [int] NULL,
	[yeucaukhac] [nvarchar](max) NULL,
	[noigui] [nvarchar](max) NULL,
	[tailieu_dinhkem] [nvarchar](max) NULL,
	[ngaygio_nhap] [nvarchar](max) NULL,
	[ngaygio_sua] [nvarchar](max) NULL,
	[status_sua_xoa] [int] NULL,
	[donvichuyenden] [int] NULL,
	[ma_quatrinhgiaiquyet_donvichuyenden] [int] NULL,
	[ten_canhan_tochuc] [nvarchar](500) NULL,
	[sdt] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[so_cmnd] [nvarchar](50) NULL,
	[ngaycap_cmnd] [date] NULL,
	[noicap_cmnd] [nvarchar](500) NULL,
	[dia_chi] [nvarchar](max) NULL,
	[ten_cqdv_canhan] [nvarchar](max) NULL,
	[nguoi_ky_trong_don] [nvarchar](max) NULL,
	[ghi_chu] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_thongtintocao] PRIMARY KEY CLUSTERED 
(
	[id_thongtintocao1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[tb_bieudocot_donthutocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[tb_bieudocot_donthutocao]
as
select ma_donvi,ma_donthu_tocao,nam=year(ngay_tiepnhan),thang=Min(MONTH(ngay_tiepnhan))
from tb_thongtintocao, tb_nhatky_guidon_tocao where tb_thongtintocao.id_thongtintocao1 = tb_nhatky_guidon_tocao.id_thongtintocao
group by ma_donthu_tocao,year(ngay_tiepnhan),ma_donvi
GO
/****** Object:  Table [dbo].[tb_phanloai_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_phanloai_tocao](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[ma_tocao] [nvarchar](5) NULL,
	[phanloai_tocao] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[thongtintocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[thongtintocao] as
select id_thongtintocao1,ma_donthu_tocao,ten_canhan_tochuc,phanloai_tocao,ma_donvi
from tb_thongtintocao,tb_phanloai_tocao
where tb_thongtintocao.ma_tocao = tb_phanloai_tocao.ma_tocao
GO
/****** Object:  View [dbo].[bidon_thuoclucluong]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[bidon_thuoclucluong] as(
SELECT DISTINCT
        bag2.id_thongtinkhieunai,
        (   SELECT bag1.thuoc_lucluong +', '
            FROM tb_bidon bag1
            WHERE bag1.id_thongtinkhieunai=bag2.id_thongtinkhieunai
            ORDER BY bag1.id_thongtinkhieunai
            FOR XML PATH(''))[thuoclucluong]
    FROM tb_bidon bag2)
GO
/****** Object:  View [dbo].[nhatky_guidon_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[nhatky_guidon_tocao] as(
SELECT DISTINCT
        bag2.id_thongtintocao,
        (   SELECT bag1.nguondon_bandau +', '
            FROM tb_nhatky_guidon_tocao bag1
            WHERE bag1.id_thongtintocao=bag2.id_thongtintocao
            ORDER BY bag1.id_thongtintocao
            FOR XML PATH(''))[nguondon_bandau]
    FROM tb_nhatky_guidon_tocao bag2)
GO
/****** Object:  Table [dbo].[tb_bidon_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_bidon_tocao](
	[id_bidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtintocao] [int] NULL,
	[bidon_tochuc_canhan] [nvarchar](500) NULL,
	[hoten_canhan] [nvarchar](500) NULL,
	[sohieu_cand] [nvarchar](150) NULL,
	[nghe_nghiep] [nvarchar](500) NULL,
	[capbac] [nvarchar](500) NULL,
	[chucvu] [nvarchar](500) NULL,
	[ten_coquandonvi] [nvarchar](500) NULL,
	[diachi] [nvarchar](500) NULL,
	[thuoc_lucluong] [nvarchar](500) NULL,
 CONSTRAINT [PK_tb_bidon_tocao] PRIMARY KEY CLUSTERED 
(
	[id_bidon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[bidon_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[bidon_tocao] as(
SELECT DISTINCT
        bag2.id_thongtintocao,
        (   SELECT bag1.hoten_canhan +', '
            FROM tb_bidon_tocao bag1
            WHERE bag1.id_thongtintocao=bag2.id_thongtintocao
            ORDER BY bag1.id_thongtintocao
            FOR XML PATH(''))[canhan_tochuc]
    FROM tb_bidon_tocao bag2)
GO
/****** Object:  View [dbo].[bidon_thuoclucluong_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[bidon_thuoclucluong_tocao] as(
SELECT DISTINCT
        bag2.id_thongtintocao,
        (   SELECT bag1.thuoc_lucluong +', '
            FROM tb_bidon_tocao bag1
            WHERE bag1.id_thongtintocao=bag2.id_thongtintocao
            ORDER BY bag1.id_thongtintocao
            FOR XML PATH(''))[thuoclucluong]
    FROM tb_bidon_tocao bag2)
GO
/****** Object:  Table [dbo].[tb_giaiquyetkhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_giaiquyetkhieunai](
	[id_quatrinhgiaiquyetkhieunai] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtinkhieunai] [int] NULL,
	[solan_khieunai] [nvarchar](50) NULL,
	[hinhthuc_xuly] [nvarchar](50) NULL,
	[donvinhan] [int] NULL,
	[ten_donvinhan] [nvarchar](150) NULL,
	[ngaynhan] [date] NULL,
	[capgiaiquyet] [nvarchar](50) NULL,
	[noidungdonthu] [nvarchar](max) NULL,
	[dv_chiutrachnhiem_giaiquyet] [nvarchar](50) NULL,
	[so_congvan] [nvarchar](50) NULL,
	[ngaytao_congvan] [date] NULL,
	[songay_giaiquyet] [nvarchar](50) NULL,
	[ngaybatdau_giaiquyet] [date] NULL,
	[ngayketthuc_giaiquyet] [date] NULL,
	[hinhthuc_xacminh] [bit] NULL,
	[so_kehoach_xacminh] [nvarchar](50) NULL,
	[ngaylap_kehoachxacminh] [date] NULL,
	[so_quyetdinh_thanhlap] [nvarchar](50) NULL,
	[ngaylap_quyetdinh_thanhlap] [date] NULL,
	[so_ngayxacminh] [nvarchar](50) NULL,
	[ngay_batdauxacminh] [date] NULL,
	[ngay_ketthucxacminh] [date] NULL,
	[totruong_xacminh] [nvarchar](50) NULL,
	[capbac_totruong] [nvarchar](50) NULL,
	[chuvu_totruong] [nvarchar](50) NULL,
	[thanhvien_trongdoan] [nvarchar](max) NULL,
	[cabo_thuly] [nvarchar](50) NULL,
	[lanhdao_phutrach] [nvarchar](50) NULL,
	[ketqua_xacminh] [nvarchar](50) NULL,
	[ngayrut_khieunai] [date] NULL,
	[tomtat_ketqua_giaiquyet] [nvarchar](max) NULL,
	[date_ngayketthuc] [date] NULL,
	[danhgia_viec_giaiquyet] [bit] NULL,
	[bidon_co_dongy_ketqua] [bit] NULL,
	[so_cb_khongduoc_xetthidua] [int] NULL,
	[so_cb_bikiemdiem] [int] NULL,
	[so_cb_bikhientrach] [int] NULL,
	[so_cb_bicanhcao] [int] NULL,
	[so_cb_bigiangchuc] [int] NULL,
	[so_cb_bigiangcap] [int] NULL,
	[so_cb_bituocdanhhieu] [int] NULL,
	[so_cb_xuly_hinhsu] [int] NULL,
	[so_tapthe_duocminhoan] [int] NULL,
	[so_canhan_duocminhoan] [int] NULL,
	[khoiphuc_loiich_nhandan] [nvarchar](500) NULL,
	[thuhoi_taisan] [nvarchar](500) NULL,
	[ketthucgiaiquyet] [nvarchar](50) NULL,
	[statuss] [nvarchar](50) NULL,
	[ngay_khoitao] [date] NULL,
	[forward] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_giaiquyetkhieunai] PRIMARY KEY CLUSTERED 
(
	[id_quatrinhgiaiquyetkhieunai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[tb_locquatrinhgiaiquyet]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--lay ket qua giai quyet lan cuoi cung
CREATE view [dbo].[tb_locquatrinhgiaiquyet] as(
select * FROM tb_giaiquyetkhieunai where solan_khieunai >1 and hinhthuc_xuly =1
Union SELECT * FROM tb_giaiquyetkhieunai
WHERE id_thongtinkhieunai IN (
SELECT id_thongtinkhieunai
FROM tb_giaiquyetkhieunai
GROUP BY id_thongtinkhieunai
HAVING COUNT(id_thongtinkhieunai) = 1
))
GO
/****** Object:  Table [dbo].[tb_giaiquyettocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_giaiquyettocao](
	[id_quatrinhgiaiquyettocao] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtintocao] [int] NULL,
	[sola_tocao] [nvarchar](50) NULL,
	[hinhthuc_xuly] [int] NULL,
	[donvinhan] [int] NULL,
	[ngaynhan] [date] NULL,
	[capgiaiquyet] [nvarchar](50) NULL,
	[noidungtocao] [nvarchar](max) NULL,
	[dv_chiutrachnhiem_giaiquyet] [nvarchar](50) NULL,
	[sothongbao_chonoigui] [nvarchar](50) NULL,
	[ngaygui_thongbao] [date] NULL,
	[songay_giaiquyet] [nvarchar](50) NULL,
	[ngaybatdau_giaiquyet] [date] NULL,
	[ngayketthuc_giaiquyet] [date] NULL,
	[so_quyetdinh_thuly] [nvarchar](50) NULL,
	[ngay_thuly] [date] NULL,
	[hinhthuc_xacminh] [nvarchar](50) NULL,
	[so_quyetdinh_thanhlap] [nvarchar](50) NULL,
	[ngay_thanhlap_quyetdinh] [date] NULL,
	[hoten_totruong] [nvarchar](50) NULL,
	[capbac_totruong] [nvarchar](50) NULL,
	[chuvu_totruong] [nvarchar](50) NULL,
	[thanhvien_trongdoan] [nvarchar](max) NULL,
	[so_kehoach_xacminh] [nvarchar](50) NULL,
	[ngay_batdauxacminh] [date] NULL,
	[ngay_ketthucxacminh] [date] NULL,
	[ketqua_xacminh] [nvarchar](50) NULL,
	[ngayrut_tocao] [date] NULL,
	[lydorut_tocao] [nvarchar](max) NULL,
	[so_baocao_ketqua_xacminh] [nvarchar](50) NULL,
	[ngay_baocao_ketqua_xacminh] [date] NULL,
	[tomtat_ketqua_xuly] [nvarchar](max) NULL,
	[so_ketluan_noidung_tocao] [nvarchar](50) NULL,
	[ngay_ketluan_noidung_tocao] [date] NULL,
	[nguoiky_ketluan_noidung_tocao] [nvarchar](50) NULL,
	[chucvu_nguoiky_ketluan_noidung_tocao] [nvarchar](150) NULL,
	[ngay_congkhai_ketluan] [date] NULL,
	[so_cb_khongduoc_xetthidua] [int] NULL,
	[so_cb_bikiemdiem] [int] NULL,
	[so_cb_bicanhcao] [int] NULL,
	[so_cb_bikhientrach] [int] NULL,
	[so_cb_bigiangchuc] [int] NULL,
	[so_cb_bigiangcap] [int] NULL,
	[so_cb_xuly_hinhsu] [int] NULL,
	[so_cb_bituocdanhhieu] [int] NULL,
	[so_tapthe_duocminhoan] [int] NULL,
	[so_canhan_duocminhoan] [int] NULL,
	[khoiphuc_loiich] [nvarchar](500) NULL,
	[thuhoi_taisan] [nvarchar](500) NULL,
	[ngaynop_luu_hoso] [date] NULL,
	[cabo_thuly] [nvarchar](50) NULL,
	[lanhdao_phutrach] [nvarchar](50) NULL,
	[ketthucgiaiquyet] [nvarchar](50) NULL,
	[statuss] [nvarchar](50) NULL,
	[ngaykhoitao] [date] NULL,
	[date_ngayketthuc] [date] NULL,
	[forward] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_giaiquyettocao] PRIMARY KEY CLUSTERED 
(
	[id_quatrinhgiaiquyettocao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[tb_locquatrinhgiaiquyet_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--lay ket qua giai quyet lan cuoi cung
create view [dbo].[tb_locquatrinhgiaiquyet_tocao] as(
select * FROM tb_giaiquyettocao where sola_tocao >1 and hinhthuc_xuly =1
Union SELECT * FROM tb_giaiquyettocao
WHERE id_thongtintocao IN (
SELECT id_thongtintocao
FROM tb_giaiquyettocao
GROUP BY id_thongtintocao
HAVING COUNT(id_thongtintocao) = 1
))
GO
/****** Object:  Table [dbo].[tb_phanloai_khieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_phanloai_khieunai](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[parent_id] [int] NULL,
	[ma_khieunai] [nvarchar](5) NULL,
	[phanloai_khieunai] [nvarchar](150) NULL
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[thongtindonthu]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE view [dbo].[thongtindonthu] as
select id_thongtinhieunai,ma_donthu_khieunai,ten_canhan_tochuc,phanloai_khieunai,ma_donvi_nhapdulieu
from tb_thongtinkhieunai,tb_phanloai_khieunai
where tb_thongtinkhieunai.ma_khieunai = tb_phanloai_khieunai.ma_khieunai
GO
/****** Object:  View [dbo].[ngayketthuc]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[ngayketthuc] as
select ngayketthuc_giaiquyet from tb_giaiquyetkhieunai
where ngaybatdau_giaiquyet IS NOT NULL and ngayketthuc_giaiquyet IS NOT NULL

GO
/****** Object:  Table [dbo].[clonebidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clonebidon](
	[id_bidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtinkhieunai] [int] NULL,
	[bidon_tochuc_canhan] [nvarchar](500) NULL,
	[hoten_canhan] [nvarchar](500) NULL,
	[sohieu_cand] [nvarchar](150) NULL,
	[nghe_nghiep] [nvarchar](500) NULL,
	[capbac] [nvarchar](500) NULL,
	[chucvu] [nvarchar](500) NULL,
	[ten_coquandonvi] [nvarchar](500) NULL,
	[diachi] [nvarchar](500) NULL,
	[thuoc_lucluong] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clonebidontocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clonebidontocao](
	[id_bidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtintocao] [int] NULL,
	[bidon_tochuc_canhan] [nvarchar](500) NULL,
	[hoten_canhan] [nvarchar](500) NULL,
	[sohieu_cand] [nvarchar](150) NULL,
	[nghe_nghiep] [nvarchar](500) NULL,
	[capbac] [nvarchar](500) NULL,
	[chucvu] [nvarchar](500) NULL,
	[ten_coquandonvi] [nvarchar](500) NULL,
	[diachi] [nvarchar](500) NULL,
	[thuoc_lucluong] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clonenhatkyguidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clonenhatkyguidon](
	[id_nhatky_guidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtinkhieunai] [int] NULL,
	[nguondon_bandau] [nvarchar](max) NULL,
	[ngay_vietdon] [date] NULL,
	[ngay_nhandon_bandau] [date] NULL,
	[canbo_tiepnhan_bandau] [nvarchar](max) NULL,
	[coquan_chuyenden] [nvarchar](max) NULL,
	[kyhieu_donvi] [nvarchar](50) NULL,
	[so_congvan] [nvarchar](50) NULL,
	[hinhthuc_bandau_cua_donthu] [nvarchar](max) NULL,
	[hinhthuc_tiepnhan] [nvarchar](max) NULL,
	[ngay_tiepnhan] [date] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clonenhatkyguidontocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clonenhatkyguidontocao](
	[id_nhatky_guidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtintocao] [int] NULL,
	[ngaynhan_dontocao_bandau] [date] NULL,
	[ngay_tocao] [date] NULL,
	[canbo_tiepnhan_bandau] [nvarchar](max) NULL,
	[coquan_chuyenden] [nvarchar](max) NULL,
	[kyhieu_donvi] [nvarchar](50) NULL,
	[so_congvan] [nvarchar](50) NULL,
	[hinhthuc_bandau_cua_donthu] [nvarchar](max) NULL,
	[hinhthuc_tiepnhan] [nvarchar](max) NULL,
	[ngay_tiepnhan] [date] NULL,
	[nguondon_bandau] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cloneThongtinkhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cloneThongtinkhieunai](
	[id_thongtinhieunai] [int] IDENTITY(1,1) NOT NULL,
	[ma_donthu_khieunai] [nvarchar](50) NOT NULL,
	[ma_canbo_nhapdulieu] [int] NULL,
	[ma_donvi_nhapdulieu] [int] NULL,
	[tochuc_canhan] [int] NULL,
	[nacdanh_codanh] [int] NULL,
	[chuky_nhieunguoi_motnguoi] [int] NULL,
	[loai_don] [nvarchar](50) NULL,
	[tomtat_noidung] [nvarchar](max) NULL,
	[dieukien_xuly_du_hoackhong] [int] NULL,
	[giayto_tailieugoc_kemtheo] [int] NULL,
	[tinhchat_vuviec_phuctap_dongian] [int] NULL,
	[ma_khieunai] [nvarchar](5) NULL,
	[khieunai_lienquanden_thamquyen_nhieucand_co_khong] [int] NULL,
	[khieunai_conoidung_tocao] [int] NULL,
	[lydo_khongdu_dieukien] [nvarchar](max) NULL,
	[noigui] [nvarchar](max) NULL,
	[tailieu_dinhkem] [nvarchar](max) NULL,
	[ngaygio_nhap] [nvarchar](max) NULL,
	[ngaygio_sua] [nvarchar](max) NULL,
	[status_sua_xoa] [int] NULL,
	[donvichuyenden] [int] NULL,
	[ma_quatrinhgiaiquyet_donvichuyenden] [int] NULL,
	[ten_canhan_tochuc] [nvarchar](500) NULL,
	[sdt] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[so_cmnd] [nvarchar](50) NULL,
	[ngaycap_cmnd] [date] NULL,
	[noicap_cmnd] [nvarchar](500) NULL,
	[dia_chi] [nvarchar](max) NULL,
	[ten_cqdv_canhan] [nvarchar](max) NULL,
	[nguoi_ky_trong_don] [nvarchar](max) NULL,
	[ghi_chu] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clonethongtintocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clonethongtintocao](
	[id_thongtintocao1] [int] IDENTITY(1,1) NOT NULL,
	[ma_donthu_tocao] [nvarchar](50) NOT NULL,
	[ma_canbo_nhapdulieu] [int] NULL,
	[ma_donvi] [int] NULL,
	[tochuc_canhan] [int] NULL,
	[nacdanh_codanh] [int] NULL,
	[hinhthuc_tocao] [nvarchar](50) NULL,
	[tomtat_noidung] [nvarchar](max) NULL,
	[dieukien_xuly_du_hoackhong] [int] NULL,
	[giayto_tailieugoc_kemtheo] [int] NULL,
	[tinhchat_vuviec_phuctap_dongian] [int] NULL,
	[ma_tocao] [nvarchar](5) NULL,
	[tocao_lienquanden_thamquyen_nhieucand_co_khong] [int] NULL,
	[tocao_conoidung_khieunai] [int] NULL,
	[tocao_nhieunoidung_linhvuc] [int] NULL,
	[lydo_khongdu_dieukien] [nvarchar](max) NULL,
	[xuly_tocao_khongthuoc_thamquyen] [nvarchar](250) NULL,
	[chuyentocao_chodonvingoai] [nvarchar](max) NULL,
	[duoc_nhanketqua] [int] NULL,
	[duoc_baove] [int] NULL,
	[yeucaukhac] [nvarchar](max) NULL,
	[noigui] [nvarchar](max) NULL,
	[tailieu_dinhkem] [nvarchar](max) NULL,
	[ngaygio_nhap] [nvarchar](max) NULL,
	[ngaygio_sua] [nvarchar](max) NULL,
	[status_sua_xoa] [int] NULL,
	[donvichuyenden] [int] NULL,
	[ma_quatrinhgiaiquyet_donvichuyenden] [int] NULL,
	[ten_canhan_tochuc] [nvarchar](500) NULL,
	[sdt] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[so_cmnd] [nvarchar](50) NULL,
	[ngaycap_cmnd] [date] NULL,
	[noicap_cmnd] [nvarchar](500) NULL,
	[dia_chi] [nvarchar](max) NULL,
	[ten_cqdv_canhan] [nvarchar](max) NULL,
	[nguoi_ky_trong_don] [nvarchar](max) NULL,
	[ghi_chu] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_canbochiensy]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_canbochiensy](
	[ma_donvi_tb_donvi] [int] NOT NULL,
	[ma_canbo] [int] IDENTITY(1,1) NOT NULL,
	[sohieu_cand] [nvarchar](50) NOT NULL,
	[hoten_chiensy] [nvarchar](50) NOT NULL,
	[ten_dangnhap] [varchar](50) NOT NULL,
	[matkhau_dangnhap] [varchar](100) NOT NULL,
	[capbac] [nvarchar](50) NOT NULL,
	[chucvu] [nvarchar](50) NOT NULL,
	[quyenhan] [int] NOT NULL,
 CONSTRAINT [PK_tb_canbochiensy_1] PRIMARY KEY CLUSTERED 
(
	[ma_canbo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_capgiaiquyet]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_capgiaiquyet](
	[id] [int] NULL,
	[capgiaiquyet] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_donvi]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_donvi](
	[ma_donvi] [int] IDENTITY(1,1) NOT NULL,
	[ten_donvi] [nvarchar](100) NOT NULL,
	[kyhieu_donvi] [nvarchar](50) NULL,
 CONSTRAINT [PK_tb_donvi] PRIMARY KEY CLUSTERED 
(
	[ma_donvi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_dvchiutrachnhiemgiaiquyet]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_dvchiutrachnhiemgiaiquyet](
	[id] [int] NULL,
	[donvichiutrachnhiemgiaiquyet] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_status_sua_xoa_donthukhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_status_sua_xoa_donthukhieunai](
	[id_trangthai_donthukhieunai] [int] NOT NULL,
	[id_thongtinkhieunai] [int] NULL,
	[status_sua_xoa] [int] NULL,
 CONSTRAINT [PK_tb_status_sua_xoa_donthukhieunai] PRIMARY KEY CLUSTERED 
(
	[id_trangthai_donthukhieunai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_temple_hinhthuc_xuly]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_temple_hinhthuc_xuly](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Forward] [int] NULL,
	[Direct handling] [int] NULL,
	[Untreated] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_temple_statuss]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_temple_statuss](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Finish] [int] NULL,
	[Processing] [int] NULL,
	[Out of date] [int] NULL,
	[No process] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_test]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_test](
	[id_bidon] [int] IDENTITY(1,1) NOT NULL,
	[id_thongtinkhieunai] [int] NULL,
	[bidon_tochuc_canhan] [nvarchar](500) NULL,
	[hoten_canhan] [nvarchar](500) NULL,
	[sohieu_cand] [nvarchar](150) NULL,
	[nghe_nghiep] [nvarchar](500) NULL,
	[capbac] [nvarchar](500) NULL,
	[chucvu] [nvarchar](500) NULL,
	[ten_coquandonvi] [nvarchar](500) NULL,
	[diachi] [nvarchar](500) NULL,
	[thuoc_lucluong] [nvarchar](500) NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_bidon]  WITH CHECK ADD  CONSTRAINT [FK_tb_bidon_tb_thongtinkhieunai] FOREIGN KEY([id_thongtinkhieunai])
REFERENCES [dbo].[tb_thongtinkhieunai] ([id_thongtinhieunai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_bidon] CHECK CONSTRAINT [FK_tb_bidon_tb_thongtinkhieunai]
GO
ALTER TABLE [dbo].[tb_bidon_tocao]  WITH CHECK ADD  CONSTRAINT [FK_tb_bidon_tocao_tb_thongtintocao] FOREIGN KEY([id_thongtintocao])
REFERENCES [dbo].[tb_thongtintocao] ([id_thongtintocao1])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_bidon_tocao] CHECK CONSTRAINT [FK_tb_bidon_tocao_tb_thongtintocao]
GO
ALTER TABLE [dbo].[tb_canbochiensy]  WITH CHECK ADD  CONSTRAINT [FK_tb_canbochiensy_tb_donvi] FOREIGN KEY([ma_donvi_tb_donvi])
REFERENCES [dbo].[tb_donvi] ([ma_donvi])
GO
ALTER TABLE [dbo].[tb_canbochiensy] CHECK CONSTRAINT [FK_tb_canbochiensy_tb_donvi]
GO
ALTER TABLE [dbo].[tb_giaiquyetkhieunai]  WITH CHECK ADD  CONSTRAINT [FK_tb_giaiquyetkhieunai_tb_thongtinkhieunai] FOREIGN KEY([id_thongtinkhieunai])
REFERENCES [dbo].[tb_thongtinkhieunai] ([id_thongtinhieunai])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_giaiquyetkhieunai] CHECK CONSTRAINT [FK_tb_giaiquyetkhieunai_tb_thongtinkhieunai]
GO
ALTER TABLE [dbo].[tb_giaiquyettocao]  WITH CHECK ADD  CONSTRAINT [FK_tb_giaiquyettocao_tb_thongtintocao] FOREIGN KEY([id_thongtintocao])
REFERENCES [dbo].[tb_thongtintocao] ([id_thongtintocao1])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_giaiquyettocao] CHECK CONSTRAINT [FK_tb_giaiquyettocao_tb_thongtintocao]
GO
ALTER TABLE [dbo].[tb_nhatky_guidon]  WITH CHECK ADD  CONSTRAINT [FK_tb_nhatky_guidon_tb_thongtinkhieunai] FOREIGN KEY([id_thongtinkhieunai])
REFERENCES [dbo].[tb_thongtinkhieunai] ([id_thongtinhieunai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_nhatky_guidon] CHECK CONSTRAINT [FK_tb_nhatky_guidon_tb_thongtinkhieunai]
GO
ALTER TABLE [dbo].[tb_nhatky_guidon_tocao]  WITH CHECK ADD  CONSTRAINT [FK_tb_nhatky_guidon_tocao_tb_thongtintocao] FOREIGN KEY([id_thongtintocao])
REFERENCES [dbo].[tb_thongtintocao] ([id_thongtintocao1])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_nhatky_guidon_tocao] CHECK CONSTRAINT [FK_tb_nhatky_guidon_tocao_tb_thongtintocao]
GO
ALTER TABLE [dbo].[tb_status_sua_xoa_donthukhieunai]  WITH CHECK ADD  CONSTRAINT [FK_tb_status_sua_xoa_donthukhieunai_tb_thongtinkhieunai] FOREIGN KEY([id_thongtinkhieunai])
REFERENCES [dbo].[tb_thongtinkhieunai] ([id_thongtinhieunai])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tb_status_sua_xoa_donthukhieunai] CHECK CONSTRAINT [FK_tb_status_sua_xoa_donthukhieunai_tb_thongtinkhieunai]
GO
ALTER TABLE [dbo].[tb_thongtinkhieunai]  WITH CHECK ADD  CONSTRAINT [FK_tb_thongtinkhieunai_tb_donvi] FOREIGN KEY([ma_donvi_nhapdulieu])
REFERENCES [dbo].[tb_donvi] ([ma_donvi])
GO
ALTER TABLE [dbo].[tb_thongtinkhieunai] CHECK CONSTRAINT [FK_tb_thongtinkhieunai_tb_donvi]
GO
ALTER TABLE [dbo].[tb_thongtintocao]  WITH CHECK ADD  CONSTRAINT [FK_tb_thongtintocao_tb_donvi] FOREIGN KEY([ma_donvi])
REFERENCES [dbo].[tb_donvi] ([ma_donvi])
GO
ALTER TABLE [dbo].[tb_thongtintocao] CHECK CONSTRAINT [FK_tb_thongtintocao_tb_donvi]
GO
/****** Object:  StoredProcedure [dbo].[_bidon_canchuyen]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[_bidon_canchuyen]
@id_thongtinkhieunai int
as
select * from tb_bidon
where id_thongtinkhieunai=@id_thongtinkhieunai
GO
/****** Object:  StoredProcedure [dbo].[_thongtinkhieunai_canchuyen]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[_thongtinkhieunai_canchuyen]
@id_thongtinkhieunai int
as
select * from tb_thongtinkhieunai
where id_thongtinhieunai=@id_thongtinkhieunai
GO
/****** Object:  StoredProcedure [dbo].[bieudo_cot_donthukhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[bieudo_cot_donthukhieunai]
@madonvi int,
@nam int
as
select tong=count(*),thang from tb_bieudocot_donthukhieunai
where nam=@nam and ma_donvi_nhapdulieu=@madonvi
group by thang
GO
/****** Object:  StoredProcedure [dbo].[bieudo_cot_donthutocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[bieudo_cot_donthutocao]
@madonvi int,
@nam int
as
select tong=count(*),thang from tb_bieudocot_donthutocao
where nam=@nam and ma_donvi=@madonvi
group by thang
GO
/****** Object:  StoredProcedure [dbo].[check_chuyendonthu]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[check_chuyendonthu]
@id_quatrinhgiaiquyetkhieunai int
as
select forward,hinhthuc_xuly from tb_giaiquyetkhieunai where id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyetkhieunai
GO
/****** Object:  StoredProcedure [dbo].[check_chuyentocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[check_chuyentocao]
@id_quatrinhgiaiquyettocao int
as
select forward,hinhthuc_xuly from tb_giaiquyettocao where id_quatrinhgiaiquyettocao=@id_quatrinhgiaiquyettocao
GO
/****** Object:  StoredProcedure [dbo].[check_ketthucgiaiquyet]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[check_ketthucgiaiquyet]
@id_quatrinhgiaiquyet int
as
select ketthucgiaiquyet from tb_giaiquyetkhieunai
where id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyet
GO
/****** Object:  StoredProcedure [dbo].[check_ketthucgiaiquyettocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[check_ketthucgiaiquyettocao]
@id_quatrinhgiaiquyettocao int
as
select ketthucgiaiquyet from tb_giaiquyettocao
where id_quatrinhgiaiquyettocao=@id_quatrinhgiaiquyettocao
GO
/****** Object:  StoredProcedure [dbo].[check_madonthu_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[check_madonthu_linq]
@ma_donvi int,
@ma_donthu_khieunai nvarchar(50)
as
begin
declare @status int
if exists ( select * from tb_thongtinkhieunai where ma_donthu_khieunai=@ma_donthu_khieunai and ma_donvi_nhapdulieu = @ma_donvi)
set @status =1
else 
set @status =0
return @status
end
GO
/****** Object:  StoredProcedure [dbo].[check_madonthutocao_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[check_madonthutocao_linq]
@ma_donvi int,
@ma_donthu_tocao nvarchar(50)
as
begin
declare @status int
if exists ( select * from tb_thongtintocao where ma_donthu_tocao=@ma_donthu_tocao and ma_donvi = @ma_donvi)
set @status =1
else 
set @status =0
return @status
end
GO
/****** Object:  StoredProcedure [dbo].[check_matocao_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[check_matocao_linq]
@ma_donvi int,
@ma_donthu_tocao nvarchar(50)
as
begin
declare @status int
if exists ( select * from tb_thongtintocao where ma_donthu_tocao=@ma_donthu_tocao and ma_donvi = @ma_donvi)
set @status =1
else 
set @status =0
return @status
end
GO
/****** Object:  StoredProcedure [dbo].[check_solangiaiquyet]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[check_solangiaiquyet]
@madonvi int,
@madonthu nvarchar(50),
@solan nvarchar(50)
as
select solan_khieunai 
from tb_thongtinkhieunai,tb_giaiquyetkhieunai 
where tb_thongtinkhieunai.id_thongtinhieunai = tb_giaiquyetkhieunai.id_thongtinkhieunai and ma_donvi_nhapdulieu=@madonvi
	  and ma_donthu_khieunai=@madonthu and solan_khieunai =@solan
GO
/****** Object:  StoredProcedure [dbo].[check_update_insert]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[check_update_insert]
@ma_donvi_tb_donvi int,
@ten_dangnhap nvarchar(50)
as
begin
declare @status int
if exists ( select * from tb_canbochiensy join tb_donvi on tb_canbochiensy.ma_donvi_tb_donvi =tb_donvi.ma_donvi where ma_donvi_tb_donvi=@ma_donvi_tb_donvi and ten_dangnhap = @ten_dangnhap)
set @status =1
else 
set @status =0
select @status
end
GO
/****** Object:  StoredProcedure [dbo].[check_update_insert_lnq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[check_update_insert_lnq]
@ma_donvi_tb_donvi int,
@ten_dangnhap nvarchar(50)
as
begin
declare @status int
if exists ( select * from tb_canbochiensy join tb_donvi on tb_canbochiensy.ma_donvi_tb_donvi =tb_donvi.ma_donvi where ma_donvi_tb_donvi=@ma_donvi_tb_donvi and ten_dangnhap = @ten_dangnhap)
set @status =1
else 
set @status =0
return @status
end
GO
/****** Object:  StoredProcedure [dbo].[check_update_insert_quatrinhgiaiquyetkhieunai_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[check_update_insert_quatrinhgiaiquyetkhieunai_linq]
@id_quatrinhgiaiquyetkhieunai int
as
begin
declare @status int
if exists ( select id_quatrinhgiaiquyetkhieunai from tb_giaiquyetkhieunai where id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyetkhieunai)
set @status =1
else 
set @status =0
return @status
end
GO
/****** Object:  StoredProcedure [dbo].[check_xoadonthu]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[check_xoadonthu]
@id_thongtinkhieunai int
as
select id_quatrinhgiaiquyetkhieunai from tb_thongtinkhieunai
Left join tb_giaiquyetkhieunai
on tb_thongtinkhieunai.id_thongtinhieunai = tb_giaiquyetkhieunai.id_thongtinkhieunai
where  id_thongtinhieunai=@id_thongtinkhieunai
GO
/****** Object:  StoredProcedure [dbo].[check_xoatocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[check_xoatocao]
@id_thongtintocao int
as
select id_quatrinhgiaiquyettocao from tb_thongtintocao 
left join tb_giaiquyettocao
on tb_thongtintocao.id_thongtintocao1 = tb_giaiquyettocao.id_thongtintocao
where id_thongtintocao1=@id_thongtintocao
GO
/****** Object:  StoredProcedure [dbo].[chuyendonthukhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[chuyendonthukhieunai](
@id_thongtinkhieunai int,
@ma_donvi_nhapdulieu int,
@donvichuyenden int,
@ma_quatrinhgiaiquyet_donvichuyenden int)
as
begin
declare @status int
insert into cloneThongtinkhieunai
select [ma_donthu_khieunai]
      ,[ma_canbo_nhapdulieu]
      ,[ma_donvi_nhapdulieu]
      ,[tochuc_canhan]
      ,[nacdanh_codanh]
      ,[chuky_nhieunguoi_motnguoi]
      ,[loai_don]
      ,[tomtat_noidung]
      ,[dieukien_xuly_du_hoackhong]
      ,[giayto_tailieugoc_kemtheo]
      ,[tinhchat_vuviec_phuctap_dongian]
      ,[ma_khieunai]
      ,[khieunai_lienquanden_thamquyen_nhieucand_co_khong]
      ,[khieunai_conoidung_tocao]
      ,[lydo_khongdu_dieukien]
      ,[noigui]
      ,[tailieu_dinhkem]
      ,[ngaygio_nhap]
      ,[ngaygio_sua]
      ,[status_sua_xoa]
      ,[donvichuyenden]
      ,[ma_quatrinhgiaiquyet_donvichuyenden]
      ,[ten_canhan_tochuc]
      ,[sdt]
      ,[email]
      ,[so_cmnd]
      ,[ngaycap_cmnd]
      ,[noicap_cmnd]
      ,[dia_chi]
      ,[ten_cqdv_canhan]
      ,[nguoi_ky_trong_don]
      ,[ghi_chu] from tb_thongtinkhieunai
where id_thongtinhieunai =@id_thongtinkhieunai
insert into clonenhatkyguidon
select [id_thongtinkhieunai]
      ,[nguondon_bandau]
      ,[ngay_vietdon]
      ,[ngay_nhandon_bandau]
      ,[canbo_tiepnhan_bandau]
      ,[coquan_chuyenden]
      ,[kyhieu_donvi]
      ,[so_congvan]
      ,[hinhthuc_bandau_cua_donthu]
      ,[hinhthuc_tiepnhan]
      ,[ngay_tiepnhan]  from tb_nhatky_guidon
where id_thongtinkhieunai=@id_thongtinkhieunai
insert into clonebidon
select [id_thongtinkhieunai]
      ,[bidon_tochuc_canhan]
      ,[hoten_canhan]
      ,[sohieu_cand]
      ,[nghe_nghiep]
      ,[capbac]
      ,[chucvu]
      ,[ten_coquandonvi]
      ,[diachi]
      ,[thuoc_lucluong] from tb_bidon
where id_thongtinkhieunai=@id_thongtinkhieunai
update  cloneThongtinkhieunai set ma_donvi_nhapdulieu=@ma_donvi_nhapdulieu, donvichuyenden=@donvichuyenden,ma_quatrinhgiaiquyet_donvichuyenden=@ma_quatrinhgiaiquyet_donvichuyenden
insert into tb_thongtinkhieunai
select [ma_donthu_khieunai]
      ,[ma_canbo_nhapdulieu]
      ,[ma_donvi_nhapdulieu]
      ,[tochuc_canhan]
      ,[nacdanh_codanh]
      ,[chuky_nhieunguoi_motnguoi]
      ,[loai_don]
      ,[tomtat_noidung]
      ,[dieukien_xuly_du_hoackhong]
      ,[giayto_tailieugoc_kemtheo]
      ,[tinhchat_vuviec_phuctap_dongian]
      ,[ma_khieunai]
      ,[khieunai_lienquanden_thamquyen_nhieucand_co_khong]
      ,[khieunai_conoidung_tocao]
      ,[lydo_khongdu_dieukien]
      ,[noigui]
      ,[tailieu_dinhkem]
      ,[ngaygio_nhap]
      ,[ngaygio_sua]
      ,[status_sua_xoa]
      ,[donvichuyenden]
      ,[ma_quatrinhgiaiquyet_donvichuyenden]
      ,[ten_canhan_tochuc]
      ,[sdt]
      ,[email]
      ,[so_cmnd]
      ,[ngaycap_cmnd]
      ,[noicap_cmnd]
      ,[dia_chi]
      ,[ten_cqdv_canhan]
      ,[nguoi_ky_trong_don]
      ,[ghi_chu] from cloneThongtinkhieunai
set @status=SCOPE_IDENTITY()
update clonenhatkyguidon set id_thongtinkhieunai=@status
insert into tb_nhatky_guidon
select [id_thongtinkhieunai]
      ,[nguondon_bandau]
      ,[ngay_vietdon]
      ,[ngay_nhandon_bandau]
      ,[canbo_tiepnhan_bandau]
      ,[coquan_chuyenden]
      ,[kyhieu_donvi]
      ,[so_congvan]
      ,[hinhthuc_bandau_cua_donthu]
      ,[hinhthuc_tiepnhan]
      ,[ngay_tiepnhan] from clonenhatkyguidon
update clonebidon set id_thongtinkhieunai=@status
insert into tb_bidon
select [id_thongtinkhieunai]
      ,[bidon_tochuc_canhan]
      ,[hoten_canhan]
      ,[sohieu_cand]
      ,[nghe_nghiep]
      ,[capbac]
      ,[chucvu]
      ,[ten_coquandonvi]
      ,[diachi]
      ,[thuoc_lucluong] from clonebidon
delete from clonebidon
where id_thongtinkhieunai=@status
delete from clonenhatkyguidon
where id_thongtinkhieunai=@status
delete from cloneThongtinkhieunai
where id_thongtinhieunai=@status
end
GO
/****** Object:  StoredProcedure [dbo].[chuyendonthutocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[chuyendonthutocao](
@id_thongtintocao int,
@ma_donvi_nhapdulieu int,
@donvichuyenden int,
@ma_quatrinhgiaiquyet_donvichuyenden int)
as
begin
declare @status int
insert into clonethongtintocao
select [ma_donthu_tocao]
      ,[ma_canbo_nhapdulieu]
      ,[ma_donvi]
      ,[tochuc_canhan]
      ,[nacdanh_codanh]
      ,[hinhthuc_tocao]
      ,[tomtat_noidung]
      ,[dieukien_xuly_du_hoackhong]
      ,[giayto_tailieugoc_kemtheo]
      ,[tinhchat_vuviec_phuctap_dongian]
      ,[ma_tocao]
      ,[tocao_lienquanden_thamquyen_nhieucand_co_khong]
      ,[tocao_conoidung_khieunai]
      ,[tocao_nhieunoidung_linhvuc]
      ,[lydo_khongdu_dieukien]
      ,[xuly_tocao_khongthuoc_thamquyen]
      ,[chuyentocao_chodonvingoai]
      ,[duoc_nhanketqua]
      ,[duoc_baove]
      ,[yeucaukhac]
      ,[noigui]
      ,[tailieu_dinhkem]
      ,[ngaygio_nhap]
      ,[ngaygio_sua]
      ,[status_sua_xoa]
      ,[donvichuyenden]
      ,[ma_quatrinhgiaiquyet_donvichuyenden]
      ,[ten_canhan_tochuc]
      ,[sdt]
      ,[email]
      ,[so_cmnd]
      ,[ngaycap_cmnd]
      ,[noicap_cmnd]
      ,[dia_chi]
      ,[ten_cqdv_canhan]
      ,[nguoi_ky_trong_don]
	  ,[ghi_chu] from tb_thongtintocao
where id_thongtintocao1 =@id_thongtintocao
insert into clonenhatkyguidontocao
select [id_thongtintocao]
      ,[ngaynhan_dontocao_bandau]
      ,[ngay_tocao]
      ,[canbo_tiepnhan_bandau]
      ,[coquan_chuyenden]
      ,[kyhieu_donvi]
      ,[so_congvan]
      ,[hinhthuc_bandau_cua_donthu]
      ,[hinhthuc_tiepnhan]
      ,[ngay_tiepnhan]  from tb_nhatky_guidon_tocao
where id_thongtintocao=@id_thongtintocao
insert into clonebidontocao
select [id_thongtintocao]
      ,[bidon_tochuc_canhan]
      ,[hoten_canhan]
      ,[sohieu_cand]
      ,[nghe_nghiep]
      ,[capbac]
      ,[chucvu]
      ,[ten_coquandonvi]
      ,[diachi]
      ,[thuoc_lucluong] from tb_bidon_tocao
where id_thongtintocao=@id_thongtintocao
update  clonethongtintocao set ma_donvi=@ma_donvi_nhapdulieu, donvichuyenden=@donvichuyenden,ma_quatrinhgiaiquyet_donvichuyenden=@ma_quatrinhgiaiquyet_donvichuyenden
insert into tb_thongtintocao
select [ma_donthu_tocao]
      ,[ma_canbo_nhapdulieu]
      ,[ma_donvi]
      ,[tochuc_canhan]
      ,[nacdanh_codanh]
      ,[hinhthuc_tocao]
      ,[tomtat_noidung]
      ,[dieukien_xuly_du_hoackhong]
      ,[giayto_tailieugoc_kemtheo]
      ,[tinhchat_vuviec_phuctap_dongian]
      ,[ma_tocao]
      ,[tocao_lienquanden_thamquyen_nhieucand_co_khong]
      ,[tocao_conoidung_khieunai]
      ,[tocao_nhieunoidung_linhvuc]
      ,[lydo_khongdu_dieukien]
      ,[xuly_tocao_khongthuoc_thamquyen]
      ,[chuyentocao_chodonvingoai]
      ,[duoc_nhanketqua]
      ,[duoc_baove]
      ,[yeucaukhac]
      ,[noigui]
      ,[tailieu_dinhkem]
      ,[ngaygio_nhap]
      ,[ngaygio_sua]
      ,[status_sua_xoa]
      ,[donvichuyenden]
      ,[ma_quatrinhgiaiquyet_donvichuyenden]
      ,[ten_canhan_tochuc]
      ,[sdt]
      ,[email]
      ,[so_cmnd]
      ,[ngaycap_cmnd]
      ,[noicap_cmnd]
      ,[dia_chi]
      ,[ten_cqdv_canhan]
      ,[nguoi_ky_trong_don]
	  ,[ghi_chu] from clonethongtintocao
set @status=SCOPE_IDENTITY()
update clonenhatkyguidontocao set id_thongtintocao=@status
insert into tb_nhatky_guidon_tocao
select [id_thongtintocao]
      ,[ngaynhan_dontocao_bandau]
      ,[ngay_tocao]
      ,[canbo_tiepnhan_bandau]
      ,[coquan_chuyenden]
      ,[kyhieu_donvi]
      ,[so_congvan]
      ,[hinhthuc_bandau_cua_donthu]
      ,[hinhthuc_tiepnhan]
      ,[ngay_tiepnhan] from clonenhatkyguidontocao
update clonebidontocao set id_thongtintocao=@status
insert into tb_bidon_tocao
select [id_thongtintocao]
      ,[bidon_tochuc_canhan]
      ,[hoten_canhan]
      ,[sohieu_cand]
      ,[nghe_nghiep]
      ,[capbac]
      ,[chucvu]
      ,[ten_coquandonvi]
      ,[diachi]
      ,[thuoc_lucluong] from clonebidontocao
delete from clonebidontocao
where id_thongtintocao=@status
delete from clonenhatkyguidontocao
where id_thongtintocao=@status
delete from clonethongtintocao
where id_thongtintocao1=@status
end
GO
/****** Object:  StoredProcedure [dbo].[delete_null_nhatky_bidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[delete_null_nhatky_bidon]
as
delete from tb_bidon
where id_thongtinkhieunai is null
delete from nhatky_guidon
where id_thongtinkhieunai is null
GO
/****** Object:  StoredProcedure [dbo].[dinhdanh_canbo]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[dinhdanh_canbo]
@ma_donvi int,
@tendangnhap nvarchar(50)
as
select *
from tb_canbochiensy join tb_donvi on tb_canbochiensy.ma_donvi_tb_donvi =tb_donvi.ma_donvi
where ma_donvi_tb_donvi=@ma_donvi and ten_dangnhap=@tendangnhap
GO
/****** Object:  StoredProcedure [dbo].[get_donvinhan]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[get_donvinhan]
@id_quatrinhgiaiquyetkhieunai int
as
select donvinhan from tb_giaiquyetkhieunai
where id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyetkhieunai
GO
/****** Object:  StoredProcedure [dbo].[list_donvi]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[list_donvi]
as
select * from tb_donvi
GO
/****** Object:  StoredProcedure [dbo].[list_phanloai_khieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[list_phanloai_khieunai]
as
select * from tb_phanloai_khieunai
GO
/****** Object:  StoredProcedure [dbo].[list_phanloai_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[list_phanloai_tocao]
as
select * from tb_phanloai_tocao
GO
/****** Object:  StoredProcedure [dbo].[list_quatrinhgiaiquyet]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[list_quatrinhgiaiquyet]
@madonvi int
as
select 
bidon_co_dongy_ketqua,hinhthuc_xuly,statuss,id_quatrinhgiaiquyetkhieunai,id_thongtinkhieunai,
ma_donthu_khieunai,solan_khieunai,ten_donvinhan,capgiaiquyet,songay_giaiquyet,ngay_ketthucxacminh,cabo_thuly,ketqua_xacminh,tomtat_ketqua_giaiquyet
from tb_giaiquyetkhieunai left join tb_thongtinkhieunai 
on tb_giaiquyetkhieunai.id_thongtinkhieunai= tb_thongtinkhieunai.id_thongtinhieunai
where ma_donvi_nhapdulieu=@madonvi
order by ngaygio_nhap
GO
/****** Object:  StoredProcedure [dbo].[list_quatrinhgiaiquyettocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[list_quatrinhgiaiquyettocao]
@madonvi int
as
select
hinhthuc_xuly=(case
when hinhthuc_xuly =1 then N'Chuyển đơn vị khác'
when hinhthuc_xuly =0 then N'Trực tiếp xử lý'
when hinhthuc_xuly =2 then N'Không xử lý'
end),statuss, id_quatrinhgiaiquyettocao,id_thongtintocao,ma_donthu_tocao,sola_tocao,donvinhan,capgiaiquyet,songay_giaiquyet,ngay_ketthucxacminh,cabo_thuly,ketqua_xacminh,tomtat_ketqua_xuly,ketthucgiaiquyet,date_ngayketthuc
from tb_thongtintocao T1 inner join  tb_giaiquyettocao T2
on T1.id_thongtintocao1= T2.id_thongtintocao
where ma_donvi=@madonvi
GO
/****** Object:  StoredProcedure [dbo].[list_thongtincanbo_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[list_thongtincanbo_linq]
@ma_donvi int
as
select  case
when quyenhan =2 then N'Chỉ được xem' 
when quyenhan=1  then N'Thêm, sửa, Xóa, Xem'
when quyenhan=0 then N'Admin'
end as quyenhan,sohieu_cand,hoten_chiensy,ten_dangnhap,capbac,chucvu,ten_donvi,ma_canbo
from tb_canbochiensy T1 inner join tb_donvi T2
on T1.ma_donvi_tb_donvi=T2.ma_donvi
where ma_donvi_tb_donvi=@ma_donvi
GO
/****** Object:  StoredProcedure [dbo].[list_thongtindonthukhieunai_gopbang_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[list_thongtindonthukhieunai_gopbang_linq]
@ma_donvi int
as
select  case
when dieukien_xuly_du_hoackhong =0 then N'Đủ điều kiện xử lý' 
when dieukien_xuly_du_hoackhong=1  then N'Không đủ ĐKXL'
end as dieukien_xuly_du_hoackhong,ma_donthu_khieunai,ten_canhan_tochuc,loai_don,tomtat_noidung,id_thongtinhieunai,ghi_chu
from tb_thongtinkhieunai
where  ma_donvi_nhapdulieu=@ma_donvi
GO
/****** Object:  StoredProcedure [dbo].[list_thongtintocao_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[list_thongtintocao_linq]
@ma_donvi int
as
select  case
when dieukien_xuly_du_hoackhong =0 then N'Đủ điều kiện xử lý' 
when dieukien_xuly_du_hoackhong=1  then N'Không đủ ĐKXL'
end as dieukien_xuly_du_hoackhong,ma_donthu_tocao,ten_canhan_tochuc,hinhthuc_tocao,tomtat_noidung,id_thongtintocao1,ghi_chu
from tb_thongtintocao
where  ma_donvi=@ma_donvi
GO
/****** Object:  StoredProcedure [dbo].[listtbbidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[listtbbidon]
@ma_donvi int
as
select id_bidon,id_thongtinhieunai,bidon_tochuc_canhan from tb_bidon
right join tb_thongtinkhieunai on tb_thongtinkhieunai.id_thongtinhieunai =tb_bidon.id_thongtinkhieunai
where ma_donvi_nhapdulieu=@ma_donvi
GO
/****** Object:  StoredProcedure [dbo].[listtbnhatky]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[listtbnhatky]
@ma_donvi int
as
select id_nhatky_guidon,id_thongtinhieunai,nguondon_bandau from tb_nhatky_guidon
right join tb_thongtinkhieunai on tb_thongtinkhieunai.id_thongtinhieunai =tb_nhatky_guidon.id_thongtinkhieunai
where ma_donvi_nhapdulieu=@ma_donvi
GO
/****** Object:  StoredProcedure [dbo].[listtbthongtinkhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[listtbthongtinkhieunai]
@ma_donvi int
as
select * from tb_thongtinkhieunai
where ma_donvi_nhapdulieu=@ma_donvi order by ngaygio_nhap
GO
/****** Object:  StoredProcedure [dbo].[load_sua_canbo]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[load_sua_canbo]
@ma_canbo int
as
select ma_donvi,kyhieu_donvi,ten_donvi,hoten_chiensy,ten_dangnhap,sohieu_cand,matkhau_dangnhap,capbac,chucvu,quyenhan
from tb_canbochiensy inner join tb_donvi on tb_canbochiensy.ma_donvi_tb_donvi =tb_donvi.ma_donvi
where ma_canbo=@ma_canbo
GO
/****** Object:  StoredProcedure [dbo].[login_canbo_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[login_canbo_linq]
@ma_donvi_tb_donvi int,
@ten_dangnhap nvarchar(50),
@matkhau_dangnhap nvarchar(50)
as
begin
declare @status int
if exists ( select * from tb_canbochiensy join tb_donvi on tb_canbochiensy.ma_donvi_tb_donvi =tb_donvi.ma_donvi where ma_donvi_tb_donvi=@ma_donvi_tb_donvi and ten_dangnhap = @ten_dangnhap and matkhau_dangnhap=@matkhau_dangnhap)
select @status =1
else 
select @status =0
return @status
end
GO
/****** Object:  StoredProcedure [dbo].[nhatky_guidon_canchuyen]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[nhatky_guidon_canchuyen]
@id_thongtinkhieunai int
as
select * from tb_nhatky_guidon
where id_thongtinkhieunai=@id_thongtinkhieunai
GO
/****** Object:  StoredProcedure [dbo].[stt_donthukhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[stt_donthukhieunai]
as
select MAX(stt_donthukhieunai) from tb_thongtinkhieunai
GO
/****** Object:  StoredProcedure [dbo].[stt_donthukhieunai_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[stt_donthukhieunai_linq]
as
declare @status int
select @status=MAX(stt_donthukhieunai) from tb_thongtinkhieunai
return @status
GO
/****** Object:  StoredProcedure [dbo].[sua_canbo]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sua_canbo] 
	-- Add the parameters for the stored procedure here
	@ma_donvi_tb_donvi int,
	@ma_canbo int,
	@sohieu_cand nvarchar(50),
	@hoten_chiensy nvarchar(50),
	@ten_dangnhap varchar(50),
	@matkhau_dangnhap varchar(100),
	@capbac nvarchar(50),
	@chucvu nvarchar(50),
	@quyenhan int
AS
UPDATE tb_canbochiensy SET
ma_donvi_tb_donvi=@ma_donvi_tb_donvi,
hoten_chiensy=@hoten_chiensy,
ten_dangnhap=@ten_dangnhap,
matkhau_dangnhap=@matkhau_dangnhap,
capbac=@capbac,
chucvu=@chucvu,
quyenhan=@quyenhan,
sohieu_cand=@sohieu_cand
Where ma_canbo=@ma_canbo
GO
/****** Object:  StoredProcedure [dbo].[sua_quatrinhgiaiquyetkhieunai_guiden_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sua_quatrinhgiaiquyetkhieunai_guiden_linq] 
	-- Add the parameters for the stored procedure here
@id_quatrinhgiaiquyetkhieunai int,
@solan_khieunai nvarchar(50),
@capgiaiquyet nvarchar(50),
@noidungdonthu nvarchar(max),
@dv_chiutrachnhiem_giaiquyet nvarchar(50),
@so_congvan nvarchar(50),
@ngaytao_congvan date,
@songay_giaiquyet nvarchar(50),
@ngaybatdau_giaiquyet date,
@ngayketthuc_giaiquyet date,
@hinhthuc_xacminh bit,
@so_kehoach_xacminh nvarchar(50),
@ngaylap_kehoachxacminh date,
@so_quyetdinh_thanhlap nvarchar(50),
@ngaylap_quyetdinh_thanhlap date,
@so_ngayxacminh nvarchar(50),
@ngay_batdauxacminh date,
@ngay_ketthucxacminh date,
@totruong_xacminh nvarchar(50),
@capbac_totruong nvarchar(50),
@chuvu_totruong nvarchar(50),
@thanhvien_trongdoan nvarchar(max),
@cabo_thuly nvarchar(50),
@lanhdao_phutrach nvarchar(50),
@ketqua_xacminh nvarchar(50),
@ngayrut_khieunai date,
@tomtat_ketqua_giaiquyet nvarchar(max),
@date_ngayketthuc date,
@danhgia_viec_giaiquyet bit,
@bidon_co_dongy_ketqua bit,
@so_cb_khongduoc_xetthidua int,
@so_cb_bikiemdiem int,
@so_cb_bikhientrach int,
@so_cb_bicanhcao int,
@so_cb_bigiangchuc int,
@so_cb_bigiangcap int,
@so_cb_bituocdanhhieu int,
@so_cb_xuly_hinhsu int,
@so_tapthe_duocminhoan int,
@so_canhan_duocminhoan int,
@khoiphuc_loiich_nhandan nvarchar(500),
@thuhoi_taisan nvarchar(500)
AS
update tb_giaiquyetkhieunai set
solan_khieunai=@solan_khieunai,
capgiaiquyet=@capgiaiquyet,
noidungdonthu=@noidungdonthu,
dv_chiutrachnhiem_giaiquyet=@dv_chiutrachnhiem_giaiquyet,
so_congvan=@so_congvan,
ngaytao_congvan=@ngaytao_congvan,
songay_giaiquyet=@songay_giaiquyet,
ngaybatdau_giaiquyet=@ngaybatdau_giaiquyet,
ngayketthuc_giaiquyet=@ngayketthuc_giaiquyet,
hinhthuc_xacminh=@hinhthuc_xacminh,
so_kehoach_xacminh=@so_kehoach_xacminh,
ngaylap_kehoachxacminh=@ngaylap_kehoachxacminh,
so_quyetdinh_thanhlap=@so_quyetdinh_thanhlap,
ngaylap_quyetdinh_thanhlap=@ngaylap_quyetdinh_thanhlap,
so_ngayxacminh=@so_ngayxacminh,
ngay_batdauxacminh=@ngay_batdauxacminh,
ngay_ketthucxacminh=@ngay_ketthucxacminh,
totruong_xacminh=@totruong_xacminh,
capbac_totruong=@capbac_totruong,
chuvu_totruong=@chuvu_totruong,
thanhvien_trongdoan=@thanhvien_trongdoan,
cabo_thuly=@cabo_thuly,
lanhdao_phutrach=@lanhdao_phutrach,
ketqua_xacminh=@ketqua_xacminh,
ngayrut_khieunai=@ngayrut_khieunai,
tomtat_ketqua_giaiquyet=@tomtat_ketqua_giaiquyet,
date_ngayketthuc=@date_ngayketthuc,
danhgia_viec_giaiquyet=@danhgia_viec_giaiquyet,
bidon_co_dongy_ketqua=@bidon_co_dongy_ketqua,
so_cb_khongduoc_xetthidua=@so_cb_khongduoc_xetthidua,
so_cb_bikiemdiem=@so_cb_bikiemdiem,
so_cb_bikhientrach=@so_cb_bikhientrach,
so_cb_bicanhcao=@so_cb_bicanhcao,
so_cb_bigiangchuc=@so_cb_bigiangchuc,
so_cb_bigiangcap=@so_cb_bigiangcap,
so_cb_bituocdanhhieu=@so_cb_bituocdanhhieu,
so_cb_xuly_hinhsu=@so_cb_xuly_hinhsu,
so_tapthe_duocminhoan=@so_tapthe_duocminhoan,
so_canhan_duocminhoan=@so_canhan_duocminhoan,
khoiphuc_loiich_nhandan=@khoiphuc_loiich_nhandan,
thuhoi_taisan=@thuhoi_taisan
where id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyetkhieunai
GO
/****** Object:  StoredProcedure [dbo].[sua_quatrinhgiaiquyetkhieunai_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sua_quatrinhgiaiquyetkhieunai_linq] 
	-- Add the parameters for the stored procedure here
@id_quatrinhgiaiquyetkhieunai int,
@id_thongtinkhieunai int,
@solan_khieunai nvarchar(50),
@hinhthuc_xuly nvarchar(50),
@donvinhan int,
@ten_donvinhan nvarchar(50),
@ngaynhan date,
@capgiaiquyet nvarchar(50),
@noidungdonthu nvarchar(max),
@dv_chiutrachnhiem_giaiquyet nvarchar(50),
@so_congvan nvarchar(50),
@ngaytao_congvan date,
@songay_giaiquyet nvarchar(50),
@ngaybatdau_giaiquyet date,
@ngayketthuc_giaiquyet date,
@hinhthuc_xacminh bit,
@so_kehoach_xacminh nvarchar(50),
@ngaylap_kehoachxacminh date,
@so_quyetdinh_thanhlap nvarchar(50),
@ngaylap_quyetdinh_thanhlap date,
@so_ngayxacminh nvarchar(50),
@ngay_batdauxacminh date,
@ngay_ketthucxacminh date,
@totruong_xacminh nvarchar(50),
@capbac_totruong nvarchar(50),
@chuvu_totruong nvarchar(50),
@thanhvien_trongdoan nvarchar(max),
@cabo_thuly nvarchar(50),
@lanhdao_phutrach nvarchar(50),
@ketqua_xacminh nvarchar(50),
@ngayrut_khieunai date,
@tomtat_ketqua_giaiquyet nvarchar(max),
@date_ngayketthuc date,
@danhgia_viec_giaiquyet bit,
@bidon_co_dongy_ketqua bit,
@so_cb_khongduoc_xetthidua int,
@so_cb_bikiemdiem int,
@so_cb_bikhientrach int,
@so_cb_bicanhcao int,
@so_cb_bigiangchuc int,
@so_cb_bigiangcap int,
@so_cb_bituocdanhhieu int,
@so_cb_xuly_hinhsu int,
@so_tapthe_duocminhoan int,
@so_canhan_duocminhoan int,
@khoiphuc_loiich_nhandan nvarchar(500),
@thuhoi_taisan nvarchar(500),
@ketthucgiaiquyet nvarchar(50),
@statuss nvarchar(50),
@forward nvarchar(50)
AS
update tb_giaiquyetkhieunai set id_thongtinkhieunai=@id_thongtinkhieunai,
solan_khieunai=@solan_khieunai,
hinhthuc_xuly=@hinhthuc_xuly,
donvinhan=@donvinhan,
ten_donvinhan=@ten_donvinhan,
ngaynhan=@ngaynhan,
capgiaiquyet=@capgiaiquyet,
noidungdonthu=@noidungdonthu,
dv_chiutrachnhiem_giaiquyet=@dv_chiutrachnhiem_giaiquyet,
so_congvan=@so_congvan,
ngaytao_congvan=@ngaytao_congvan,
songay_giaiquyet=@songay_giaiquyet,
ngaybatdau_giaiquyet=@ngaybatdau_giaiquyet,
ngayketthuc_giaiquyet=@ngayketthuc_giaiquyet,
hinhthuc_xacminh=@hinhthuc_xacminh,
so_kehoach_xacminh=@so_kehoach_xacminh,
ngaylap_kehoachxacminh=@ngaylap_kehoachxacminh,
so_quyetdinh_thanhlap=@so_quyetdinh_thanhlap,
ngaylap_quyetdinh_thanhlap=@ngaylap_quyetdinh_thanhlap,
so_ngayxacminh=@so_ngayxacminh,
ngay_batdauxacminh=@ngay_batdauxacminh,
ngay_ketthucxacminh=@ngay_ketthucxacminh,
totruong_xacminh=@totruong_xacminh,
capbac_totruong=@capbac_totruong,
chuvu_totruong=@chuvu_totruong,
thanhvien_trongdoan=@thanhvien_trongdoan,
cabo_thuly=@cabo_thuly,
lanhdao_phutrach=@lanhdao_phutrach,
ketqua_xacminh=@ketqua_xacminh,
ngayrut_khieunai=@ngayrut_khieunai,
tomtat_ketqua_giaiquyet=@tomtat_ketqua_giaiquyet,
date_ngayketthuc=@date_ngayketthuc,
danhgia_viec_giaiquyet=@danhgia_viec_giaiquyet,
bidon_co_dongy_ketqua=@bidon_co_dongy_ketqua,
so_cb_khongduoc_xetthidua=@so_cb_khongduoc_xetthidua,
so_cb_bikiemdiem=@so_cb_bikiemdiem,
so_cb_bikhientrach=@so_cb_bikhientrach,
so_cb_bicanhcao=@so_cb_bicanhcao,
so_cb_bigiangchuc=@so_cb_bigiangchuc,
so_cb_bigiangcap=@so_cb_bigiangcap,
so_cb_bituocdanhhieu=@so_cb_bituocdanhhieu,
so_cb_xuly_hinhsu=@so_cb_xuly_hinhsu,
so_tapthe_duocminhoan=@so_tapthe_duocminhoan,
so_canhan_duocminhoan=@so_canhan_duocminhoan,
khoiphuc_loiich_nhandan=@khoiphuc_loiich_nhandan,
thuhoi_taisan=@thuhoi_taisan,
ketthucgiaiquyet=@ketthucgiaiquyet,
statuss=@statuss,
forward=@forward
where id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyetkhieunai
GO
/****** Object:  StoredProcedure [dbo].[sua_quatrinhgiaiquyettocao_guiden_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sua_quatrinhgiaiquyettocao_guiden_linq] 
	-- Add the parameters for the stored procedure here
@id_quatrinhgiaiquyettocao int,
@sola_tocao nvarchar(50),
@capgiaiquyet nvarchar(50),
@noidungtocao nvarchar(max),
@dv_chiutrachnhiem_giaiquyet nvarchar(50),
@sothongbao_chonoigui nvarchar(50),
@ngaygui_thongbao date,
@songay_giaiquyet nvarchar(50),
@ngaybatdau_giaiquyet date,
@ngayketthuc_giaiquyet date,
@so_quyetdinh_thuly nchar(10),
@ngay_thuly date,
@hinhthuc_xacminh nvarchar(50),
@so_quyetdinh_thanhlap nvarchar(50),
@ngay_thanhlap_quyetdinh date,
@hoten_totruong nvarchar(50),
@capbac_totruong nvarchar(50),
@chuvu_totruong nvarchar(50),
@thanhvien_trongdoan nvarchar(max),
@so_kehoach_xacminh nvarchar(50),
@ngay_batdauxacminh date,
@ngay_ketthucxacminh date,
@ketqua_xacminh nvarchar(50),
@ngayrut_tocao date,
@lydorut_tocao nvarchar(max),
@so_baocao_ketqua_xacminh nchar(10),
@ngay_baocao_ketqua_xacminh date,
@tomtat_ketqua_xuly nvarchar(max),
@so_ketluan_noidung_tocao nchar(10),
@ngay_ketluan_noidung_tocao date,
@nguoiky_ketluan_noidung_tocao nvarchar(50),
@chucvu_nguoiky_ketluan_noidung_tocao nvarchar(150),
@ngay_congkhai_ketluan date,
@so_cb_khongduoc_xetthidua int,
@so_cb_bikiemdiem int,
@so_cb_bicanhcao int,
@so_cb_bikhientrach int,
@so_cb_bigiangchuc int,
@so_cb_bigiangcap int,
@so_cb_xuly_hinhsu int,
@so_cb_bituocdanhhieu int,
@so_tapthe_duocminhoan int,
@so_canhan_duocminhoan int,
@khoiphuc_loiich nvarchar(500),
@thuhoi_taisan nvarchar(500),
@ngaynop_luu_hoso date,
@cabo_thuly nvarchar(50),
@lanhdao_phutrach nvarchar(50),
@date_ngayketthuc date
AS
update tb_giaiquyettocao set 
sola_tocao=@sola_tocao,
capgiaiquyet=@capgiaiquyet,
noidungtocao=@noidungtocao,
dv_chiutrachnhiem_giaiquyet=@dv_chiutrachnhiem_giaiquyet,
sothongbao_chonoigui=@sothongbao_chonoigui,
ngaygui_thongbao=@ngaygui_thongbao,
songay_giaiquyet=@songay_giaiquyet,
ngaybatdau_giaiquyet=@ngaybatdau_giaiquyet,
ngayketthuc_giaiquyet=@ngayketthuc_giaiquyet,
so_quyetdinh_thuly=@so_quyetdinh_thuly,
ngay_thuly=@ngay_thuly,
hinhthuc_xacminh=@hinhthuc_xacminh,
so_quyetdinh_thanhlap=@so_quyetdinh_thanhlap,
ngay_thanhlap_quyetdinh=@ngay_thanhlap_quyetdinh,
hoten_totruong=@hoten_totruong,
capbac_totruong=@capbac_totruong,
chuvu_totruong=@chuvu_totruong,
thanhvien_trongdoan=@thanhvien_trongdoan,
so_kehoach_xacminh=@so_kehoach_xacminh,
ngay_batdauxacminh=@ngay_batdauxacminh,
ngay_ketthucxacminh=@ngay_ketthucxacminh,
ketqua_xacminh=@ketqua_xacminh,
ngayrut_tocao=@ngayrut_tocao,
lydorut_tocao=@lydorut_tocao,
so_baocao_ketqua_xacminh=@so_baocao_ketqua_xacminh,
ngay_baocao_ketqua_xacminh=@ngay_baocao_ketqua_xacminh,
tomtat_ketqua_xuly=@tomtat_ketqua_xuly,
so_ketluan_noidung_tocao=@so_ketluan_noidung_tocao,
ngay_ketluan_noidung_tocao=@ngay_ketluan_noidung_tocao,
nguoiky_ketluan_noidung_tocao=@nguoiky_ketluan_noidung_tocao,
chucvu_nguoiky_ketluan_noidung_tocao=@chucvu_nguoiky_ketluan_noidung_tocao,
ngay_congkhai_ketluan=@ngay_congkhai_ketluan,
so_cb_khongduoc_xetthidua=@so_cb_khongduoc_xetthidua,
so_cb_bikiemdiem=@so_cb_bikiemdiem,
so_cb_bicanhcao=@so_cb_bicanhcao,
so_cb_bikhientrach=@so_cb_bikhientrach,
so_cb_bigiangchuc=@so_cb_bigiangchuc,
so_cb_bigiangcap=@so_cb_bigiangcap,
so_cb_xuly_hinhsu=@so_cb_xuly_hinhsu,
so_cb_bituocdanhhieu=@so_cb_bituocdanhhieu,
so_tapthe_duocminhoan=@so_tapthe_duocminhoan,
so_canhan_duocminhoan=@so_canhan_duocminhoan,
khoiphuc_loiich=@khoiphuc_loiich,
thuhoi_taisan=@thuhoi_taisan,
ngaynop_luu_hoso=@ngaynop_luu_hoso,
cabo_thuly=@cabo_thuly,
lanhdao_phutrach=@lanhdao_phutrach,
date_ngayketthuc=@date_ngayketthuc
where id_quatrinhgiaiquyettocao=@id_quatrinhgiaiquyettocao
GO
/****** Object:  StoredProcedure [dbo].[sua_quatrinhgiaiquyettocao_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sua_quatrinhgiaiquyettocao_linq] 
	-- Add the parameters for the stored procedure here
@id_quatrinhgiaiquyettocao int,
@id_thongtintocao int,
@sola_tocao nvarchar(50),
@hinhthuc_xuly int,
@donvinhan int,
@ngaynhan date,
@capgiaiquyet nvarchar(50),
@noidungtocao nvarchar(max),
@dv_chiutrachnhiem_giaiquyet nvarchar(50),
@sothongbao_chonoigui nvarchar(50),
@ngaygui_thongbao date,
@songay_giaiquyet nvarchar(50),
@ngaybatdau_giaiquyet date,
@ngayketthuc_giaiquyet date,
@so_quyetdinh_thuly nchar(10),
@ngay_thuly date,
@hinhthuc_xacminh nvarchar(50),
@so_quyetdinh_thanhlap nvarchar(50),
@ngay_thanhlap_quyetdinh date,
@hoten_totruong nvarchar(50),
@capbac_totruong nvarchar(50),
@chuvu_totruong nvarchar(50),
@thanhvien_trongdoan nvarchar(max),
@so_kehoach_xacminh nvarchar(50),
@ngay_batdauxacminh date,
@ngay_ketthucxacminh date,
@ketqua_xacminh nvarchar(50),
@ngayrut_tocao date,
@lydorut_tocao nvarchar(max),
@so_baocao_ketqua_xacminh nchar(10),
@ngay_baocao_ketqua_xacminh date,
@tomtat_ketqua_xuly nvarchar(max),
@so_ketluan_noidung_tocao nchar(10),
@ngay_ketluan_noidung_tocao date,
@nguoiky_ketluan_noidung_tocao nvarchar(50),
@chucvu_nguoiky_ketluan_noidung_tocao nvarchar(150),
@ngay_congkhai_ketluan date,
@so_cb_khongduoc_xetthidua int,
@so_cb_bikiemdiem int,
@so_cb_bicanhcao int,
@so_cb_bikhientrach int,
@so_cb_bigiangchuc int,
@so_cb_bigiangcap int,
@so_cb_xuly_hinhsu int,
@so_cb_bituocdanhhieu int,
@so_tapthe_duocminhoan int,
@so_canhan_duocminhoan int,
@khoiphuc_loiich nvarchar(500),
@thuhoi_taisan nvarchar(500),
@ngaynop_luu_hoso date,
@cabo_thuly nvarchar(50),
@lanhdao_phutrach nvarchar(50),
@ketthucgiaiquyet nvarchar(50),
@statuss nvarchar(50),
@date_ngayketthuc date,
@forward nvarchar(50)
AS
update tb_giaiquyettocao set 
id_thongtintocao=@id_thongtintocao,
sola_tocao=@sola_tocao,
hinhthuc_xuly=@hinhthuc_xuly,
donvinhan=@donvinhan,
ngaynhan=@ngaynhan,
capgiaiquyet=@capgiaiquyet,
noidungtocao=@noidungtocao,
dv_chiutrachnhiem_giaiquyet=@dv_chiutrachnhiem_giaiquyet,
sothongbao_chonoigui=@sothongbao_chonoigui,
ngaygui_thongbao=@ngaygui_thongbao,
songay_giaiquyet=@songay_giaiquyet,
ngaybatdau_giaiquyet=@ngaybatdau_giaiquyet,
ngayketthuc_giaiquyet=@ngayketthuc_giaiquyet,
so_quyetdinh_thuly=@so_quyetdinh_thuly,
ngay_thuly=@ngay_thuly,
hinhthuc_xacminh=@hinhthuc_xacminh,
so_quyetdinh_thanhlap=@so_quyetdinh_thanhlap,
ngay_thanhlap_quyetdinh=@ngay_thanhlap_quyetdinh,
hoten_totruong=@hoten_totruong,
capbac_totruong=@capbac_totruong,
chuvu_totruong=@chuvu_totruong,
thanhvien_trongdoan=@thanhvien_trongdoan,
so_kehoach_xacminh=@so_kehoach_xacminh,
ngay_batdauxacminh=@ngay_batdauxacminh,
ngay_ketthucxacminh=@ngay_ketthucxacminh,
ketqua_xacminh=@ketqua_xacminh,
ngayrut_tocao=@ngayrut_tocao,
lydorut_tocao=@lydorut_tocao,
so_baocao_ketqua_xacminh=@so_baocao_ketqua_xacminh,
ngay_baocao_ketqua_xacminh=@ngay_baocao_ketqua_xacminh,
tomtat_ketqua_xuly=@tomtat_ketqua_xuly,
so_ketluan_noidung_tocao=@so_ketluan_noidung_tocao,
ngay_ketluan_noidung_tocao=@ngay_ketluan_noidung_tocao,
nguoiky_ketluan_noidung_tocao=@nguoiky_ketluan_noidung_tocao,
chucvu_nguoiky_ketluan_noidung_tocao=@chucvu_nguoiky_ketluan_noidung_tocao,
ngay_congkhai_ketluan=@ngay_congkhai_ketluan,
so_cb_khongduoc_xetthidua=@so_cb_khongduoc_xetthidua,
so_cb_bikiemdiem=@so_cb_bikiemdiem,
so_cb_bicanhcao=@so_cb_bicanhcao,
so_cb_bikhientrach=@so_cb_bikhientrach,
so_cb_bigiangchuc=@so_cb_bigiangchuc,
so_cb_bigiangcap=@so_cb_bigiangcap,
so_cb_xuly_hinhsu=@so_cb_xuly_hinhsu,
so_cb_bituocdanhhieu=@so_cb_bituocdanhhieu,
so_tapthe_duocminhoan=@so_tapthe_duocminhoan,
so_canhan_duocminhoan=@so_canhan_duocminhoan,
khoiphuc_loiich=@khoiphuc_loiich,
thuhoi_taisan=@thuhoi_taisan,
ngaynop_luu_hoso=@ngaynop_luu_hoso,
cabo_thuly=@cabo_thuly,
lanhdao_phutrach=@lanhdao_phutrach,
ketthucgiaiquyet=@ketthucgiaiquyet,
statuss=@statuss,
date_ngayketthuc=@date_ngayketthuc,
forward=@forward
where id_quatrinhgiaiquyettocao=@id_quatrinhgiaiquyettocao
GO
/****** Object:  StoredProcedure [dbo].[them_canbo]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[them_canbo] 
	-- Add the parameters for the stored procedure here
	@ma_donvi_tb_donvi int,
	@sohieu_cand int,
	@hoten_chiensy nvarchar(50),
	@ten_dangnhap varchar(50),
	@matkhau_dangnhap varchar(100),
	@capbac nvarchar(50),
	@chucvu nvarchar(50),
	@quyenhan int
AS
INSERT INTO tb_canbochiensy(ma_donvi_tb_donvi,sohieu_cand,hoten_chiensy,ten_dangnhap,matkhau_dangnhap,capbac,chucvu,quyenhan)
VALUES (@ma_donvi_tb_donvi,@sohieu_cand,@hoten_chiensy,@ten_dangnhap,@matkhau_dangnhap,@capbac,@chucvu,@quyenhan) 
GO
/****** Object:  StoredProcedure [dbo].[them_canhan_tochuc_khieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[them_canhan_tochuc_khieunai]
@ma_tb_donthu_khieunai nvarchar(50),
@tochuc_canhan int,
@ten_canhan_tochuc nvarchar(50),
@sdt nvarchar(15),
@email nvarchar(50),
@so_cmnd nvarchar(15),
@ngaycap_cmnd date,
@noicap_cmnd nvarchar(50),
@dia_chi nvarchar(50),
@ten_cqdv_canhan nvarchar(50),
@nguoi_ky_trong_don nvarchar(50)
as
insert into tb_canhan_tochuc_khieunai(ma_tb_donthu_khieunai,tochuc_canhan,ten_canhan_tochuc,sdt,email,so_cmnd,
ngaycap_cmnd,noicap_cmnd,dia_chi,ten_cqdv_canhan,nguoi_ky_trong_don)
values(@ma_tb_donthu_khieunai,@tochuc_canhan,@ten_canhan_tochuc,@sdt,@email,@so_cmnd,@ngaycap_cmnd,@noicap_cmnd,
@dia_chi,@ten_cqdv_canhan,@nguoi_ky_trong_don)
GO
/****** Object:  StoredProcedure [dbo].[them_donthukhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[them_donthukhieunai]
@ma_donthu_khieunai nvarchar(50),
@ma_canbo_nhaplieu int,
@ma_donvi int,
@tochuc_canhan int,
@nacdanh_codanh int,
@chuky_nhieunguoi_motnguoi int,
@loai_don nvarchar(50),
@tomtat_noidung nvarchar(500),
@dieukien_xuly_du_hoackhong int,
@giayto_tailieugoc_kemtheo int,
@tinhchat_vuviec_phuctap_dongian int,
@ma_khieunai nvarchar(5),
@khieunai_lienquanden_thamquyen_nhieucand_co_khong int,
@khieunai_conoidung_tocao int,
@lydo_khongdu_dieukien nvarchar(50),
@noigui nvarchar(50),
@tailieu_dinhkem nvarchar(50),
@ngaygio_nhap nvarchar(50),
@ngaygio_sua nvarchar(100)
as
insert into tb_thongtinkhieunai(ma_donthu_khieunai,ma_donvi,ma_canbo_nhapdulieu,tochuc_canhan,nacdanh_codanh,chuky_nhieunguoi_motnguoi,loai_don,tomtat_noidung,
dieukien_xuly_du_hoackhong,giayto_tailieugoc_kemtheo,tinhchat_vuviec_phuctap_dongian,ma_khieunai,khieunai_lienquanden_thamquyen_nhieucand_co_khong,
khieunai_conoidung_tocao,lydo_khongdu_dieukien,noigui,tailieu_dinhkem,ngaygio_nhap,ngaygio_sua)
values(@ma_donthu_khieunai,@ma_canbo_nhaplieu,@ma_donvi,@tochuc_canhan,@nacdanh_codanh,@chuky_nhieunguoi_motnguoi,@loai_don,@tomtat_noidung,
@dieukien_xuly_du_hoackhong,@giayto_tailieugoc_kemtheo,@tinhchat_vuviec_phuctap_dongian,@ma_khieunai,@khieunai_lienquanden_thamquyen_nhieucand_co_khong,
@khieunai_conoidung_tocao,@lydo_khongdu_dieukien,@noigui,@tailieu_dinhkem,@ngaygio_nhap,@ngaygio_sua)
GO
/****** Object:  StoredProcedure [dbo].[them_quatrinhgiaiquyetkhieunai_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[them_quatrinhgiaiquyetkhieunai_linq] 
	-- Add the parameters for the stored procedure here
@id_thongtinkhieunai int,
@solan_khieunai nvarchar(50),
@hinhthuc_xuly nvarchar(50),
@donvinhan int,
@ten_donvinhan nvarchar(150),
@ngaynhan date,
@capgiaiquyet nvarchar(50),
@noidungdonthu nvarchar(max),
@dv_chiutrachnhiem_giaiquyet nvarchar(50),
@so_congvan nvarchar(50),
@ngaytao_congvan date,
@songay_giaiquyet nvarchar(50),
@ngaybatdau_giaiquyet date,
@ngayketthuc_giaiquyet date,
@hinhthuc_xacminh bit,
@so_kehoach_xacminh nvarchar(50),
@ngaylap_kehoachxacminh date,
@so_quyetdinh_thanhlap nvarchar(50),
@ngaylap_quyetdinh_thanhlap date,
@so_ngayxacminh nvarchar(50),
@ngay_batdauxacminh date,
@ngay_ketthucxacminh date,
@totruong_xacminh nvarchar(50),
@capbac_totruong nvarchar(50),
@chuvu_totruong nvarchar(50),
@thanhvien_trongdoan nvarchar(max),
@cabo_thuly nvarchar(50),
@lanhdao_phutrach nvarchar(50),
@ketqua_xacminh nvarchar(50),
@ngayrut_khieunai date,
@tomtat_ketqua_giaiquyet nvarchar(max),
@date_ngayketthuc date,
@danhgia_viec_giaiquyet bit,
@bidon_co_dongy_ketqua bit,
@so_cb_khongduoc_xetthidua int,
@so_cb_bikiemdiem int,
@so_cb_bikhientrach int,
@so_cb_bicanhcao int,
@so_cb_bigiangchuc int,
@so_cb_bigiangcap int,
@so_cb_bituocdanhhieu int,
@so_cb_xuly_hinhsu int,
@so_tapthe_duocminhoan int,
@so_canhan_duocminhoan int,
@khoiphuc_loiich_nhandan nvarchar(500),
@thuhoi_taisan nvarchar(500),
@ketthucgiaiquyet nvarchar(50),
@statuss nvarchar(50),
@date_ngaykhoitao date,
@foward nvarchar(50)
AS
INSERT INTO tb_giaiquyetkhieunai(id_thongtinkhieunai,solan_khieunai,hinhthuc_xuly,donvinhan,ten_donvinhan,ngaynhan,capgiaiquyet,noidungdonthu,dv_chiutrachnhiem_giaiquyet,so_congvan,ngaytao_congvan,
songay_giaiquyet,ngaybatdau_giaiquyet,ngayketthuc_giaiquyet,hinhthuc_xacminh,so_kehoach_xacminh,ngaylap_kehoachxacminh,so_quyetdinh_thanhlap,ngaylap_quyetdinh_thanhlap,
so_ngayxacminh,ngay_batdauxacminh,ngay_ketthucxacminh,totruong_xacminh,capbac_totruong,chuvu_totruong,thanhvien_trongdoan,cabo_thuly,lanhdao_phutrach,
ketqua_xacminh,ngayrut_khieunai,tomtat_ketqua_giaiquyet,date_ngayketthuc,danhgia_viec_giaiquyet,bidon_co_dongy_ketqua,so_cb_khongduoc_xetthidua,so_cb_bikiemdiem,so_cb_bikhientrach,
so_cb_bicanhcao,so_cb_bigiangchuc,so_cb_bigiangcap,so_cb_bituocdanhhieu,so_cb_xuly_hinhsu,so_tapthe_duocminhoan,so_canhan_duocminhoan,khoiphuc_loiich_nhandan,thuhoi_taisan,ketthucgiaiquyet,statuss,ngay_khoitao,forward)
VALUES (@id_thongtinkhieunai,@solan_khieunai,@hinhthuc_xuly,@donvinhan,@ten_donvinhan,@ngaynhan,@capgiaiquyet,@noidungdonthu,@dv_chiutrachnhiem_giaiquyet,@so_congvan,@ngaytao_congvan,@songay_giaiquyet,@ngaybatdau_giaiquyet,@ngayketthuc_giaiquyet,
@hinhthuc_xacminh,@so_kehoach_xacminh,@ngaylap_kehoachxacminh,@so_quyetdinh_thanhlap,@ngaylap_quyetdinh_thanhlap,@so_ngayxacminh,@ngay_batdauxacminh,@ngay_ketthucxacminh,@totruong_xacminh,@capbac_totruong,@chuvu_totruong,@thanhvien_trongdoan,
@cabo_thuly,@lanhdao_phutrach,@ketqua_xacminh,@ngayrut_khieunai,@tomtat_ketqua_giaiquyet,@date_ngayketthuc,@danhgia_viec_giaiquyet,@bidon_co_dongy_ketqua,@so_cb_khongduoc_xetthidua,@so_cb_bikiemdiem,@so_cb_bikhientrach,@so_cb_bicanhcao,@so_cb_bigiangchuc,
@so_cb_bigiangcap,@so_cb_bituocdanhhieu,@so_cb_xuly_hinhsu,@so_tapthe_duocminhoan,@so_canhan_duocminhoan,@khoiphuc_loiich_nhandan,@thuhoi_taisan,@ketthucgiaiquyet,@statuss,@date_ngaykhoitao,@foward) 
GO
/****** Object:  StoredProcedure [dbo].[them_quatrinhgiaiquyettocao_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[them_quatrinhgiaiquyettocao_linq] 
	-- Add the parameters for the stored procedure here
@id_thongtintocao int,
@sola_tocao nvarchar(50),
@hinhthuc_xuly int,
@donvinhan int,
@ngaynhan date,
@capgiaiquyet nvarchar(50),
@noidungtocao nvarchar(max),
@dv_chiutrachnhiem_giaiquyet nvarchar(50),
@sothongbao_chonoigui nvarchar(50),
@ngaygui_thongbao date,
@songay_giaiquyet nvarchar(50),
@ngaybatdau_giaiquyet date,
@ngayketthuc_giaiquyet date,
@so_quyetdinh_thuly nvarchar(50),
@ngay_thuly date,
@hinhthuc_xacminh nvarchar(50),
@so_quyetdinh_thanhlap nvarchar(50),
@ngay_thanhlap_quyetdinh date,
@hoten_totruong nvarchar(50),
@capbac_totruong nvarchar(50),
@chuvu_totruong nvarchar(50),
@thanhvien_trongdoan nvarchar(max),
@so_kehoach_xacminh nvarchar(50),
@ngay_batdauxacminh date,
@ngay_ketthucxacminh date,
@ketqua_xacminh nvarchar(50),
@ngayrut_tocao date,
@lydorut_tocao nvarchar(max),
@so_baocao_ketqua_xacminh nvarchar(50),
@ngay_baocao_ketqua_xacminh date,
@tomtat_ketqua_xuly nvarchar(max),
@so_ketluan_noidung_tocao nvarchar(50),
@ngay_ketluan_noidung_tocao date,
@nguoiky_ketluan_noidung_tocao nvarchar(50),
@chucvu_nguoiky_ketluan_noidung_tocao nvarchar(150),
@ngay_congkhai_ketluan date,
@so_cb_khongduoc_xetthidua int,
@so_cb_bikiemdiem int,
@so_cb_bicanhcao int,
@so_cb_bikhientrach int,
@so_cb_bigiangchuc int,
@so_cb_bigiangcap int,
@so_cb_xuly_hinhsu int,
@so_cb_bituocdanhhieu int,
@so_tapthe_duocminhoan int,
@so_canhan_duocminhoan int,
@khoiphuc_loiich nvarchar(500),
@thuhoi_taisan nvarchar(500),
@ngaynop_luu_hoso date,
@cabo_thuly nvarchar(50),
@lanhdao_phutrach nvarchar(50),
@ketthucgiaiquyet nvarchar(50),
@statuss nvarchar(50),
@ngaykhoitao date,
@date_ngayketthuc date,
@forward nvarchar(50)
AS
INSERT INTO tb_giaiquyettocao(id_thongtintocao,sola_tocao,hinhthuc_xuly,donvinhan,ngaynhan,capgiaiquyet,noidungtocao,dv_chiutrachnhiem_giaiquyet,sothongbao_chonoigui,ngaygui_thongbao,songay_giaiquyet,ngaybatdau_giaiquyet,
ngayketthuc_giaiquyet,so_quyetdinh_thuly,ngay_thuly,hinhthuc_xacminh,so_quyetdinh_thanhlap,ngay_thanhlap_quyetdinh,hoten_totruong,capbac_totruong,chuvu_totruong,thanhvien_trongdoan,so_kehoach_xacminh,ngay_batdauxacminh,ngay_ketthucxacminh,
ketqua_xacminh,ngayrut_tocao,lydorut_tocao,so_baocao_ketqua_xacminh,ngay_baocao_ketqua_xacminh,tomtat_ketqua_xuly,so_ketluan_noidung_tocao,ngay_ketluan_noidung_tocao,nguoiky_ketluan_noidung_tocao,chucvu_nguoiky_ketluan_noidung_tocao,ngay_congkhai_ketluan,so_cb_khongduoc_xetthidua,so_cb_bikiemdiem,so_cb_bicanhcao,
so_cb_bikhientrach,so_cb_bigiangchuc,so_cb_bigiangcap,so_cb_xuly_hinhsu,so_cb_bituocdanhhieu,so_tapthe_duocminhoan,so_canhan_duocminhoan,khoiphuc_loiich,thuhoi_taisan,ngaynop_luu_hoso,cabo_thuly,lanhdao_phutrach,ketthucgiaiquyet,statuss,ngaykhoitao,date_ngayketthuc,forward)
VALUES (@id_thongtintocao,@sola_tocao,@hinhthuc_xuly,@donvinhan,@ngaynhan,
@capgiaiquyet,@noidungtocao,@dv_chiutrachnhiem_giaiquyet,@sothongbao_chonoigui,@ngaygui_thongbao,@songay_giaiquyet,@ngaybatdau_giaiquyet,@ngayketthuc_giaiquyet,@so_quyetdinh_thuly,@ngay_thuly,@hinhthuc_xacminh,@so_quyetdinh_thanhlap,
@ngay_thanhlap_quyetdinh,@hoten_totruong,@capbac_totruong,@chuvu_totruong,@thanhvien_trongdoan,@so_kehoach_xacminh,@ngay_batdauxacminh,@ngay_ketthucxacminh,@ketqua_xacminh,@ngayrut_tocao,@lydorut_tocao,@so_baocao_ketqua_xacminh,@ngay_baocao_ketqua_xacminh,@tomtat_ketqua_xuly,
@so_ketluan_noidung_tocao,@ngay_ketluan_noidung_tocao,@nguoiky_ketluan_noidung_tocao,@chucvu_nguoiky_ketluan_noidung_tocao,@ngay_congkhai_ketluan,@so_cb_khongduoc_xetthidua,@so_cb_bikiemdiem,@so_cb_bicanhcao,@so_cb_bikhientrach,@so_cb_bigiangchuc,@so_cb_bigiangcap,@so_cb_xuly_hinhsu,
@so_cb_bituocdanhhieu,@so_tapthe_duocminhoan,@so_canhan_duocminhoan,@khoiphuc_loiich,@thuhoi_taisan,@ngaynop_luu_hoso,@cabo_thuly,@lanhdao_phutrach,@ketthucgiaiquyet,@statuss,@ngaykhoitao,@date_ngayketthuc,@forward) 
GO
/****** Object:  StoredProcedure [dbo].[them_temple_bidon]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[them_temple_bidon]
@ma_donthu_khieunai nvarchar(50),
@bidon_tochuc_canhan nvarchar(50),
@hoten_canhan nvarchar(50),
@sohieu_cand nvarchar(15),
@nghe_nghiep nvarchar(50),
@capbac nvarchar(50),
@chucvu nvarchar(50),
@ten_coquandonvi nvarchar(150),
@diachi nvarchar(50),
@thuoc_lucluong nvarchar(50)
as

insert into tb_temple_bidon(ma_donthu_khieunai,bidon_tochuc_canhan,hoten_canhan,sohieu_cand,nghe_nghiep,capbac,chucvu,ten_coquandonvi,diachi,thuoc_lucluong)
values(@ma_donthu_khieunai,@bidon_tochuc_canhan,@hoten_canhan,@sohieu_cand,@nghe_nghiep,@capbac,@chucvu,@ten_coquandonvi,@diachi,@thuoc_lucluong) 
GO
/****** Object:  StoredProcedure [dbo].[thongke_giaiquyetkhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[thongke_giaiquyetkhieunai]
@date_tungay date,
@date_denngay date,
@madovi int
as
select statuss,soluong=Count(statuss) from tb_giaiquyetkhieunai T1 Inner join tb_thongtinkhieunai T2
on T2.id_thongtinhieunai =T1.id_thongtinkhieunai
where ma_donvi_nhapdulieu=@madovi and ngay_khoitao between @date_tungay and @date_denngay
group by statuss
GO
/****** Object:  StoredProcedure [dbo].[thongke_giaiquyettocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[thongke_giaiquyettocao]
@date_tungay date,
@date_denngay date,
@madovi int
as
select case
when statuss =0 then N'Kết thúc'
when statuss =1 then N'Đang xử lý'
when statuss =2 then N'Quá hạn'
when statuss =3 then N'Chưa xử lý'
end as statuss,soluong=Count(statuss) from tb_thongtintocao T1 inner join tb_giaiquyettocao T2
on T2.id_thongtintocao =T1.id_thongtintocao1
where ma_donvi=@madovi and ngaykhoitao between @date_tungay and @date_denngay
group by statuss
GO
/****** Object:  StoredProcedure [dbo].[thongketonghop_khieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[thongketonghop_khieunai]
@date_tungay date,
@date_denngay date,
@madonvi int
as
select * from thongtindonthu T1 
inner join tb_locquatrinhgiaiquyet T2 
on T1.id_thongtinhieunai=T2.id_thongtinkhieunai 
inner join bidon T3
on T1.id_thongtinhieunai=T3.id_thongtinkhieunai
Inner join nhatky_guidon T4
on T1.id_thongtinhieunai=T4.id_thongtinkhieunai
inner join bidon_thuoclucluong T5
on T1.id_thongtinhieunai=T5.id_thongtinkhieunai
where 
T1.ma_donvi_nhapdulieu=@madonvi  and 
ngay_khoitao between @date_tungay and @date_denngay
GO
/****** Object:  StoredProcedure [dbo].[thongketonghop_tocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[thongketonghop_tocao]
@date_tungay date,
@date_denngay date,
@madonvi int
as
select * from thongtintocao T1
inner join tb_locquatrinhgiaiquyet_tocao T2 
on T1.id_thongtintocao1=T2.id_thongtintocao
inner join bidon_tocao T3 
on T1.id_thongtintocao1=T3.id_thongtintocao
inner join nhatky_guidon_tocao T4 
on T1.id_thongtintocao1=T4.id_thongtintocao
inner join bidon_thuoclucluong_tocao T5
on T1.id_thongtintocao1=T5.id_thongtintocao
where T1.ma_donvi=@madonvi
 and ngaykhoitao between @date_tungay and @date_denngay
GO
/****** Object:  StoredProcedure [dbo].[tomtatnoidungdongthu]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tomtatnoidungdongthu]
@ma_donthu nvarchar(50),
@ma_donvi int
as
select tomtat_noidung from tb_thongtinkhieunai
where ma_donthu_khieunai=@ma_donthu and ma_donvi_nhapdulieu=@ma_donvi
GO
/****** Object:  StoredProcedure [dbo].[tomtatnoidungtocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tomtatnoidungtocao]
@ma_donthu nvarchar(50),
@madonvi int
as
select tomtat_noidung from tb_thongtintocao
where ma_donthu_tocao=@ma_donthu and ma_donvi=@madonvi
GO
/****** Object:  StoredProcedure [dbo].[update_trangthaichuyedonthu]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[update_trangthaichuyedonthu]
@maquatrinhgiaiquyet int,
@chuyendonthu nvarchar(50)
as
update tb_giaiquyetkhieunai
set forward=@chuyendonthu
where id_quatrinhgiaiquyetkhieunai=@maquatrinhgiaiquyet
GO
/****** Object:  StoredProcedure [dbo].[update_trangthaichuyentocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[update_trangthaichuyentocao]
@maquatrinhgiaiquyet int,
@chuyentocao nvarchar(50)
as
update tb_giaiquyettocao
set forward=@chuyentocao
where id_quatrinhgiaiquyettocao=@maquatrinhgiaiquyet
GO
/****** Object:  StoredProcedure [dbo].[xem_id_thongtinkhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[xem_id_thongtinkhieunai]
@ma_donthu nvarchar(50),
@ma_donvi_nhapdulieu int
as
select id_thongtinhieunai,ma_quatrinhgiaiquyet_donvichuyenden,donvichuyenden from tb_thongtinkhieunai
where ma_donthu_khieunai=@ma_donthu and ma_donvi_nhapdulieu=@ma_donvi_nhapdulieu
GO
/****** Object:  StoredProcedure [dbo].[xem_id_thongtintocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[xem_id_thongtintocao]
@ma_donthutocao nvarchar(50),
@madonvi int
as
select id_thongtintocao1,ma_quatrinhgiaiquyet_donvichuyenden,donvichuyenden from tb_thongtintocao
where ma_donthu_tocao=@ma_donthutocao and ma_donvi=@madonvi
GO
/****** Object:  StoredProcedure [dbo].[xem_madonvi]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[xem_madonvi]
@ma_donthu nvarchar(50),
@lan_giaiquyet nvarchar(50)
as
select donvinhan from tb_thongtinkhieunai,tb_giaiquyetkhieunai
where tb_thongtinkhieunai.id_thongtinhieunai=tb_giaiquyetkhieunai.id_thongtinkhieunai and ma_donthu_khieunai=@ma_donthu and solan_khieunai=@lan_giaiquyet
GO
/****** Object:  StoredProcedure [dbo].[xem_thongtin_quatrinhgiaiquyet_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[xem_thongtin_quatrinhgiaiquyet_linq]
@id_quatrinhgiaiquyetkhieunai int
as
select ma_donthu_khieunai,id_thongtinkhieunai,solan_khieunai,hinhthuc_xuly,donvinhan,ngaynhan,capgiaiquyet,noidungdonthu,dv_chiutrachnhiem_giaiquyet,so_congvan,ngaytao_congvan,
songay_giaiquyet,ngaybatdau_giaiquyet,ngayketthuc_giaiquyet,hinhthuc_xacminh,so_kehoach_xacminh,ngaylap_kehoachxacminh,so_quyetdinh_thanhlap,ngaylap_quyetdinh_thanhlap,
so_ngayxacminh,ngay_batdauxacminh,ngay_ketthucxacminh,totruong_xacminh,capbac_totruong,chuvu_totruong,thanhvien_trongdoan,cabo_thuly,lanhdao_phutrach,
ketqua_xacminh,ngayrut_khieunai,tomtat_ketqua_giaiquyet,danhgia_viec_giaiquyet,bidon_co_dongy_ketqua,so_cb_khongduoc_xetthidua,so_cb_bikiemdiem,so_cb_bikhientrach,
so_cb_bicanhcao,so_cb_bigiangchuc,so_cb_bigiangcap,so_cb_bituocdanhhieu,so_cb_xuly_hinhsu,so_tapthe_duocminhoan,so_canhan_duocminhoan,khoiphuc_loiich_nhandan,thuhoi_taisan,ketthucgiaiquyet 
from tb_thongtinkhieunai,tb_giaiquyetkhieunai 
where tb_thongtinkhieunai.id_thongtinhieunai=tb_giaiquyetkhieunai.id_thongtinkhieunai and id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyetkhieunai
GO
/****** Object:  StoredProcedure [dbo].[xem_thongtin_quatrinhgiaiquyettocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[xem_thongtin_quatrinhgiaiquyettocao]
@id_quatrinhgiaiquyettocao int
as
select ma_donthu_tocao,id_thongtintocao,sola_tocao,hinhthuc_xuly,donvinhan,ngaynhan,capgiaiquyet,noidungtocao,dv_chiutrachnhiem_giaiquyet,sothongbao_chonoigui,ngaygui_thongbao,songay_giaiquyet,ngaybatdau_giaiquyet,ngayketthuc_giaiquyet,
so_quyetdinh_thuly,ngay_thuly,hinhthuc_xacminh,so_quyetdinh_thanhlap,ngay_thanhlap_quyetdinh,hoten_totruong,capbac_totruong,chuvu_totruong,thanhvien_trongdoan,so_kehoach_xacminh,ngay_batdauxacminh,ngay_ketthucxacminh,ketqua_xacminh,ngayrut_tocao,
lydorut_tocao,so_baocao_ketqua_xacminh,ngay_baocao_ketqua_xacminh,tomtat_ketqua_xuly,so_ketluan_noidung_tocao,ngay_ketluan_noidung_tocao,nguoiky_ketluan_noidung_tocao,chucvu_nguoiky_ketluan_noidung_tocao,ngay_congkhai_ketluan,so_cb_khongduoc_xetthidua,so_cb_bikiemdiem,so_cb_bicanhcao,so_cb_bikhientrach,
so_cb_bigiangchuc,so_cb_bigiangcap,so_cb_xuly_hinhsu,so_cb_bituocdanhhieu,so_tapthe_duocminhoan,so_canhan_duocminhoan,khoiphuc_loiich,thuhoi_taisan,ngaynop_luu_hoso,cabo_thuly,lanhdao_phutrach,ketthucgiaiquyet 
from tb_thongtintocao,tb_giaiquyettocao 
where tb_thongtintocao.id_thongtintocao1=tb_giaiquyettocao.id_thongtintocao and id_quatrinhgiaiquyettocao=@id_quatrinhgiaiquyettocao
GO
/****** Object:  StoredProcedure [dbo].[xem_thongtindonthu_gopbang_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[xem_thongtindonthu_gopbang_linq]
@id_thongtinkhieunai int
as
select *
from tb_thongtinkhieunai
where id_thongtinhieunai=@id_thongtinkhieunai
GO
/****** Object:  StoredProcedure [dbo].[xem_thongtintocao_linq]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[xem_thongtintocao_linq]
@id_thongtintocao int
as
select *
from tb_thongtintocao
where id_thongtintocao1=@id_thongtintocao
GO
/****** Object:  StoredProcedure [dbo].[xemcanbo]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[xemcanbo]
as
select  case
when quyenhan =2 then N'Chỉ được xem' 
when quyenhan=1  then N'Thêm, sửa, Xóa, Xem'
when quyenhan=0 then N'Admin'
end as quyenhan,sohieu_cand,hoten_chiensy,ten_dangnhap,capbac,chucvu,ten_donvi,ma_canbo
from tb_canbochiensy join tb_donvi on tb_canbochiensy.ma_donvi_tb_donvi =tb_donvi.ma_donvi
where ma_donvi_tb_donvi=ma_donvi
GO
/****** Object:  StoredProcedure [dbo].[xoa_quatrinhgiaiquyet]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[xoa_quatrinhgiaiquyet]
@id_quatrinhgiaiquyet int
as
delete from tb_giaiquyetkhieunai
where id_quatrinhgiaiquyetkhieunai=@id_quatrinhgiaiquyet
GO
/****** Object:  StoredProcedure [dbo].[xoa_quatrinhgiaiquyettocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[xoa_quatrinhgiaiquyettocao]
@id_quatrinhgiaiquyettocao int
as
delete from tb_giaiquyettocao
where id_quatrinhgiaiquyettocao=@id_quatrinhgiaiquyettocao
GO
/****** Object:  StoredProcedure [dbo].[xoa_thongtinkhieunai]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[xoa_thongtinkhieunai]
@IdThongtindonthu int
as
delete from tb_thongtinkhieunai
where id_thongtinhieunai=@IdThongtindonthu
GO
/****** Object:  StoredProcedure [dbo].[xoa_thongtintocao]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[xoa_thongtintocao]
@IdThongtintocao int
as
delete from tb_thongtintocao
where id_thongtintocao1=@IdThongtintocao
GO
/****** Object:  StoredProcedure [dbo].[xoacanbo]    Script Date: 2/14/2020 7:09:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[xoacanbo]
@ma_canbo int
as delete from tb_canbochiensy where ma_canbo=@ma_canbo
GO
