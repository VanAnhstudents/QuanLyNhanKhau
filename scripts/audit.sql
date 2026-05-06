-- ============================================================
-- AUDIT.SQL
-- Script nâng cấp: Thêm cơ chế Audit/Log cho SQL Server
-- CSDL: QuanLyNhanKhau
-- Tương thích: SQL Server 2016 trở lên (cần hỗ trợ FOR JSON PATH
--              và SESSION_CONTEXT)
--
-- HƯỚNG DẪN CHẠY:
--   Mở SSMS, kết nối vào SQL Server, mở file này và chạy toàn bộ.
--   Script đã viết idempotent (IF NOT EXISTS / CREATE OR ALTER),
--   có thể chạy lại nhiều lần mà không bị lỗi.
--
-- NỘI DUNG:
--   PHẦN 0  — Bảng dbo.AuditLog dùng chung cho cả 2 cách
--   PHẦN A  — Cách A: App-driven  (metadata columns + hướng dẫn app)
--   PHẦN B  — Cách B: Trigger-driven (SESSION_CONTEXT + triggers)
-- ============================================================

USE QuanLyNhanKhau;
GO

-- ============================================================
-- PHẦN 0: BẢNG dbo.AuditLog (dùng chung cho cả Cách A và Cách B)
-- ============================================================
IF NOT EXISTS (
    SELECT 1 FROM sys.tables
    WHERE object_id = OBJECT_ID(N'dbo.AuditLog')
)
BEGIN
    CREATE TABLE dbo.AuditLog (
        AuditLogId          BIGINT          NOT NULL IDENTITY(1,1),
        At                  DATETIME2       NOT NULL DEFAULT SYSUTCDATETIME(),
        ActorTenDangNhap    NVARCHAR(50)    NULL,       -- FK logic tới tblTaiKhoan.TenDangNhap
        Action              NVARCHAR(10)    NOT NULL,   -- 'INSERT' | 'UPDATE' | 'DELETE'
        TableName           SYSNAME         NOT NULL,
        PrimaryKeyJson      NVARCHAR(MAX)   NOT NULL,   -- JSON: {"MaPhuong":1}
        OldDataJson         NVARCHAR(MAX)   NULL,       -- NULL khi INSERT
        NewDataJson         NVARCHAR(MAX)   NULL,       -- NULL khi DELETE
        AppName             NVARCHAR(128)   NULL DEFAULT APP_NAME(),
        HostName            NVARCHAR(128)   NULL DEFAULT HOST_NAME(),
        CONSTRAINT PK_AuditLog PRIMARY KEY CLUSTERED (AuditLogId)
    );
    PRINT N'[OK] Tạo bảng dbo.AuditLog thành công.';
END
ELSE
BEGIN
    PRINT N'[SKIP] Bảng dbo.AuditLog đã tồn tại.';
END
GO

-- ============================================================
-- PHẦN A: CÁCH A — APP-DRIVEN
-- Thêm cột metadata vào từng bảng nghiệp vụ.
-- Ứng dụng tự ghi các cột này và tự INSERT vào dbo.AuditLog
-- trong cùng một transaction khi thực hiện INSERT/UPDATE/DELETE.
--
-- Các cột được thêm (bỏ qua nếu đã tồn tại):
--   CreatedByTenDangNhap  NVARCHAR(50) NULL  — FK logic tới tblTaiKhoan
--   UpdatedByTenDangNhap  NVARCHAR(50) NULL  — FK logic tới tblTaiKhoan
--   CreatedAt             DATETIME2    NULL
--   UpdatedAt             DATETIME2    NULL
--
-- Lưu ý: dùng FK logic (không tạo CONSTRAINT FK thực) để tránh
-- xung đột khi xóa tài khoản.  Nếu cần ràng buộc chặt, bỏ comment
-- phần CONSTRAINT bên dưới.
-- ============================================================

-- ---- tblPhuong ----
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.tblPhuong')
                 AND name = N'CreatedByTenDangNhap')
BEGIN
    ALTER TABLE dbo.tblPhuong
        ADD CreatedByTenDangNhap    NVARCHAR(50)    NULL,
            UpdatedByTenDangNhap    NVARCHAR(50)    NULL,
            CreatedAt               DATETIME2       NULL DEFAULT SYSUTCDATETIME(),
            UpdatedAt               DATETIME2       NULL;
    -- FK tuỳ chọn (bỏ comment để bật):
    -- ALTER TABLE dbo.tblPhuong
    --     ADD CONSTRAINT FK_Phuong_CreatedBy FOREIGN KEY (CreatedByTenDangNhap)
    --         REFERENCES dbo.tblTaiKhoan(TenDangNhap);
    -- ALTER TABLE dbo.tblPhuong
    --     ADD CONSTRAINT FK_Phuong_UpdatedBy FOREIGN KEY (UpdatedByTenDangNhap)
    --         REFERENCES dbo.tblTaiKhoan(TenDangNhap);
    PRINT N'[OK] Thêm metadata columns vào tblPhuong.';
