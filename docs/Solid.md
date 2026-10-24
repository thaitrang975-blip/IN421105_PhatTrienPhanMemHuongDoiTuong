Single Responsibility Principle (SRP): ClubManager đang tự xử lý quá nhiều việc như thao tác dữ liệu, tính phí và gửi thông báo.

Open/Closed Principle (OCP): Các thuật toán tính phí hoặc phân loại thành viên bị fix cứng bằng if/else trong ClubManager, muốn thêm loại mới phải sửa code cũ.

Liskov Substitution Principle (LSP): Có thể có các class con kế thừa nhưng lại throw NotImplementedException ở một số phương thức không dùng tới.

Dependency Inversion Principle (DIP): ClubManager đang khởi tạo trực tiếp (dùng từ khóa new) các class cụ thể như hệ thống lưu trữ hoặc gửi email, thay vì phụ thuộc vào Interface.