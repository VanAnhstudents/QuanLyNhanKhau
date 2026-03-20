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
│   ├── Schema.sql                          ← Script tạo toàn bộ bảng, ràng buộc và Stored Procedure
│   ├── SampleData.sql                      ← Script nạp dữ liệu mẫu để test
│   └── DatabaseHelper.cs                   ← Class kết nối CSDL, thực thi query và Stored Procedure
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

## 👥 Thành viên nhóm & Phân công

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