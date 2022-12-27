USE [master]
GO
/****** Object:  Database [HTTT1]    Script Date: 11/11/2022 10:22:00 PM ******/
CREATE DATABASE [HTTT1]
GO
ALTER DATABASE [HTTT1] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HTTT1].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HTTT1] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HTTT1] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HTTT1] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HTTT1] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HTTT1] SET ARITHABORT OFF 
GO
ALTER DATABASE [HTTT1] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HTTT1] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HTTT1] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HTTT1] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HTTT1] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HTTT1] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HTTT1] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HTTT1] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HTTT1] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HTTT1] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HTTT1] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HTTT1] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HTTT1] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HTTT1] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HTTT1] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HTTT1] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HTTT1] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HTTT1] SET RECOVERY FULL 
GO
ALTER DATABASE [HTTT1] SET  MULTI_USER 
GO
ALTER DATABASE [HTTT1] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HTTT1] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HTTT1] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HTTT1] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HTTT1] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HTTT1] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HTTT1] SET QUERY_STORE = OFF
GO
USE [HTTT1]
GO
/****** Object:  Table [dbo].[CapDonVi]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CapDonVi](
	[MaCap] [nchar](10) NOT NULL,
	[TenCap] [nchar](10) NULL,
 CONSTRAINT [PK_CapDonVi] PRIMARY KEY CLUSTERED 
(
	[MaCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CongViecChiTiet]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CongViecChiTiet](
	[ThoiGian] [nchar](10) NOT NULL,
	[NDCongViec] [nchar](10) NULL,
	[KetQua] [nchar](10) NULL,
	[NguoiNghiemThu] [nchar](10) NULL,
	[DanhGia] [nchar](10) NULL,
	[PhienHieuDonVi] [nchar](10) NULL,
 CONSTRAINT [PK_CongViec] PRIMARY KEY CLUSTERED 
(
	[ThoiGian] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonVi]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonVi](
	[PhienHieuDonVi] [nchar](10) NOT NULL,
	[TenDonVi] [nchar](10) NULL,
	[MaCap] [nchar](10) NULL,
 CONSTRAINT [PK_DonVi] PRIMARY KEY CLUSTERED 
(
	[PhienHieuDonVi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HocVien]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HocVien](
	[MaHocVien] [nchar](10) NOT NULL,
	[TenHocVien] [nchar](10) NULL,
	[PhienHieuDonVi] [nchar](10) NULL,
 CONSTRAINT [PK_HocVien] PRIMARY KEY CLUSTERED 
(
	[MaHocVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KeHoachCongTac]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KeHoachCongTac](
	[ThoiGian] [nchar](10) NOT NULL,
	[NDThucHien] [nchar](10) NULL,
	[DiaDiem] [nchar](10) NULL,
	[MaTrucBan] [nchar](10) NULL,
	[TrucChiHuy] [nchar](10) NULL,
	[PhienHieuDonVi] [nchar](10) NULL,
	[TPThucHien] [nchar](10) NULL,
 CONSTRAINT [PK_KeHoachCongTac] PRIMARY KEY CLUSTERED 
(
	[ThoiGian] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NhatKy_CongViec]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhatKy_CongViec](
	[ThoiGian] [nchar](10) NOT NULL,
	[PhienHieuDonVi] [nchar](10) NOT NULL,
	[NDThucHien] [nchar](10) NULL,
	[KGThucHien] [nchar](10) NULL,
	[KLCuaCapTren] [nchar](10) NULL,
	[NguoiChuTri] [nchar](10) NULL,
 CONSTRAINT [PK_NhatKy_CongViec_1] PRIMARY KEY CLUSTERED 
(
	[ThoiGian] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong_CongViec]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong_CongViec](
	[ThoiGian] [nchar](10) NOT NULL,
	[MaHocVien] [nchar](10) NOT NULL,
	[NDCongViec] [nchar](10) NOT NULL,
 CONSTRAINT [PK_PhanCong_CongViec] PRIMARY KEY CLUSTERED 
(
	[ThoiGian] ASC,
	[MaHocVien] ASC,
	[NDCongViec] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThongTinDangNhap]    Script Date: 11/11/2022 10:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinDangNhap](
	[TK] [nchar](10) NOT NULL,
	[MK] [nchar](10) NOT NULL,
	[PhienHieuDV] [nchar](10) NULL,
 CONSTRAINT [PK_ThongTinDangNhap] PRIMARY KEY CLUSTERED 
(
	[TK] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CongViecChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_CongViecChiTiet_DonVi] FOREIGN KEY([PhienHieuDonVi])
REFERENCES [dbo].[DonVi] ([PhienHieuDonVi])
GO
ALTER TABLE [dbo].[CongViecChiTiet] CHECK CONSTRAINT [FK_CongViecChiTiet_DonVi]
GO
ALTER TABLE [dbo].[DonVi]  WITH CHECK ADD  CONSTRAINT [FK_DonVi_CapDonVi] FOREIGN KEY([MaCap])
REFERENCES [dbo].[CapDonVi] ([MaCap])
GO
ALTER TABLE [dbo].[DonVi] CHECK CONSTRAINT [FK_DonVi_CapDonVi]
GO
ALTER TABLE [dbo].[HocVien]  WITH CHECK ADD  CONSTRAINT [FK_HocVien_DonVi] FOREIGN KEY([PhienHieuDonVi])
REFERENCES [dbo].[DonVi] ([PhienHieuDonVi])
GO
ALTER TABLE [dbo].[HocVien] CHECK CONSTRAINT [FK_HocVien_DonVi]
GO
ALTER TABLE [dbo].[KeHoachCongTac]  WITH CHECK ADD  CONSTRAINT [FK_KeHoachCongTac_DonVi] FOREIGN KEY([PhienHieuDonVi])
REFERENCES [dbo].[DonVi] ([PhienHieuDonVi])
GO
ALTER TABLE [dbo].[KeHoachCongTac] CHECK CONSTRAINT [FK_KeHoachCongTac_DonVi]
GO
--ALTER TABLE [dbo].[Lop]  WITH CHECK ADD  CONSTRAINT [FK_Lop_DonVi] FOREIGN KEY([MaLopTruong])
--REFERENCES [dbo].[DonVi] ([PhienHieuDonVi])
--GO
--ALTER TABLE [dbo].[Lop] CHECK CONSTRAINT [FK_Lop_DonVi]
--GO
ALTER TABLE [dbo].[NhatKy_CongViec]  WITH CHECK ADD  CONSTRAINT [FK_NhatKy_CongViec_DonVi] FOREIGN KEY([PhienHieuDonVi])
REFERENCES [dbo].[DonVi] ([PhienHieuDonVi])
GO
ALTER TABLE [dbo].[NhatKy_CongViec] CHECK CONSTRAINT [FK_NhatKy_CongViec_DonVi]
GO
ALTER TABLE [dbo].[PhanCong_CongViec]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_CongViec_CongViecChiTiet] 
FOREIGN KEY([MaHocVien]) REFERENCES [dbo].[CongViecChiTiet] ([ThoiGian])
GO
ALTER TABLE [dbo].[PhanCong_CongViec] CHECK CONSTRAINT [FK_PhanCong_CongViec_CongViecChiTiet]
GO
ALTER TABLE [dbo].[PhanCong_CongViec]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_CongViec_HocVien] FOREIGN KEY([MaHocVien])
REFERENCES [dbo].[HocVien] ([MaHocVien])
GO
ALTER TABLE [dbo].[PhanCong_CongViec] CHECK CONSTRAINT [FK_PhanCong_CongViec_HocVien]
GO
ALTER TABLE [dbo].[ThongTinDangNhap]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinDangNhap_DonVi] FOREIGN KEY([PhienHieuDV])
REFERENCES [dbo].[DonVi] ([PhienHieuDonVi])
GO
ALTER TABLE [dbo].[ThongTinDangNhap] CHECK CONSTRAINT [FK_ThongTinDangNhap_DonVi]
GO
USE [master]
GO
ALTER DATABASE [HTTT1] SET  READ_WRITE 
GO