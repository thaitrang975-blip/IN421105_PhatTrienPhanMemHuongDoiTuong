# Refactoring EduHub - Ch02 (SOLID & Design Patterns)
**Sinh viên:** Thái Thị Hồng Trang - MSSV: 0024419352

Dự án này là bài tập thực hành refactoring mã nguồn C# nhằm giải quyết tình trạng vi phạm nguyên lý thiết kế. Ban đầu, hệ thống sử dụng một lớp "God Object" là `ClubManager` ôm đồm quá nhiều trách nhiệm, gây khó khăn cho việc bảo trì và mở rộng.

## Mục tiêu đã hoàn thành
- Xóa bỏ lớp `ClubManager` cũ và tái cấu trúc hệ thống theo các nguyên lý **SOLID**.
- Hoàn thiện Domain Logic (quy tắc nghiệp vụ) cho các thực thể `Club` và `Event`.
- Viết Unit Test theo đúng mô hình **AAA (Arrange - Act - Assert)**.
- Quản lý phiên bản bằng Git chuẩn **Conventional Commits**.

## Kiến trúc & SOLID
- **SRP (Single Responsibility Principle):** Tách `ClubManager` thành các dịch vụ độc lập như `ClubService`, `EventService`, và `ReportService`.
- **DIP (Dependency Inversion Principle):** Các dịch vụ giao tiếp với nhau thông qua Interface (ví dụ: `IClubRepository`, `IAppLogger`) thay vì phụ thuộc trực tiếp vào các class cụ thể.
- **OCP (Open/Closed Principle):** Dễ dàng thêm các loại thông báo mới hoặc cách xuất báo cáo mới mà không cần sửa đổi mã nguồn hiện tại.

## Design Patterns đã áp dụng
1. **Factory Pattern:** Sử dụng `NotificationServiceFactory` để khởi tạo linh hoạt các dịch vụ gửi thông báo (Gmail, Yahoo, Generic) dựa trên Enum, loại bỏ các khối `if/else` cứng nhắc.
2. **Decorator Pattern:** Tạo `LoggingClubRepository` đóng vai trò là một lớp bọc (wrapper) xung quanh `IClubRepository` gốc để tự động ghi log mọi thao tác cơ sở dữ liệu mà không làm thay đổi code cũ.
3. **Strategy Pattern:** Tách rời logic xuất báo cáo thông qua `IReportStrategy`, cho phép hệ thống dễ dàng chuyển đổi giữa việc in báo cáo ra Console (`ConsoleReportStrategy`) hoặc định dạng CSV (`CsvReportStrategy`).
4. **Observer Pattern:** Xây dựng cơ chế đăng ký theo dõi sự kiện qua `IEventObserver`. Khi `EventService` tạo một sự kiện mới, tất cả các bên liên quan (EmailNotifier, LogNotifier) đều được tự động thông báo.

## Cấu trúc thư mục
- `/Domain`: Chứa các thực thể cốt lõi (`Club`, `Event`, `Member`) cùng với quy tắc nghiệp vụ nội bộ (HasRoom, Register, CheckIn...).
- `/Interfaces`: Chứa các hợp đồng giao tiếp giữa các thành phần (`IClubRepository`, `IReportStrategy`...).
- `/Services`: Chứa phần triển khai logic nghiệp vụ và các Design Patterns.

## Hướng dẫn chạy và kiểm thử

**1. Biên dịch dự án:**
```bash
dotnet build Ch02.Refactor.sln
