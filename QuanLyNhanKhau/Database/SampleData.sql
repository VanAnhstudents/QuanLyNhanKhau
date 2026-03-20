-- ============================================================
-- SAMPLEDATA.SQL
-- Dữ liệu mẫu cho CSDL: Quản lý Nhân Khẩu Quận
-- ============================================================

USE QuanLyNhanKhau;
GO

-- ============================================================
INSERT INTO tblPhuong 
    (TenPhuong,              DienThoai,       TruSo) VALUES
    (N'Phường Hoàn Kiếm',    '0243.829.1100', N'Số 126 Hàng Trống'),
    (N'Phường Hai Bà Trưng', '0243.829.2200', N'Số 30 Lê Đại Hành'),
    (N'Phường Định Công',    '0243.829.3300', N'Số 1 ngõ 282 đường Kim Giang');
GO

-- ============================================================
INSERT INTO tblTodanpho
    (TenTDP,  MaPhuong, HoTenCSKV,         DienThoaiCSKV,  HoTenToTruong,    DienThoaiToTruong) VALUES
    (N'Tổ 1', 1,        N'Nguyễn Văn An',  '0912.001.001', N'Trần Thị Bình', '0987.001.001'),
    (N'Tổ 2', 1,        N'Lê Văn Cường',   '0912.002.002', N'Phạm Thị Dung', '0987.002.002'),
    (N'Tổ 1', 2,        N'Hoàng Văn Em',   '0912.003.003', N'Vũ Thị Fương',  '0987.003.003'),
    (N'Tổ 2', 2,        N'Đặng Văn Giang', '0912.004.004', N'Bùi Thị Hoa',   '0987.004.004'),
    (N'Tổ 1', 3,        N'Ngô Văn Inh',    '0912.005.005', N'Lý Thị Kim',    '0987.005.005');
GO

-- ============================================================
INSERT INTO tblNhankhau
    (HoTen,              NgaySinh,     GioiTinh, NgheNghiep,    NoiLamViec,                 DiaChi,                               DienThoai,      MaTDP, TrangThai,      NgayDangKy) VALUES
    (N'Nguyễn Văn Hùng', '1975-04-10', 1,        N'Kỹ sư điện', N'Công ty Điện lực Hà Nội', N'Số 12, Ngõ 5, Phường Hai Bà Trưng', '0901.111.111', 1,     N'Đang cư trú', '2018-06-01'),
    (N'Trần Thị Lan',    '1980-08-22', 0,        N'Giáo viên',  N'Trường THCS Trúc Bạch',   N'Số 34, Ngõ 7, Phường Hai Bà Trưng', '0902.222.222', 2,     N'Đang cư trú', '2016-03-15'),
    (N'Lê Văn Minh',     '1968-12-05', 1,        N'Bác sĩ',     N'Bệnh viện Quận Ba Đình',  N'Số 56, Phường Định Công',           '0903.333.333', 3,     N'Đang cư trú', '2010-09-20'),
    (N'Phạm Thị Nga',    '1990-03-15', 0,        N'Kế toán',    N'Công ty TNHH Thành Đạt',  N'Số 78, Phường Định Côngh',          '0904.444.444', 4,     N'Đang cư trú', '2021-11-05'),
    (N'Hoàng Văn Phúc',  '1955-07-30', 1,        N'Hưu trí',    N'Nghỉ hưu',                N'Số 90, Phường Hoàn Kiếm',           '0905.555.555', 5,     N'Đang cư trú', '2008-01-10');
GO

-- ============================================================
INSERT INTO tblNguoi_phu_thuoc
    (MaNK, HoTen,              NgaySinh,     GioiTinh, NgheNghiep,             QuanHe,     TrangThai) VALUES
-- Hộ ông Hùng (MaNK = 1)
    (1,    N'Nguyễn Thị Thu',  '1978-06-18', 0,        N'Nhân viên văn phòng', N'Vợ',      N'Đang cư trú'),
    (1,    N'Nguyễn Văn Khoa', '2005-09-01', 1,        N'Học sinh',            N'Con',     N'Đang cư trú'),
    (1,    N'Nguyễn Thị Linh', '2010-11-20', 0,        N'Học sinh',            N'Con',     N'Đang cư trú'),

-- Hộ bà Lan (MaNK = 2)
    (2,    N'Vũ Văn Nam',      '1978-02-14', 1,        N'Lái xe',              N'Chồng',   N'Đang cư trú'),
    (2,    N'Vũ Thị Oanh',     '2008-04-25', 0,        N'Học sinh',            N'Con',     N'Đang cư trú'),

