# 🏘️ Quản Lý Nhân Khẩu Quận

## 📋 Mô tả dự án

**Quản Lý Nhân Khẩu Quận** là ứng dụng desktop hỗ trợ công tác quản lý hộ khẩu – nhân khẩu tại cấp quận, thay thế hoàn toàn phương thức quản lý thủ công bằng sổ sách giấy tờ truyền thống.

Chương trình phản ánh đúng cấu trúc hành chính thực tế: **Quận → Phường → Tổ dân phố → Hộ gia đình → Cá nhân**, đồng thời xử lý đầy đủ các nghiệp vụ hộ khẩu phát sinh trong thực tiễn.

### Các chức năng chính

| Nhóm | Chức năng |
|---|---|
| Danh mục | Quản lý Phường, Tổ dân phố |
| Nhân khẩu | Quản lý Chủ hộ, Người phụ thuộc |
| Nghiệp vụ | Khai sinh, Báo tử, Chuyển đến, Chuyển đi, Tách hộ, Nhập hộ |
| Tra cứu | Tìm kiếm theo tên, địa chỉ, tổ dân phố, phường |
| Báo cáo | Thống kê nhân khẩu, biến động theo kỳ (Crystal Report) |

---

## 🛠️ Công nghệ sử dụng

| Công nghệ | Phiên bản | Mục đích |
|---|---|---|
| C# / Windows Forms | .NET Framework 4.7.2 | Ngôn ngữ lập trình & giao diện desktop |
| SQL Server | 2019 trở lên | Hệ quản trị cơ sở dữ liệu |
| T-SQL / Stored Procedure | — | Xử lý nghiệp vụ phía database |
| Crystal Reports | 13.x | Xuất và in báo cáo |
| Visual Studio | 2019 / 2022 | Môi trường phát triển (IDE) |
| Git / GitHub | — | Quản lý phiên bản và cộng tác nhóm |

---

## ⚙️ Yêu cầu cài đặt

Trước khi chạy dự án, máy tính cần có đầy đủ các phần mềm sau:

