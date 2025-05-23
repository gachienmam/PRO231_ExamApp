USE [master]
GO
/****** Object:  Database [PolyTest_Database]    Script Date: 4/8/2025 2:45:43 AM ******/
CREATE DATABASE [PolyTest_Database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'PolyTest_Database', FILENAME = N'/var/opt/mssql/data/PolyTest_Database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'PolyTest_Database_log', FILENAME = N'/var/opt/mssql/data/PolyTest_Database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [PolyTest_Database] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [PolyTest_Database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [PolyTest_Database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [PolyTest_Database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [PolyTest_Database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [PolyTest_Database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [PolyTest_Database] SET ARITHABORT OFF 
GO
ALTER DATABASE [PolyTest_Database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [PolyTest_Database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [PolyTest_Database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [PolyTest_Database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [PolyTest_Database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [PolyTest_Database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [PolyTest_Database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [PolyTest_Database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [PolyTest_Database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [PolyTest_Database] SET  DISABLE_BROKER 
GO
ALTER DATABASE [PolyTest_Database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [PolyTest_Database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [PolyTest_Database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [PolyTest_Database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [PolyTest_Database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [PolyTest_Database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [PolyTest_Database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [PolyTest_Database] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [PolyTest_Database] SET  MULTI_USER 
GO
ALTER DATABASE [PolyTest_Database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [PolyTest_Database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [PolyTest_Database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [PolyTest_Database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [PolyTest_Database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [PolyTest_Database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'PolyTest_Database', N'ON'
GO
ALTER DATABASE [PolyTest_Database] SET QUERY_STORE = ON
GO
ALTER DATABASE [PolyTest_Database] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [PolyTest_Database]
GO
/****** Object:  Table [dbo].[DeThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeThi](
	[MaDe] [varchar](50) NOT NULL,
	[MaNguoiDung] [varchar](50) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NOT NULL,
	[TrangThai] [int] NOT NULL,
	[DanhSachThi] [nvarchar](max) NULL,
	[ViTriFileDe] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_DETHI] PRIMARY KEY CLUSTERED 
(
	[MaDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KetQuaThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KetQuaThi](
	[MaKetQua] [int] IDENTITY(1,1) NOT NULL,
	[MaThiSinh] [varchar](50) NOT NULL,
	[MaDe] [varchar](50) NOT NULL,
	[Diem] [float] NOT NULL,
	[ThoiGianBatDau] [datetime] NOT NULL,
	[ThoiGianKetThuc] [datetime] NOT NULL,
	[DaHoanThanh] [bit] NULL,
 CONSTRAINT [PK__KETQUA__603FFF99B6751D10] PRIMARY KEY CLUSTERED 
(
	[MaKetQua] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[MaNguoiDung] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[VaiTro] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK__NGUOIDUN__603F51067C977F8B] PRIMARY KEY CLUSTERED 
(
	[MaNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThiSinh]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThiSinh](
	[MaThiSinh] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[MatKhau] [varchar](255) NOT NULL,
	[NgaySinh] [date] NOT NULL,
	[SoDienThoai] [varchar](15) NOT NULL,
	[TrangThai] [int] NOT NULL,
 CONSTRAINT [PK__THISINH__6023720E6DB536DF] PRIMARY KEY CLUSTERED 
(
	[MaThiSinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[DeThi] ([MaDe], [MaNguoiDung], [MatKhau], [ThoiGianBatDau], [ThoiGianKetThuc], [TrangThai], [DanhSachThi], [ViTriFileDe]) VALUES (N'DT001', N'ND001', N'4321', CAST(N'2025-04-08T13:40:17.000' AS DateTime), CAST(N'2025-04-10T14:50:17.000' AS DateTime), 1, N'[{"MaThiSinh":"TS002"}]', N'ExamPapers/exam_DT002.xlsx')
GO
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [Email], [MatKhau], [VaiTro]) VALUES (N'ND001', N'Vu Van Thanh', N'vanthanh3045@gmail.com', N'$2a$11$CVMJTUUC3SGs1oUoHlhz3O8H8Db8MpZ3vngyc6I.s1Fbp766di.oO', N'Admin')
INSERT [dbo].[NguoiDung] ([MaNguoiDung], [HoTen], [Email], [MatKhau], [VaiTro]) VALUES (N'ND002', N'caodangthanhdat', N'thanhdatcaodang@gmail.com', N'$2a$11$IP72u3UUy9vLx7oouvaMZ.Iglm8dg9oC/Ki58VY6ABN1xUJEPs/LG', N'GiangVien')
GO
INSERT [dbo].[ThiSinh] ([MaThiSinh], [HoTen], [Email], [MatKhau], [NgaySinh], [SoDienThoai], [TrangThai]) VALUES (N'TS001', N'Vũ Văn Thành', N'vanthanh3045@gmail.com', N'$2a$11$2.7LJdD/z3oOMt/wgZtiEeV9d5igdEFBdJAeRNzJFiZAFgd2QJb8O', CAST(N'2007-04-08' AS Date), N'0938421721', 1)
INSERT [dbo].[ThiSinh] ([MaThiSinh], [HoTen], [Email], [MatKhau], [NgaySinh], [SoDienThoai], [TrangThai]) VALUES (N'TS002', N'Cao Dang Thanh Dat', N'thanhdatcaodang@gmail.com', N'$2a$11$2.7LJdD/z3oOMt/wgZtiEeV9d5igdEFBdJAeRNzJFiZAFgd2QJb8O', CAST(N'2025-04-08' AS Date), N'0123456789', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__THISINH__161CF724694400F8]    Script Date: 4/8/2025 2:45:44 AM ******/
ALTER TABLE [dbo].[ThiSinh] ADD  CONSTRAINT [UQ__THISINH__161CF724694400F8] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__THISINH__A7FD94DB4E6836E9]    Script Date: 4/8/2025 2:45:44 AM ******/
ALTER TABLE [dbo].[ThiSinh] ADD  CONSTRAINT [UQ__THISINH__A7FD94DB4E6836E9] UNIQUE NONCLUSTERED 
(
	[SoDienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KetQuaThi] ADD  CONSTRAINT [DF__KETQUA__NGAYTHI__403A8C7D]  DEFAULT (getdate()) FOR [ThoiGianBatDau]
GO
ALTER TABLE [dbo].[DeThi]  WITH CHECK ADD  CONSTRAINT [FK_DeThi_NguoiDung] FOREIGN KEY([MaNguoiDung])
REFERENCES [dbo].[NguoiDung] ([MaNguoiDung])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[DeThi] CHECK CONSTRAINT [FK_DeThi_NguoiDung]
GO
ALTER TABLE [dbo].[KetQuaThi]  WITH CHECK ADD  CONSTRAINT [FK__KETQUA__MATS__4222D4EF] FOREIGN KEY([MaThiSinh])
REFERENCES [dbo].[ThiSinh] ([MaThiSinh])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KetQuaThi] CHECK CONSTRAINT [FK__KETQUA__MATS__4222D4EF]
GO
ALTER TABLE [dbo].[KetQuaThi]  WITH CHECK ADD  CONSTRAINT [FK_KetQuaThi_DeThi] FOREIGN KEY([MaDe])
REFERENCES [dbo].[DeThi] ([MaDe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KetQuaThi] CHECK CONSTRAINT [FK_KetQuaThi_DeThi]
GO
ALTER TABLE [dbo].[KetQuaThi]  WITH CHECK ADD  CONSTRAINT [CK__KETQUA__DIEM__4316F928] CHECK  (([DIEM]>=(0) AND [DIEM]<=(10)))
GO
ALTER TABLE [dbo].[KetQuaThi] CHECK CONSTRAINT [CK__KETQUA__DIEM__4316F928]
GO
/****** Object:  StoredProcedure [dbo].[sp_BangDiem]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_BangDiem](@MaDe VARCHAR(50))  
AS BEGIN  
    SELECT MaKetQua, MaThiSinh, MaDe, Diem, ThoiGianBatDau, ThoiGianKetThuc
    FROM KetQuaThi  
    WHERE MaDe = @MaDe  
    ORDER BY Diem DESC  
END  
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachDeThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DanhSachDeThi](@MaNguoiDung VARCHAR(50))  
AS BEGIN  
    SELECT MaDe, MaNguoiDung, MatKhau, ThoiGianBatDau, ThoiGianKetThuc, TrangThai, DanhSachThi, ViTriFileDe
    FROM DeThi  
    WHERE MaNguoiDung = @MaNguoiDung  
    ORDER BY ThoiGianBatDau DESC  
END  
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachNguoiDung]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DanhSachNguoiDung](@VaiTro NVARCHAR(10))  
AS BEGIN  
    SELECT MaNguoiDung, HoTen, Email, MatKhau, VaiTro
    FROM NguoiDung  
    WHERE VaiTro = @VaiTro  
    ORDER BY HoTen  
END  
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachThiSinh]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_DanhSachThiSinh](@TrangThai INT)  
AS BEGIN  
    SELECT MaThiSinh, HoTen, Email, MatKhau, NgaySinh, SoDienThoai, TrangThai
    FROM ThiSinh  
    WHERE TrangThai = @TrangThai  
    ORDER BY HoTen  
END  
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteDeThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục xóa (DELETE) cho DeThi
CREATE PROCEDURE [dbo].[sp_DeleteDeThi]
    @MaDe VARCHAR(50)
AS
BEGIN
    DELETE FROM [dbo].[DeThi]
		WHERE MaDe = @MaDe;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteKetQuaThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục xóa (DELETE) cho KetQuaThi
CREATE PROCEDURE [dbo].[sp_DeleteKetQuaThi]
    @MaKetQua INT
AS
BEGIN
    DELETE FROM [dbo].[KetQuaThi]
    WHERE MaKetQua = @MaKetQua;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteNguoiDung]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục xóa (DELETE) cho NguoiDung
CREATE PROCEDURE [dbo].[sp_DeleteNguoiDung]
    @MaNguoiDung VARCHAR(50)
AS
BEGIN
DELETE FROM [dbo].[DeThi]
		WHERE MaNguoiDung = @MaNguoiDung;
    DELETE FROM [dbo].[NguoiDung]
		WHERE MaNguoiDung = @MaNguoiDung;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteThiSinh]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục xóa (DELETE) cho ThiSinh
CREATE PROCEDURE [dbo].[sp_DeleteThiSinh]
    @MaThiSinh VARCHAR(50)
AS
BEGIN
    DELETE FROM [dbo].[ThiSinh]
    WHERE MaThiSinh = @MaThiSinh;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertDeThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Thủ tục thêm (INSERT) cho DeThi
CREATE PROCEDURE [dbo].[sp_InsertDeThi]
    @MaDe VARCHAR(50),
    @MaNguoiDung VARCHAR(50),
    @MatKhau VARCHAR(255),
    @ThoiGianBatDau DATETIME,
    @ThoiGianKetThuc DATETIME,
    @TrangThai INT,
    @DanhSachThi NVARCHAR(MAX),
    @ViTriFileDe NVARCHAR(MAX)
AS
BEGIN
    INSERT INTO [dbo].[DeThi] (MaDe, MaNguoiDung, MatKhau, ThoiGianBatDau, ThoiGianKetThuc, TrangThai, DanhSachThi, ViTriFileDe)
    VALUES (@MaDe, @MaNguoiDung, @MatKhau, @ThoiGianBatDau, @ThoiGianKetThuc, @TrangThai, @DanhSachThi, @ViTriFileDe);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertKetQuaThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Thủ tục thêm (INSERT) cho DeThi
CREATE PROCEDURE [dbo].[sp_InsertKetQuaThi]
    @MaThiSinh VARCHAR(50),
	@MaDe VARCHAR(50),
    @Diem FLOAT,
    @ThoiGianBatDau DATETIME,
    @ThoiGianKetThuc DATETIME,
    @DaHoanThanh bit
AS
BEGIN
    INSERT INTO [dbo].KetQuaThi (MaThiSinh, MaDe, Diem, ThoiGianBatDau, ThoiGianKetThuc, DaHoanThanh)
    VALUES (@MaThiSinh, @MaDe, @Diem, @ThoiGianBatDau, @ThoiGianKetThuc, @DaHoanThanh);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertNguoiDung]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục thêm (INSERT) cho NguoiDung
CREATE PROCEDURE [dbo].[sp_InsertNguoiDung]
    @MaNguoiDung VARCHAR(50),
    @HoTen NVARCHAR(50),
    @Email VARCHAR(100),
    @MatKhau VARCHAR(255),
    @VaiTro NVARCHAR(10)
AS
BEGIN
    INSERT INTO [dbo].[NguoiDung] (MaNguoiDung, HoTen, Email, MatKhau, VaiTro)
    VALUES (@MaNguoiDung, @HoTen, @Email, @MatKhau, @VaiTro);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertThiSinh]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục thêm (INSERT) cho ThiSinh
CREATE PROCEDURE [dbo].[sp_InsertThiSinh]
    @MaThiSinh VARCHAR(50),
    @HoTen NVARCHAR(50),
    @Email VARCHAR(100),
    @MatKhau VARCHAR(255),
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @TrangThai INT
AS
BEGIN
    INSERT INTO [dbo].[ThiSinh] (MaThiSinh, HoTen, Email, MatKhau, NgaySinh, SoDienThoai, TrangThai)
    VALUES (@MaThiSinh, @HoTen, @Email, @MatKhau, @NgaySinh, @SoDienThoai, @TrangThai);
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateDeThi]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục cập nhật (UPDATE) cho DeThi
CREATE PROCEDURE [dbo].[sp_UpdateDeThi]
    @MaDe VARCHAR(50),
    @MaNguoiDung VARCHAR(50),
    @MatKhau VARCHAR(255),
    @ThoiGianBatDau DATETIME,
    @ThoiGianKetThuc DATETIME,
    @TrangThai INT,
    @DanhSachThi NVARCHAR(MAX),
    @ViTriFileDe NVARCHAR(MAX)
AS
BEGIN
    UPDATE [dbo].[DeThi]
    SET 
        MaNguoiDung = @MaNguoiDung,
        MatKhau = @MatKhau,
        ThoiGianBatDau = @ThoiGianBatDau,
        ThoiGianKetThuc = @ThoiGianKetThuc,
        TrangThai = @TrangThai,
        DanhSachThi = @DanhSachThi,
        ViTriFileDe = @ViTriFileDe
    WHERE MaDe = @MaDe;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateNguoiDung]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục cập nhật (UPDATE) cho NguoiDung
CREATE PROCEDURE [dbo].[sp_UpdateNguoiDung]
    @MaNguoiDung VARCHAR(50),
    @HoTen NVARCHAR(50),
    @Email VARCHAR(100),
    @MatKhau VARCHAR(255),
    @VaiTro NVARCHAR(10)
AS
BEGIN
    UPDATE [dbo].[NguoiDung]
    SET 
        HoTen = @HoTen,
        Email = @Email,
        MatKhau = @MatKhau,
        VaiTro = @VaiTro
    WHERE MaNguoiDung = @MaNguoiDung;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateThiSinh]    Script Date: 4/8/2025 2:45:44 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Thủ tục cập nhật (UPDATE) cho ThiSinh
CREATE PROCEDURE [dbo].[sp_UpdateThiSinh]
    @MaThiSinh VARCHAR(50),
    @HoTen NVARCHAR(50),
    @Email VARCHAR(100),
    @MatKhau VARCHAR(255),
    @NgaySinh DATE,
    @SoDienThoai VARCHAR(15),
    @TrangThai INT
AS
BEGIN
    UPDATE [dbo].[ThiSinh]
    SET 
        HoTen = @HoTen,
        Email = @Email,
        MatKhau = @MatKhau,
        NgaySinh = @NgaySinh,
        SoDienThoai = @SoDienThoai,
        TrangThai = @TrangThai
    WHERE MaThiSinh = @MaThiSinh;
END
GO
USE [master]
GO
ALTER DATABASE [PolyTest_Database] SET  READ_WRITE 
GO