END
ELSE
    PRINT N'[SKIP] tblPhuong đã có metadata columns.';
GO

-- ---- tblTodanpho ----
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.tblTodanpho')
                 AND name = N'CreatedByTenDangNhap')
BEGIN
    ALTER TABLE dbo.tblTodanpho
        ADD CreatedByTenDangNhap    NVARCHAR(50)    NULL,
            UpdatedByTenDangNhap    NVARCHAR(50)    NULL,
            CreatedAt               DATETIME2       NULL DEFAULT SYSUTCDATETIME(),
            UpdatedAt               DATETIME2       NULL;
    PRINT N'[OK] Thêm metadata columns vào tblTodanpho.';
END
ELSE
    PRINT N'[SKIP] tblTodanpho đã có metadata columns.';
GO

-- ---- tblNhankhau ----
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.tblNhankhau')
                 AND name = N'CreatedByTenDangNhap')
BEGIN
    ALTER TABLE dbo.tblNhankhau
        ADD CreatedByTenDangNhap    NVARCHAR(50)    NULL,
            UpdatedByTenDangNhap    NVARCHAR(50)    NULL,
            CreatedAt               DATETIME2       NULL DEFAULT SYSUTCDATETIME(),
            UpdatedAt               DATETIME2       NULL;
    PRINT N'[OK] Thêm metadata columns vào tblNhankhau.';
END
ELSE
    PRINT N'[SKIP] tblNhankhau đã có metadata columns.';
GO

-- ---- tblNguoi_phu_thuoc ----
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.tblNguoi_phu_thuoc')
                 AND name = N'CreatedByTenDangNhap')
BEGIN
    ALTER TABLE dbo.tblNguoi_phu_thuoc
        ADD CreatedByTenDangNhap    NVARCHAR(50)    NULL,
            UpdatedByTenDangNhap    NVARCHAR(50)    NULL,
            CreatedAt               DATETIME2       NULL DEFAULT SYSUTCDATETIME(),
            UpdatedAt               DATETIME2       NULL;
    PRINT N'[OK] Thêm metadata columns vào tblNguoi_phu_thuoc.';
END
ELSE
    PRINT N'[SKIP] tblNguoi_phu_thuoc đã có metadata columns.';
GO

-- ---- tblBienDong ----
IF NOT EXISTS (SELECT 1 FROM sys.columns
               WHERE object_id = OBJECT_ID(N'dbo.tblBienDong')
                 AND name = N'CreatedByTenDangNhap')
BEGIN
    ALTER TABLE dbo.tblBienDong
        ADD CreatedByTenDangNhap    NVARCHAR(50)    NULL,
            UpdatedByTenDangNhap    NVARCHAR(50)    NULL,
            CreatedAt               DATETIME2       NULL DEFAULT SYSUTCDATETIME(),
            UpdatedAt               DATETIME2       NULL;
    PRINT N'[OK] Thêm metadata columns vào tblBienDong.';
END
ELSE
    PRINT N'[SKIP] tblBienDong đã có metadata columns.';
GO

-- ============================================================
-- PHẦN B: CÁCH B — TRIGGER-DRIVEN
--
-- Bước B.1: Ứng dụng set SESSION_CONTEXT trước khi thao tác:
--
--   EXEC sys.sp_set_session_context
--       @key   = N'ActorTenDangNhap',
--       @value = N'<TenDangNhap>';
--
-- Trigger sẽ đọc actor qua:
--   CAST(SESSION_CONTEXT(N'ActorTenDangNhap') AS NVARCHAR(50))
-- Nếu chưa set → actor = NULL (vẫn ghi log, actor để NULL).
--
-- Bước B.2: Tạo trigger INSERT/UPDATE/DELETE cho từng bảng.
--   Trigger hỗ trợ multi-row (dùng CURSOR qua inserted/deleted).
--   old/new data lưu dạng JSON (FOR JSON PATH).
--   PrimaryKey lưu dạng JSON ({"<PKCol>":<PKVal>}).
-- ============================================================

