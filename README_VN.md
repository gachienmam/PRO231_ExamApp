<img src="resources/Images/PolyTest Logo Full Horizontal 500x192.png"/>

[Click here to go to the English version](README.md)

Hệ thống phần mềm quản lý và thi trắc nghiệm PolyTest
=====================================================
***by Nhóm 2 - Dự án cuối môn PRO231 (C#, WinForms)***
## Công nghệ
- Máy chủ dựa trên **ASP.NET Core** (.NET 8)
- Liên lạc giữa client và server bằng công nghệ **gRPC**
- Bảo mật bằng **JWT (Json Web Tokens)** và mã hóa bằng **BCrypt**
- Sử dụng **SQL Server**, thiết kế dựa trên mô hình 3 lớp
- Giao diện quản lý và thi bằng **WinForms**

## Sử dụng

### Phần mềm quản lý (ManagementApp)
1. Cài phần mềm bằng file ```Setup.exe``` hoặc ```SetupManagementApp.msi```
2. Vào phần mềm “PolyTest Manager” trên desktop, đăng nhập bằng tài khoản mặc định:
	- User: vanthanh3045@gmail.com
	- Pass: fptgg

<b>Nếu gặp lỗi truy cập máy chủ, sửa link kết nối trong cửa sổ đăng nhập.</b>

---

### Phần mềm thi (StudentApp)
1. Cài phần mềm bằng file ```Setup.exe``` hoặc ```SetupStudentApp.msi```
2. Vào phần mềm “PolyTest Student” trên desktop, đăng nhập bằng tài khoản và mã đề thi bạn đã tạo trong phần mềm quản lý.

<b>Nếu gặp lỗi truy cập máy chủ, hãy sửa link kết nối trong cửa sổ cài đặt.</b>

---

### Máy chủ thi (ExamServer)
1. Thiết lập một máy chủ SQL Server gồm cơ sở dữ liệu gốc bằng cách chạy file .SQL đính kèm (cơ sở dữ liệu dùng chung với máy chủ Management)
2. Giải nén tệp tin chứa máy chủ ExamServer
3. Trong file ```appsettings.json```, đổi các thông tin cần thiết:
	- ```Jwt:Key``` -> Đổi chìa khóa sử dụng để tạo key bảo mật giữa thí sinh và máy chủ (tối thiểu 256 kí tự)
	- ```ConnectionStrings:ExamDatabase``` -> Hãy để chuỗi kết nối vào máy chủ SQL Server mà bạn đã thiết lặp với cơ sở dữ liệu*
4. Bật máy chủ ```ExamServer.exe``` và thưởng thức
5. (Không bắt buộc) Hãy đảm bảo cổng ```50051``` đã được mở (nếu bạn đang mở máy chủ ở một môi trường mạng khác)

<b>* Chú ý: Cả hai hệ thống máy chủ Management và Exam đều sử dụng chung cơ sở dữ liệu, xin hãy để chuỗi kết nối trùng.</b>

---

### Máy chủ quản lý (ManagementServer)

1. Thiết lập một máy chủ SQL Server gồm cơ sở dữ liệu gốc bằng cách chạy file .SQL đính kèm (cơ sở dữ liệu dùng chung với máy chủ Exam)
2. Giải nén tệp tin chứa máy chủ ManagementServer
3. Trong file ```appsettings.json```, đổi các thông tin cần thiết:
	- ```Directory:ExamPapers``` -> Hãy đổi vị trí thư mục chứa đề thi (tại thư mục ExamPapers trong thư mục gốc của máy chủ Exam)
	- ```Jwt:Key``` -> Đổi chìa khóa sử dụng để tạo key bảo mật giữa người dùng và máy chủ (tối thiểu 256 kí tự)
	- ```ConnectionStrings:ExamDatabase``` -> Hãy để chuỗi kết nối vào máy chủ SQL Server mà bạn đã thiết lặp với cơ sở dữ liệu*
4. Bật máy chủ ```ManagementServer.exe``` và thưởng thức
5. (Không bắt buộc) Hãy đảm bảo cổng ```50052``` đã được mở (nếu bạn đang mở máy chủ ở một môi trường mạng khác)

<b>* Chú ý: Cả hai hệ thống máy chủ Management và Exam đều sử dụng chung cơ sở dữ liệu, xin hãy để chuỗi kết nối trùng.</b>

---