-- Hộ ông Minh (MaNK = 3)
    (3,    N'Lê Thị Phương',   '1970-09-10', 0,        N'Giáo viên',           N'Vợ',      N'Đang cư trú'),
    (3,    N'Lê Văn Quân',     '1998-12-30', 1,        N'Sinh viên',           N'Con',     N'Đang cư trú'),
    (3,    N'Lê Thị Thảo',     '2002-05-17', 0,        N'Học sinh',            N'Con',     N'Đang cư trú'),

-- Hộ bà Nga (MaNK = 4)
    (4,    N'Đỗ Văn Sơn',      '1988-05-05', 1,        N'Lập trình viên',      N'Chồng',   N'Đang cư trú'),
    (4,    N'Đỗ Thị Ngân',     '2015-08-12', 0,        N'Chưa đi học',         N'Con',     N'Đang cư trú'),

-- Hộ ông Phúc (MaNK = 5)
    (5,    N'Hoàng Thị Tâm',   '1958-01-20', 0,        N'Hưu trí',             N'Vợ',      N'Đang cư trú'),
    (5,    N'Hoàng Văn Uy',    '1985-08-08', 1,        N'Kỹ sư xây dựng',      N'Con',     N'Đang cư trú'),
    (5,    N'Đinh Thị Vân',    '1987-03-25', 0,        N'Giáo viên',           N'Con dâu', N'Đang cư trú');
GO

-- ============================================================
INSERT INTO tblBienDong
    (MaNK, MaNPT, LoaiBienDong,   NgayBienDong, NguoiThucHien,     GhiChu) VALUES
    (1,    NULL,  N'Chuyển đến',  '2018-06-01', N'Nguyễn Văn An',  N'Hộ ông Nguyễn Văn Hùng chuyển từ tỉnh Thanh Hóa về'),
    (2,    NULL,  N'Chuyển đến',  '2016-03-15', N'Lê Văn Cường',   N'Hộ bà Trần Thị Lan chuyển từ tỉnh Nam Định về'),
    (3,    NULL,  N'Đăng ký mới', '2010-09-20', N'Hoàng Văn Em',   N'Hộ ông Lê Văn Minh đăng ký hộ khẩu lần đầu'),
    (4,    NULL,  N'Chuyển đến',  '2021-11-05', N'Đặng Văn Giang', N'Hộ bà Phạm Thị Nga chuyển từ tỉnh Hà Tĩnh về'),
    (5,    NULL,  N'Đăng ký mới', '2008-01-10', N'Ngô Văn Inh',    N'Hộ ông Hoàng Văn Phúc đăng ký hộ khẩu lần đầu'),

-- Khai sinh con thứ hai hộ ông Hùng
    (1,    3,     N'Khai sinh',   '2010-12-01', N'Nguyễn Văn An',  N'Khai sinh cho Nguyễn Thị Linh, sinh ngày 20/11/2010'),

-- Khai sinh con hộ bà Nga
    (4,    10,    N'Khai sinh',   '2015-08-20', N'Đặng Văn Giang', N'Khai sinh cho Đỗ Thị Ngân, sinh ngày 12/08/2015');
GO

-- ============================================================
-- Xem toàn bộ hộ khẩu kèm tổ dân phố và phường
SELECT
    p.TenPhuong,
    t.TenTDP,
    n.HoTen         AS ChuHo,
    n.NgaySinh,
    CASE n.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
    n.NgheNghiep,
    n.DiaChi,
    n.TrangThai
FROM tblNhankhau n
JOIN tblTodanpho t ON n.MaTDP   = t.MaTDP
JOIN tblPhuong   p ON t.MaPhuong = p.MaPhuong
ORDER BY p.TenPhuong, t.TenTDP, n.HoTen;
GO

-- Xem danh sách người phụ thuộc kèm tên chủ hộ
SELECT
    n.HoTen     AS ChuHo,
    pt.HoTen    AS ThanhVien,
    CASE pt.GioiTinh WHEN 1 THEN N'Nam' ELSE N'Nữ' END AS GioiTinh,
    pt.NgaySinh,
    pt.QuanHe,
    pt.NgheNghiep,
    pt.TrangThai
FROM tblNguoi_phu_thuoc pt
JOIN tblNhankhau n ON pt.MaNK = n.MaNK
ORDER BY n.HoTen, pt.QuanHe;
GO

-- Xem lịch sử biến động
SELECT
    bd.NgayBienDong,
    bd.LoaiBienDong,
    n.HoTen     AS ChuHo,
    bd.NguoiThucHien,
    bd.GhiChu
FROM tblBienDong bd
LEFT JOIN tblNhankhau n ON bd.MaNK = n.MaNK
ORDER BY bd.NgayBienDong;
GO