# 📌 Hướng Dẫn Làm Việc Nhóm — QuanLyNhanKhau

---

## 🌅 Công việc thường ngày mỗi khi bắt đầu phiên làm việc

### Bước 1 — Mở terminal tại thư mục project và cập nhật code mới nhất

```bash
git checkout main
git pull origin main
```

> Làm bước này **trước tiên, mỗi ngày, không bỏ qua** — để tránh làm việc trên code cũ và gây xung đột sau này.

---

### Bước 2 — Chuyển sang branch của mình

```bash
git checkout feature/ten-thanh-vien
```

Ví dụ cụ thể từng người:

```bash
# Nguyễn Văn Anh
git checkout feature/van-anh

# Tiêu Thị Vân Anh
git checkout feature/thi-van-anh

# Nguyễn Hữu Khánh
git checkout feature/huu-khanh
```

Nếu branch chưa tồn tại (lần đầu), tạo mới:

```bash
git checkout -b feature/ten-thanh-vien
```

---

### Bước 3 — Cập nhật branch của mình với code mới nhất từ main

```bash
git merge main
```

> Bước này đảm bảo branch của bạn luôn chứa những thay đổi mới nhất từ các thành viên khác đã được merge vào main.

---

### Bước 4 — Mở Visual Studio và bắt đầu code

```
Mở file QuanLyNhanKhau.sln
→ Build → Build Solution (Ctrl + Shift + B)
→ Chờ 0 Error rồi mới bắt đầu code
```

> Nếu build lỗi ngay khi mở — đừng vội code. Đọc lỗi, hỏi nhóm, sửa xong rồi mới tiếp tục.

---

### Bước 5 — Trong lúc code, commit thường xuyên

Không cần đợi xong cả form mới commit. Cứ hoàn thành một phần nhỏ là commit:

```bash
git add .
git commit -m "Q03: Hoàn thành giao diện form đăng ký chủ hộ"
```

```bash
git add .
git commit -m "Q03: Viết xong hàm LoadData và btnThem_Click"
```

```bash
git add .
git commit -m "Q03: Hoàn thiện validate dữ liệu đầu vào"
```

---

### Bước 6 — Kết thúc phiên làm việc, đẩy code lên GitHub

```bash
git push origin feature/ten-thanh-vien
```

---

### Bước 7 — Khi hoàn thành hẳn một nghiệp vụ, tạo Pull Request

1. Vào **https://github.com/VanAnhstudents/QuanLyNhanKhau**
2. GitHub sẽ hiện thông báo **"Compare & pull request"** → nhấn vào
3. Viết mô tả ngắn những gì đã làm
4. Nhấn **Create pull request**
5. Báo **Nguyễn Văn Anh** (trưởng nhóm) vào review và merge

---

## ⚠️ Lưu ý làm việc

### Về Git

- **Không bao giờ commit thẳng lên `main`** — luôn làm việc trên branch riêng của mình. Nhánh `main` chỉ nhận code qua Pull Request đã được review.
- **Không dùng `git push --force`** — lệnh này có thể xóa code của người khác vĩnh viễn.
- **Commit nhỏ, commit thường xuyên** — một commit nên chỉ làm một việc cụ thể, tránh gom quá nhiều thứ vào một commit vì rất khó rollback khi có lỗi.
- **Viết commit message rõ ràng** — người khác nhìn vào phải hiểu ngay bạn làm gì. Tham khảo quy ước đặt tên commit trong `README.md`.

---

### Về Visual Studio và code

- **Luôn Build thành công trước khi push** — không push code đang lỗi build lên GitHub, vì sẽ ảnh hưởng đến toàn bộ nhóm khi pull về.
- **Không sửa file của người khác nếu không báo trước** — nếu cần sửa phần của thành viên khác, nhắn tin thảo luận trước.
- **Không thay đổi file `Schema.sql` và `DatabaseHelper.cs` tùy tiện** — đây là file dùng chung, mọi thay đổi phải được cả nhóm đồng ý và thông báo trước.
- **Đặt tên biến, control theo đúng quy ước** đã thống nhất trong `README.md` — giúp code nhất quán khi ghép lại với nhau.
- **Không để code thừa, code test trong file khi push** — xóa sạch các `Console.WriteLine`, comment debug, code thử trước khi commit.

---

### Về phối hợp nhóm

- **Báo nhóm ngay khi gặp lỗi không tự giải quyết được** — đừng ngồi mãi một mình, mất thời gian cả nhóm.
- **Cập nhật tiến độ mỗi ngày** — dù làm được ít hay nhiều, báo cho nhóm biết hôm nay làm đến đâu.
- **Ưu tiên hoàn thành đúng thứ tự phụ thuộc** — form sau phụ thuộc form trước (xem thứ tự trong `README.md`). Nếu bạn đang làm form phụ thuộc mà form trước chưa xong, báo ngay để nhóm sắp xếp lại.
- **Khi merge xong một Pull Request, cả nhóm cần `git pull origin main`** ngay để đồng bộ, tránh làm việc trên code lạc hậu.

---

## 🆘 Xử lý tình huống hay gặp

| Tình huống | Cách xử lý |
|---|---|
| Merge bị conflict | Mở file conflict, tìm đoạn `<<<<<<< HEAD`, giữ lại đoạn code đúng, xóa marker, commit lại |
| Lỡ commit nhầm lên main | Báo ngay trưởng nhóm để revert, không tự xử lý |
| Build lỗi sau khi pull | Kiểm tra xem có file `.cs` nào bị đổi namespace không, hoặc thiếu `using` |
| Quên tên branch của mình | Chạy `git branch` để xem danh sách branch hiện có |
| Muốn xem lịch sử commit | Chạy `git log --oneline` |
| Muốn hủy thay đổi chưa commit | Chạy `git checkout -- .` *(cẩn thận: không thể hoàn tác)* |