-- ==========================
-- TRIGGER: tblPhuong
-- ==========================
CREATE OR ALTER TRIGGER trg_AuditLog_tblPhuong
ON dbo.tblPhuong
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actor NVARCHAR(50) =
        CAST(SESSION_CONTEXT(N'ActorTenDangNhap') AS NVARCHAR(50));

    -- INSERT
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'INSERT',
            N'tblPhuong',
            (SELECT i.MaPhuong AS MaPhuong FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL,
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i;
        RETURN;
    END

    -- DELETE
    IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'DELETE',
            N'tblPhuong',
            (SELECT d.MaPhuong AS MaPhuong FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL
        FROM deleted d;
        RETURN;
    END

    -- UPDATE
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'UPDATE',
            N'tblPhuong',
            (SELECT i.MaPhuong AS MaPhuong FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i
        JOIN deleted d ON i.MaPhuong = d.MaPhuong;
    END
END
GO

-- ==========================
-- TRIGGER: tblTodanpho
-- ==========================
CREATE OR ALTER TRIGGER trg_AuditLog_tblTodanpho
ON dbo.tblTodanpho
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actor NVARCHAR(50) =
        CAST(SESSION_CONTEXT(N'ActorTenDangNhap') AS NVARCHAR(50));

    -- INSERT
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'INSERT',
            N'tblTodanpho',
            (SELECT i.MaTDP AS MaTDP FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL,
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i;
        RETURN;
    END

    -- DELETE
    IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'DELETE',
            N'tblTodanpho',
            (SELECT d.MaTDP AS MaTDP FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL
        FROM deleted d;
        RETURN;
    END

    -- UPDATE
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'UPDATE',
            N'tblTodanpho',
            (SELECT i.MaTDP AS MaTDP FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i
        JOIN deleted d ON i.MaTDP = d.MaTDP;
    END
END
GO

-- ==========================
-- TRIGGER: tblNhankhau
-- ==========================
CREATE OR ALTER TRIGGER trg_AuditLog_tblNhankhau
ON dbo.tblNhankhau
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actor NVARCHAR(50) =
        CAST(SESSION_CONTEXT(N'ActorTenDangNhap') AS NVARCHAR(50));

    -- INSERT
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'INSERT',
            N'tblNhankhau',
            (SELECT i.MaNK AS MaNK FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL,
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i;
        RETURN;
    END

    -- DELETE
    IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'DELETE',
            N'tblNhankhau',
            (SELECT d.MaNK AS MaNK FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL
        FROM deleted d;
        RETURN;
    END

    -- UPDATE
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'UPDATE',
            N'tblNhankhau',
            (SELECT i.MaNK AS MaNK FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i
        JOIN deleted d ON i.MaNK = d.MaNK;
    END
END
GO

-- ==========================
-- TRIGGER: tblNguoi_phu_thuoc
-- ==========================
CREATE OR ALTER TRIGGER trg_AuditLog_tblNguoi_phu_thuoc
ON dbo.tblNguoi_phu_thuoc
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actor NVARCHAR(50) =
        CAST(SESSION_CONTEXT(N'ActorTenDangNhap') AS NVARCHAR(50));

    -- INSERT
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'INSERT',
            N'tblNguoi_phu_thuoc',
            (SELECT i.MaNPT AS MaNPT FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL,
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i;
        RETURN;
    END

    -- DELETE
    IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'DELETE',
            N'tblNguoi_phu_thuoc',
            (SELECT d.MaNPT AS MaNPT FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL
        FROM deleted d;
        RETURN;
    END

    -- UPDATE
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'UPDATE',
            N'tblNguoi_phu_thuoc',
            (SELECT i.MaNPT AS MaNPT FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i
        JOIN deleted d ON i.MaNPT = d.MaNPT;
    END
END
GO

-- ==========================
-- TRIGGER: tblBienDong
-- ==========================
CREATE OR ALTER TRIGGER trg_AuditLog_tblBienDong
ON dbo.tblBienDong
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @actor NVARCHAR(50) =
        CAST(SESSION_CONTEXT(N'ActorTenDangNhap') AS NVARCHAR(50));

    -- INSERT
    IF EXISTS (SELECT 1 FROM inserted) AND NOT EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'INSERT',
            N'tblBienDong',
            (SELECT i.MaBD AS MaBD FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL,
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i;
        RETURN;
    END

    -- DELETE
    IF EXISTS (SELECT 1 FROM deleted) AND NOT EXISTS (SELECT 1 FROM inserted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'DELETE',
            N'tblBienDong',
            (SELECT d.MaBD AS MaBD FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            NULL
        FROM deleted d;
        RETURN;
    END

    -- UPDATE
    IF EXISTS (SELECT 1 FROM inserted) AND EXISTS (SELECT 1 FROM deleted)
    BEGIN
        INSERT INTO dbo.AuditLog
            (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, OldDataJson, NewDataJson)
        SELECT
            @actor,
            N'UPDATE',
            N'tblBienDong',
            (SELECT i.MaBD AS MaBD FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT d.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
            (SELECT i.* FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)
        FROM inserted i
        JOIN deleted d ON i.MaBD = d.MaBD;
    END
END
GO

PRINT N'============================================================';
PRINT N'Audit.sql đã chạy xong. Kiểm tra kết quả bằng:';
PRINT N'  SELECT TOP 20 * FROM dbo.AuditLog ORDER BY AuditLogId DESC;';
PRINT N'============================================================';