- [ ] **Visual Studio 2019** hoặc **2022** — có cài workload **.NET desktop development**
- [ ] **SQL Server 2019** trở lên (hoặc SQL Server Express)
- [ ] **SQL Server Management Studio (SSMS)** — để chạy file `.sql`
- [ ] **Crystal Reports Runtime** cho Visual Studio — tải tại [SAP Crystal Reports](https://www.sap.com/products/technology-platform/crystal-visual-studio.html)
- [ ] **Git** — tải tại [https://git-scm.com](https://git-scm.com)

---

## 🚀 Hướng dẫn cài đặt và chạy dự án

### 1. Clone repository về máy

```bash
git clone https://github.com/VanAnhstudents/QuanLyNhanKhau.git
cd QuanLyNhanKhau
```

### 2. Tạo cơ sở dữ liệu

Mở **SQL Server Management Studio (SSMS)** → kết nối vào SQL Server → mở và chạy lần lượt hai file sau:

```
Bước 1: chạy file  Database/Schema.sql       ← tạo cấu trúc CSDL và Stored Procedure
Bước 2: chạy file  Database/SampleData.sql   ← nạp dữ liệu mẫu
```

### 3. Cấu hình chuỗi kết nối

Mở file `Database/DatabaseHelper.cs` → tìm dòng sau và thay `YOUR_SERVER_NAME` bằng tên SQL Server instance trên máy bạn (thường là `localhost` hoặc `.\SQLEXPRESS`):

```csharp
private static string connectionString =
    "Server=YOUR_SERVER_NAME;Database=QuanLyNhanKhau;Integrated Security=True;";
```

### 4. Mở và chạy project

```
1. Mở file  QuanLyNhanKhau.sln  bằng Visual Studio
2. Build → Build Solution  (Ctrl + Shift + B)
3. Chờ build thành công (0 Error)
4. Nhấn F5 để chạy chương trình
```

### 5. Quy trình làm việc nhóm với Git

```bash
# Lấy code mới nhất từ nhóm trước khi bắt đầu làm việc
git pull origin main

# Làm việc trên branch riêng của mình
git checkout -b feature/ten-thanh-vien

# Sau khi code xong, commit và push lên
git add .
git commit -m "Q03: Hoàn thành form đăng ký chủ hộ"
git push origin feature/ten-thanh-vien

# Tạo Pull Request trên GitHub để trưởng nhóm review và merge
```

---

## 📁 Cấu trúc dự án

```
QuanLyNhanKhau/
│
├── QuanLyNhanKhau.sln                      ← File Solution, mở bằng Visual Studio
├── Program.cs                              ← Điểm khởi chạy ứng dụng
├── README.md                               ← Tài liệu hướng dẫn dự án (file này)
├── .gitignore                              ← Danh sách file/thư mục không đưa lên GitHub
│
├── Database/
│   ├── Schema.sql                          ← Script tạo toàn bộ bảng, ràng buộc, Stored Procedure và Triggers audit
│   ├── SampleData.sql                      ← Script nạp dữ liệu mẫu để test
│   └── DatabaseHelper.cs                   ← Class kết nối CSDL, thực thi query và Stored Procedure
│
├── scripts/
│   └── audit.sql                           ← Script nâng cấp độc lập: thêm AuditLog, metadata columns và triggers
│
├── Models/                                 ← Các class đối tượng ánh xạ từ bảng CSDL
│   ├── Phuong.cs                           ← Đối tượng Phường
│   ├── ToDanPho.cs                         ← Đối tượng Tổ dân phố
│   ├── NhanKhau.cs                         ← Đối tượng Chủ hộ
│   ├── NguoiPhuThuoc.cs                    ← Đối tượng Người phụ thuộc
│   └── BienDong.cs                         ← Đối tượng Biến động nhân khẩu
│
├── Forms/
│   ├── frmMain.cs                          ← Form chính MDI Container, chứa MenuStrip điều hướng
│   ├── frmMain.Designer.cs                 ← Code giao diện tự sinh bởi Visual Studio Designer
│   │
│   ├── DanhMuc/                            ← Nhóm Q01, Q02
│   │   ├── frmPhuong.cs                    ← Q01: Thêm/sửa/xóa thông tin phường
│   │   ├── frmPhuong.Designer.cs
│   │   ├── frmToDanPho.cs                  ← Q02: Thêm/sửa/xóa tổ dân phố, CSKV, tổ trưởng
│   │   └── frmToDanPho.Designer.cs
│   │
│   ├── NhanKhau/                           ← Nhóm Q03, Q04
│   │   ├── frmChuHo.cs                     ← Q03: Đăng ký và quản lý hộ gia đình mới
│   │   ├── frmChuHo.Designer.cs
│   │   ├── frmNguoiPhuThuoc.cs             ← Q04: Thêm/sửa/xóa người phụ thuộc trong hộ
│   │   └── frmNguoiPhuThuoc.Designer.cs
│   │
│   ├── NghiepVu/                           ← Nhóm Q05 → Q10
│   │   ├── frmKhaiSinh.cs                  ← Q05: Đăng ký trẻ mới sinh vào hộ
│   │   ├── frmKhaiSinh.Designer.cs
│   │   ├── frmBaoTu.cs                     ← Q06: Xử lý báo tử, cập nhật trạng thái nhân khẩu
│   │   ├── frmBaoTu.Designer.cs
│   │   ├── frmChuyenDi.cs                  ← Q07: Xóa khẩu khi chuyển sang địa bàn khác
│   │   ├── frmChuyenDi.Designer.cs
│   │   ├── frmChuyenDen.cs                 ← Q08: Tiếp nhận nhân khẩu từ địa bàn khác chuyển về
│   │   ├── frmChuyenDen.Designer.cs
│   │   ├── frmTachHo.cs                    ← Q09: Tách một hộ thành nhiều hộ độc lập
│   │   ├── frmTachHo.Designer.cs
│   │   ├── frmNhapHo.cs                    ← Q10: Gộp nhiều hộ thành một hộ chung
│   │   └── frmNhapHo.Designer.cs
│   │
│   ├── TraCuu/                             ← Nhóm Q11, Q12
│   │   ├── frmCapNhatNhanKhau.cs           ← Q11: Cập nhật thông tin cá nhân nhân khẩu
│   │   ├── frmCapNhatNhanKhau.Designer.cs
│   │   ├── frmTraCuu.cs                    ← Q12: Tìm kiếm theo tên, địa chỉ, tổ/phường
│   │   └── frmTraCuu.Designer.cs
│   │
│   └── BaoCao/                             ← Nhóm Q13
│       ├── frmBaoCao.cs                    ← Q13: Gọi và hiển thị các báo cáo Crystal Report
│       └── frmBaoCao.Designer.cs
│
└── Reports/                                ← Các file báo cáo Crystal Report (.rpt)
    ├── rptDanhSachTheoTo.rpt               ← Báo cáo danh sách nhân khẩu theo tổ dân phố
    ├── rptDanhSachTheoPhuong.rpt           ← Báo cáo danh sách nhân khẩu theo phường
    └── rptBienDong.rpt                     ← Báo cáo biến động nhân khẩu trong kỳ
```

---

## 🔍 Audit / Ghi Log Thao Tác (INSERT / UPDATE / DELETE)

Hệ thống cung cấp **hai cách** ghi nhận ai đã thực hiện thao tác INSERT/UPDATE/DELETE trên các bảng nghiệp vụ (tblPhuong, tblTodanpho, tblNhankhau, tblNguoi_phu_thuoc, tblBienDong). Bảng đăng nhập `tblTaiKhoan` **không** được audit.

> Script nâng cấp độc lập: `scripts/audit.sql`  
> Script tổng thể (dùng khi tạo mới CSDL): `Database/Schema.sql`

---

### Cấu trúc bảng dbo.AuditLog

| Cột | Kiểu | Mô tả |
|---|---|---|
| AuditLogId | BIGINT IDENTITY | Khóa chính |
| At | DATETIME2 | Thời điểm UTC xảy ra thao tác |
| ActorTenDangNhap | NVARCHAR(50) | Tên đăng nhập thực hiện (FK logic tới tblTaiKhoan) |
| Action | NVARCHAR(10) | `INSERT` / `UPDATE` / `DELETE` |
| TableName | SYSNAME | Tên bảng bị tác động |
| PrimaryKeyJson | NVARCHAR(MAX) | Khóa chính dạng JSON, ví dụ `{"MaPhuong":1}` |
| OldDataJson | NVARCHAR(MAX) | Dữ liệu trước khi thay đổi (NULL khi INSERT) |
| NewDataJson | NVARCHAR(MAX) | Dữ liệu sau khi thay đổi (NULL khi DELETE) |
| AppName | NVARCHAR(128) | Tên ứng dụng (APP_NAME()) |
| HostName | NVARCHAR(128) | Tên máy chủ (HOST_NAME()) |

---

### Cách A — App-driven (Ứng dụng tự ghi log)

**Ý tưởng:** Mỗi bảng nghiệp vụ có thêm 4 cột metadata. Ứng dụng tự gán giá trị và tự INSERT vào `dbo.AuditLog` trong cùng một transaction khi thao tác dữ liệu.

**Các cột metadata được thêm vào mỗi bảng:**

| Cột | Kiểu | Mô tả |
|---|---|---|
| CreatedByTenDangNhap | NVARCHAR(50) NULL | Tên đăng nhập tạo bản ghi |
| UpdatedByTenDangNhap | NVARCHAR(50) NULL | Tên đăng nhập sửa lần cuối |
| CreatedAt | DATETIME2 NULL | Thời điểm tạo (mặc định SYSUTCDATETIME()) |
| UpdatedAt | DATETIME2 NULL | Thời điểm cập nhật lần cuối |

**Ví dụ C# — Thêm phường mới và ghi AuditLog:**

```csharp
// currentUser là TenDangNhap lấy từ trạng thái đăng nhập của ứng dụng.
// Ví dụ: trong Windows Forms bạn có thể lưu vào biến static sau khi đăng nhập thành công.
// string currentUser = AppSession.TenDangNhap; // thay bằng cách lưu session thực tế trong app
string currentUser = "admin"; // placeholder — thay bằng giá trị thực từ luồng đăng nhập

using (var conn = DatabaseHelper.GetConnection())
{
    conn.Open();
    using (var tx = conn.BeginTransaction())
    {
        // 1) INSERT nghiệp vụ
        var cmdInsert = new SqlCommand(@"
            INSERT INTO tblPhuong
                (TenPhuong, DienThoai, TruSo,
                 CreatedByTenDangNhap, CreatedAt)
            OUTPUT INSERTED.MaPhuong
            VALUES (@ten, @dt, @ts, @actor, SYSUTCDATETIME())", conn, tx);
        cmdInsert.Parameters.AddWithValue("@ten", tenPhuong);
        cmdInsert.Parameters.AddWithValue("@dt",  dienThoai);
        cmdInsert.Parameters.AddWithValue("@ts",  truSo);
        cmdInsert.Parameters.AddWithValue("@actor", currentUser);
        int newId = (int)cmdInsert.ExecuteScalar();

        // 2) Ghi AuditLog trong cùng transaction
        //    PrimaryKeyJson và NewDataJson xây dựng bằng cách nối chuỗi hoặc FOR JSON PATH
        var cmdLog = new SqlCommand(@"
            INSERT INTO dbo.AuditLog
                (ActorTenDangNhap, Action, TableName, PrimaryKeyJson, NewDataJson)
            SELECT
                @actor,
                'INSERT',
                'tblPhuong',
                (SELECT @id AS MaPhuong FOR JSON PATH, WITHOUT_ARRAY_WRAPPER),
                (SELECT @ten AS TenPhuong, @dt AS DienThoai, @ts AS TruSo
                 FOR JSON PATH, WITHOUT_ARRAY_WRAPPER)", conn, tx);
        cmdLog.Parameters.AddWithValue("@actor", currentUser);
        cmdLog.Parameters.AddWithValue("@id",    newId);
        cmdLog.Parameters.AddWithValue("@ten",   tenPhuong);
        cmdLog.Parameters.AddWithValue("@dt",    dienThoai);
        cmdLog.Parameters.AddWithValue("@ts",    truSo);
        cmdLog.ExecuteNonQuery();

        tx.Commit();
    }
}
```

**Ưu / Nhược:**
- ✅ Không cần trigger, dễ debug, có thể log dữ liệu tuỳ chỉnh (loại bỏ field nhạy cảm)
- ✅ Dễ tích hợp vào service layer hoặc repository pattern
- ⚠️ Dev phải nhớ ghi log ở mỗi thao tác; khuyến nghị đóng gói vào một lớp chung

---

### Cách B — Trigger-driven (Trigger tự động ghi log)

**Ý tưởng:** Trigger `AFTER INSERT, UPDATE, DELETE` trên mỗi bảng nghiệp vụ tự ghi vào `dbo.AuditLog`. Actor được lấy từ `SESSION_CONTEXT` do ứng dụng set trước khi thao tác.

#### Bước B.1 — Ứng dụng set SESSION_CONTEXT

Sau khi mở connection (hoặc lấy connection từ pool), **trước bất kỳ lệnh DML nào**, gọi:

```sql
EXEC sys.sp_set_session_context
    @key   = N'ActorTenDangNhap',
    @value = N'admin';    -- thay bằng TenDangNhap thực tế
```

Ví dụ C#:

```csharp
// currentUser là TenDangNhap lấy từ trạng thái đăng nhập của ứng dụng.
// Ví dụ: trong Windows Forms bạn có thể lưu vào biến static sau khi đăng nhập thành công.
// string currentUser = AppSession.TenDangNhap; // thay bằng cách lưu session thực tế trong app
string currentUser = "admin"; // placeholder — thay bằng giá trị thực từ luồng đăng nhập

using (var conn = DatabaseHelper.GetConnection())
{
    conn.Open();

    // Set actor cho toàn bộ session này
    using (var cmdCtx = new SqlCommand(
        "EXEC sys.sp_set_session_context @key = N'ActorTenDangNhap', @value = @actor;",
        conn))
    {
        cmdCtx.Parameters.AddWithValue("@actor", currentUser);
        cmdCtx.ExecuteNonQuery();
    }

    // Sau đó thực hiện thao tác bình thường — trigger sẽ tự ghi log
    using (var cmd = new SqlCommand(
        "INSERT INTO tblPhuong (TenPhuong, DienThoai, TruSo) VALUES (@ten, @dt, @ts)",
        conn))
    {
        cmd.Parameters.AddWithValue("@ten", tenPhuong);
        cmd.Parameters.AddWithValue("@dt",  dienThoai);
        cmd.Parameters.AddWithValue("@ts",  truSo);
        cmd.ExecuteNonQuery();
    }
    // Trigger trg_AuditLog_tblPhuong đã tự động ghi vào dbo.AuditLog
}
```

> **Lưu ý connection pooling:** Nếu ứng dụng dùng connection pool, context sẽ bị giữ lại giữa các request trên cùng một connection vật lý. Hãy luôn set lại context khi mở/lấy connection. Có thể dùng `@read_only = 1` để ngăn overwrite trong cùng session nếu cần.

#### Bước B.2 — Trigger đã được tạo cho các bảng

| Bảng | Trigger | PK |
|---|---|---|
| tblPhuong | trg_AuditLog_tblPhuong | MaPhuong |
| tblTodanpho | trg_AuditLog_tblTodanpho | MaTDP |
| tblNhankhau | trg_AuditLog_tblNhankhau | MaNK |
| tblNguoi_phu_thuoc | trg_AuditLog_tblNguoi_phu_thuoc | MaNPT |
| tblBienDong | trg_AuditLog_tblBienDong | MaBD |

Tất cả trigger đều hỗ trợ **multi-row statements** (dùng `SELECT ... FROM inserted/deleted`, không dùng vòng lặp cursor).

**Ưu / Nhược:**
- ✅ Không thể quên log; hoạt động ngay cả khi thao tác trực tiếp qua SSMS (actor = NULL)
- ✅ Tự động với mọi nguồn thao tác (app, SSMS, script)
- ⚠️ Cần set SESSION_CONTEXT mỗi khi lấy connection; nếu quên, actor ghi NULL
- ⚠️ JSON hóa toàn bộ row có thể ảnh hưởng hiệu năng trên bảng nhiều cột lớn

---

### Hướng dẫn chạy script audit

#### Với CSDL mới (chạy lần đầu)

```
Bước 1: chạy Database/Schema.sql      ← tạo CSDL + bảng + trigger (đã bao gồm audit)
Bước 2: chạy Database/SampleData.sql  ← nạp dữ liệu mẫu
```

#### Với CSDL đang chạy (nâng cấp)

```
Chạy scripts/audit.sql  ← idempotent, có thể chạy lại nhiều lần
```

Script `audit.sql` sẽ:
1. Tạo bảng `dbo.AuditLog` (nếu chưa có)
2. Thêm 4 cột metadata vào 5 bảng nghiệp vụ (nếu chưa có)
3. Tạo/cập nhật 5 trigger audit

#### Kiểm tra sau khi chạy

```sql
-- Xem log mới nhất
SELECT TOP 20 * FROM dbo.AuditLog ORDER BY AuditLogId DESC;

-- Xem log theo bảng và người thực hiện
SELECT TableName, Action, ActorTenDangNhap, At, PrimaryKeyJson
FROM   dbo.AuditLog
WHERE  ActorTenDangNhap = N'admin'
ORDER  BY At DESC;
```

---



| Thành viên | Nhiệm vụ chủ đạo |
|---|---|
| Nguyễn Văn Anh | Q06, Q07 *(độc lập)*, Q08, Q09, Q12 |
| Tiêu Thị Vân Anh | Q01, Q02, Q04 *(độc lập)*, Q05 |
| Nguyễn Hữu Khánh | Q03, Q10, Q11, Q13, Q08 *(độc lập)* |

---

## 📬 Liên hệ

Mọi thắc mắc về kỹ thuật hay vấn đề khác, vui lòng liên hệ:

**Nguyễn Văn Anh**
- 📧 [anhnguyenvan280105@gmail.com](mailto:anhnguyenvan280105@gmail.com)
- 📧 [23a1001d0020@students.hou.edu.vn](mailto:23a1001d0020@students.hou.edu.vn)
- 🐛 Hoặc tạo [Issue](https://github.com/VanAnhstudents/QuanLyNhanKhau/issues) trực tiếp trên GitHub

---

## 📄 Giấy phép

Dự án được thực hiện cho mục đích học tập — môn **Lập trình hướng sự kiện**.  
Không sử dụng cho mục đích thương mại.