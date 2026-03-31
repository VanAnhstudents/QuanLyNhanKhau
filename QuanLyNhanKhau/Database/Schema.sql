-- ============================================================
-- SCHEMA.SQL
-- Cơ sở dữ liệu: Quản lý Nhân Khẩu Quận
-- Hệ quản trị: SQL Server
-- ============================================================

CREATE DATABASE QuanLyNhanKhau;
GO
USE QuanLyNhanKhau;
GO

-- ============================================================
-- BẢNG 1: tblPhuong
-- Lưu thông tin các phường trong quận
-- ============================================================
CREATE TABLE tblPhuong (
    MaPhuong    INT             PRIMARY KEY IDENTITY(1,1),
    TenPhuong   NVARCHAR(100)   NOT NULL,
    DienThoai   NVARCHAR(15),
    TruSo       NVARCHAR(255)
);
GO

-- ============================================================
-- BẢNG 2: tblTodanpho
-- Lưu thông tin tổ dân phố, CSKV, tổ trưởng
-- ============================================================
CREATE TABLE tblTodanpho (
    MaTDP               INT             PRIMARY KEY IDENTITY(1,1),
    TenTDP              NVARCHAR(100)   NOT NULL,
    MaPhuong            INT             NOT NULL,
    HoTenCSKV          NVARCHAR(100),
    DienThoaiCSKV      NVARCHAR(15),
    HoTenToTruong      NVARCHAR(100),
    DienThoaiToTruong  NVARCHAR(15),
    CONSTRAINT FK_TDP_Phuong FOREIGN KEY (MaPhuong)
        REFERENCES tblPhuong(MaPhuong)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

-- ============================================================
-- BẢNG 3: tblNhankhau
-- Lưu thông tin chủ hộ (người đứng tên hộ khẩu)
-- ============================================================
CREATE TABLE tblNhankhau (
    MaNK        INT             PRIMARY KEY IDENTITY(1,1),
    HoTen       NVARCHAR(100)   NOT NULL,
    NgaySinh    DATE            NOT NULL,
    GioiTinh    BIT             NOT NULL,   -- 1: Nam | 0: Nữ
    NgheNghiep  NVARCHAR(100),
    NoiLamViec  NVARCHAR(200),
    DiaChi      NVARCHAR(200)   NOT NULL,
    DienThoai   NVARCHAR(15),
    MaTDP       INT             NOT NULL,
    TrangThai   NVARCHAR(50)    NOT NULL
                DEFAULT N'Đang cư trú',     -- Đang cư trú | Đã chuyển đi | Đã báo tử | Đã nhập hộ
    NgayDangKy  DATE            NOT NULL
                DEFAULT GETDATE(),
    CONSTRAINT FK_NK_TDP FOREIGN KEY (MaTDP)
        REFERENCES tblTodanpho(MaTDP)
        ON UPDATE CASCADE
        ON DELETE NO ACTION
);
GO

-- ============================================================
-- BẢNG 4: tblNguoi_phu_thuoc
-- Lưu thông tin thành viên phụ thuộc của chủ hộ
-- ============================================================
CREATE TABLE tblNguoi_phu_thuoc (
    MaNPT       INT             PRIMARY KEY IDENTITY(1,1),
    MaNK        INT             NOT NULL,
    HoTen       NVARCHAR(100)   NOT NULL,
    NgaySinh    DATE,
    GioiTinh    BIT,                        -- 1: Nam | 0: Nữ
    NgheNghiep  NVARCHAR(100),
    QuanHe      NVARCHAR(50)    NOT NULL,   -- Vợ | Chồng | Con | Cha | Mẹ | Anh | Chị | Em
    TrangThai   NVARCHAR(50)    NOT NULL
                DEFAULT N'Đang cư trú',     -- Đang cư trú | Đã chuyển đi | Đã báo tử
    CONSTRAINT FK_NPT_NK FOREIGN KEY (MaNK)
        REFERENCES tblNhankhau(MaNK)
        ON UPDATE CASCADE
        ON DELETE CASCADE
);
GO

-- ============================================================
-- BẢNG 5: tblBienDong
-- Lưu lịch sử biến động nhân khẩu (phục vụ báo cáo)
-- ============================================================
CREATE TABLE tblBienDong (
    MaBD            INT             PRIMARY KEY IDENTITY(1,1),
    MaNK            INT,
    MaNPT           INT,
    LoaiBienDong    NVARCHAR(100)   NOT NULL,
    -- Khai sinh | Báo tử | Chuyển đến | Chuyển đi | Tách hộ | Nhập hộ | Đăng ký mới
    NgayBienDong    DATE            NOT NULL DEFAULT GETDATE(),
    NguoiThucHien   NVARCHAR(100),
    GhiChu          NVARCHAR(500),
    CONSTRAINT FK_BD_NK FOREIGN KEY (MaNK)
        REFERENCES tblNhankhau(MaNK)
        ON UPDATE CASCADE
        ON DELETE SET NULL
);
GO

-- ============================================================
-- STORED PROCEDURES — PHƯỜNG
-- ============================================================
CREATE OR ALTER PROCEDURE sp_ThemPhuong
    @TenPhuong  NVARCHAR(100),
    @DienThoai  NVARCHAR(15),
    @TruSo     NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblPhuong (TenPhuong, DienThoai, TruSo)
    VALUES (@TenPhuong, @DienThoai, @TruSo);
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_SuaPhuong
    @MaPhuong   INT,
    @TenPhuong  NVARCHAR(100),
    @DienThoai  NVARCHAR(15),
    @TruSo     NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblPhuong
    SET TenPhuong = @TenPhuong,
        DienThoai = @DienThoai,
        TruSo     = @TruSo
    WHERE MaPhuong = @MaPhuong;
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_XoaPhuong
    @MaPhuong INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM tblPhuong WHERE MaPhuong = @MaPhuong;
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_GetAllPhuong
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        MaPhuong,
        TenPhuong,
        DienThoai,
        TruSo
    FROM tblPhuong
    ORDER BY MaPhuong ASC;
END
GO

-- ============================================================
-- STORED PROCEDURES — TỔ DÂN PHỐ
-- ============================================================
CREATE OR ALTER PROCEDURE sp_ThemTDP
    @TenTDP            NVARCHAR(100),
    @MaPhuong          INT,
    @HoTenCSKV         NVARCHAR(100),
    @DienThoaiCSKV     NVARCHAR(15),
    @HoTenToTruong     NVARCHAR(100),
    @DienThoaiToTruong VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblTodanpho
        (TenTDP, MaPhuong, HoTenCSKV, DienThoaiCSKV, HoTenToTruong, DienThoaiToTruong)
    VALUES
        (@TenTDP, @MaPhuong, @HoTenCSKV, @DienThoaiCSKV, @HoTenToTruong, @DienThoaiToTruong);
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_SuaTDP
    @MaTDP             INT,
    @TenTDP            NVARCHAR(100),
    @MaPhuong          INT,
    @HoTenCSKV         NVARCHAR(100),
    @DienThoaiCSKV     VARCHAR(15),
    @HoTenToTruong     NVARCHAR(100),
    @DienThoaiToTruong VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblTodanpho
    SET TenTDP             = @TenTDP,
        MaPhuong           = @MaPhuong,
        HoTenCSKV          = @HoTenCSKV,
        DienThoaiCSKV      = @DienThoaiCSKV,
        HoTenToTruong      = @HoTenToTruong,
        DienThoaiToTruong  = @DienThoaiToTruong
    WHERE MaTDP = @MaTDP;
END
GO

CREATE OR ALTER PROCEDURE sp_XoaTDP
    @MaTDP INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM tblTodanpho WHERE MaTDP = @MaTDP;
END
GO

-- ============================================================
-- STORED PROCEDURES — NHÂN KHẨU (CHỦ HỘ)
-- ============================================================
CREATE OR ALTER PROCEDURE sp_ThemNhanKhau
    @HoTen      NVARCHAR(100),
    @NgaySinh   DATE,
    @GioiTinh   BIT,
    @NgheNghiep NVARCHAR(100),
    @NoiLamViec NVARCHAR(200),
    @DiaChi     NVARCHAR(200),
    @DienThoai  VARCHAR(15),
    @MaTDP      INT
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblNhankhau
        (HoTen, NgaySinh, GioiTinh, NgheNghiep, NoiLamViec, DiaChi, DienThoai, MaTDP)
    VALUES
        (@HoTen, @NgaySinh, @GioiTinh, @NgheNghiep, @NoiLamViec, @DiaChi, @DienThoai, @MaTDP);
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_SuaNhanKhau
    @MaNK       INT,
    @HoTen      NVARCHAR(100),
    @NgaySinh   DATE,
    @GioiTinh   BIT,
    @NgheNghiep NVARCHAR(100),
    @NoiLamViec NVARCHAR(200),
    @DiaChi     NVARCHAR(200),
    @DienThoai  VARCHAR(15),
    @MaTDP      INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblNhankhau
    SET HoTen       = @HoTen,
        NgaySinh    = @NgaySinh,
        GioiTinh    = @GioiTinh,
        NgheNghiep  = @NgheNghiep,
        NoiLamViec  = @NoiLamViec,
        DiaChi      = @DiaChi,
        DienThoai   = @DienThoai,
        MaTDP       = @MaTDP
    WHERE MaNK = @MaNK;
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_XoaNhanKhau
    @MaNK INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM tblNhankhau WHERE MaNK = @MaNK;
END
GO

-- ============================================================
-- STORED PROCEDURES — NGƯỜI PHỤ THUỘC
-- ============================================================
CREATE OR ALTER PROCEDURE sp_ThemNguoiPhuThuoc
    @MaNK       INT,
    @HoTen      NVARCHAR(100),
    @NgaySinh   DATE,
    @GioiTinh   BIT,
    @NgheNghiep NVARCHAR(100),
    @QuanHe     NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblNguoi_phu_thuoc
        (MaNK, HoTen, NgaySinh, GioiTinh, NgheNghiep, QuanHe)
    VALUES
        (@MaNK, @HoTen, @NgaySinh, @GioiTinh, @NgheNghiep, @QuanHe);
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_SuaNguoiPhuThuoc
    @MaNPT      INT,
    @HoTen      NVARCHAR(100),
    @NgaySinh   DATE,
    @GioiTinh   BIT,
    @NgheNghiep NVARCHAR(100),
    @QuanHe     NVARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE tblNguoi_phu_thuoc
    SET HoTen       = @HoTen,
        NgaySinh    = @NgaySinh,
        GioiTinh    = @GioiTinh,
        NgheNghiep  = @NgheNghiep,
        QuanHe      = @QuanHe
    WHERE MaNPT = @MaNPT;
END
GO

-- ============================================================
CREATE OR ALTER PROCEDURE sp_XoaNguoiPhuThuoc
    @MaNPT INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM tblNguoi_phu_thuoc WHERE MaNPT = @MaNPT;
END
GO

-- ============================================================
-- STORED PROCEDURES — NGHIỆP VỤ HỘ KHẨU
-- ============================================================
-- Q05: Khai sinh
CREATE OR ALTER PROCEDURE sp_KhaiSinh
    @MaNK           INT,
    @HoTen          NVARCHAR(100),
    @NgaySinh       DATE,
    @GioiTinh       BIT,
    @NguoiThucHien  NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        INSERT INTO tblNguoi_phu_thuoc (MaNK, HoTen, NgaySinh, GioiTinh, NgheNghiep, QuanHe)
        VALUES (@MaNK, @HoTen, @NgaySinh, @GioiTinh, N'Chưa đi làm', N'Con');

        INSERT INTO tblBienDong (MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
        VALUES (@MaNK, N'Khai sinh', GETDATE(), @NguoiThucHien,
                N'Khai sinh cho: ' + @HoTen);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Q06: Báo tử
CREATE OR ALTER PROCEDURE sp_BaoTu
    @MaNK           INT,
    @MaNPT          INT = NULL,     -- NULL nếu người qua đời là chủ hộ
    @NguoiThucHien  NVARCHAR(100),
    @GhiChu         NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        IF @MaNPT IS NOT NULL
        BEGIN
            UPDATE tblNguoi_phu_thuoc
            SET TrangThai = N'Đã báo tử'
            WHERE MaNPT = @MaNPT;

            INSERT INTO tblBienDong (MaNK, MaNPT, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
            VALUES (@MaNK, @MaNPT, N'Báo tử', GETDATE(), @NguoiThucHien, @GhiChu);
        END
        ELSE
        BEGIN
            UPDATE tblNhankhau
            SET TrangThai = N'Đã báo tử'
            WHERE MaNK = @MaNK;

            INSERT INTO tblBienDong (MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
            VALUES (@MaNK, N'Báo tử', GETDATE(), @NguoiThucHien, @GhiChu);
        END
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Q07: Chuyển đi
CREATE OR ALTER PROCEDURE sp_ChuyenDi
    @MaNK           INT,
    @NguoiThucHien  NVARCHAR(100),
    @GhiChu         NVARCHAR(500)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        UPDATE tblNhankhau
        SET TrangThai = N'Đã chuyển đi'
        WHERE MaNK = @MaNK;

        UPDATE tblNguoi_phu_thuoc
        SET TrangThai = N'Đã chuyển đi'
        WHERE MaNK = @MaNK;

        INSERT INTO tblBienDong (MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
        VALUES (@MaNK, N'Chuyển đi', GETDATE(), @NguoiThucHien, @GhiChu);

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Q09: Tách hộ
CREATE OR ALTER PROCEDURE sp_TachHo
    @MaNK_Cu            INT,
    @HoTen_Moi          NVARCHAR(100),
    @NgaySinh_Moi       DATE,
    @GioiTinh_Moi       BIT,
    @NgheNghiep_Moi     NVARCHAR(100),
    @DiaChi_Moi         NVARCHAR(200),
    @DienThoai_Moi      VARCHAR(15),
    @MaTDP              INT,
    @NguoiThucHien      NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Tạo hộ mới với chủ hộ mới
        INSERT INTO tblNhankhau
            (HoTen, NgaySinh, GioiTinh, NgheNghiep, DiaChi, DienThoai, MaTDP)
        VALUES
            (@HoTen_Moi, @NgaySinh_Moi, @GioiTinh_Moi, @NgheNghiep_Moi,
             @DiaChi_Moi, @DienThoai_Moi, @MaTDP);

        DECLARE @MaNK_Moi INT = SCOPE_IDENTITY();

        -- Ghi biến động cho hộ cũ
        INSERT INTO tblBienDong (MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
        VALUES (@MaNK_Cu, N'Tách hộ', GETDATE(), @NguoiThucHien,
                N'Tách ra hộ mới, MaNK mới = ' + CAST(@MaNK_Moi AS NVARCHAR));

        -- Ghi biến động cho hộ mới
        INSERT INTO tblBienDong (MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
        VALUES (@MaNK_Moi, N'Tách hộ', GETDATE(), @NguoiThucHien,
                N'Tách từ hộ MaNK = ' + CAST(@MaNK_Cu AS NVARCHAR));

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- Q10: Nhập hộ
CREATE OR ALTER PROCEDURE sp_NhapHo
    @MaNK_Chinh         INT,
    @MaNK_GiaiThe       INT,
    @NguoiThucHien      NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Chuyển người phụ thuộc của hộ bị giải thể sang hộ chính
        UPDATE tblNguoi_phu_thuoc
        SET MaNK = @MaNK_Chinh
        WHERE MaNK = @MaNK_GiaiThe;

        -- Đánh dấu hộ bị giải thể
        UPDATE tblNhankhau
        SET TrangThai = N'Đã nhập hộ'
        WHERE MaNK = @MaNK_GiaiThe;

        -- Ghi biến động
        INSERT INTO tblBienDong (MaNK, LoaiBienDong, NgayBienDong, NguoiThucHien, GhiChu)
        VALUES (@MaNK_Chinh, N'Nhập hộ', GETDATE(), @NguoiThucHien,
                N'Nhập hộ MaNK = ' + CAST(@MaNK_GiaiThe AS NVARCHAR) + N' vào hộ này');

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO